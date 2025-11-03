using Microsoft.AspNetCore.Mvc;
using TempleAPI.Models;
using TempleAPI.Services;

namespace TempleAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        // ✅ POST: api/Contact
        [HttpPost]
        public IActionResult PostContact([FromBody] ContactMessage contact)
        {
            var (success, message) = _contactService.SubmitContact(contact);

            if (!success)
                return BadRequest(new { message });

            return Ok(new { message });
        }

        // ✅ GET: api/Contact
        [HttpGet]
        public IActionResult GetContacts()
        {
            var contacts = _contactService.GetAllContacts();
            return Ok(contacts);
        }
    }
}
