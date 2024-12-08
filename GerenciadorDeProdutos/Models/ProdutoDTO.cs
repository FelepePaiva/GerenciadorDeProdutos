using GerenciadorDeProdutos.Entities;

namespace GerenciadorDeProdutos.Models
{
    public class ProdutoDTO
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Status StatusProduto { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeEstoque { get; set; }
        public ProdutoDTO() { }

        public ProdutoDTO(string nome, string descricao, Status statusProduto, decimal preco,
                            int quantidadeEstoque)
        {
            Nome = nome;
            Descricao = descricao;
            StatusProduto = statusProduto;
            Preco = preco;
            QuantidadeEstoque = quantidadeEstoque;
        }
    }
}
