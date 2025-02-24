using Npgsql;
using Trade_GP.Extensoes;
using Trade_GP.Models;
using Trade_GP.Util;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trade_GP.Dao.postgre
{
    public class daoNfeCabTrade
    {
        public NfeCabTrade Insert(NfeCabTrade obj)
        {
            String StringInsert = $" INSERT INTO NFE_CAB_TRADE(id_grupo,arquivo, qtd, vlr_contabil, bas_icms, vlr_icms, bas_pis, vlr_pis, bas_cof, vlr_cof, bas_ipi, vlr_ipi, bas_icms_st, vlr_icms_st, nro_linha, usuarioinclusao, usuarioatualizacao, data_criacao, data_fechamento, status, ultima, layout, resumo_5405) VALUES ( " +
            $"  {obj.Id_Grupo}    " +
            $",'{obj.Arquivo}'   " +
            $",{obj.Qtd.DoubleParseDb()     }  " +
            $",{obj.Vlr_Contabil.DoubleParseDb() }   " +
            $",{obj.Bas_Icms.DoubleParseDb()}    " +
            $",{obj.Vlr_Icms.DoubleParseDb()}    " +
            $",{obj.Bas_Pis.DoubleParseDb()}     " +
            $",{obj.Vlr_Pis.DoubleParseDb()}     " +
            $",{obj.Bas_Cof.DoubleParseDb()}    " +
            $",{obj.Vlr_Cof.DoubleParseDb()}  " +
            $",{obj.Bas_Ipi.DoubleParseDb()}    " +
            $",{obj.Vlr_Ipi.DoubleParseDb()}  " +
            $",{obj.Bas_Icms_st.DoubleParseDb()}    " +
            $",{obj.Vlr_Icms_st.DoubleParseDb()}  " +
            $",{obj.NroLinha}  " +
            $",{obj.UsuarioInclusao } " +
            $",{obj.UsuarioAtualizacao}   ";
            StringInsert += obj.DataCriacao == null ? "   , null " : $",'{obj.DataCriacao.ToString("yyyy-MM-dd hh:mm:ss")}' ";
            StringInsert += obj.DataFechamento == null ? ", null " : $",'{obj.DataFechamento?.ToString("yyyy-MM-dd hh:mm:ss")}' ";
            StringInsert += $", {obj.Status}" +
            $", 0 " +
            $", '{obj.Layout}' " +
            $", '{obj.resumo_5405}' " +
            $" )  RETURNING ID ";

            Console.WriteLine($"Insert NFE_CAB_TRADE: {StringInsert}");

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
        public void Update(NfeCabTrade obj)
        {

            String StringUpdate = $" UPDATE NFE_CAB_TRADE SET " +
            $"    Arquivo                          = '{obj.Arquivo}'   " +
            $"   ,QTD                              =  {obj.Qtd.DoubleParseDb()}  " +
            $"   ,VLR_CONTABIL                     =  {obj.Vlr_Contabil.DoubleParseDb()} " +
            $"   ,BAS_ICMS                         = {obj.Bas_Icms.DoubleParseDb()}    " +
            $"   ,VLR_ICMS                         = {obj.Vlr_Icms.DoubleParseDb()}    " +
            $"   ,BAS_PIS                          = {obj.Bas_Pis.DoubleParseDb()}     " +
            $"   ,VLR_PIS                          = {obj.Vlr_Pis.DoubleParseDb()}     " +
            $"   ,BAS_COF                          = {obj.Bas_Cof.DoubleParseDb()}    " +
            $"   ,VLR_COF                          = {obj.Vlr_Cof.DoubleParseDb()}   " +
            $"   ,BAS_IPI                          = {obj.Bas_Ipi.DoubleParseDb()}    " +
            $"   ,VLR_IPI                          = {obj.Vlr_Ipi.DoubleParseDb()}   " +
            $"   ,BAS_ICMS_ST                      = {obj.Bas_Icms_st.DoubleParseDb()}    " +
            $"   ,VLR_ICMS_ST                      = {obj.Vlr_Icms_st.DoubleParseDb()}   " +
            $"   ,NRO_LINHA                        = {obj.NroLinha}   " +
            $"   ,USUARIOINCLUSAO                  = {obj.UsuarioInclusao} " +
            $"   ,USUARIOATUALIZACAO               = {obj.UsuarioAtualizacao}   ";
            StringUpdate += obj.DataCriacao == null ? ", DATA_CRIACAO    = null " : $", DATA_CRIACAO    = '{obj.DataCriacao.ToString("yyyy-MM-dd hh:mm:ss")}' ";
            StringUpdate += obj.DataFechamento == null ? ", DATA_FECHAMENTO = null " : $", DATA_FECHAMENTO = '{obj.DataFechamento?.ToString("yyyy-MM-dd hh:mm:ss")}' ";
            StringUpdate += $", STATUS             =  {obj.Status} ";
            StringUpdate += $", resumo_5405        =  '{obj.resumo_5405}' " +
            $" WHERE ID_GRUPO = {obj.Id_Grupo} AND ID = '{obj.Id}' ";

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
        public void Delete(NfeCabTrade obj)
        {
            try
            {
                String StringDelete = $" DELETE FROM  NFE_CAB_TRADE  WHERE ID_GRUPO = {obj.Id_Grupo} AND ID = {obj.Id} ";

                DataBase.RunCommand.CreateCommand(StringDelete);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeleteAll(NfeCabTrade obj)
        {
            try
            {
                String StringDelete = $" DELETE FROM  NFE_CAB_TRADE  WHERE ID_GRUPO = {obj.Id_Grupo} AND ID = {obj.Id} ";

                DataBase.RunCommand.CreateCommand(StringDelete);

                daoNfeDetTrade daoDet = new daoNfeDetTrade();

                daoDet.DeleteByIdPlanilha(obj.Id_Grupo, obj.Id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public NfeCabTrade Seek(int id_grupo, int id)
        {

            NfeCabTrade obj = null;

            string strStringConexao = DataBase.RunCommand.connectionString;

            string strSelect = $"SELECT * FROM NFE_CAB_TRADE WHERE ID_GRUPO = {id_grupo} AND ID = {id}";

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

                            obj = new NfeCabTrade();

                            obj = PopulaNfeCab(objDataReader);


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
        public NfeCabTrade SeekByPlanilha(int id_grupo, string Arquivo)
        {

            NfeCabTrade obj = null;

            string strStringConexao = DataBase.RunCommand.connectionString;

            string strSelect = $"SELECT * FROM NFE_CAB_TRADE WHERE ID_GRUPO = {id_grupo} and ARQUIVO  ='{Arquivo}' ";

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

                            obj = new NfeCabTrade();

                            obj = PopulaNfeCab(objDataReader);


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
        public NfeCabTrade SeekByPlanilhaV2(int id_grupo, string Arquivo)
        {

            NfeCabTrade obj = null;

            string strStringConexao = DataBase.RunCommand.connectionString;

            string strSelect = $"SELECT * FROM NFE_CAB_TRADE WHERE  ID_GRUPO = {id_grupo} and ARQUIVO  ='{Arquivo}' ";

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

                            obj = new NfeCabTrade();

                            obj = PopulaNfeCabPobre(objDataReader);


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
        private NfeCabTrade PopulaNfeCab(NpgsqlDataReader objDataReader)
        {

            var obj = new NfeCabTrade();
            obj.Id_Grupo = Convert.ToInt32(objDataReader["id_grupo"].ToString());
            obj.Id = Convert.ToInt32(objDataReader["id"].ToString());
            obj.Arquivo = objDataReader["arquivo"].ToString();
            obj.Qtd = Convert.ToDouble(objDataReader["qtd"]);
            obj.Vlr_Contabil = Convert.ToDouble(objDataReader["vlr_Contabil"]);
            obj.Bas_Icms = Convert.ToDouble(objDataReader["bas_Icms"]);
            obj.Vlr_Icms = Convert.ToDouble(objDataReader["vlr_Icms"]);
            obj.Bas_Pis = Convert.ToDouble(objDataReader["bas_Pis"]);
            obj.Vlr_Pis = Convert.ToDouble(objDataReader["vlr_Pis"]);
            obj.Bas_Cof = Convert.ToDouble(objDataReader["bas_Cof"]);
            obj.Vlr_Cof = Convert.ToDouble(objDataReader["vlr_Cof"]);
            obj.Bas_Ipi = Convert.ToDouble(objDataReader["bas_ipi"]);
            obj.Vlr_Ipi = Convert.ToDouble(objDataReader["vlr_ipi"]);
            obj.Bas_Icms_st = Convert.ToDouble(objDataReader["bas_icms_st"]);
            obj.Vlr_Icms_st = Convert.ToDouble(objDataReader["vlr_icms_st"]);
            obj.NroLinha = Convert.ToInt32(objDataReader["Nro_Linha"].ToString());
            obj.UsuarioInclusao = Convert.ToInt32(objDataReader["usuarioInclusao"]);
            obj.UsuarioAtualizacao = Convert.ToInt32(objDataReader["usuarioAtualizacao"]);
            obj.DataCriacao = Convert.ToDateTime(objDataReader["Data_Criacao"]);
            try
            {
                obj.DataFechamento = Convert.ToDateTime(objDataReader["Data_Fechamento"]);
            }
            catch (Exception _)
            {
                obj.DataFechamento = null;
            }
            obj.Status = Convert.ToInt32(objDataReader["Status"]);
            obj.resumo_5405 = objDataReader["RESUMO_5405"].ToString();
            return obj;
        }
        private NfeCabTrade PopulaNfeCabPobre(NpgsqlDataReader objDataReader)
        {
            var obj = new NfeCabTrade();
            obj.Id = Convert.ToInt32(objDataReader["id"].ToString());
            obj.Arquivo = objDataReader["arquivo"].ToString();
            obj.Qtd = Convert.ToDouble(objDataReader["qtd"]);
            obj.Vlr_Contabil = Convert.ToDouble(objDataReader["vlr_Contabil"]);
            obj.Bas_Icms = Convert.ToDouble(objDataReader["bas_Icms"]);
            obj.Vlr_Icms = Convert.ToDouble(objDataReader["vlr_Icms"]);
            obj.Bas_Pis = Convert.ToDouble(objDataReader["bas_Pis"]);
            obj.Vlr_Pis = Convert.ToDouble(objDataReader["vlr_Pis"]);
            obj.Bas_Cof = Convert.ToDouble(objDataReader["bas_Cof"]);
            obj.Vlr_Cof = Convert.ToDouble(objDataReader["vlr_Cof"]);
            obj.Bas_Ipi = Convert.ToDouble(objDataReader["bas_ipi"]);
            obj.Vlr_Ipi = Convert.ToDouble(objDataReader["vlr_ipi"]);
            obj.Bas_Icms_st = Convert.ToDouble(objDataReader["bas_icms_st"]);
            obj.Vlr_Icms_st = Convert.ToDouble(objDataReader["vlr_icms_st"]);
            obj.NroLinha = Convert.ToInt32(objDataReader["Nro_Linha"].ToString());
            obj.UsuarioInclusao = Convert.ToInt32(objDataReader["usuarioInclusao"]);
            obj.UsuarioAtualizacao = Convert.ToInt32(objDataReader["usuarioAtualizacao"]);
            obj.DataCriacao = Convert.ToDateTime(objDataReader["Data_Criacao"]);
            try
            {
                obj.DataFechamento = Convert.ToDateTime(objDataReader["Data_Fechamento"]);
            }
            catch (Exception _)
            {
                obj.DataFechamento = null;
            }
            obj.Status = Convert.ToInt32(objDataReader["Status"]);
            obj.resumo_5405 = objDataReader["resumo_5405"].ToString();
            return obj;
        }
        private Nfe_CabE_Qry_01 PopulaNfeCabEQry01(NpgsqlDataReader objDataReader)
        {
            var obj = new Nfe_CabE_Qry_01();
            obj.Id_Grupo = Convert.ToInt32(objDataReader["id_grupo"].ToString());
            obj.Id = Convert.ToInt32(objDataReader["id"].ToString());
            obj.Planilha = objDataReader["planilha"].ToString();
            obj.Qtd = Convert.ToDouble(objDataReader["qtd"]);
            obj.Vlr_Contabil = Convert.ToDouble(objDataReader["vlr_Contabil"]);
            obj.Bas_Icms = Convert.ToDouble(objDataReader["bas_Icms"]);
            obj.Vlr_Icms = Convert.ToDouble(objDataReader["vlr_Icms"]);
            obj.Bas_Pis = Convert.ToDouble(objDataReader["bas_Pis"]);
            obj.Vlr_Pis = Convert.ToDouble(objDataReader["vlr_Pis"]);
            obj.Bas_Cof = Convert.ToDouble(objDataReader["bas_Cof"]);
            obj.Vlr_Cof = Convert.ToDouble(objDataReader["vlr_Cof"]);
            obj.Nro_Linha = Convert.ToInt32(objDataReader["Nro_Linha"].ToString());
            obj.UsuarioInclusao = Convert.ToInt32(objDataReader["usuarioInclusao"]);
            obj.UsuarioAtualizacao = Convert.ToInt32(objDataReader["usuarioAtualizacao"]);
            obj.Data_Criacao = Convert.ToDateTime(objDataReader["Data_Criacao"]);
            try
            {
                obj.Data_Fechamento = Convert.ToDateTime(objDataReader["Data_Fechamento"]);
            }
            catch (Exception _)
            {
                obj.Data_Fechamento = null;
            }

            obj.Status = Convert.ToInt32(objDataReader["Status"]);
            return obj;
        }
        public List<NfeCabTrade> getAll(int Ordenacao, string Filtro)
        {

            NfeCabTrade obj = null;

            string strStringConexao = DataBase.RunCommand.connectionString;

            List<NfeCabTrade> lista = new List<NfeCabTrade>();

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

                                obj = new NfeCabTrade();

                                obj = PopulaNfeCabPobre(objDataReader);

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
        public async Task<List<Nfe_CabE_Qry_01>> getAllAsync(Filtro_NfeCabE Filtro, int Page, int TamPage, bool Contador)
        {
            List<Nfe_CabE_Qry_01> lista = new List<Nfe_CabE_Qry_01>();

            Nfe_CabE_Qry_01 obj = null;

            string strStringConexao = DataBase.RunCommand.connectionString;

            string strSelect = SelectNfeCabPage(Filtro, Page, TamPage, Contador);

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

                                    obj = new Nfe_CabE_Qry_01();

                                    obj = PopulaNfeCabEQry01(objDataReader);

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


            });

            return lista;

        }
        public async Task<int> getContadorSync(Filtro_NfeCabE Filtro, int Page, int TamPage)
        {

            int Retorno = 0;

            string strSelect = "";

            string strStringConexao = DataBase.RunCommand.connectionString;

            strSelect = SelectNfeCabPage(Filtro, Page, TamPage, true);

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

                                    Retorno = Convert.ToInt32(objDataReader["TOTAL"]);

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
        public string SqlGrid(int Ordenacao, string Filtro)
        {
            string Where = "";

            string OrderBy = "";

            string strSelect = "SELECT  " +
                               " ID, " +
                               " PLANILHA, " +
                               " SISTEMA, " +
                               " EMPRESA, " +
                               " LOCAL, " +
                               " CNPJ, " +
                               " QTD, " +
                               " VLR_CONTABIL, " +
                               " BAS_ICMS, " +
                               " VLR_ICMS, " +
                               " BAS_PIS, " +
                               " VLR_PIS, " +
                               " BAS_COF, " +
                               " VLR_COF, " +
                               " BAS_IPI, " +
                               " VLR_IPI, " +
                               " BAS_ICMS_ST, " +
                               " VLR_ICMS_ST, " +
                               " NRO_LINHA, " +
                               " USUARIOINCLUSAO, " +
                               " USUARIOATUALIZACAO," +
                               " DATA_CRIACAO," +
                               " DATA_FECHAMENTO," +
                               " STATUS " +
                                "FROM NFE_CAB_TRADE ";

            //Adiciona WHERE 
            if (Filtro.Trim() != "")
            {
                switch (Ordenacao)
                {
                    case 0:
                        Where = $"WHERE ID = {Filtro}";
                        break;
                    case 1:
                        Where = $"WHERE PLANILHA LIKE '%{Filtro.Trim()}%'";
                        break;
                    case 2:
                        Where = $"WHERE CNPJ ='{Filtro.Trim()}'";
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
                    OrderBy = $"ORDER BY PLANILHA ";
                    break;
                case 2:
                    OrderBy = $"ORDER BY CNPJ ";
                    break;
            }

            strSelect += $" {Where} {OrderBy} ";

            return strSelect;

        }
        private String SelectNfeCabPage(Filtro_NfeCabE Filtro, int Page, int TamPage, bool Contador)
        {

            string Where = "";

            string OrderBy = "";

            string strSelect = "";

            //Adiciona WHERE 

            if (Filtro.Id_Grupo != 0)
            {
                Where += Where == "" ? " where " : " and ";
                Where += $" CAB.ID_GRUPO = {Filtro.Id_Grupo} ";
            }

            if (Filtro.Id != 0)
            {
                Where += Where == "" ? " where " : " and ";
                Where += $" CAB.ID = {Filtro.Id} ";
            }

            if (Filtro.Planilha.Trim() != "")
            {
                Where += Where == "" ? " where " : " and ";
                Where += $" CAB.PLANILHA like '%{Filtro.Planilha.Trim()}%' ";
            }

            if (Filtro.Status != -1)
            {
                Where += Where == "" ? " where " : " and ";
                Where += $" CAB.STATUS = {Filtro.Status} ";
            }

            //Adiciona ORDER BY
            switch (Filtro.Ordenacao)
            {
                case 0:
                    OrderBy = $"ORDER BY CAB.ID";
                    break;
                case 1:
                    OrderBy = $"ORDER BY CAB.PLANILHA ";
                    break;

            }


            if (Contador)
            {
                strSelect = "SELECT count(*) AS TOTAL FROM NFE_CAB_TRADE CAB ";

                strSelect += $" {Where} ";

            }
            else
            {
                strSelect = "SELECT  " +
                               " CAB.ID_GRUPO, " +
                               " CAB.ID, " +
                               " CAB.PLANILHA, " +
                               " CAB.QTD, " +
                               " CAB.VLR_CONTABIL, " +
                               " CAB.BAS_ICMS, " +
                               " CAB.VLR_ICMS, " +
                               " CAB.BAS_PIS, " +
                               " CAB.VLR_PIS, " +
                               " CAB.BAS_COF, " +
                               " CAB.VLR_COF, " +
                               " CAB.NRO_LINHA, " +
                               " CAB.USUARIOINCLUSAO, " +
                               " CAB.USUARIOATUALIZACAO," +
                               " CAB.DATA_CRIACAO," +
                               " CAB.DATA_FECHAMENTO," +
                               " CAB.STATUS " +
                               "FROM NFE_CAB_TRADE CAB ";
                strSelect += $" {Where} ";
                strSelect += $" {OrderBy} ";
                strSelect += $" LIMIT {TamPage} OFFSET {((Page - 1) * TamPage)} ";
            }
            return strSelect;
        }
        //Nfe_Cab on file
        private String SelectNfeCabFile(Filtro_NfeCabE Filtro, string pasta, string file)
        {

            string Where = "";

            string OrderBy = "";

            string strSelect = "";

            //Adiciona WHERE 

            if (Filtro.Id_Grupo != 0)
            {
                Where += Where == "" ? " where " : " and ";
                Where += $" CAB.ID_GRUPO = {Filtro.Id_Grupo} ";
            }

            if (Filtro.Id != 0)
            {
                Where += Where == "" ? " where " : " and ";
                Where += $" CAB.ID = {Filtro.Id} ";
            }

            if (Filtro.Planilha.Trim() != "")
            {
                Where += Where == "" ? " where " : " and ";
                Where += $" CAB.PLANILHA like '%{Filtro.Planilha.Trim()}%' ";
            }

            if (Filtro.Status != -1)
            {
                Where += Where == "" ? " where " : " and ";
                Where += $" CAB.STATUS = {Filtro.Status} ";
            }

            //Adiciona ORDER BY
            switch (Filtro.Ordenacao)
            {
                case 0:
                    OrderBy = $"ORDER BY CAB.ID";
                    break;
                case 1:
                    OrderBy = $"ORDER BY CAB.PLANILHA ";
                    break;

            }

            strSelect = "COPY ( SELECT  " +
                           " CAB.ID_GRUPO as \"ID_GRUPO\", " +
                           " CAB.ID as \"ID\", " +
                           " CAB.PLANILHA as \"PLANILHA\" " +
                          $",{Coluna_Copy.NumericFormat("cab.qtd", 12, 4, "QTD")}" +
                          $",{Coluna_Copy.NumericFormat("cab.vlr_contabil", 12, 4, "VALOR_TOTAL")} " +
                          $",{Coluna_Copy.NumericFormat("cab.bas_icms", 12, 2, "BASE_ICMS")} " +
                          $",{Coluna_Copy.NumericFormat("cab.vlr_icms", 12, 2, "VLR_ICMS")} " +
                          $",{Coluna_Copy.NumericFormat("cab.bas_pis", 12, 2, "BASE_PIS")} " +
                          $",{Coluna_Copy.NumericFormat("cab.vlr_pis", 12, 2, "VLR_PIS")} " +
                          $",{Coluna_Copy.NumericFormat("cab.bas_cof", 12, 2, "BASE_COFINS")} " +
                          $",{Coluna_Copy.NumericFormat("cab.vlr_cof", 12, 2, "VLR_COFINS")} " +
                           ", CAB.NRO_LINHA as \"NRO_LINHA\" " +
                           ", CAB.USUARIOINCLUSAO as \"INCLUIDO\" " +
                           ", CAB.USUARIOATUALIZACAO as \"ALTERADO\" " +
                           ", CAB.DATA_CRIACAO  as \"DT_CRIAÇÃO\"  " +
                           ", CAB.DATA_FECHAMENTO as \"DT_FECHAMENTO\" " +
                           ", CAB.STATUS as \"STATUS\" " +
                           "FROM NFE_CAB_TRADE CAB ";
            strSelect += $" {Where} ";
            strSelect += $" {OrderBy} ";
            strSelect += $" ) To '{pasta}{file}.csv' With CSV DELIMITER ';'  HEADER  encoding 'latin1'; ";

            return strSelect;
        }
        public async Task<string> Planilha_Cabec(Filtro_NfeCabE Filtro, string pasta, string file)
        {
            string retorno = "Relatório Gravado Com Sucesso!";

            string strStringConexao = DataBase.RunCommand.connectionString;

            string strSelect = SelectNfeCabFile(Filtro, pasta, file);

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
    }
}
