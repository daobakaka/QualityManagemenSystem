using System.ComponentModel.DataAnnotations;

namespace WebWinMVC.Models
{
    public class DailyQualityIssueChecklistV91
    {
        public int ID { get; set; }
        public string OldMaterialCode { get; set; } = default!;
        public string ? OldMaterialDescription { get; set; } = default!;
        public string ?SupplierShortCode { get; set; } = default!;
        public string ?ResponsibilitySourceSupplierName { get; set; } = default!;

        public string? CaseCount { set; get; } = default!;
        public string ?MIS3 { get; set; } = default!;
        public string ?MIS6 { get; set; } = default!;
        public string ?MIS12 { get; set; } = default!;
        public string ?MIS24 { get; set; } = default!;
        public string ?MIS36 { get; set; } = default!;
        public string ?SMT { get; set; } = default!;
        public string ?LocationCode { get; set; } = default!;
        public string ?FaultCode { get; set; } = default!;
        public string ?QE { get; set; } = default!;
        public string ?ServiceFaultIdentificationAccurate { get; set; } = default!;
        public string ?IdentifiedFaultMode { get; set; } = default!;
        //public string IdentifiedFaultCode { get; set; } = default!;
        public string ?BreakdownCount { get; set; } = default!; // Updated property
        public string ?IsBreakdownInvalid { get; set; } = default!; // 断点是否失效
        public string ?IncludedInSIL { get; set; } = default!;
        public string ?PQSNumber { get; set; } = default!;
        public string ?BreakpointTime { get; set; } = default!;
        public string ?StartTime { get; set; } = default!;
        public string ?Remarks { get; set; } = default!;
        public string ?ProjectIdentifier { get; set; } = default!;

        [Timestamp]
        public byte[] RowVersion { get; set; } = default!;

    }
}
