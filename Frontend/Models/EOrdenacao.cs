using System.ComponentModel;

namespace FilmesFrontend.Models
{
    public enum EOrdenacao
    {
        [Description("Alfabética Crescente")]
        AlfabeticaCrescente = 1,
        [Description("Alfabética Decrescente")]
        AlfabeticaDecrescente = 2,
        [Description("Mais Recente")]
        MaisRecente = 3,
        [Description("Mais Antigo")]
        MaisAntigo = 4
    }
}
