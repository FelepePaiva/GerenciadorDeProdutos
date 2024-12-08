using GerenciadorDeProdutos.Contexts;
using GerenciadorDeProdutos.Entities;
using GerenciadorDeProdutos.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeProdutos.Services
{
    public class ProdutoService
    {
        private readonly ProgramContext _context;

        public ProdutoService(ProgramContext context)
        {
            _context = context;
        }
        public async Task<List<Produto>> ListarTodosProdutosCadastrados() 
        {
            return await _context.Produtos.ToListAsync();
        }
        public async Task<List<Produto>> ListarTodosProdutosEmEstoque() 
        {
            return await _context.Produtos.Where(
                p => p.StatusProduto == Status.EmEstoque).ToListAsync();
        }
        public async Task<bool> ExcluirProduto(int id) 
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.Id == id);
            if (produto == null) 
            {
                return false;   
            }
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task AdicionarProduto(ProdutoDTO produtoDTO) 
        {
            var novoProduto = new Produto
            {
                Nome = produtoDTO.Nome,
                Descricao = produtoDTO.Descricao,
                StatusProduto = produtoDTO.StatusProduto,
                Preco = produtoDTO.Preco,
                QuantidadeEstoque = produtoDTO.QuantidadeEstoque,
            };
            _context.Produtos.Add(novoProduto);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> AtualizarProduto(int id, ProdutoAtualizadoDto produto)
        {
            var checarProduto = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id);
            if (checarProduto == null) 
            {
                return false;
            }      
            
            if (checarProduto.QuantidadeEstoque < 0) 
            {
                throw new ArgumentException("O valor da quantidade não pode ser negativo");
            }
            checarProduto.StatusProduto = produto.StatusProduto;
            checarProduto.QuantidadeEstoque = produto.QuantidadeEstoque;
            
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
