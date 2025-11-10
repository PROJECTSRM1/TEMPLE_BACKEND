using TempleAPI.Models;

namespace TempleAPI.Services
{
    public class DayEventService
    {
        // Using a dictionary for fast lookup
        private readonly Dictionary<string, DayEvent> _events = new();

        public IEnumerable<DayEvent> GetAll() => _events.Values;

        public DayEvent? GetByKey(string key)
        {
            _events.TryGetValue(key, out var dayEvent);
            return dayEvent;
        }

        public DayEvent AddEvent(DayEvent newEvent)
        {
            // Prevent duplicate event at same date & hour
            if (_events.ContainsKey(newEvent.Key))
                throw new InvalidOperationException("An event already exists at this time.");

            _events[newEvent.Key] = newEvent;
            return newEvent;
        }

        public bool DeleteEvent(string key)
        {
            return _events.Remove(key);
        }

        public void ClearAll()
        {
            _events.Clear();
        }
    }
}
