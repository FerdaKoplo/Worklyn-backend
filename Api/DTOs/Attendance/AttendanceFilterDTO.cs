namespace Worklyn_backend.Api.DTOs.Attendance
{
    public class AttendanceFilterDTO
    {
        public Guid? EmployeeId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string? Status { get; set; }
    }
}
