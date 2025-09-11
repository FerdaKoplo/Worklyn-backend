using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Worklyn_backend.Domain.Data;

namespace Worklyn_backend.Domain.Factory
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            optionsBuilder.UseSqlServer("Server=localhost;Database=WorklynDb;Trusted_Connection=True;");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
