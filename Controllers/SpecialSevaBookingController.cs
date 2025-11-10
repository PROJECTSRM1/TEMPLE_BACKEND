using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TempleAPI.Models;
using TempleAPI.Services;

namespace TempleAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpecialSevaBookingController : ControllerBase
    {
        private readonly SpecialSevaBookingService _service;

        public SpecialSevaBookingController(SpecialSevaBookingService service)
        {
            _service = service;
        }

        // GET: api/SpecialSevaBooking
        [HttpGet]
        public ActionResult<IEnumerable<SpecialSevaBooking>> GetAll()
        {
            return Ok(_service.GetAll());
        }

        // GET: api/SpecialSevaBooking/{id}
        [HttpGet("{id}")]
        public ActionResult<SpecialSevaBooking> GetById(int id)
        {
            var booking = _service.GetById(id);
            if (booking == null) return NotFound(new { error = "Booking not found" });
            return Ok(booking);
        }

        // POST: api/SpecialSevaBooking
        [HttpPost]
        public ActionResult<SpecialSevaBooking> Create([FromBody] SpecialSevaBooking booking)
        {
            if (booking == null) return BadRequest(new { error = "Booking data is required" });

            if (string.IsNullOrWhiteSpace(booking.Name) ||
                string.IsNullOrWhiteSpace(booking.Mobile) ||
                booking.Age < 1 || booking.Members < 1)
            {
                return BadRequest(new { error = "Invalid booking data" });
            }

            var created = _service.Create(booking);
            return Ok(created);
        }

        // PUT: api/SpecialSevaBooking/{id}
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] SpecialSevaBooking booking)
        {
            if (booking == null) return BadRequest(new { error = "Booking data is required" });

            var updated = _service.Update(id, booking);
            if (!updated) return NotFound(new { error = "Booking not found" });

            return Ok(new { message = "Booking updated successfully" });
        }

        // DELETE: api/SpecialSevaBooking/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var deleted = _service.Delete(id);
            if (!deleted) return NotFound(new { error = "Booking not found" });

            return Ok(new { message = "Booking deleted successfully" });
        }
    }
}
