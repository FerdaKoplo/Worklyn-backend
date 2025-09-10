using Worklyn_backend.Domain.Enum.SubscriptionStatus;

namespace Worklyn_backend.Domain.Entities
{
    public class Subscription : BaseEntity
    {
        public Guid SubscriptionId { get; set; }

        public Guid CompanyId { get; set; }
        public Company Company { get; set; }

        public SubscriptionPlan Plan { get; set; }  
        public SubscriptionStatus Status { get; set; } 

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool AutoRenew { get; set; }

        public Guid PaymentMethodID { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public decimal Price { get; set; }
    }
}
