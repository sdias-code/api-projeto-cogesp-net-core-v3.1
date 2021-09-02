using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiByteBank.Models;

namespace ApiByteBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransacoesController : ControllerBase
    {
        private readonly SilvioBbAppBancoContext _context;

        public TransacoesController(SilvioBbAppBancoContext context)
        {
            _context = context;
        }

        // GET: api/Transacoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaco>>> GetTransacoes()
        {
            return await _context.Transacoes.ToListAsync();
        }

        // GET: api/Transacoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Transaco>> GetTransaco(int id)
        {
            var transaco = await _context.Transacoes.FindAsync(id);

            if (transaco == null)
            {
                return NotFound();
            }

            return transaco;
        }

        // POST: api/Transacoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Transaco>> PostTransaco(Transaco transaco)
        {
            _context.Transacoes.Add(transaco);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransaco", new { id = transaco.Id }, transaco);
        }

        // DELETE: api/Transacoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Transaco>> DeleteTransaco(int id)
        {
            var transaco = await _context.Transacoes.FindAsync(id);
            if (transaco == null)
            {
                return NotFound();
            }

            _context.Transacoes.Remove(transaco);
            await _context.SaveChangesAsync();

            return transaco;
        }

        private bool TransacoExists(int id)
        {
            return _context.Transacoes.Any(e => e.Id == id);
        }
    }
}
