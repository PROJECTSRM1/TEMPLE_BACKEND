using System.Collections.Generic;
using System.Linq;
using TempleAPI.Models;

namespace TempleAPI.Services
{
    public class OfflineDonationService
    {
        private readonly List<OfflineDonation> _donations = new();

        public IEnumerable<OfflineDonation> GetAll() => _donations;

        public OfflineDonation Add(OfflineDonation donation)
        {
            donation.Id = _donations.Count + 1;
            _donations.Add(donation);
            return donation;
        }
    }
}
