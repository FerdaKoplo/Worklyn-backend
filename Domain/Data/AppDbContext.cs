using Microsoft.EntityFrameworkCore;
using Worklyn_backend.Domain.Entities;

namespace Worklyn_backend.Domain.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Payroll> Payrolls { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ---------- Company Relationships ----------
            modelBuilder.Entity<Company>()
                .HasMany(c => c.Departments)
                .WithOne(d => d.Company)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Company>()
                .HasMany(c => c.Employees)
                .WithOne(e => e.Company)
                .HasForeignKey(e => e.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Company>()
                .HasMany(c => c.Payrolls)
                .WithOne(p => p.Company)
                .HasForeignKey(p => p.CompanyID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Company>()
                .HasMany(c => c.Subscriptions)
                .WithOne(s => s.Company)
                .HasForeignKey(s => s.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Company>()
                .HasMany(c => c.PaymentMethods)
                .WithOne(pm => pm.Company)
                .HasForeignKey(pm => pm.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Company>()
                .HasMany(c => c.TrainingCourses)
                .WithOne(tc => tc.Company)
                .HasForeignKey(tc => tc.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Company>()
                .HasMany(c => c.Assets)
                .WithOne(a => a.Company)
                .HasForeignKey(a => a.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            // ---------- Department Relationships ----------
            modelBuilder.Entity<Department>()
                .HasMany(d => d.Employees)
                .WithOne(e => e.Department)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Department>()
                .HasOne(d => d.Manager)
                .WithMany()
                .HasForeignKey(d => d.ManagerID)
                .OnDelete(DeleteBehavior.SetNull);

            // ---------- Employee Relationships ----------
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Manager)
                .WithMany()
                .HasForeignKey(e => e.ManagerId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Profile)
                .WithOne(p => p.Employee)
                .HasForeignKey<EmployeeProfile>(p => p.EmployeeId);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Payrolls)
                .WithOne(p => p.Employee)
                .HasForeignKey(p => p.EmployeeID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Attendances)
                .WithOne(a => a.Employee)
                .HasForeignKey(a => a.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.LeaveRequests)
                .WithOne(lr => lr.Employee)
                .HasForeignKey(lr => lr.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Shifts)
                .WithOne(s => s.Employee)
                .HasForeignKey(s => s.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            // ---------- LeaveType ----------
            modelBuilder.Entity<LeaveType>()
                .HasOne(lt => lt.Company)
                .WithMany(c => c.LeaveTypes)
                .HasForeignKey(lt => lt.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            // ---------- Subscription ----------
            modelBuilder.Entity<Subscription>()
                .HasOne(s => s.PaymentMethod)
                .WithMany()
                .HasForeignKey(s => s.PaymentMethodID)
                .OnDelete(DeleteBehavior.SetNull);

            // ---------- Asset ----------
            modelBuilder.Entity<Asset>()
                .HasOne(a => a.Category)
                .WithMany()
                .HasForeignKey(a => a.AssetCategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            // ---------- EmployeeCourseEnrollment ----------
            modelBuilder.Entity<EmployeeCourseEnrollment>()
                .HasOne(ece => ece.Employee)
                .WithMany()
                .HasForeignKey(ece => ece.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EmployeeCourseEnrollment>()
                .HasOne(ece => ece.TrainingCourse)
                .WithMany(tc => tc.Enrollments)
                .HasForeignKey(ece => ece.TrainingCourseId)
                .OnDelete(DeleteBehavior.Cascade);

            // ---------- User ----------
            modelBuilder.Entity<User>()
                .HasOne(u => u.Company)
                .WithMany(c => c.Users)
                .HasForeignKey(u => u.CompanyId)
                .OnDelete(DeleteBehavior.SetNull);

            // ---------- RefreshToken ----------
            modelBuilder.Entity<RefreshToken>()
                .HasOne(rt => rt.User)
                .WithMany()
                .HasForeignKey(rt => rt.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
