
namespace TrySomethingDev.Scheduling.Library.Services
{
    public class Jobs : List<Job>
    {
        private SchedulingApp schedulingApp;

        public Jobs(SchedulingApp schedulingApp)
        {
            this.schedulingApp = schedulingApp;
        }
    }
}