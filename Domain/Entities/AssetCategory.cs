namespace Worklyn_backend.Domain.Entities
{
    public class AssetCategory : BaseEntity
    {
        public int AssetCategoryId { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }

        public string Name { get; set; }
    }
}
