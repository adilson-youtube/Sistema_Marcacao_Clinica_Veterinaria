namespace Sistema_Marcacao_Clinica_Veterinaria.Models
{
    public class Servico
    {
        public int Id { get; set; }
        public DateTime? data { get; set; }
        public Pagamento? pagamento { get; set; }
    }
}
