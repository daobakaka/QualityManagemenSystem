using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebWinMVC.Migrations
{
    /// <inheritdoc />
    public partial class MigrationSILSimulationTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: " SILSimulationTables",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OldMaterialCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaultCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FailurePartCount = table.Column<int>(type: "int", nullable: true),
                    FaultLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaultDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reporter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReporterPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InitialFaultAnalysis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepairProcessAndEffect = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inspector = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InspectorPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepairTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VAN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChassisNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaultTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreventiveMeasures = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponsiblePerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotificationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PSQNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StageStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponsibleDepartment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manager = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Creator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TTF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PendingPerson = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ SILSimulationTables", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: " SILSimulationTables");
        }
    }
}
