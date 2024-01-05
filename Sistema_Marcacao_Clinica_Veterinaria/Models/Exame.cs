using Sistema_Marcacao_Clinica_Veterinaria.Enums;
using System.Text.Json.Serialization;

namespace Sistema_Marcacao_Clinica_Veterinaria.Models
{
    public class Exame : Servico
    {
        //public int Id { get; set; }
        //public string? TipoExame { get; set; }
        public string? Descricao { get; set; }

        //[JsonConstructor]
        //public Exame(string descricao, DateTime data, double preco, string tipoServico, TipoPagamento tipoPagamento, ICollection<Marcacao> marcacoes)
        //    : base(data, preco, tipoServico, tipoPagamento, marcacoes)
        //{
        //    this.descricao = descricao;
        //}

        //[JsonConstructor()]
        //public Exame() : base() { }
    }
}
