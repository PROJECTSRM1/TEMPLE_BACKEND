namespace TempleAPI.Models
{
    public class MaalaRequest
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Gotram { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }

    public class MaalaResponse
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Gotram { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}
