using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace FilmesApi.Controllers;
[ApiController] // a primeira coisa que precisamos fazer é começar nossas anotações
[Route("[controller]")] //a rota é para o nome do controlador
public class FilmeController : ControllerBase //herdamos de ControllerBase

    //queremos usar o banco de dados para criar as nossas tabelas
{
    //queremos usar o banco de dados para criar as nossas tabelas
    private FilmeContext _context;
    private IMapper _mapper;

    public FilmeController(FilmeContext context, IMapper mapper)
    {
        _context = context; //_context vai ser a implementação da instância do contexto que iremos utilizar 
        _mapper = mapper;
    }

    //private static List<Filme> filmes = new List<Filme>(); //vamos criar a nossa lista de filmes - vai ser estática pois queremos manter o escolpo
    //private static int id = 0; //para não termos conflitos de mesmo título, vamos criar uma classe para gerar um id

    /// <summary>
    /// Adiciona um filme ao banco de dados
    /// </summary>
    /// <param name="filmeDto">Objeto com os campos necessários para criação de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>

    [HttpPost] //queremos postar um filme então vamos usar a anotação HttpPost
    [ProducesResponseType(statusCode: 201)] //queremos que o status code seja 201
    public IActionResult AdicionaFilme(
        [FromBody] CreateFilmeDto filmeDto) //se queremos cadastrar um filme, então cadastramos um filme como parametro
    //especificamos que essa informação vem do corpo da requisição da requisição através do atributo [FromBody]
    {

        Filme filme = _mapper.Map<Filme>(filmeDto); //chamamos o automapper para ele fazer a conversão
        _context.Add(filme);
        _context.SaveChanges(); //salvamos as alterações no banco de dados
        return CreatedAtAction(nameof(RecuperaFilmePorId), new {id = filme.Id},
            filme); //retornamos o elemento que acabamos de criar
    }

    [HttpGet] //queremos pegar um filme então vamos usar a anotação HttpGet
    public IEnumerable<ReadFilmeDto> RecuperaFilme([FromQuery] int skip = 0, 
        [FromQuery] int take = 50) //ao invés de List podemos usar IEnumerable pois garantimos que a lista não vai ser alterada caso seja acessada por outra classe
    {
        //precisamos retornar uma lista de filmes
        return _mapper.Map<List<ReadFilmeDto>>(_context.Filmes.Skip(skip).Take(take)); //consulta paginada
    }
    [HttpGet("{id}")] //queremos pegar um filme então vamos usar a anotação HttpGet com o id
    public IActionResult RecuperaFilmePorId(int id) // IActionResult — resultado de uma ação da interface
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id); //queremos que o id retornado seja o do item que passamos no parametro
        if (filme == null) return NotFound();
        var filmeDto = _mapper.Map<ReadFilmeDto>(filme); //chamamos o automapper para ele fazer a conversão
        return Ok(filmeDto); //retornamos o filme dto
    }
    //Atualizando com PUT
    [HttpPut("{id}")]
    public IActionResult AtualizaFilme(int id, [FromBody] 
    UpdateFilmeDto filmeDto)
    {
        var filme = _context.Filmes.FirstOrDefault(
            filme => filme.Id == id); // queremos que esse filme que estamos procurando tenha o mesmo id que passamos no parametro
        if(filme == null) return NotFound();
        _mapper.Map(filmeDto, filme); //se não, atualizaremos as infos do filme a partir do meu filmeDto
        _context.SaveChanges(); //salvamos as alterações no banco de dados
        return NoContent(); //queremos retornar um status code NoContent
    }
    [HttpPatch("{id}")]
    public IActionResult AtualizaFilmeParcial(int id, 
        JsonPatchDocument<UpdateFilmeDto> patch)
    {
        var filme = _context.Filmes.FirstOrDefault(
                       filme => filme.Id == id); // queremos que esse filme que estamos procurando tenha o mesmo id que passamos no parametro
        if (filme == null) return NotFound();

        var filmeParaAtualizar = _mapper.Map<UpdateFilmeDto>(filme); //queremos mapear o filme para atualizar

        patch.ApplyTo(filmeParaAtualizar, ModelState); //aplicamos o patch no filme para atualizar

        if (!TryValidateModel(filmeParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }//se não conseguirmos validar o modelo, retornamos um problema de validação

    _mapper.Map(filmeParaAtualizar, filme); //se não, atualizaremos as infos do filme a partir do meu filmeDto
    _context.SaveChanges(); //salvamos as alterações no banco de dados
    return NoContent(); //queremos retornar um status code NoContent
    }
    [HttpDelete("{Id}")]
    public IActionResult DeletaFilme(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(
                       filme => filme.Id == id); // queremos que esse filme que estamos procurando tenha o mesmo id que passamos no parametro
        if (filme == null) return NotFound();
        _context.Remove(filme);
        _context.SaveChanges();
        return NoContent();
    }
}
