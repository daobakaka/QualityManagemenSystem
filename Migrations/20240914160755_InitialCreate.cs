using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebWinMVC.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BreakpointAnalysisTables",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FaultCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BreakpointTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PQSNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VAN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VIN = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreakpointAnalysisTables", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DailyQualityIssueChecklists",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApprovalDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OldMaterialCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OldMaterialDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierShortCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResponsibilitySourceSupplierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaseCount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MIS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FaultMode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IncludedInSIL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PQSNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BreakpointTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyQualityIssueChecklists", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DailyQualityIssueChecklistV91Queries",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApprovalDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OldMaterialCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OldMaterialDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierShortCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResponsibilitySourceSupplierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaseCount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccumulatedCaseCount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MIS3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MIS6 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MIS12 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MIS24 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MIS36 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SMT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FaultCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PQSNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VAN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VIN = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyQualityIssueChecklistV91Queries", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DailyQualityIssueChecklistV91s",
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
                    table.PrimaryKey("PK_DailyQualityIssueChecklistV91s", x => x.ID);
                });

          

            migrationBuilder.CreateTable(
                name: "DailyServiceReviewForms",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceOrder = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceOrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceOrderTotalPrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkOrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkOrderCreationDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkOrderType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartureTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarPickupTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkOrderRepairEndTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkOrderRepairAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OutboundServiceLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OutboundMileage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceStation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceStationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoticeVehicleModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VAN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VIN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WarrantyStartDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaterialType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LineNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OldMaterialCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OldMaterialDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewMaterialCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewMaterialDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RepairMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplyMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OldPartReturnStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResponsibilitySourceIdentifier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResponsibilitySourceSupplier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierShortCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResponsibilitySourceSupplierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinePrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActualAmount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaterialMarkupCoefficient = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LaborRegionCoefficient = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LaborColdClimateCoefficient = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LaborQualityCoefficient = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationCodeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FaultCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FaultCodeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FaultDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceOrderCreationDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FDP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecialAuthorizationCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WBS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DrivingMileageKM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OutboundRescueLicensePlate1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OutboundRescueLicensePlate2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApprovalDate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyServiceReviewForms", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VehicleBasicInfos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortVin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VIN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VAN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FDP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnnouncementModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductionDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalesDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EngineNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClaimDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExportStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EngineModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SsvaOrSva = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InternalAnnouncemen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeriesDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductionMouth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Series = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Emissions = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleBasicInfos", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BreakpointAnalysisTables");

            migrationBuilder.DropTable(
                name: "DailyQualityIssueChecklists");

            migrationBuilder.DropTable(
                name: "DailyQualityIssueChecklistV91Queries");

            migrationBuilder.DropTable(
                name: "DailyQualityIssueChecklistV91s");

            migrationBuilder.DropTable(
                name: "DailyServiceReviewFormQueries");

            migrationBuilder.DropTable(
                name: "DailyServiceReviewForms");

            migrationBuilder.DropTable(
                name: "VehicleBasicInfos");
        }
    }
}
