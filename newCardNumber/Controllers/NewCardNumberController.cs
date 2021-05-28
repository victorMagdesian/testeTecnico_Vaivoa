using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewCardNumber.Data;
using NewCardNumber.Models;

namespace NewCardNumber.Controllers
{
    [ApiController]
    [Route("")]
    public class ClientControler : ControllerBase
    {
        [HttpGet]
        [Route("Clients")]
        public async Task<ActionResult<List<Client>>> Get(
        [FromServices] DataContext context)
        {
            var clients = await context.Clients.Include(x=>x.Card).ToListAsync();
            return clients;
        }

        [HttpPost]
        [Route("NewClient")]
        public async Task<ActionResult<Client>> Post(
            [FromServices] DataContext context,
            [FromBody] Client model,
            [FromQuery] NewCardNumberClass action)
        {

            if (ModelState.IsValid)
            {
                Client save = model;

                save.Card.CardNumber = action.CreateCardNumber(model.CardBrand);

                context.cards.Add(save.Card);
                context.Clients.Add(save);
                await context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}