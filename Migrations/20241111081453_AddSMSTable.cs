using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebWinMVC.Migrations
{
    /// <inheritdoc />
    public partial class AddSMSTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Emissions",
                table: "VehicleBasicInfos");

            migrationBuilder.DropColumn(
                name: "InternalAnnouncemen",
                table: "VehicleBasicInfos");

            migrationBuilder.DropColumn(
                name: "ProductionMouth",
                table: "VehicleBasicInfos");

            migrationBuilder.DropColumn(
                name: "Series",
                table: "VehicleBasicInfos");

            migrationBuilder.DropColumn(
                name: "SeriesDescription",
                table: "VehicleBasicInfos");

            migrationBuilder.DropColumn(
                name: "ShortVin",
                table: "VehicleBasicInfos");

            migrationBuilder.CreateTable(
                name: "dailyServiceReviewFormQueryTemps",
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
                    table.PrimaryKey("PK_dailyServiceReviewFormQueryTemps", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "seriesDescriptionTables",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VIN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VAN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InternalAnnouncemen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeriesDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seriesDescriptionTables", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dailyServiceReviewFormQueryTemps");

            migrationBuilder.DropTable(
                name: "seriesDescriptionTables");

            migrationBuilder.AddColumn<string>(
                name: "Emissions",
                table: "VehicleBasicInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InternalAnnouncemen",
                table: "VehicleBasicInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductionMouth",
                table: "VehicleBasicInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Series",
                table: "VehicleBasicInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeriesDescription",
                table: "VehicleBasicInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortVin",
                table: "VehicleBasicInfos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
