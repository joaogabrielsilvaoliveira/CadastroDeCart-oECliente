using System.ComponentModel;

namespace SisteminhaBancario.Enums
{
    public enum StatusTransacao
    {
        [Description("A pagar")]
        APagar = 1,
        [Description("paga")]
        PagamentoConcluido = 2
    }
}
