namespace Sistema_Marcacao_Clinica_Veterinaria.Models
{
    public class Consulta : Servico
    {
        public int id { get; set; }
        public string? tipoConsulta { get; set;}
        public string? descricao { get; set;}

        public Consulta() : base() { }
    }
}
