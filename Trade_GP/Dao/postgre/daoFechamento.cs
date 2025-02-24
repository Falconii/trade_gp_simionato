using Npgsql;
using Trade_GP.Models;
using Trade_GP.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trade_GP.Dao.postgre
{
    public class daoFechamento
    {
        public Fechamento Insert(Fechamento obj)
        {
            String StringInsert = $" INSERT INTO FECHAMENTO(id_grupo, pinicial, pfinal, descricao, user_insert, dtinicial, dtfinal, status) VALUES ( " +
            $"  {obj.Id_Grupo}    " +
            $",'{obj.PInicial.ToString("yyyy-MM-dd")}'   " +
            $",'{obj.PFinal.ToString("yyyy-MM-dd")}'   " +
            $",'{obj.Descricao}' " +
            $", {obj.User_Insert}  " +
            $",'{obj.DtInicial.ToString("yyyy-MM-dd")}' " +
            $",'{obj.DtFinal.ToString("yyyy-MM-dd")}' " +
            $",'{obj.Status}' " +
            $" )  RETURNING ID ";

            Console.WriteLine($"Insert : {StringInsert}");

            try
            {

                using (var objConexao = new NpgsqlConnection(DataBase.RunCommand.connectionString))
                {
                    using (var objCommand = new NpgsqlCommand(StringInsert, objConexao))
                    {
                        try
                        {
                            objConexao.Open();

                            var objDataReader = objCommand.ExecuteReader();

                            if (objDataReader.HasRows)
                            {

                                while (objDataReader.Read())
                                {

                                    obj.Id = Convert.ToInt32(objDataReader["ID"]);

                                }
                            }

                        }
                        catch (Exception ex)
                        {


                            obj = null;

                            throw new Exception(ex.Message);
                        }
                        finally
                        {
                            objConexao.Close();
                        }
                    }
                }

            }
            catch (ExceptionErroImportacao ex)
            {
                MessageBox.Show(ex.Message, "Atenção!");

                obj = null;

            }


            return obj;


        }
        public void Update(Fechamento obj)
        {

            String StringUpdate = $" UPDATE FECHAMENTO SET " +
            $"  PINICIAL        = '{obj.PInicial.ToString("yyyy-MM-dd")}'   " +
            $", PFINAL          = '{obj.PFinal.ToString("yyyy-MM-dd")}'   " +
            $", DESCRICAO       = '{obj.Descricao}' " +
            $", USER_INSERT     =  {obj.User_Insert}  " +
            $", DTINICIAL       = '{obj.DtInicial.ToString("yyyy-MM-dd hh:mm:ss")}' " +
            $", DTFINAL         = '{obj.DtFinal.ToString("yyyy-MM-dd hh:mm:ss")}' " +
            $", STATUS          = '{obj.Status}' " +
            $" WHERE ID_GRUPO   =  {obj.Id_Grupo} AND ID = {obj.Id} ";
            Console.WriteLine(StringUpdate);

            try
            {

                DataBase.RunCommand.CreateCommand(StringUpdate);

            }
            catch (ExceptionErroImportacao ex)
            {
                throw ex;
            }

        }
        public void Delete(Fechamento obj)
        {
            try
            {
                String StringDelete = $" DELETE FROM FECHAMENTO WHERE ID_GRUPO = {obj.Id_Grupo} AND ID = {obj.Id} ";

                DataBase.RunCommand.CreateCommand(StringDelete);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Fechamento Seek(int id_grupo, int id)
        {

            Fechamento obj = null;

            string strStringConexao = DataBase.RunCommand.connectionString;

            string strSelect = $"SELECT * FROM FECHAMENTO WHERE ID_GRUPO = {id_grupo} AND ID = {id}";

            using (var objConexao = new NpgsqlConnection(strStringConexao))
            {
                using (var objCommand = new NpgsqlCommand(strSelect, objConexao))
                {
                    try
                    {
                        objConexao.Open();

                        var objDataReader = objCommand.ExecuteReader();

                        if (objDataReader.HasRows)
                        {

                            objDataReader.Read();

                            obj = new Fechamento();

                            obj = PopulaFechamento(objDataReader);


                        }

                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        objConexao.Close();
                    }
                }
            }

            return obj;
        }
        public Fechamento SeekLast(int id_grupo)
        {

            Fechamento obj = null;

            string strStringConexao = DataBase.RunCommand.connectionString;

            string strSelect = $" select fe.* " +
                               $" from fechamento fe " +
                               $" where fe.id_grupo = {id_grupo} and fe.id = (select max(id) from fechamento ultimo where id_grupo = {id_grupo} ) ";


            using (var objConexao = new NpgsqlConnection(strStringConexao))
            {
                using (var objCommand = new NpgsqlCommand(strSelect, objConexao))
                {
                    try
                    {
                        objConexao.Open();

                        var objDataReader = objCommand.ExecuteReader();

                        if (objDataReader.HasRows)
                        {

                            objDataReader.Read();

                            obj = new Fechamento();

                            obj = PopulaFechamento(objDataReader);


                        }

                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        objConexao.Close();
                    }
                }
            }

            return obj;
        }
        public List<Fechamento> getAll(int Ordenacao, string Filtro)
        {

            Fechamento obj = null;

            string strStringConexao = DataBase.RunCommand.connectionString;

            List<Fechamento> lista = new List<Fechamento>();

            string strSelect = SqlGrid(Ordenacao, Filtro);

            Console.WriteLine(strSelect);

            using (var objConexao = new NpgsqlConnection(strStringConexao))
            {
                using (var objCommand = new NpgsqlCommand(strSelect, objConexao))
                {
                    try
                    {
                        objConexao.Open();

                        var objDataReader = objCommand.ExecuteReader();

                        if (objDataReader.HasRows)
                        {

                            while (objDataReader.Read())
                            {

                                obj = new Fechamento();

                                obj = PopulaFechamento(objDataReader);

                                lista.Add(obj);

                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        objConexao.Close();
                    }
                }
            }

            return lista;
        }
        public string SqlGrid(int Ordenacao, string Filtro)
        {
            string Where = "";

            string OrderBy = "";

            string strSelect = "SELECT  ID_GRUPO, ID, PINICIAL , PFINAL, DESCRICAO, USER_INSERT, DTINICIAL, DTFINAL, STATUS " +
                               "FROM FECHAMENTO ";

            //Adiciona WHERE 
            if (Filtro.Trim() != "")
            {
                switch (Ordenacao)
                {
                    case 0:
                        Where = $"WHERE ID = {Filtro}";
                        break;
                    case 1:
                        Where = $"WHERE PINICIAL = {Filtro}";
                        break;
                }


            }

            //Adiciona ORDER BY


            switch (Ordenacao)
            {
                case 0:
                    OrderBy = $"ORDER BY ID";
                    break;
                case 1:
                    OrderBy = $"ORDER BY PINCIAL";
                    break;

            }

            strSelect += $" {Where} {OrderBy} ";

            return strSelect;

        }

        
        private Fechamento PopulaFechamento(NpgsqlDataReader objDataReader)
        {
            var obj = new Fechamento();
            obj.Id_Grupo = Convert.ToInt32(objDataReader["id_grupo"].ToString());
            obj.Id = Convert.ToInt32(objDataReader["id"].ToString());
            obj.PInicial = Convert.ToDateTime(objDataReader["pinicial"]);
            obj.PFinal = Convert.ToDateTime(objDataReader["pfinal"]);
            obj.Descricao = objDataReader["descricao"].ToString();
            obj.DtInicial = Convert.ToDateTime(objDataReader["dtinicial"]);
            obj.DtFinal = Convert.ToDateTime(objDataReader["dtfinal"]);
            obj.User_Insert = Convert.ToInt32(objDataReader["user_insert"].ToString());
            obj.Status = objDataReader["status"].ToString();
            return obj;
        }
        public string SelectStringFechamentos_Relatorio(Filtro_Fechamento Filtro, string pasta, string file)
        {
            string Where = "";

            string OrderBy = "order by cli.empresa,to_char(ven.dtnf,'YYYY'),ven.id,ven.nro_linha,ent.operacao,ent.serie,ent.nro";

            string strSelect = "";

            //Adiciona WHERE 
            if (Filtro.Id_Grupo != 0)
            {
                Where += Where == "" ? " where " : " and ";
                Where += $" FEC.ID_GRUPO = {Filtro.Id_Grupo} ";
            }

            if (Filtro.Id != 0)
            {
                Where += Where == "" ? " where " : " and ";
                Where += $" FEC.ID = {Filtro.Id} ";
            }

            if (Filtro.Descricao.Trim() != "")
            {
                Where += Where == "" ? " where " : " and ";
                Where += $" fec.descricao like '%{Filtro.Descricao.Trim()}%' ";
            }

            if (Filtro.Periodo)
            {

                if (Filtro.PInicial != null)
                {
                    Where += Where == "" ? " where " : " and ";
                    Where += $" ( FEC.PINICIAL = '{Filtro.PInicial?.ToString("yyyy-MM-dd")}' AND  FEC.PFINAL = '{Filtro.PFinal?.ToString("yyyy-MM-dd")}') ";
                }

            }

            if (Filtro.Status != "")
            {
                Where += Where == "" ? " where " : " and ";
                Where += $" FEC.STATUS = '{Filtro.Status}' ";
            }

            if (Filtro.Fechamentos.Count > 0)
            {
                string rascunho = "(";

                foreach(string _id in Filtro.Fechamentos)
                {
                    if (rascunho.Length > 1) rascunho += ",";

                    rascunho += $"{_id}";

                }
                rascunho += ")";

                Where += Where == "" ? " where " : " and ";
                Where += $" FEC.ID IN {rascunho} ";
            }
            strSelect = "copy ( select ";
            if (Filtro.Excel)
            {
                strSelect += "con.id_fechamento as ID_FECHAMENTO, " +
                             "fec.descricao as DESCRICAO_FECHAMENTO, ";
            }
            strSelect += "cli.empresa              as EMPRESA" +
                           ",to_char(ven.dtnf, 'YYYY') as ANO " +
                           ",ven.id                    as ID " +
                           ",ven.nro_linha             as NRO_LINHA" +
                          $",{Coluna_Copy.NumericLikeText("ven.chave", "chave")}" +
                           ",ven.cod_empresa AS COD_EMPRESA " +
                          $",{Coluna_Copy.NumericLikeText("ven.local", "local")}" +
                          $",{Coluna_Copy.NumericLikeText("cli.cnpj_cpf", "cnpj")}" +
                          $",{Coluna_Copy.NumericLikeText("ven.id_planilha", "ID_PLANILHA")} " +
                           ",ven.dtlanc as DT_LANC " +
                           ",ven.dtnf AS DTNF " +
                          $",{Coluna_Copy.NumericLikeText("ven.nro", "NRO_NF")}" +
                          $",{Coluna_Copy.NumericLikeText("ven.serie", "SERIE")}" +
                           ",ven.material AS MATERIAL " +
                           ",ven.descricao AS DESCRICAO " +
                           ",ven.cfop AS CFOP " +
                          $",{Coluna_Copy.NumericFormat("ven.qtd", 12, 4, "QTD")}" +
                          $",{Coluna_Copy.NumericFormat("ven.vlr_contabil", 12, 4, "VALOR_TOTAL")} " +
                          $",{Coluna_Copy.NumericFormat("ven.bas_icms", 12, 2, "BASE_ICMS")} " +
                          $",{Coluna_Copy.NumericFormat("ven.bas_pis", 12, 2, "BASE_PIS")} " +
                          $",{Coluna_Copy.NumericFormat("ven.per_pis", 6, 2, "PERC_PIS")} " +
                          $",{Coluna_Copy.NumericFormat("ven.vlr_pis", 6, 2, "VLR_PIS")} " +
                          $",{Coluna_Copy.NumericFormat("ven.bas_cof", 12, 2, "BASE_COF")} " +
                          $",{Coluna_Copy.NumericFormat("ven.per_cof", 6, 2, "PERC_COFINS")} " +
                          $",{Coluna_Copy.NumericFormat("ven.vlr_cof", 6, 2, "VLR_COF")} " +
                          $",{Coluna_Copy.NumericFormat("ven.saldo", 12, 4, "SALDO_VENDA")} " +
                          $",{Coluna_Copy.NumericLikeText("ent.chave", "chave")}" +
                           ", ent.cod_empresa " +
                           ",ent.local " +
                          $",{Coluna_Copy.NumericLikeText("ven.id_planilha", "ID_PLANILHA")} " +
                           ",ent.dtlanc " +
                           ",ent.dtnf " +
                          $",{Coluna_Copy.AgeFormat("ent.dtnf", "2023-12-05", "idade")}" +
                          $",{Coluna_Copy.NumericLikeText("ent.nro", "NRO_NF")}" +
                          $",{Coluna_Copy.NumericLikeText("ent.serie", "SERIE")}" +
                          $",ent.nr_item "+
                           ",case  " +
                          $"       when ent.operacao = 'E' then 'ENTRADA' " +
                          $"       else 'SALDO ANTERIOR' " +
                           " end as OPERACAO " +
                           ",ent.material " +
                           ",ent.descricao " +
                           ",ent.cfop " +
                          $",{Coluna_Copy.NumericFormat("ent.qtd", 12, 4, "QTD")}" +
                            ",case  " +
                          $"       when ent.operacao = 'E' then  TO_CHAR("+
                                   "(SELECT coalesce(sum(qtd_e),0) FROM controle_e con_sld WHERE con_sld.id_grupo = 1  AND con_sld.id_e = con.id_e AND con_sld.id_fechamento <> fec.id AND con_sld.nro_linha_e = con.nro_linha_e ) " +
                          $", '999999999999D0000')"+
                          $"       else {Coluna_Copy.NumericFormat("ent.qtd-ent.sobra", 12, 4, "")} " +
                           "end as QTD_REMANESCENTE " +
                          $",{Coluna_Copy.NumericFormat("ent.vlr_contabil", 12, 4, "VALOR_TOTAL")} " +
                          $",{Coluna_Copy.NumericFormat("ent.bas_icms", 12, 2, "BASE_ICMS")} " +
                          $",{Coluna_Copy.NumericFormat("ent.saldo", 12, 4, "SALDO_ENTRADA")} " +
                          $",{Coluna_Copy.NumericFormat("con.qtd_e", 12, 4, "QTD_USADA")} " +
                           ",case  " +
                          $"       when ent.operacao = 'E' then {Coluna_Copy.NumericFormat("round((ent.bas_icms / ent.qtd), 4)",12,4,"")}  " +
                          $"       else {Coluna_Copy.NumericFormat("ent.vlr_unit",12,4,"")} " +
                           "end as P_Unit " +
                           ",case " +
                          $"    when ent.operacao = 'E' then {Coluna_Copy.NumericFormat("round((con.qtd_e* (round((ent.bas_icms/ ent.qtd),4))),4)",12,4,"")} " +
                          $"    else {Coluna_Copy.NumericFormat("round((con.qtd_e * ent.vlr_unit), 4)", 12,4,"")} " +
                           " end as BASE_PIS " +
                          $",{Coluna_Copy.NumericFormat("ven.per_pis",12,4,"PER_PIS")}" +
                           ",case " +
                          $"    when ent.operacao = 'E' then {Coluna_Copy.NumericFormat("round((con.qtd_e* (round((ent.bas_icms/ ent.qtd),4)) *(ven.per_pis / 100)),4)",12,4,"")} " +
                          $"    else {Coluna_Copy.NumericFormat("round((con.qtd_e * ent.vlr_unit) * (ven.per_pis / 100), 4)", 12,4,"")} " +
                           " end as VLR_PIS " +
                           ",case " +
                          $"    when ent.operacao = 'E' then {Coluna_Copy.NumericFormat("round((con.qtd_e* (round((ent.bas_icms/ ent.qtd),4))),4)",12,4,"")} "+
                          $"    else {Coluna_Copy.NumericFormat("round((con.qtd_e * ent.vlr_unit), 4)", 12,4,"")} " +
                           " end as BASE_COFINS " +
                           $",{Coluna_Copy.NumericFormat("ven.per_cof", 12, 4, "PER_COFINS")}" + 
                           ",case " +
                          $"    when ent.operacao = 'E' then {Coluna_Copy.NumericFormat("round((con.qtd_e* (round((ent.bas_icms/ ent.qtd),4)) *(ven.per_cof / 100)),4)",12,4,"")} " +
                          $"    else {Coluna_Copy.NumericFormat("round((con.qtd_e * ent.vlr_unit) * (ven.per_cof / 100), 4)", 12,4,"")} " +
                           " end as VLR_COFINS " +
                           " from fechamento fec " +
                           " inner join controle_e con  on con.id_grupo = fec.id_grupo and con.id_fechamento = fec.id " +
                           " inner join nfe_det_e ven on ven.id = con.id_s and ven.nro_linha = con.nro_linha_s " +
                           " inner join nfe_det_e ent on ent.id = con.id_e and ent.nro_linha = con.nro_linha_e " +
                           " inner join clientes cli on cli.cod_empresa = ven.cod_empresa and cli.local = ven.local ";

            strSelect += $" {Where} ";

            strSelect += $" {OrderBy} ";

            strSelect += $" ) To '{pasta}{file}.csv' With CSV DELIMITER ';' HEADER; ";

            return strSelect;
        }
        public async Task<string> Fechamento_Relatorio(Filtro_Fechamento Filtro, string pasta, string file)
        {
            string retorno = "Relatório Gravado Com Sucesso!";

            string strStringConexao = DataBase.RunCommand.connectionString;

            string strSelect = SelectStringFechamentos_Relatorio(Filtro,pasta,file);

            Console.WriteLine(strSelect);

            await Task.Run(() =>
            {
                try
                {

                    DataBase.RunCommand.CreateCommand(strSelect);

                }
                catch (ExceptionErroImportacao ex)
                {
                    
                    retorno = $"Erro: {ex.Message}";

                }


            });

            return retorno;

        }
        public string SelectStringFechamentos_Page(Filtro_Fechamento Filtro, int Page, int TamPage, bool Contador)
        {
            string Where = "";

            string OrderBy = "order by id_grupo,pinicial";

            string strSelect = "";

            //Adiciona WHERE 
            if (Filtro.Id_Grupo != 0)
            {
                Where += Where == "" ? " where " : " and ";
                Where += $" FEC.ID_GRUPO = {Filtro.Id_Grupo} ";
            }

            if (Filtro.Id != 0)
            {
                Where += Where == "" ? " where " : " and ";
                Where += $" FEC.ID = {Filtro.Id} ";
            }

            if (Filtro.Descricao != "")
            {
                Where += Where == "" ? " where " : " and ";
                Where += $" fec.descricao = '{Filtro.Descricao}' ";
            }


            if (Filtro.Periodo)
            {

                if (Filtro.PInicial != null)
                {
                    Where += Where == "" ? " where " : " and ";
                    Where += $" ( FEC.PINICIAL = '{Filtro.PInicial?.ToString("yyyy-MM-dd")}' AND  FEC.PFINAL = '{Filtro.PFinal?.ToString("yyyy-MM-dd")}') ";
                }

            }

            if (Filtro.Status != "")
            {
                Where += Where == "" ? " where " : " and ";
                Where += $" FEC.STATUS = '{Filtro.Status}' ";
            }


            if (Contador)
            {

                strSelect = "SELECT count(*) AS TOTAL FROM FECHAMENTO FEC ";

                strSelect += $" {Where} ";

            }
            else
            {

                strSelect = "SELECT  * FROM FECHAMENTO FEC";

                strSelect += $" {Where} ";

                strSelect += $" {OrderBy} ";

                if (Page > 0)
                {
                    strSelect += $" LIMIT {TamPage} OFFSET {((Page - 1) * TamPage)} ";
                }

            }

            return strSelect;
        }
        public async Task<List<Fechamento>> GetFechamentosByFiltro(Filtro_Fechamento Filtro)
        {
            List<Fechamento> Retorno = new List<Fechamento>();

            string strSelect = "";

            string strStringConexao = DataBase.RunCommand.connectionString;

            strSelect = SelectStringFechamentos_Page(Filtro, 0, 0, false);

            Console.WriteLine(strSelect);

            await Task.Run(() =>
            {
                using (var objConexao = new NpgsqlConnection(strStringConexao))
                {
                    using (var objCommand = new NpgsqlCommand(strSelect, objConexao))
                    {
                        try
                        {
                            objConexao.Open();

                            var objDataReader = objCommand.ExecuteReader();

                            if (objDataReader.HasRows)
                            {

                                while (objDataReader.Read())
                                {

                                    Fechamento obj = PopulaFechamento(objDataReader);

                                    Retorno.Add(obj);

                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                        finally
                        {
                            objConexao.Close();
                        }
                    }
                }

            });

            return Retorno;

        }
        
    }
}

