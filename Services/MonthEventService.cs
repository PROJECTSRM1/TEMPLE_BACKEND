using TempleAPI.Models;

namespace TempleAPI.Services
{
    public class MonthEventService
    {
        // In-memory storage
        private readonly List<MonthEvent> _events = new List<MonthEvent>();

        public List<MonthEvent> GetAllEvents()
        {
            return _events.OrderBy(e =>
            {
                var parts = e.Date.Split('-').Select(int.Parse).ToArray();
                return new DateTime(parts[2], parts[1], parts[0]);
            }).ToList();
        }

        public MonthEvent? AddEvent(MonthEvent ev)
        {
            // Check duplicate: same date and time
            var exists = _events.Any(e => e.Date == ev.Date && e.Time == ev.Time);
            if (exists)
            {
                return null; // reject duplicate
            }

            _events.Add(ev);
            return ev;
        }

        public bool DeleteEvent(string date, int index)
        {
            var dateEvents = _events.Where(e => e.Date == date).ToList();
            if (index < 0 || index >= dateEvents.Count) return false;

            var evToRemove = dateEvents[index];
            _events.Remove(evToRemove);
            return true;
        }
    }
}
