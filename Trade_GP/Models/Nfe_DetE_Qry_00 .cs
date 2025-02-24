using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade_GP.Models
{
	public class Nfe_DetE_Qry_00
	{
		public string Planilha { get; set; }
		public string Empresa { get; set; }
		public string Cnpj_Cpf { get; set; }
		public int Id_Grupo { get; set; }
		public int Id { get; set; }
		public string Operacao { get; set; }
		public int Nro_Linha { get; set; }
		public string Cod_Empresa { get; set; }
		public string Local { get; set; }
		public string Id_Planilha { get; set; }
		public Nullable<DateTime> Dtlanc { get; set; }
		public Nullable<DateTime> Dtnf { get; set; }
		public string Nro { get; set; }
		public string Serie { get; set; }
		public string Uf { get; set; }
		public string Nr_Item { get; set; }
		public string Material { get; set; }
		public string Descricao { get; set; }
		public string Ncm { get; set; }
		public string Unid { get; set; }
		public string Cfop { get; set; }
		public string Cfop_Texto { get; set; }
		public double Qtd { get; set; }
		public double Vlr_Contabil { get; set; }
		public double Vlr_Unit { get; set; }
		public string Sti { get; set; }
		public double Bas_Icms { get; set; }
		public double Per_Icms { get; set; }
		public double Vlr_Icms { get; set; }
		public string Stp { get; set; }
		public double Bas_Pis { get; set; }
		public double Per_Pis { get; set; }
		public double Vlr_Pis { get; set; }
		public string Stc { get; set; }
		public double Bas_Cof { get; set; }
		public double Per_Cof { get; set; }
		public double Vlr_Cof { get; set; }
		public string Stip { get; set; }
		public double Bas_Ipi { get; set; }
		public double Per_Ipi { get; set; }
		public double Vlr_Ipi { get; set; }
		public string Cnpj_Destinatario { get; set; }
		public string Chave { get; set; }
		public string Nome { get; set; }
		public double Saldo { get; set; }
		public double Sobra { get; set; }
		public string Status { get; set; }

        public Nfe_DetE_Qry_00()
        {
            Zerar();
        }

        public Nfe_DetE_Qry_00(string planilha, string empresa, string cnpj_Cpf, int id_Grupo, int id, string operacao, int nro_Linha, string cod_Empresa, string local, string id_Planilha, DateTime? dtlanc, DateTime? dtnf, string nro, string serie, string uf, string nr_Item, string material, string descricao, string ncm, string unid, string cfop, string cfop_Texto, double qtd, double vlr_Contabil, double vlr_Unit, string sti, double bas_Icms, double per_Icms, double vlr_Icms, string stp, double bas_Pis, double per_Pis, double vlr_Pis, string stc, double bas_Cof, double per_Cof, double vlr_Cof, string stip, double bas_Ipi, double per_Ipi, double vlr_Ipi, double bas_Icms_St, double per_Icms_St, double vlr_Icms_St, string cnpj_Destinatario, string chave, string nome, double saldo, double sobra, string status)
        {
            Planilha = planilha;
            Empresa = empresa;
            Cnpj_Cpf = cnpj_Cpf;
            Id_Grupo = id_Grupo;
            Id = id;
            Operacao = operacao;
            Nro_Linha = nro_Linha;
            Cod_Empresa = cod_Empresa;
            Local = local;
            Id_Planilha = id_Planilha;
            Dtlanc = dtlanc;
            Dtnf = dtnf;
            Nro = nro;
            Serie = serie;
            Uf = uf;
            Nr_Item = nr_Item;
            Material = material;
            Descricao = descricao;
            Ncm = ncm;
            Unid = unid;
            Cfop = cfop;
            Cfop_Texto = cfop_Texto;
            Qtd = qtd;
            Vlr_Contabil = vlr_Contabil;
            Vlr_Unit = vlr_Unit;
            Sti = sti;
            Bas_Icms = bas_Icms;
            Per_Icms = per_Icms;
            Vlr_Icms = vlr_Icms;
            Stp = stp;
            Bas_Pis = bas_Pis;
            Per_Pis = per_Pis;
            Vlr_Pis = vlr_Pis;
            Stc = stc;
            Bas_Cof = bas_Cof;
            Per_Cof = per_Cof;
            Vlr_Cof = vlr_Cof;
            Stip = stip;
            Bas_Ipi = bas_Ipi;
            Per_Ipi = per_Ipi;
            Vlr_Ipi = vlr_Ipi;
            Cnpj_Destinatario = cnpj_Destinatario;
            Chave = chave;
            Nome = nome;
            Saldo = saldo;
            Sobra = sobra;
            Status = status;
        }

        private void Zerar()
        {
            Planilha = "";
            Empresa = "";
            Cnpj_Cpf = "";
            Id_Grupo = 0;
            Id = 0;
            Operacao = "";
            Nro_Linha = 0;
            Cod_Empresa = "";
            Local = "";
            Id_Planilha = "";
            Dtlanc = null;
            Dtnf = null;
            Nro = "";
            Serie = "";
            Uf = "";
            Nr_Item = "";
            Material = "";
            Descricao = "";
            Ncm = "";
            Unid = "";
            Cfop = "";
            Cfop_Texto = "";
            Qtd = 0;
            Vlr_Contabil = 0;
            Vlr_Unit = 0;
            Sti = "";
            Bas_Icms = 0;
            Per_Icms = 0;
            Vlr_Icms = 0;
            Stp = "";
            Bas_Pis = 0;
            Per_Pis = 0;
            Vlr_Pis = 0;
            Stc = "";
            Bas_Cof = 0;
            Per_Cof = 0;
            Vlr_Cof = 0;
            Stip = "";
            Bas_Ipi = 0;
            Per_Ipi = 0;
            Vlr_Ipi = 0;
            Cnpj_Destinatario = "";
            Chave = "";
            Nome = "";
            Saldo = 0;
            Sobra = 0;
            Status = "";
        }
    }

}
