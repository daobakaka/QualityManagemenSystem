namespace WebWinMVC.Models
{
    public class QEIdentify
    {
        public int ID { get; set; } // Assuming you might want a primary key

        
        public string? LocationCode { get; set; } = default!; // 部位码
        public string? QEName { get; set; }=default!;
    }
}
