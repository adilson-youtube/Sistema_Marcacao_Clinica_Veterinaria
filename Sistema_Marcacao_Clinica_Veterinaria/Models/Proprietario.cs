using Microsoft.AspNetCore.Components;
using System.Text.Json.Serialization;

namespace Sistema_Marcacao_Clinica_Veterinaria.Models
{
    public class Proprietario
    {
        public int Id { get; set; }
        public string? Nome { get; set; } = string.Empty;
        public string? Telefone { get; set;}
        public string? Genero { get; set;}
        public DateTime? DataNascimento { get; set; } = new DateTime();
        public Endereco? Endereco { get; set; }

        //[CascadingParameter]
        public Usuario? Usuario { get; set; } = new Usuario();
        public ICollection<Animal>? Animais { get; set; } = new HashSet<Animal>();
        public int? UsuarioId { get; set; }

    }
}
