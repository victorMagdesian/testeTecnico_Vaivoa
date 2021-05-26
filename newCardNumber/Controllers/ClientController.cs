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
            bool BoolAux = true;

            if (ModelState.IsValid)
            {
                model.CardNumber = action.CreateCardNumber(model.CardBrand);
                /*while (BoolAux == true)
                {
                    for (int i = 0; i < context.AllCardNumbers.Count(); i++)
                    {
                        if (context.AllCardNumbers.ElementAt(i) == model.CardNumber)
                        {
                            model.CardNumber = action.CreateCardNumber(model.CardBrand);
                        }
                        else { BoolAux = false; }
                    }
                }*/

                //context.AllCardNumbers.Add(model.CardNumber);
                context.Clients.Add(model);
                await context.SaveChangesAsync();

                for (int i = 0; i < context.Clients.Count(); i++)
                {
                    if (context.Clients.ElementAt(i).Email == model.Email)
                    {
                        model.CardsByEmail = context.Clients.ElementAt(i).CardNumber;

                    }
                }
                return model;


            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}