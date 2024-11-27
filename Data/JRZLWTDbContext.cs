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

        // DbSets for each table in the database
        public DbSet<DailyQualityIssueChecklist> DailyQualityIssueChecklists { get; set; }
        public DbSet<DailyQualityIssueChecklistV91> DailyQualityIssueChecklistV91s { get; set; }
        public DbSet<DailyServiceReviewForm> DailyServiceReviewForms { get; set; }
        public DbSet<DailyServiceReviewFormQuery> DailyServiceReviewFormQueries { get; set; }
        public DbSet<DailyQualityIssueChecklistV91Query> DailyQualityIssueChecklistV91Queries { get; set; }
        public DbSet<VehicleBasicInfo> VehicleBasicInfos { get; set; }
        public DbSet<BreakpointAnalysisTable> BreakpointAnalysisTables { get; set; } // Add this line

        public DbSet<SILSimulationTable> SILSimulationTables { get; set; }
        public DbSet<UserAuthentication> userAuthentications { get; set; }
        /// <summary>
        /// add temp DBmodel
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// 
        public DbSet<DailyQualityIssueChecklistV91Temp> dailyQualityIssueChecklistV91Temps { get; set; }
        public DbSet<DailyQualityIssueChecklistV91QueryTemp> dailyQualityIssueChecklistV91QueryTemps { get; set; }

        public DbSet<DailyServiceReviewFormQueryTemp> dailyServiceReviewFormQueryTemps { get; set; }


        public DbSet<SeriesDescriptionTable>  seriesDescriptionTables { get; set; }

        public DbSet<QEIdentify> QEIdentifies { get; set; }
        // Configure the model with explicit table names
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         modelBuilder.Entity<DailyQualityIssueChecklistV91>()
         .Property(e => e.RowVersion)
         .IsRowVersion(); // 确保 RowVersion 被配置为行版本


            base.OnModelCreating(modelBuilder);

            // Set table names to match DbSet properties
            modelBuilder.Entity<DailyQualityIssueChecklist>().ToTable("DailyQualityIssueChecklists");
            modelBuilder.Entity<DailyQualityIssueChecklistV91>().ToTable("DailyQualityIssueChecklistV91s");
            modelBuilder.Entity<DailyServiceReviewForm>().ToTable("DailyServiceReviewForms");
            modelBuilder.Entity<DailyServiceReviewFormQuery>().ToTable("DailyServiceReviewFormQueries");
            modelBuilder.Entity<DailyQualityIssueChecklistV91Query>().ToTable("DailyQualityIssueChecklistV91Queries");
            modelBuilder.Entity<VehicleBasicInfo>().ToTable("VehicleBasicInfos");
            modelBuilder.Entity<BreakpointAnalysisTable>().ToTable("BreakpointAnalysisTables"); // Add this line
            modelBuilder.Entity<SILSimulationTable>().ToTable(" SILSimulationTables");
            modelBuilder.Entity<UserAuthentication>().ToTable("userAuthentications");
            modelBuilder.Entity<DailyQualityIssueChecklistV91Temp>().ToTable("dailyQualityIssueChecklistV91Temps");
            modelBuilder.Entity<DailyQualityIssueChecklistV91QueryTemp>().ToTable("dailyQualityIssueChecklistV91QueryTemps");
            modelBuilder.Entity<DailyServiceReviewFormQueryTemp>().ToTable("dailyServiceReviewFormQueryTemps");
            modelBuilder.Entity<SeriesDescriptionTable>().ToTable("seriesDescriptionTables");
            modelBuilder.Entity<QEIdentify>().ToTable("QEIdentifies");
        }
    }

}
