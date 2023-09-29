//A pasta models contém os modelos de dados que serão utilizados na aplicação.

using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models;

public class Filme
{
    [Key] //a chave vai identificar o campo no banco de dados
    [Required]
    //pensando nas propriedades que um filme tem, vamos criar as propriedades
    //vamos utilizar as datas notations para restrigir o que o usuário pode colocar
    public int Id { get; set; } //nossos sistema está preparado para receber um id
    [Required(ErrorMessage = "O título do filme é obrigatório")] //o usuário é obrigado a colocar um título
    public string Titulo { get; set; }
    [Required(ErrorMessage = "O gênero do filme é obrigatório")]
    [MaxLength(50, ErrorMessage = "O gênero não pode ter mais do que 50 caracteres")]
    public string Genero { get; set; }
    [Required(ErrorMessage = "A duração do filme é obrigatória")]
    [Range(70, 600, ErrorMessage = "A duração deve ter no mínimo 70 e no máximo 600 minutos")]
    public int Duracao { get; set; }
}
