using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebWinMVC.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTemp91 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FilteredVehicleModel",
                table: "dailyQualityIssueChecklistV91Temps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FilteredVehicleModel",
                table: "DailyQualityIssueChecklistV91s",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilteredVehicleModel",
                table: "dailyQualityIssueChecklistV91Temps");

            migrationBuilder.DropColumn(
                name: "FilteredVehicleModel",
                table: "DailyQualityIssueChecklistV91s");
        }
    }
}
