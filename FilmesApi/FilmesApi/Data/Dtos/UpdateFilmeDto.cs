using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos;

public class UpdateFilmeDto
{
    [Required(ErrorMessage = "O título do filme é obrigatório")] //o usuário é obrigado a colocar um título
    public string Titulo { get; set; }
    [Required(ErrorMessage = "O gênero do filme é obrigatório")]
    [StringLength(50, ErrorMessage = "O gênero não pode ter mais do que 50 caracteres")] //a stringLength é mais flexível que a maxLength
    public string Genero { get; set; }
    [Required(ErrorMessage = "A duração do filme é obrigatória")]
    [Range(70, 600, ErrorMessage = "A duração deve ter no mínimo 70 e no máximo 600 minutos")]
    public int Duracao { get; set; }
}
