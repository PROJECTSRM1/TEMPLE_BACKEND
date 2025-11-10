namespace TempleAPI.Models
{
    public class EventRegistration
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string EventName { get; set; } = string.Empty;
    }
}
