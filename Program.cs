﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
   
		internal class Program
		{
			static SerieRepositorio repositorio = new SerieRepositorio();
			static void Main(string[] args)
			{
				Console.WriteLine("DIO Séries a seu dispor!!!");

				string opcaoUsuario = ObterOpcaoUsuario();

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

						default:
							Console.Clear();
							Console.WriteLine("Insira uma opção valida");

							break;
					}

					opcaoUsuario = ObterOpcaoUsuario();
				}

				Console.WriteLine("Obrigado por utilizar nossos serviços.");
				Console.ReadLine();
			}

			private static void ExcluirSerie()
			{
				Console.Clear();
				Console.Write("Digite o id da série: ");
				int indiceSerie = int.Parse(Console.ReadLine());

				repositorio.Exclui(indiceSerie);
			}

			private static void VisualizarSerie()
			{
				Console.Clear();
				Console.Write("Digite o id da série: ");
				int indiceSerie = int.Parse(Console.ReadLine());

				var serie = repositorio.RetornaPorId(indiceSerie);

				Console.WriteLine(serie);
			}

			private static void AtualizarSerie()
			{
				Console.Clear();
				Console.Write("Digite o id da série: ");
				int indiceSerie = int.Parse(Console.ReadLine());

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
			private static void ListarSeries()
			{
				Console.Clear();
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

			private static void InserirSerie()
			{

				Console.Clear();
				Console.WriteLine("Inserir nova série");

				foreach (int i in Enum.GetValues(typeof(Genero)))
				{
					Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
				}

				Console.Write("Digite o gênero entre as opções acima: ");
				int entradaGenero = int.Parse(Console.ReadLine());

				Console.Clear();
				Console.Write("Digite o Título da Série: ");
				string entradaTitulo = Console.ReadLine();

				Console.Clear();
				Console.Write("Digite o Ano de Início da Série: ");
				int entradaAno = int.Parse(Console.ReadLine());

				Console.Clear();
				Console.Write("Digite a Descrição da Série: ");
				string entradaDescricao = Console.ReadLine();
				Console.WriteLine();
				Console.WriteLine("Cadastro Completo!");

				Serie novaSerie = new Serie(id: repositorio.ProximoId(),
											genero: (Genero)entradaGenero,
											titulo: entradaTitulo,
											ano: entradaAno,
											descricao: entradaDescricao);

				repositorio.Insere(novaSerie);
			}

			private static string ObterOpcaoUsuario()
			{
				Console.WriteLine("Pressione Enter");
				Console.ReadLine();
				Console.Clear();
				Console.WriteLine();
				Console.WriteLine("Informe a opção desejada:");

				Console.WriteLine("1- Listar séries");
				Console.WriteLine("2- Inserir nova série");
				Console.WriteLine("3- Atualizar série");
				Console.WriteLine("4- Excluir série");
				Console.WriteLine("5- Visualizar série");
				Console.WriteLine("X- Sair");
				Console.WriteLine();

				string opcaoUsuario = Console.ReadLine().ToUpper();
				Console.WriteLine();
				return opcaoUsuario;
			}
		}
}

