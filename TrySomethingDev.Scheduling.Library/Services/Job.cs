
namespace TrySomethingDev.Scheduling.Library.Services
{
    public class Job
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public TimeSpan duration { get; set; } = TimeSpan.FromHours(1);

        public DateTime DateTimeStart { get; set; }
        public DateTime DateTimeEnd { get; set; }
        public Resource AssignedToResource { get; set; }
    }
}