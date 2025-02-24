using System;

namespace Trade_GP.Models
{
    public class NfeCabTrade    
    {
        public int Id_Grupo { get; set; }
        public int Id { get; set; }
        public string Arquivo { get; set; }
        public double Qtd { get; set; }
        public double Vlr_Contabil { get; set; }
        public double Bas_Icms { get; set; }
        public double Vlr_Icms { get; set; }
        public double Bas_Pis { get; set; }
        public double Vlr_Pis { get; set; }
        public double Bas_Cof { get; set; }
        public double Vlr_Cof { get; set; }
        public double Bas_Ipi { get; set; }
        public double Vlr_Ipi { get; set; }
        public double Bas_Icms_st { get; set; }
        public double Vlr_Icms_st { get; set; }
        public int NroLinha { get; set; }
        public int UsuarioInclusao { get; set; }
        public int UsuarioAtualizacao { get; set; }
        public  DateTime DataCriacao { get; set; }
        public Nullable<DateTime> DataFechamento { get; set; }
        public int Status { get; set; }
        public string  Layout { get; set; }
        public string  resumo_5405 { get; set; }

        public NfeCabTrade(int id_Grupo, int id, string arquivo, double qtd, double vlr_Contabil, double bas_Icms, double vlr_Icms, double bas_Pis, double vlr_Pis, double bas_Cof, double vlr_Cof, double bas_Ipi, double vlr_Ipi, double bas_Icms_st, double vlr_Icms_st, int nroLinha, int usuarioInclusao, int usuarioAtualizacao, DateTime dataCriacao, DateTime? dataFechamento, int status, string layout, string resumo_5405)
        {
            Id_Grupo = id_Grupo;
            Id = id;
            Arquivo = arquivo;
            Qtd = qtd;
            Vlr_Contabil = vlr_Contabil;
            Bas_Icms = bas_Icms;
            Vlr_Icms = vlr_Icms;
            Bas_Pis = bas_Pis;
            Vlr_Pis = vlr_Pis;
            Bas_Cof = bas_Cof;
            Vlr_Cof = vlr_Cof;
            Bas_Ipi = bas_Ipi;
            Vlr_Ipi = vlr_Ipi;
            Bas_Icms_st = bas_Icms_st;
            Vlr_Icms_st = vlr_Icms_st;
            NroLinha = nroLinha;
            UsuarioInclusao = usuarioInclusao;
            UsuarioAtualizacao = usuarioAtualizacao;
            DataCriacao = dataCriacao;
            DataFechamento = dataFechamento;
            Status = status;
            Layout = layout;
            resumo_5405 = resumo_5405;
        }

        public NfeCabTrade()
        {
            Zerar();
        }
      
        public void Zerar()
        {
            Id_Grupo = 1;
            Id = 0;
            Arquivo = "";
            Qtd = 0;
            Vlr_Contabil = 0;
            Bas_Icms = 0;
            Vlr_Icms = 0;
            Bas_Pis = 0;
            Vlr_Pis = 0;
            Bas_Cof = 0;
            Vlr_Cof = 0;
            Bas_Ipi = 0;
            Vlr_Ipi = 0;
            Bas_Icms_st = 0;
            Vlr_Icms_st = 0;
            NroLinha = 0;
            UsuarioInclusao = 0;
            UsuarioAtualizacao = 0;
            DataCriacao =  DateTime.Now;
            DataFechamento = null;
            Status = 0;
            Layout = "S";
            /*
               0=>Em Aberto
               1=>Encerrado Com Sucesso
            */
            resumo_5405 = "N";
    }
    }
}
