//using Microsoft.AspNetCore.Mvc;
//using TempleAPI.Models;
//using TempleScheduleAPI.Models;
//using TempleScheduleAPI.Services;

//namespace TempleScheduleAPI.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class EventsController : ControllerBase
//    {
//        private readonly YearCalendarService _service;

//        public EventsController()
//        {
//            _service = new YearCalendarService();
//        }

//        [HttpGet]
//        public IActionResult GetAll()
//        {
//            var data = _service.GetAll();
//            return Ok(data);
//        }

//        [HttpPost]
//        public IActionResult AddEvent(EventModel model)
//        {
//            var result = _service.AddEvent(model);
//            if (!result.success)
//                return Conflict(new { message = result.message });
//            return Ok(new { message = result.message, eventData = result.newEvent });
//        }

//        [HttpPut("{id}")]
//        public IActionResult UpdateEvent(int id, EventModel model)
//        {
//            var result = _service.UpdateEvent(id, model);
//            if (!result.success)
//                return NotFound(new { message = result.message });
//            return Ok(new { message = result.message, eventData = result.updatedEvent });
//        }

//        [HttpDelete("{id}")]
//        public IActionResult DeleteEvent(int id)
//        {
//            var result = _service.DeleteEvent(id);
//            if (!result.success)
//                return NotFound(new { message = result.message });
//            return Ok(new { message = result.message });
//        }

//        [HttpPost("login")]
//        public IActionResult Login([FromBody] string password)
//        {
//            if (_service.ValidateLogin(password))
//                return Ok(new { isStaff = true });
//            return Unauthorized(new { message = "Invalid password" });
//        }
//    }
//}
