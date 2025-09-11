using Worklyn_backend.Domain.Enum.Enrollment;

namespace Worklyn_backend.Domain.Entities
{
    public class EmployeeCourseEnrollment : BaseEntity
    {
        public Guid EnrollmentId { get; set; }

        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public Guid TrainingCourseId { get; set; }
        public TrainingCourse TrainingCourse { get; set; }

        public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow;

        public EnrollmentStatus Status { get; set; } = EnrollmentStatus.Pending;
        public decimal? Score { get; set; }
    }
}
