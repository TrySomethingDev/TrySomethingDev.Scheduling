
namespace TrySomethingDev.Scheduling.Library.Services
{
    public class Sequencer
    {
        private SchedulingApp _app;
        private DateTime _planStartTime;
        private double _timeBetweenJobs;

        public Sequencer(SchedulingApp schedulingApp)
        {
            _timeBetweenJobs = 1;
            _app = schedulingApp;
            _planStartTime = new DateTime(2024, 1, 1);
        }

        public void SequenceAll()
        {
         var firstRes =    _app.GetResources().First();
            foreach (Job job in _app.GetJobs())
            {
                DateTime nextAvailableTime;

                Resource resource = GetResourceWithEarliestAvailableTime(job, out nextAvailableTime);

                job.AssignedToResource = resource;
                job.DateTimeStart = (DateTime) nextAvailableTime;
                job.DateTimeEnd = (DateTime) nextAvailableTime + job.duration;
                resource.JobsScheduled.Add(job);
            }
        }

        private Resource GetResourceWithEarliestAvailableTime(Job job, out DateTime nextAvailableTime)
        {
            Resource soonestAvailableResource = null;
            nextAvailableTime = DateTime.MaxValue;
            
            foreach (Resource resource in _app.GetResources())
            {
                if (resource.JobsScheduled.Any())
                {
                  var latestJobEndTime = resource.JobsScheduled.Max(x => x.DateTimeEnd);
                  
                    if(latestJobEndTime < nextAvailableTime)
                    {
                        nextAvailableTime = latestJobEndTime;
                        soonestAvailableResource= resource;
                    }
                }
                else
                {
                    //If we find a resource with nothing on it yet. We can go ahead and schedule there. Since nothing will be scheduled earlier than this.
                    soonestAvailableResource = resource;
                    nextAvailableTime = this._planStartTime;
                    return soonestAvailableResource;
                }
             
            }

            return soonestAvailableResource;


        }
    }
}