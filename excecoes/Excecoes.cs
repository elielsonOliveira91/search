using System;

namespace excecoes
{

    class ExcecaoDeArquivo : Exception
    {
        public string Mensagem;

        public ExcecaoDeArquivo()
        {
            Mensagem = "[Erro] O nome de diretório pasado como argumento não é um caminho válido ou é longo demais ...";
        }
    }   
}
