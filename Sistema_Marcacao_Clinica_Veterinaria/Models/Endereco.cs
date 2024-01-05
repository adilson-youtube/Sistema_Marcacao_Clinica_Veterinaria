using System.Text.Json.Serialization;

namespace Sistema_Marcacao_Clinica_Veterinaria.Models
{
    public class Endereco
    {
        public int Id { get; set; }
        public string? Rua { get; set; }
        public string? Bairro { get; set; }
        public string? Municipio { get; set; }
        //public string? provincia { get; set; }
        [JsonIgnore]
        public Proprietario? Proprietario { get; set; } = null;
        public int? ProprietarioId { get; set; }

        public Endereco() { }
    }
}
