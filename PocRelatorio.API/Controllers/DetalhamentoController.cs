using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PocRelatorio.API.Contexts;

namespace PocRelatorio.API.Controllers
{
    [Route("api/detalhamento")]
    [ApiController]
    public class DetalhamentoController : ControllerBase
    {

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<TitulosRenegociados>>> Get([FromServices] DataContext context)
        {
            var detalhes = await context.Titulos.ToListAsync();

            return detalhes;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<TitulosRenegociados>> GetBy([FromServices] DataContext context, int id)
        {
            var detalhe = await context.Titulos.FindAsync(id);

            return detalhe;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<TitulosRenegociados>> Post([FromServices] DataContext context, [FromBody] TitulosRenegociados detalhamento)
        {
            if (ModelState.IsValid)
            {
                context.Titulos.Add(detalhamento);
                await context.SaveChangesAsync();
                return detalhamento;
            }
            else
            {
                return BadRequest(ModelState);
            }
          
        }



    }
}
