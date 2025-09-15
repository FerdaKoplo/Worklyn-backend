namespace Worklyn_backend.Api.DTOs.Department
{
    public class UpdateDepartmentDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? ManagerId { get; set; }
        public string Status { get; set; }
    }
}
