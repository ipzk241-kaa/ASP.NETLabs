using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace CoursesApp.Infrastructure
{
    public class CoursesHub : Hub
    {
        public async Task SendNewCourseNotification(string category, string courseName)
        {
            await Clients.Group(category).SendAsync("ReceiveNewCourse", courseName);
        }

        public async Task SubscribeCategory(string category)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, category);
        }

        public async Task UnsubscribeCategory(string category)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, category);
        }
    }
}
