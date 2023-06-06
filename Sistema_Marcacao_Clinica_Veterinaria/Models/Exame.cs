namespace Sistema_Marcacao_Clinica_Veterinaria.Models
{
    public class Exame : Servico
    {
        public int id { get; set; }
        public string tipoExame { get; set; }
        public string descricao { get; set; }

        public Exame() : base() { }
    }
}
