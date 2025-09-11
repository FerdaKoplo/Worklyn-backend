using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Worklyn_backend.Domain.Data;

namespace Worklyn_backend.Domain.Factory
{
    public class CasbinDbContextFactory : IDesignTimeDbContextFactory<CasbinDbContext>
    {
        public CasbinDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<CasbinDbContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new CasbinDbContext(optionsBuilder.Options);
        }
    }
}
