using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Dtos;
public class CreateFilmeDto
{
    [Required(ErrorMessage = "Obrigatório")]
    [StringLength(50)]
    [RegularExpression(@"^[a-zA-Z0-9\sçáéíóúãõâêîôû]+$", ErrorMessage = "Não deve ter caracteres especiais")]
    public string Titulo { get; set; }
    [Required(ErrorMessage = "Obrigatório")]
    [MaxLength(50)]
    public string Genero { get; set; }

    [Required(ErrorMessage = "Obrigatório")]
    public string Sinopse { get; set; }

    [Required(ErrorMessage = "Obrigatório")]
    [Range(70, 240, ErrorMessage = "Intervalo de duração aceito: 70 a 240 minutos")]
    public int Duracao { get; set; }
}

