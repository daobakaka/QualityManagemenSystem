using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebWinMVC.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBreakPointTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FilteredVehicleModel",
                table: "BreakpointAnalysisTables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SupplierShortCode",
                table: "BreakpointAnalysisTables",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilteredVehicleModel",
                table: "BreakpointAnalysisTables");

            migrationBuilder.DropColumn(
                name: "SupplierShortCode",
                table: "BreakpointAnalysisTables");
        }
    }
}
