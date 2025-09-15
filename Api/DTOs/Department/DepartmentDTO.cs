namespace Worklyn_backend.Api.DTOs.Department
{
    public class DepartmentDTO
    {
        public int DepartmentID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? ManagerId { get; set; }
        public string? ManagerName { get; set; }
        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Status { get; set; }

    }
}
