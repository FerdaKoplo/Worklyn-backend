using Worklyn_backend.Domain.Enum.Department;

namespace Worklyn_backend.Domain.Entities
{
    public class Department : BaseEntity
    {
        public int DepartmentID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ManagerID { get; set; }
        public Employee Manager { get; set; }

        public Guid CompanyId { get; set; } 
        public Company Company { get; set; }


        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
        public DepartmentStatus Status { get; set; } = DepartmentStatus.Active;
    }
}
