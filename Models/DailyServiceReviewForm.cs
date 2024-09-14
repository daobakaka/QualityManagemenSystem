namespace WebWinMVC.Models
{
    public class DailyServiceReviewForm
    {
        public int ID { get; set; }
        public string? ServiceOrder { get; set; } = default!;
        public string? ServiceOrderStatus { get; set; } = default!;
        public string? ServiceOrderTotalPrice { get; set; } = default!;
        public string? WorkOrderNumber { get; set; } = default!;
        public string? WorkOrderCreationDate { get; set; } = default!;
        public string? WorkOrderType { get; set; } = default!;
        public string? DepartureTime { get; set; } = default!;
        public string? CarPickupTime { get; set; } = default!;
        public string? WorkOrderRepairEndTime { get; set; } = default!;
        public string? WorkOrderRepairAccount { get; set; } = default!;
        public string? OutboundServiceLocation { get; set; } = default!;
        public string? OutboundMileage { get; set; } = default!;
        public string? Province { get; set; } = default!;
        public string? ServiceStation { get; set; } = default!;
        public string? ServiceStationName { get; set; } = default!;
        public string? NoticeVehicleModel { get; set; } = default!;
        public string? VAN { get; set; } = default!;
        public string? VIN { get; set; } = default!;
        public string? WarrantyStartDate { get; set; } = default!;
        public string? MaterialType { get; set; } = default!;
        public string? LineNumber { get; set; } = default!;
        public string? OldMaterialCode { get; set; } = default!;
        public string? OldMaterialDescription { get; set; } = default!;
        public string? NewMaterialCode { get; set; } = default!;
        public string? NewMaterialDescription { get; set; } = default!;
        public string? RepairMethod { get; set; } = default!;
        public string? SupplyMethod { get; set; } = default!;
        public string? Quantity { get; set; } = default!;
        public string? OldPartReturnStatus { get; set; } = default!;
        public string? ResponsibilitySourceIdentifier { get; set; } = default!;
        public string? ResponsibilitySourceSupplier { get; set; } = default!;
        public string? SupplierShortCode { get; set; } = default!;
        public string? ResponsibilitySourceSupplierName { get; set; } = default!;
        public string? LinePrice { get; set; } = default!;
        public string? ActualAmount { get; set; } = default!;
        public string? MaterialMarkupCoefficient { get; set; } = default!;
        public string? LaborRegionCoefficient { get; set; } = default!;
        public string? LaborColdClimateCoefficient { get; set; } = default!;
        public string? LaborQualityCoefficient { get; set; } = default!;
        public string? LocationCode { get; set; } = default!;
        public string? LocationCodeDescription { get; set; } = default!;
        public string? FaultCode { get; set; } = default!;
        public string? FaultCodeDescription { get; set; } = default!;
        public string? FaultDescription { get; set; } = default!;
        public string? ServiceCategory { get; set; } = default!;
        public string? ServiceOrderCreationDate { get; set; } = default!;
        public string? FDP { get; set; } = default!;
        public string? SpecialAuthorizationCode { get; set; } = default!;
        public string? WBS { get; set; } = default!;
        public string? DrivingMileageKM { get; set; } = default!;
        public string? OutboundRescueLicensePlate1 { get; set; } = default!;
        public string? OutboundRescueLicensePlate2 { get; set; } = default!;
        public string? ApprovalDate { get; set; } = default!;
        // 'ManufacturingMonth' and following fields are excluded
    }
}
