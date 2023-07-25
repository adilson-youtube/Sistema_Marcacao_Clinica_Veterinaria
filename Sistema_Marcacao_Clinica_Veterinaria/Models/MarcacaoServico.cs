using Sistema_Marcacao_Clinica_Veterinaria.Enums;

namespace Sistema_Marcacao_Clinica_Veterinaria.Models
{
    public class MarcacaoServico
    {
        public int MarcacaoId { get; set; }
        public int ServicoId { get; set; }
        public TipoPagamento? TipoPagamento { get; set; }
    }
}
