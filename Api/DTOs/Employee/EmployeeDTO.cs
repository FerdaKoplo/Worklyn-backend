namespace Worklyn_backend.Api.DTOs.Employee
{
    public class EmployeeDTO
    {
        public Guid EmployeeId { get; set; }
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
