using System;
using System.Collections.Generic;
using System.Linq;
using TempleAPI.Models;

namespace TempleAPI.Services
{
    public class SpecialSevaBookingService
    {
        private readonly List<SpecialSevaBooking> _bookings = new();

        // Get all bookings
        public IEnumerable<SpecialSevaBooking> GetAll()
        {
            return _bookings;
        }

        // Get booking by ID
        public SpecialSevaBooking? GetById(int id)
        {
            return _bookings.FirstOrDefault(b => b.Id == id);
        }

        // Create a new booking
        public SpecialSevaBooking Create(SpecialSevaBooking booking)
        {
            int newId = _bookings.Any() ? _bookings.Max(b => b.Id) + 1 : 1;
            booking.Id = newId;

            // Calculate total amount based on members
            booking.TotalAmount = booking.Members > 0 ? booking.Members * 100 : 100;

            _bookings.Add(booking);
            return booking;
        }

        // Update an existing booking
        public bool Update(int id, SpecialSevaBooking updatedBooking)
        {
            var existing = GetById(id);
            if (existing == null) return false;

            existing.SevaName = updatedBooking.SevaName;
            existing.Name = updatedBooking.Name;
            existing.Age = updatedBooking.Age;
            existing.Mobile = updatedBooking.Mobile;
            existing.Date = updatedBooking.Date;
            existing.Members = updatedBooking.Members;
            existing.Email = updatedBooking.Email;

            // Recalculate total amount
            existing.TotalAmount = updatedBooking.Members > 0 ? updatedBooking.Members * 100 : 100;

            return true;
        }

        // Delete a booking
        public bool Delete(int id)
        {
            var existing = GetById(id);
            if (existing == null) return false;

            _bookings.Remove(existing);
            return true;
        }
    }
}
