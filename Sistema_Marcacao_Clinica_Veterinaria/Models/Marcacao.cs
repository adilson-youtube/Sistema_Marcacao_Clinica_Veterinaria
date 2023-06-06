namespace Sistema_Marcacao_Clinica_Veterinaria.Models
{
    public class Marcacao
    {
        public int id { get; set; }
        public DateTime diaSemana { get; set; }
        public DateTime diaMes { get; set; }
        public DateTime ano { get; set; }
        public Animal animal { get; set; }
        public Veterinario veterinario { get; set; }
        public ICollection<Servico> servicos { get; set; } 

        public Marcacao() { }
    }
}
