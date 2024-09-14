namespace WebWinMVC.Models
{
    public class BreakpointAnalysisTable
    {
        public int ID { get; set; } // Assuming you might want a primary key

        public string? MaterialCode { get; set; } = default!; // 物料号
        public string? LocationCode { get; set; } = default!; // 部位码
        public string? FaultCode { get; set; } = default!; // 故障码
        public string? BreakpointTime { get; set; } = default!; // 断点时间
        public string? PQSNumber { get; set; } = default!; // PQS编号
        public string? VAN { get; set; } = default!; // VAN
        public string? VIN { get; set; } = default!; // VIN
    }
}
