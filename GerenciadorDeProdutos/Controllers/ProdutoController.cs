using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GerenciadorDeProdutos.Contexts;
using GerenciadorDeProdutos.Entities;
using GerenciadorDeProdutos.Services;
using GerenciadorDeProdutos.Models;
using Microsoft.AspNetCore.Authorization;

namespace GerenciadorDeProdutos.Controllers
{
    
    [ApiController]
    [Route("api/")]
    public class ProdutoController : Controller
    {
        private readonly ProdutoService _service;

        public ProdutoController(ProdutoService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        [HttpGet("/todosprodutos")]
        public async Task<IActionResult> TodosProdutosCadastrados()
        {
            var listaProdutos = await _service.ListarTodosProdutosCadastrados();
            return Ok(listaProdutos);
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> TodosProdutosDisponiveis()
        {
            var listarProdutos = await _service.ListarTodosProdutosEmEstoque();
            return Ok(listarProdutos);
        }
        [Authorize(Roles ="gerente")]
        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody]ProdutoDTO produtoDTO)
        {
            await _service.AdicionarProduto(produtoDTO);
            return Ok();

        }
        [Authorize(Roles ="gerente, vendedor")]        
        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] ProdutoAtualizadoDto produtoDTO)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            try
            {
                var resultado = await _service.AtualizarProduto(id, produtoDTO);
                if (!resultado)
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
        [Authorize(Roles = "gerente")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirProduto(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            try
            {
                var resultado = await _service.ExcluirProduto(id);
                if (!resultado)
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
