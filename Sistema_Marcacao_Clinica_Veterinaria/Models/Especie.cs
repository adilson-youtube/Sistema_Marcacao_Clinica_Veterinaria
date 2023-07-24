using System.Text.Json.Serialization;

namespace Sistema_Marcacao_Clinica_Veterinaria.Models
{
    public class Especie
    {
        public int Id { get; set; }
        public string? Raca { get; set; }
        [JsonIgnore]
        public ICollection<Animal>? Animais { get; set; } = new HashSet<Animal>();

        public Especie() { }   
    }
}
