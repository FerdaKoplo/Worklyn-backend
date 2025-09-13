namespace Worklyn_backend.Api.DTOs.EmployeeProfile
{
    public class EmployeeSearchFilter
    {
        public string? Name { get; set; }
        public int? DepartmentId { get; set; }
        public int? PositionId { get; set; }
        public string? Status { get; set; }
    }
}
