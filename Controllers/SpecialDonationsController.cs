using Microsoft.AspNetCore.Mvc;
using TempleAPI.Models;
using TempleAPI.Services;

namespace TempleAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpecialDonationsController : ControllerBase
    {
        private readonly SpecialDonationService _service;

        public SpecialDonationsController(SpecialDonationService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult AddDonation([FromBody] SpecialDonation donation)
        {
            if (donation == null)
                return BadRequest("Invalid donation data.");

            _service.AddDonation(donation);
            return Ok(new { message = "Donation received successfully." });
        }

        [HttpGet]
        public IActionResult GetAllDonations()
        {
            var donations = _service.GetAll();
            return Ok(donations);
        }
    }
}
