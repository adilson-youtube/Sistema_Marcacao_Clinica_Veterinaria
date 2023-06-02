using System.ComponentModel;

namespace Sistema_Marcacao_Clinica_Veterinaria.Enums
{
    public enum TipoPagamento
    {
        [Description("Pago com Dinheiro")]
        Cash = 1,
        [Description("Pago com Cartão")]
        Cartao = 2,
        [Description("Pago com Carteira Digital")]
        CarteiraDigital = 3
    }
}
