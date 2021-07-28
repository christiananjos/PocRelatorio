using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PocRelatorio.API.Contexts;

namespace PocRelatorio.API.Controllers
{
    [Route("api/formaPagamento")]
    [ApiController]
    public class FormaPagamentoController : ControllerBase
    {

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<FormaPagamento>>> Get([FromServices] DataContext context)
        {
            var formaPagamentos = await context.FormasPagamentos.ToListAsync();

            return formaPagamentos;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<FormaPagamento>> GetBy([FromServices] DataContext context, int id)
        {
            var formaPagto = await context.FormasPagamentos.FindAsync(id);

            return formaPagto;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<FormaPagamento>> Post([FromServices] DataContext context, [FromBody] FormaPagamento model)
        {
            if (ModelState.IsValid)
            {
                context.FormasPagamentos.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }

        }
    }
}
