using ScreenSound_04.Modelos;

namespace ScreenSound_04.Filtros;

internal class LinqFilter
{
    //método que não precisamos dar um new(instanciar) para usar
    public static void FiltrarTodosOsGenerosMusicais (List<Musica> musicas)
    {
        var todosOsGenerosMusicais = musicas.Select(generos => 
        generos.Genero).Distinct().ToList(); //Distinct() - não repete os gêneros musicais
        foreach (var genero in todosOsGenerosMusicais) //para cada gênero musical, exibe o gênero
        {
            Console.WriteLine($"- {genero}");
        }
    }
    public static void FiltrarArtistasPorGeneroMusical(List<Musica> musicas, 
        string genero)
    {
        var artistasPorGeneroMusical = musicas.Where(musica => 
        musica.Genero!.Contains(genero)).Select(musica => 
        musica.Artista).Distinct().ToList();
        Console.WriteLine($"Exibindo os artistas por gênero músical >>> {genero}.");
        foreach (var artista in artistasPorGeneroMusical)
        {
            Console.WriteLine($"- {artista}");
        }
    }
    public static void FiltrarMusicasDeUmArtista(List<Musica> musicas, 
               string nomeDoArtista)
    {
        var musicasDeUmArtista = musicas.Where(musica => 
               musica.Artista!.Equals(nomeDoArtista)).ToList();
        Console.WriteLine($"Exibindo as músicas do artista >>> {nomeDoArtista}.");
        foreach (var musica in musicasDeUmArtista)
        {
            Console.WriteLine($"- {musica.Nome}");
        }
    }
    public static void FiltrarMusicasPeloAno(List<Musica> musicas, int ano)
    {
        var musicasDoAno = musicas.Where(musica => musica.Ano == ano)
            .OrderBy(musicas => musicas.Nome) // ordena as músicas pelo nome
    .Select(musicas => musicas.Nome) // seleciona apenas o nome das músicas
            .Distinct() // remove as duplicidades
            .ToList(); // converte o resultado em uma lista

        Console.WriteLine($"Músicas de {ano}");
        foreach (var musica in musicasDoAno)
        {
            Console.WriteLine($"- {musica}");
        }
    }

    internal static void FiltrarMusicasEmCSharp(List<Musica> musicas)
    {
        var musicasEmCSharp = musicas.Where(musica => musica.Tonalidade.Equals("C#"))
            .Select(musica => musica.Nome)
            .Distinct()
            .ToList();
        Console.WriteLine("Músicas em C#: ");
        foreach (var musica in musicasEmCSharp)
        {
            Console.WriteLine($"- {musica}");
        }
    }
}
