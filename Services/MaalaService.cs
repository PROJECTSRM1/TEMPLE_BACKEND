using TempleAPI.Models;

namespace TempleAPI.Services
{
    public class MaalaService
    {
        private readonly List<MaalaResponse> _maalaTokens = new();

        public MaalaResponse GenerateToken(MaalaRequest request)
        {
            string randomPart = Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper();
            string token = $"MAALA-AYYAPPA-{DateTime.Now.Year}-{randomPart}";

            var response = new MaalaResponse
            {
                Name = request.Name,
                Age = request.Age,
                Gotram = request.Gotram,
                Phone = request.Phone,
                Token = token
            };

            _maalaTokens.Add(response);
            return response;
        }

        public List<MaalaResponse> GetAllTokens() => _maalaTokens;
    }
}
