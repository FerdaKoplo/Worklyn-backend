namespace Worklyn_backend.Api.DTOs.Department
{
    public class DepartmentFilterDTO
    {
        public string? Name { get; set; }
        public string? Status { get; set; }
        public Guid? CompanyId { get; set; }
    }
}
