namespace TempleAPI.Models
{
    public class EventModel
    {
        public int Id { get; set; }
        public int Month { get; set; } = 1;
        public string Date { get; set; } = string.Empty;
        public string Day { get; set; } = string.Empty;
        public string Time { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
    }
}
