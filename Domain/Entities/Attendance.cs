using Worklyn_backend.Domain.Enum.Attendance;

namespace Worklyn_backend.Domain.Entities
{
    public class Attendance : BaseEntity
    {
        public Guid AttendanceId { get; set; }
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public DateTime Date { get; set; }
        public TimeSpan CheckIn { get; set; }
        public TimeSpan? CheckOut { get; set; }

        public AttendanceStatus Status { get; set; } = AttendanceStatus.Absent;
        public string Notes { get; set; }

    }
}
