using TempleAPI.Models;

namespace TempleAPI.Services
{
    public class SpecialDonationService
    {
        private readonly List<SpecialDonation> _donations = new();

        public IEnumerable<SpecialDonation> GetAll()
        {
            return _donations;
        }

        public void AddDonation(SpecialDonation donation)
        {
            _donations.Add(donation);
        }
    }
}
