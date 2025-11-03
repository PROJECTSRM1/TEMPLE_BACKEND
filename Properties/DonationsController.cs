using Microsoft.AspNetCore.Mvc;
using TempleAPI.Models;
using TempleAPI.Services;

namespace TempleAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DonationsController : ControllerBase
    {
        private readonly IDonationService _donationService;

        public DonationsController(IDonationService donationService)
        {
            _donationService = donationService;
        }

        // ✅ POST: api/donations
        [HttpPost]
        public IActionResult PostDonation([FromBody] Donation donation)
        {
            var (success, message) = _donationService.ProcessDonation(donation);

            if (!success)
                return BadRequest(new { success, message });

            return Ok(new { success, message });
        }

        // ✅ GET: api/donations
        [HttpGet]
        public IActionResult GetDonations()
        {
            var donations = _donationService.GetAllDonations();
            return Ok(donations);
        }
    }
}
