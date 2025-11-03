namespace TempleAPI.Models
{
    public class PoojaBooking
    {
        public string PoojaName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty; // Optional: capture who booked
        public DateTime BookingTime { get; set; } = DateTime.Now;
    }
}
