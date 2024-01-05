using Sistema_Marcacao_Clinica_Veterinaria.Enums;
using System.Text.Json.Serialization;

namespace Sistema_Marcacao_Clinica_Veterinaria.Models
{
    public class MarcacaoServico
    {
        public int Id { get; set; }
        public int MarcacaoId { get; set; }
        public int ServicoId { get; set; }
        public TipoPagamento? TipoPagamento { get; set; } = null;
        [JsonIgnore]
        public Marcacao? Marcacao { get; set; }
        [JsonIgnore]
        public Servico? Servico { get; set; }

        public MarcacaoServico() { }
        public MarcacaoServico(int MarcacaoId, int ServicoId) {
            this.MarcacaoId = MarcacaoId;
            this.ServicoId = ServicoId;
            this.TipoPagamento = TipoPagamento;
        }
    }
}
