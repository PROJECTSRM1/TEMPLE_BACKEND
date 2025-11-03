using OfflineDonationsAPI.Models;

namespace OfflineDonationsAPI.Services
{
    public interface IOfflineDonationService
    {
        IEnumerable<OfflineDonation> GetAll();
        void AddDonation(OfflineDonation donation);
    }

    public class OfflineDonationService : IOfflineDonationService
    {
        private readonly List<OfflineDonation> _donations = new();

        public IEnumerable<OfflineDonation> GetAll()
        {
            return _donations;
        }

        public void AddDonation(OfflineDonation donation)
        {
            _donations.Add(donation);
            Console.WriteLine("New donation added:");
            Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(donation, new System.Text.Json.JsonSerializerOptions { WriteIndented = true }));
        }
    }
}
