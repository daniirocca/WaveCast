using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace ScreenSound_04.Modelos;

internal class MusicasPreferidas 
{
    public string? Nome { get; set; } //propriedades começam com letra maiúscula
    public List<Musica> ListaDeMusicasFavoritas { get; }
    public MusicasPreferidas(string nome)
    {
        Nome = nome;
        ListaDeMusicasFavoritas = new List<Musica>();
    }
    //método adicionar músicas favoritas
    public void AdicionarMusicasFavoritas(Musica musica)
    {
        ListaDeMusicasFavoritas.Add(musica);
    }
    //método para exibir as músicas
    public void ExibirMusicasFavoritas()
    {
        Console.WriteLine($"Exibindo as músicas favoritas de {Nome}");
        foreach (var musica in ListaDeMusicasFavoritas)
        {
            Console.WriteLine($"- {musica.Nome} de {musica.Artista}");
        }
        Console.WriteLine();
    }
    //método para criar arquivo Json - serialização
    public void CriarArquivoJson()
    {
        string json = JsonSerializer.Serialize(new 
        { 
            Nome, ListaDeMusicasFavoritas //objeto anônimo - estrutura temporaria
        });
        string nomeDoArquivo = $"musicas-favoritas-{Nome}.json";

        File.WriteAllText(nomeDoArquivo, json); //método estático do método chamado File
        Console.WriteLine($"Json criado com sucesso! {Path.GetFullPath(nomeDoArquivo)}");

        //para ver as músicas favoritas: https://screen-sound.vercel.app/
    }
}

//depois de criarmos a classe, iremos instanciar ela no Program.cs
