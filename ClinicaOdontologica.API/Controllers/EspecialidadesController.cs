using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClinicaOdontologica.Models;

namespace ClinicaOdontologica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadesController : ControllerBase
    {
        private readonly OdontologiaDbContext _context;
        public EspecialidadesController(OdontologiaDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Especialidad>>> GetEspecialidades() => await _context.Especialidades.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Especialidad>> GetEspecialidad(int id)
        {
            var item = await _context.Especialidades.FindAsync(id);
            return item == null ? NotFound() : item;
        }

        [HttpPost]
        public async Task<ActionResult<Especialidad>> PostEspecialidad(Especialidad item)
        {
            _context.Especialidades.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEspecialidad), new { id = item.IdEspecialidad }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEspecialidad(int id, Especialidad item)
        {
            if (id != item.IdEspecialidad) return BadRequest();
            _context.Entry(item).State = EntityState.Modified;
            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException) { if (!_context.Especialidades.Any(e => e.IdEspecialidad == id)) return NotFound(); else throw; }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEspecialidad(int id)
        {
            var item = await _context.Especialidades.FindAsync(id);
            if (item == null) return NotFound();
            _context.Especialidades.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}