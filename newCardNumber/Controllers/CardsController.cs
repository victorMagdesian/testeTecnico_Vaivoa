using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewCardNumber.Data;
using NewCardNumber.Models;

/*namespace NewCardNumber.Controllers
{
    [ApiController]
    [Route("v1/cards")]
    public class CardsController : ControllerBase
    {
        [HttpGet]
        [Route("{email:string}")]
        public async Task<ActionResult<List<Cards>>> Post(
            [FromServices] DataContext context, 
            [FromBody] Client model,
            [FromQuery] NewCardNumberClass action,
            string email)
        {
            for (int i = 0; i < context.Clients.Count(); i++)
            {
                
            }
            return ;
        }
    }
}*/