using Npgsql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trade_GP.Models;
using Trade_GP.Util;

namespace Trade_GP.Dao.postgre
{
    class daoResumo5405
    {

        public Resumo_5405 Insert(Resumo_5405 obj)
        {
            Resumo_5405 retorno = null;

            String StringInsert = "INSERT INTO resumo_5405(id_grupo, cod_emp, local, material, descricao, unid, fator, dt_ref,validade,origem) " +
                                  "VALUES(@id_grupo, @cod_emp, @local, @material, @descricao, @unid, @fator, @dt_ref,@validade,@origem) RETURNING *";

            try
            {
                using (var objConexao = new NpgsqlConnection(DataBase.RunCommand.connectionString))
                using (var objCommand = new NpgsqlCommand(StringInsert, objConexao))
                {
                    objCommand.Parameters.AddWithValue("@id_grupo", obj.id_grupo);
                    objCommand.Parameters.AddWithValue("@cod_emp", obj.cod_emp);
                    objCommand.Parameters.AddWithValue("@local", obj.local);
                    objCommand.Parameters.AddWithValue("@material", obj.material);
                    objCommand.Parameters.AddWithValue("@descricao", obj.descricao);
                    objCommand.Parameters.AddWithValue("@unid", obj.unid);
                    objCommand.Parameters.AddWithValue("@fator", obj.fator);
                    objCommand.Parameters.AddWithValue("@validade", obj.validade);
                    objCommand.Parameters.AddWithValue("@dt_ref", obj.dt_ref);
                    objCommand.Parameters.AddWithValue("@origem", obj.origem);

                    objConexao.Open();
                    var objDataReader = objCommand.ExecuteReader();

                    if (objDataReader.HasRows)
                    {
                        while (objDataReader.Read())
                        {
                            retorno = PopulaResumo(objDataReader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro no Insert: {ex.Message}");
            }

            return retorno;
        }


        public Resumo_5405 UpdateX(Resumo_5405 obj)
        {

            Resumo_5405 resumo = this.Seek(obj);

            if (resumo == null)
            {
                try
                {
                    obj = this.Insert(obj);
                }
                catch (Exception ex)
                {
                    obj = null;
                }
            }

            return obj;
        }

 
        public void Update(Resumo_5405 obj)
        {
            String StringUpdate = "UPDATE resumo_5405 SET " +
                                  "dt_ref = @dt_ref, " +
                                  "unid = @unid, " +
                                  "fator = @fator " +
                                  "validade = @validade " +
                                  "origem = @origem " +
                                  "WHERE id_grupo = @id_grupo AND cod_emp = @cod_emp AND local = @local AND material = @material and unid = @unid;";

            try
            {
                using (var objConexao = new NpgsqlConnection(DataBase.RunCommand.connectionString))
                {
                    using (var objCommand = new NpgsqlCommand(StringUpdate, objConexao))
                    {
                        objCommand.Parameters.AddWithValue("@dt_ref", obj.dt_ref);
                        objCommand.Parameters.AddWithValue("@unid", obj.unid);
                        objCommand.Parameters.AddWithValue("@fator", obj.fator);
                        objCommand.Parameters.AddWithValue("@validade", obj.validade);
                        objCommand.Parameters.AddWithValue("@id_grupo", obj.id_grupo);
                        objCommand.Parameters.AddWithValue("@cod_emp", obj.cod_emp);
                        objCommand.Parameters.AddWithValue("@local", obj.local);
                        objCommand.Parameters.AddWithValue("@material", obj.material);
                        objCommand.Parameters.AddWithValue("@origem", obj.material);

                        objConexao.Open();
                        objCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (ExceptionErroImportacao ex)
            {
                MessageBox.Show(ex.Message, "Atenção!");
            }
        }

        public void Delete(Resumo_5405 obj)
        {
            String StringDelete = "DELETE FROM resumo_5405 WHERE id_grupo = @id_grupo AND cod_emp = @cod_emp AND local = @local AND material = @material AND unid = @unid;";

            try
            {
                using (var objConexao = new NpgsqlConnection(DataBase.RunCommand.connectionString))
                {
                    using (var objCommand = new NpgsqlCommand(StringDelete, objConexao))
                    {
                        objCommand.Parameters.AddWithValue("@id_grupo", obj.id_grupo);
                        objCommand.Parameters.AddWithValue("@cod_emp", obj.cod_emp);
                        objCommand.Parameters.AddWithValue("@local", obj.local);
                        objCommand.Parameters.AddWithValue("@material", obj.material);
                        objCommand.Parameters.AddWithValue("@dt_ref", obj.dt_ref);
                        objCommand.Parameters.AddWithValue("@unid", obj.unid);

                        objConexao.Open();
                        objCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção!");
            }
        }

        public Resumo_5405 Seek(Resumo_5405 obj)
        {
            string StringSelect = "SELECT * FROM resumo_5405 WHERE id_grupo = @id_grupo AND cod_emp = @cod_emp AND local = @local AND material = @material AND unid = @unid ;";

            using (var objConexao = new NpgsqlConnection(DataBase.RunCommand.connectionString))
            {
                using (var objCommand = new NpgsqlCommand(StringSelect, objConexao))
                {
                    objCommand.Parameters.AddWithValue("@id_grupo", obj.id_grupo);
                    objCommand.Parameters.AddWithValue("@cod_emp", obj.cod_emp);
                    objCommand.Parameters.AddWithValue("@local", obj.local);
                    objCommand.Parameters.AddWithValue("@material", obj.material);
                    objCommand.Parameters.AddWithValue("@unid", obj.unid);

                    try
                    {
                        objConexao.Open();
                        var objDataReader = objCommand.ExecuteReader();

                        if (objDataReader.HasRows)
                        {
                            objDataReader.Read();
                            obj = PopulaResumo(objDataReader);
                        }
                        else
                        {
                            obj = null;
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

        private Resumo_5405 PopulaResumo(NpgsqlDataReader objDataReader)
        {

            var obj = new Resumo_5405
            {
                id_grupo = Convert.ToInt16(objDataReader["id_grupo"]),
                cod_emp = objDataReader["cod_emp"].ToString(),
                local = objDataReader["local"].ToString(),
                material = objDataReader["material"].ToString(),
                descricao = objDataReader["descricao"].ToString(),
                unid = objDataReader["unid"].ToString(),
                fator = Convert.ToDouble(objDataReader["fator"]),
                validade = Convert.ToInt16(objDataReader["validade"]),
                dt_ref = objDataReader["dt_ref"] != DBNull.Value ? Convert.ToDateTime(objDataReader["dt_ref"]) : DateTime.MinValue,
                origem = objDataReader["origem"].ToString()

            };

            return obj;
        }

        private Resumo_5405_01 PopulaResumo_01(NpgsqlDataReader objDataReader)
        {

            var obj = new Resumo_5405_01
            {
                material = objDataReader["material"].ToString(),
                descricao = objDataReader["descricao"].ToString(),
                unid = objDataReader["unid"].ToString(),
                fator = Convert.ToDouble(objDataReader["fator"]),
                dt_ref = objDataReader["dt_ref"] == DBNull.Value
            ? DateTime.MinValue
            : Convert.ToDateTime(objDataReader["dt_ref"]),
             validade = Convert.ToInt16(objDataReader["validade"])
            };

            return obj;
        }

        public async Task<int> existe5405(int id_grupo, string cod_emp)
        {
            int total = 0;

            String StringProc = $"SELECT COUNT(*) AS TOTAL FROM resumo_5405 where id_grupo = '{id_grupo}' and cod_emp = '{cod_emp}' ";

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
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Atenção!");

                            total = -1;
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


        public List<Resumo_5405_01> getAll(int id_grupo, string cod_emp, string local)
        {
            var lista = new List<Resumo_5405_01>();

            string query = $"SELECT material, descricao, unid, fator, dt_ref, validade " +
                            "FROM resumo_5405 " +
                           $"WHERE id_grupo = {id_grupo} AND cod_emp = '{cod_emp}' AND local = '{local}' " +
                            "ORDER BY material,unid;";

            Console.WriteLine("GetALL", query);

            try
            {
                using (var connection = new NpgsqlConnection(DataBase.RunCommand.connectionString))
                using (var command = new NpgsqlCommand(query, connection))
                {
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(PopulaResumo_01(reader));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao obter dados: {ex.Message}");
            }

            return lista;
        }

        public string SqlGrid(int id_grupo, string cod_emp, string local, DateTime dt_ref)
        {
            string Where = "";

            string OrderBy = "";

            string strSelect = "select  material, descricao , unid, fator, dt_ref , validade from resumo_5405 ";

            Where = $"WHERE  id_grupo = {id_grupo} and cod_emp = '{cod_emp}' and local = '{local}'  and dt_ref = '{dt_ref}' ";


            //Adiciona ORDER BY

            OrderBy = $"ORDER BY MATERIAL";

            strSelect += $" {Where} {OrderBy} ";

            return strSelect;

        }

        public void reindex()
        {
            String StringReindex = "select * from reindex()";
            try
            {
                using (var objConexao = new NpgsqlConnection(DataBase.RunCommand.connectionString))
                {
                    using (var objCommand = new NpgsqlCommand(StringReindex, objConexao))
                    {
                        objConexao.Open();
                        objCommand.ExecuteNonQuery();
                    }

                    objConexao.Close();
                }
            }
            catch (ExceptionErroImportacao ex)
            {
                MessageBox.Show(ex.Message, "Atenção!");
            }
        } 

        public void vacuum()
        {
            String StringVacuum = "VACUUM ANALYZE NFE_DET_TRADE;";
            try
            {
                using (var objConexao = new NpgsqlConnection(DataBase.RunCommand.connectionString))
                {
                    using (var objCommand = new NpgsqlCommand(StringVacuum, objConexao))
                    {
                        objConexao.Open();
                        objCommand.ExecuteNonQuery();
                    }

                    objConexao.Close();
                }
            }
            catch (ExceptionErroImportacao ex)
            {
                MessageBox.Show(ex.Message, "Atenção!");
            }
        }

    }
}
