using System;

namespace Trade_GP.Util
{
    class ExceptionErroImportacao :  Exception
    {
        public ErrosImportacao Erros { get; set; }

        public ExceptionErroImportacao(
            string flag,
            string planilha,
            string linha,
            string campo,
            string valorCampo, 
            int tamanhoMax, 
            string obs)
        {
            Erros = new ErrosImportacao(flag,planilha, linha, campo, valorCampo, tamanhoMax, obs);
        }
    }
}
