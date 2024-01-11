using Sistema_Marcacao_Clinica_Veterinaria.Enums;
using System.Text.Json.Serialization;

namespace Sistema_Marcacao_Clinica_Veterinaria.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? NomeUsuario { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public Role? Role { get; set; }
        public DateTime? DataCriacao { get; set; } = new DateTime();
        public DateTime? UltimoAcesso { get; set; } = new DateTime();

        [JsonIgnore]
        public Proprietario? Proprietario { get; set; }
        [JsonIgnore]
        public Veterinario? Veterinario { get; set; }
    }
}
