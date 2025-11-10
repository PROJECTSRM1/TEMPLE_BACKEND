using Microsoft.AspNetCore.Mvc;
using TempleAPI.Models;
using TempleAPI.Services;

namespace TempleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaalaController : ControllerBase
    {
        private readonly MaalaService _service;

        public MaalaController(MaalaService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult<MaalaResponse> CreateMaalaToken([FromBody] MaalaRequest request)
        {
            if (string.IsNullOrEmpty(request.Name) ||
                string.IsNullOrEmpty(request.Gotram) ||
                string.IsNullOrEmpty(request.Phone) ||
                request.Age <= 0)
            {
                return BadRequest("Invalid request data");
            }

            var token = _service.GenerateToken(request);
            return Ok(token);
        }

        [HttpGet]
        public ActionResult<List<MaalaResponse>> GetAllTokens()
        {
            return Ok(_service.GetAllTokens());
        }
    }
}
