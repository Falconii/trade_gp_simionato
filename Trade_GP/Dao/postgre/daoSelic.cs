using Trade_GP.Extensoes;
using Trade_GP.Models;
using Trade_GP.Util;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Trade_GP.Dao.postgre
{
    class daoSelic
    {
        public Selic Insert(Selic obj)
        {
            Selic retorno = null;

            String StringInsert = $" INSERT INTO SELIC " +
                                "(ANO,MES,TAXA) " +
                                " VALUES(" +
                                $"  '{obj.Ano}', '{obj.Mes}', {obj.Taxa.DoubleParseDb()} ) RETURNING  * ";
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

                                    retorno = PopulaSelic(objDataReader);

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

        public void Update(Selic
            obj)
        {

            String StringUpdate = $" UPDATE SELIC SET " +
                    $" TAXA = {obj.Taxa.DoubleParseDb()}  " +
                    $"WHERE ANO = '{obj.Ano}' AND MES = '{obj.Mes}'";

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

        public void Delete(Selic obj)
        {

            String StringDelete = $" DELETE FROM  SELIC  WHERE ANO = '{obj.Ano}'  AND MES = '{obj.Mes}'";

            DataBase.RunCommand.CreateCommand(StringDelete);

        }

        public Selic Seek(string ano, string mes)
        {

            Selic obj = null;

            string strStringConexao = DataBase.RunCommand.connectionString;

            string strSelect = $"SELECT * FROM SELIC WHERE ANO = '{ano}'  AND MES = '{mes}'";

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

                            obj = new Selic();

                            obj = PopulaSelic(objDataReader);


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

        private Selic PopulaSelic(NpgsqlDataReader objDataReader)
        {

            var obj = new Selic()
            {
                Ano = objDataReader["ANO"].ToString(),
                Mes = objDataReader["MES"].ToString(),
                Taxa = Convert.ToDouble(objDataReader["TAXA"])
            };

            return obj;
        }

        public List<Selic> getAll(int Ordenacao, string Filtro)
        {

            Selic obj = null;

            string strStringConexao = DataBase.RunCommand.connectionString;

            List<Selic> lista = new List<Selic>();

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

                                obj = new Selic();

                                obj = PopulaSelic(objDataReader);

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
                                 "ANO,  " +
                                 "MES,  " +
                                 "TAXA  " +
                                 "FROM SELIC ";

            //Adiciona WHERE 
            if (Filtro.Trim() != "")
            {
                switch (Ordenacao)
                {
                    case 0:
                        Where = $"WHERE ANO = '{Filtro}' ";
                        break;
                }


            }

            //Adiciona ORDER BY


            switch (Ordenacao)
            {
                case 0:
                    OrderBy = $"ORDER BY ANO,MES";
                    break;
            }

            strSelect += $" {Where} {OrderBy} ";

            return strSelect;

        }
    }
}
