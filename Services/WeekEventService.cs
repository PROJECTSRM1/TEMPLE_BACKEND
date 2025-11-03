using TempleAPI.Models;

namespace TempleAPI.Services
{
    public class WeekEventService
    {
        private readonly List<WeekEvent> _events = new List<WeekEvent>();

        public List<WeekEvent> GetAll() => _events;

        public WeekEvent AddEvent(WeekEvent newEvent)
        {
            // Optional: check duplicate by day+date+time
            if (_events.Any(e => e.Day == newEvent.Day && e.Date == newEvent.Date && e.Time == newEvent.Time))
                return null;

            _events.Add(newEvent);
            return newEvent;
        }

        public void ClearAll() => _events.Clear();
    }
}
