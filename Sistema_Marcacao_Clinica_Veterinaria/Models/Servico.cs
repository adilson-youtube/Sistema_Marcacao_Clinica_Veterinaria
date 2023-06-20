using Sistema_Marcacao_Clinica_Veterinaria.Enums;

namespace Sistema_Marcacao_Clinica_Veterinaria.Models
{
    public abstract class Servico
    {
        public int id { get; set; }
        public DateTime? data { get; set; }
        public double? preco { get; set; }
        public TipoPagamento? tipoPagamento { get; set; }
        public ICollection<Marcacao>? marcacoes { get; set; }

        public Servico() { }
    }
}
