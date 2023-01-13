using Microsoft.AspNetCore.Mvc;
using SiparisYonetimiNetCore.Entities;
using SiparisYonetimiNetCore.Service.Abstract;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SiparisYonetimiNetCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IService<Contact> _service;

        public ContactsController(IService<Contact> service)
        {
            _service = service;
        }

        // GET: api/<ContactsController>
        [HttpGet]
        public async Task<IEnumerable<Contact>> Get()
        {
            return await _service.GetAllAsync();
        }

        // GET api/<ContactsController>/5
        [HttpGet("{id}")]
        public async Task<Contact> Get(int id)
        {
            return await _service.FindAsync(id);
        }

        // POST api/<ContactsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Contact entity)
        {
            await _service.AddAsync(entity);
            await _service.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = entity.Id }, entity);
        }

        // PUT api/<ContactsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Contact entity)
        {
            _service.Update(entity);
            var sonuc = await _service.SaveChangesAsync();
            if (sonuc > 0) return NoContent();
            return StatusCode(StatusCodes.Status304NotModified);
        }

        // DELETE api/<ContactsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var kayit = await _service.FindAsync(id);
            if (kayit == null) return BadRequest();
            _service.Delete(kayit);
            var sonuc = await _service.SaveChangesAsync();
            if (sonuc > 0) return NoContent();
            return StatusCode(StatusCodes.Status304NotModified);
        }
    }
}
