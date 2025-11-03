namespace OfflineDonationsAPI.Models
{
    public class TransferMethodDetails
    {
        public string? UpiIdUsed { get; set; }
        public string? BankAcctNameUsed { get; set; }
        public string? BankAcctNumberUsed { get; set; }
        public string? TempleAcctNumberUsed { get; set; }
        public string? TempleIfscUsed { get; set; }
    }
}
