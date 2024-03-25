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
            im.ImportSingleJob();

            int resourceCount = _schedulingApp.GetResources().Count();
            Assert.That(1, Is.EqualTo(resourceCount));
          
        }

        [Test]
        public void SequenceJobs()
        {

            var im = _schedulingApp.GetImportManager();

            im.ImportSingleResource();
            im.ImportSingleJob();

            int resourceCount = _schedulingApp.GetResources().Count();
            Assert.That(1, Is.EqualTo(resourceCount));

            var res1 = _schedulingApp.GetResources().First();
            
            Assert.AreEqual(0,res1.JobsScheduled.Count());
            
            var s = _schedulingApp.GetSequencer();
            
            s.SequenceAll();
            Assert.AreEqual(1,res1.JobsScheduled.Count());
        }
    }
}