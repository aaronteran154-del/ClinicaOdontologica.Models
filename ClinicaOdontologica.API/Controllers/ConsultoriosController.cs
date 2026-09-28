using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClinicaOdontologica.Models;

namespace ClinicaOdontologica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultoriosController : ControllerBase
    {
        private readonly OdontologiaDbContext _context;
        public ConsultoriosController(OdontologiaDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Consultorio>>> GetConsultorios() => await _context.Consultorios.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Consultorio>> GetConsultorio(int id)
        {
            var item = await _context.Consultorios.FindAsync(id);
            return item == null ? NotFound() : item;
        }

        [HttpPost]
        public async Task<ActionResult<Consultorio>> PostConsultorio(Consultorio item)
        {
            _context.Consultorios.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetConsultorio), new { id = item.IdConsultorio }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsultorio(int id, Consultorio item)
        {
            if (id != item.IdConsultorio) return BadRequest();
            _context.Entry(item).State = EntityState.Modified;
            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException) { if (!_context.Consultorios.Any(e => e.IdConsultorio == id)) return NotFound(); else throw; }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsultorio(int id)
        {
            var item = await _context.Consultorios.FindAsync(id);
            if (item == null) return NotFound();
            _context.Consultorios.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}