using Barman.Interfaces;
using Barman.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Barman.Controllers
{

    [Authorize]
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


        [HttpPost]
        public async Task<ActionResult> InserirAsync([FromBody] Drink drink)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var erro = await _drinkService.Inserir(drink);

                if((erro == null) || (erro == ""))
                    return Created($"v1/drinks/{drink.Id}", drink);
                else
                    return BadRequest("ERRO -> " + erro.ToString());
            }catch (Exception ex)
            {
                return BadRequest("Erro (Controller) -> " + ex);
            }
        }// inserir
        
        [HttpPut(template: ("{id}"))]
        public async Task<IActionResult> AlterarAsync([FromBody] Drink drinkModel, [FromRoute] int id)
        {
            try
            {
                var drink = await _drinkService.Alterar(drinkModel, id);

                if ((drink == null) || drink == "")
                    return Ok(drink);
                else
                    return BadRequest("ERRO -> " + drink);
            }
            catch (Exception ex)
            {
                return BadRequest("ERRO -> " + ex);
            }

        } //alterar

        [HttpGet]
        [Route(template: "{id}")]
        public async Task<IActionResult> ListarPorIdAsync([FromRoute] int id)
        {
            try
            {
                var usuario = await _drinkService.BuscarPorId(id);

                if (usuario == null)
                {
                    return BadRequest("ERRO -> Drink não encontrado");
                }
                else
                {
                    return Ok(usuario);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }//listar um

        [HttpDelete(template: "{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var erro = await _drinkService.Excluir(id);

                if ((erro == null) || erro == "")
                    return Ok("Drink excluído com sucesso");
                else
                    return BadRequest("ERRO -> " + erro);
            }
            catch (Exception ex)
            {
                return BadRequest("ERRO -> " + ex);
            }
        }//excluir

    }
}
