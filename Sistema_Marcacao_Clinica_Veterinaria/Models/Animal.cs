namespace Sistema_Marcacao_Clinica_Veterinaria.Models
{
    public class Animal
    {
        public int id { get; set; }
        public string? nome { get; set; }
        public string? sexo { get; set; }
        public DateTime? dataNascimento { get; set; }
        public Especie? especie { get; set; }
        public Proprietario? proprietario { get; set; }
        public ICollection<Marcacao>? marcacoes { get; set; }

        public Animal() { }


    }
}
