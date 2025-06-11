using Trade_GP.Extensoes;
using Trade_GP.Models;
using Trade_GP.Util;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Trade_GP.Dao.postgre
{
    class daoParametro
    {
        public Parametro Insert(Parametro obj)
        {
            Parametro retorno = null;

            String StringInsert = $" INSERT INTO PARAMETRO " +
                                "(CHAVE,VALOR) " +
                                " VALUES(" +
                                $"  '{obj.Chave}', '{obj.Valor}') RETURNING  * ";
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

                                    retorno = PopulaParametro(objDataReader);

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

                return retorno;
            }
            catch (ExceptionErroImportacao ex)
            {
                MessageBox.Show(ex.Message, "Atenção!");

                retorno = null;
            }

            return retorno;

        }

        public void Update(Parametro obj)
        {

            String StringUpdate = $" UPDATE PARAMETRO SET " +
                    $" VALOR = '{obj.Valor}' " +
                    $"WHERE CHAVE = '{obj.Chave}' ";

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

        public void Delete(Parametro obj)
        {

            String StringDelete = $" DELETE FROM  PARAMETRO  WHERE CHAVE = '{obj.Chave}' ";

            DataBase.RunCommand.CreateCommand(StringDelete);

        }

        public Parametro Seek(string chave)
        {

            Parametro obj = null;

            string strStringConexao = DataBase.RunCommand.connectionString;

            string strSelect = $"SELECT * FROM PARAMETRO WHERE CHAVE = '{chave}' ";

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

                            obj = new Parametro();

                            obj = PopulaParametro(objDataReader);


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

        private Parametro PopulaParametro(NpgsqlDataReader objDataReader)
        {

            var obj = new Parametro()
            {
                Chave = objDataReader["CHAVE"].ToString(),
                Valor = objDataReader["VALOR"].ToString()
            };

            return obj;
        }

        public List<Parametro> getAll(int Ordenacao, string Filtro)
        {

            Parametro obj = null;

            string strStringConexao = DataBase.RunCommand.connectionString;

            List<Parametro> lista = new List<Parametro>();

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

                                obj = new Parametro();

                                obj = PopulaParametro(objDataReader);

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

            string strSelect = "SELECT  " +
                                 "CHAVE,  " +
                                 "VALOR  " +
                                 "FROM PARAMETRO ";

            //Adiciona WHERE 
            if (Filtro.Trim() != "")
            {
                switch (Ordenacao)
                {
                    case 0:
                        Where = $"WHERE CHAVE = '{Filtro}' ";
                        break;
                }


            }

            //Adiciona ORDER BY


            switch (Ordenacao)
            {
                case 0:
                    OrderBy = $"ORDER BY CHAVE ";
                    break;
            }

            strSelect += $" {Where} {OrderBy} ";

            return strSelect;

        }

        
    }



}
