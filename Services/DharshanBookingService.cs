using TempleAPI.Models;

namespace TempleAPI.Services
{
    public class DharshanBookingService
    {
        private readonly List<DharshanBooking> _bookings = new List<DharshanBooking>();

        public IEnumerable<DharshanBooking> GetAllBookings() => _bookings;

        public void AddBooking(DharshanBooking booking)
        {
            _bookings.Add(booking);
        }
    }
}
