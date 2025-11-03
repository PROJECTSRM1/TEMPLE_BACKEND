using System.Collections.Concurrent;
using TempleAPI.Models;

namespace TempleAPI.Services
{
    public class MonthEventService
    {
        // Thread-safe in-memory event store
        private readonly ConcurrentDictionary<string, MonthEvent> _events = new();

        // Get all events
        public IEnumerable<MonthEvent> GetAll()
        {
            return _events.Values.OrderBy(e => e.Date);
        }

        // Get single event by date key
        public MonthEvent? GetByDate(string date)
        {
            _events.TryGetValue(date, out var ev);
            return ev;
        }

        // Add or Update an event
        public MonthEvent AddOrUpdateEvent(MonthEvent monthEvent)
        {
            // The date will be used as key (like “25-10-2025”)
            _events[monthEvent.Date] = monthEvent;
            return monthEvent;
        }

        // Delete an event by date
        public bool DeleteEvent(string date)
        {
            return _events.TryRemove(date, out _);
        }
    }
}
