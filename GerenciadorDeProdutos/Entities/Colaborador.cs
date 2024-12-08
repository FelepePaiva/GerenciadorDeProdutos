namespace GerenciadorDeProdutos.Entities
{
    public class Colaborador
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Cargo { get; set; }
        public Colaborador() { }

        public Colaborador(int id, string nome, string email, string password, string cargo)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Password = password;
            Cargo = cargo;
        }
    }
}
