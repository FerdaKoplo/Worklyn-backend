using Worklyn_backend.Domain.Enum.Employee;

namespace Worklyn_backend.Domain.Entities
{
    public class LeaveRequest : BaseEntity
    {
        public Guid LeaveRequestId { get; set; }

        public Guid CompanyId { get; set; }
        public Company Company { get; set; }

        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int LeaveTypeId { get; set; }
        public LeaveType LeaveType { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TotalDays { get; set; }

        public string Reason { get; set; }
        public string AttachmentUrl { get; set; }

        public Guid? ApproverId { get; set; }   
        public Employee Approver { get; set; }
        public LeaveRequestStatus Status { get; set; }
    }
}
