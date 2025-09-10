namespace Worklyn_backend.Domain.Entities
{
    public class LeaveType : BaseEntity
    {
        public int LeaveTypeId { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }

        public string Name { get; set; }
        public int MaxDaysPerYear { get; set; }
        public bool IsPaid { get; set; }
    }
}
