using Sistema_Marcacao_Clinica_Veterinaria.Enums;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Sistema_Marcacao_Clinica_Veterinaria.Models
{
    public class Vacina : Servico
    {
        //public int id { get; set; }
        public string? Nome { get; set; }
        public int? Periodo { get; set; }
        //public string? tipoVacina { get; set; }

        //[JsonConstructor]
        //public Vacina(string nome, int periodo, DateTime data, double preco, string tipoServico, TipoPagamento tipoPagamento, ICollection<Marcacao> marcacoes) 
        //    : base(data, preco, tipoServico, tipoPagamento, marcacoes) 
        //{ 
        //    this.nome = nome;
        //    this.periodo = periodo;
        //}

        //[JsonConstructor()]
        //public Vacina() : base() { }
    }
}
