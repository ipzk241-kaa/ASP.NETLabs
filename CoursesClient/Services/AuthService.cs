using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text.Json;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Components.Authorization;
using Courses.Domain.DTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

public class AuthService : AuthenticationStateProvider
{
    private readonly HttpClient _http;
    private readonly IJSRuntime _js;
    private readonly NavigationManager _nav;
    private const string TokenKey = "authToken";

    public AuthService(HttpClient http, IJSRuntime js, NavigationManager nav)
    {
        _http = http;
        _js = js;
        _nav = nav;
    }

    public async Task<bool> Login(LoginDto model)
    {
        var response = await _http.PostAsJsonAsync("auth/login", model);
        if (!response.IsSuccessStatusCode)
            return false;

        var json = await response.Content.ReadAsStringAsync();
        var token = JsonDocument.Parse(json).RootElement.GetProperty("token").GetString();

        await _js.InvokeVoidAsync("localStorage.setItem", TokenKey, token);
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        return true;
    }

    public async Task Logout()
    {
        await _js.InvokeVoidAsync("localStorage.removeItem", TokenKey);
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        _nav.NavigateTo("/");
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var token = await _js.InvokeAsync<string>("localStorage.getItem", TokenKey);
        var identity = new ClaimsIdentity();

        if (!string.IsNullOrWhiteSpace(token))
        {
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(token);
            var claims = jwt.Claims;

            identity = new ClaimsIdentity(claims, "jwt");
        }

        var user = new ClaimsPrincipal(identity);
        return new AuthenticationState(user);
    }

    public async Task<string?> GetToken()
    {
        return await _js.InvokeAsync<string>("localStorage.getItem", TokenKey);
    }
}
