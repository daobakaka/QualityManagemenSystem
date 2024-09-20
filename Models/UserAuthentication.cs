namespace WebWinMVC.Models
{
    public class UserAuthentication
    {
        public int ID { get; set; }
        public string ?Username { get; set; } = default!;
        public string ?Password { get; set; } = default!;
        public string ?Role { get; set; } = default!;
        public string ?Group { get; set; } = default!;
        public string ?Name { get; set; } = default!;
        public string ?Phone { get; set; } = default!;
    }
}
