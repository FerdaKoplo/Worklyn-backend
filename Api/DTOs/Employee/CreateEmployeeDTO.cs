namespace Worklyn_backend.Api.DTOs.Employee
{
    public class CreateEmployeeDTO
    {
        public string EmployeeNumber { get; set; }
        public int PositionId { get; set; }
        public int DepartmentId { get; set; }
        public Guid? ManagerId { get; set; }
        public DateTime HireDate { get; set; }
        public Guid CompanyId { get; set; }
        public string Status { get; set; }
        public string EmployementType { get; set; }
    }
}
