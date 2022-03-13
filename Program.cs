using System;
using System.IO;
using linkedlist;
using arquivos;

namespace search
{
    class Program
    {
        static void Main(string[] args)
        {
			LinkedList<string> arquivosEncontrados = null;	// Cria uma lista para os arquivos encontrados
            LinkedList<string> listaDeArquivos = null;    	// Cria uma lista para todos os arquivos no diretorio e subdiretorios
			
            Console.WriteLine("Search versão 1.0.0");
			Console.WriteLine("Uso:\nsearch <arquivo>");
				
            Console.WriteLine();
			if (args.Length == 1)															// Verifica se existe arquivo a ser procurado
			{
				Console.WriteLine("Arquivo procurado: {0}", args[0]);
				
				Console.WriteLine("Carregando arquivos...");
				listaDeArquivos = Arquivos.ObtemArquivos(Directory.GetCurrentDirectory());	// Obtém todos os arquivos no diretório atual
				
				Console.WriteLine("Procurando...");
				arquivosEncontrados = Arquivos.BuscaArquivos(args[0], listaDeArquivos);     // Procura pelos arquivo na lista de arquivos
				
				Console.WriteLine();
				for (int i = 0; i < arquivosEncontrados.Length(); i++)
				{
					Console.WriteLine(arquivosEncontrados.GetItemIn(i));                   	// Exibe todos os caminhos (path) onde o arquivo foi encontrado
				}
				
				Console.WriteLine();
				Console.WriteLine("Total de arquivos encontrados: {0}", arquivosEncontrados.Length());
			}
			else
				Console.WriteLine("Nenhum arquivo a ser procurado.");
        }
    }
}
