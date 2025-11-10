using TempleAPI.Models;

namespace TempleAPI.Services
{
    public class AnnadanamService
    {
        private readonly List<AnnadanamModel> _annadanams = new();
        private int _nextId = 1;

        // Get all sponsors
        public List<AnnadanamModel> GetAll() => _annadanams;

        // Get one by Id
        public AnnadanamModel? GetById(int id) => _annadanams.FirstOrDefault(x => x.Id == id);

        // Add a new record
        public AnnadanamModel Add(AnnadanamModel data)
        {
            // ✅ Validation to prevent duplicates by date + mobile
            bool duplicate = _annadanams.Any(x => x.Date == data.Date && x.Mobile == data.Mobile);
            if (duplicate)
                throw new InvalidOperationException("Duplicate sponsorship detected for the same date and mobile.");

            data.Id = _nextId++;
            _annadanams.Add(data);
            return data;
        }

        // Update sponsor (optional)
        public AnnadanamModel Update(int id, AnnadanamModel updated)
        {
            var existing = GetById(id);
            if (existing == null)
                throw new KeyNotFoundException("Record not found.");

            existing.Name = updated.Name;
            existing.Date = updated.Date;
            existing.Mobile = updated.Mobile;
            existing.Amount = updated.Amount;

            return existing;
        }

        // Delete record
        public void Delete(int id)
        {
            var record = GetById(id);
            if (record != null)
                _annadanams.Remove(record);
        }
    }
}
