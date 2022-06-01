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
        private readonly AppBancoContext _context;

        public TransacoesController(AppBancoContext context)
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

        //Deposito: api/Transacoes
        [HttpPost("deposito")]
        public async Task<ActionResult<Transaco>> DepositoTransaco(Transaco transaco)

        {
            Conta contaDB = _context.Contas.Find(transaco.ContaId);
            var tipo = transaco.TipoTransacaoId;
            
            var valor = transaco.Valor;            

            if(valor <= 0)
            {
                return BadRequest("Não é permitido entrar com valor 0 ou negativo!");
            }

            if(tipo == 1)
            {
                double saldo_Atual = contaDB.Saldo;                

                double deposito = saldo_Atual + valor;

                contaDB.Saldo = deposito;

                transaco.Valor = valor;
                transaco.Data = DateTime.Now;

                _context.Transacoes.Add(transaco);

                await _context.SaveChangesAsync();
               
            }

            return CreatedAtAction("GetTransaco", new { id = transaco.Id }, transaco);

        }

        //Saque: api/Transacoes
        [HttpPost("saque")]
        public async Task<ActionResult<Transaco>> SaqueTransaco(Transaco transaco)

        {
            Conta contaDB = _context.Contas.Find(transaco.ContaId);
            var tipo = transaco.TipoTransacaoId;

            var valor = transaco.Valor;

            double saldo_Atual = contaDB.Saldo;

            if (valor <= 0)
            {
                return BadRequest("Não é permitido entrar com valor 0 ou negativo!");
            }

            if(valor > saldo_Atual)
            {
                return BadRequest("Erro! Valor solicitado é maior que o saldo na conta!");
            }

            if (tipo == 2)
            {               

                double saldoTotal = saldo_Atual - valor;

                contaDB.Saldo = saldoTotal;

                transaco.Valor = valor;
                transaco.Data = DateTime.Now;

                _context.Transacoes.Add(transaco);

                await _context.SaveChangesAsync();

            }

            return CreatedAtAction("GetTransaco", new { id = transaco.Id }, transaco);

        }



        private bool TransacoExists(int id)
        {
            return _context.Transacoes.Any(e => e.Id == id);
        }
    }
}
