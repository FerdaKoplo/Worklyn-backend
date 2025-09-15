namespace Worklyn_backend.Api.DTOs.Attendance
{
    public class UpdateAttendanceDTO
    {
        public TimeSpan? CheckOut { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; }
    }
}
