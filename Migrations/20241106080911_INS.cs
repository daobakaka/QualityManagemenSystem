using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebWinMVC.Migrations
{
    /// <inheritdoc />
    public partial class INS : Migration
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
                    LocationCodeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OldMaterialCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OldMaterialCodeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaultCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaultCodeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FailurePartCount = table.Column<string>(type: "nvarchar(max)", nullable: true),
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

            migrationBuilder.CreateTable(
                name: "BreakpointAnalysisTables",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaultCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BreakpointTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PQSNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VAN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VIN = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    table.PrimaryKey("PK_DailyQualityIssueChecklistV91Queries", x => x.ID);
                });

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
                name: "DailyQualityIssueChecklistV91s",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OldMaterialCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OldMaterialDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierShortCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponsibilitySourceSupplierName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaseCount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MIS3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MIS6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MIS12 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MIS24 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MIS36 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SMT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaultCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceFaultIdentificationAccurate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentifiedFaultMode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BreakdownCount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsBreakdownInvalid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IncludedInSIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PQSNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BreakpointTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectIdentifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyQualityIssueChecklistV91s", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "dailyQualityIssueChecklistV91Temps",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OldMaterialCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OldMaterialDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierShortCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponsibilitySourceSupplierName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaseCount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MIS3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MIS6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MIS12 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MIS24 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MIS36 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SMT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaultCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceFaultIdentificationAccurate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentifiedFaultMode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BreakdownCount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsBreakdownInvalid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IncludedInSIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PQSNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BreakpointTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectIdentifier = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dailyQualityIssueChecklistV91Temps", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DailyServiceReviewFormQueries",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceOrder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceOrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceOrderTotalPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkOrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkOrderCreationDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkOrderType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartureTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarPickupTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkOrderRepairEndTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkOrderRepairAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OutboundServiceLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OutboundMileage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceStation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceStationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoticeVehicleModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VAN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VIN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarrantyStartDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaterialType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LineNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OldMaterialCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OldMaterialDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewMaterialCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewMaterialDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepairMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplyMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OldPartReturnStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponsibilitySourceIdentifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponsibilitySourceSupplier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierShortCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponsibilitySourceSupplierName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinePrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualAmount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaterialMarkupCoefficient = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LaborRegionCoefficient = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LaborColdClimateCoefficient = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LaborQualityCoefficient = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationCodeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaultCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaultCodeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaultDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceOrderCreationDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FDP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialAuthorizationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WBS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrivingMileageKM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OutboundRescueLicensePlate1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OutboundRescueLicensePlate2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovalDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManufacturingMonth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MIS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Emission = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InternalModelCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fuel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MISInterval = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilteredVehicleModel = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyServiceReviewFormQueries", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DailyServiceReviewForms",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceOrder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceOrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceOrderTotalPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkOrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkOrderCreationDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkOrderType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartureTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarPickupTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkOrderRepairEndTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkOrderRepairAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OutboundServiceLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OutboundMileage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceStation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceStationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoticeVehicleModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VAN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VIN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarrantyStartDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaterialType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LineNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OldMaterialCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OldMaterialDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewMaterialCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewMaterialDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepairMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplyMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OldPartReturnStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponsibilitySourceIdentifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponsibilitySourceSupplier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierShortCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponsibilitySourceSupplierName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinePrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualAmount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaterialMarkupCoefficient = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LaborRegionCoefficient = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LaborColdClimateCoefficient = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LaborQualityCoefficient = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationCodeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaultCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaultCodeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaultDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceOrderCreationDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FDP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialAuthorizationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WBS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrivingMileageKM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OutboundRescueLicensePlate1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OutboundRescueLicensePlate2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovalDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyServiceReviewForms", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "userAuthentications",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Group = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userAuthentications", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VehicleBasicInfos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortVin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VIN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VAN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FDP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnnouncementModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductionDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EngineNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExportStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EngineModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SsvaOrSva = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InternalAnnouncemen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeriesDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductionMouth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Series = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Emissions = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: " SILSimulationTables");

            migrationBuilder.DropTable(
                name: "BreakpointAnalysisTables");

            migrationBuilder.DropTable(
                name: "DailyQualityIssueChecklists");

            migrationBuilder.DropTable(
                name: "DailyQualityIssueChecklistV91Queries");

            migrationBuilder.DropTable(
                name: "dailyQualityIssueChecklistV91QueryTemps");

            migrationBuilder.DropTable(
                name: "DailyQualityIssueChecklistV91s");

            migrationBuilder.DropTable(
                name: "dailyQualityIssueChecklistV91Temps");

            migrationBuilder.DropTable(
                name: "DailyServiceReviewFormQueries");

            migrationBuilder.DropTable(
                name: "DailyServiceReviewForms");

            migrationBuilder.DropTable(
                name: "userAuthentications");

            migrationBuilder.DropTable(
                name: "VehicleBasicInfos");
        }
    }
}
