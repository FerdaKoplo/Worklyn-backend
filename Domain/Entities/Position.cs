using Worklyn_backend.Domain.ValueObjects.Finance;

namespace Worklyn_backend.Domain.Entities
{
    public class Position : BaseEntity
    {
        public int PositionId { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public MoneyVO BaseSalary { get; set; }
    }
}
