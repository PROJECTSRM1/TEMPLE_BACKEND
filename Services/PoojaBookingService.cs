using System.Collections.Generic;
using System.Linq;
using TempleAPI.Models;

namespace TempleAPI.Services
{
    public class PoojaBookingService
    {
        private readonly List<PoojaBooking> _bookings = new();
        private int _nextId = 1;

        public IEnumerable<PoojaBooking> GetAll() => _bookings;

        public PoojaBooking? GetById(int id) => _bookings.FirstOrDefault(b => b.Id == id);

        public PoojaBooking Add(PoojaBooking booking)
        {
            booking.Id = _nextId++;
            _bookings.Add(booking);
            return booking;
        }

        public bool Delete(int id)
        {
            var booking = GetById(id);
            if (booking == null) return false;
            _bookings.Remove(booking);
            return true;
        }
    }
}
