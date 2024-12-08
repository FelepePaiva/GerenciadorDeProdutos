namespace GerenciadorDeProdutos.Models
{
    public class ColaboradorDTO
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Cargo { get; set; }
        public ColaboradorDTO() { }

        public ColaboradorDTO(string? nome, string? email, string? password, string? cargo)
        {
            Nome = nome;
            Email = email;
            Password = password;
            Cargo = cargo;
        }
    }
}
