using Microsoft.AspNetCore.Mvc;
using SiparisYonetimiNetCore.Entities;
using SiparisYonetimiNetCore.Service.Abstract;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SiparisYonetimiNetCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IService<Brand> _service;

        public BrandsController(IService<Brand> service) // D.I
        {
            _service = service;
        }
        // GET: api/<BrandsController>
        [HttpGet]
        public async Task<IEnumerable<Brand>> Get()
        {
            return await _service.GetAllAsync();
        }

        // GET api/<BrandsController>/5
        [HttpGet("{id}")]
        public async Task<Brand> Get(int id)
        {
            return await _service.FindAsync(id);
        }

        // POST api/<BrandsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Brand brand)
        {
            await _service.AddAsync(brand);
            await _service.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = brand.Id }, brand);
        }

        // PUT api/<BrandsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Brand brand)
        {
            _service.Update(brand);
            var sonuc = await _service.SaveChangesAsync();
            if (sonuc > 0) return NoContent();
            return StatusCode(StatusCodes.Status304NotModified);
        }

        // DELETE api/<BrandsController>/5
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
