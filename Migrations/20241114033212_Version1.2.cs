using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebWinMVC.Migrations
{
    /// <inheritdoc />
    public partial class Version12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BreakPointTime",
                table: "dailyQualityIssueChecklistV91QueryTemps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IsBreakdownInvalid",
                table: "dailyQualityIssueChecklistV91QueryTemps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IssueAttributes",
                table: "dailyQualityIssueChecklistV91QueryTemps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "dailyQualityIssueChecklistV91QueryTemps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StartTime",
                table: "dailyQualityIssueChecklistV91QueryTemps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BreakPointTime",
                table: "DailyQualityIssueChecklistV91Queries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IsBreakdownInvalid",
                table: "DailyQualityIssueChecklistV91Queries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IssueAttributes",
                table: "DailyQualityIssueChecklistV91Queries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "DailyQualityIssueChecklistV91Queries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StartTime",
                table: "DailyQualityIssueChecklistV91Queries",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BreakPointTime",
                table: "dailyQualityIssueChecklistV91QueryTemps");

            migrationBuilder.DropColumn(
                name: "IsBreakdownInvalid",
                table: "dailyQualityIssueChecklistV91QueryTemps");

            migrationBuilder.DropColumn(
                name: "IssueAttributes",
                table: "dailyQualityIssueChecklistV91QueryTemps");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "dailyQualityIssueChecklistV91QueryTemps");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "dailyQualityIssueChecklistV91QueryTemps");

            migrationBuilder.DropColumn(
                name: "BreakPointTime",
                table: "DailyQualityIssueChecklistV91Queries");

            migrationBuilder.DropColumn(
                name: "IsBreakdownInvalid",
                table: "DailyQualityIssueChecklistV91Queries");

            migrationBuilder.DropColumn(
                name: "IssueAttributes",
                table: "DailyQualityIssueChecklistV91Queries");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "DailyQualityIssueChecklistV91Queries");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "DailyQualityIssueChecklistV91Queries");
        }
    }
}
