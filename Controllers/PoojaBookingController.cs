using Microsoft.AspNetCore.Mvc;
using TempleAPI.Models;
using TempleAPI.Services;

namespace TempleAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PoojaBookingController : ControllerBase
    {
        private readonly PoojaBookingService _bookingService;

        public PoojaBookingController(PoojaBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        // ✅ POST: /api/PoojaBooking
        [HttpPost]
        public IActionResult CreateBooking([FromBody] PoojaBooking booking)
        {
            if (booking == null)
                return BadRequest("Invalid booking details.");

            var addedBooking = _bookingService.Add(booking);
            return Ok(addedBooking); // ✅ same response structure frontend expects
        }

        // ✅ GET: /api/PoojaBooking
        [HttpGet]
        public IActionResult GetAll()
        {
            var bookings = _bookingService.GetAll();
            return Ok(bookings);
        }

        // ✅ GET: /api/PoojaBooking/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var booking = _bookingService.GetById(id);
            if (booking == null)
                return NotFound();
            return Ok(booking);
        }

        // ✅ DELETE: /api/PoojaBooking/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _bookingService.Delete(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }
    }
}
