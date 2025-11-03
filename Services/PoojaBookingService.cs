using TempleAPI.Models;

namespace TempleAPI.Services
{
    public interface IPoojaBookingService
    {
        void AddBooking(PoojaBooking booking);
        IEnumerable<PoojaBooking> GetAllBookings();
    }

    public class PoojaBookingService : IPoojaBookingService
    {
        private readonly List<PoojaBooking> _bookings = new();

        public void AddBooking(PoojaBooking booking)
        {
            _bookings.Add(booking);
            Console.WriteLine("New Pooja booked:");
            Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(booking, new System.Text.Json.JsonSerializerOptions { WriteIndented = true }));
        }

        public IEnumerable<PoojaBooking> GetAllBookings()
        {
            return _bookings;
        }
    }
}
