namespace Worklyn_backend.Api.DTOs.Attendance
{
    public class AttendanceDTO
    {
        public Guid AttendanceId { get; set; }
        public Guid EmployeeId { get; set; }
        public string EmployeeName { get; set; } 
        public DateTime Date { get; set; }
        public TimeSpan CheckIn { get; set; }
        public TimeSpan? CheckOut { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
    }
}
