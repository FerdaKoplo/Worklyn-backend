using Worklyn_backend.Domain.Enum.Employee;

namespace Worklyn_backend.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public Guid EmployeeID { get; set; }
        public string EmployeeNumber { get; set; }

        // Job Info
        public int PositionID { get; set; }
        public int DepartmentID { get; set; }
        public Guid? ManagerID { get; set; }
        public DateTime HireDate { get; set; }

        // Employement Status
        public EmployeeStatus Status { get; set; } 
        public EmployementType EmployementType { get; set; }

        // navigation
        public EmployeeProfile Profile { get; set; }
        public Department Department { get; set; }
        public Position Position { get; set; }
        public Employee Manager { get; set; }  


    }
}
