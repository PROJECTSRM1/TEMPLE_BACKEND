using Microsoft.AspNetCore.Mvc;
using TempleAPI.Models;
using TempleAPI.Services;

namespace TempleAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PoojaBookingController : ControllerBase
    {
        private readonly IPoojaBookingService _bookingService;

        public PoojaBookingController(IPoojaBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        // POST: api/poojabooking
        [HttpPost]
        public IActionResult BookPooja([FromBody] PoojaBooking booking)
        {
            if (string.IsNullOrEmpty(booking.PoojaName))
            {
                return BadRequest(new { message = "Pooja name is required." });
            }

            _bookingService.AddBooking(booking);
            return Ok(new { message = $"Booking received for {booking.PoojaName}." });
        }

        // GET: api/poojabooking
        [HttpGet]
        public IActionResult GetBookings()
        {
            var allBookings = _bookingService.GetAllBookings();
            return Ok(allBookings);
        }
    }
}
