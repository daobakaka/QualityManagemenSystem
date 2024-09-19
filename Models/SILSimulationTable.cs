namespace WebWinMVC.Models
{
    public class SILSimulationTable
    {
        public int ID { get; set; } // 主键

        public string? LocationCode { get; set; } = default!; // 部位码
        public string? LocationCodeDescription { get; set; } = default!; // 部位码描述
        public string? OldMaterialCode { get; set; } = default!; // 旧物料号
        public string? OldMaterialCodeDescription { get; set; } = default!; // 旧物料号描述
        public string? FaultCode { get; set; } = default!; // 故障码
        public string? FaultCodeDescription { get; set; } = default!; // 故障码描述
        public string? Title { get; set; } = default!; // 标题
        public string? Province { get; set; } = default!; // 省份
        public string? City { get; set; } = default!; // 地级市
        public string? FailurePartCount { get; set; } = default!; // 失效件数量
        public string? FaultLevel { get; set; } = default!; // 故障等级
        public string? FaultDescription { get; set; } = default!; // 故障描述
        public string? Reporter { get; set; } = default!; // 信息提报人(QE)
        public string? ReporterPhone { get; set; } = default!; // 提报人电话(QE电话)
        public string? InitialFaultAnalysis { get; set; } = default!; // 故障原因初步分析
        public string? RepairProcessAndEffect { get; set; } = default!; // 维修经过与效果
        public string? Inspector { get; set; } = default!; // 检修人(服务站)
        public string? InspectorPhone { get; set; } = default!; // 检修人电话
        public string? RepairTime { get; set; } = default!; // 检修时间
        public string? VAN { get; set; } = default!; // VAN
        public string? ChassisNumber { get; set; } = default!; // 底盘号
        public string? VehicleModel { get; set; } = default!; // 车型
        public string? PurchaseTime { get; set; } = default!; // 购车时间
        public string? FaultTime { get; set; } = default!; // 故障时间
        public string? VehicleStatus { get; set; } = default!; // 车辆状态
        public string? PreventiveMeasures { get; set; } = default!; // 遏制措施
        public string? ProjectType { get; set; } = default!; // 项目类型
        public string? ResponsiblePerson { get; set; } = default!; // 责任人
        public string? NotificationNumber { get; set; } = default!; // 通知单号系统自动生成
        public string? PSQNumber { get; set; } = default!; // PSQ编号系统自动生成
        public string? Status { get; set; } = default!; // 状态
        public string? StageStatus { get; set; } = default!; // 阶段状态
        public string? ResponsibleDepartment { get; set; } = default!; // 责任部门
        public string? Manager { get; set; } = default!; // 管理人
        public string? Creator { get; set; } = default!; // 创建人
        public string? StartTime { get; set; } = default!; // 开始时间 (作为字符串)
        public string? TTF { get; set; } = default!; // TTF
        public string? PendingPerson { get; set; } = default!; // 待处理人
    }
}
