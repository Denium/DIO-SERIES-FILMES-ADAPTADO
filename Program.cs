using System;

namespace DIO.Series
{
  class Program
  {
    static SerieRepository repositorio = new SerieRepository();
    static FilmeRepository repositoryFilme = new FilmeRepository();
    static void Main(string[] args)
    {
      string opcaoUsuario = "";
      while (opcaoUsuario.ToUpper() != "X")
      {
        Console.WriteLine("Digite 1 para assistir Filmes ou digite 2 para assistir séries.");
        Console.WriteLine("1- Filmes.");
        Console.WriteLine("2- Séries.");
        int Escolha = int.Parse(Console.ReadLine());

        opcaoUsuario = ObterOpcaoUsuario(Escolha);

        if (Escolha == 1)
        {
          opcaoUsuario = EscolhaMenuFilmes(Escolha, opcaoUsuario);
        }
        else if (Escolha == 2)
        {
          opcaoUsuario = EscolhaMenuSeries(Escolha, opcaoUsuario);
        }
        else
        {
          throw new Exception("A opção escolhida está incorreta, tente novamente!.");
        }

        if (opcaoUsuario == "X")
        {
          Console.WriteLine("Obrigado por utilizar nossos serviços.");
          Console.ReadLine();
        }
      }
    }

    private static string EscolhaMenuSeries(int Escolha, string opcaoUsuario)
    {
      while (opcaoUsuario.ToUpper() != "X")
      {
        switch (opcaoUsuario)
        {
          case "1":
            ListarSeries();
            break;
          case "2":
            InserirSerie();
            break;
          case "3":
            AtualizarSerie();
            break;
          case "4":
            ExcluirSerie();
            break;
          case "5":
            VisualizarSerie();
            break;
          case "B":
            return opcaoUsuario;
          case "C":
            Console.Clear();
            break;

          default:
            throw new ArgumentOutOfRangeException();
        }

        opcaoUsuario = ObterOpcaoUsuario(Escolha);
      }

      return opcaoUsuario;
    }

    private static string EscolhaMenuFilmes(int Escolha, string opcaoUsuario)
    {
      while (opcaoUsuario.ToUpper() != "X")
      {
        switch (opcaoUsuario)
        {
          case "1":
            ListarFilmes();
            break;
          case "2":
            InserirFilme();
            break;
          case "3":
            AtualizarFilme();
            break;
          case "4":
            ExcluirFilme();
            break;
          case "5":
            VisualizarFilme();
            break;
          case "B":
            return opcaoUsuario;
          case "C":
            Console.Clear();
            break;

          default:
            throw new ArgumentOutOfRangeException();
        }

        opcaoUsuario = ObterOpcaoUsuario(Escolha);
      }

      return opcaoUsuario;
    }

    private static void ExcluirSerie()
    {
      Console.Write("Digite o id da série: ");
      int indiceSerie = int.Parse(Console.ReadLine());

      repositorio.Exclui(indiceSerie);
    }

    private static void ExcluirFilme()
    {
      Console.Write("Digite o id do filme: ");
      int indiceFilme = int.Parse(Console.ReadLine());

      repositoryFilme.Exclui(indiceFilme);
    }

    private static void VisualizarSerie()
    {
      Console.Write("Digite o id da série: ");
      int indiceSerie = int.Parse(Console.ReadLine());

      var serie = repositorio.RetornaPorId(indiceSerie);

      Console.WriteLine(serie);
    }

    private static void VisualizarFilme()
    {
      Console.Write("Digite o id do filme: ");
      int indiceFilme = int.Parse(Console.ReadLine());

      var filme = repositoryFilme.RetornaPorId(indiceFilme);

      Console.WriteLine(filme);
    }

    private static void AtualizarSerie()
    {
      Console.Write("Digite o id da série: ");
      int indiceSerie = int.Parse(Console.ReadLine());

      // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
      // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
      foreach (int i in Enum.GetValues(typeof(Genero)))
      {
        Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
      }
      Console.Write("Digite o gênero entre as opções acima: ");
      int entradaGenero = int.Parse(Console.ReadLine());

      Console.Write("Digite o Título da Série: ");
      string entradaTitulo = Console.ReadLine();

      Console.Write("Digite o Ano de Início da Série: ");
      int entradaAno = int.Parse(Console.ReadLine());

      Console.Write("Digite a Descrição da Série: ");
      string entradaDescricao = Console.ReadLine();

      Serie atualizaSerie = new Serie(id: indiceSerie,
                    genero: (Genero)entradaGenero,
                    titulo: entradaTitulo,
                    ano: entradaAno,
                    descricao: entradaDescricao);

      repositorio.Atualiza(indiceSerie, atualizaSerie);
    }

    private static void AtualizarFilme()
    {
      Console.Write("Digite o id do filme: ");
      int indiceFilme = int.Parse(Console.ReadLine());

      // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
      // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
      foreach (int i in Enum.GetValues(typeof(Genero)))
      {
        Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
      }
      Console.Write("Digite o gênero entre as opções acima: ");
      int entradaGenero = int.Parse(Console.ReadLine());

      Console.Write("Digite o Título do Filme: ");
      string entradaTitulo = Console.ReadLine();

      Console.Write("Digite o Ano de Início do Filme: ");
      int entradaAno = int.Parse(Console.ReadLine());

      Console.Write("Digite a Descrição do Filme: ");
      string entradaDescricao = Console.ReadLine();

      Filme atualizaFilme = new Filme(IdFilme: indiceFilme,
                    genero: (Genero)entradaGenero,
                    titulo: entradaTitulo,
                    ano: entradaAno,
                    descricao: entradaDescricao);

      repositoryFilme.Atualiza(indiceFilme, atualizaFilme);
    }
    private static void ListarSeries()
    {
      Console.WriteLine("Listar séries");

      var lista = repositorio.Lista();

      if (lista.Count == 0)
      {
        Console.WriteLine("Nenhuma série cadastrada.");
        return;
      }

      foreach (var serie in lista)
      {
        var excluido = serie.retornaExcluido();

        Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
      }
    }

    private static void ListarFilmes()
    {
      Console.WriteLine("Listar filmes");

      var lista = repositoryFilme.Lista();

      if (lista.Count == 0)
      {
        Console.WriteLine("Nenhum filme cadastrado.");
        return;
      }

      foreach (var filme in lista)
      {
        var excluido = filme.retornaExcluido();

        Console.WriteLine("#ID {0}: - {1} {2}", filme.retornaId(), filme.retornaTitulo(), (excluido ? "*Excluído*" : ""));
      }
    }

    private static void InserirSerie()
    {
      Console.WriteLine("Inserir nova série");

      // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
      // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
      foreach (int i in Enum.GetValues(typeof(Genero)))
      {
        Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
      }
      Console.Write("Digite o gênero entre as opções acima: ");
      int entradaGenero = int.Parse(Console.ReadLine());

      Console.Write("Digite o Título da Série: ");
      string entradaTitulo = Console.ReadLine();

      Console.Write("Digite o Ano de Início da Série: ");
      int entradaAno = int.Parse(Console.ReadLine());

      Console.Write("Digite a Descrição da Série: ");
      string entradaDescricao = Console.ReadLine();

      Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                    genero: (Genero)entradaGenero,
                    titulo: entradaTitulo,
                    ano: entradaAno,
                    descricao: entradaDescricao);

      repositorio.Insere(novaSerie);
    }

    private static void InserirFilme()
    {
      Console.WriteLine("Inserir novo Filme");

      // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
      // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
      foreach (int i in Enum.GetValues(typeof(Genero)))
      {
        Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
      }
      Console.Write("Digite o gênero entre as opções acima: ");
      int entradaGenero = int.Parse(Console.ReadLine());

      Console.Write("Digite o Título do Filme: ");
      string entradaTitulo = Console.ReadLine();

      Console.Write("Digite o Ano de Início do Filme: ");
      int entradaAno = int.Parse(Console.ReadLine());

      Console.Write("Digite a Descrição do Filme: ");
      string entradaDescricao = Console.ReadLine();

      Filme novoFilme = new Filme(IdFilme: repositoryFilme.ProximoId(),
                    genero: (Genero)entradaGenero,
                    titulo: entradaTitulo,
                    ano: entradaAno,
                    descricao: entradaDescricao);

      repositoryFilme.Insere(novoFilme);
    }

    private static string ObterOpcaoUsuario(int escolha)
    {
      switch (escolha)
      {
        case 1:
          return ObterMenuFilmes();
        case 2:
          return ObterMenuSeries();
        default:
          return "";
      }
    }

    private static string ObterMenuFilmes()
    {
      Console.WriteLine();
      Console.WriteLine("DIO Filmes a seu dispor!!!");
      Console.WriteLine("Informe a opção desejada:");

      Console.WriteLine("1- Listar filmes");
      Console.WriteLine("2- Inserir novo filme");
      Console.WriteLine("3- Atualizar filme");
      Console.WriteLine("4- Excluir filme");
      Console.WriteLine("5- Visualizar filme");
      Console.WriteLine("C- Limpar Tela");
      Console.WriteLine("B- Voltar");
      Console.WriteLine("X- Sair");
      Console.WriteLine();
      string opcaoUsuario1 = Console.ReadLine().ToUpper();
      Console.WriteLine();
      return opcaoUsuario1;
    }

    private static string ObterMenuSeries()
    {
      Console.WriteLine();
      Console.WriteLine("DIO Séries a seu dispor!!!");
      Console.WriteLine("Informe a opção desejada:");

      Console.WriteLine("1- Listar séries");
      Console.WriteLine("2- Inserir nova série");
      Console.WriteLine("3- Atualizar série");
      Console.WriteLine("4- Excluir série");
      Console.WriteLine("5- Visualizar série");
      Console.WriteLine("C- Limpar Tela");
      Console.WriteLine("B- Voltar");
      Console.WriteLine("X- Sair");
      Console.WriteLine();
      string opcaoUsuario2 = Console.ReadLine().ToUpper();
      Console.WriteLine();
      return opcaoUsuario2;
    }
  }
}
