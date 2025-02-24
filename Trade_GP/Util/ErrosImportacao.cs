namespace Trade_GP.Util
{
    public class ErrosImportacao
    {
        public string Flag { get; set; }
        public string  Planilha { get; set; }
        public string  Linha    { get; set; }
        public string  Campo { get; set; }
        public string  ValorCampo { get; set; }
        public int     TamanhoMax { get; set; }
        public string  Obs { get; set; }

        public ErrosImportacao(string flag, string planilha, string linha, string campo, string valorCampo, int tamanhoMax, string obs)
        {
            Flag = flag;
            Planilha = planilha;
            Linha = linha;
            Campo = campo;
            ValorCampo = valorCampo;
            TamanhoMax = tamanhoMax;
            Obs = obs;
        }
    }
}
