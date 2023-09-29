using ScreenSound_04.Modelos;
using System.Text.Json;
using ScreenSound_04.Filtros;

using (HttpClient client = new HttpClient()) //usaremos esse pacote só dentro do using
//gerenciamos esse recurso
{
    //tentamos acessar a API
    try
    {
        string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json"); //com o Async, garantimos que o programa não vai travar
        var musicas = JsonSerializer.Deserialize<List<Musica>>(resposta)!; //queremos criar uma lista baseado no objeto música
        //desserialização - pegamos o Json e convertemos em ujm objeto manipulavel no C#
        //esse json deserialize não estamos instanciando um objeto, estamos criando uma lista de objetos
        //LinqFilter.FiltrarTodosOsGenerosMusicais(musicas);
        //LinqOrder.ExibirListaDeArtistasOrdenados(musicas);
        //LinqFilter.FiltrarArtistasPorGeneroMusical(musicas, "pop");
        //LinqFilter.FiltrarMusicasDeUmArtista(musicas, "U2");
        //LinqFilter.FiltrarMusicasPeloAno(musicas, 2012);

        //musicas[0].ExibirDetalhesDaMusica();
        LinqFilter.FiltrarMusicasEmCSharp(musicas);

        //var musicasPreferidasDoDaniel = new MusicasPreferidas("Daniel");
        //musicasPreferidasDoDaniel.AdicionarMusicasFavoritas(musicas[1]);
        //musicasPreferidasDoDaniel.AdicionarMusicasFavoritas(musicas[377]);
        //musicasPreferidasDoDaniel.AdicionarMusicasFavoritas(musicas[4]);
        //musicasPreferidasDoDaniel.AdicionarMusicasFavoritas(musicas[6]);
        //musicasPreferidasDoDaniel.AdicionarMusicasFavoritas(musicas[1467]);
        //musicasPreferidasDoDaniel.ExibirMusicasFavoritas();

        var musicasPreferidasEmily = new MusicasPreferidas("Emily");
        //musicasPreferidasEmily.AdicionarMusicasFavoritas(musicas[500]);
        //musicasPreferidasEmily.AdicionarMusicasFavoritas(musicas[637]);
        //musicasPreferidasEmily.AdicionarMusicasFavoritas(musicas[428]);
        //musicasPreferidasEmily.AdicionarMusicasFavoritas(musicas[13]);
        //musicasPreferidasEmily.AdicionarMusicasFavoritas(musicas[71]);
        //musicasPreferidasEmily.ExibirMusicasFavoritas();

        //musicasPreferidasEmily.CriarArquivoJson();
    }
    //exceção
    catch (Exception ex)
    {
        Console.WriteLine("Erro ao acessar a API: " + ex.Message);
    }
}