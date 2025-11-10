using System;

namespace TempleAPI.Models
{
    public class SpecialSevaBooking
    {
        public int Id { get; set; } // Auto-increment ID
        public string SevaName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Mobile { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public int Members { get; set; }
        public string Email { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
