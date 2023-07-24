namespace Sistema_Marcacao_Clinica_Veterinaria.Models
{
    public class Veterinario
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Genero { get; set; }
        public string? Especialidade { get; set; }
        public Usuario? Usuario { get; set; } = new Usuario();
        public ICollection<Marcacao>? Marcacoes { get; set; }
        public int? UsuarioId { get; set; }
    }
}
