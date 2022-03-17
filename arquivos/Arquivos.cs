using System;
using System.IO;
using linkedlist;
using excecoes;

namespace arquivos
{
	// Classe que manipula arquivos no programa
	public static class Arquivos
    {
        // Método que recebe um diretório como argumento e obtém todos os arquivos
        // contidos nesse diretório e em seus subdiretórios de maneira recursiva
        public static LinkedList<string> ObtemArquivos(string diretorio)
		{
            LinkedList<string> listaDeArquivos = new LinkedList<string>();
            try
            {
				string[] subDiretorios = Directory.GetDirectories(diretorio);    	// Obtém os subdiretórios do diretório atual
				try
				{
					string[] arquivos = Directory.GetFiles(diretorio);           	// Obtém os arquivos do diretório atual 

					if (subDiretorios != null)										// Se existem subdiretórios
					{
						// Laço que percorre o vetor de subdiretórios e obtém todos os arquivos desses subdiretórios
						// Cada passo do loop executa o metodo ObtemArquivos com o subdiretorio como argumento e retorna uma lista
						// com os arquivos nesse subdiretorio
						for (int i = 0; i < subDiretorios.Length; i++)
							listaDeArquivos.AddList(ObtemArquivos(subDiretorios[i]));	// Cada chamada retorna uma lista de arquivos que será concatenada a lista anterior
						
						listaDeArquivos.AddList(List.ConvertToList(arquivos));          // Converte o vetor de arquivos numa lista e adiciona à lista já existente de arquivos
					}
					else
					{
						listaDeArquivos = List.ConvertToList(arquivos);          	// Converte o vetor de arquivos numa lista de arquivos
					}
					return listaDeArquivos;                                   		// Retorna a lista
				}
				catch (UnauthorizedAccessException e)
				{ }
				catch (IOException exc)                                   			// Exceção causada por nome de diretório muito longo
				{
					throw new ExcecaoDeArquivo();
				}
            }
            catch (UnauthorizedAccessException excGetDir)                         	// Exceção de acesso restrito a um diretório
            {
                try
                {
                    string[] arquivos = Directory.GetFiles(diretorio);             	// Obtém os arquivos do diretório atual
                    listaDeArquivos = List.ConvertToList(arquivos);             	// Converte o vetor de arquivos numa lista de arquivos
                }
                catch (UnauthorizedAccessException excGetFiles)                   	// Exceção causada por erro na tentativa de acessar um arquivo
                { }
            }
            catch (IOException exc)                                               	// Exceção causada por nome de diretório muito longo
            {
                throw new ExcecaoDeArquivo();
            }
            return listaDeArquivos;
        }
	
		// Método que recebe um arquivo a ser procurado e a lista de caminhos de arquivos
        public static LinkedList<string> BuscaArquivos(string arquivoProcurado, LinkedList<string> lista)
        {
            string caminhoDoArquivo;
            LinkedList<string> arquivos = null;
			
			if(lista.Length() > 0)
			{
				arquivos = new LinkedList<string>();
				for(int i = 0; i < lista.Length(); i++)                   	// Laço que percorre toda a lista em busca da ocorrencia no nome de arquivo procurado
				{
					caminhoDoArquivo = lista.GetItemIn(i);
					if (caminhoDoArquivo.Contains(arquivoProcurado))      	// Cada caminho que contém o arquivo procurado é inserido na lista
						arquivos.Add(caminhoDoArquivo);
				}
			}
			return arquivos;                                              	// Retorna a lista com os caminhos que contém o arquivo
        }
	}
}