using System.ComponentModel;

namespace FilmesAPI.Enums
{
    public enum EOrdenacao
    {
        [Description("Alfab;ética Crescente")]
        AlfabeticaCrescente = 1,
        [Description("Alfabética Decrescente")]
        AlfabeticaDecrescente = 2,
        [Description("Mais Recente")]
        MaisRecente = 3,
        [Description("Mais Antigo")]
        MaisAntigo = 4
    }
}
