using Microsoft.AspNetCore.Mvc;
using TempleAPI.Models;
using TempleAPI.Services;

namespace TempleAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DayEventController : ControllerBase
    {
        private readonly DayEventService _eventService;

        public DayEventController(DayEventService eventService)
        {
            _eventService = eventService;
        }

        // GET: api/DayEvent
        [HttpGet]
        public IActionResult GetEvents()
        {
            return Ok(_eventService.GetAll());
        }

        // POST: api/DayEvent
        [HttpPost]
        public IActionResult AddEvent([FromBody] DayEvent dayEvent)
        {
            if (dayEvent == null || string.IsNullOrEmpty(dayEvent.Key))
            {
                return BadRequest("Invalid event data.");
            }

            try
            {
                var stored = _eventService.AddEvent(dayEvent);
                return Ok(stored);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message); // Duplicate event
            }
        }
    }
}
