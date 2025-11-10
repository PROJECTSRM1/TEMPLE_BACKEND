using Microsoft.AspNetCore.Mvc;
using TempleAPI.Models;
using TempleAPI.Services;

namespace TempleAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class YearCalendarController : ControllerBase
    {
        private readonly YearCalendarService _service;

        public YearCalendarController(YearCalendarService service)
        {
            _service = service;
        }

        // ✅ Get all events
        [HttpGet]
        public ActionResult<List<YearEvent>> Get() => _service.GetAll();

        // ✅ Get a specific event by ID
        [HttpGet("{id}")]
        public ActionResult<YearEvent> Get(int id)
        {
            var ev = _service.GetById(id);
            if (ev == null)
                return NotFound();
            return Ok(ev);
        }

        // ✅ Add a new event
        [HttpPost]
        public ActionResult<YearEvent> Post([FromBody] YearEvent ev)
        {
            try
            {
                var added = _service.Add(ev);
                return CreatedAtAction(nameof(Get), new { id = added.Id }, added);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // ✅ Update an existing event
        [HttpPut("{id}")]
        public ActionResult<YearEvent> Put(int id, [FromBody] YearEvent ev)
        {
            try
            {
                var updated = _service.Update(id, ev);
                return Ok(updated);
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Event with ID {id} not found.");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // ✅ Delete an event
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}
