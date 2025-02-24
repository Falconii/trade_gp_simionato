using System; // Importa tipos fundamentais do C#
using Npgsql; // Importa tipos relacionados à comunicação com o banco de dados PostgreSQL
using System.Windows.Forms; // Importa tipos relacionados à criação de interfaces gráficas usando Windows Forms
using Trade_GP.Models; // Importa tipos definidos no namespace Trade_GP.Models
using Trade_GP.Util;

namespace Trade_GP.Dao.postgre
{
    public class daoContDetProc
    {
        public ContDetProc Insert(ContDetProc obj)
        {
            ContDetProc retorno = null;

            String StringInsert = $"INSERT INTO cont_det_proc " +
                                  "(Id_Grupo, Cod_Emp, Local, Id_Cabec, Ano, Mes, Id_Processo, Status) " +
                                  "VALUES(" +
                                  $"{obj.Id_Grupo}, '{obj.Cod_Emp}', '{obj.Local}', '{obj.Id_Cabec}', '{obj.Ano}', '{obj.Mes}', '{obj.Id_Processo}', '{obj.Status}' ) RETURNING *";

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
                                objDataReader.Read();
                                retorno = PopulaContDetProc(objDataReader);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Erro ao inserir registro: {ex.Message}", "Erro de Inserção");
                            throw new Exception(ex.Message);
                        }
                        finally
                        {
                            objConexao.Close();
                        }
                    }
                }

                return retorno;
            }
            catch (ExceptionErroImportacao ex)
            {
                MessageBox.Show($"Erro ao conectar ao banco de dados: {ex.Message}", "Erro de Conexão");
                retorno = null;
            }

            return retorno;
        }

        public void Update(ContDetProc obj)
        {
            String StringUpdate = $"UPDATE cont_det_proc SET " +
                                  $"Status = '{obj.Status}' " +
                                  $"WHERE Id_Grupo = {obj.Id_Grupo} AND " +
                                  $"Cod_Emp = '{obj.Cod_Emp}' AND " +
                                  $"Local = '{obj.Local}' AND " +
                                  $"Id_Cabec = '{obj.Id_Cabec}' AND " +
                                  $"Ano = '{obj.Ano}' AND " +
                                  $"Mes = '{obj.Mes}' AND " +
                                  $"Id_Processo = '{obj.Id_Processo}'";

            Console.WriteLine(StringUpdate);

            try
            {
                DataBase.RunCommand.CreateCommand(StringUpdate);
            }
            catch (ExceptionErroImportacao ex)
            {
                MessageBox.Show(ex.Message, "Atenção!");
            }
        }

        public void Delete(ContDetProc obj)
        {
            String StringDelete = $"DELETE FROM cont_det_proc WHERE " +
                                  $"Id_Grupo = {obj.Id_Grupo} AND " +
                                  $"Cod_Emp = '{obj.Cod_Emp}' AND " +
                                  $"Local = '{obj.Local}' AND " +
                                  $"Id_Cabec = '{obj.Id_Cabec}' AND " +
                                  $"Ano = '{obj.Ano}' AND " +
                                  $"Mes = '{obj.Mes}' AND " +
                                  $"Id_Processo = '{obj.Id_Processo}'";

            try
            {
                DataBase.RunCommand.CreateCommand(StringDelete);
            }
            catch (ExceptionErroImportacao ex)
            {
                MessageBox.Show(ex.Message, "Atenção!");
            }
        }

        public ContDetProc Seek(int idGrupo, string codEmp, string local, string idCabec, string ano, string mes, string idProcesso)
        {
            ContDetProc obj = null;

            string strStringConexao = DataBase.RunCommand.connectionString;

            string strSelect = $"SELECT * FROM cont_det_proc WHERE " +
                               $"Id_Grupo = {idGrupo} AND " +
                               $"Cod_Emp = '{codEmp}' AND " +
                               $"Local = '{local}' AND " +
                               $"Id_Cabec = '{idCabec}' AND " +
                               $"Ano = '{ano}' AND " +
                               $"Mes = '{mes}' AND " +
                               $"Id_Processo = '{idProcesso}'";

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
                            obj = PopulaContDetProc(objDataReader);
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

        public ContDetProc PopulaContDetProc(NpgsqlDataReader objDataReader)
        {
            var obj = new ContDetProc()
            {
                Id_Grupo = Convert.ToInt32(objDataReader["Id_Grupo"]),
                Cod_Emp = objDataReader["Cod_Emp"].ToString(),
                Local = objDataReader["Local"].ToString(),
                Id_Cabec = Convert.ToInt32(objDataReader["Id_Cabec"]),
                Ano = objDataReader["Ano"].ToString(),
                Mes = objDataReader["Mes"].ToString(),
                Id_Processo = objDataReader["Id_Processo"].ToString(),
                Status = objDataReader["Status"].ToString() // Convertendo char para string
            };

            return obj;
        }
    }
}
