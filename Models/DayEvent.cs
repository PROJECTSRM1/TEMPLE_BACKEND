using System;

namespace TempleAPI.Models
{
    public class DayEvent
    {
        public string Key { get; set; }        // e.g., "2025-10-30-6"
        public string Title { get; set; }
        public string Desc { get; set; }
        public string Image { get; set; }      // base64 string from frontend
        public string Date { get; set; }       // "MM/DD/YYYY"
        public string Time { get; set; }       // "6 AM"
    }
}
