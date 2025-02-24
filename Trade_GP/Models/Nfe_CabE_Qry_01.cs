using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade_GP.Models
{
    public class Nfe_CabE_Qry_01
    {
        public int Id_Grupo { get; set; }
        public int Id { get; set; }
        public string Planilha { get; set; }
        public double Qtd { get; set; }
        public double Vlr_Contabil { get; set; }
        public double Bas_Icms { get; set; }
        public double Vlr_Icms { get; set; }
        public double Bas_Pis { get; set; }
        public double Vlr_Pis { get; set; }
        public double Bas_Cof { get; set; }
        public double Vlr_Cof { get; set; }
        public int Nro_Linha { get; set; }
        public int UsuarioInclusao { get; set; }
        public int UsuarioAtualizacao { get; set; }
        public DateTime? Data_Criacao { get; set; }
        public DateTime? Data_Fechamento { get; set; }
        public int Status { get; set; }
        public Nfe_CabE_Qry_01()
        {
            Zerar();
        }
        public Nfe_CabE_Qry_01(int id_Grupo, int id, string planilha, double qtd, double vlr_Contabil, double bas_Icms, double vlr_Icms, double bas_Pis, double vlr_Pis, double bas_Cof, double vlr_Cof, int nro_Linha, int usuarioInclusao, int usuarioAtualizacao, DateTime? data_Criacao, DateTime? data_Fechamento, int status)
        {
            Id_Grupo = id_Grupo;
            Id = id;
            Planilha = planilha;
            Qtd = qtd;
            Vlr_Contabil = vlr_Contabil;
            Bas_Icms = bas_Icms;
            Vlr_Icms = vlr_Icms;
            Bas_Pis = bas_Pis;
            Vlr_Pis = vlr_Pis;
            Bas_Cof = bas_Cof;
            Vlr_Cof = vlr_Cof;
            Nro_Linha = nro_Linha;
            UsuarioInclusao = usuarioInclusao;
            UsuarioAtualizacao = usuarioAtualizacao;
            Data_Criacao = data_Criacao;
            Data_Fechamento = data_Fechamento;
            Status = status;
        }
        private void Zerar()
        {
            Id_Grupo = 0;
            Id = 0;
            Planilha = "";
            Qtd = 0;
            Vlr_Contabil = 0;
            Bas_Icms = 0;
            Vlr_Icms = 0;
            Bas_Pis = 0;
            Vlr_Pis = 0;
            Bas_Cof = 0;
            Vlr_Cof = 0;
            Nro_Linha = 0;
            UsuarioInclusao = 0;
            UsuarioAtualizacao = 0;
            Data_Criacao = null;
            Data_Fechamento = null;
            Status = 0;
        }
    }
}
