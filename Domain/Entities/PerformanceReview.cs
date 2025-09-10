namespace Worklyn_backend.Domain.Entities
{
    public class PerformanceReview : BaseEntity
    {
        public Guid ReviewId { get; set; }
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public DateTime ReviewDate { get; set; }
        public string Reviewer { get; set; }
        public string Comments { get; set; }
        public int Rating { get; set; }
    }
}
