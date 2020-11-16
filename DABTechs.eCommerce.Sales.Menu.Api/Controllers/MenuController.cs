using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DABTechs.eCommerce.Sales.Providers.Menu;
using DABTechs.eCommerce.Sales.Providers.Menu.Models;

// TODO add logging
namespace DABTechs.eCommerce.Sales.Menu.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize]
    public class MenuController : ControllerBase
    {
        private readonly IMenu _menu;
        public MenuController(IMenu menu)
        {
            _menu = menu;
        }

        [Route("meganav")]
        [HttpGet]
        public async Task<ActionResult<MegaNav>> GetMenuAsync()
        {
            try
            {
                // Get the API Result.
                var menuResult = await _menu.GetMegaNav();
                
                // Return the search results.
                return Ok(menuResult);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}