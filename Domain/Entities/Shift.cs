using Worklyn_backend.Domain.Enum.Shift;

namespace Worklyn_backend.Domain.Entities
{
    public class Shift : BaseEntity
    {
        public Guid CompanyId { get; set; }  
        public Company Company { get; set; }  

        public Guid EmployeeId { get; set; }  
        public Employee Employee { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public bool IsOvernight { get; set; } 

        public string? Notes { get; set; }

        public ShiftType ShiftType { get; set; } = ShiftType.Regular;
    }
}
