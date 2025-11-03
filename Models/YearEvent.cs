namespace TempleAPI.Models
{
    public class YearEvent
    {
        public int Id { get; set; }               // Auto-generated ID
        public int Month { get; set; }            // Month number (1–12)
        public string Date { get; set; } = string.Empty;
        public string Day { get; set; } = string.Empty;
        public string Time { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string? Image { get; set; }        // Base64 image string
    }
}
