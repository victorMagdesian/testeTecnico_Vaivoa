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
    [Route("NewCard")]
    public class ClientControler : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Client>> Post(
            [FromServices] DataContext context,
            [FromBody] Client model,
            [FromQuery] NewCardNumberClass action)
        {
            if (ModelState.IsValid)
            {
                model.CardNumber = action.CreateCardNumber(model.CardBrand);
                context.Clients.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        /*[HttpGet]
        [Route("consult/{email:string}")]
        public async Task<ActionResult<List<Client>>> Post(
            [FromServices] DataContext context,
            [FromBody] Client model,
            [FromQuery] NewCardNumberClass action,
            string email)
        {
            for (int i = 0; i < context.Clients.Count(); i++)
            {
                if(model.Email == email)
                {
                    context.Clients.Find(email)
                }
            }
            return;
*/

        }
    }
