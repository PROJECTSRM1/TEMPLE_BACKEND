using TempleAPI.Models;

namespace TempleAPI.Services
{
    public class YearEventService
    {
        private static readonly List<YearEvent> _events = new();
        private static int _nextId = 1;

        public IEnumerable<YearEvent> GetAll() => _events;

        public YearEvent? GetById(int id) => _events.FirstOrDefault(e => e.Id == id);

        public YearEvent Add(YearEvent ev)
        {
            ev.Id = _nextId++;
            _events.Add(ev);
            return ev;
        }

        public bool Update(int id, YearEvent updated)
        {
            var existing = _events.FirstOrDefault(e => e.Id == id);
            if (existing == null) return false;

            existing.Month = updated.Month;
            existing.Date = updated.Date;
            existing.Day = updated.Day;
            existing.Time = updated.Time;
            existing.Title = updated.Title;
            existing.Image = updated.Image;
            return true;
        }

        public bool Delete(int id)
        {
            var ev = _events.FirstOrDefault(e => e.Id == id);
            if (ev == null) return false;
            _events.Remove(ev);
            return true;
        }
    }
}
