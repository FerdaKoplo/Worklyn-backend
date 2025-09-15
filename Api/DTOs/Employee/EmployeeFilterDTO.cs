namespace Worklyn_backend.Api.DTOs.Employee
{
    public class EmployeeFilterDTO
    {
        public string? Name { get; set; }
        public int? DepartmentId { get; set; }
        public int? PositionId { get; set; }
        public string? Status { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
