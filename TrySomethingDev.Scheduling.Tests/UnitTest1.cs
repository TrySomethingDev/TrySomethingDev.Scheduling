using TrySomethingDev.Scheduling.Library.Services;

namespace TrySomethingDev.Scheduling.Tests
{
    public class Tests
    {
        private SchedulingApp _schedulingApp;

        [SetUp]
        public void Setup()
        {
            _schedulingApp = new SchedulingApp();
        }

        [Test]
        public void ImportResource()
        {
            var im = _schedulingApp.GetImportManager();

            im.ImportSingleResource();

            int resourceCount = _schedulingApp.Resources.Count();
            Assert.Equals(resourceCount, 1);
          
        }

        [Test]
        public void SequenceJobs()
        { 
            var res1 = _schedulingApp.Resources.First();
            
            Assert.Equals(res1.JobsScheduled, 0);
            
            var s = _schedulingApp.GetSequencer();
            
            s.SequenceAll();
            Assert.Equals(res1.JobsScheduled, 1);
        }
    }
}