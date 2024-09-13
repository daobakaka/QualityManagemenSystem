using Microsoft.EntityFrameworkCore;
using WebWinMVC.Models;

namespace WebWinMVC.Data
{
    public class JRZLWTDbContext : DbContext
    {
        public JRZLWTDbContext(DbContextOptions<JRZLWTDbContext> options)
            : base(options)
        {
        }

        // DbSets for each table in the same database
        public DbSet<DailyQualityIssueChecklist> DailyQualityIssueChecklists { get; set; }
        public DbSet<DailyQualityIssueChecklistV91> DailyQualityIssueChecklistV91s { get; set; }
        public DbSet<DailyServiceReviewForm> DailyServiceReviewForms { get; set; }
        public DbSet<DailyServiceReviewFormQuery> DailyServiceReviewFormQueries { get; set; }
        public DbSet<DailyQualityIssueChecklistV91Query> DailyQualityIssueChecklistV91Queries { get; set; }

        // Configure the model with explicit table names
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Set table names to match DbSet properties
            modelBuilder.Entity<DailyQualityIssueChecklist>().ToTable("DailyQualityIssueChecklists");
            modelBuilder.Entity<DailyQualityIssueChecklistV91>().ToTable("DailyQualityIssueChecklistV91s");
            modelBuilder.Entity<DailyServiceReviewForm>().ToTable("DailyServiceReviewForms");
            modelBuilder.Entity<DailyServiceReviewFormQuery>().ToTable("DailyServiceReviewFormQueries");
            modelBuilder.Entity<DailyQualityIssueChecklistV91Query>().ToTable("DailyQualityIssueChecklistV91Queries");
        }
    }
}
