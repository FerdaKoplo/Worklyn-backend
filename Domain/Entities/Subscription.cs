using Worklyn_backend.Domain.Enum.SubscriptionStatus;
using Worklyn_backend.Domain.ValueObjects.Date;
using Worklyn_backend.Domain.ValueObjects.Finance;

namespace Worklyn_backend.Domain.Entities
{
    public class Subscription : BaseEntity
    {
        public Guid SubscriptionId { get; set; }

        public Guid CompanyId { get; set; }
        public Company Company { get; set; }

        public SubscriptionPlan Plan { get; set; }  
        public SubscriptionStatus Status { get; set; }

        public DateRangeVO Period { get; set; }
        public bool AutoRenew { get; set; }

        public Guid PaymentMethodID { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public MoneyVO Price { get; set; }
    }
}
