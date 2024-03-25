
namespace TrySomethingDev.Scheduling.Library.Services
{
    public class ImportManager
    {
        private SchedulingApp _app;

        public ImportManager(SchedulingApp schedulingApp)
        {
            _app = schedulingApp;
        }

        public void ImportSingleResource()
        {
           var resources = _app.GetResources();

            Resource resource = new Resource(_app);
            resource.Name = "Test Resource 1";
            
            resources.Add(resource);
            

        }

        public void ImportSingleJob()
        {
            var jobs = _app.GetJobs();

            Job job = new Job();

            jobs.Add(job);
        }
    }
}