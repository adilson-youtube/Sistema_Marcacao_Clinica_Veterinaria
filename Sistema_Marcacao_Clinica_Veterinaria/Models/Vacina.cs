namespace Sistema_Marcacao_Clinica_Veterinaria.Models
{
    public class Vacina : Servico
    {
        public int id { get; set; }
        public string? nome { get; set; }
        public int? periodo { get; set; }
        public string? tipoVacina { get; set; }

        public Vacina() : base() { }
    }
}
