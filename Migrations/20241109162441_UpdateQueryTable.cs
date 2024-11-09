using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebWinMVC.Migrations
{
    /// <inheritdoc />
    public partial class UpdateQueryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AccumulatedCaseCount",
                table: "dailyQualityIssueChecklistV91QueryTemps",
                newName: "BreakPointNum");

            migrationBuilder.RenameColumn(
                name: "AccumulatedCaseCount",
                table: "DailyQualityIssueChecklistV91Queries",
                newName: "BreakPointNum");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BreakPointNum",
                table: "dailyQualityIssueChecklistV91QueryTemps",
                newName: "AccumulatedCaseCount");

            migrationBuilder.RenameColumn(
                name: "BreakPointNum",
                table: "DailyQualityIssueChecklistV91Queries",
                newName: "AccumulatedCaseCount");
        }
    }
}
