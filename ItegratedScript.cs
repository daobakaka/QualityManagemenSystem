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
            Map(m => m.MIS36).Name("36MIS");
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
            Map(m => m.OutboundRescueLicensePlate2).Name("外出救援车牌号（二次)");
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
            Map(m => m.MIS36).Name("36MIS");
            Map(m => m.SMT).Name("SMT");
            Map(m => m.LocationCode).Name("部位码");
            Map(m => m.FaultCode).Name("故障码");
            Map(m => m.PQSNumber).Name("PQS编号");
            Map(m => m.VAN).Name("VAN");
            Map(m => m.VAN).Name("VIN");
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
            Map(m => m.MaterialCode).Name("物料号");
            Map(m => m.LocationCode).Name("部位码");
            Map(m => m.FaultCode).Name("故障码");
            Map(m => m.BreakpointTime).Name("断点时间");
            Map(m => m.PQSNumber).Name("PQS编号");
            Map(m => m.VAN).Name("VAN");
            Map(m => m.VAN).Name("VIN");
        }
    }


}
