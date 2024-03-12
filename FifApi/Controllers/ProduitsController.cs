using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FifApi.Models.EntityFramework;

namespace FifApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduitsController : ControllerBase
    {
        private readonly FootDBContext _context;

        public ProduitsController(FootDBContext context)
        {
            _context = context;
        }

        // GET: api/Produits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produit>>> GetAllProducts()
        {
          if (_context.Produit == null)
          {
              return NotFound();
          }
            return await _context.Produit.ToListAsync();
        }

        // GET: api/Produits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Produit>> GetProduit(int id)
        {
          if (_context.Produit == null)
          {
              return NotFound();
          }
            var produit = await _context.Produit.FindAsync(id);

            if (produit == null)
            {
                return NotFound();
            }

            return produit;
        }

        // PUT: api/Produits/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduit(int id, Produit produit)
        {
            if (id != produit.MarqueId)
            {
                return BadRequest();
            }

            _context.Entry(produit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProduitExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Produits
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Produit>> PostProduit(Produit produit)
        {
          if (_context.Produit == null)
          {
              return Problem("Entity set 'FootDBContext.Produit'  is null.");
          }
            _context.Produit.Add(produit);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProduitExists(produit.MarqueId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProduit", new { id = produit.MarqueId }, produit);
        }

        // DELETE: api/Produits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduit(int id)
        {
            if (_context.Produit == null)
            {
                return NotFound();
            }
            var produit = await _context.Produit.FindAsync(id);
            if (produit == null)
            {
                return NotFound();
            }

            _context.Produit.Remove(produit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProduitExists(int id)
        {
            return (_context.Produit?.Any(e => e.MarqueId == id)).GetValueOrDefault();
        }
    }
}
