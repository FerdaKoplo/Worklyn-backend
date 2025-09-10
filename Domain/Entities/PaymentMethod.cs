using Worklyn_backend.Domain.Enum.Payment;

namespace Worklyn_backend.Domain.Entities
{
    public class PaymentMethod : BaseEntity
    {
        public Guid PaymentMethodId { get; set; }

        public Guid CompanyId { get; set; }
        public Company Company { get; set; }

        public PaymentMethodType Type { get; set; }
        public PaymentMethodPriority Priority { get; set; }
        public string Provider { get; set; }   
        public string Token { get; set; }           
        public string MaskedAccount { get; set; }    
        public DateTime? Expiry { get; set; }
    }
}
