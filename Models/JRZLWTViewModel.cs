namespace WebWinMVC.Models
{
    public class JRZLWTViewModel
    {
        public List<DailyQualityIssueChecklist> Checklists { get; set; } = new List<DailyQualityIssueChecklist>();
        public string AdditionalInfo { get; set; } = "这是一些额外的信息";
        public List<DailyQualityIssueChecklistV91> ChecklistV91s { get; set; }=new List<DailyQualityIssueChecklistV91>();
        public List<DailyQualityIssueChecklistV91Query> ChecklistV91Queries { get; set; }=new List<DailyQualityIssueChecklistV91Query>();

        public List<DailyServiceReviewForm> DailyServiceReviewForms { get; set; } = new List<DailyServiceReviewForm>();

        public List<DailyServiceReviewFormQuery> DailyServiceReviewFormQueries { get; set; } = new List<DailyServiceReviewFormQuery>();

        public List<VehicleBasicInfo> VehicleBasicInfos { get; set; } =new List<VehicleBasicInfo>();
        public List<BreakpointAnalysisTable> BreakpointAnalysisTables { get; set; } = new List<BreakpointAnalysisTable>();       


        public List<SILSimulationTable> SILSimulationTables { get; set; }= new List<SILSimulationTable>();

        public List<UserAuthentication> UserAuthentications { get; set; } = new List<UserAuthentication>();


        //add properties for pages
        public Dictionary<string, string> JRZLWTV91Headers { get; set; } = default!;


        public string ContentTest { get; set; } = default!;
    }
}
