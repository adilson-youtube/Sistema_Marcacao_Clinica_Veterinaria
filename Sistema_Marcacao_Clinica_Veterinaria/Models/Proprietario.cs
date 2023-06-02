namespace Sistema_Marcacao_Clinica_Veterinaria.Models
{
    public class Proprietario
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string? telefone { get; set;}
        public DateTime? dataNascimento { get; set; }
        public Endereco? endereco { get; set; }


    }
}
