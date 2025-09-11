using Casbin.Persist.Adapter.EFCore;
using Microsoft.EntityFrameworkCore;

namespace Worklyn_backend.Domain.Data
{
    public class CasbinDbContext : CasbinDbContext<int>
    {
        public CasbinDbContext(DbContextOptions<CasbinDbContext> options) : base(options) { }
    }
}
