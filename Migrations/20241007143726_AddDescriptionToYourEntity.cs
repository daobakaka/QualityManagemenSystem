using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebWinMVC.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriptionToYourEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dailyQualityIssueChecklistV91QueryTemps",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApprovalDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OldMaterialCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OldMaterialDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierShortCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponsibilitySourceSupplierName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaseCount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccumulatedCaseCount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MIS3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MIS6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MIS12 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MIS24 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MIS36 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SMT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaultCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PQSNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VAN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VIN = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dailyQualityIssueChecklistV91QueryTemps", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "dailyQualityIssueChecklistV91Temps",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OldMaterialCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OldMaterialDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierShortCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResponsibilitySourceSupplierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MIS3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MIS6 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MIS12 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MIS24 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MIS36 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SMT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FaultCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceFaultIdentificationAccurate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentifiedFaultMode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BreakdownCount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsBreakdownInvalid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IncludedInSIL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PQSNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BreakpointTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectIdentifier = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dailyQualityIssueChecklistV91Temps", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dailyQualityIssueChecklistV91QueryTemps");

            migrationBuilder.DropTable(
                name: "dailyQualityIssueChecklistV91Temps");
        }
    }
}
