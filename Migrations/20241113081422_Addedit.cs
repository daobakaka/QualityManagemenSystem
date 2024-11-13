using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebWinMVC.Migrations
{
    /// <inheritdoc />
    public partial class Addedit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApprovalDate",
                table: "dailyQualityIssueChecklistV91Temps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApprovalDate",
                table: "DailyQualityIssueChecklistV91s",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EditedBody",
                table: "DailyQualityIssueChecklistV91Queries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EditedDate",
                table: "DailyQualityIssueChecklistV91Queries",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovalDate",
                table: "dailyQualityIssueChecklistV91Temps");

            migrationBuilder.DropColumn(
                name: "ApprovalDate",
                table: "DailyQualityIssueChecklistV91s");

            migrationBuilder.DropColumn(
                name: "EditedBody",
                table: "DailyQualityIssueChecklistV91Queries");

            migrationBuilder.DropColumn(
                name: "EditedDate",
                table: "DailyQualityIssueChecklistV91Queries");
        }
    }
}
