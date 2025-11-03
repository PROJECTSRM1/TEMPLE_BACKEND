using TempleAPI.Models;

namespace TempleAPI.Services
{
    public interface IDonationService
    {
        (bool Success, string Message) ProcessDonation(Donation donation);
        IEnumerable<Donation> GetAllDonations();
    }

    public class DonationService : IDonationService
    {
        // In-memory donation list (temporary store)
        private static readonly List<Donation> _donations = new();

        public (bool Success, string Message) ProcessDonation(Donation donation)
        {
            if (donation == null || donation.Amount < 1 || string.IsNullOrEmpty(donation.Name) || string.IsNullOrEmpty(donation.Email))
            {
                return (false, "Invalid donation details.");
            }

            _donations.Add(donation);

            Console.WriteLine($"Donation Received: {donation.Name}, {donation.Email}, {donation.Amount} ₹ for {donation.SelectedScheme}");

            return (true, $"Thank you {donation.Name} for donating ₹{donation.Amount} towards {donation.SelectedScheme}.");
        }

        public IEnumerable<Donation> GetAllDonations()
        {
            return _donations;
        }
    }
}
