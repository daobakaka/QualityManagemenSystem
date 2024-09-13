namespace WebWinMVC.Models
{
    public class DailyQualityIssueChecklist
    {
        public int ID { get; set; }
        public string SerialNumber { get; set; } = default!;
        public string ApprovalDate { get; set; } = default!;
        public string Model { get; set; } = default!;
        public string OldMaterialCode { get; set; } = default!;
        public string OldMaterialDescription { get; set; } = default!;
        public string SupplierShortCode { get; set; } = default!;
        public string ResponsibilitySourceSupplierName { get; set; } = default!;
        public string CaseCount { get; set; } = default!;
        public string MIS { get; set; } = default!;
        public string FaultMode { get; set; } = default!;
        public string QE { get; set; } = default!;
        public string IncludedInSIL { get; set; } = default!;
        public string PQSNumber { get; set; } = default!;
        public string BreakpointTime { get; set; } = default!;
        public string StartTime { get; set; } = default!;
        public string Remarks { get; set; } = default!;

    
    }
}
