using System;
using System.IO;
using linkedlist;

namespace search
{
    class Program
    {
        static void Main(string[] args)
        {
			LinkedList<string> arquivosEncontrados = null;	// Cria uma lista para os arquivos encontrados
            LinkedList<string> listaDeArquivos = null;    	// Cria uma lista para todos os arquivos no diretorio e subdiretorios
			
            Console.WriteLine("Search versão 1.0");
			Console.WriteLine("Uso:\nsearch <arquivo>");
				
            Console.WriteLine();
			
			string diretorioAtual = Directory.GetCurrentDirectory();		// Obtem o diretorio atual
			if (args.Length == 1)											// Verifica se existe arquivo a ser procurado
			{
				Console.WriteLine("Arquivo procurado: {0}", args[0]);
				Console.WriteLine("Carregando arquivos...");
				
			}
			else
				Console.WriteLine("Nenhum arquivo a ser procurado.");
        }
    }
}
