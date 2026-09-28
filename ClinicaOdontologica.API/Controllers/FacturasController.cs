using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClinicaOdontologica.Models;

namespace ClinicaOdontologica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturasController : ControllerBase
    {
        private readonly OdontologiaDbContext _context;
        public FacturasController(OdontologiaDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Factura>>> GetFacturas() => await _context.Facturas.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Factura>> GetFactura(int id)
        {
            var item = await _context.Facturas.FindAsync(id);
            return item == null ? NotFound() : item;
        }

        [HttpPost]
        public async Task<ActionResult<Factura>> PostFactura(Factura item)
        {
            _context.Facturas.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetFactura), new { id = item.IdFactura }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFactura(int id, Factura item)
        {
            if (id != item.IdFactura) return BadRequest();
            _context.Entry(item).State = EntityState.Modified;
            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException) { if (!_context.Facturas.Any(e => e.IdFactura == id)) return NotFound(); else throw; }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFactura(int id)
        {
            var item = await _context.Facturas.FindAsync(id);
            if (item == null) return NotFound();
            _context.Facturas.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}