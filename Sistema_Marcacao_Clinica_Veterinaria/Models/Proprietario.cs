namespace Sistema_Marcacao_Clinica_Veterinaria.Models
{
    public class Proprietario
    {
        public int id { get; set; }
        public string nome { get; set; } = string.Empty;
        public string? telefone { get; set;}
        public DateTime? dataNascimento { get; set; }
        public Endereco? endereco { get; set; } = new Endereco();
        public Usuario? usuario { get; set; } = new Usuario();
        public ICollection<Animal>? animais { get; set; } = new HashSet<Animal>();
        public int? usuarioId { get; set; }

    }
}
