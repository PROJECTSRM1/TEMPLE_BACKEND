namespace TempleAPI.Models
{
    public class OfflineDonation
    {
        public int Id { get; set; }
        public string DonorName { get; set; } =string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public decimal Amount { get; set; } = decimal.Zero;
        public string DonationScheme { get; set; } = string.Empty;
        public string TransactionRef { get; set; } = string.Empty;
        public string TransferDate { get; set; } = string.Empty;
        public string TransferTime { get; set; } = string.Empty;
        public string FullAddress { get; set; } = string.Empty;
        public bool ProofAvailable { get; set; }
    }
}
