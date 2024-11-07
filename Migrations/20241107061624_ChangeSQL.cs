using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebWinMVC.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSQL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MIS36",
                table: "dailyQualityIssueChecklistV91Temps",
                newName: "MIS48");

            migrationBuilder.RenameColumn(
                name: "MIS36",
                table: "DailyQualityIssueChecklistV91s",
                newName: "MIS48");

            migrationBuilder.RenameColumn(
                name: "MIS36",
                table: "dailyQualityIssueChecklistV91QueryTemps",
                newName: "MIS48");

            migrationBuilder.RenameColumn(
                name: "MIS36",
                table: "DailyQualityIssueChecklistV91Queries",
                newName: "MIS48");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MIS48",
                table: "dailyQualityIssueChecklistV91Temps",
                newName: "MIS36");

            migrationBuilder.RenameColumn(
                name: "MIS48",
                table: "DailyQualityIssueChecklistV91s",
                newName: "MIS36");

            migrationBuilder.RenameColumn(
                name: "MIS48",
                table: "dailyQualityIssueChecklistV91QueryTemps",
                newName: "MIS36");

            migrationBuilder.RenameColumn(
                name: "MIS48",
                table: "DailyQualityIssueChecklistV91Queries",
                newName: "MIS36");
        }
    }
}
