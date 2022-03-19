using System;
using System.IO;
using linkedlist;
using arquivos;
using excecoes;

namespace search
{
    class Program
    {
        static void Main(string[] args)
        {
			bool flag = true;								// Valor booleano que indica se a busca por um arquivo será feita em subdiretorios
			string diretorio;								// Indica o diretorio alvo da busca
			string arquivo;									// Arquivo a ser procurado
			LinkedList<string> listaDeArquivos = null;    	// Cria uma lista para todos os arquivos obtidos no diretorio e subdiretorios
			LinkedList<string> arquivosEncontrados = null;	// Cria uma lista para os arquivos que forem encontrados na busca
			
            Console.WriteLine("Search versão 2.0.0");
			Console.WriteLine("Uso: search [opçao] [local] [arquivo]");
			Console.WriteLine("Opçao: \n" +
								"  -ns		Diz ao programa para procurar arquivo somente no diretorio corrente nao em seus subdiretorios.");
				
            Console.WriteLine();
			if (args.Length > 1 && args.Length < 4)
			{
				// A opçao -ns diz ao programa para fazer busca somente no diretorio e nao nos subdiretorios
				if(args[0] == "-ns")
				{
					flag = false;							// Flag false indica que a busca nao sera feita em subdiretorios
					diretorio = args[1];
					arquivo = args[2];
					Console.WriteLine("Diretorio: {0}", diretorio);
					Console.WriteLine("Arquivo procurado: {0}", arquivo);
					Console.WriteLine("* Sem busca em subdiretorios...");
				}
				else if(args.Length == 2)
				{
					diretorio = args[0];
					arquivo = args[1];
					Console.WriteLine("Diretorio: {0}", diretorio);
					Console.WriteLine("Arquivo procurado: {0}", arquivo);
				}
				else
				{
					Console.WriteLine("Opçao invalida.");
					return;
				}
				
				try{
					Console.WriteLine("Carregando arquivos...");
					listaDeArquivos = Arquivos.ObtemArquivos(diretorio, flag);				// Obtém todos os arquivos no diretório
					
					Console.WriteLine("Procurando...");
					arquivosEncontrados = Arquivos.BuscaArquivos(arquivo, listaDeArquivos);	// Procura pelo arquivo na lista de arquivos
					Console.WriteLine();
					for (int i = 0; i < arquivosEncontrados.Length(); i++)					// Laço que percorre a lista de arquivos encontrados
					{
						Console.WriteLine(arquivosEncontrados.GetItemIn(i));            	// Exibe todos os caminhos (path) onde o arquivo foi encontrado
					}
					
					Console.WriteLine();
					Console.WriteLine("Total de arquivos encontrados: {0}", arquivosEncontrados.Length());
					Console.WriteLine("Total de arquivos verificados: {0}", listaDeArquivos.Length());
				}
				catch(ExcecaoDeDiretorio e)
				{
					Console.WriteLine();
					Console.WriteLine(e.Mensagem);
				}
				catch(ExcecaoDeArquivo e)
				{
					Console.WriteLine();
					Console.WriteLine(e.Mensagem);
				}
				catch(ExcecaoDeAcesso e)
				{
					Console.WriteLine();
					Console.WriteLine(e.Mensagem);
				}
			}
			else
				Console.WriteLine("Numero de argumentos invalido.");
        }
    }
}
