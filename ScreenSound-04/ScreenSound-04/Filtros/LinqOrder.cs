

using ScreenSound_04.Modelos;

namespace ScreenSound_04.Filtros;

internal class LinqOrder
{
    public static void ExibirListaDeArtistasOrdenados(List<Musica> musicas) //recebemos uma lista de músicas
    {
        //primeiro ordenamos todas as músicas com base nos artistas
        //depois selecionamos apenas os artistas
        //e por fim, removemos os artistas repetidos
        var artistasOrdenados = musicas.OrderBy(musica => 
        musica.Artista).Select(musica => musica.Artista).Distinct().ToList(); //OrderBy - ordena os artistas em ordem alfabética
        Console.WriteLine("Lista de artistas ordenados");
        foreach (var artista in artistasOrdenados)
        {
            Console.WriteLine($" - {artista}");
        }
    }
}
