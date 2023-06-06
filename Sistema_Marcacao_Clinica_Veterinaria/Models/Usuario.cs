namespace Sistema_Marcacao_Clinica_Veterinaria.Models
{
    public class Usuario
    {
        public int id { get; set; }
        public string usuario { get; set; }
        public string senha { get; set; }
        public DateTime dataCriacao { get; set; }
        public DateTime ultimoAcesso { get; set; }

        public Usuario() { }
    }
}
