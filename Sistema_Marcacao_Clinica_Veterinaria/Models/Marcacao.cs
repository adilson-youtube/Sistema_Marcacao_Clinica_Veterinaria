using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_Marcacao_Clinica_Veterinaria.Models
{
    public class Marcacao
    {
        public int Id { get; set; }
        public DateTime? DiaSemana { get; set; }
        public DateTime? DiaMes { get; set; }
        public DateTime? Ano { get; set; }
        public Animal? Animal { get; set; }
        public Animal? AnimalID { get; set; }
        public Veterinario? Veterinario { get; set; } = new Veterinario();

        public ICollection<Servico>? Servicos { get; set; } = new HashSet<Servico>();

        public Marcacao() { }
    }
}
