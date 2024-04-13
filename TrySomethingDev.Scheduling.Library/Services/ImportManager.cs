


using System.Resources;

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

        public void ImportTwoJobs()
        {
            var jobs = _app.GetJobs();
            Job job = new Job();
            jobs.Add(job);

            job = new Job();
            jobs.Add(job);
        }

        public void ImportTwoResources()
        {
            
           var resources = _app.GetResources();

            Resource resource = new Resource(_app);
            resource.Name = "ResourceA";
            resources.Add(resource);

            resource = new Resource(_app);
            resource.Name = "ResourceB";
            resources.Add(resource);


        }

        public void ImportThreeJobs()
        {
            var jobs = _app.GetJobs();
            Job job = new Job();
            job.Id = 1;
            jobs.Add(job);

            job = new Job();
            job.Id = 2;
            jobs.Add(job);

            job = new Job();
            job.Id = 3;
            jobs.Add(job);
        }


    }
}