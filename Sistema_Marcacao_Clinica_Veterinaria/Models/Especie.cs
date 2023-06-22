using System.Text.Json.Serialization;

namespace Sistema_Marcacao_Clinica_Veterinaria.Models
{
    public class Especie
    {
        public int id { get; set; }
        public string? raca { get; set; }
        [JsonIgnore]
        public ICollection<Animal>? animais { get; set; } = new HashSet<Animal>();

        public Especie() { }   
    }
}
