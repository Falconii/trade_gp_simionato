using Npgsql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trade_GP.Models;

namespace Trade_GP.Dao.postgre
{
    class daoNfeDetTrade5910    
    {
        private async Task<int> calculo_saldoAsync(NpgsqlConnection conn,string strSql)
        {
            // Sua lógica para calcular o saldo aqui.
            // Este é apenas um exemplo fictício.
            using (var cmd = new NpgsqlCommand(strSql, conn))
            {
                return (int)await cmd.ExecuteScalarAsync();
            }
        }
        public void Delete(NfeDetTrade5910 obj)
        {

            try
            {
                String StringDelete = $" DELETE FROM  nfe_det_trade_5910  WHERE ID_GRUPO = {obj.Id_Grupo} AND AND ID_PLANILHA = {obj.Id_Planilha} AND NRO_LINHA = {obj.Nro_Linha} ";

                DataBase.RunCommand.CreateCommand(StringDelete);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteByIdPlanilha(int id_Grupo, int id_Planilha)
        {

            try
            {
                String StringDelete = $" DELETE FROM  nfe_det_trade_5910  WHERE ID_GRUPO = {id_Grupo} AND ID_PLANILHA = {id_Planilha} ";

                DataBase.RunCommand.CreateCommand(StringDelete);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
        public NfeDetTrade5910 Insert(NfeDetTrade5910 obj)
        {
            /*
            String StringInsert = $" INSERT INTO NFE_DET(ID_GRUPO,ID, NRO_LINHA, EMPRESA, LOCAL, DTLANC, DTNF, NRO, SERIE, UF, NR_ITEM, MATERIAL, DESCRICAO, NCM, UNID, CFOP, QTD, VLR_CONTABIL, VLR_UNIT, BAS_ICMS, VLR_ICMS, BAS_PIS, VLR_PIS, BAS_COF, VLR_COF, BAS_IPI, VLR_IPI, BAS_ICMS_ST, VLR_ICMS_ST, SERIE_OLD)   " +
            $" {obj.Id_Grupo} " +
            $",{obj.Id_Planilha}   " +
            $",{obj.Nro_Linha}   " +
            $",'{obj.Cod_Emp}'   " +
            $",'{obj.Local}'   " +
            $",'{obj.Dt_Doc.ToString("yyyy-MM-dd")}' " +
            $",'{obj.Dt_Lanc.ToString("yyyy-MM-dd")}' " +
            $",'{obj.Nro                    }'   " +
            $",'{obj.Serie                  }'   " +
            $",'{obj.Uf                     }'   " +
            $",'{obj.Nr_Item                }'   " +
            $",'{obj.Material               }'   " +
            $",'{obj.Descricao              }'   " +
            $",'{obj.Ncm                    }'   " +
            $",'{obj.Unid                   }'   " +
            $",'{obj.Cfop.Substring(0, 4)}'   " +
            $",{obj.Qtd.DoubleParseDb()     }    " +
            $",{obj.Vlr_Contabil.DoubleParseDb() }   " +
            $",{obj.Vlr_Unit.DoubleParseDb() }   " +
            $",'{obj.Sti}'   " +
            $",{obj.Bas_Icms.DoubleParseDb()}    " +
            $",{obj.Per_Icms.DoubleParseDb()}    " +
            $",{obj.Vlr_Icms.DoubleParseDb()}    " +
            $",'{obj.Stp}'   " +
            $",{obj.Bas_Pis.DoubleParseDb()}     " +
            $",{obj.Per_Pis.DoubleParseDb()}     " +
            $",{obj.Vlr_Pis.DoubleParseDb()}     " +
            $",'{obj.Stc}'   " +
            $",{obj.Bas_Cof.DoubleParseDb()}    " +
            $",{obj.Per_Cof.DoubleParseDb()}   " +
            $",{obj.Vlr_Cof.DoubleParseDb()}  " +
            $",'{obj.StIp}'   " +
            $",{obj.Bas_Ipi.DoubleParseDb()}    " +
            $",{obj.Per_Ipi.DoubleParseDb()}   " +
            $",{obj.Vlr_Ipi.DoubleParseDb()}  " +
            $",{obj.Bas_Icms_st.DoubleParseDb()}    " +
            $",{obj.Per_Icms_st.DoubleParseDb()}   " +
            $",{obj.Vlr_Icms_st.DoubleParseDb()}  " +
            $",{obj.Ncm}  ";
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

            */
            return obj;


        }
        public void Update(NfeDetTrade5910 obj)
        {
            /*
            String StringUpdate = $" UPDATE NFE_DET SET " +
            $"   ,EMPRESA                         = '{obj.Cod_Empresa                }'   " +
            $"   ,LOCAL                           = '{obj.Local                  }'   ";
            StringUpdate += obj.Dtlanc == null ? " ,DTLANC  = null " : $"   ,DTLANC  = '{obj.Dtlanc?.ToString("yyyy-MM-dd")}' ";
            StringUpdate += obj.Dtnf == null ? " ,DTNF    = null " : $"   ,DTNF    = '{obj.Dtnf?.ToString("yyyy-MM-dd")}' ";
            StringUpdate += $"   ,NRO                             = '{obj.Nro                    }'   " +
            $"   ,SERIE                           = '{obj.Serie                  }'   " +
            $"   ,UF                              = '{obj.Uf                     }'   " +
            $"   ,NR_ITEM                         = '{obj.Nr_Item                }'   " +
            $"   ,MATERIAL                        = '{obj.Material               }'   " +
            $"   ,DESCRICAO                       = '{obj.Descricao              }'   " +
            $"   ,NCM                             = '{obj.Ncm                    }'   " +
            $"   ,UNID                            = '{obj.Unid                   }'   " +
            $"   ,CFOP                            = '{obj.Cfop.Substring(0, 4)}'   " +
            $"   ,QTD                              =  {obj.Qtd.DoubleParseDb()     }    " +
            $"   ,VLR_CONTABIL                     =  {obj.Vlr_Contabil.DoubleParseDb() }   " +
            $"   ,VLR_UNIT                         =  {obj.Vlr_Unit.DoubleParseDb() }   " +
            $"   ,STI                              = '{obj.Sti}'   " +
            $"   ,BAS_ICMS                         = {obj.Bas_Icms.DoubleParseDb()}    " +
            $"   ,PER_ICMS                         = {obj.Per_Icms.DoubleParseDb()}    " +
            $"   ,VLR_ICMS                         = {obj.Vlr_Icms.DoubleParseDb()}    " +
            $"   ,STP                              = '{obj.Stp}'   " +
            $"   ,BAS_PIS                          = {obj.Bas_Pis.DoubleParseDb()}     " +
            $"   ,PER_PIS                          = {obj.Per_Pis.DoubleParseDb()}     " +
            $"   ,VLR_PIS                          = {obj.Vlr_Pis.DoubleParseDb()}     " +
            $"   ,STC                              = '{obj.Stc}'   " +
            $"   ,BAS_COF                          = {obj.Bas_Cof.DoubleParseDb()}    " +
            $"   ,PER_COF                          = {obj.Per_Cof.DoubleParseDb()}   " +
            $"   ,VLR_COF                          = {obj.Vlr_Cof.DoubleParseDb()}   " +
            $"   ,STIP                             = '{obj.StIp}'   " +
            $"   ,BAS_IPI                          = {obj.Bas_Ipi.DoubleParseDb()}    " +
            $"   ,PER_IPI                          = {obj.Per_Ipi.DoubleParseDb()}   " +
            $"   ,VLR_IPI                          = {obj.Vlr_Ipi.DoubleParseDb()}   " +
            $"   ,BAS_ICMS_ST                      = {obj.Bas_Icms_st.DoubleParseDb()}    " +
            $"   ,PER_ICMS_ST                      = {obj.Per_Icms_st.DoubleParseDb()}   " +
            $"   ,VLR_ICMS_ST                      = {obj.Vlr_Icms_st.DoubleParseDb()}   " +
            $" WHERE ID_GRUPO = {obj.Id_Grupo} AND ID =  {obj.Id} AND NRO_LINHA = {obj.NroLinha}";

            Console.WriteLine(StringUpdate);

            try
            {

                DataBase.RunCommand.CreateCommand(StringUpdate);

            }
            catch (ExceptionErroImportacao ex)
            {
                MessageBox.Show(ex.Message, "Atenção!");
            }
            */
        }
        public async Task<int> Check_Devolucaox(int id_grupo, string cod_emp, string local, string periodo)
        {

            int Nro_Dev = 0;

            String StringProc = $"select * from check_devolucaox({id_grupo},'{cod_emp}','{local}','{periodo}');";


            string strStringConexao = DataBase.RunCommand.connectionString;

            await Task.Run(() =>
            {
                using (var objConexao = new NpgsqlConnection(strStringConexao))
                {
                    using (var objCommand = new NpgsqlCommand(StringProc, objConexao))
                    {
                        try
                        {
                            objConexao.Open();

                            var objDataReader = objCommand.ExecuteReader();

                            if (objDataReader.HasRows)
                            {

                                while (objDataReader.Read())
                                {

                                    Nro_Dev = Convert.ToInt32(objDataReader["_qtd_dev"]);

                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Atenção!");

                            Nro_Dev = -1;
                        }
                        finally
                        {
                            objConexao.Dispose();
                        }
                    }
                }

            });

            return Nro_Dev;

        }

        public async Task<int> Check_Devolucao2x(int id_grupo, string cod_emp, string local, string periodo)
        {

            int Nro_Dev = 0;

            String StringProc = $"select * from check_devolucao2x({id_grupo},'{cod_emp}','{local}','{periodo}');";

            string strStringConexao = DataBase.RunCommand.connectionString;

            await Task.Run(() =>
            {
                using (var objConexao = new NpgsqlConnection(strStringConexao))
                {
                    using (var objCommand = new NpgsqlCommand(StringProc, objConexao))
                    {
                        try
                        {
                            objConexao.Open();

                            var objDataReader = objCommand.ExecuteReader();

                            if (objDataReader.HasRows)
                            {

                                while (objDataReader.Read())
                                {

                                    Nro_Dev = Convert.ToInt32(objDataReader["_qtd_dev"]);

                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Atenção!");

                            Nro_Dev = -1;
                        }
                        finally
                        {
                            objConexao.Dispose();
                        }
                    }
                }

            });

            return Nro_Dev;

        }

        public async Task<int> Check_Devx(int id_grupo, string cod_emp, string local, string periodo)
        {

            int Nro_Dev = 0;

            String StringProc = $"select * from check_devx({id_grupo},'{cod_emp}','{local}','{periodo}');";

            string strStringConexao = DataBase.RunCommand.connectionString;

            await Task.Run(() =>
            {
                using (var objConexao = new NpgsqlConnection(strStringConexao))
                {
                    using (var objCommand = new NpgsqlCommand(StringProc, objConexao))
                    {
                        try
                        {
                            objConexao.Open();

                            var objDataReader = objCommand.ExecuteReader();

                            if (objDataReader.HasRows)
                            {

                                while (objDataReader.Read())
                                {

                                    Nro_Dev = Convert.ToInt32(objDataReader["_qtd_dev"]);

                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Atenção!");

                            Nro_Dev = -1;
                        }
                        finally
                        {
                            objConexao.Dispose();
                        }
                    }
                }

            });

            return Nro_Dev;

        }
        public async Task<int> Processou_Devolucao(int id_grupo, string cod_emp, string local, string periodo)
        {

            int total = -1;

            String StringProc = $"SELECT COUNT(*) AS TOTAL FROM nfe_det_trade_5910 dev where dev.id_grupo = '{id_grupo}' and dev.cod_emp = '{cod_emp}' and dev.local = '{local}' and dev.id_operacao = 'Z' and to_char(dev.dt_ref,'MM/YYYY') = '{periodo}' and dev.dt_ref >= '2017-03-16' AND dev.id_saida = 0;";

            string strStringConexao = DataBase.RunCommand.connectionString;

            await Task.Run(() =>
            {
                using (var objConexao = new NpgsqlConnection(strStringConexao))
                {
                    using (var objCommand = new NpgsqlCommand(StringProc, objConexao))
                    {
                        try
                        {
                            objConexao.Open();

                            var objDataReader = objCommand.ExecuteReader();

                            if (objDataReader.HasRows)
                            {

                                while (objDataReader.Read())
                                {

                                    total = Convert.ToInt32(objDataReader["TOTAL"]);

                                }
                            }

                        }

                        catch (NpgsqlException ex)
                        {
                            MessageBox.Show($"Erro no PostgreSQL: {ex.Message}");
                        }
                        catch (InvalidOperationException ex)
                        {
                            MessageBox.Show($"Operação inválida: {ex.Message}");
                        }
                        catch (TimeoutException ex)
                        {
                            MessageBox.Show($"Tempo de espera esgotado: {ex.Message}");
                        }
                        catch (IOException ex)
                        {
                            MessageBox.Show($"Erro de I/O: {ex.Message}");
                        }
                        catch (ArgumentException ex)
                        {
                            MessageBox.Show($"Argumento inválido: {ex.Message}");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Erro inesperado: {ex.Message}");
                        }
                        finally
                        {
                            objConexao.Dispose();
                        }
                    }
                }

            });

            return total;

        }

        public async Task<int> Conta_Nfe_Saida(int id_grupo, string cod_emp, string local, string periodo)
        {

            int Nro_Notas = 0;

            String StringProc = "SELECT COALESCE(COUNT(*),0) AS TOTAL " +
                                "FROM nfe_det_trade_5910 DET " +
                                $"WHERE  DET.id_grupo = {id_grupo} and DET.cod_emp = '{cod_emp}' and Det.local = '{local}' " + 
                                $"and ((det.id_operacao = 'S' and det.status = '0') OR (det.id_operacao = 'Z' and det.status = '0')) " +
                                $"and (TO_CHAR(det.dt_ref,'MM/YYYY') = '{periodo}' ) ";


            string strStringConexao = DataBase.RunCommand.connectionString;

            await Task.Run(() =>
            {
                using (var objConexao = new NpgsqlConnection(strStringConexao))
                {
                    using (var objCommand = new NpgsqlCommand(StringProc, objConexao))
                    {
                        try
                        {
                            objConexao.Open();

                            var objDataReader = objCommand.ExecuteReader();

                            if (objDataReader.HasRows)
                            {

                                while (objDataReader.Read())
                                {

                                    Nro_Notas = Convert.ToInt32(objDataReader["TOTAL"]);

                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Atenção!");

                            Nro_Notas = -1;
                        }
                        finally
                        {
                            objConexao.Dispose();
                        }
                    }
                }

            });

            return Nro_Notas;

        }

        public async Task<int> Conta_Nfe_Saida_Val(int id_grupo, string cod_emp, string local, string periodo)
        {

            int Nro_Notas = 0;

            String StringProc = "SELECT COALESCE(COUNT(*),0) AS TOTAL " +
                                "FROM nfe_det_trade_5910 DET " +
                                $"WHERE  DET.id_grupo = {id_grupo} and DET.cod_emp = '{cod_emp}' and Det.local = '{local}' " +
                                $"and ((det.id_operacao = 'S' and det.status = '1' AND det.quantidade_1  <>  det.saldo)) " +
                                $"and (TO_CHAR(det.dt_ref,'MM/YYYY') = '{periodo}' ) ";


            string strStringConexao = DataBase.RunCommand.connectionString;

            await Task.Run(() =>
            {
                using (var objConexao = new NpgsqlConnection(strStringConexao))
                {
                    using (var objCommand = new NpgsqlCommand(StringProc, objConexao))
                    {
                        try
                        {
                            objConexao.Open();

                            var objDataReader = objCommand.ExecuteReader();

                            if (objDataReader.HasRows)
                            {

                                while (objDataReader.Read())
                                {

                                    Nro_Notas = Convert.ToInt32(objDataReader["TOTAL"]);

                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Atenção!");

                            Nro_Notas = -1;
                        }
                        finally
                        {
                            objConexao.Close();
                        }
                    }
                }

            });

            return Nro_Notas;

        }

        public async Task<int> Conta_Nfe_Saida_Saldos(int id_grupo, string cod_emp, string local, string periodo)
        {

            int Nro_Notas = 0;
            /*
            String StringProc = "SELECT COALESCE(COUNT(*),0) AS TOTAL " +
                                "FROM nfe_det_trade_5910 DET  " +
                                $"WHERE  DET.id_grupo = {id_grupo} and DET.cod_emp = '{cod_emp}'  and Det.local  = '{local}' and((det.id_operacao = 'S' and det.status = '0') OR(det.id_operacao = 'Z' and det.status = '0')) and(TO_CHAR(det.dt_ref, 'MM/YYYY') = '{periodo}')";
            */

            String StringProc = "SELECT COALESCE(COUNT(det.*),0) AS TOTAL " +
            " FROM nfe_det_trade_5910 DET " +
            " LEFT  JOIN de_para     depara on depara.id_grupo = det.id_grupo and depara.cod_emp = det.cod_emp and depara.local = det.local and depara.de_material = det.material " +
            $" WHERE DET.id_grupo = {id_grupo} and DET.cod_emp = '{cod_emp}' and Det.local = '{local}' and " +
            "   ( " +
            "       (((det.id_operacao = 'S') OR(det.id_operacao = 's'))  and det.status = '0') " +
            "        OR " +
            "       (((det.id_operacao = 'Z') OR(det.id_operacao = 'Y'))  and det.status = '0') " +
            "   ) " +
            $"   and(TO_CHAR(det.dt_ref, 'MM/YYYY') = '{periodo}') ";

            string strStringConexao = DataBase.RunCommand.connectionString;

            await Task.Run(() =>
            {
                using (var objConexao = new NpgsqlConnection(strStringConexao))
                {
                    using (var objCommand = new NpgsqlCommand(StringProc, objConexao))
                    {
                        try
                        {
                            objConexao.Open();

                            var objDataReader = objCommand.ExecuteReader();

                            if (objDataReader.HasRows)
                            {

                                while (objDataReader.Read())
                                {
                                   
                                    Nro_Notas = Convert.ToInt32(objDataReader["TOTAL"]);

                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Atenção!");

                            Nro_Notas = -1;
                        }
                        finally
                        {
                            objConexao.Dispose();
                        }
                    }
                }

            });

            return Nro_Notas;

        }
        public async Task<List<ContadorModel>> Conta_Nfe_Saida_SaldosByDay(int id_grupo, string cod_emp, string local, string periodo)
        {

            List<ContadorModel> lista = new List<ContadorModel>();

            String StringProc = "SELECT det.id_grupo,det.cod_emp,det.local,det.dt_ref,COALESCE(COUNT(det.*), 0) AS TOTAL  FROM nfe_det_trade_5910 DET " +
                                "LEFT  JOIN de_para     depara on depara.id_grupo = det.id_grupo and depara.cod_emp = det.cod_emp and depara.local = det.local and depara.de_material = det.material " +
                               $"WHERE DET.id_grupo = {id_grupo} and DET.cod_emp = '{cod_emp}' and Det.local IN ('{local}') and " +
                                "    ((((det.id_operacao = 'S'))  and det.status = '0') " +
                                " OR " +
                                "    (((det.id_operacao = 'Z'))  and det.status = '0') ) and " +  
                               $" det.dt_ref >= '2017-03-16' and (TO_CHAR(det.dt_ref, 'MM/YYYY') IN ('{periodo}')) " +
                                " group by det.id_grupo,det.cod_emp,det.local,det.dt_ref " +
                                " order by det.id_grupo,det.cod_emp,det.local,det.dt_ref ";

            string strStringConexao = DataBase.RunCommand.connectionString;

            await Task.Run(() =>
            {
                using (var objConexao = new NpgsqlConnection(strStringConexao))
                {
                    using (var objCommand = new NpgsqlCommand(StringProc, objConexao))
                    {
                        try
                        {
                            objConexao.Open();

                            var objDataReader = objCommand.ExecuteReader();

                            if (objDataReader.HasRows)
                            {

                                while (objDataReader.Read())
                                {
                                    ContadorModel contador = new ContadorModel();
                                    contador.local = objDataReader["LOCAL"].ToString();
                                    try
                                    {
                                        contador.notas = Convert.ToInt32(objDataReader["TOTAL"]);
                                    }
                                    catch
                                    {
                                        contador.notas = 0;
                                    }
                                    try
                                    {
                                        contador.dt_ref = Convert.ToDateTime(objDataReader["dt_ref"]);
                                    }
                                    catch
                                    {
                                        contador.dt_ref = DateTime.Now; 
                                    }
                                    contador.ano = contador.dt_ref.Year;
                                    contador.mes = contador.dt_ref.Month;
                                    lista.Add(contador);
                                }
                            }

                        }
                        catch (NpgsqlException ex)
                        {
                            MessageBox.Show($"Erro no PostgreSQL: {ex.Message}");
                        }
                        catch (InvalidOperationException ex)
                        {
                            MessageBox.Show($"Operação inválida: {ex.Message}");
                        }
                        catch (TimeoutException ex)
                        {
                            MessageBox.Show($"Tempo de espera esgotado: {ex.Message}");
                        }
                        catch (IOException ex)
                        {
                            MessageBox.Show($"Erro de I/O: {ex.Message}");
                        }
                        catch (ArgumentException ex)
                        {
                            MessageBox.Show($"Argumento inválido: {ex.Message}");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Erro inesperado: {ex.Message}");
                        }
                        finally
                        {
                            objConexao.Dispose();
                        }
                    }
                }

            });

            return lista;

        }
        public async Task<List<ContadorModel>> Conta_Nfe_ValoresByDay(int id_grupo, string cod_emp, string local, string periodo)
        {

            List<ContadorModel> lista = new List<ContadorModel>();


            String StringProc = "SELECT             ven.id_grupo,ven.cod_emp,ven.local,ven.dt_ref,COALESCE(COUNT(ven.*), 0) AS TOTAL  "+
                                "  from controle_e con " +
                                "  inner " +
                                "  join nfe_det_trade_5910 ven on ven.id_grupo = con.id_grupo and ven.id_planilha = con.id_s and ven.nro_linha = con.nro_linha_s " +
                                "  inner join nfe_det_trade_5910 ent on ent.id_grupo = con.id_grupo and ent.id_planilha = con.id_e and ent.nro_linha = con.nro_linha_e " +
                               $"  where con.id_grupo = {id_grupo} and con.id_fechamento = 1 and con.qtd_e > 0 and VEN.cod_emp = '{cod_emp}' and VEN.LOCAL IN ('{local}')  and ven.dt_ref >= '2017-03-16' and to_char(VEN.dt_ref,'MM/YYYY')  IN ('{periodo}')  and VEN.STATUS = '1' and VEN.ID_OPERACAO = 'S'  and con.id_fechamento = 1 " +
                                "  group by ven.id_grupo,ven.cod_emp,ven.local,ven.dt_ref "+
                                "  order by ven.id_grupo,ven.cod_emp,ven.local,ven.dt_ref ";
    
            string strStringConexao = DataBase.RunCommand.connectionString;

            await Task.Run(() =>
            {
                using (var objConexao = new NpgsqlConnection(strStringConexao))
                {
                    using (var objCommand = new NpgsqlCommand(StringProc, objConexao))
                    {
                        try
                        {
                            objConexao.Open();

                            var objDataReader = objCommand.ExecuteReader();

                            if (objDataReader.HasRows)
                            {

                                while (objDataReader.Read())
                                {
                                    ContadorModel contador = new ContadorModel();
                                    contador.local = objDataReader["LOCAL"].ToString();
                                    try
                                    {
                                        contador.notas = Convert.ToInt32(objDataReader["TOTAL"]);
                                    }
                                    catch
                                    {
                                        contador.notas = 0;
                                    }
                                    try
                                    {
                                        contador.dt_ref = Convert.ToDateTime(objDataReader["dt_ref"]);
                                    }
                                    catch
                                    {
                                        contador.dt_ref = DateTime.Now;
                                    }
                                    contador.ano = contador.dt_ref.Year;
                                    contador.mes = contador.dt_ref.Month;
                                    lista.Add(contador);
                                }
                            }

                        }
                        catch (NpgsqlException ex)
                        {
                            MessageBox.Show($"Erro no PostgreSQL: {ex.Message}");
                        }
                        catch (InvalidOperationException ex)
                        {
                            MessageBox.Show($"Operação inválida: {ex.Message}");
                        }
                        catch (TimeoutException ex)
                        {
                            MessageBox.Show($"Tempo de espera esgotado: {ex.Message}");
                        }
                        catch (IOException ex)
                        {
                            MessageBox.Show($"Erro de I/O: {ex.Message}");
                        }
                        catch (ArgumentException ex)
                        {
                            MessageBox.Show($"Argumento inválido: {ex.Message}");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Erro inesperado: {ex.Message}");
                        }
                        finally
                        {
                            objConexao.Dispose();
                        }
                    }
                }

            });

            return lista;

        }
        public async Task<string> Saldos(int id_grupo, string cod_emp, string local, string periodo)
        {

            string _saida = "";

            String StringProc = $"select * from calculo_saldo({id_grupo},'{cod_emp}','{local}','{periodo}', 1) ";

            string strStringConexao = DataBase.RunCommand.connectionString;

            await Task.Run(() =>
            {
                using (var objConexao = new NpgsqlConnection(strStringConexao))
                {
                    using (var objCommand = new NpgsqlCommand(StringProc, objConexao))
                    {
                        try
                        {
                            objConexao.Open();

                            var objDataReader = objCommand.ExecuteReader();

                            if (objDataReader.HasRows)
                            {

                                while (objDataReader.Read())
                                {

                                    _saida  = objDataReader["_saida"].ToString();

                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Atenção!");

                            _saida = "Falha No Processamento!";
                        }
                        finally
                        {
                            objConexao.Dispose();
                        }
                    }
                }

            });

            return _saida;

        }
        public async Task<int> Saldosv2(int id_grupo, string cod_emp, string local, string periodo)
        {

            int _saida = 0;

            String StringProc = $"select * from calculo_saldov2({id_grupo},'{cod_emp}','{local}','{periodo}', 1) ";

            string strStringConexao = DataBase.RunCommand.connectionString;

            await Task.Run(() =>
            {
                using (var objConexao = new NpgsqlConnection(strStringConexao))
                {
                    using (var objCommand = new NpgsqlCommand(StringProc, objConexao))
                    {
                        try
                        {
                            objConexao.Open();

                            var objDataReader = objCommand.ExecuteReader();

                            if (objDataReader.HasRows)
                            {

                                while (objDataReader.Read())
                                {

                                    _saida = Convert.ToInt32(objDataReader["_saida"]);

                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Atenção!");

                            _saida =  -1;
                        }
                        finally
                        {
                            objConexao.Dispose();
                        }
                    }
                }

            });

            return _saida;

        }

        public async Task<int> Saldosv2X(int id_grupo, string cod_emp, string local, string periodo)
        {
            // Defina a string de conexão. Atualize com as informações do seu banco de dados.
            string connString = DataBase.RunCommand.connectionString;


            String StringProc = $"select * from calculo_saldov2({id_grupo},'{cod_emp}','{local}','{periodo}', 1) ";
            //String StringProc = $"select * from atualizar_saldo({id_grupo},'{cod_emp}','{local}','{periodo}', 1) "; 
            int _saida = 0;

            using (var conn = new NpgsqlConnection(connString))
            {
                try
                {
                    // Abra a conexão
                    await conn.OpenAsync();
                    Console.WriteLine("Conexão aberta com sucesso!");

                    // Chame a função calculo_saldo() de forma assíncrona
                    _saida = await calculo_saldoAsync(conn, StringProc);

                    Console.WriteLine("Saldo calculado: " + _saida);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao abrir a conexão: " + ex.Message);
                }
                finally
                {
                    // Feche a conexão
                    await conn.DisposeAsync();
                    Console.WriteLine("Conexão fechada com sucesso!");
                }
            }

            return _saida;
        }

    public async Task<string> Vlr_Economico(int id_grupo, string cod_emp, string local, string periodo, int ano_selic, int mes_selic)
        {

            string _saida = "";

            String StringProc = $"select * from vlr_enconomico({id_grupo},'{cod_emp}','{local}','{periodo}', {ano_selic},{mes_selic}) ";

            string strStringConexao = DataBase.RunCommand.connectionString;

            await Task.Run(() =>
            {
                using (var objConexao = new NpgsqlConnection(strStringConexao))
                {
                    using (var objCommand = new NpgsqlCommand(StringProc, objConexao))
                    {
                        try
                        {
                            objConexao.Open();

                            var objDataReader = objCommand.ExecuteReader();

                            if (objDataReader.HasRows)
                            {

                                while (objDataReader.Read())
                                {

                                    _saida = objDataReader["_saida"].ToString();

                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Atenção!");

                            _saida = "Falha No Processamento!";
                        }
                        finally
                        {
                            objConexao.Dispose();
                        }
                    }
                }

            });

            return _saida;

        }

        public async Task<int> Vlr_Economico_V2(int id_grupo, string cod_emp, string local, string periodo, int ano_selic, int mes_selic)
        {

            int _saida = 0;

            String StringProc = $"select * from vlr_enconomico_V2({id_grupo},'{cod_emp}','{local}','{periodo}', {ano_selic},{mes_selic}) ";

            string strStringConexao = DataBase.RunCommand.connectionString;

            await Task.Run(() =>
            {
                using (var objConexao = new NpgsqlConnection(strStringConexao))
                {
                    using (var objCommand = new NpgsqlCommand(StringProc, objConexao))
                    {
                        try
                        {
                            objConexao.Open();

                            var objDataReader = objCommand.ExecuteReader();

                            if (objDataReader.HasRows)
                            {

                                while (objDataReader.Read())
                                {

                                    _saida = Convert.ToInt32(objDataReader["_saida"]); 

                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Atenção!");

                            _saida = -1;
                        }
                        finally
                        {
                            objConexao.Dispose();
                        }
                    }
                }

            });

            return _saida;

        }

        public async Task<int> Vlr_Economico_V3(int id_grupo, string cod_emp, string local, string periodo, int ano_selic, int mes_selic)
        {

            int _saida = 0;

            String StringProc = $"select * from vlr_enconomico_V3({id_grupo},'{cod_emp}','{local}','{periodo}', {ano_selic},{mes_selic}) ";

            string strStringConexao = DataBase.RunCommand.connectionString;

            await Task.Run(() =>
            {
                using (var objConexao = new NpgsqlConnection(strStringConexao))
                {
                    using (var objCommand = new NpgsqlCommand(StringProc, objConexao))
                    {
                        try
                        {
                            objConexao.Open();

                            var objDataReader = objCommand.ExecuteReader();

                            if (objDataReader.HasRows)
                            {

                                while (objDataReader.Read())
                                {

                                    _saida = Convert.ToInt32(objDataReader["_saida"]);

                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Atenção!");

                            _saida = -1;
                        }
                        finally
                        {
                            objConexao.Dispose();
                        }
                    }
                }

            });

            return _saida;

        }

        public async Task<int> atualizacao_selic(int id_grupo, string cod_emp, string local, string periodo, int ano_selic, int mes_selic)
        {

            int _saida = 0;

            String StringProc = $"select * from atualizacao_selic({id_grupo},'{cod_emp}','{local}','{periodo}', {ano_selic},{mes_selic}) ";

            string strStringConexao = DataBase.RunCommand.connectionString;

            await Task.Run(() =>
            {
                using (var objConexao = new NpgsqlConnection(strStringConexao))
                {
                    using (var objCommand = new NpgsqlCommand(StringProc, objConexao))
                    {
                        try
                        {
                            objConexao.Open();

                            var objDataReader = objCommand.ExecuteReader();

                            if (objDataReader.HasRows)
                            {

                                while (objDataReader.Read())
                                {

                                    _saida = Convert.ToInt32(objDataReader["_saida"]);

                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Atenção!");

                            _saida = -1;
                        }
                        finally
                        {
                            objConexao.Dispose();
                        }
                    }
                }

            });

            return _saida;

        }


        public async Task<int> TemAutomacao()
        {

            int TOTAL  = 0;

            String StringProc = "select count(*) as TOTAL from automacao where processado = 'N'; ";

            string strStringConexao = DataBase.RunCommand.connectionString;

            await Task.Run(() =>
            {
                using (var objConexao = new NpgsqlConnection(strStringConexao))
                {
                    using (var objCommand = new NpgsqlCommand(StringProc, objConexao))
                    {
                        try
                        {
                            objConexao.Open();

                            var objDataReader = objCommand.ExecuteReader();

                            if (objDataReader.HasRows)
                            {

                                while (objDataReader.Read())
                                {

                                    TOTAL = Convert.ToInt32(objDataReader["TOTAL"]);

                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Atenção!");

                            TOTAL = -1;
                        }
                        finally
                        {
                            objConexao.Dispose();
                        }
                    }
                }

            });

            return TOTAL;

        }


       

        public async Task<int> vlr_enconomico_c(int id_grupo, string cod_emp, string local, string periodo, int ano_selic, int mes_selic)
        {

            int _saida = 0;

            String StringProc = $"select * from vlr_enconomico_c({id_grupo},'{cod_emp}','{local}','{periodo}', {ano_selic},{mes_selic}) ";

            string strStringConexao = DataBase.RunCommand.connectionString;

            await Task.Run(() =>
            {
                using (var objConexao = new NpgsqlConnection(strStringConexao))
                {
                    using (var objCommand = new NpgsqlCommand(StringProc, objConexao))
                    {
                        try
                        {
                            objConexao.Open();

                            var objDataReader = objCommand.ExecuteReader();

                            if (objDataReader.HasRows)
                            {

                                while (objDataReader.Read())
                                {

                                    _saida =  Convert.ToInt32(objDataReader["_saida"]);

                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Atenção!");

                            _saida = -1;
                        }
                        finally
                        {
                            objConexao.Dispose();
                        }
                    }
                }

            });

            return _saida;

        }

        public async Task<List<ContadorModel>> Conta_Nfe_DevolucoesByDay(int id_grupo, string cod_emp, string local, string periodo)
        {

            List<ContadorModel> lista = new List<ContadorModel>();

            String StringProc = "SELECT   dev.id_grupo, dev.cod_emp, dev.local,dev.id_operacao,dev.dt_ref,count(*) AS TOTAL " +
                                "FROM nfe_det_trade_5910 dev " +
                                $"WHERE dev.id_grupo = {id_grupo} and dev.cod_emp = '{cod_emp}' and dev.local IN ('{local}') and " +
                                $"      (((dev.id_operacao = 'Z')) and dev.id_saida = 0 ) " +
                                $"      and dt_ref >= '2017-03-16' and (TO_CHAR(dev.dt_ref, 'MM/YYYY') IN('{periodo}') ) " +
                                 "      group by dev.id_grupo,dev.cod_emp,dev.local,dev.id_operacao,dev.dt_ref " +
                                 "      order by dev.id_grupo,dev.cod_emp,dev.local,dev.id_operacao,dev.dt_ref ";

            string strStringConexao = DataBase.RunCommand.connectionString;

            await Task.Run(() =>
            {
                using (var objConexao = new NpgsqlConnection(strStringConexao))
                {
                    using (var objCommand = new NpgsqlCommand(StringProc, objConexao))
                    {
                        try
                        {
                            objConexao.Open();

                            var objDataReader = objCommand.ExecuteReader();

                            if (objDataReader.HasRows)
                            {

                                while (objDataReader.Read())
                                {
                                    ContadorModel contador = new ContadorModel();
                                    contador.local = objDataReader["LOCAL"].ToString();
                                    try
                                    {
                                        contador.notas = Convert.ToInt32(objDataReader["TOTAL"]);
                                    }
                                    catch
                                    {
                                        contador.notas = 0;
                                    }
                                    try
                                    {
                                        contador.dt_ref = Convert.ToDateTime(objDataReader["dt_ref"]);
                                    }
                                    catch
                                    {
                                        contador.dt_ref = DateTime.Now;
                                    }
                                    contador.ano = contador.dt_ref.Year;
                                    contador.mes = contador.dt_ref.Month;
                                    lista.Add(contador);
                                }
                            }

                        }
                        catch (NpgsqlException ex)
                        {
                            MessageBox.Show($"Erro no PostgreSQL: {ex.Message}");
                        }
                        catch (InvalidOperationException ex)
                        {
                            MessageBox.Show($"Operação inválida: {ex.Message}");
                        }
                        catch (TimeoutException ex)
                        {
                            MessageBox.Show($"Tempo de espera esgotado: {ex.Message}");
                        }
                        catch (IOException ex)
                        {
                            MessageBox.Show($"Erro de I/O: {ex.Message}");
                        }
                        catch (ArgumentException ex)
                        {
                            MessageBox.Show($"Argumento inválido: {ex.Message}");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Erro inesperado: {ex.Message}");
                        }
                        finally
                        {
                            objConexao.Dispose();
                        }
                    }
                }

            });

            return lista;

        }
    }





    /*

    public NfeDetTrade5910 Seek(int id_grupo, int id, int nrolinha)
    {

        NfeDetTrade5910 obj = null;

        string strStringConexao = DataBase.RunCommand.connectionString;

        string strSelect = $"SELECT * FROM NFE_DET WHERE ID_GRUPO = {id_grupo} AND ID = {id} AND NRO_LINHA ={nrolinha}";

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

                        obj = new NfeDetTrade5910();

                        obj = PopulaNfeDetFull(objDataReader);


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
    public NfeDetTrade5910 SeekNfeConsulta(int id, int nrolinha)
    {

        NfeDetTrade5910 obj = null;

        string strStringConexao = DataBase.RunCommand.connectionString;

        string strSelect = $"SELECT * FROM NFE_DET WHERE ID = {id} AND NRO_LINHA ={nrolinha}";

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

                        obj = new NfeDetTrade5910();

                        obj = PopulaNfeDet(objDataReader);


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
    private NfeDetTrade5910 PopulaNfeDet(NpgsqlDataReader objDataReader)
    {

        var obj = new NfeDetTrade5910();
        obj.Id_Grupo = Convert.ToInt32(objDataReader["id_grupo"].ToString());
        obj.Id = Convert.ToInt32(objDataReader["id"].ToString());
        obj.NroLinha = Convert.ToInt32(objDataReader["nro_linha"].ToString());
        obj.Cod_Empresa = objDataReader["empresa"].ToString();
        obj.Local = objDataReader["local"].ToString();
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
        return obj;
    }
    private NfeDetTrade5910 PopulaNfeDetFull(NpgsqlDataReader objDataReader)
    {

        var obj = new NfeDetTrade5910();
        obj.Id = Convert.ToInt32(objDataReader["id"].ToString());
        obj.Cod_Empresa = objDataReader["empresa"].ToString();
        obj.Local = objDataReader["local"].ToString();
        obj.NroLinha = Convert.ToInt32(objDataReader["nro_linha"].ToString());
        try
        {
            obj.Dtlanc = Convert.ToDateTime(objDataReader["dtlanc"]);
        }
        catch
        {
            obj.Dtlanc = null;
        }
        try
        {
            obj.Dtnf = Convert.ToDateTime(objDataReader["dtnf"]);
        }
        catch
        {
            obj.Dtnf = null;
        }
        obj.Nro = objDataReader["nro"].ToString();
        obj.Serie = objDataReader["serie"].ToString();
        obj.Uf = objDataReader["uf"].ToString();
        obj.Nr_Item = objDataReader["nr_item"].ToString();
        obj.Material = objDataReader["material"].ToString();
        obj.Descricao = objDataReader["descricao"].ToString();
        obj.Ncm = objDataReader["ncm"].ToString();
        obj.Unid = objDataReader["unid"].ToString();
        obj.Cfop = objDataReader["cfop"].ToString();
        obj.Qtd = Convert.ToDouble(objDataReader["Qtd"]);
        obj.Vlr_Contabil = Convert.ToDouble(objDataReader["Vlr_Contabil"]);
        obj.Sti = objDataReader["Sti"].ToString();
        obj.Bas_Icms = Convert.ToDouble(objDataReader["bas_Icms"]);
        obj.Per_Icms = Convert.ToDouble(objDataReader["Per_Icms"]);
        obj.Vlr_Icms = Convert.ToDouble(objDataReader["Vlr_Icms"]);
        obj.Stp = objDataReader["Stp"].ToString();
        obj.Bas_Pis = Convert.ToDouble(objDataReader["Bas_Pis"]);
        obj.Per_Pis = Convert.ToDouble(objDataReader["Per_Pis"]);
        obj.Vlr_Pis = Convert.ToDouble(objDataReader["Vlr_Pis"]);
        obj.Stc = objDataReader["Stc"].ToString();
        obj.Bas_Cof = Convert.ToDouble(objDataReader["Bas_Cof"]);
        obj.Per_Cof = Convert.ToDouble(objDataReader["Per_Cof"]);
        obj.Vlr_Cof = Convert.ToDouble(objDataReader["Vlr_Cof"]);
        obj.StIp = objDataReader["StIp"].ToString();
        obj.Bas_Ipi = Convert.ToDouble(objDataReader["Bas_Ipi"]);
        obj.Per_Ipi = Convert.ToDouble(objDataReader["Per_Ipi"]);
        obj.Vlr_Ipi = Convert.ToDouble(objDataReader["Vlr_Ipi"]);
        obj.Bas_Icms_st = Convert.ToDouble(objDataReader["Bas_Icms_st"]);
        obj.Per_Icms_st = Convert.ToDouble(objDataReader["Per_Icms_st"]);
        obj.Vlr_Icms_st = Convert.ToDouble(objDataReader["Vlr_Icms_st"]);

        return obj;
    }
    private Nfe_DetE_Qry_01 PopulaNfe_DetE_Qry_01(NpgsqlDataReader objDataReader)
    {

        var obj = new Nfe_DetE_Qry_01();

        obj.Id_Fechamento = Convert.ToInt32(objDataReader["id_fechamento"]);
        obj.Desc_Fechamento = objDataReader["desc_fechamento"].ToString();
        obj.Ven_Empresa = objDataReader["ven_empresa"].ToString();
        obj.Ven_Ano = Convert.ToInt32(objDataReader["ven_ano"]);
        obj.Ven_Id = Convert.ToInt32(objDataReader["ven_id"]);
        obj.Ven_Nro_Linha = Convert.ToInt32(objDataReader["ven_nro_linha"]);
        obj.Ven_Chave = objDataReader["ven_chave"].ToString();
        obj.Ven_Cod_Empresa = objDataReader["ven_cod_empresa"].ToString();
        obj.Ven_Local = objDataReader["ven_local"].ToString();
        obj.Ven_Id_Planilha = objDataReader["ven_id_planilha"].ToString();
        try
        {
            obj.Ven_Dtlanc = Convert.ToDateTime(objDataReader["ven_dtlanc"]);
        }
        catch
        {
            obj.Ven_Dtlanc = null;
        }
        try
        {
            obj.Ven_Dtnf = Convert.ToDateTime(objDataReader["ven_dtnf"]);
        }
        catch
        {
            obj.Ven_Dtnf = null;
        }
        obj.Ven_Nro = objDataReader["ven_nro"].ToString();
        obj.Ven_Serie = objDataReader["ven_serie"].ToString();
        obj.Ven_Material = objDataReader["ven_material"].ToString();
        obj.Ven_Descricao = objDataReader["ven_descricao"].ToString();
        obj.Ven_Cfop = objDataReader["ven_cfop"].ToString();
        obj.Ven_Qtd = Convert.ToDouble(objDataReader["ven_qtd"]);
        obj.Ven_Valor = Convert.ToDouble(objDataReader["ven_valor"]);
        obj.Ven_Bas_Icms = Convert.ToDouble(objDataReader["ven_bas_icms"]);
        obj.Ven_Bas_Pis = Convert.ToDouble(objDataReader["ven_bas_pis"]);
        obj.Ven_Per_Pis = Convert.ToDouble(objDataReader["ven_per_pis"]);
        obj.Ven_Vlr_Pis = Convert.ToDouble(objDataReader["ven_vlr_pis"]);
        obj.Ven_Bas_Cof = Convert.ToDouble(objDataReader["ven_bas_cof"]);
        obj.Ven_Per_Cof = Convert.ToDouble(objDataReader["ven_per_cof"]);
        obj.Ven_Vlr_Cof = Convert.ToDouble(objDataReader["ven_vlr_cof"]);
        obj.Ven_Saldo_Venda = Convert.ToDouble(objDataReader["saldo_venda"]);
        obj.Ent_Chave = objDataReader["ent_chave"].ToString();
        obj.Ent_Cod_Empresa = objDataReader["ent_cod_empresa"].ToString();
        obj.Ent_Local = objDataReader["ent_local"].ToString();
        obj.Ent_Id_Planilha = objDataReader["ent_id_planilha"].ToString();
        try
        {
            obj.Ent_Dtlanc = Convert.ToDateTime(objDataReader["Ent_Dtlanc"]);
        }
        catch
        {
            obj.Ent_Dtlanc = null;
        }
        try
        {
            obj.Ent_Dtnf = Convert.ToDateTime(objDataReader["Ent_Dtnf"]);
        }
        catch
        {
            obj.Ent_Dtnf = null;
        }
        obj.Ent_Nro = objDataReader["ent_nro"].ToString();
        obj.Ent_Serie = objDataReader["ent_serie"].ToString();
        obj.Ent_Operacao = objDataReader["ent_operacao"].ToString();
        obj.Ent_Material = objDataReader["ent_material"].ToString();
        obj.Ent_Descricao = objDataReader["ent_descricao"].ToString();
        obj.Ent_Cfop = objDataReader["ent_cfop"].ToString();
        try
        {
            obj.Ent_Qtd = Convert.ToDouble(objDataReader["ent_qtd"]);
        }
        catch
        {
            obj.Ent_Qtd = 0;
        }
        try
        {
            obj.Ent_Qtd_Remanescente = Convert.ToDouble(objDataReader["ent_qtd_temanescente"]);
        }
        catch
        {
            obj.Ent_Qtd_Remanescente = 0;
        }
        try
        {
            obj.Ent_Valor = Convert.ToDouble(objDataReader["ent_valor"]);
        }
        catch
        {
            obj.Ent_Valor = 0;
        }
        try
        {
            obj.Ent_Bas_Icms = Convert.ToDouble(objDataReader["Ent_bas_icms"]);
        }
        catch
        {
            obj.Ent_Bas_Icms = 0;
        }
        obj.Ent_Saldo = Convert.ToDouble(objDataReader["ent_saldo"]);
        obj.Ent_Qtd_Usada = Convert.ToDouble(objDataReader["ent_qtd_usada"]);
        obj.Calc_P_Unit = Convert.ToDouble(objDataReader["calc_p_unit"]);
        obj.Calc_Base_Pis = Convert.ToDouble(objDataReader["calc_base_pis"]);
        obj.Calc_Per_Pis = Convert.ToDouble(objDataReader["per_pis"]);
        obj.Calc_Vlr_Pis = Convert.ToDouble(objDataReader["calc_vlr_pis"]);
        obj.Calc_Base_Cofins = Convert.ToDouble(objDataReader["calc_base_cofins"]);
        obj.Calc_Per_Cof = Convert.ToDouble(objDataReader["per_cof"]);
        obj.Calc_Vlr_Cofins = Convert.ToDouble(objDataReader["calc_vlr_cofins"]);
        return obj;
    }
    private Nfe_DetE_Qry_00 PopulaNfe_DetE_Qry_00(NpgsqlDataReader objDataReader)
    {

        var obj = new Nfe_DetE_Qry_00();

        obj.Planilha = objDataReader["Planilha"].ToString();
        obj.Empresa = objDataReader["Empresa"].ToString();
        obj.Cnpj_Cpf = objDataReader["Cnpj_cpf"].ToString();
        obj.Id_Grupo = Convert.ToInt32(objDataReader["Id_Grupo"]);
        obj.Id = Convert.ToInt32(objDataReader["Id"]);
        obj.Operacao = objDataReader["Operacao"].ToString();
        obj.Nro_Linha = Convert.ToInt32(objDataReader["Nro_Linha"]);
        obj.Cod_Empresa = objDataReader["Cod_Empresa"].ToString();
        obj.Local = objDataReader["Local"].ToString();
        obj.Id_Planilha = objDataReader["Id_Planilha"].ToString();
        try
        {
            obj.Dtlanc = Convert.ToDateTime(objDataReader["dtlanc"]);
        }
        catch
        {
            obj.Dtlanc = null;
        }
        try
        {
            obj.Dtnf = Convert.ToDateTime(objDataReader["dtnf"]);
        }
        catch
        {
            obj.Dtnf = null;
        }
        obj.Nro = objDataReader["Nro"].ToString();
        obj.Serie = objDataReader["Serie"].ToString();
        obj.Uf = objDataReader["Uf"].ToString();
        obj.Nr_Item = objDataReader["Nr_Item"].ToString();
        obj.Material = objDataReader["Material"].ToString();
        obj.Descricao = objDataReader["Descricao"].ToString();
        obj.Ncm = objDataReader["Ncm"].ToString();
        obj.Unid = objDataReader["Unid"].ToString();
        obj.Cfop = objDataReader["Cfop"].ToString();
        obj.Cfop_Texto = objDataReader["Cfop_Texto"].ToString();
        obj.Qtd = Convert.ToDouble(objDataReader["Qtd"]);
        obj.Vlr_Contabil = Convert.ToDouble(objDataReader["Vlr_Contabil"]);
        obj.Vlr_Unit = Convert.ToDouble(objDataReader["Vlr_Unit"]);
        obj.Sti = objDataReader["Sti"].ToString();
        obj.Bas_Icms = Convert.ToDouble(objDataReader["Bas_Icms"]);
        obj.Per_Icms = Convert.ToDouble(objDataReader["Per_Icms"]);
        obj.Vlr_Icms = Convert.ToDouble(objDataReader["Vlr_Icms"]);
        obj.Stp = objDataReader["Stp"].ToString();
        obj.Bas_Pis = Convert.ToDouble(objDataReader["Bas_Pis"]);
        obj.Per_Pis = Convert.ToDouble(objDataReader["Per_Pis"]);
        obj.Vlr_Pis = Convert.ToDouble(objDataReader["Vlr_Pis"]);
        obj.Stc = objDataReader["Stc"].ToString();
        obj.Bas_Cof = Convert.ToDouble(objDataReader["Bas_Cof"]);
        obj.Per_Cof = Convert.ToDouble(objDataReader["Per_Cof"]);
        obj.Vlr_Cof = Convert.ToDouble(objDataReader["Vlr_Cof"]);
        obj.Stip = objDataReader["Stip"].ToString();
        obj.Bas_Ipi = Convert.ToDouble(objDataReader["Bas_Ipi"]);
        obj.Per_Ipi = Convert.ToDouble(objDataReader["Per_Ipi"]);
        obj.Vlr_Ipi = Convert.ToDouble(objDataReader["Vlr_Ipi"]);
        obj.Cnpj_Destinatario = objDataReader["Cnpj_Destinatario"].ToString();
        obj.Chave = objDataReader["Chave"].ToString();
        obj.Nome = objDataReader["Nome"].ToString();
        obj.Saldo = Convert.ToDouble(objDataReader["Saldo"]);
        obj.Sobra = Convert.ToDouble(objDataReader["Sobra"]);
        obj.Status = objDataReader["Status"].ToString();
        return obj;
    }
    public string SelectNfeCabPage(int Ordenacao, string Filtro, int Page, int TamPage, bool Contador)
    {
        string Where = "";

        string WhereDet = "";

        string OrderBy = "";

        string strSelect = "";


        //Adiciona WHERE 
        if (Filtro.Trim() != "")
        {

            switch (Ordenacao)
            {

                case 0:
                    Where = $"WHERE CAB.ID = {Filtro}";
                    break;
                case 1:
                    Where = $"WHERE CAB.PLANILHA LIKE '%{Filtro.Trim()}%'";
                    break;
                case 2:
                    Where = $"WHERE CAB.CNPJ ='{Filtro.Trim()}'";
                    break;
                case 3:
                    WhereDet = $"DET.NRO = '{Filtro.Trim()}'";
                    break;

            }

        }

        //Adiciona ORDER BY
        switch (Ordenacao)
        {
            case 0:
                OrderBy = $"ORDER BY CAB.ID";
                break;
            case 1:
                OrderBy = $"ORDER BY CAB.PLANILHA ";
                break;
            case 2:
                OrderBy = $"ORDER BY CAB.CNPJ ";
                break;
            case 3:
                OrderBy = $"ORDER BY CAB.CNPJ,DET.NRO ";
                break;
        }


        if (Contador)
        {
            strSelect = "SELECT count(*) AS TOTAL " +
                        "FROM NFE_CAB CAB " +
              "INNER JOIN NFE_DET          DET     ON DET.ID     = CAB.ID ";
            if (WhereDet != "")
            {
                strSelect += $" AND {WhereDet} ";
            }
            strSelect += "INNER JOIN DEPARA           DP      ON DP.CNPJ    = CAB.CNPJ " +
              "LEFT  JOIN NFE_VALORES      VAL_PIS ON VAL_PIS.ID = DET.ID AND VAL_PIS.NRO_LINHA = DET.NRO_LINHA " +
              "LEFT  JOIN NFE_VALORES_IPI  VAL_IPI ON VAL_IPI.ID = DET.ID AND VAL_IPI.NRO_LINHA = DET.NRO_LINHA ";
            strSelect += $" {Where} ";

        }
        else
        {

            strSelect = "SELECT  " +
                " CAB.ID                                             " +
                ",CAB.PLANILHA                                       " +
                ",CAB.SISTEMA                                        " +
                ",CAB.EMPRESA                                        " +
                ",DP.EMPRESA AS EMPRESADESCRICAO                     " +
                ",CAB.LOCAL                                          " +
                ",CAB.CNPJ                                           " +
                ",DP.UNID AS EMPRESAUNID                             " +
                ",DET.NRO_LINHA                                      " +
                ",DET.DTLANC                                         " +
                ",DET.DTNF                                           " +
                ",DET.NRO                                            " +
                ",DET.SERIE                                          " +
                ",DET.UF                                             " +
                ",DET.NR_ITEM                                        " +
                ",DET.MATERIAL                                       " +
                ",DET.DESCRICAO                                      " +
                ",DET.NCM                                            " +
                ",DET.UNID                                           " +
                ",DET.CFOP                                           " +
                ",DET.QTD                                            " +
                ",DET.VLR_CONTABIL                                   " +
                ",DET.STI                                            " +
                ",DET.BAS_ICMS                                       " +
                ",DET.PER_ICMS                                       " +
                ",DET.VLR_ICMS                                       " +
                ",DET.STP                                            " +
                ",DET.BAS_PIS                                        " +
                ",DET.PER_PIS                                        " +
                ",DET.VLR_PIS                                        " +
                ",DET.STC                                            " +
                ",DET.BAS_COF                                        " +
                ",DET.PER_COF                                        " +
                ",DET.VLR_COF                                        " +
                ",DET.STIP                                           " +
                ",DET.BAS_IPI                                        " +
                ",DET.PER_IPI                                        " +
                ",DET.VLR_IPI                                        " +
                ",DET.BAS_ICMS_ST                                    " +
                ",DET.PER_ICMS_ST                                    " +
                ",DET.VLR_ICMS_ST                                    " +
                ",VAL_PIS.DTNFE                                                 AS VAL_PIS_DTNFE                               " +
                ",VAL_PIS.DTCREDITO                                             AS VAL_PIS_DTCREDITO                           " +
                ",COALESCE(VAL_PIS.VLR_ECONOMICO_PIS,0)                         AS VAL_PIS_VLR_ECONOMICO_PIS                   " +
                ",COALESCE(VAL_PIS.VLR_OUTRO_PIS,0)                             AS VAL_PIS_VLR_OUTRO_PIS                       " +
                ",COALESCE(VAL_PIS.VLR_ECONOMICO_COFINS,0)                      AS VAL_PIS_VLR_ECONOMICO_COFINS                " +
                ",COALESCE(VAL_PIS.VLR_OUTRO_COFINS,0)                          AS VAL_PIS_VLR_OUTRO_COFINS                    " +
                ",VAL_PIS.DTFCORRECAO                                           AS VAL_PIS_DTFCORRECAO                         " +
                ",COALESCE(VAL_PIS.VLR_ECONOMICO_PIS_CORRIGIDO,0)               AS VAL_PIS_VLR_ECONOMICO_PIS_CORRIGIDO         " +
                ",COALESCE(VAL_PIS.VLR_OUTRO_PIS_CORRIGIDO,0)                   AS VAL_PIS_VLR_OUTRO_PIS_CORRIGIDO             " +
                ",COALESCE(VAL_PIS.VLR_ECONOMICO_COFINS_CORRIGIDO,0)            AS VAL_PIS_VLR_ECONOMICO_COFINS_CORRIGIDO      " +
                ",COALESCE(VAL_PIS.VLR_OUTRO_COFINS_CORRIGIDO,0)                AS VAL_PIS_VLR_OUTRO_COFINS_CORRIGIDO          " +
                ",COALESCE(VAL_PIS.METODO_PIS,'')                               AS VAL_PIS_METODO_PIS                          " +
                ",COALESCE(VAL_PIS.METODO_COFINS,'')                            AS VAL_PIS_METODO_COFINS                       " +
                ",COALESCE(VAL_PIS.TAXA,0)                                      AS VAL_PIS_TAXA                                " +
                ",VAL_IPI.DTCREDITO                                             AS VAL_IPI_DTCREDITO                           " +
                ",VAL_IPI.DTFCORRECAO                                           AS VAL_IPI_DTFCORRECAO                         " +
                ",COALESCE(VAL_IPI.VLR_IPI,0)                                   AS VAL_IPI_VLR_IPI                             " +
                ",COALESCE(VAL_IPI.VLR_IPI_CORRIGIDO,0)                         AS VAL_IPI_VLR_IPI_CORRIGIDO                   " +
                ",COALESCE(VAL_IPI.TAXA,0)                                      AS VAL_IPI_TAXA                                " +
              "FROM NFE_CAB CAB " +
              "INNER JOIN NFE_DET          DET     ON DET.ID     = CAB.ID ";
            if (WhereDet != "")
            {
                strSelect += $" AND {WhereDet} ";
            }
            strSelect += "INNER JOIN DEPARA           DP      ON DP.CNPJ    = CAB.CNPJ " +
              "LEFT JOIN NFE_VALORES      VAL_PIS ON VAL_PIS.ID = DET.ID AND VAL_PIS.NRO_LINHA = DET.NRO_LINHA " +
              "LEFT JOIN NFE_VALORES_IPI  VAL_IPI ON VAL_IPI.ID = DET.ID AND VAL_IPI.NRO_LINHA = DET.NRO_LINHA ";
            strSelect += $" {Where} ";
            strSelect += $" {OrderBy} ";
            strSelect += $" LIMIT {TamPage} OFFSET {((Page - 1) * TamPage)} ";
        }

        return strSelect;
    }
    public async Task<int> getContadorSync(int Ordenacao, string Filtro, int Page, int TamPage)
    {

        int Retorno = 0;

        string strSelect = "";

        string strStringConexao = DataBase.RunCommand.connectionString;

        strSelect = SelectNfeCabPage(Ordenacao, Filtro, Page, TamPage, true);

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
    public string SelectPisFechamento(string Filtro, int Page, int TamPage, bool Contador)
    {
        string Where = "";

        string WhereDet = "";

        string OrderBy = "";

        string strSelect = "";


        //Adiciona WHERE 
        if (Filtro.Trim() != "")
        {
            Where = $"WHERE CAB.CNPJ ='{Filtro.Trim()}'";
        }

        //Ordenacao
        OrderBy = $"ORDER BY CAB.ID";

        if (Contador)
        {
            strSelect = "SELECT count(*) AS TOTAL     " +
                  "FROM NFE_CAB CAB " +
                  "INNER JOIN NFE_DET          DET     ON DET.ID     = CAB.ID ";
            if (WhereDet != "")
            {
                strSelect += $" AND {WhereDet} ";
            }
            strSelect += "INNER JOIN DEPARA  DP  ON DP.CNPJ    = CAB.CNPJ " +
              "INNER JOIN NFE_VALORES_IPI  VAL_IPI ON VAL_IPI.ID = DET.ID AND VAL_IPI.NRO_LINHA = DET.NRO_LINHA AND VAL_IPI.VLR_IPI > 0";
            strSelect += $" {Where} ";
        }
        else
        {
            strSelect = "SELECT  " +
                         " CAB.ID                                             " +
                         ",CAB.PLANILHA                                       " +
                         ",CAB.SISTEMA                                        " +
                         ",CAB.EMPRESA                                        " +
                         ",DP.EMPRESA AS EMPRESADESCRICAO                     " +
                         ",CAB.LOCAL                                          " +
                         ",CAB.CNPJ                                           " +
                         ",DP.UNID AS EMPRESAUNID                             " +
                         ",DET.NRO_LINHA                                      " +
                         ",DET.DTLANC                                         " +
                         ",DET.DTNF                                           " +
                         ",DET.NRO                                            " +
                         ",DET.SERIE                                          " +
                         ",DET.UF                                             " +
                         ",DET.NR_ITEM                                        " +
                         ",DET.MATERIAL                                       " +
                         ",DET.DESCRICAO                                      " +
                         ",DET.NCM                                            " +
                         ",DET.UNID                                           " +
                         ",DET.CFOP                                           " +
                         ",DET.QTD                                            " +
                         ",DET.VLR_CONTABIL                                   " +
                         ",DET.STI                                            " +
                         ",DET.BAS_ICMS                                       " +
                         ",DET.PER_ICMS                                       " +
                         ",DET.VLR_ICMS                                       " +
                         ",DET.STP                                            " +
                         ",DET.BAS_PIS                                        " +
                         ",DET.PER_PIS                                        " +
                         ",DET.VLR_PIS                                        " +
                         ",DET.STC                                            " +
                         ",DET.BAS_COF                                        " +
                         ",DET.PER_COF                                        " +
                         ",DET.VLR_COF                                        " +
                         ",DET.STIP                                           " +
                         ",DET.BAS_IPI                                        " +
                         ",DET.PER_IPI                                        " +
                         ",DET.VLR_IPI                                        " +
                         ",DET.BAS_ICMS_ST                                    " +
                         ",DET.PER_ICMS_ST                                    " +
                         ",DET.VLR_ICMS_ST                                    " +
                         ",VAL_IPI.DTCREDITO                                             AS VAL_IPI_DTCREDITO                           " +
                         ",VAL_IPI.DTFCORRECAO                                           AS VAL_IPI_DTFCORRECAO                         " +
                         ",COALESCE(VAL_IPI.VLR_IPI,0)                                   AS VAL_IPI_VLR_IPI                             " +
                         ",COALESCE(VAL_IPI.VLR_IPI_CORRIGIDO,0)                         AS VAL_IPI_VLR_IPI_CORRIGIDO                   " +
                         ",COALESCE(VAL_IPI.TAXA,0)                                      AS VAL_IPI_TAXA                                " +
                       "FROM NFE_CAB CAB " +
                       "INNER JOIN NFE_DET          DET     ON DET.ID     = CAB.ID ";
            if (WhereDet != "")
            {
                strSelect += $" AND {WhereDet} ";
            }
            strSelect += "INNER JOIN DEPARA           DP      ON DP.CNPJ    = CAB.CNPJ " +
              "INNER JOIN NFE_VALORES_IPI  VAL_IPI ON VAL_IPI.ID = DET.ID AND VAL_IPI.NRO_LINHA = DET.NRO_LINHA AND VAL_IPI.VLR_IPI > 0";
            strSelect += $" {Where} ";
            strSelect += $" {OrderBy} ";
            if (Page > 0)
            {

                strSelect += $" LIMIT {TamPage} OFFSET {((Page - 1) * TamPage)} ";

            }

        }

        return strSelect;
    }
    public async Task<int> Calcula_Saldo(DateTime inicial, DateTime final, int id_grupo, int id_fechamento)
    {

        int Retorno = 0;

        string strSelect = "";

        string strStringConexao = DataBase.RunCommand.connectionString;

        strSelect = $"SELECT  FROM calculo_saldo('{inicial.ToString("yyyy-MM-dd")}','{final.ToString("yyyy-MM-dd")}',{id_grupo},{id_fechamento})";

        await Task.Run(() =>
        {
            using (var objConexao = new NpgsqlConnection(strStringConexao))
            {
                using (var objCommand = new NpgsqlCommand(strSelect, objConexao))
                {
                    try
                    {

                        DataBase.RunCommand.CreateCommand(strSelect);

                    }
                    catch (ExceptionErroImportacao ex)
                    {
                        MessageBox.Show(ex.Message, "Atenção!");
                    }
                }
            }

        });

        return Retorno;
    }
    public async Task<int> getContadorPisFechamentoSync(string Filtro, int Page, int TamPage)
    {

        int Retorno = 0;

        string strSelect = "";

        string strStringConexao = DataBase.RunCommand.connectionString;

        strSelect = SelectPisFechamento(Filtro, Page, TamPage, true);

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
    public string SelectPisFechamentoExcel_00(string cnpj)
    {

        string strSelect = "";

        strSelect = " COPY (" +
                        " SELECT  CAB.ID                                                    " +
                        "        ,CAB.EMPRESA                                               " +
                        "        ,'=' || '\"' || CAB.CNPJ || '\"' as CNPJ                   " +
                        "        ,DET.NRO_LINHA                                             " +
                        "        ,'=' || '\"' || DET.LOCAL  || '\"' AS LOCAL                  " +
                        "        ,DET.DTNF                                                    " +
                        "        ,'=' || '\"' || DET.NRO  || '\"'  AS NRO                     " +
                        "        ,'=' || '\"' || DET.SERIE  || '\"'  AS SERIE                 " +
                        "        ,'=' || '\"' || DET.NR_ITEM  || '\"'  AS NRO_ITEM            " +
                        "        ,'=' || '\"' || DET.MATERIAL  || '\"'  AS MATERIAL           " +
                        "        ,DET.DESCRICAO                                             " +
                        "        ,'=' || '\"' || COMP.CNPJ  || '\"' AS  CNPJ_CLI_FOR          " +
                        "        ,'=' || '\"' || COMP.CHAVE || '\"' AS CHAVE_ELETRONICA       " +
                        "        ,'=' || '\"' || DET.CFOP  || '\"' AS CFOP                    " +
                        "        ,TO_CHAR(DET.QTD,'999999999999D9999')  AS QTD                 " +
                        "        ,TO_CHAR(DET.VLR_CONTABIL,'999999999999D9999') AS VLR_CONTABIL  " +
                        "        ,TO_CHAR(VAL.VLR_IPI,'999999999999D9999') AS VLR_IPI          " +
                        "        ,TO_CHAR(VAL.TAXA,'99999999D99') AS TAXA                                                  " +
                        "        ,TO_CHAR(VAL.VLR_IPI_CORRIGIDO,'999999999999D9999') AS VLR_IPI_CORRIGIDO                                  " +
                        "        ,'=' || '\"' || VE.NRO || '\"'    AS NRO_VENDA " +
                        "        ,'=' || '\"' || VE.SERIE || '\"'  AS SERIE_VENDA " +
                        "        ,'=' || '\"' || VE.MATERIAL || '\"'  AS MATERIAL_VENDA " +
                        "        ,VE.DESCRICAO AS DESCRICAO_VENDA " +
                        "        ,TO_CHAR(VE.QTD, '999999999999D9999')  AS QTD_VENDA " +
                        "        ,TO_CHAR(VE.VLR_CONTABIL, '999999999999D9999') AS VLR_CONTABIL_VENDA " +
                        "        ,TO_CHAR(VE.VLR_IPI, '999999999999D9999') AS VLR_IPI_VENDA " +
                        "        ,( " +
                        "           SELECT ('|' || CAB2.CNPJ ||  '|' " +
                        "                   || DET2.NRO   ||  '|' || DET2.SERIE || '|' || DET2.CFOP  ||  '|' || DET2.DESCRICAO || '|' || TO_CHAR(DET2.QTD,'999999999990D0000')    ||  '|' || TO_CHAR(DET2.VLR_CONTABIL, '999999999990D0000') || '|' || TO_CHAR(DET2.BAS_IPI, '999999999990D00')  || '|' || TO_CHAR(DET2.PER_IPI, '999999999990D00') || '|' || TO_CHAR(DET2.VLR_IPI, '999999999990D00')  " +
                        "          ) AS NOTA" +
                        "                   FROM NFE_DET DET2 " +
                        "                   INNER JOIN NFE_CAB CAB2 ON CAB2.ID = DET2.ID " +
                        "                   WHERE(DET2.NRO = DET.NRO AND DET2.SERIE = DET.SERIE AND DET.QTD = DET2.QTD AND DET.VLR_CONTABIL = DET2.VLR_CONTABIL) AND(DET2.CFOP = '1910' OR DET2.CFOP = '2910') LIMIT 1 " +
                        "        ) AS ENTRADA , " +
                        "        '   ' AS CNPJ, '   ' AS NRO, '   ' AS SERIE, '    ' AS CFOP, '    ' AS DESCRICAO, '   ' AS QTD, '     ' AS VLR_CONTABIL, '      ' AS BASE_IPI, '    ' AS PERC_IPI, '    ' AS VLR_IPI " +
                        " FROM   NFE_CAB CAB                                                " +
                        " INNER  JOIN NFE_DET DET ON CAB.ID = DET.ID  " +
                        " INNER  JOIN NFE_VALORES_IPI VAL   ON VAL.ID =  DET.ID  AND VAL.NRO_LINHA  = DET.NRO_LINHA AND VAL.VLR_IPI > 0 " +
                        " INNER  JOIN NFE_DET_COMP    COMP  ON COMP.ID = DET.ID  AND COMP.NRO_LINHA = DET.NRO_LINHA AND COMP.BEBIDA = 'S' " +
                        " INNER  JOIN NFE_DET_NOTA_VENDA VE ON VE.ID = DET.ID    AND VE.NRO_LINHA = DET.NRO_LINHA " +
                        $"WHERE    CAB.CNPJ = '{cnpj}' " +
                        " AND COMP.CNPJ IN (" +
                        " '15350602000308',  " +
                        " '15350602000146',  " +
                        " '15350602001703',  " +
                        " '15350602001541',  " +
                        " '15350602000901',  " +
                        " '15350602002190',  " +
                        " '15350602000650',  " +
                        " '15350602000499',  " +
                        " '15350602002009',  " +
                        " '15350602000812',  " +
                        " '15350602001118',  " +
                        " '15350602001975',  " +
                        " '15350602001037',  " +
                        " '15350602001460',  " +
                        " '15350602001894',  " +
                        " '15350602001380',  " +
                        " '15350602001622',  " +
                        " '15350602000570',  " +
                        " '15350602000731',  " +
                        " '15350602001207',  " +
                        " '73410326002023',  " +
                        " '73410326011600',  " +
                        " '73410326007092',  " +
                        " '73410326001728',  " +
                        " '73410326008811',  " +
                        " '73410326010476',  " +
                        " '73410326010638',  " +
                        " '73410326009389',  " +
                        " '73410326004581',  " +
                        " '73410326011529',  " +
                        " '73410326007173',  " +
                        " '73410326012339',  " +
                        " '73410326010557',  " +
                        " '73410326012258',  " +
                        " '73410326004905',  " +
                        " '73410326000322',  " +
                        " '73410326003500',  " +
                        " '73410326008730',  " +
                        " '73410326004239',  " +
                        " '73410326006100',  " +
                        " '73410326011871',  " +
                        " '73410326004662',  " +
                        " '73410326014897',  " +
                        " '73410326010123',  " +
                        " '73410326005120',  " +
                        " '73410326004409',  " +
                        " '73410326006525',  " +
                        " '73410326009036',  " +
                        " '73410326003003',  " +
                        " '73410326007254',  " +
                        " '73410326013904',  " +
                        " '73410326011367',  " +
                        " '73410326002961',  " +
                        " '73410326016679',  " +
                        " '73410326009893',  " +
                        " '73410326016083',  " +
                        " '73410326015869',  " +
                        " '73410326001566',  " +
                        " '73410326011103',  " +
                        " '73410326013491',  " +
                        " '73410326014110',  " +
                        " '73410326003852',  " +
                        " '73410326016830',  " +
                        " '73410326004077',  " +
                        " '73410326011448',  " +
                        " '73410326004310',  " +
                        " '73410326005987',  " +
                        " '73410326012681',  " +
                        " '73410326009621',  " +
                        " '73410326008579',  " +
                        " '73410326013734',  " +
                        " '73410326005391',  " +
                        " '73410326008307',  " +
                        " '73410326017217',  " +
                        " '73410326016245',  " +
                        " '73410326010719',  " +
                        " '73410326001302',  " +
                        " '73410326005715',  " +
                        " '73410326013300',  " +
                        " '73410326001647',  " +
                        " '73410326006606',  " +
                        " '73410326004824',  " +
                        " '73410326009460',  " +
                        " '73410326014625',  " +
                        " '73410326007920',  " +
                        " '73410326003267',  " +
                        " '73410326013149',  " +
                        " '73410326009974',  " +
                        " '73410326015001',  " +
                        " '73410326015940',  " +
                        " '73410326006444',  " +
                        " '73410326009540',  " +
                        " '73410326003186',  " +
                        " '73410326010808',  " +
                        " '73410326008650',  " +
                        " '73410326008226',  " +
                        " '73410326014463',  " +
                        " '73410326014544',  " +
                        " '73410326016598',  " +
                        " '73410326007335',  " +
                        " '73410326007416',  " +
                        " '73410326005200',  " +
                        " '73410326003429',  " +
                        " '73410326012843',  " +
                        " '73410326011952',  " +
                        " '73410326012177',  " +
                        " '73410326000403',  " +
                        " '73410326006010',  " +
                        " '73410326016407',  " +
                        " '73410326008064',  " +
                        " '73410326013068',  " +
                        " '73410326012410',  " +
                        " '73410326007840',  " +
                        " '73410326014200',  " +
                        " '73410326008498',  " +
                        " '73410326004158',  " +
                        " '73410326009117',  " +
                        " '73410326007688',  " +
                        " '73410326001990',  " +
                        " '73410326009206',  " +
                        " '73410326015516',  " +
                        " '73410326005049',  " +
                        " '73410326011286',  " +
                        " '73410326006363',  " +
                        " '73410326009702',  " +
                        " '73410326015192',  " +
                        " '73410326015605',  " +
                        " '73410326010980',  " +
                        " '73410326011790',  " +
                        " '73410326003771',  " +
                        " '73410326005472',  " +
                        " '73410326012924',  " +
                        " '73410326014030',  " +
                        " '73410326016911',  " +
                        " '73410326002538',  " +
                        " '73410326008900',  " +
                        " '73410326003933',  " +
                        " '73410326015354',  " +
                        " '73410326000918',  " +
                        " '73410326016750',  " +
                        " '73410326014706',  " +
                        " '73410326003348',  " +
                        " '73410326010042',  " +
                        " '73410326002880',  " +
                        " '73410326013220',  " +
                        " '73410326012096',  " +
                        " '73410326011014'   " +
                          ")" +
                        " ORDER BY CAB.CNPJ,DET.DTNF, DET.NRO " +
                        //" --ORDER BY CAB.ID " +
                        //" --       ,CAB.PLANILHA " +
                        //" --       ,CAB.CNPJ " +
                        $" ) To 'c:\\Fechamento IPI\\{cnpj}.csv' With CSV DELIMITER ';' HEADER; ";


        return strSelect;
    }
    public async Task<string> FechamentoExcel_00(string cnpj)
    {

        string strStringConexao = DataBase.RunCommand.connectionString;

        string strSelect = SelectPisFechamentoExcel_00(cnpj);

        Console.WriteLine(strSelect);

        await Task.Run(() =>
        {
            try
            {

                DataBase.RunCommand.CreateCommand(strSelect);

            }
            catch (ExceptionErroImportacao ex)
            {
                MessageBox.Show(ex.Message, "Atenção!");
            }



        });

        return "OK";

    }
    public string SelectPisFechamentoExcel_01(string cnpj)
    {

        string strSelect = "";

        strSelect = " COPY (" +
                        " SELECT  CAB.ID                                                    " +
                        "        ,CAB.EMPRESA                                               " +
                        "        ,'=' || '\"' || CAB.CNPJ || '\"' as CNPJ                   " +
                        "        ,DET.NRO_LINHA                                             " +
                        "        ,'=' || '\"' || DET.LOCAL  || '\"' AS LOCAL                  " +
                        "        ,DET.DTNF                                                    " +
                        "        ,'=' || '\"' || DET.NRO  || '\"'  AS NRO                     " +
                        "        ,'=' || '\"' || DET.SERIE  || '\"'  AS SERIE                 " +
                        "        ,'=' || '\"' || DET.NR_ITEM  || '\"'  AS NRO_ITEM            " +
                        "        ,'=' || '\"' || DET.MATERIAL  || '\"'  AS MATERIAL           " +
                        "        ,DET.DESCRICAO                                             " +
                        "        ,'=' || '\"' || COMP.CNPJ  || '\"' AS  CNPJ_CLI_FOR          " +
                        "        ,'=' || '\"' || COMP.CHAVE || '\"' AS CHAVE_ELETRONICA       " +
                        "        ,'=' || '\"' || DET.CFOP  || '\"' AS CFOP                    " +
                        "        ,TO_CHAR(DET.QTD,'999999999999D9999')  AS QTD                 " +
                        "        ,TO_CHAR(DET.VLR_CONTABIL,'999999999999D9999') AS VLR_CONTABIL  " +
                        "        ,TO_CHAR(VAL.VLR_IPI,'999999999999D9999') AS VLR_IPI          " +
                        "        ,TO_CHAR(VAL.TAXA,'99999999D99') AS TAXA                                                  " +
                        "        ,TO_CHAR(VAL.VLR_IPI_CORRIGIDO,'999999999999D9999') AS VLR_IPI_CORRIGIDO                                  " +
                        ",CASE " +
                        "   WHEN SUBSTR(VE.DESCRICAO,1,1) = '*'        THEN 'VENDA EM OUTRA NOTA' " +
                        "   WHEN VE.DESCRICAO = 'SEM VENDA NESTA NOTA' THEN 'NAO ENCONTRADO VENDA' " +
                        "   ELSE                                            'VENDA NA NOTA' " +
                        "END AS CLASSFICACAO_VENDA " +
                        "        ,'=' || '\"' || VE.NRO || '\"'    AS NRO_VENDA " +
                        "        ,'=' || '\"' || VE.SERIE || '\"'  AS SERIE_VENDA " +
                        "        ,'=' || '\"' || VE.MATERIAL || '\"'  AS MATERIAL_VENDA " +
                        "        ,VE.DESCRICAO AS DESCRICAO_VENDA " +
                        "        ,TO_CHAR(VE.QTD, '999999999999D9999')  AS QTD_VENDA " +
                        "        ,TO_CHAR(VE.VLR_CONTABIL, '999999999999D9999') AS VLR_CONTABIL_VENDA " +
                        "        ,TO_CHAR(VE.VLR_IPI, '999999999999D9999') AS VLR_IPI_VENDA " +
                        " FROM   NFE_CAB CAB                                                " +
                        " INNER  JOIN NFE_DET DET ON CAB.ID = DET.ID  " +
                        " INNER  JOIN NFE_VALORES_IPI VAL   ON VAL.ID =  DET.ID  AND VAL.NRO_LINHA  = DET.NRO_LINHA AND VAL.VLR_IPI > 0 " +
                        " INNER  JOIN NFE_DET_COMP    COMP  ON COMP.ID = DET.ID  AND COMP.NRO_LINHA = DET.NRO_LINHA AND COMP.BEBIDA = 'S' " +
                        " INNER  JOIN NFE_DET_NOTA_VENDA VE ON VE.ID = DET.ID    AND VE.NRO_LINHA = DET.NRO_LINHA " +
                        $"WHERE    CAB.CNPJ = '{cnpj}' " +
                        " ORDER BY CAB.CNPJ,DET.DTNF, DET.NRO " +
                        //" --ORDER BY CAB.ID " +
                        //" --       ,CAB.PLANILHA " +
                        //" --       ,CAB.CNPJ " +
                        $" ) To 'c:\\Fechamento IPI\\{cnpj}.csv' With CSV DELIMITER ';' HEADER; ";


        return strSelect;
    }
    public async Task<string> FechamentoExcel_01(string cnpj)
    {

        string strStringConexao = DataBase.RunCommand.connectionString;

        string strSelect = SelectPisFechamentoExcel_01(cnpj);

        Console.WriteLine(strSelect);

        await Task.Run(() =>
        {
            try
            {

                DataBase.RunCommand.CreateCommand(strSelect);

            }
            catch (ExceptionErroImportacao ex)
            {
                MessageBox.Show(ex.Message, "Atenção!");
            }



        });

        return "OK";

    }
    public string SelectFechamentoExcel_01_Pis_Cofins(string arquivo, string cnpj, string dtInicial, string dtFinal)
    {
        string filtro = "";
        string strSelect = "";


        if (!(dtInicial.Trim() == ""))
        {
            filtro = $"AND (DET.DTNF >= '{dtInicial}' AND DET.DTNF <= '{dtFinal}') ";
        }

        strSelect = " COPY (" +
                        " SELECT  CAB.ID " +
                        "        ,CAB.PLANILHA   " +
                        "        ,CAB.SISTEMA    " +
                        "        ,CAB.EMPRESA    " +
                        "        ,'=' || '\"' || DET.LOCAL  || '\"' AS LOCAL  " +
                        "        ,'=' || '\"' || CAB.CNPJ   || '\"' AS CNPJ " +
                        "        ,'=' || '\"' || DET.NRO_LINHA  || '\"' AS NRO_LINHA  " +
                        "        ,DET.dtlanc     " +
                        "        ,DET.dtnf       " +
                        "        ,'=' || '\"' || DET.NRO  || '\"'       AS NRO       " +
                        "        ,'=' || '\"' || DET.SERIE  || '\"'     AS SERIE     " +
                        "        ,'=' || '\"' || DET.NR_ITEM  || '\"'   AS NRO_ITEM  " +
                        "        ,'=' || '\"' || DET.MATERIAL  || '\"'  AS MATERIAL  " +
                        "        ,DET.descricao  " +
                        "        ,'=' || '\"' || DET.NCM  || '\"'  AS NCM " +
                        "        ,DET.unid " +
                        "        ,'=' || '\"' || DET.CFOP  || '\"'  AS CFOP " +
                        "        ,TO_CHAR(DET.QTD,'999999999990D0000')  AS QTD " +
                        "        ,TO_CHAR(DET.VLR_CONTABIL,'999999999990D0000') AS VLR_CONTABIL " +
                        "        ,'=' || '\"' || DET.STI  || '\"'  AS STI " +
                        "        ,TO_CHAR(DET.BAS_ICMS,'999999999990D00') AS BAS_ICMS  " +
                        "        ,TO_CHAR(DET.PER_ICMS,'999999999990D00') AS PER_ICMS  " +
                        "        ,TO_CHAR(DET.VLR_ICMS,'999999999990D00') AS VLR_ICMS  " +
                        "        ,'=' || '\"' || DET.STP  || '\"'          AS STP      " +
                        "        ,TO_CHAR(DET.BAS_PIS,'999999999990D00')   AS BAS_PIS  " +
                        "        ,TO_CHAR(DET.PER_PIS,'999999999990D00')   AS PER_PIS  " +
                        "        ,TO_CHAR(DET.VLR_PIS,'999999999990D0000') AS VLR_PIS  " +
                        "        ,'=' || '\"' || DET.STC  || '\"'          AS STC      " +
                        "        ,TO_CHAR(DET.BAS_COF,'999999999990D00')   AS BAS_COF  " +
                        "        ,TO_CHAR(DET.PER_COF,'999999999990D00')   AS PER_COF  " +
                        "        ,TO_CHAR(DET.VLR_COF,'999999999990D0000') AS VLR_COF  " +
                        "        ,TO_CHAR(VAL.VLR_ECONOMICO_PIS,'999999999990D0000')    AS VLR_ECONOMICO_PIS " +
                        "        ,TO_CHAR(VAL.VLR_ECONOMICO_COFINS,'999999999990D0000') AS VLR_ECONOMICO_COFINS " +
                        " FROM NFE_CAB CAB " +
                       $" INNER JOIN NFE_DET     DET ON CAB.ID = DET.ID {filtro} " +
                        " INNER JOIN NFE_VALORES VAL ON VAL.ID = DET.ID AND VAL.NRO_LINHA = DET.NRO_LINHA " +
                       $" WHERE CAB.CNPJ = '{cnpj}' " +
                         " ORDER  BY CAB.ID " +
                         "          ,CAB.PLANILHA " +
                         "          ,CAB.CNPJ " +
                        $" ) To '{arquivo}' With CSV DELIMITER ';' HEADER; ";


        return strSelect;
    }
    public async Task<string> FechamentoExcel_01_Pis_Cofins(string arquivo, string cnpj, string dtInicial, string dtFinal)
    {

        string strStringConexao = DataBase.RunCommand.connectionString;

        string strSelect = SelectFechamentoExcel_01_Pis_Cofins(arquivo, cnpj, dtInicial, dtFinal);

        Console.WriteLine(strSelect);

        await Task.Run(() =>
        {
            try
            {

                DataBase.RunCommand.CreateCommand(strSelect);

            }
            catch (ExceptionErroImportacao ex)
            {
                MessageBox.Show(ex.Message, "Atenção!");
            }


        });

        return "OK";

    }
    public string SelectStringNfet_Det_E_Page(FiltroNfDetE Filtro, int Page, int TamPage, bool Contador)
    {
        string Where = "";

        string OrderBy = "Order By DET.ID,DET_NRO_LINHA";

        string strSelect = "";

        //Adiciona WHERE 
        if (Filtro.Id_Grupo != 0)
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" DET.ID_GRUPO = {Filtro.Id_Grupo} ";
        }

        if (Filtro.Id != 0)
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" DET.ID = {Filtro.Id} ";
        }

        if (Filtro.Nro != "")
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" DET.NRO = '{Filtro.Nro}' ";
        }

        if (Filtro.Serie != "")
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" DET.SERIE = {Filtro.Serie} ";
        }

        if (Filtro.Material != "")
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" DET.MATERIAL = '{Filtro.Material}' ";
        }

        if (Filtro.Cfop != "")
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" DET.CFOP = '{Filtro.Cfop}' ";
        }

        if ((Filtro.Dtnf != null))
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" DET.DTNF = '{Filtro.Dtnf?.ToString("YYYY-mm-dd")}' ";
        }

        if ((Filtro.Dtlanc != null))
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" DET.DTLANC = '{Filtro.Dtnf?.ToString("YYYY-mm-dd")}' ";
        }

        if (Filtro.DataInicial != null)
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" ( DET.DTNF >= '{Filtro.DataInicial?.ToString("yyyy-MM-dd")}' AND  DET.DTNF <= '{Filtro.DataFinal?.ToString("yyyy-MM-dd")}') ";
        }

        if (Filtro.Operacao != "")
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" DET.OPERACAO = '{Filtro.Operacao}' ";
        }

        if (Filtro.Status != "")
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" DET.STATUS = '{Filtro.Status}' ";
        }


        if (Contador)
        {

            strSelect = "SELECT count(*) AS TOTAL FROM NFE_DET_E DET ";

            strSelect += $" {Where} ";

        }
        else
        {

            strSelect = "SELECT  * FROM NFE_DET_E DET ";

            strSelect += $" {Where} ";

            strSelect += $" {OrderBy} ";

            strSelect += $" LIMIT {TamPage} OFFSET {((Page - 1) * TamPage)} ";

        }

        return strSelect;
    }
    public async Task<int> GetContadorNFEDETE(FiltroNfDetE Filtro)
    {
        int Retorno = 0;

        string strSelect = "";

        string strStringConexao = DataBase.RunCommand.connectionString;

        strSelect = SelectStringNfet_Det_E_Page(Filtro, 0, 0, true);

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
    private String SelectNfeDetPage(Filtro_NfeCabE Filtro, int Page, int TamPage, bool Contador)
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

        if (Filtro.Planilha == "")
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" CAB.PLANILHA = '{Filtro.Planilha}' ";
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
            case 2:
                OrderBy = $"ORDER BY CAB.CNPJ ";
                break;

        }


        if (Contador)
        {
            strSelect = "SELECT count(*) AS TOTAL FROM NFE_CAB_E CAB ";

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
                           "FROM NFE_CAB_E CAB ";
            strSelect += $" {Where} ";
            strSelect += $" {OrderBy} ";
            strSelect += $" LIMIT {TamPage} OFFSET {((Page - 1) * TamPage)} ";
        }
        return strSelect;
    }

    //Consulta Notas Processadas

    public string SelectStringNfet_Det_01_Page(Filtro_Nfe_Det_01 Filtro, int Page, int TamPage, bool Contador)
    {
        string Where = "";

        string OrderBy = "";

        string strSelect = "";

        //Adiciona WHERE 
        if (Filtro.Id_Grupo != 0)
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" VEN.ID_GRUPO = {Filtro.Id_Grupo} ";
        }

        if (Filtro.Id_Fechamento != 0)
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" con.id_fechamento = {Filtro.Id_Fechamento} ";
        }

        if (Filtro.Fec_Descricao != "")
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" fec.descricao like '%{Filtro.Fec_Descricao.Trim()}%' ";
        }

        if (Filtro.Ven_Empresa != "")
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" Ven.Empresa = '{Filtro.Ven_Empresa}' ";
        }

        if (Filtro.Ven_Ano != 0)
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" VEN.ANO = {Filtro.Ven_Ano} ";
        }

        if (Filtro.Ven_Id != 0)
        {
            Where += Where == "" ? " where " : " and ";
            Where += $"  VEN.ID = {Filtro.Ven_Id} ";
        }

        if (Filtro.Ven_Chave != "")
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" VEN.CHAVE = '{Filtro.Ven_Chave}' ";
        }

        if (Filtro.Ven_Cod_Empresa != "")
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" VEN.COD_EMPRESA = '{Filtro.Ven_Cod_Empresa}' ";
        }

        if (Filtro.Ven_Local != "")
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" VEN.LOCAL = '{Filtro.Ven_Local}' ";
        }

        if ((Filtro.Ven_Dtlanc != null))
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" VEN.DTLANC = '{Filtro.Ven_Dtlanc?.ToString("YYYY-mm-dd")}' ";
        }

        if ((Filtro.Ven_Dtnf != null))
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" DET.DTNF = '{Filtro.Ven_Dtnf?.ToString("YYYY-mm-dd")}' ";
        }

        if (Filtro.Ven_Nro != "")
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" VEN.NRO = '{Filtro.Ven_Nro}' ";
        }

        if (Filtro.Ven_Serie != "")
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" VEN.SERIE = '{Filtro.Ven_Serie}' ";
        }
        if (Filtro.Ven_Material != "")
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" VEN.MATERIAL = '{Filtro.Ven_Material}' ";
        }
        if (Filtro.Ven_Descricao != "")
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" VEN.DESCRICAO = '{Filtro.Ven_Descricao}' ";
        }
        if (Filtro.Ven_Cfop != "")
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" VEN.VEN_CFOP = '{Filtro.Ven_Cfop}' ";
        }
        if (Filtro.Ven_Status != "")
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" VEN.STATUS = '{Filtro.Ven_Status}' ";
        }

        if (Filtro.Ent_Chave != "")
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" ENT.CHAVE = '{Filtro.Ent_Chave}' ";
        }

        if ((Filtro.Ent_Dtlanc != null))
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" ENT.DTLANC = '{Filtro.Ent_Dtlanc?.ToString("YYYY-mm-dd")}' ";
        }

        if ((Filtro.Ent_Dtnf != null))
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" ENT.DTNF = '{Filtro.Ent_Dtnf?.ToString("YYYY-mm-dd")}' ";
        }

        if (Filtro.Ent_Nro != "")
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" ENT.NRO = '{Filtro.Ent_Nro}' ";
        }

        if (Filtro.Ent_Serie != "")
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" ENT.SERIE = '{Filtro.Ent_Serie}' ";
        }

        if (Filtro.Ent_Operacao != "")
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" ENT.OPERACAO = '{Filtro.Ent_Operacao}' ";
        }
        if (Filtro.Ent_Descricao != "")
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" ENT.DESCRICAO = '{Filtro.Ent_Descricao}' ";
        }
        if (Filtro.Ent_Cfop != "")
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" ENT.CFOP = '{Filtro.Ent_Cfop}' ";
        }
        if (Filtro.Ent_Qtd != 0)
        {
            Where += Where == "" ? " where " : " and ";
            Where += $"  VEN.QTD = {Filtro.Ent_Qtd} ";
        }
        //Filtro Só Vendas
        Where += Where == "" ? " where " : " and ";
        Where += $"  VEN.OPERACAO = 'V' ";

        if (Contador)
        {

            strSelect = "SELECT count(con.*) AS TOTAL " +
             "from controle_e con " +
             "inner join nfe_det_e ven on ven.id = con.id_s and ven.nro_linha = con.nro_linha_s " +
             "inner join nfe_det_e ent on ent.id = con.id_e and ent.nro_linha = con.nro_linha_e " +
             "inner join clientes cli on cli.cod_empresa = ven.cod_empresa and cli.local = ven.local " +
             "inner join fechamento fec on fec.id_grupo = con.id_grupo and fec.id = con.id_fechamento ";

            strSelect += $" {Where} ";

        }
        else
        {

            strSelect = " select  " +
                        " con.id_fechamento as \"id_fechamento\" " +
                        ",fec.descricao as \"desc_fechamento\" " +
                        ",cli.empresa as \"ven_empresa\" " +
                        ",to_char(ven.dtnf, 'YYYY') as \"ven_ano\" " +
                        ",ven.id as \"ven_id\" " +
                        ",ven.nro_linha as \"ven_nro_linha\" " +
                        ",ven.chave as \"ven_chave\" " +
                        ",ven.cod_empresa as \"ven_cod_empresa\" " +
                        ",ven.local as \"ven_local\"  " +
                        ",ven.id_planilha as \"ven_id_planilha\" " +
                        ",ven.dtlanc as \"ven_dtlanc\" " +
                        ",ven.dtnf as \"ven_dtnf\" " +
                        ",ven.nro as \"ven_nro\" " +
                        ",ven.serie as \"ven_serie\" " +
                        ",ven.material as \"ven_material\" " +
                        ",ven.descricao as \"ven_descricao\" " +
                        ",ven.cfop as \"ven_cfop\" " +
                        ",ven.qtd as \"ven_qtd\" " +
                        ",ven.vlr_contabil as \"ven_valor\" " +
                        ",ven.bas_icms as \"ven_bas_icms\" " +
                        ",ven.bas_pis as \"ven_bas_pis\" " +
                        ",ven.per_pis as \"ven_per_pis\" " +
                        ",ven.vlr_pis as \"ven_vlr_pis\" " +
                        ",ven.bas_cof as \"ven_bas_cof\" " +
                        ",ven.per_cof as \"ven_per_cof\" " +
                        ",ven.vlr_cof as \"ven_vlr_cof\" " +
                        ",ven.saldo as \"saldo_venda\" " +
                        ",ent.chave as \"ent_chave\" " +
                        ",ent.cod_empresa as \"ent_cod_empresa\" " +
                        ",ent.local as \"ent_local\" " +
                        ",ent.id_planilha as \"ent_id_planilha\" " +
                        ",ent.dtlanc as \"ent_dtlanc\" " +
                        ",ent.dtnf as \"ent_dtnf\" " +
                        ",ent.nro as \"ent_nro\" " +
                        ",ent.serie as \"ent_serie\" " +
                        " ,case " +
                        "     when ent.operacao = 'A'  THEN 'SALDO ANTERIROR' " +
                        "     when ent.operacao = 'X'  THEN 'ENTRADA - DISP.' " +
                        "     when ent.operacao = 'V'  THEN 'VENDA' " +
                        "     when ent.operacao = 'S'  THEN 'SAIDA - DISP.' " +
                        "     when ent.operacao = 'E'  THEN 'ENTRADA' " +
                        "     else 'NÃO DEF.' " +
                        "     end  as \"ent_operacao\" " +
                        ",ent.material as \"ent_material\" " +
                        ",ent.descricao as \"ent_descricao\" " +
                        ",ent.cfop as \"ent_cfop\" " +
                        ",ent.qtd as \"ent_qtd\" " +
                        ",case  " +
                        $"       when ent.operacao = 'E' then 0 " +
                        $"       else ent.qtd-ent.sobra " +
                        "end as \"ent_qtd_remanescente\" " +
                        ",ent.vlr_contabil as \"ent_valor\" " +
                        ",ent.bas_icms as \"ent_bas_icms\" " +
                        ",ent.saldo as \"ent_saldo\" " +
                        ",con.qtd_e as \"ent_qtd_usada\" " +
                        ",case " +
                        "   when ent.operacao = 'E' then round((ent.bas_icms/ ent.qtd),4) " +
                        "   else ent.vlr_unit " +
                        " end as \"calc_p_unit\" " +
                        ",case " +
                        "   when ent.operacao = 'E' then round((con.qtd_e* (round((ent.bas_icms/ ent.qtd),4))),4) " +
                        "   else round((con.qtd_e * ent.vlr_unit), 4) " +
                        " end as \"calc_base_pis\" " +
                        ",ven.per_pis " +
                        ",case " +
                        "   when ent.operacao = 'E' then round((con.qtd_e* (round((ent.bas_icms/ ent.qtd),4)) *(ven.per_pis / 100)),4) " +
                        "   else round((con.qtd_e * ent.vlr_unit) * (ven.per_pis / 100), 4) " +
                        " end as \"calc_vlr_pis\" " +
                        ",case " +
                        "   when ent.operacao = 'E' then round((con.qtd_e* (round((ent.bas_icms/ ent.qtd),4))),4) " +
                        "   else round((con.qtd_e * ent.vlr_unit), 4) " +
                        " end as \"calc_base_cofins\" " +
                        ",ven.per_cof " +
                        ",case " +
                        "   when ent.operacao = 'E' then round((con.qtd_e* (round((ent.bas_icms/ ent.qtd),4)) *(ven.per_cof / 100)),4) " +
                        "   else round((con.qtd_e * ent.vlr_unit) * (ven.per_cof / 100), 4) " +
                        " end as \"calc_vlr_cofins\" " +
                        "from controle_e con " +
                        "inner join nfe_det_e ven on ven.id = con.id_s and ven.nro_linha = con.nro_linha_s " +
                        "inner join nfe_det_e ent on ent.id = con.id_e and ent.nro_linha = con.nro_linha_e " +
                        "inner join clientes cli on cli.cod_empresa = ven.cod_empresa and cli.local = ven.local " +
                        "inner join fechamento fec on fec.id_grupo = con.id_grupo and fec.id = con.id_fechamento ";

            strSelect += $" {Where} ";

            strSelect += $" {OrderBy} ";

            strSelect += $" LIMIT {TamPage} OFFSET {((Page - 1) * TamPage)} ";

        }

        return strSelect;
    }
    public async Task<int> GetContadorNfet_Det_01_Page(Filtro_Nfe_Det_01 Filtro)
    {
        int Retorno = 0;

        string strSelect = "";

        string strStringConexao = DataBase.RunCommand.connectionString;

        strSelect = SelectStringNfet_Det_01_Page(Filtro, 0, 0, true);

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
    public async Task<List<Nfe_DetE_Qry_01>> getProcessadoAsync(Filtro_Nfe_Det_01 Filtro, int Page, int TamPage)
    {
        List<Nfe_DetE_Qry_01> lista = new List<Nfe_DetE_Qry_01>();

        Nfe_DetE_Qry_01 obj = null;

        string strStringConexao = DataBase.RunCommand.connectionString;

        string strSelect = SelectStringNfet_Det_01_Page(Filtro, Page, TamPage, false);

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

                                obj = new Nfe_DetE_Qry_01();

                                obj = PopulaNfe_DetE_Qry_01(objDataReader);

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

    //Consulta De Planilhas
    public string SelectStringNfet_Det_00_Page(FiltroNfDetE Filtro, int Page, int TamPage, bool Contador)
    {
        string Where = "";

        string OrderBy = "Order By DET.ID,DET.NRO_LINHA";

        string strSelect = "";

        //Adiciona WHERE 
        if (Filtro.Id_Grupo != 0)
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" DET.ID_GRUPO = {Filtro.Id_Grupo} ";
        }

        if (Filtro.Id != 0)
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" DET.ID = {Filtro.Id} ";
        }

        if (Filtro.Nro != "")
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" DET.NRO LIKE '%{Filtro.Nro.Trim()}%' ";
        }

        if (Filtro.Planilha != "")
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" CAB.PLANILHA LIKE '%{Filtro.Planilha.Trim()}%' ";
        }

        if (Filtro.Empresa != "")
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" CLI.EMPRESA LIKE '%{Filtro.Empresa.Trim()}%' ";
        }
        if (Filtro.Serie != "")
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" DET.SERIE = {Filtro.Serie} ";
        }

        if (Filtro.Material != "")
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" DET.MATERIAL = '{Filtro.Material}' ";
        }

        if (Filtro.Cfop != "")
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" DET.CFOP = '{Filtro.Cfop}' ";
        }

        if ((Filtro.Dtnf != null))
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" DET.DTNF = '{Filtro.Dtnf?.ToString("YYYY-mm-dd")}' ";
        }

        if ((Filtro.Dtlanc != null))
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" DET.DTLANC = '{Filtro.Dtnf?.ToString("YYYY-mm-dd")}' ";
        }

        if (Filtro.DataInicial != null)
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" ( DET.DTNF >= '{Filtro.DataInicial?.ToString("yyyy-MM-dd")}' AND  DET.DTNF <= '{Filtro.DataFinal?.ToString("yyyy-MM-dd")}') ";
        }

        if (Filtro.Operacao != "")
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" DET.OPERACAO = '{Filtro.Operacao}' ";
        }

        if (Filtro.Status != "")
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" DET.STATUS = '{Filtro.Status}' ";
        }


        if (Contador)
        {

            strSelect = " SELECT count(det.*) as TOTAL " +
                        " FROM nfe_det_e det " +
                        " INNER JOIN nfe_cab_e cab on cab.id_grupo = det.id_grupo and cab.id = det.id " +
                        " INNER JOIN clientes cli on cli.id_grupo = det.id_grupo and cli.cod_empresa = det.cod_empresa and cli.local = det.local ";
            strSelect += $" {Where} ";

        }
        else
        {
            strSelect = " select  " +
                        "  cab.planilha          as \"Planilha\" " +
                        " ,cli.empresa           as \"Empresa\" " +
                        " ,cli.cnpj_cpf          as \"Cnpj_Cpf\" " +
                        " ,det.Id_Grupo          as \"Id_Grupo\" " +
                        " ,det.Id                as \"Id\" " +
                        " ,case " +
                        "     when det.operacao = 'A'  THEN 'SALDO ANTERIROR' " +
                        "     when det.operacao = 'X'  THEN 'ENTRADA - DISP.' " +
                        "     when det.operacao = 'V'  THEN 'VENDA' " +
                        "     when det.operacao = 'S'  THEN 'SAIDA - DISP.' " +
                        "     when det.operacao = 'E'  THEN 'ENTRADA' " +
                        "     else 'NÃO DEF.' " +
                        "     end  as \"Operacao\" " +
                        " ,det.Nro_Linha         as \"Nro_Linha\" " +
                        " ,det.Cod_Empresa       as \"Cod_Empresa\" " +
                        " ,det.Local             as \"Local\" " +
                        " ,det.Id_Planilha       as \"Id_Planilha\" " +
                        " ,det.Dtlanc            as \"Dtlanc\" " +
                        " ,det.Dtnf              as \"Dtnf\" " +
                        " ,det.Nro               as \"Nro\" " +
                        " ,det.Serie             as \"Serie\" " +
                        " ,det.Uf                as \"Uf\" " +
                        " ,det.Nr_Item           as \"Nr_Item\" " +
                        " ,det.Material          as \"Material\" " +
                        " ,det.Descricao         as \"Descricao\" " +
                        " ,det.Ncm               as \"Ncm\" " +
                        " ,det.Unid              as \"Unid\" " +
                        " ,det.Cfop              as \"Cfop\" " +
                        " ,det.Cfop_Texto        as \"Cfop_Texto\" " +
                        " ,det.Qtd               as \"Qtd\" " +
                        " ,det.Vlr_Contabil      as \"Vlr_Contabil\" " +
                        " ,det.Vlr_Unit          as \"Vlr_Unit\" " +
                        " ,det.Sti               as \"Sti\" " +
                        " ,det.Bas_Icms          as \"Bas_Icms\" " +
                        " ,det.Per_Icms          as \"Per_Icms\" " +
                        " ,det.Vlr_Icms          as \"Vlr_Icms\" " +
                        " ,det.Stp               as \"Stp\" " +
                        " ,det.Bas_Pis           as \"Bas_Pis\" " +
                        " ,det.Per_Pis           as \"Per_Pis\" " +
                        " ,det.Vlr_Pis           as \"Vlr_Pis\" " +
                        " ,det.Stc               as \"Stc\" " +
                        " ,det.Bas_Cof           as \"Bas_Cof\" " +
                        " ,det.Per_Cof           as \"Per_Cof\" " +
                        " ,det.Vlr_Cof           as \"Vlr_Cof\" " +
                        " ,det.Stip              as \"Stip\" " +
                        " ,det.Bas_Ipi           as \"Bas_Ipi\" " +
                        " ,det.Per_Ipi           as \"Per_Ipi\" " +
                        " ,det.Vlr_Ipi           as \"Vlr_Ipi\" " +
                        " ,det.Cnpj_Destinatario as \"Cnpj_Destinatario\" " +
                        " ,det.Chave             as \"Chave\" " +
                        " ,det.Nome              as \"Nome\" " +
                        " ,det.Saldo             as \"Saldo\" " +
                        " ,det.Sobra             as \"Sobra\" " +
                        " ,det.Status            as \"Status\" " +
                         " FROM nfe_det_e det " +
                        " INNER JOIN nfe_cab_e cab on cab.id_grupo = det.id_grupo and cab.id = det.id " +
                        " INNER JOIN clientes cli on cli.id_grupo = det.id_grupo and cli.cod_empresa = det.cod_empresa and cli.local = det.local ";
            strSelect += $" {Where} ";

            strSelect += $" {OrderBy} ";

            strSelect += $" LIMIT {TamPage} OFFSET {((Page - 1) * TamPage)} ";

        }

        return strSelect;
    }

    public async Task<int> GetContadorNfet_Det_00_Page(FiltroNfDetE Filtro)
    {
        int Retorno = 0;

        string strSelect = "";

        string strStringConexao = DataBase.RunCommand.connectionString;

        strSelect = SelectStringNfet_Det_00_Page(Filtro, 0, 0, true);

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

    public async Task<List<Nfe_DetE_Qry_00>> getPlanilhaAsync(FiltroNfDetE Filtro, int Page, int TamPage)
    {
        List<Nfe_DetE_Qry_00> lista = new List<Nfe_DetE_Qry_00>();

        Nfe_DetE_Qry_00 obj = null;

        string strStringConexao = DataBase.RunCommand.connectionString;

        string strSelect = SelectStringNfet_Det_00_Page(Filtro, Page, TamPage, false);

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

                                obj = new Nfe_DetE_Qry_00();

                                obj = PopulaNfe_DetE_Qry_00(objDataReader);

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

    //Planilha em arquivo
    public string SelectString_File(FiltroNfDetE Filtro, string pasta, string file)
    {
        string Where = "";

        string OrderBy = "Order By DET.ID,DET.NRO_LINHA";

        string strSelect = "";

        //Adiciona WHERE 
        if (Filtro.Id_Grupo != 0)
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" DET.ID_GRUPO = {Filtro.Id_Grupo} ";
        }

        if (Filtro.Id != 0)
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" DET.ID = {Filtro.Id} ";
        }
        if (Filtro.Planilha != "")
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" CAB.PLANILHA LIKE '%{Filtro.Planilha.Trim()}%' ";
        }

        if (Filtro.Empresa != "")
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" CLI.EMPRESA LIKE '%{Filtro.Empresa.Trim()}%' ";
        }

        if (Filtro.Nro != "")
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" DET.NRO LIKE '%{Filtro.Nro.Trim()}%' ";
        }

        if (Filtro.Serie != "")
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" DET.SERIE = {Filtro.Serie} ";
        }

        if (Filtro.Material != "")
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" DET.MATERIAL = '{Filtro.Material}' ";
        }

        if (Filtro.Cfop != "")
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" DET.CFOP = '{Filtro.Cfop}' ";
        }

        if ((Filtro.Dtnf != null))
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" DET.DTNF = '{Filtro.Dtnf?.ToString("YYYY-mm-dd")}' ";
        }

        if ((Filtro.Dtlanc != null))
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" DET.DTLANC = '{Filtro.Dtnf?.ToString("YYYY-mm-dd")}' ";
        }

        if (Filtro.DataInicial != null)
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" ( DET.DTNF >= '{Filtro.DataInicial?.ToString("yyyy-MM-dd")}' AND  DET.DTNF <= '{Filtro.DataFinal?.ToString("yyyy-MM-dd")}') ";
        }

        if (Filtro.Operacao != "")
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" DET.OPERACAO = '{Filtro.Operacao}' ";
        }

        if (Filtro.Status != "")
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" DET.STATUS = '{Filtro.Status}' ";
        }

        strSelect = " Copy ( select  " +
                    "  cab.planilha          as \"Planilha\" " +
                    " ,cli.empresa           as \"Empresa\" " +
                    $",{Coluna_Copy.NumericLikeText("cli.cnpj_cpf", "Cnpj_Cpf")}" +
                    " ,det.Id_Grupo          as \"Id_Grupo\" " +
                    " ,det.Id                as \"Id\" " +
                    " ,case " +
                    "     when det.operacao = 'A'  THEN 'SALDO ANTERIROR' " +
                    "     when det.operacao = 'X'  THEN 'ENTRADA - DISP.' " +
                    "     when det.operacao = 'V'  THEN 'VENDA' " +
                    "     when det.operacao = 'S'  THEN 'SAIDA - DISP.' " +
                    "     when det.operacao = 'E'  THEN 'ENTRADA' " +
                    "     else 'NÃO DEF.' " +
                    "     end  as \"Operacao\" " +
                    " ,det.Nro_Linha         as \"Nro_Linha\" " +
                    " ,det.Cod_Empresa       as \"Cod_Empresa\" " +
                    " ,det.Local             as \"Local\" " +
                    " ,det.Id_Planilha       as \"Id_Planilha\" " +
                    " ,det.Dtlanc            as \"Dtlanc\" " +
                    " ,det.Dtnf              as \"Dtnf\" " +
                     $",{Coluna_Copy.NumericLikeText("det.Nro", "NRO")}" +
                     $",{Coluna_Copy.NumericLikeText("det.Serie", "SERIE")}" +
                    " ,det.Uf                as \"Uf\" " +
                    " ,det.Nr_Item           as \"Nr_Item\" " +
                    " ,det.Material          as \"Material\" " +
                    " ,det.Descricao         as \"Descricao\" " +
                    " ,det.Ncm               as \"Ncm\" " +
                    " ,det.Unid              as \"Unid\" " +
                    $",{Coluna_Copy.NumericLikeText("det.cfop", "CFOP")}" +
                    $",{Coluna_Copy.NumericLikeText("det.Cfop_Texto", "CFOP_TEXTO")}" +
                    $",{Coluna_Copy.NumericFormat("det.qtd", 12, 4, "QTD")}" +
                    $",{Coluna_Copy.NumericFormat("det.vlr_contabil", 12, 4, "VALOR_TOTAL")} " +
                    $",{Coluna_Copy.NumericFormat("det.Vlr_Unit", 12, 2, "VLR_UNIT")} " +
                    " ,det.Sti               as \"Sti\" " +
                    $",{Coluna_Copy.NumericFormat("det.bas_icms", 12, 2, "BASE_ICMS")} " +
                    $",{Coluna_Copy.NumericFormat("det.per_icms", 6, 2,  "PERC_ICMS")} " +
                    $",{Coluna_Copy.NumericFormat("det.vlr_icms", 12, 2,  "VLR_ICMS")} " +
                    " ,det.Stp               as \"Stp\" " +
                    $",{Coluna_Copy.NumericFormat("det.bas_pis", 12, 2, "BASE_PIS")} " +
                    $",{Coluna_Copy.NumericFormat("det.per_pis", 6, 2, "PERC_PIS")} " +
                    $",{Coluna_Copy.NumericFormat("det.vlr_pis", 12, 2, "VLR_PIS")} " +
                    " ,det.Stc               as \"Stc\" " +
                    $",{Coluna_Copy.NumericFormat("det.bas_cof", 12, 2, "BASE_COF")} " +
                    $",{Coluna_Copy.NumericFormat("det.per_cof", 6, 2, "PERC_COFINS")} " +
                    $",{Coluna_Copy.NumericFormat("det.vlr_cof", 12, 2, "VLR_COF")} " +
                    " ,det.Stip              as \"Stip\" " +
                    $",{Coluna_Copy.NumericFormat("det.bas_ipi", 12, 2, "BASE_IPI")} " +
                    $",{Coluna_Copy.NumericFormat("det.per_ipi", 6, 2, "PERC_IPI")} " +
                    $",{Coluna_Copy.NumericFormat("det.vlr_ipi", 12, 2, "VLR_IPI")} " +
                     $",{Coluna_Copy.NumericLikeText("det.Cnpj_Destinatario", "Cnpj_Destinatario")}" +
                    $",{Coluna_Copy.NumericLikeText("det.Chave", "chave")}" +
                    " ,det.Nome              as \"Nome\" " +
                    $",{Coluna_Copy.NumericFormat("det.saldo", 12, 4, "SALDO_VENDA")} " + 
                    $",{Coluna_Copy.NumericFormat("det.sobra", 12, 4, "SALDO_VENDA")} " +
                    " ,det.Status            as \"Status\" " +
                    " FROM nfe_det_e det " +
                    " INNER JOIN nfe_cab_e cab on cab.id_grupo = det.id_grupo and cab.id = det.id " +
                    " INNER JOIN clientes cli on cli.id_grupo = det.id_grupo and cli.cod_empresa = det.cod_empresa and cli.local = det.local ";
        strSelect += $" {Where} ";

        strSelect += $" {OrderBy} ";

        strSelect += $" ) To '{pasta}{file}.csv' With CSV DELIMITER ';'  HEADER  encoding 'latin1'; ";


        return strSelect;
    }
    public async Task<string> Planilha_Nfet_Det_00(FiltroNfDetE Filtro, string pasta, string file)
    {
        string retorno = "Relatório Gravado Com Sucesso!";

        string strStringConexao = DataBase.RunCommand.connectionString;

        string strSelect = SelectString_File(Filtro, pasta, file);

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

    //Sados Ou Entradas Com Vencimento

    public string SelectStringVencimento_File(FiltroVencimento Filtro, string pasta, string file)
    {
        string Where = "";

        string OrderBy = "Order By DET.ID,DET.NRO_LINHA";

        string strSelect = "";

        //Adiciona WHERE 


        if (Filtro.Id_Grupo != 0)
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" DET.ID_GRUPO = {Filtro.Id_Grupo} ";
        }

        if (Filtro.Periodo)
        {
            if ( (Filtro.DtInicial != null) && (Filtro.DtInicial != null) )
            {
                Where += Where == "" ? " where " : " and ";
                Where += $" ((DET.DTNF >= '{Filtro.DtInicial?.ToString("yyyy-MM-dd")}') AND (DET.DTLNF <= '{Filtro.DtFinal?.ToString("yyyy-MM-dd")}')) ";
            }

        }

        Where += " AND (DET.OPERACAO = 'E'  AND DET.VLR_COF > 0) OR(DET.OPERACAO = 'A') ";


        /*
        if (Filtro.Id != 0)
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" DET.ID = {Filtro.Id} ";
        }
        if (Filtro.Planilha != "")
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" CAB.PLANILHA LIKE '%{Filtro.Planilha.Trim()}%' ";
        }

        if (Filtro.Empresa != "")
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" CLI.EMPRESA LIKE '%{Filtro.Empresa.Trim()}%' ";
        }

        if (Filtro.Nro != "")
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" DET.NRO LIKE '%{Filtro.Nro.Trim()}%' ";
        }

        if (Filtro.Serie != "")
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" DET.SERIE = {Filtro.Serie} ";
        }

        if (Filtro.Material != "")
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" DET.MATERIAL = '{Filtro.Material}' ";
        }

        if (Filtro.Cfop != "")
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" DET.CFOP = '{Filtro.Cfop}' ";
        }

        if ((Filtro.Dtnf != null))
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" DET.DTNF = '{Filtro.Dtnf?.ToString("YYYY-mm-dd")}' ";
        }

        if ((Filtro.Dtlanc != null))
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" DET.DTLANC = '{Filtro.Dtnf?.ToString("YYYY-mm-dd")}' ";
        }

        if (Filtro.DataInicial != null)
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" ( DET.DTNF >= '{Filtro.DataInicial?.ToString("yyyy-MM-dd")}' AND  DET.DTNF <= '{Filtro.DataFinal?.ToString("yyyy-MM-dd")}') ";
        }

        if (Filtro.Operacao != "")
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" DET.OPERACAO = '{Filtro.Operacao}' ";
        }

        if (Filtro.Status != "")
        {
            Where += Where == "" ? " where " : " and ";
            Where += $" DET.STATUS = '{Filtro.Status}' ";
        }
        */
    /*
        strSelect = " Copy ( select  " +
                   $"'{Filtro.DtRef?.ToString("dd/MM/yyyy")}' AS DT_REF , " +
                    "  DET.dtnf as DATA_NFE, " +
                   $" TO_CHAR( date '{Filtro.DtRef?.ToString("yyyy-MM-dd")}' - interval '4 years 11 months','DD/MM/YYYY') as VENCIMENTO, " +
                   $" {Coluna_Copy.NumericFormat("DET.SALDO", 12, 4, "SALDO")} ,  " +
                    "  CASE " +
                   $"      WHEN DET.dtnf < date '{Filtro.DtRef?.ToString("yyyy-MM-dd")}' - interval '5 years' THEN 'VENCIDA' " +
                    "      ELSE                                                           'OK     ' " +
                    "  END AS STATUS, ";
                   if (Filtro.Fechamentos != "")
                    {
                        strSelect += " (SELECT COUNT(*) FROM CONTROLE_E CON WHERE CON.ID_GRUPO = 1 AND CON.ID_E = DET.ID AND CON.NRO_LINHA_E = DET.NRO_LINHA ) NFES_USADAS, ";
                    }
       strSelect += " DET.ID_GRUPO,    " +
                    " DET.ID      ,    " +
                    " DET.OPERACAO,    " +
                    " DET.NRO_LINHA ,  " +
                    $" {Coluna_Copy.NumericLikeText("DET.COD_EMPRESA", "COD_EMPRESA")} ,  " +
                    $" {Coluna_Copy.NumericLikeText("DET.LOCAL", "LOCAL")}  ,  " +
                    $" {Coluna_Copy.NumericLikeText("DET.ID_PLANILHA", "ID_PLANILHA")} ,  " +
                    " DET.DTLANC,       " +
                    " DET.DTNF          " +
                    $",{Coluna_Copy.NumericLikeText("DET.NRO", "NRO")} " +
                    $",{Coluna_Copy.NumericLikeText("DET.SERIE", "SERIE")}" +
                    $",DET.UF " +
                    $",DET.NR_ITEM " +
                    $",DET.MATERIAL " +
                    $",DET.DESCRICAO " +
                    $",DET.NCM " +
                    $",DET.UNID " +
                    $",{Coluna_Copy.NumericLikeText("det.cfop", "CFOP")} " +
                    $",{Coluna_Copy.NumericLikeText("det.Cfop_Texto", "CFOP_TEXTO")} " +
                    $",{Coluna_Copy.NumericFormat("det.qtd", 12, 4, "QTD")} " +
                    $",{Coluna_Copy.NumericFormat("DET.VLR_CONTABIL", 12, 4, "VLR_CONTABIL")} " +
                    $",{Coluna_Copy.NumericFormat("DET.VLR_UNIT", 12, 2, "VLR_UNIT")} " +
                    $",{Coluna_Copy.NumericFormat("DET.BAS_ICMS", 12, 2, "BASE_ICMS")} " +
                    $",{Coluna_Copy.NumericFormat("DET.PER_ICMS", 6, 2, "PERC_ICMS")} " +
                    $",{Coluna_Copy.NumericFormat("DET.VLR_ICMS", 12, 2, "VLR_ICMS")} " +
                    $",{Coluna_Copy.NumericFormat("DET.BAS_PIS", 12, 2, "BASE_PIS")} " +
                    $",{Coluna_Copy.NumericFormat("DET.PER_PIS", 6, 2, "PERC_PIS")} " +
                    $",{Coluna_Copy.NumericFormat("DET.VLR_PIS", 12, 2, "VLR_PIS")} " +
                    $",{Coluna_Copy.NumericFormat("DET.BAS_COF", 12, 2, "BASE_COF")} " +
                    $",{Coluna_Copy.NumericFormat("DET.PER_COF", 6, 2, "PERC_COF")} " +
                    $",{Coluna_Copy.NumericFormat("DET.VLR_COF", 12, 2, "VLR_COF")} " +
                    $",{Coluna_Copy.NumericFormat("DET.BAS_IPI", 12, 4, "BASE_IPI")} " +
                    $",{Coluna_Copy.NumericFormat("DET.PER_IPI", 6, 2, "PERC_IPI")} " +
                    $",{Coluna_Copy.NumericFormat("DET.VLR_IPI", 12, 4, "VLR_IPI")} " +
                    $",{Coluna_Copy.NumericLikeText("DET.CNPJ_DESTINATARIO", "Cnpj_Cpf")} " +
                    $",{Coluna_Copy.NumericLikeText("DET.CHAVE", "CHAVE")} " +
                    ",DET.NOME  " +
                    $",{Coluna_Copy.NumericFormat("DET.SALDO", 12, 4, "SALDO")} " +
                    " FROM   NFE_DET_E DET  ";
                    if (Filtro.Fechamentos != "")
                    {
                        strSelect += $" INNER JOIN FECHAMENTO FEC ON FEC.ID_GRUPO = {Filtro.Id_Grupo} AND FEC.ID IN {Filtro.Fechamentos} ";
                    }

        strSelect += $" {Where} ";

        strSelect += $" {OrderBy} ";

        strSelect += $" ) To '{pasta}{file}.csv' With CSV DELIMITER ';'  HEADER  encoding 'latin1'; ";

        return strSelect;
    }

    public async Task<string> Planilha_Nfet_Det_Venc(FiltroVencimento Filtro, string pasta, string file)
    {
        string retorno = "Relatório Gravado Com Sucesso!";

        string strStringConexao = DataBase.RunCommand.connectionString;

        string strSelect = SelectStringVencimento_File(Filtro, pasta, file);

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
    */
}
