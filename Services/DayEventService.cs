using TempleAPI.Models;

namespace TempleAPI.Services
{
    public class DayEventService
    {
        private readonly Dictionary<string, DayEvent> _events = new();

        public IEnumerable<DayEvent> GetAll() => _events.Values;

        public DayEvent AddEvent(DayEvent dayEvent)
        {
            if (_events.ContainsKey(dayEvent.Key))
            {
                throw new InvalidOperationException("Event already exists at this time");
            }

            _events[dayEvent.Key] = dayEvent;
            return dayEvent;
        }
    }
}
