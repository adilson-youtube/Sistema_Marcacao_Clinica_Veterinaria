namespace Sistema_Marcacao_Clinica_Veterinaria.Models
{
    public class Veterinario
    {
        public int id { get; set; }
        public string? nome { get; set; }
        public string? especialidade { get; set; }
        public Usuario? usuario { get; set; } = new Usuario();
        public ICollection<Marcacao>? marcacoes { get; set; }
        public int? usuarioId { get; set; }
    }
}
