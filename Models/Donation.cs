namespace TempleAPI.Models
{
    public class Donation
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string SelectedScheme { get; set; } = string.Empty;
        public decimal Amount { get; set; }
    }
}
