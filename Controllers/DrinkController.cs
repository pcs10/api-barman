using Barman.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Barman.Controllers
{

    [ApiController]
    [Route("v1/drinks")]
    public class DrinkController : ControllerBase
    {

        public readonly IDrinkRepository _drinkService;

        public DrinkController(IDrinkRepository drinkService)
        {
            _drinkService = drinkService;
        }
        
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> ListarTodosAsync()
        {
            try
            {
                return Ok(await _drinkService.BuscarTodos());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }// listar todos

        [HttpGet("teste")]   
        public async Task<IActionResult> aaaaaa()
        {
            return Ok("Funfou");
        }
    }
}
