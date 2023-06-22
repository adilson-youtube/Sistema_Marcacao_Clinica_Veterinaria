using System.Text.Json.Serialization;

namespace Sistema_Marcacao_Clinica_Veterinaria.Models
{
    public class Endereco
    {
        public int id { get; set; }
        public string? rua { get; set; }
        public string? bairro { get; set; }
        public string? municipio { get; set; }
        //public string? provincia { get; set; }
        [JsonIgnore]
        public Proprietario? proprietario { get; set; } = null;
        public int? proprietarioId { get; set; }

        public Endereco() { }
    }
}
