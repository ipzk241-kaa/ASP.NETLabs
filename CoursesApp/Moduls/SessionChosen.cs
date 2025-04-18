namespace CoursesApp.Models
{
    public class SessionChosen : Chosen
    {
        public static Chosen GetChosen(IServiceProvider services)
        {
            var session = services.GetRequiredService<IHttpContextAccessor>()
                .HttpContext!.Session;

            var chosen = session.GetJson<SessionChosen>("Chosen") ?? new SessionChosen();
            chosen._session = session;
            return chosen;
        }

        private ISession? _session;

        public override void AddItem(Course course)
        {
            base.AddItem(course);
            _session?.SetJson("Chosen", this);
        }

        public override void RemoveItem(long courseId)
        {
            base.RemoveItem(courseId);
            _session?.SetJson("Chosen", this);
        }

        public override void Clear()
        {
            base.Clear();
            _session?.Remove("Chosen");
        }
    }
}
