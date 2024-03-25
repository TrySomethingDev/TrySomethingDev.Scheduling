
using System.Collections;

namespace TrySomethingDev.Scheduling.Library.Services
{

    public class Resources: List<Resource>
    {
        private SchedulingApp schedulingApp;

        public Resources(SchedulingApp schedulingApp)
        {
            this.schedulingApp = schedulingApp;
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}