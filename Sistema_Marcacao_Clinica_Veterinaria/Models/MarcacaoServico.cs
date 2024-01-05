using Sistema_Marcacao_Clinica_Veterinaria.Enums;

namespace Sistema_Marcacao_Clinica_Veterinaria.Models
{
    public class MarcacaoServico
    {
        public int MarcacaoId { get; set; }
        public int ServicoId { get; set; }
        //public TipoPagamento? TipoPagamento { get; set; } = null;

        public MarcacaoServico() { }
        public MarcacaoServico(int MarcacaoId, int ServicoId) 
        {
            this.MarcacaoId = MarcacaoId;
            this.ServicoId = ServicoId;
            //this.TipoPagamento = TipoPagamento;
        }
    }
}
