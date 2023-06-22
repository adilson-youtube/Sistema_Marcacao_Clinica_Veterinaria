using Sistema_Marcacao_Clinica_Veterinaria.Enums;
using System.Text.Json.Serialization;

namespace Sistema_Marcacao_Clinica_Veterinaria.Models
{
    public class Usuario
    {
        public int id { get; set; }
        public string? usuario { get; set; }
        public string? senha { get; set; }
        public Role? role { get; set; }
        public DateTime? dataCriacao { get; set; } = new DateTime();
        public DateTime? ultimoAcesso { get; set; } = new DateTime();

        [JsonIgnore]
        public Proprietario? proprietario { get; set; }
        [JsonIgnore]
        public Veterinario? veterinario { get; set; }
    }
}
