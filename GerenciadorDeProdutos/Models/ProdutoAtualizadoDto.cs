using GerenciadorDeProdutos.Entities;
using System.ComponentModel;

namespace GerenciadorDeProdutos.Models
{
    public class ProdutoAtualizadoDto
    {
        public Status StatusProduto { get; set; }
        public int QuantidadeEstoque { get; set; }
        public ProdutoAtualizadoDto() { }

        public ProdutoAtualizadoDto(Status statusProduto, int quantidadeEstoque)
        {
            StatusProduto = statusProduto;
            QuantidadeEstoque = quantidadeEstoque;
        }
    }
    
}
