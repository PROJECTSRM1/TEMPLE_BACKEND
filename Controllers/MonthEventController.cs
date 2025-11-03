using Microsoft.AspNetCore.Mvc;
using TempleAPI.Models;
using TempleAPI.Services;

namespace TempleAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonthEventController : ControllerBase
    {
        private readonly MonthEventService _service;

        public MonthEventController(MonthEventService service)
        {
            _service = service;
        }

        // GET: api/MonthEvent
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        // GET: api/MonthEvent/{date}
        [HttpGet("{date}")]
        public IActionResult GetByDate(string date)
        {
            var ev = _service.GetByDate(date);
            if (ev == null)
                return NotFound();
            return Ok(ev);
        }

        // POST: api/MonthEvent
        [HttpPost]
        public IActionResult AddOrUpdate([FromBody] MonthEvent ev)
        {
            if (string.IsNullOrWhiteSpace(ev.Date))
                return BadRequest("Date is required");

            var result = _service.AddOrUpdateEvent(ev);
            return Ok(result);
        }

        // DELETE: api/MonthEvent/{date}
        [HttpDelete("{date}")]
        public IActionResult Delete(string date)
        {
            var removed = _service.DeleteEvent(date);
            if (!removed)
                return NotFound();
            return Ok(new { message = $"Event on {date} deleted." });
        }
    }
}
