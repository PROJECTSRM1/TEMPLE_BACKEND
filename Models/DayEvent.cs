namespace TempleAPI.Models
{
    public class DayEvent
    {
        public string Key { get; set; } = string.Empty; 
        public string Date { get; set; } = string.Empty; 
        public string Time { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Desc { get; set; } = string.Empty;
        public string? Image { get; set; } 
    }
}
