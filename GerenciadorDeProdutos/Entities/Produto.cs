namespace GerenciadorDeProdutos.Entities
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Status StatusProduto { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeEstoque { get; set; }

        public Produto() { }

        public Produto(int id, string nome, string descricao, Status statusProduto, decimal preco,
            int quantidadeEstoque)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            StatusProduto = statusProduto;
            Preco = preco;
            QuantidadeEstoque = quantidadeEstoque;
        }
    }
}
