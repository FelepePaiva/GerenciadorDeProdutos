using GerenciadorDeProdutos.Models;
using GerenciadorDeProdutos.Services;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeProdutos.Controllers
{
    [ApiController]
    [Route("api/colaborador")]
    public class ColaboradorController : Controller
    {
        private readonly ColaboradorService _service;

        public ColaboradorController(ColaboradorService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> AdicionarColaborador([FromBody] ColaboradorDTO colaboradorDTO)
        {
            await _service.AdicionarColaborador(colaboradorDTO);
            return Ok();
        }
        [HttpPut("/{id}")]
        public async Task<IActionResult> AtualizarColaborador(int id, [FromBody] ColaboradorDTO colaboradorDTO)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            try
            {
                var checar = await _service.AtualizarColaborador(id, colaboradorDTO);
                if (!checar)
                {
                    return BadRequest();
                }
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("/{id}")]
        public async Task<IActionResult> ExcluirColaborador(int id) 
        {
            
            if (id <= 0) 
            {
                return BadRequest();
            }
            try
            {
                var checar = await _service.ExcluirColaborador(id);
                if (!checar)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (ArgumentException ex) 
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
