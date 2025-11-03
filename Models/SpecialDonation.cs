namespace TempleAPI.Models
{
    public class SpecialDonation
    {
        public string DonorName { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Scheme { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
