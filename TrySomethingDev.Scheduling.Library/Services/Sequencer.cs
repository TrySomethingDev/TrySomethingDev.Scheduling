
namespace TrySomethingDev.Scheduling.Library.Services
{
    public class Sequencer
    {
        private SchedulingApp _app;

        public Sequencer(SchedulingApp schedulingApp)
        {
            _app = schedulingApp;
        }

        public void SequenceAll()
        {
         var firstRes =    _app.GetResources().First();
            foreach (Job job in _app.GetJobs())
            {
                firstRes.JobsScheduled.Add(job);
            }
        }
    }
}