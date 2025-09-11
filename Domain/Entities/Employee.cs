using Worklyn_backend.Domain.Enum.Employee;

namespace Worklyn_backend.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public Guid EmployeeId { get; set; }
        public string EmployeeNumber { get; set; }

        // Job Info
        public int PositionId { get; set; }
        public int DepartmentId { get; set; }
        public Guid? ManagerId { get; set; }
        public DateTime HireDate { get; set; }
        public Guid CompanyId { get; set; }

        // Employement Status
        public EmployeeStatus Status { get; set; } 
        public EmployementType EmployementType { get; set; }

        // navigation
        public Company Company { get; set; }
        public EmployeeProfile Profile { get; set; }
        public Department Department { get; set; }
        public Position Position { get; set; }
        public Employee Manager { get; set; }
            
        public ICollection<Payroll> Payrolls { get; set; } = new List<Payroll>();
        public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
        public ICollection<LeaveRequest> LeaveRequests { get; set; } = new List<LeaveRequest>();
        public ICollection<Shift> Shifts { get; set; } = new List<Shift>();
        public ICollection<EmployeeCourseEnrollment> CourseEnrollments { get; set; } = new List<EmployeeCourseEnrollment>();

    }
}
