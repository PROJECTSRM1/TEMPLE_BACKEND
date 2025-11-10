using TempleAPI.Models;

namespace TempleAPI.Services
{
    public class YearCalendarService
    {
        private readonly List<YearEvent> _events = new();
        private int _nextId = 1;

        public List<YearEvent> GetAll() => _events;

        public YearEvent? GetById(int id) => _events.FirstOrDefault(e => e.Id == id);

        public bool ExistsDuplicate(int month, int date, string time, int? ignoreId = null)
        {
            return _events.Any(e => e.Month == month && e.Date == date && e.Time == time && e.Id != ignoreId);
        }

        public YearEvent Add(YearEvent ev)
        {
            if (ExistsDuplicate(ev.Month, ev.Date, ev.Time))
                throw new InvalidOperationException("Duplicate event");

            ev.Id = _nextId++;
            _events.Add(ev);
            return ev;
        }

        public YearEvent Update(int id, YearEvent ev)
        {
            var existing = GetById(id);
            if (existing == null) throw new KeyNotFoundException("Event not found");

            if (ExistsDuplicate(ev.Month, ev.Date, ev.Time, id))
                throw new InvalidOperationException("Duplicate event");

            existing.Month = ev.Month;
            existing.Date = ev.Date;
            existing.Day = ev.Day;
            existing.Time = ev.Time;
            existing.Title = ev.Title;
            existing.Image = ev.Image;

            return existing;
        }

        public void Delete(int id)
        {
            var ev = GetById(id);
            if (ev != null) _events.Remove(ev);
        }
    }
}
