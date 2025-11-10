using Microsoft.AspNetCore.Mvc;
using TempleAPI.Models;
using TempleAPI.Services;

namespace TempleAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnnadanamController : ControllerBase
    {
        private readonly AnnadanamService _service;

        public AnnadanamController(AnnadanamService service)
        {
            _service = service;
        }

        // GET: api/Annadanam
        [HttpGet]
        public ActionResult<List<AnnadanamModel>> GetAll()
        {
            return Ok(_service.GetAll());
        }

        // GET: api/Annadanam/5
        [HttpGet("{id}")]
        public ActionResult<AnnadanamModel> GetById(int id)
        {
            var record = _service.GetById(id);
            if (record == null)
                return NotFound();
            return Ok(record);
        }

        // POST: api/Annadanam
        [HttpPost]
        public ActionResult<AnnadanamModel> Create([FromBody] AnnadanamModel data)
        {
            try
            {
                var added = _service.Add(data);
                return CreatedAtAction(nameof(GetById), new { id = added.Id }, added);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Annadanam/5
        [HttpPut("{id}")]
        public ActionResult<AnnadanamModel> Update(int id, [FromBody] AnnadanamModel data)
        {
            try
            {
                var updated = _service.Update(id, data);
                return Ok(updated);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Record not found.");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Annadanam/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}
