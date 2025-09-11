namespace Worklyn_backend.Domain.Entities
{
    public class TrainingCourse : BaseEntity
    {
        public Guid TrainingCourseId { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public int DurationHours { get; set; }
        public string Instructor { get; set; }
        public ICollection<EmployeeCourseEnrollment> Enrollments { get; set; } = new List<EmployeeCourseEnrollment>();
    }
}
