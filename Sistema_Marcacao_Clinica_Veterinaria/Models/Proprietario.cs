namespace Sistema_Marcacao_Clinica_Veterinaria.Models
{
    public class Proprietario : Usuario
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string? telefone { get; set;}
        public DateTime? dataNascimento { get; set; }
        public Endereco endereco { get; set; }
        public ICollection<Animal> animais { get; set; }

        public Proprietario(): base() { }


    }
}
