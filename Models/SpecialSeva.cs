namespace TempleAPI.Models
{
    public class SpecialSeva
    {
        public string SevaName { get; set; }
        public string DonorName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime BookingDate { get; set; } = DateTime.Now;
    }
}
