using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebWinMVC.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSQL11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IssueAttributes",
                table: "dailyQualityIssueChecklistV91Temps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IssueAttributes",
                table: "DailyQualityIssueChecklistV91s",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EditedBody",
                table: "dailyQualityIssueChecklistV91QueryTemps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EditedDate",
                table: "dailyQualityIssueChecklistV91QueryTemps",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IssueAttributes",
                table: "dailyQualityIssueChecklistV91Temps");

            migrationBuilder.DropColumn(
                name: "IssueAttributes",
                table: "DailyQualityIssueChecklistV91s");

            migrationBuilder.DropColumn(
                name: "EditedBody",
                table: "dailyQualityIssueChecklistV91QueryTemps");

            migrationBuilder.DropColumn(
                name: "EditedDate",
                table: "dailyQualityIssueChecklistV91QueryTemps");
        }
    }
}
