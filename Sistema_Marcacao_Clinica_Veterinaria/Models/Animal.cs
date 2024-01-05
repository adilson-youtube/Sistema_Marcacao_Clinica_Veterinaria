using System.Text.Json.Serialization;

namespace Sistema_Marcacao_Clinica_Veterinaria.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Sexo { get; set; }
        public double? Peso { get; set; }
        public DateTime? DataNascimento { get; set; }
        [JsonIgnore]
        public Especie? Especie { get; set; }
        [JsonIgnore]
        public Proprietario? Proprietario { get; set; }

        [JsonIgnore]
        public ICollection<Marcacao>? Marcacoes { get; set; }

        public Animal() { }


    }
}
