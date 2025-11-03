using Microsoft.AspNetCore.Mvc;
using TempleAPI.Models;
using TempleAPI.Services;

namespace TempleAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DharshanBookingController : ControllerBase
    {
        private readonly DharshanBookingService _service;

        public DharshanBookingController(DharshanBookingService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetBookings()
        {
            return Ok(_service.GetAllBookings());
        }

        [HttpPost]
        public IActionResult PostBooking([FromBody] DharshanBooking booking)
        {
            if (booking == null || string.IsNullOrEmpty(booking.FullName) || string.IsNullOrEmpty(booking.Email))
                return BadRequest(new { message = "Invalid booking data" });

            _service.AddBooking(booking);
            return Ok(new { message = "Dharshan booking received successfully!" });
        }
    }
}
