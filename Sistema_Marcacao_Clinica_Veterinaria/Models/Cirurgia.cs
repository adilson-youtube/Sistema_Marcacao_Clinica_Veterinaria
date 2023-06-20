namespace Sistema_Marcacao_Clinica_Veterinaria.Models
{
    public class Cirurgia : Servico
    {
        public int id { get; set; }
        public string? tipoCirurgia { get;set; }
        public string? descricao { get;set; }

        public Cirurgia() : base() { }
    }
}
