namespace TempleAPI.Models
{
    public class YearEvent
    {
        public int Id { get; set; }
        public int Month { get; set; }
        public int Date { get; set; }
        public string Day { get; set; } = string.Empty;
        public string Time { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
    }
}
