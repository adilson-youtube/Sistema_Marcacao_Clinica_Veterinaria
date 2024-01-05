using Sistema_Marcacao_Clinica_Veterinaria.Enums;
using System.Text.Json.Serialization;

namespace Sistema_Marcacao_Clinica_Veterinaria.Models
{
    public class Servico
    {
        public int Id { get; set; }
        public DateTime? Data { get; set; }
        public double? Preco { get; set; }
        public string? TipoServico { get; set; }
        public TipoPagamento? TipoPagamento { get; set; }
        [JsonIgnore]
        public ICollection<Marcacao>? Marcacoes { get; set; } = new HashSet<Marcacao>();
        public ICollection<MarcacaoServico>? MarcacoesServicos { get; set; } = new HashSet<MarcacaoServico>();


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
