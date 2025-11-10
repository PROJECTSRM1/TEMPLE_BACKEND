using Microsoft.AspNetCore.Mvc;
using TempleAPI.Models;
using TempleAPI.Services;

namespace TempleAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DayEventController : ControllerBase
    {
        private readonly DayEventService _service;

        public DayEventController(DayEventService service)
        {
            _service = service;
        }

        // GET: api/DayEvent
        [HttpGet]
        public ActionResult<IEnumerable<DayEvent>> GetAll()
        {
            return Ok(_service.GetAll());
        }

        // GET: api/DayEvent/{key}
        [HttpGet("{key}")]
        public ActionResult<DayEvent> Get(string key)
        {
            var ev = _service.GetByKey(key);
            if (ev == null) return NotFound("Event not found");
            return Ok(ev);
        }

        // POST: api/DayEvent
        [HttpPost]
        public ActionResult<DayEvent> Add([FromBody] DayEvent newEvent)
        {
            try
            {
                var added = _service.AddEvent(newEvent);
                return CreatedAtAction(nameof(Get), new { key = added.Key }, added);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/DayEvent/{key}
        [HttpDelete("{key}")]
        public IActionResult Delete(string key)
        {
            var removed = _service.DeleteEvent(key);
            if (!removed) return NotFound("Event not found");
            return NoContent();
        }
    }
}
