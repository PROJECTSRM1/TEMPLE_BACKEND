using Microsoft.AspNetCore.Mvc;
using TempleAPI.Models;
using TempleAPI.Services;

namespace TempleAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class YearCalendarController : ControllerBase
    {
        private readonly YearEventService _service;

        public YearCalendarController(YearEventService service)
        {
            _service = service;
        }

        // ✅ GET: api/YearCalendar
        [HttpGet]
        public IActionResult GetAll()
        {
            var events = _service.GetAll();
            return Ok(events);
        }

        // ✅ GET by ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var ev = _service.GetById(id);
            if (ev == null) return NotFound("Event not found");
            return Ok(ev);
        }

        // ✅ POST: api/YearCalendar
        [HttpPost]
        public IActionResult Add([FromBody] YearEvent newEvent)
        {
            if (newEvent == null || string.IsNullOrEmpty(newEvent.Title))
                return BadRequest("Invalid event data");

            var added = _service.Add(newEvent);
            return Ok(new { message = "Successfully Updated!", eventData = added });
        }

        // ✅ PUT: api/YearCalendar/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] YearEvent updated)
        {
            if (!_service.Update(id, updated))
                return NotFound("Event not found");

            return Ok(new { message = "Successfully Updated!" });
        }

        // ✅ DELETE: api/YearCalendar/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_service.Delete(id))
                return NotFound("Event not found");

            return Ok(new { message = "Event deleted successfully" });
        }
    }
}
