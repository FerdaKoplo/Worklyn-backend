using Worklyn_backend.Domain.Enum.SubscriptionStatus;

namespace Worklyn_backend.Domain.Entities
{
    public class Company : BaseEntity
    {
        public int CompanyID { get; set; }
        // Identity
        public string Name { get; set; }
        public string LegalName { get; set; }   // full registered name
        public string RegistrationNumber { get; set; } //  NPWP or business license number

        // Contact info
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        // Address
        public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }

        // SaaS specifics
        public SubscriptionPlan CurrentPlan { get; set; } = SubscriptionPlan.Free;
        public SubscriptionStatus Status { get; set; } = SubscriptionStatus.Trial;
        public DateTime SubscriptionExpiry { get; set; }

        // Navigation
        public ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
        public ICollection<Department> Departments { get; set; } = new List<Department>();
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
        public ICollection<Payroll> Payrolls { get; set; } = new List<Payroll>();
    }
}
