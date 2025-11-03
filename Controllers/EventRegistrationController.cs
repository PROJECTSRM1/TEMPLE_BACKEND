using Microsoft.AspNetCore.Mvc;
using TempleAPI.Models;
using TempleAPI.Services;

namespace TempleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventRegistrationController : ControllerBase
    {
        private readonly EventRegistrationService _service;

        public EventRegistrationController(EventRegistrationService service)
        {
            _service = service;
        }

        // POST api/EventRegistration
        [HttpPost]
        public IActionResult RegisterDonation([FromBody] EventRegistration registration)
        {
            if (registration == null)
                return BadRequest("Invalid registration data.");

            _service.AddRegistration(registration);
            return Ok(new
            {
                message = "✅ Donation Registered Successfully!",
                registration
            });
        }

        // GET api/EventRegistration
        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _service.GetAllRegistrations();
            return Ok(data);
        }
    }
}
