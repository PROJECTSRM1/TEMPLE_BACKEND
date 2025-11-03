using TempleAPI.Models;

namespace TempleAPI.Services
{
    public class SpecialSevaService
    {
        private readonly List<SpecialSeva> _bookings = new List<SpecialSeva>();

        public IEnumerable<SpecialSeva> GetAllBookings() => _bookings;

        public void AddBooking(SpecialSeva booking)
        {
            _bookings.Add(booking);
        }
    }
}
