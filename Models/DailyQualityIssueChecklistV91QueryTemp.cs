namespace WebWinMVC.Models
{
    public class DailyQualityIssueChecklistV91QueryTemp
    {
        public int ID { get; set; }
        public string? ApprovalDate { get; set; } = default!;
        public string? VehicleModel { get; set; } = default!;
        public string? OldMaterialCode { get; set; } = default!;
        public string? OldMaterialDescription { get; set; } = default!;
        public string? SupplierShortCode { get; set; } = default!;
        public string? ResponsibilitySourceSupplierName { get; set; } = default!;
        public string? CaseCount { get; set; } = default!;
        public string? BreakPointNum { get; set; } = default!;
        public string? BreakPointTime { get; set; } = default!;
        public string? MIS3 { get; set; } = default!;
        public string? MIS6 { get; set; } = default!;
        public string? MIS12 { get; set; } = default!;
        public string? MIS24 { get; set; } = default!;
        public string? MIS48 { get; set; } = default!;
        public string? SMT { get; set; } = default!;
        public string? LocationCode { get; set; } = default!;
        public string? FaultCode { get; set; } = default!;
        public string? PQSNumber { get; set; } = default!;
        public string? VAN { get; set; } = default!;
        public string? VIN { get; set; } = default!;
        // 新增的属性
        public string? EditedBody { get; set; } = default!;      // 编辑人
        public string? EditedDate { get; set; } = default!;    // 编辑日期
        //补充的属性
        public string? IssueAttributes { get; set; } = default!;
        public string? StartTime { get; set; } = default!;
        public string? Remarks { get; set; } = default!;
        public string? IsBreakdownInvalid { get; set; } = default!; // 断点是否失效


    }
}
