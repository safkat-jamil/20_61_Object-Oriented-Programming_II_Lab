using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;
using StudentManagementSystem.Models.Academic;

namespace StudentManagementSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Faculty> Faculty { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Routine> Routines { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<RegisteredCourse> RegisteredCourses { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Assessment> Assessments { get; set; }
        public DbSet<ImprovementExam> ImprovementExams { get; set; }
        public DbSet<StudyMaterial> StudyMaterials { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<ExamCommittee> ExamCommittees { get; set; }
        public DbSet<ExamReview> ExamReviews { get; set; }
        public DbSet<FeeSetting> FeeSettings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fix multiple cascade paths by disabling cascade delete on RegisteredCourse -> Registration
            modelBuilder.Entity<RegisteredCourse>()
                .HasOne(rc => rc.Registration)
                .WithMany(r => r.RegisteredCourses)
                .HasForeignKey(rc => rc.RegistrationId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
