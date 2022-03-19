using System;

namespace excecoes
{

    class ExcecaoDeArquivo : Exception
    {
        public string Mensagem;

        public ExcecaoDeArquivo()
        {
            Mensagem = "[Erro] Erro de arquivo ...";
        }
    } 
	
	class ExcecaoDeDiretorio : Exception
    {
        public string Mensagem;

        public ExcecaoDeDiretorio()
        {
            Mensagem = "O nome de diretório pasado como argumento não existe ...";
        }
    }   
}
