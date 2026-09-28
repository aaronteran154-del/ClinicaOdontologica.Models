using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClinicaOdontologica.Models;

namespace ClinicaOdontologica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TratamientosController : ControllerBase
    {
        private readonly OdontologiaDbContext _context;
        public TratamientosController(OdontologiaDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tratamiento>>> GetTratamientos() => await _context.Tratamientos.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Tratamiento>> GetTratamiento(int id)
        {
            var item = await _context.Tratamientos.FindAsync(id);
            return item == null ? NotFound() : item;
        }

        [HttpPost]
        public async Task<ActionResult<Tratamiento>> PostTratamiento(Tratamiento item)
        {
            _context.Tratamientos.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTratamiento), new { id = item.IdTratamiento }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTratamiento(int id, Tratamiento item)
        {
            if (id != item.IdTratamiento) return BadRequest();
            _context.Entry(item).State = EntityState.Modified;
            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException) { if (!_context.Tratamientos.Any(e => e.IdTratamiento == id)) return NotFound(); else throw; }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTratamiento(int id)
        {
            var item = await _context.Tratamientos.FindAsync(id);
            if (item == null) return NotFound();
            _context.Tratamientos.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}