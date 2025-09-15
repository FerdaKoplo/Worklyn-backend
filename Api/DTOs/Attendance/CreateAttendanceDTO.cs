namespace Worklyn_backend.Api.DTOs.Attendance
{
    public class CreateAttendanceDTO
    {
        public Guid EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan CheckIn { get; set; }
        public TimeSpan? CheckOut { get; set; }
        public string Notes { get; set; }
    }
}
