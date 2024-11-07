using ClosedXML.Excel;
using CsvHelper.Configuration;
using System.Reflection;
using WebWinMVC.Models;

namespace WebWinMVC
{
    public enum DataOperation
    {
        Replace,
        Update
    }

    public class ItegratedScript
    {
    }
    public interface IExcelMapping<T>
    {
        Dictionary<string, string> GetColumnMappings();
    }
    public class ExcelMapper
    {
        public static T MapRowToEntity<T>(IXLRow row, IXLRow headerRow) where T : new()
        {
            var entity = new T();
            var properties = typeof(T).GetProperties().Skip(1);//跳过第一个属性

            foreach (var property in properties)
            {
                var headerIndex = GetHeaderIndex(headerRow, property.Name);
                if (headerIndex != -1)
                {
                    var cellValue = row.Cell(headerIndex).GetValue<string>();
                    property.SetValue(entity, cellValue);
                }
            }

            return entity;
        }

        private static int GetHeaderIndex(IXLRow headerRow, string columnName)
        {
            for (int i = 1; i <= headerRow.CellCount(); i++)
            {
                if (headerRow.Cell(i).GetValue<string>() == columnName)
                {
                    return i;
                }
            }
            return -1; // If not found, return -1
        }
    }

    public class HeaderMappingUtil
    {
        public static Dictionary<string, string> GetHeaderMapping<T>() where T : ClassMap
        {
            var map = Activator.CreateInstance<T>();
            var headerMapping = new Dictionary<string, string>();

            var properties = typeof(T).GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                                         .Where(f => f.FieldType == typeof(Dictionary<string, string>))
                                         .FirstOrDefault();

            if (properties != null)
            {
                var mapping = (Dictionary<string, string>)properties.GetValue(map);
                foreach (var kvp in mapping)
                {
                    headerMapping[kvp.Key] = kvp.Value;
                }
            }

            return headerMapping;
        }
    }
    public class PivotResult
    {
        public string? Order { get; set; }
        public string? ApprovalDate { get; set; }
        public string? VehicleModel { get; set; }
        public string? OldMaterialCode { get; set; }
        public string? OldMaterialDescription { get; set; }
        public string? SupplierShortCode { get; set; }
        public string? ResponsibilitySourceSupplierName { get; set; }
        public string? CaseCount { get; set; }
        public string? CumulativeCaseCount { get; set; }
        public string? MIS3 { get; set; }
        public string? MIS6 { get; set; }
        public string? MIS12 { get; set; }
        public string? MIS24 { get; set; }
        public string? MIS48 { get; set; }
        public string? SMT { get; set; }
        public string? LocationCode { get; set; }
        public string? FaultCode { get; set; }
        public string? BreakPointNum { get; set; }
        public string? BreakPointTime { get; set; }
    }
    public class DailyQualityIssueChecklistMap : ClassMap<DailyQualityIssueChecklist>
    {
        public DailyQualityIssueChecklistMap()
        {
            Map(m => m.SerialNumber).Name("序号");
            Map(m => m.ApprovalDate).Name("审核通过日期");
            Map(m => m.Model).Name("车型");
            Map(m => m.OldMaterialCode).Name("旧物料代码");
            Map(m => m.OldMaterialDescription).Name("旧物料描述");
            Map(m => m.SupplierShortCode).Name("供应商短代码");
            Map(m => m.ResponsibilitySourceSupplierName).Name("责任源供应商名称");
            Map(m => m.CaseCount).Name("案例数");
            Map(m => m.MIS).Name("MIS");
            Map(m => m.FaultMode).Name("故障模式");
            Map(m => m.QE).Name("QE");
            Map(m => m.IncludedInSIL).Name("是否已纳入SIL");
            Map(m => m.PQSNumber).Name("PQS编号");
            Map(m => m.BreakpointTime).Name("断点时间");
            Map(m => m.StartTime).Name("开启时间");
            Map(m => m.Remarks).Name("备注");
        }
    }

    public class DailyQualityIssueChecklistV91Map : ClassMap<DailyQualityIssueChecklistV91>
    {
        public DailyQualityIssueChecklistV91Map()
        {

            Map(m => m.OldMaterialCode).Name("旧物料代码");
            Map(m => m.OldMaterialDescription).Name("旧物料描述");
            Map(m => m.SupplierShortCode).Name("供应商短代码");
            Map(m => m.ResponsibilitySourceSupplierName).Name("责任源供应商名称");
            Map(m => m.MIS3).Name("3MIS");
            Map(m => m.MIS6).Name("6MIS");
            Map(m => m.MIS12).Name("12MIS");
            Map(m => m.MIS24).Name("24MIS");
            Map(m => m.MIS48).Name("48MIS");
            Map(m => m.SMT).Name("SMT");
            Map(m => m.LocationCode).Name("部位码");
            Map(m => m.FaultCode).Name("故障码");
            Map(m => m.IdentifiedFaultMode).Name("识别故障模式");
            Map(m => m.BreakdownCount).Name("断点次数");
            Map(m => m.QE).Name("QE");
            Map(m => m.IncludedInSIL).Name("是否已纳入SIL");
            Map(m => m.PQSNumber).Name("PQS编号");
            Map(m => m.BreakpointTime).Name("断点时间");
            Map(m => m.StartTime).Name("立项时间");
            Map(m => m.Remarks).Name("备注");
            Map(m => m.ServiceFaultIdentificationAccurate).Name("服务故障识别是否准确");
            Map(m => m.IsBreakdownInvalid).Name("断点失效");
            Map(m => m.ProjectIdentifier).Name("立项车号或底盘号"); // 新映射
        }
    }

    public class DailyServiceReviewFormMap : ClassMap<DailyServiceReviewForm>
    {
        public DailyServiceReviewFormMap()
        {
            Map(m => m.ServiceOrder).Name("服务单");
            Map(m => m.ServiceOrderStatus).Name("服务单状态");
            Map(m => m.ServiceOrderTotalPrice).Name("服务单总价格");
            Map(m => m.WorkOrderNumber).Name("工单号");
            Map(m => m.WorkOrderCreationDate).Name("工单创建日期");
            Map(m => m.WorkOrderType).Name("工单类型");
            Map(m => m.DepartureTime).Name("出发时间");
            Map(m => m.CarPickupTime).Name("接车时间");
            Map(m => m.WorkOrderRepairEndTime).Name("工单维修结束时间");
            Map(m => m.WorkOrderRepairAccount).Name("工单维修账号");
            Map(m => m.OutboundServiceLocation).Name("外出服务地点");
            Map(m => m.OutboundMileage).Name("外出里程");
            Map(m => m.Province).Name("省份");
            Map(m => m.ServiceStation).Name("服务站");
            Map(m => m.ServiceStationName).Name("服务站名称");
            Map(m => m.NoticeVehicleModel).Name("公告车型");
            Map(m => m.VAN).Name("VAN");
            Map(m => m.VIN).Name("VIN");
            Map(m => m.WarrantyStartDate).Name("三包开始日期");
            Map(m => m.MaterialType).Name("物料类型");
            Map(m => m.LineNumber).Name("行号");
            Map(m => m.OldMaterialCode).Name("旧物料代码");
            Map(m => m.OldMaterialDescription).Name("旧物料描述");
            Map(m => m.NewMaterialCode).Name("新物料代码");
            Map(m => m.NewMaterialDescription).Name("新物料描述");
            Map(m => m.RepairMethod).Name("维修方式");
            Map(m => m.SupplyMethod).Name("供货方式");
            Map(m => m.Quantity).Name("数量");
            Map(m => m.OldPartReturnStatus).Name("旧件退回状态");
            Map(m => m.ResponsibilitySourceIdentifier).Name("责任源标识");
            Map(m => m.ResponsibilitySourceSupplier).Name("责任源供应商");
            Map(m => m.SupplierShortCode).Name("供应商短代码");
            Map(m => m.ResponsibilitySourceSupplierName).Name("责任源供应商名称");
            Map(m => m.LinePrice).Name("行价格");
            Map(m => m.ActualAmount).Name("实际金额");
            Map(m => m.MaterialMarkupCoefficient).Name("物料上浮系数");
            Map(m => m.LaborRegionCoefficient).Name("工时地区系数");
            Map(m => m.LaborColdClimateCoefficient).Name("工时高寒系数");
            Map(m => m.LaborQualityCoefficient).Name("工时质量系数");
            Map(m => m.LocationCode).Name("部位码");
            Map(m => m.LocationCodeDescription).Name("部位码描述");
            Map(m => m.FaultCode).Name("故障码");
            Map(m => m.FaultCodeDescription).Name("故障码描述");
            Map(m => m.FaultDescription).Name("故障描述");
            Map(m => m.ServiceCategory).Name("服务类别");
            Map(m => m.ServiceOrderCreationDate).Name("服务单创建日期");
            Map(m => m.FDP).Name("FDP");
            Map(m => m.SpecialAuthorizationCode).Name("特殊授权码");
            Map(m => m.WBS).Name("WBS");
            Map(m => m.DrivingMileageKM).Name("行驶里程(KM)");
            Map(m => m.OutboundRescueLicensePlate1).Name("外出救援车牌号（一次）");
            Map(m => m.OutboundRescueLicensePlate2).Name("外出救援车牌号（二次）");
            Map(m => m.ApprovalDate).Name("审核通过日期");
        }
    }

    public class DailyServiceReviewFormQueryMap : ClassMap<DailyServiceReviewFormQuery>
    {
        public DailyServiceReviewFormQueryMap()
        {
            Map(m => m.ServiceOrder).Name("服务单");
            Map(m => m.ServiceOrderStatus).Name("服务单状态");
            Map(m => m.ServiceOrderTotalPrice).Name("服务单总价格");
            Map(m => m.WorkOrderNumber).Name("工单号");
            Map(m => m.WorkOrderCreationDate).Name("工单创建日期");
            Map(m => m.WorkOrderType).Name("工单类型");
            Map(m => m.DepartureTime).Name("出发时间");
            Map(m => m.CarPickupTime).Name("接车时间");
            Map(m => m.WorkOrderRepairEndTime).Name("工单维修结束时间");
            Map(m => m.WorkOrderRepairAccount).Name("工单维修账号");
            Map(m => m.OutboundServiceLocation).Name("外出服务地点");
            Map(m => m.OutboundMileage).Name("外出里程");
            Map(m => m.Province).Name("省份");
            Map(m => m.ServiceStation).Name("服务站");
            Map(m => m.ServiceStationName).Name("服务站名称");
            Map(m => m.NoticeVehicleModel).Name("公告车型");
            Map(m => m.VAN).Name("VAN");
            Map(m => m.VIN).Name("VIN");
            Map(m => m.WarrantyStartDate).Name("三包开始日期");
            Map(m => m.MaterialType).Name("物料类型");
            Map(m => m.LineNumber).Name("行号");
            Map(m => m.OldMaterialCode).Name("旧物料代码");
            Map(m => m.OldMaterialDescription).Name("旧物料描述");
            Map(m => m.NewMaterialCode).Name("新物料代码");
            Map(m => m.NewMaterialDescription).Name("新物料描述");
            Map(m => m.RepairMethod).Name("维修方式");
            Map(m => m.SupplyMethod).Name("供货方式");
            Map(m => m.Quantity).Name("数量");
            Map(m => m.OldPartReturnStatus).Name("旧件退回状态");
            Map(m => m.ResponsibilitySourceIdentifier).Name("责任源标识");
            Map(m => m.ResponsibilitySourceSupplier).Name("责任源供应商");
            Map(m => m.SupplierShortCode).Name("供应商短代码");
            Map(m => m.ResponsibilitySourceSupplierName).Name("责任源供应商名称");
            Map(m => m.LinePrice).Name("行价格");
            Map(m => m.ActualAmount).Name("实际金额");
            Map(m => m.MaterialMarkupCoefficient).Name("物料上浮系数");
            Map(m => m.LaborRegionCoefficient).Name("工时地区系数");
            Map(m => m.LaborColdClimateCoefficient).Name("工时高寒系数");
            Map(m => m.LaborQualityCoefficient).Name("工时质量系数");
            Map(m => m.LocationCode).Name("部位码");
            Map(m => m.LocationCodeDescription).Name("部位码描述");
            Map(m => m.FaultCode).Name("故障码");
            Map(m => m.FaultCodeDescription).Name("故障码描述");
            Map(m => m.FaultDescription).Name("故障描述");
            Map(m => m.ServiceCategory).Name("服务类别");
            Map(m => m.ServiceOrderCreationDate).Name("服务单创建日期");
            Map(m => m.FDP).Name("FDP");
            Map(m => m.SpecialAuthorizationCode).Name("特殊授权码");
            Map(m => m.WBS).Name("WBS");
            Map(m => m.DrivingMileageKM).Name("行驶里程(KM)");
            Map(m => m.OutboundRescueLicensePlate1).Name("外出救援车牌号（一次）");
            Map(m => m.OutboundRescueLicensePlate2).Name("外出救援车牌号（二次）");
            Map(m => m.ApprovalDate).Name("审核通过日期");
            Map(m => m.ManufacturingMonth).Name("制造月");
            Map(m => m.SalesDate).Name("销售日期");
            Map(m => m.MIS).Name("MIS");
            Map(m => m.VehicleModel).Name("车型");
            Map(m => m.Emission).Name("排放");
            Map(m => m.OrderType).Name("订单类型");
            Map(m => m.InternalModelCode).Name("内部车型代号");
            Map(m => m.VehicleType).Name("车辆类型");
            Map(m => m.Fuel).Name("燃料");
            Map(m => m.MISInterval).Name("MIS区间");
            Map(m => m.FilteredVehicleModel).Name("筛选车型");
        }
    }

    public class DailyQualityIssueChecklistV91QueryMap : ClassMap<DailyQualityIssueChecklistV91Query>
    {
        public DailyQualityIssueChecklistV91QueryMap()
        {
            Map(m => m.ApprovalDate).Name("审核通过日期");
            Map(m => m.VehicleModel).Name("车型");
            Map(m => m.OldMaterialCode).Name("旧物料代码");
            Map(m => m.OldMaterialDescription).Name("旧物料描述");
            Map(m => m.SupplierShortCode).Name("供应商短代码");
            Map(m => m.ResponsibilitySourceSupplierName).Name("责任源供应商名称");
            Map(m => m.CaseCount).Name("案例数");
            Map(m => m.AccumulatedCaseCount).Name("累计案例数");
            Map(m => m.OldMaterialCode).Name("旧物料代码");
            Map(m => m.OldMaterialDescription).Name("旧物料描述");
            Map(m => m.SupplierShortCode).Name("供应商短代码");
            Map(m => m.ResponsibilitySourceSupplierName).Name("责任源供应商名称");
            Map(m => m.MIS3).Name("3MIS");
            Map(m => m.MIS6).Name("6MIS");
            Map(m => m.MIS12).Name("12MIS");
            Map(m => m.MIS24).Name("24MIS");
            Map(m => m.MIS48).Name("48MIS");
            Map(m => m.SMT).Name("SMT");
            Map(m => m.LocationCode).Name("部位码");
            Map(m => m.FaultCode).Name("故障码");
            Map(m => m.PQSNumber).Name("PQS编号");
            Map(m => m.VAN).Name("VAN");
            Map(m => m.VIN).Name("VIN");
        }
    }

    public class VehicleBasicInfoMap : ClassMap<VehicleBasicInfo>
    {
        public VehicleBasicInfoMap()
        {
            // Map CSV columns to properties of the VehicleBasicInfo class
            Map(m => m.ShortVin).Name("底盘号");
            Map(m => m.VIN).Name("VIN");
            Map(m => m.VAN).Name("VAN");
            Map(m => m.FDP).Name("FDP");
            Map(m => m.AnnouncementModel).Name("公告");
            Map(m => m.ProductionDate).Name("生产日期");
            Map(m => m.SalesDate).Name("销售时间");
            Map(m => m.EngineNumber).Name("发动机编号");
            Map(m => m.ClaimDate).Name("出保时间");
            Map(m => m.ExportStatus).Name("是否出口车");
            Map(m => m.EngineModel).Name("发动机型号");
            Map(m => m.SsvaOrSva).Name("SSVA/SVA编号");
            Map(m => m.InternalAnnouncemen).Name("内部公告");
            Map(m => m.SeriesDescription).Name("车系描述");
            Map(m => m.ProductionMouth).Name("制造月");
            Map(m => m.Series).Name("车型");
            Map(m => m.Emissions).Name("排放");
        }
    }

    public class BreakpointAnalysisTableMap : ClassMap<BreakpointAnalysisTable>
    {
        public BreakpointAnalysisTableMap()
        {
            Map(m => m.MaterialCode).Name("旧物料代码");
            Map(m => m.LocationCode).Name("部位码");
            Map(m => m.FaultCode).Name("故障码");
            Map(m => m.BreakpointTime).Name("断点时间");
            Map(m => m.PQSNumber).Name("PQS编号");
            Map(m => m.VAN).Name("VAN");
            Map(m => m.VAN).Name("VIN");
        }
    }
    // 定义接口

    // 映射类实现

    public class DailyServiceReviewFormMapXLSX : IExcelMapping<DailyServiceReviewForm>
    {
        public Dictionary<string, string> GetColumnMappings()
        {
            return new Dictionary<string, string>
        {
            { "服务单", nameof(DailyServiceReviewForm.ServiceOrder) },
            { "服务单状态", nameof(DailyServiceReviewForm.ServiceOrderStatus) },
            { "服务单总价格", nameof(DailyServiceReviewForm.ServiceOrderTotalPrice) },
            { "工单号", nameof(DailyServiceReviewForm.WorkOrderNumber) },
            { "工单创建日期", nameof(DailyServiceReviewForm.WorkOrderCreationDate) },
            { "工单类型", nameof(DailyServiceReviewForm.WorkOrderType) },
            { "出发时间", nameof(DailyServiceReviewForm.DepartureTime) },
            { "接车时间", nameof(DailyServiceReviewForm.CarPickupTime) },
            { "工单维修结束时间", nameof(DailyServiceReviewForm.WorkOrderRepairEndTime) },
            { "工单维修账号", nameof(DailyServiceReviewForm.WorkOrderRepairAccount) },
            { "外出服务地点", nameof(DailyServiceReviewForm.OutboundServiceLocation) },
            { "外出里程", nameof(DailyServiceReviewForm.OutboundMileage) },
            { "省份", nameof(DailyServiceReviewForm.Province) },
            { "服务站", nameof(DailyServiceReviewForm.ServiceStation) },
            { "服务站名称", nameof(DailyServiceReviewForm.ServiceStationName) },
            { "公告车型", nameof(DailyServiceReviewForm.NoticeVehicleModel) },
            { "VAN", nameof(DailyServiceReviewForm.VAN) },
            { "VIN", nameof(DailyServiceReviewForm.VIN) },
            { "三包开始日期", nameof(DailyServiceReviewForm.WarrantyStartDate) },
            { "物料类型", nameof(DailyServiceReviewForm.MaterialType) },
            { "行号", nameof(DailyServiceReviewForm.LineNumber) },
            { "旧物料代码", nameof(DailyServiceReviewForm.OldMaterialCode) },
            { "旧物料描述", nameof(DailyServiceReviewForm.OldMaterialDescription) },
            { "新物料代码", nameof(DailyServiceReviewForm.NewMaterialCode) },
            { "新物料描述", nameof(DailyServiceReviewForm.NewMaterialDescription) },
            { "维修方式", nameof(DailyServiceReviewForm.RepairMethod) },
            { "供货方式", nameof(DailyServiceReviewForm.SupplyMethod) },
            { "数量", nameof(DailyServiceReviewForm.Quantity) },
            { "旧件退回状态", nameof(DailyServiceReviewForm.OldPartReturnStatus) },
            { "责任源标识", nameof(DailyServiceReviewForm.ResponsibilitySourceIdentifier) },
            { "责任源供应商", nameof(DailyServiceReviewForm.ResponsibilitySourceSupplier) },
            { "供应商短代码", nameof(DailyServiceReviewForm.SupplierShortCode) },
            { "责任源供应商名称", nameof(DailyServiceReviewForm.ResponsibilitySourceSupplierName) },
            { "行价格", nameof(DailyServiceReviewForm.LinePrice) },
            { "实际金额", nameof(DailyServiceReviewForm.ActualAmount) },
            { "物料上浮系数", nameof(DailyServiceReviewForm.MaterialMarkupCoefficient) },
            { "工时地区系数", nameof(DailyServiceReviewForm.LaborRegionCoefficient) },
            { "工时高寒系数", nameof(DailyServiceReviewForm.LaborColdClimateCoefficient) },
            { "工时质量系数", nameof(DailyServiceReviewForm.LaborQualityCoefficient) },
            { "部位码", nameof(DailyServiceReviewForm.LocationCode) },
            { "部位码描述", nameof(DailyServiceReviewForm.LocationCodeDescription) },
            { "故障码", nameof(DailyServiceReviewForm.FaultCode) },
            { "故障码描述", nameof(DailyServiceReviewForm.FaultCodeDescription) },
            { "故障描述", nameof(DailyServiceReviewForm.FaultDescription) },
            { "服务类别", nameof(DailyServiceReviewForm.ServiceCategory) },
            { "服务单创建日期", nameof(DailyServiceReviewForm.ServiceOrderCreationDate) },
            { "FDP", nameof(DailyServiceReviewForm.FDP) },
            { "特殊授权码", nameof(DailyServiceReviewForm.SpecialAuthorizationCode) },
            { "WBS", nameof(DailyServiceReviewForm.WBS) },
            { "行驶里程(KM)", nameof(DailyServiceReviewForm.DrivingMileageKM) },
            { "外出救援车牌号（一次）", nameof(DailyServiceReviewForm.OutboundRescueLicensePlate1) },
            { "外出救援车牌号（二次）", nameof(DailyServiceReviewForm.OutboundRescueLicensePlate2) },
            { "审核通过日期", nameof(DailyServiceReviewForm.ApprovalDate) }
        };
        }
    }

    public class DailyServiceReviewFormQueryMapXLSX : IExcelMapping<DailyServiceReviewFormQuery>
    {
        public Dictionary<string, string> GetColumnMappings()
        {
            return new Dictionary<string, string>
        {
            { "服务单", nameof(DailyServiceReviewFormQuery.ServiceOrder) },
            { "服务单状态", nameof(DailyServiceReviewFormQuery.ServiceOrderStatus) },
            { "服务单总价格", nameof(DailyServiceReviewFormQuery.ServiceOrderTotalPrice) },
            { "工单号", nameof(DailyServiceReviewFormQuery.WorkOrderNumber) },
            { "工单创建日期", nameof(DailyServiceReviewFormQuery.WorkOrderCreationDate) },
            { "工单类型", nameof(DailyServiceReviewFormQuery.WorkOrderType) },
            { "出发时间", nameof(DailyServiceReviewFormQuery.DepartureTime) },
            { "接车时间", nameof(DailyServiceReviewFormQuery.CarPickupTime) },
            { "工单维修结束时间", nameof(DailyServiceReviewFormQuery.WorkOrderRepairEndTime) },
            { "工单维修账号", nameof(DailyServiceReviewFormQuery.WorkOrderRepairAccount) },
            { "外出服务地点", nameof(DailyServiceReviewFormQuery.OutboundServiceLocation) },
            { "外出里程", nameof(DailyServiceReviewFormQuery.OutboundMileage) },
            { "省份", nameof(DailyServiceReviewFormQuery.Province) },
            { "服务站", nameof(DailyServiceReviewFormQuery.ServiceStation) },
            { "服务站名称", nameof(DailyServiceReviewFormQuery.ServiceStationName) },
            { "公告车型", nameof(DailyServiceReviewFormQuery.NoticeVehicleModel) },
            { "VAN", nameof(DailyServiceReviewFormQuery.VAN) },
            { "VIN", nameof(DailyServiceReviewFormQuery.VIN) },
            { "三包开始日期", nameof(DailyServiceReviewFormQuery.WarrantyStartDate) },
            { "物料类型", nameof(DailyServiceReviewFormQuery.MaterialType) },
            { "行号", nameof(DailyServiceReviewFormQuery.LineNumber) },
            { "旧物料代码", nameof(DailyServiceReviewFormQuery.OldMaterialCode) },
            { "旧物料描述", nameof(DailyServiceReviewFormQuery.OldMaterialDescription) },
            { "新物料代码", nameof(DailyServiceReviewFormQuery.NewMaterialCode) },
            { "新物料描述", nameof(DailyServiceReviewFormQuery.NewMaterialDescription) },
            { "维修方式", nameof(DailyServiceReviewFormQuery.RepairMethod) },
            { "供货方式", nameof(DailyServiceReviewFormQuery.SupplyMethod) },
            { "数量", nameof(DailyServiceReviewFormQuery.Quantity) },
            { "旧件退回状态", nameof(DailyServiceReviewFormQuery.OldPartReturnStatus) },
            { "责任源标识", nameof(DailyServiceReviewFormQuery.ResponsibilitySourceIdentifier) },
            { "责任源供应商", nameof(DailyServiceReviewFormQuery.ResponsibilitySourceSupplier) },
            { "供应商短代码", nameof(DailyServiceReviewFormQuery.SupplierShortCode) },
            { "责任源供应商名称", nameof(DailyServiceReviewFormQuery.ResponsibilitySourceSupplierName) },
            { "行价格", nameof(DailyServiceReviewFormQuery.LinePrice) },
            { "实际金额", nameof(DailyServiceReviewFormQuery.ActualAmount) },
            { "物料上浮系数", nameof(DailyServiceReviewFormQuery.MaterialMarkupCoefficient) },
            { "工时地区系数", nameof(DailyServiceReviewFormQuery.LaborRegionCoefficient) },
            { "工时高寒系数", nameof(DailyServiceReviewFormQuery.LaborColdClimateCoefficient) },
            { "工时质量系数", nameof(DailyServiceReviewFormQuery.LaborQualityCoefficient) },
            { "部位码", nameof(DailyServiceReviewFormQuery.LocationCode) },
            { "部位码描述", nameof(DailyServiceReviewFormQuery.LocationCodeDescription) },
            { "故障码", nameof(DailyServiceReviewFormQuery.FaultCode) },
            { "故障码描述", nameof(DailyServiceReviewFormQuery.FaultCodeDescription) },
            { "故障描述", nameof(DailyServiceReviewFormQuery.FaultDescription) },
            { "服务类别", nameof(DailyServiceReviewFormQuery.ServiceCategory) },
            { "服务单创建日期", nameof(DailyServiceReviewFormQuery.ServiceOrderCreationDate) },
            { "FDP", nameof(DailyServiceReviewFormQuery.FDP) },
            { "特殊授权码", nameof(DailyServiceReviewFormQuery.SpecialAuthorizationCode) },
            { "WBS", nameof(DailyServiceReviewFormQuery.WBS) },
            { "行驶里程(KM)", nameof(DailyServiceReviewFormQuery.DrivingMileageKM) },
            { "外出救援车牌号（一次）", nameof(DailyServiceReviewFormQuery.OutboundRescueLicensePlate1) },
            { "外出救援车牌号（二次）", nameof(DailyServiceReviewFormQuery.OutboundRescueLicensePlate2) },
            { "审核通过日期", nameof(DailyServiceReviewFormQuery.ApprovalDate) },
            { "制造月", nameof(DailyServiceReviewFormQuery.ManufacturingMonth) },
            { "销售日期", nameof(DailyServiceReviewFormQuery.SalesDate) },
            { "MIS", nameof(DailyServiceReviewFormQuery.MIS) },
            { "车型", nameof(DailyServiceReviewFormQuery.VehicleModel) },
            { "排放", nameof(DailyServiceReviewFormQuery.Emission) },
            { "订单类型", nameof(DailyServiceReviewFormQuery.OrderType) },
            { "内部车型代号", nameof(DailyServiceReviewFormQuery.InternalModelCode) },
            { "车辆类型", nameof(DailyServiceReviewFormQuery.VehicleType) },
            { "燃料", nameof(DailyServiceReviewFormQuery.Fuel) },
            { "MIS区间", nameof(DailyServiceReviewFormQuery.MISInterval) },
            { "筛选车型", nameof(DailyServiceReviewFormQuery.FilteredVehicleModel) }
        };
        }
    }

    public class DailyQualityIssueChecklistV91MapXLSX : IExcelMapping<DailyQualityIssueChecklistV91>
    {
        public Dictionary<string, string> GetColumnMappings()
        {
            return new Dictionary<string, string>
        {
            { "旧物料代码", nameof(DailyQualityIssueChecklistV91.OldMaterialCode) },
            { "旧物料描述", nameof(DailyQualityIssueChecklistV91.OldMaterialDescription) },
            { "供应商短代码", nameof(DailyQualityIssueChecklistV91.SupplierShortCode) },
            { "责任源供应商名称", nameof(DailyQualityIssueChecklistV91.ResponsibilitySourceSupplierName) },
            { "案例数", nameof(DailyQualityIssueChecklistV91.CaseCount) },
            { "3MIS", nameof(DailyQualityIssueChecklistV91.MIS3) },
            { "6MIS", nameof(DailyQualityIssueChecklistV91.MIS6) },
            { "12MIS", nameof(DailyQualityIssueChecklistV91.MIS12) },
            { "24MIS", nameof(DailyQualityIssueChecklistV91.MIS24) },
            { "48MIS", nameof(DailyQualityIssueChecklistV91.MIS48) },
            { "SMT", nameof(DailyQualityIssueChecklistV91.SMT) },
            { "部位码", nameof(DailyQualityIssueChecklistV91.LocationCode) },
            { "故障码", nameof(DailyQualityIssueChecklistV91.FaultCode) },
            { "识别故障模式", nameof(DailyQualityIssueChecklistV91.IdentifiedFaultMode) },
            { "断点次数", nameof(DailyQualityIssueChecklistV91.BreakdownCount) },
            { "QE", nameof(DailyQualityIssueChecklistV91.QE) },
            { "是否已纳入SIL", nameof(DailyQualityIssueChecklistV91.IncludedInSIL) },
            { "PQS编号", nameof(DailyQualityIssueChecklistV91.PQSNumber) },
            { "断点时间", nameof(DailyQualityIssueChecklistV91.BreakpointTime) },
            { "立项时间", nameof(DailyQualityIssueChecklistV91.StartTime) },
            { "备注", nameof(DailyQualityIssueChecklistV91.Remarks) },
            { "服务故障识别是否准确", nameof(DailyQualityIssueChecklistV91.ServiceFaultIdentificationAccurate) },
            { "断点失效", nameof(DailyQualityIssueChecklistV91.IsBreakdownInvalid) },
            { "立项车号或底盘号", nameof(DailyQualityIssueChecklistV91.ProjectIdentifier) }
        };
        }
    }

    public class DailyQualityIssueChecklistV91QueryMapXLSX : IExcelMapping<DailyQualityIssueChecklistV91Query>
    {
        public Dictionary<string, string> GetColumnMappings()
        {
            return new Dictionary<string, string>
        {
            { "审核通过日期", nameof(DailyQualityIssueChecklistV91Query.ApprovalDate) },
            { "车型", nameof(DailyQualityIssueChecklistV91Query.VehicleModel) },
            { "旧物料代码", nameof(DailyQualityIssueChecklistV91Query.OldMaterialCode) },
            { "旧物料描述", nameof(DailyQualityIssueChecklistV91Query.OldMaterialDescription) },
            { "供应商短代码", nameof(DailyQualityIssueChecklistV91Query.SupplierShortCode) },
            { "责任源供应商名称", nameof(DailyQualityIssueChecklistV91Query.ResponsibilitySourceSupplierName) },
            { "案例数", nameof(DailyQualityIssueChecklistV91Query.CaseCount) },
            { "累计案例数", nameof(DailyQualityIssueChecklistV91Query.AccumulatedCaseCount) },
            { "3MIS", nameof(DailyQualityIssueChecklistV91Query.MIS3) },
            { "6MIS", nameof(DailyQualityIssueChecklistV91Query.MIS6) },
            { "12MIS", nameof(DailyQualityIssueChecklistV91Query.MIS12) },
            { "24MIS", nameof(DailyQualityIssueChecklistV91Query.MIS24) },
            { "48MIS", nameof(DailyQualityIssueChecklistV91Query.MIS48) },
            { "SMT", nameof(DailyQualityIssueChecklistV91Query.SMT) },
            { "部位码", nameof(DailyQualityIssueChecklistV91Query.LocationCode) },
            { "故障码", nameof(DailyQualityIssueChecklistV91Query.FaultCode) },
            { "PQS编号", nameof(DailyQualityIssueChecklistV91Query.PQSNumber) },
            { "VAN", nameof(DailyQualityIssueChecklistV91Query.VAN) },
            { "VIN", nameof(DailyQualityIssueChecklistV91Query.VIN) }
        };
        }
    }

    public class VehicleBasicInfoMapXLSX : IExcelMapping<VehicleBasicInfo>
    {
        public Dictionary<string, string> GetColumnMappings()
        {
            return new Dictionary<string, string>
        {
            { "底盘号", nameof(VehicleBasicInfo.ShortVin) },
            { "VIN", nameof(VehicleBasicInfo.VIN) },
            { "VAN", nameof(VehicleBasicInfo.VAN) },
            { "FDP", nameof(VehicleBasicInfo.FDP) },
            { "公告", nameof(VehicleBasicInfo.AnnouncementModel) },
            { "生产日期", nameof(VehicleBasicInfo.ProductionDate) },
            { "销售时间", nameof(VehicleBasicInfo.SalesDate) },
            { "发动机编号", nameof(VehicleBasicInfo.EngineNumber) },
            { "出保时间", nameof(VehicleBasicInfo.ClaimDate) },
            { "是否出口车", nameof(VehicleBasicInfo.ExportStatus) },
            { "发动机型号", nameof(VehicleBasicInfo.EngineModel) },
            { "SSVA/SVA编号", nameof(VehicleBasicInfo.SsvaOrSva) },
            { "内部公告", nameof(VehicleBasicInfo.InternalAnnouncemen) },
            { "车系描述", nameof(VehicleBasicInfo.SeriesDescription) },
            { "制造月", nameof(VehicleBasicInfo.ProductionMouth) },
            { "车型", nameof(VehicleBasicInfo.Series) },
            { "排放", nameof(VehicleBasicInfo.Emissions) }
        };
        }
    }

    public class BreakpointAnalysisTableMapXLSX : IExcelMapping<BreakpointAnalysisTable>
    {
        public Dictionary<string, string> GetColumnMappings()
        {
            return new Dictionary<string, string>
        {
            { "旧物料代码", nameof(BreakpointAnalysisTable.MaterialCode) },
            { "部位码", nameof(BreakpointAnalysisTable.LocationCode) },
            { "故障码", nameof(BreakpointAnalysisTable.FaultCode) },
            { "断点时间", nameof(BreakpointAnalysisTable.BreakpointTime) },
            { "PQS编号", nameof(BreakpointAnalysisTable.PQSNumber) },
            { "VAN", nameof(BreakpointAnalysisTable.VAN) },
            { "VIN", nameof(BreakpointAnalysisTable.VIN) }
        };
        }
    }
}
