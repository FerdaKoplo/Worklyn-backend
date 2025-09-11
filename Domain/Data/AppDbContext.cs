using Microsoft.EntityFrameworkCore;
using Worklyn_backend.Domain.Entities;

namespace Worklyn_backend.Domain.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // ---------- DbSets ----------
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Payroll> Payrolls { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<PerformanceReview> PerformanceReviews { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<RecruitmentCandidate> RecruitmentCandidates { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<AssetCategory> AssetCategories { get; set; }
        public DbSet<EmployeeCourseEnrollment> EmployeeCourseEnrollments { get; set; }
        public DbSet<EmployeeProfile> EmployeeProfiles { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ---------- Company ----------
            modelBuilder.Entity<Company>()
                .HasKey(c => c.CompanyId);

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
                .HasForeignKey(p => p.CompanyId)
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

            modelBuilder.Entity<Company>()
                .HasMany(c => c.LeaveTypes)
                .WithOne(lt => lt.Company)
                .HasForeignKey(lt => lt.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Company>()
                .HasMany(c => c.Users)
                .WithOne(u => u.Company)
                .HasForeignKey(u => u.CompanyId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Company>()
                .HasMany(c => c.LeaveRequests)
                .WithOne(lr => lr.Company)
                .HasForeignKey(lr => lr.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            // ---------- Department ----------
            modelBuilder.Entity<Department>()
                .HasKey(d => d.DepartmentID);

            modelBuilder.Entity<Department>()
                .HasMany(d => d.Employees)
                .WithOne(e => e.Department)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Department>()
                .HasOne(d => d.Manager)
                .WithMany()
                .HasForeignKey(d => d.ManagerId)
                .OnDelete(DeleteBehavior.SetNull);

            // ---------- Employee ----------
            modelBuilder.Entity<Employee>()
                .HasKey(e => e.EmployeeId);

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
                .HasForeignKey(p => p.EmployeeId)
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

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.CourseEnrollments)
                .WithOne(ece => ece.Employee)
                .HasForeignKey(ece => ece.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            // ---------- Employee Profile ----------
            modelBuilder.Entity<EmployeeProfile>()
                .HasKey(ep => ep.EmployeeProfileId);

            modelBuilder.Entity<EmployeeProfile>()
                .HasOne(ep => ep.Employee)
                .WithOne(e => e.Profile)
                .HasForeignKey<EmployeeProfile>(ep => ep.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            // ---------- LeaveType ----------
            modelBuilder.Entity<LeaveType>()
                .HasKey(lt => lt.LeaveTypeId);

            // ---------- LeaveRequest ----------
            modelBuilder.Entity<LeaveRequest>()
                .HasKey(lr => lr.LeaveRequestId);

            modelBuilder.Entity<LeaveRequest>()
                .HasOne(lr => lr.LeaveType)
                .WithMany()
                .HasForeignKey(lr => lr.LeaveTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LeaveRequest>()
                .HasOne(lr => lr.Approver)
                .WithMany()
                .HasForeignKey(lr => lr.ApproverId)
                .OnDelete(DeleteBehavior.SetNull);

            // ---------- Subscription ----------
            modelBuilder.Entity<Subscription>()
                .HasKey(s => s.SubscriptionId);

            modelBuilder.Entity<Subscription>()
                .HasOne(s => s.PaymentMethod)
                .WithMany()
                .HasForeignKey(s => s.PaymentMethodID)
                .OnDelete(DeleteBehavior.SetNull);

            // ---------- Asset ----------
            modelBuilder.Entity<Asset>()
                .HasKey(a => a.AssetId);

            modelBuilder.Entity<Asset>()
                .HasOne(a => a.Category)
                .WithMany()
                .HasForeignKey(a => a.AssetCategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            // ---------- AssetCategory ----------
            modelBuilder.Entity<AssetCategory>()
                .HasKey(ac => ac.AssetCategoryId);

            // ---------- EmployeeCourseEnrollment ----------
            modelBuilder.Entity<EmployeeCourseEnrollment>()
                .HasKey(ece => ece.EnrollmentId);

            modelBuilder.Entity<EmployeeCourseEnrollment>()
                .HasOne(ece => ece.TrainingCourse)
                .WithMany(tc => tc.Enrollments)
                .HasForeignKey(ece => ece.TrainingCourseId)
                .OnDelete(DeleteBehavior.Cascade);

            // ---------- TrainingCourse ----------
            modelBuilder.Entity<TrainingCourse>()
                .HasKey(tc => tc.TrainingCourseId);

            // ---------- Position ----------
            modelBuilder.Entity<Position>()
                .HasKey(p => p.PositionId);

            // ---------- RecruitmentCandidate ----------
            modelBuilder.Entity<RecruitmentCandidate>()
                .HasKey(rc => rc.CandidateId);

            // ---------- Shift ----------
            modelBuilder.Entity<Shift>()
                .HasKey(s => s.ShiftId);

            // ---------- Attendance ----------
            modelBuilder.Entity<Attendance>()
                .HasKey(a => a.AttendanceId);

            // ---------- Payroll ----------
            modelBuilder.Entity<Payroll>()
                .HasKey(p => p.PayrollId);

            // ---------- PerformanceReview ----------
            modelBuilder.Entity<PerformanceReview>()
                .HasKey(pr => pr.ReviewId);

            // ---------- User ----------
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId);

            // ---------- RefreshToken ----------
            modelBuilder.Entity<RefreshToken>()
                .HasKey(rt => rt.Id);

            modelBuilder.Entity<RefreshToken>()
                .HasOne(rt => rt.User)
                .WithMany(u => u.RefreshTokens)
                .HasForeignKey(rt => rt.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

