using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClinicaOdontologica.Models;

namespace ClinicaOdontologica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecetasController : ControllerBase
    {
        private readonly OdontologiaDbContext _context;
        public RecetasController(OdontologiaDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Receta>>> GetRecetas() => await _context.Recetas.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Receta>> GetReceta(int id)
        {
            var item = await _context.Recetas.FindAsync(id);
            return item == null ? NotFound() : item;
        }

        [HttpPost]
        public async Task<ActionResult<Receta>> PostReceta(Receta item)
        {
            _context.Recetas.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetReceta), new { id = item.IdReceta }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutReceta(int id, Receta item)
        {
            if (id != item.IdReceta) return BadRequest();
            _context.Entry(item).State = EntityState.Modified;
            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException) { if (!_context.Recetas.Any(e => e.IdReceta == id)) return NotFound(); else throw; }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReceta(int id)
        {
            var item = await _context.Recetas.FindAsync(id);
            if (item == null) return NotFound();
            _context.Recetas.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}