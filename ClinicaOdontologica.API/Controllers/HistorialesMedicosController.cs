using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClinicaOdontologica.Models;

namespace ClinicaOdontologica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialesMedicosController : ControllerBase
    {
        private readonly OdontologiaDbContext _context;
        public HistorialesMedicosController(OdontologiaDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistorialMedico>>> GetHistorialesMedicos() => await _context.HistorialesMedicos.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<HistorialMedico>> GetHistorialMedico(int id)
        {
            var item = await _context.HistorialesMedicos.FindAsync(id);
            return item == null ? NotFound() : item;
        }

        [HttpPost]
        public async Task<ActionResult<HistorialMedico>> PostHistorialMedico(HistorialMedico item)
        {
            _context.HistorialesMedicos.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetHistorialMedico), new { id = item.IdHistorial }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistorialMedico(int id, HistorialMedico item)
        {
            if (id != item.IdHistorial) return BadRequest();
            _context.Entry(item).State = EntityState.Modified;
            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException) { if (!_context.HistorialesMedicos.Any(e => e.IdHistorial == id)) return NotFound(); else throw; }
            return NoContent();
        }   

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistorialMedico(int id)
        {
            var item = await _context.HistorialesMedicos.FindAsync(id);
            if (item == null) return NotFound();
            _context.HistorialesMedicos.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}