using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Data;

//essa classe faz o contexto entre a nossa aplicação e o banco de dados
//Utilizar o DbContext abstrai a lógica de acesso ao banco de dados.

public class FilmeContext : DbContext //a classe FilmeContext herda de DbContext
{
    public FilmeContext(DbContextOptions<FilmeContext> opts) //opções de acesso ao banco de dados
        : base(opts) //não utilizaremos especificamente dentro desse construtor, então passamos para a classe pai
    {
            
    }
    //propriedade de acesso a tabela de filmes
    public DbSet<Filme> Filmes { get; set; } //DbSet é uma coleção de filmes
}
