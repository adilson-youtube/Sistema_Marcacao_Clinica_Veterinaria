using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Sistema_Marcacao_Clinica_Veterinaria.Models
{
    public class Marcacao
    {
        public int Id { get; set; }
        public DateTime? DiaSemana { get; set; }
        public DateTime? DiaMes { get; set; }
        public DateTime? Ano { get; set; }
        [JsonIgnore]
        public Animal? Animal { get; set; }
        public int? AnimalID { get; set; }
        [JsonIgnore]
        public Veterinario? Veterinario { get; set; } = new Veterinario();
        //[ForeignKey("VeterinarioID")]
        public int? VeterinarioID { get; set; }
        public ICollection<Servico>? Servicos { get; set; } = new HashSet<Servico>();

        public Marcacao() { }
    }
}
