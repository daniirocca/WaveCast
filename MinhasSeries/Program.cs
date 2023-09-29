//My series

string mensagemDeBoasVindas = "Boas Vindas ao My Series";
//Vamos criar uma matriz para nossas series
Dictionary<string, List<int>> seriesRegistradas = new Dictionary<string, List<int>>();
seriesRegistradas.Add("Breaking Bad", new List<int> { 10 });
seriesRegistradas.Add("One Piece", new List<int> ());

void ExibirLogo()
{
    Console.WriteLine(@"

███╗░░░███╗██╗░░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░░██████╗
████╗░████║╚██╗░██╔╝  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗██╔════╝
██╔████╔██║░╚████╔╝░  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║╚█████╗░
██║╚██╔╝██║░░╚██╔╝░░  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║░╚═══██╗
██║░╚═╝░██║░░░██║░░░  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝██████╔╝
╚═╝░░░░░╚═╝░░░╚═╝░░░  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░╚═════╝░

");
    Console.WriteLine(mensagemDeBoasVindas);
}

void ExibirTituloDaOpcao(string titulo)
{
    int quantidadeDeCaracteres = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeCaracteres, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma série");
    Console.WriteLine("Digite 2 para exibir as séries cadastradas");
    Console.WriteLine("Digite 3 para avaliar uma série cadastrada");
    Console.WriteLine("Digite 4 para exibir a média da avaliação de uma série");
    Console.WriteLine("Digite -1 para sair");
    Console.Write("\nDigite sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaNumerica)
    {
        case 1:
            RegistrarSerie();
            break;
        case 2:
            MostrarSeriesRegistradas();
            break;
        case 3:
            AvaliarUmaSerie();
            break;
        case 4:
            ExibirMediaDaSerie();
            break;
        case -1:
            Console.WriteLine("Até a próxima :) !");
            break;
        default:
            Console.WriteLine("A opção não é válida");
            break;
    }

}

void RegistrarSerie()
{
    Console.Clear();
    ExibirTituloDaOpcao("Registro das séries");
    Console.Write("Digite i nome da série que deseja registrar: ");
    string nomeDaSerie = Console.ReadLine()!;
    seriesRegistradas.Add(nomeDaSerie, new List<int>());
    Console.WriteLine($"A série {nomeDaSerie} foi registrada com sucesso!");
    Thread.Sleep(2000);
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void MostrarSeriesRegistradas()
{
    Console.Clear();
    ExibirTituloDaOpcao ("Exibindo todas as séries registradas");
    foreach (string serie in seriesRegistradas.Keys)
    {
        Console.WriteLine($"Série: {serie}");
    }
    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void AvaliarUmaSerie()
{
    Console.Clear();
    ExibirTituloDaOpcao("Avaliar uma série");
    Console.Write("Digite o nome da série que deseja avaliar: ");
    string nomeDaSerie = Console.ReadLine()!;
    if (seriesRegistradas.ContainsKey(nomeDaSerie))
    {
        Console.Write($"Digite uma nota para a série {nomeDaSerie}: ");
        int nota = int.Parse(Console.ReadLine()!);
        seriesRegistradas[nomeDaSerie].Add(nota);
        Console.WriteLine($"A nota {nota} foi registradada com sucesso para a série {nomeDaSerie}.");
        Thread.Sleep(4000);
        Console.Clear();
    }
    else
    {
        Console.WriteLine($"\nA série {nomeDaSerie} não foi encontrada!");
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }

}

void ExibirMediaDaSerie()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibir média da série");
    Console.Write("Digite o nome da série que deseja exibir a média de avaliação: ");
    string nomeDaSerie = Console.ReadLine()!;
    if (seriesRegistradas.ContainsKey(nomeDaSerie))
    {
        List<int> notasDaSerie = seriesRegistradas[nomeDaSerie];
        Console.WriteLine($"\nA média da série {nomeDaSerie} é {notasDaSerie.Average()}.");
        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
    else
    {
        Console.WriteLine($"\nA série {nomeDaSerie} não foi encontrada!");
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}
ExibirOpcoesDoMenu();