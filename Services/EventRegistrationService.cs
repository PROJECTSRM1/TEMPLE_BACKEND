using System.Collections.Generic;
using TempleAPI.Models;

namespace TempleAPI.Services
{
    public class EventRegistrationService
    {
        private readonly List<EventRegistration> _registrations = new();

        public void AddRegistration(EventRegistration registration)
        {
            _registrations.Add(registration);
        }

        public IEnumerable<EventRegistration> GetAllRegistrations()
        {
            return _registrations;
        }
    }
}
