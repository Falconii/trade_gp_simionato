using System;

namespace Trade_GP.Util
{
    public class FiltroNfDetE
    {
        public int Id_Grupo { get; set; }
        public int Id { get; set; }
        public string Planilha { get; set; }
        public string Empresa { get; set; }
        public string Nro { get; set; }
        public string Serie { get; set; }
        public string Material { get; set; }
        public string Cfop  { get; set; }
        public DateTime? Dtnf { get; set; }
        public DateTime? Dtlanc  { get; set; }
        public DateTime? DataInicial { get; set; }
        public DateTime? DataFinal { get; set; }
        public string Operacao { get; set; }
        public string  Status { get; set; }
        public FiltroNfDetE()
        {
            Zerar();
        }

        public FiltroNfDetE(int id_Grupo, int id, string planilha, string empresa, string nro, string serie, string material, string cfop, DateTime? dtnf, DateTime? dtlanc, DateTime? dataInicial, DateTime? dataFinal, string operacao, string status)
        {
            Id_Grupo = id_Grupo;
            Id = id;
            Planilha = planilha;
            Empresa = empresa;
            Nro = nro;
            Serie = serie;
            Material = material;
            Cfop = cfop;
            Dtnf = dtnf;
            Dtlanc = dtlanc;
            DataInicial = dataInicial;
            DataFinal = dataFinal;
            Operacao = operacao;
            Status = status;
        }

        public void Zerar()
        {
            this.Id_Grupo = 0;
            this.Id = 0;
            this.Nro = "";
            this.Planilha = "";
            this.Empresa = "";
            this.Serie = "";
            this.Material = "";
            this.Cfop = "";
            this.Dtnf = null;
            this.Dtlanc = null;
            this.DataInicial = null;
            this.DataFinal = null;
            this.Operacao = "";
            this.Status = "";
        }
    }
}
