using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClinicaOdontologica.Models;

namespace ClinicaOdontologica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OdontologosController : ControllerBase
    {
        private readonly OdontologiaDbContext _context;
        public OdontologosController(OdontologiaDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Odontologo>>> GetOdontologos() => await _context.Odontologos.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Odontologo>> GetOdontologo(int id)
        {
            var item = await _context.Odontologos.FindAsync(id);
            return item == null ? NotFound() : item;
        }

        [HttpPost]
        public async Task<ActionResult<Odontologo>> PostOdontologo(Odontologo item)
        {
            _context.Odontologos.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetOdontologo), new { id = item.IdOdontologo }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOdontologo(int id, Odontologo item)
        {
            if (id != item.IdOdontologo) return BadRequest();
            _context.Entry(item).State = EntityState.Modified;
            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException) { if (!_context.Odontologos.Any(e => e.IdOdontologo == id)) return NotFound(); else throw; }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOdontologo(int id)
        {
            var item = await _context.Odontologos.FindAsync(id);
            if (item == null) return NotFound();
            _context.Odontologos.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}