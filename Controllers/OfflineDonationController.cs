using Microsoft.AspNetCore.Mvc;
using TempleAPI.Models;
using TempleAPI.Services;

namespace TempleAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OfflineDonationController : ControllerBase
    {
        private readonly OfflineDonationService _service;

        public OfflineDonationController(OfflineDonationService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAll());

        [HttpPost]
        public IActionResult Create([FromBody] OfflineDonation donation)
        {
            if (donation == null)
                return BadRequest("Donation details are required.");

            var saved = _service.Add(donation);
            return Ok(saved);
        }
    }
}
