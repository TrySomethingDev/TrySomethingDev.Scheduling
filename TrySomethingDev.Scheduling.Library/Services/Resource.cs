namespace TrySomethingDev.Scheduling.Library.Services
{
    public class Resource
    {
        private SchedulingApp _app;

        public Resource(SchedulingApp schedulingApp)
        {
            _app = schedulingApp;
            JobsScheduled = new Jobs(_app);
        }
        public string? Name { get; internal set; }

        public Jobs JobsScheduled { get; set; }

	}
}