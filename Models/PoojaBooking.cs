namespace TempleAPI.Models
{
    public class PoojaBooking
    {
        public int Id { get; set; }
        public string PoojaName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime BookingDate { get; set; } = DateTime.Now;
    }
}
