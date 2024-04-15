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
        public void SequenceJobsPlacesJobInResource()
        {

            var im = _schedulingApp.GetImportManager();

            im.ImportSingleResource();
            im.ImportSingleJob();

            int resourceCount = _schedulingApp.GetResources().Count();
            Assert.That(1, Is.EqualTo(resourceCount));

            var res1 = _schedulingApp.GetResources().First();

            Assert.AreEqual(0, res1.JobsScheduled.Count());

            var s = _schedulingApp.GetSequencer();

            s.SequenceAll();
            Assert.AreEqual(1, res1.JobsScheduled.Count());
        }

        [Test]
        public void IfTwoJobsAreScheduledOnTheSameResourceTheyShouldNotOverlap()
        {
            var im = _schedulingApp.GetImportManager();
            im.ImportSingleResource();
            im.ImportTwoJobs();
            int resourceCount = _schedulingApp.GetResources().Count();
            Assert.That(1, Is.EqualTo(resourceCount));
            var res1 = _schedulingApp.GetResources().First();
            Assert.AreEqual(0, res1.JobsScheduled.Count());
            var s = _schedulingApp.GetSequencer();
            s.SequenceAll();
            //Get the first Job on the Resource
            Job job1 = res1.JobsScheduled.First();
            //Get the Second Job on the Resource
            Job job2 = res1.JobsScheduled.Last();
            //See if their dates overlap.
            if (AreDateRangesOverlapping(job1.DateTimeStart, job1.DateTimeEnd, job2.DateTimeStart, job2.DateTimeEnd))
            {
                Assert.Fail("Jobs are overlapping");
            }
            Assert.Pass("No problems found");
        }

        bool AreDateRangesOverlapping(DateTime startA, DateTime endA, DateTime startB, DateTime endB)
        {
            return startA <= endB && startB <= endA;
        }


        [Test]
        public void WhenSchedulingLookForTheResoureThatIsAvailableTheSoonestAndScheduleTheJobThere()
        {
            var im = _schedulingApp.GetImportManager();
            im.ImportTwoResources();
            im.ImportThreeJobs();

            //Make sure we have the correct number of resources
            int resourceCount = _schedulingApp.GetResources().Count();
            Assert.That(2, Is.EqualTo(resourceCount));


            //Make sure nothing is scheduled on resource 1
            var res1 = _schedulingApp.GetResources().First();
            Assert.AreEqual(0, res1.JobsScheduled.Count());

            //Make sure nothing is scheduled on resource 2
            var res2 = _schedulingApp.GetResources().Last();
            Assert.AreEqual(0, res2.JobsScheduled.Count());

            var s = _schedulingApp.GetSequencer();
            s.SequenceAll();

            Job job1 = _schedulingApp.GetJobs().First(x => x.Id == 1);
            Job job2 = _schedulingApp.GetJobs().First(x => x.Id == 2);
            Job job3 = _schedulingApp.GetJobs().First(x => x.Id == 3);

            //Make sure Job1 is assigned to correct resource
            Resource res = job1.AssignedToResource;
            if (res == null) Assert.Fail("Job AssignedToResource is null");

            Assert.AreEqual("ResourceA", res.Name);

            //Make sure Job2 is assigned to correct resource
            res = job2.AssignedToResource;
            if (res == null) Assert.Fail("Job AssignedToResource is null");
            Assert.AreEqual("ResourceB", res.Name);

            //Make sure Job3 is assigned to correct resource
            res = job3.AssignedToResource;
            if (res == null) Assert.Fail("Job AssignedToResource is null");
            Assert.AreEqual("ResourceA", res.Name);



            Assert.AreEqual(new DateTime(2024, 01, 01, 0, 0, 0), job1.DateTimeStart);
            Assert.AreEqual(new DateTime(2024, 01, 01, 0, 0, 0), job2.DateTimeStart);
            Assert.AreEqual(new DateTime(2024, 01, 01, 1, 0, 0), job3.DateTimeStart);



            Assert.Pass("No problems found");
        }


        [Test]
        public void Sc()
        {
            var im = _schedulingApp.GetImportManager();
            im.ImportTwoResources();
            im.ImportThreeJobs();

            //Make sure we have the correct number of resources
            int resourceCount = _schedulingApp.GetResources().Count();
            Assert.That(2, Is.EqualTo(resourceCount));


            //Make sure nothing is scheduled on resource 1
            var res1 = _schedulingApp.GetResources().First();
            Assert.AreEqual(0, res1.JobsScheduled.Count());

            //Make sure nothing is scheduled on resource 2
            var res2 = _schedulingApp.GetResources().Last();
            Assert.AreEqual(0, res2.JobsScheduled.Count());

            var s = _schedulingApp.GetSequencer();
            s.SequenceAll();

            Job job1 = _schedulingApp.GetJobs().First(x => x.Id == 1);
            Job job2 = _schedulingApp.GetJobs().First(x => x.Id == 2);
            Job job3 = _schedulingApp.GetJobs().First(x => x.Id == 3);

            //Make sure Job1 is assigned to correct resource
            Resource res = job1.AssignedToResource;
            if (res == null) Assert.Fail("Job AssignedToResource is null");

            Assert.AreEqual("ResourceA", res.Name);

            //Make sure Job2 is assigned to correct resource
            res = job2.AssignedToResource;
            if (res == null) Assert.Fail("Job AssignedToResource is null");
            Assert.AreEqual("ResourceB", res.Name);

            //Make sure Job3 is assigned to correct resource
            res = job3.AssignedToResource;
            if (res == null) Assert.Fail("Job AssignedToResource is null");
            Assert.AreEqual("ResourceA", res.Name);



            Assert.AreEqual(new DateTime(2024, 01, 01, 0, 0, 0), job1.DateTimeStart);
            Assert.AreEqual(new DateTime(2024, 01, 01, 0, 0, 0), job2.DateTimeStart);
            Assert.AreEqual(new DateTime(2024, 01, 01, 1, 0, 0), job3.DateTimeStart);



            Assert.Pass("No problems found");
        }
    }
}
