using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade_GP.Models
{
	public class Nfe_DetE_Qry_01
	{   public int Id_Fechamento { get; set; }
        public string Desc_Fechamento { get; set; }
        public string Ven_Empresa { get; set; }
		public int Ven_Ano { get; set; }
		public int Ven_Id { get; set; }
		public int Ven_Nro_Linha { get; set; }
		public string Ven_Chave { get; set; }
		public string Ven_Cod_Empresa { get; set; }
		public string Ven_Local { get; set; }
		public string Ven_Id_Planilha { get; set; }
		public DateTime? Ven_Dtlanc { get; set; }
		public DateTime? Ven_Dtnf { get; set; }
		public string Ven_Nro { get; set; }
		public string Ven_Serie { get; set; }
		public string Ven_Material { get; set; }
		public string Ven_Descricao { get; set; }
		public string Ven_Cfop { get; set; }
		public double Ven_Qtd { get; set; }
		public double Ven_Valor { get; set; }
        public double Ven_Bas_Icms { get; set; }
        public double Ven_Bas_Pis { get; set; }
        public double Ven_Per_Pis { get; set; }
        public double Ven_Vlr_Pis { get; set; }
        public double Ven_Bas_Cof { get; set; }
        public double Ven_Per_Cof { get; set; }
        public double Ven_Vlr_Cof { get; set; }
        public double Ven_Saldo_Venda { get; set; }
		public string Ent_Chave { get; set; }
		public string Ent_Cod_Empresa { get; set; }
		public string Ent_Local { get; set; }
		public string Ent_Id_Planilha { get; set; }
		public DateTime? Ent_Dtlanc { get; set; }
		public DateTime? Ent_Dtnf { get; set; }
		public string Ent_Nro { get; set; }
		public string Ent_Serie { get; set; }
		public string Ent_Operacao { get; set; }
		public string Ent_Material { get; set; }
		public string Ent_Descricao { get; set; }
		public string Ent_Cfop { get; set; }
		public double Ent_Qtd { get; set; }
        public double Ent_Qtd_Remanescente { get; set; }
        public double Ent_Valor { get; set; }
        public double Ent_Bas_Icms { get; set; }
        public double Ent_Saldo { get; set; }
		public double Ent_Qtd_Usada { get; set; }
		public double Calc_P_Unit { get; set; }
		public double Calc_Base_Pis { get; set; }
		public double Calc_Per_Pis { get; set; }
		public double Calc_Vlr_Pis { get; set; }
		public double Calc_Base_Cofins { get; set; }
		public double Calc_Per_Cof { get; set; }
		public double Calc_Vlr_Cofins { get; set; }

        public Nfe_DetE_Qry_01(int id_Groupo, int id_Fechamento, string desc_Fechamento, string ven_Empresa, int ven_Ano, int ven_Id, int ven_Nro_Linha, string ven_Chave, string ven_Cod_Empresa, string ven_Local, string ven_Id_Planilha, DateTime? ven_Dtlanc, DateTime? ven_Dtnf, string ven_Nro, string ven_Serie, string ven_Material, string ven_Descricao, string ven_Cfop, double ven_Qtd, double ven_Valor, double ven_Per_Pis, double ven_Per_Cof, double ven_Saldo_Venda, string ent_Chave, string ent_Cod_Empresa, string ent_Local, string ent_Id_Planilha, DateTime? ent_Dtlanc, DateTime? ent_Dtnf, string ent_Nro, string ent_Serie, string ent_Operacao, string ent_Material, string ent_Descricao, string ent_Cfop, double ent_Qtd, double ent_Valor, double ent_Saldo, double ent_Qtd_Usada, double calc_P_Unit, double calc_Base_Pis, double calc_Per_Pis, double calc_Vlr_Pis, double calc_Base_Cofins, double calc_Per_Cof, double calc_Vlr_Cofins)
        {
            Id_Fechamento = id_Fechamento;
            Desc_Fechamento = desc_Fechamento;
            Ven_Empresa = ven_Empresa;
            Ven_Ano = ven_Ano;
            Ven_Id = ven_Id;
            Ven_Nro_Linha = ven_Nro_Linha;
            Ven_Chave = ven_Chave;
            Ven_Cod_Empresa = ven_Cod_Empresa;
            Ven_Local = ven_Local;
            Ven_Id_Planilha = ven_Id_Planilha;
            Ven_Dtlanc = ven_Dtlanc;
            Ven_Dtnf = ven_Dtnf;
            Ven_Nro = ven_Nro;
            Ven_Serie = ven_Serie;
            Ven_Material = ven_Material;
            Ven_Descricao = ven_Descricao;
            Ven_Cfop = ven_Cfop;
            Ven_Qtd = ven_Qtd;
            Ven_Valor = ven_Valor;
            Ven_Per_Pis = ven_Per_Pis;
            Ven_Per_Cof = ven_Per_Cof;
            Ven_Saldo_Venda = ven_Saldo_Venda;
            Ent_Chave = ent_Chave;
            Ent_Cod_Empresa = ent_Cod_Empresa;
            Ent_Local = ent_Local;
            Ent_Id_Planilha = ent_Id_Planilha;
            Ent_Dtlanc = ent_Dtlanc;
            Ent_Dtnf = ent_Dtnf;
            Ent_Nro = ent_Nro;
            Ent_Serie = ent_Serie;
            Ent_Operacao = ent_Operacao;
            Ent_Material = ent_Material;
            Ent_Descricao = ent_Descricao;
            Ent_Cfop = ent_Cfop;
            Ent_Qtd = ent_Qtd;
            Ent_Valor = ent_Valor;
            Ent_Saldo = ent_Saldo;
            Ent_Qtd_Usada = ent_Qtd_Usada;
            Calc_P_Unit = calc_P_Unit;
            Calc_Base_Pis = calc_Base_Pis;
            Calc_Per_Pis = calc_Per_Pis;
            Calc_Vlr_Pis = calc_Vlr_Pis;
            Calc_Base_Cofins = calc_Base_Cofins;
            Calc_Per_Cof = calc_Per_Cof;
            Calc_Vlr_Cofins = calc_Vlr_Cofins;
        }

        public Nfe_DetE_Qry_01()
		{
            Zerar();
		}

		public void Zerar()
        {
            Id_Fechamento = 0;
            Desc_Fechamento = "";
            Ven_Empresa = "";
            Ven_Ano = 0;
            Ven_Id = 0;
            Ven_Nro_Linha = 0;
            Ven_Chave = "";
            Ven_Cod_Empresa = "";
            Ven_Local = "";
            Ven_Id_Planilha = "";
            Ven_Dtlanc = null;
            Ven_Dtnf = null;
            Ven_Nro = "";
            Ven_Serie = "";
            Ven_Material = "";
            Ven_Descricao = "";
            Ven_Cfop = "";
            Ven_Qtd = 0;
            Ven_Valor = 0;
            Ven_Per_Pis = 0;
            Ven_Per_Cof = 0;
            Ven_Saldo_Venda = 0;
            Ent_Chave = "";
            Ent_Cod_Empresa = "";
            Ent_Local = "";
            Ent_Id_Planilha = "";
            Ent_Dtlanc = null;
            Ent_Dtnf = null;
            Ent_Nro = "";
            Ent_Serie = "";
            Ent_Operacao = "";
            Ent_Material = "";
            Ent_Descricao = "";
            Ent_Cfop = "";
            Ent_Qtd = 0;
            Ent_Valor = 0;
            Ent_Saldo = 0;
            Ent_Qtd_Usada = 0;
            Calc_P_Unit = 0;
            Calc_Base_Pis = 0;
            Calc_Per_Pis = 0;
            Calc_Vlr_Pis = 0;
            Calc_Base_Cofins = 0;
            Calc_Per_Cof = 0;
            Calc_Vlr_Cofins = 0;
        }
    }

}
