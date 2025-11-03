using Microsoft.AspNetCore.Mvc;
using TempleAPI.Models;
using TempleAPI.Services;

namespace TempleAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpecialSevaController : ControllerBase
    {
        private readonly SpecialSevaService _service;

        public SpecialSevaController(SpecialSevaService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult BookSeva([FromBody] SpecialSeva booking)
        {
            if (string.IsNullOrEmpty(booking.SevaName) || string.IsNullOrEmpty(booking.DonorName))
            {
                return BadRequest(new { message = "Seva name and donor name are required." });
            }

            _service.AddBooking(booking);
            return Ok(new { message = $"Booking received for {booking.SevaName}. Thank you, {booking.DonorName}!" });
        }

        [HttpGet]
        public IActionResult GetBookings()
        {
            var allBookings = _service.GetAllBookings();
            return Ok(allBookings);
        }
    }
}
