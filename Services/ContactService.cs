using TempleAPI.Models;

namespace TempleAPI.Services
{
    public interface IContactService
    {
        (bool Success, string Message) SubmitContact(ContactMessage contact);
        IEnumerable<ContactMessage> GetAllContacts();
    }

    public class ContactService : IContactService
    {
        private static readonly List<ContactMessage> _contacts = new();

        public (bool Success, string Message) SubmitContact(ContactMessage contact)
        {
            if (string.IsNullOrEmpty(contact.Name) || string.IsNullOrEmpty(contact.Email) || string.IsNullOrEmpty(contact.Message))
            {
                return (false, "All fields are required.");
            }

            _contacts.Add(contact);
            Console.WriteLine($"📩 New Contact Message: {contact.Name} ({contact.Email}) - {contact.Message}");

            return (true, "Your message has been sent successfully!");
        }

        public IEnumerable<ContactMessage> GetAllContacts()
        {
            return _contacts;
        }
    }
}
