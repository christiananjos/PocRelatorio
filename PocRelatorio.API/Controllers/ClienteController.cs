using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PocRelatorio.API.Contexts;

namespace PocRelatorio.API.Controllers
{
    [Route("api/cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Cliente>>> Get([FromServices] DataContext context)
        {
            var clientes = await context.Clientes
                                 .Include(x => x.Titulos)
                                 .Include(x => x.FormaPagamentos)
                                 .AsNoTracking()
                                 .ToListAsync();




            return clientes;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<Cliente>>> GetById([FromServices] DataContext context, int id)
        {
            var clientDetail = await context.Clientes
                                            .Include(x => x.Titulos).Include(x => x.FormaPagamentos).AsNoTracking()
                                            .Where(x => x.Id == id).ToListAsync();

            return clientDetail;
        }


        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Cliente>> Post([FromServices] DataContext context, [FromBody] Cliente model)
        {
            if (ModelState.IsValid)
            {
                context.Clientes.Add(model);
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
