using Sistema_Marcacao_Clinica_Veterinaria.Enums;
using System.Text.Json.Serialization;

namespace Sistema_Marcacao_Clinica_Veterinaria.Models
{
    public abstract class Servico
    {
        public int id { get; set; }
        public DateTime? data { get; set; }
        public double? preco { get; set; }
        public string? tipoServico { get; set; }
        public TipoPagamento? tipoPagamento { get; set; }
        public ICollection<Marcacao>? marcacoes { get; set; } = new HashSet<Marcacao>();

        //[JsonConstructor]
        //protected Servico(DateTime data, double preco, string tipoServico, TipoPagamento tipoPagamento, ICollection<Marcacao> marcacoes) {
        //    this.data = data;
        //    this.preco = preco;
        //    this.tipoServico = tipoServico;
        //    this.tipoPagamento = tipoPagamento;
        //    //this.marcacoes = marcacoes;
        //}

        //[JsonConstructor()]
        public Servico() { }
    }
}
