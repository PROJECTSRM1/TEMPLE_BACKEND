using Microsoft.AspNetCore.Mvc;
using OfflineDonationsAPI.Models;
using OfflineDonationsAPI.Services;

namespace OfflineDonationsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OfflineDonationsController : ControllerBase
    {
        private readonly IOfflineDonationService _donationService;

        public OfflineDonationsController(IOfflineDonationService donationService)
        {
            _donationService = donationService;
        }

        [HttpPost]
        public IActionResult SubmitDonation([FromBody] OfflineDonation donation)
        {
            if (!donation.ProofAvailable || string.IsNullOrEmpty(donation.DonorName) || string.IsNullOrEmpty(donation.TransactionRef))
            {
                return BadRequest(new { message = "Missing required fields or proof not confirmed." });
            }

            _donationService.AddDonation(donation);
            return Ok(new { message = "Donation details received successfully." });
        }

        [HttpGet]
        public IActionResult GetDonations()
        {
            var allDonations = _donationService.GetAll();
            return Ok(allDonations);
        }
    }
}
