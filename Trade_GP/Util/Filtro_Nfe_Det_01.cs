using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade_GP.Util
{
    public class Filtro_Nfe_Det_01
    {
		public int Id_Grupo { get; set; }
        public int Id_Fechamento { get; set; }
        public string Fec_Descricao { get; set; }
        public string Ven_Empresa { get; set; }
		public int Ven_Ano { get; set; }
		public int Ven_Id { get; set; }
		public string Ven_Chave { get; set; }
		public string Ven_Cod_Empresa { get; set; }
		public string Ven_Local { get; set; }
		public DateTime? Ven_Dtlanc { get; set; }
		public DateTime? Ven_Dtnf { get; set; }
		public string Ven_Nro { get; set; }
		public string Ven_Serie { get; set; }
		public string Ven_Material { get; set; }
		public string Ven_Descricao { get; set; }
		public string Ven_Cfop { get; set; }
		public string Ent_Chave { get; set; }
		public DateTime? Ent_Dtlanc { get; set; }
		public DateTime? Ent_Dtnf { get; set; }
		public string Ent_Nro { get; set; }
		public string Ent_Serie { get; set; }
		public string Ent_Operacao { get; set; }
		public string Ent_Material { get; set; }
		public string Ent_Descricao { get; set; }
		public string Ent_Cfop { get; set; }
		public double Ent_Qtd { get; set; }
		public string Ven_Status { get; set; }

        public Filtro_Nfe_Det_01(int id_Grupo, int id_Fechamento, string fec_Descricao, string ven_Empresa, int ven_Ano, int ven_Id, string ven_Chave, string ven_Cod_Empresa, string ven_Local, DateTime? ven_Dtlanc, DateTime? ven_Dtnf, string ven_Nro, string ven_Serie, string ven_Material, string ven_Descricao, string ven_Cfop, string ent_Chave, DateTime? ent_Dtlanc, DateTime? ent_Dtnf, string ent_Nro, string ent_Serie, string ent_Operacao, string ent_Material, string ent_Descricao, string ent_Cfop, double ent_Qtd, string ven_Status)
        {
            Id_Grupo = id_Grupo;
            Id_Fechamento = id_Fechamento;
            Fec_Descricao = fec_Descricao;
            Ven_Empresa = ven_Empresa;
            Ven_Ano = ven_Ano;
            Ven_Id = ven_Id;
            Ven_Chave = ven_Chave;
            Ven_Cod_Empresa = ven_Cod_Empresa;
            Ven_Local = ven_Local;
            Ven_Dtlanc = ven_Dtlanc;
            Ven_Dtnf = ven_Dtnf;
            Ven_Nro = ven_Nro;
            Ven_Serie = ven_Serie;
            Ven_Material = ven_Material;
            Ven_Descricao = ven_Descricao;
            Ven_Cfop = ven_Cfop;
            Ent_Chave = ent_Chave;
            Ent_Dtlanc = ent_Dtlanc;
            Ent_Dtnf = ent_Dtnf;
            Ent_Nro = ent_Nro;
            Ent_Serie = ent_Serie;
            Ent_Operacao = ent_Operacao;
            Ent_Material = ent_Material;
            Ent_Descricao = ent_Descricao;
            Ent_Cfop = ent_Cfop;
            Ent_Qtd = ent_Qtd;
            Ven_Status = ven_Status;
        }

        public Filtro_Nfe_Det_01()
        {
            Zerar();
        }

        
        public void Zerar()
        {
            Id_Grupo = 0;
            Id_Fechamento = 0;
            Fec_Descricao = "";
            Ven_Empresa = "";
            Ven_Ano = 0;
            Ven_Id = 0;
            Ven_Chave = "";
            Ven_Cod_Empresa = "";
            Ven_Local = "";
            Ven_Dtlanc = null;
            Ven_Dtnf = null;
            Ven_Nro = "";
            Ven_Serie = "";
            Ven_Material = "";
            Ven_Descricao = "";
            Ven_Cfop = "";
            Ent_Chave = "";
            Ent_Dtlanc = null;
            Ent_Dtnf = null;
            Ent_Nro = "";
            Ent_Serie = "";
            Ent_Operacao = "";
            Ent_Material = "";
            Ent_Descricao = "";
            Ent_Cfop = "";
            Ent_Qtd = 0;
            Ven_Status = "1";
        }
    }
}
