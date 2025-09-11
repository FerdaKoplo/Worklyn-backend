using Worklyn_backend.Domain.Enum.Asset;

namespace Worklyn_backend.Domain.Entities
{
    public class Asset : BaseEntity
    {
        public Guid AssetId { get; set; }
        public int AssetCategoryId { get; set; }
        public AssetCategory Category { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }

        public string AssetTag { get; set; }
        public string Description { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal Value { get; set; }
        public AssetStatus Status { get; set; } = AssetStatus.Available;
    }
}
