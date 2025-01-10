using System.ComponentModel.DataAnnotations;

namespace FilmesFrontend.Models;

public class Filme
{
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "Preencha o nome")]
    [MaxLength(50)]
    [RegularExpression(@"^[a-zA-Z0-9\sçáéíóúãõâêîôû]+$", ErrorMessage = "Não deve ter caracteres especiais")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "Preencha gênero")]
    [RegularExpression(@"^[a-zA-Z0-9\sçáéíóúãõâêîôû]+$", ErrorMessage = "Não deve ter caracteres especiais")]
    [MaxLength(50)]
    public string Genero { get; set; }

    [Required(ErrorMessage = "Preencha a sinopse")]
    [MaxLength(150)]
    public string Sinopse { get; set; }

    [Required(ErrorMessage = "Preencha a duração")]
    [Range(70, 240, ErrorMessage = "Duração precisa ser de 70 a 240 minutos")]
    public int Duracao { get; set; }
}
