namespace WebWinMVC.Models
{
    public class SeriesDescriptionTable
    {
        public int ID { get; set; }
        public string? VIN { get; set; } = default!;
        public string? VAN { get; set; } = default!;

        public string? InternalAnnouncemen { get; set; } = default!;
        public string? SeriesDescription { get; set; } = default!;
    }
}
