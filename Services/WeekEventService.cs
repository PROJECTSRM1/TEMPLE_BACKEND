using TempleAPI.Models;

namespace TempleAPI.Services
{
    public class WeekEventService
    {
        // In-memory storage for weekly events
        private readonly List<WeekEvent> _events = new List<WeekEvent>();

        // Get all events
        public List<WeekEvent> GetAll() => _events;

        // Add a new event (returns null if a duplicate exists)
        public WeekEvent? AddEvent(WeekEvent newEvent)
        {
            // Check for duplicates: same Day + Date + Time
            bool exists = _events.Any(e => e.Day == newEvent.Day
                                        && e.Date == newEvent.Date
                                        && e.Time == newEvent.Time);
            if (exists)
                return null;

            _events.Add(newEvent);
            return newEvent;
        }

        // Remove all events
        public void ClearAll() => _events.Clear();
    }
}
