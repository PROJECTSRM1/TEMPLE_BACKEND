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

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAllEvents());
        }

        [HttpPost]
        public IActionResult Add([FromBody] MonthEvent ev)
        {
            var added = _service.AddEvent(ev);
            if (added == null)
                return BadRequest("An event already exists at this date and time.");

            return Ok(added);
        }

        [HttpDelete("{date}/{index}")]
        public IActionResult Delete(string date, int index)
        {
            var success = _service.DeleteEvent(date, index);
            if (!success) return NotFound();
            return Ok();
        }
    }
}
