using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClinicaOdontologica.Models;

namespace ClinicaOdontologica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitasController : ControllerBase
    {
        private readonly OdontologiaDbContext _context;
        public CitasController(OdontologiaDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cita>>> GetCitas() => await _context.Citas.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Cita>> GetCita(int id)
        {
            var item = await _context.Citas.FindAsync(id);
            return item == null ? NotFound() : item;
        }

        [HttpPost]
        public async Task<ActionResult<Cita>> PostCita(Cita item)
        {
            _context.Citas.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCita), new { id = item.IdCita }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCita(int id, Cita item)
        {
            if (id != item.IdCita) return BadRequest();
            _context.Entry(item).State = EntityState.Modified;
            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException) { if (!_context.Citas.Any(e => e.IdCita == id)) return NotFound(); else throw; }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCita(int id)
        {
            var item = await _context.Citas.FindAsync(id);
            if (item == null) return NotFound();
            _context.Citas.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}