using Microsoft.AspNetCore.Mvc;
using SiparisYonetimiNetCore.Entities;
using SiparisYonetimiNetCore.Service.Abstract;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SiparisYonetimiNetCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IService<Customer> _service;

        public CustomersController(IService<Customer> service)
        {
            _service = service;
        }

        // GET: api/<CustomersController>
        [HttpGet]
        public async Task<IEnumerable<Customer>> Get()
        {
            return await _service.GetAllAsync();
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public async Task<Customer> Get(int id)
        {
            return await _service.FindAsync(id);
        }

        // POST api/<CustomersController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Customer entity)
        {
            await _service.AddAsync(entity);
            await _service.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = entity.Id }, entity);
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Customer entity)
        {
            _service.Update(entity);
            var sonuc = await _service.SaveChangesAsync();
            if (sonuc > 0) return NoContent();
            return StatusCode(StatusCodes.Status304NotModified);
        }

        // DELETE api/<CustomersController>/5
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
