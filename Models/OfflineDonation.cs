namespace OfflineDonationsAPI.Models
{
    public class OfflineDonation
    {
        public string DonorName { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string TransferDate { get; set; } = string.Empty;
        public string TransferTime { get; set; } = string.Empty;
        public string TransactionRef { get; set; } = string.Empty;
        public string FullAddress { get; set; } = string.Empty;
        public string DonationScheme { get; set; } = "general-fund";
        public bool ProofAvailable { get; set; }
        public string SelectedTransferMethod { get; set; } = "upi";
        public TransferMethodDetails? MethodDetails { get; set; }
    }
}
