using System;

namespace Trade_GP.Models
{
    public class NfeDetTrade5910
    {
        public int Id_Grupo { get; set; }
        public int Id_Planilha { get; set; }
        public string Id_Operacao { get; set; }
        public int Nro_Linha { get; set; }
        public string Cod_Emp { get; set; }
        public string Local { get; set; }
        public string Id_Parc { get; set; }
        public string Cnpj_Cpf { get; set; }
        public string Nome { get; set; }
        public string UF { get; set; }
        public string Chave_Acesso { get; set; }
        public string Nro_Doc { get; set; }
        public string Nro_Item { get; set; }
        public string Nro_Posicao { get; set; }
        public DateTime Dt_Doc { get; set; }
        public DateTime Dt_Lanc { get; set; }
        public DateTime Dt_Ref { get; set; }
        public string Cfop { get; set; }
        public string Origem { get; set; }
        public string Sit_Trib { get; set; }
        public string Material { get; set; }
        public string Tp_Aval { get; set; }
        public string Cod_Controle { get; set; }
        public string Denom { get; set; }
        public string Unid { get; set; }
        public double Quantidade_1 { get; set; }
        public double Quantidade_2 { get; set; }
        public double Qtd_Conv { get; set; }
        public double Preco_Liq { get; set; }
        public double Liquido { get; set; }
        public double Valor { get; set; }
        public double Vlr_Contb { get; set; }
        public double PIS_Base { get; set; }
        public string StPis { get; set; }
        public double Pis_Taxa { get; set; }
        public double Pis_Vlr { get; set; }
        public string StCof { get; set; }
        public double Cof_Base { get; set; }
        public double Cof_Taxa { get; set; }
        public double Cof_Vlr { get; set; }
        public double Ipi_Base { get; set; }
        public double Ipi_Taxa { get; set; }
        public double Ipi_Vlr { get; set; }
        public double Icms_Base { get; set; }
        public double Icms_Taxa { get; set; }
        public double Icms_Vlr { get; set; }
        public double Fecp_Vlr { get; set; }
        public double Icst_Base { get; set; }
        public double Icst_Taxa { get; set; }
        public double Icst_Valor { get; set; }
        public double Fest_Valor { get; set; }
        public double Bc_Icms_Rt { get; set; }
        public double Vlr_Icms_Str { get; set; }
        public double Vlr_Fcps_St_Rt { get; set; }
        public string Doc_Origem { get; set; }
        public string Item_Ref { get; set; }
        public double Saldo { get; set; }
        public double Sobra { get; set; }
        public string Status { get; set; }
        public string Layout { get; set; }
        public double Qtd_Dev { get; set; }
        public int Id_Saida { get; set; }
        public int Nro_Linha_Saida { get; set; }
        public double Saldo_Inicial { get; set; }
        public double Qtd_Convertida { get; set; }
        public double Fator { get; set; }
        public int    Etapa { get; set; }
        public double Qtd_Venda { get; set; }
        public string Venda_Status { get; set; }

        public NfeDetTrade5910(int id_Grupo, int id_Planilha, string id_Operacao, int nro_Linha, string cod_Emp, string local, string id_Parc, string cnpj_Cpf, string nome, string uF, string chave_Acesso, string nro_Doc, string nro_Item, string nro_Posicao, DateTime dt_Doc, DateTime dt_Lanc, DateTime dt_Ref, string cfop, string origem, string sit_Trib, string material, string tp_Aval, string cod_Controle, string denom, string unid, double quantidade_1, double quantidade_2, double qtd_Conv, double preco_Liq, double liquido, double valor, double vlr_Contb, double pIS_Base, string stPis, double pis_Taxa, double pis_Vlr, string stCof, double cof_Base, double cof_Taxa, double cof_Vlr, double ipi_Base, double ipi_Taxa, double ipi_Vlr, double icms_Base, double icms_Taxa, double icms_Vlr, double fecp_Vlr, double icst_Base, double icst_Taxa, double icst_Valor, double fest_Valor, double bc_Icms_Rt, double vlr_Icms_Str, double vlr_Fcps_St_Rt, string doc_Origem, string item_Ref, double saldo, double sobra, string status, string layout, double qtd_Dev, int id_Saida, int nro_Linha_Saida, double saldo_Inicial, double qtd_Convertida, double fator, int etapa, double qtd_Venda, string venda_Status)
        {
            Id_Grupo = id_Grupo;
            Id_Planilha = id_Planilha;
            Id_Operacao = id_Operacao;
            Nro_Linha = nro_Linha;
            Cod_Emp = cod_Emp;
            Local = local;
            Id_Parc = id_Parc;
            Cnpj_Cpf = cnpj_Cpf;
            Nome = nome;
            UF = uF;
            Chave_Acesso = chave_Acesso;
            Nro_Doc = nro_Doc;
            Nro_Item = nro_Item;
            Nro_Posicao = nro_Posicao;
            Dt_Doc = dt_Doc;
            Dt_Lanc = dt_Lanc;
            Dt_Ref = dt_Ref;
            Cfop = cfop;
            Origem = origem;
            Sit_Trib = sit_Trib;
            Material = material;
            Tp_Aval = tp_Aval;
            Cod_Controle = cod_Controle;
            Denom = denom;
            Unid = unid;
            Quantidade_1 = quantidade_1;
            Quantidade_2 = quantidade_2;
            Qtd_Conv = qtd_Conv;
            Preco_Liq = preco_Liq;
            Liquido = liquido;
            Valor = valor;
            Vlr_Contb = vlr_Contb;
            PIS_Base = pIS_Base;
            StPis = stPis;
            Pis_Taxa = pis_Taxa;
            Pis_Vlr = pis_Vlr;
            StCof = stCof;
            Cof_Base = cof_Base;
            Cof_Taxa = cof_Taxa;
            Cof_Vlr = cof_Vlr;
            Ipi_Base = ipi_Base;
            Ipi_Taxa = ipi_Taxa;
            Ipi_Vlr = ipi_Vlr;
            Icms_Base = icms_Base;
            Icms_Taxa = icms_Taxa;
            Icms_Vlr = icms_Vlr;
            Fecp_Vlr = fecp_Vlr;
            Icst_Base = icst_Base;
            Icst_Taxa = icst_Taxa;
            Icst_Valor = icst_Valor;
            Fest_Valor = fest_Valor;
            Bc_Icms_Rt = bc_Icms_Rt;
            Vlr_Icms_Str = vlr_Icms_Str;
            Vlr_Fcps_St_Rt = vlr_Fcps_St_Rt;
            Doc_Origem = doc_Origem;
            Item_Ref = item_Ref;
            Saldo = saldo;
            Sobra = sobra;
            Status = status;
            Layout = layout;
            Qtd_Dev = qtd_Dev;
            Id_Saida = id_Saida;
            Nro_Linha_Saida = nro_Linha_Saida;
            Saldo_Inicial = saldo_Inicial;
            Qtd_Convertida = qtd_Convertida;
            Fator = fator;
            Etapa = etapa;
            Qtd_Venda = qtd_Venda;
            Venda_Status = venda_Status;
        }

        public NfeDetTrade5910()
    {
        Zerar();
    }

    public void Zerar()
    {
            Id_Grupo = 1;
            Id_Planilha = 0;
            Id_Operacao = "";
            Nro_Linha = 0;
            Cod_Emp = "";
            Local = "";
            Id_Parc = "";
            Cnpj_Cpf = "";
            Nome = "";
            UF = "";
            Chave_Acesso = "";
            Nro_Doc = "";
            Nro_Item = "";
            Nro_Posicao = "";
            Dt_Doc = DateTime.Now; ;
            Dt_Lanc = DateTime.Now; ;
            Cfop = "";
            Origem = "";
            Sit_Trib = "";
            Material = "";
            Tp_Aval = "";
            Cod_Controle = "";
            Denom = "";
            Unid = "";
            Quantidade_1 = 0;
            Quantidade_2 = 0;
            Qtd_Conv = 0;
            Preco_Liq = 0;
            Liquido = 0;
            Valor = 0;
            Vlr_Contb = 0;
            PIS_Base = 0;
            StPis = "";
            Pis_Taxa = 0;
            Pis_Vlr = 0;
            StCof ="";
            Cof_Base = 0;
            Cof_Taxa = 0;
            Cof_Vlr = 0;
            Ipi_Base = 0;
            Ipi_Taxa = 0;
            Ipi_Vlr = 0;
            Icms_Base = 0;
            Icms_Taxa = 0;
            Icms_Vlr = 0;
            Fecp_Vlr = 0;
            Icst_Base = 0;
            Icst_Taxa = 0;
            Icst_Valor = 0;
            Fest_Valor = 0;
            Bc_Icms_Rt = 0;
            Vlr_Icms_Str = 0;
            Vlr_Fcps_St_Rt = 0;
            Doc_Origem = "";
            Item_Ref = "";
            Saldo = 0;
            Sobra = 0;
            Status = "";
            Layout = "S";
            Qtd_Dev = 0;
            Id_Saida = 0;
            Nro_Linha_Saida = 0;
            Saldo_Inicial = 0;
            Qtd_Convertida = 0;
            Fator = 0;
            Etapa = 0;
            Qtd_Venda = 0;
            Venda_Status = "";
        }
}
}
