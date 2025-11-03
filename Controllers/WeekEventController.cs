using Microsoft.AspNetCore.Mvc;
using TempleAPI.Models;
using TempleAPI.Services;

namespace TempleAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeekEventController : ControllerBase
    {
        private readonly WeekEventService _service;

        public WeekEventController(WeekEventService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<WeekEvent>> Get()
        {
            return Ok(_service.GetAll());
        }

        [HttpPost]
        public ActionResult<WeekEvent> Post([FromBody] WeekEvent newEvent)
        {
            var added = _service.AddEvent(newEvent);
            if (added == null)
                return BadRequest("An event at this day/date/time already exists.");
            return Ok(added);
        }

        [HttpDelete("clear")]
        public IActionResult ClearAll()
        {
            _service.ClearAll();
            return Ok("All events cleared.");
        }
    }
}
