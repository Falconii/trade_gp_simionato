using Npgsql;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Trade_GP.Models;
using Trade_GP.Util;

namespace Trade_GP.Dao.postgre
{
    class daoUsuario
    {

        public Usuario Insert(Usuario obj)
        {

            int Novo = LastReg() + 1;

            String StringInsert = $" INSERT INTO USUARIOS " +
                                "(RAZAO, CNPJ_CPF, CADASTR, ENDERECO, BAIRRO, CIDADE, UF, CEP, TEL1, TEL2, EMAIL, PASTA, SENHA) " +
                                " VALUES(" +
                                $" '{obj.Razao}','{obj.Cnpj_Cpf}','{obj.Cadastr}','{obj.Endereco}', '{obj.Bairro}' , '{obj.Cidade}','{obj.Uf}','{obj.Cep}','{obj.Tel1}','{obj.Tel2}','{obj.Email}','{obj.Pasta}','{obj.Senha}')";
            try
            {

                DataBase.RunCommand.CreateCommand(StringInsert);

                obj = Seek(Novo);

            }
            catch (ExceptionErroImportacao ex)
            {
                MessageBox.Show(ex.Message, "Atenção!");

                obj = null;
            }


            return obj;


        }

        public void Update(Usuario obj)
        {

            String StringUpdate = $" UPDATE  USUARIOS SET " +
                 $"CNPJ_CPF = '{obj.Cnpj_Cpf}', " +
                 $"RAZAO    = '{obj.Razao}', " +
                 $"CADASTR  = '{obj.Cadastr}', " +
                 $"ENDERECO = '{obj.Endereco}', " +
                 $"BAIRRO   = '{obj.Bairro}' , " +
                 $"CIDADE   = '{obj.Cidade}', " +
                 $"UF       = '{obj.Uf}', " +
                 $"CEP      = '{obj.Cep}'," +
                 $"TEL1     = '{obj.Tel1}', " +
                 $"TEL2     = '{obj.Tel2}', " +
                 $"EMAIL    = '{obj.Email}', " +
                 $"PASTA    = '{obj.Pasta}', " +
                 $"SENHA    = '{obj.Senha}' " +
                 $"WHERE CODIGO = {obj.Codigo} ";

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

        public void Delete(Usuario obj)
        {

            String StringDelete = $" DELETE FROM  USUARIOS  WHERE CODIGO = {obj.Codigo} ";

            DataBase.RunCommand.CreateCommand(StringDelete);

        }

        public Usuario Seek(int codigo)
        {

            Usuario obj = null;

            string strStringConexao = DataBase.RunCommand.connectionString;

            string strSelect = $"SELECT * FROM USUARIOS WHERE CODIGO = {codigo}";

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

                            obj = new Usuario();

                            obj = PopulaUsuario(objDataReader);


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

        public int LastReg()
        {

            int Last = -1;

            string strStringConexao = DataBase.RunCommand.connectionString;

            string strSelect = "SELECT COALESCE(MAX(CODIGO), 0) AS CODIGO FROM USUARIOS"
 ;
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

                            Last = Convert.ToInt32(objDataReader["CODIGO"]);

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

            return Last;
        }

        private Usuario PopulaUsuario(NpgsqlDataReader objDataReader)
        {

            var obj = new Usuario();

            obj.Codigo = Convert.ToInt32(objDataReader["CODIGO"]);

            obj.Cnpj_Cpf = objDataReader["CNPJ_CPF"].ToString();
            obj.Razao = objDataReader["RAZAO"].ToString();
            obj.Cadastr = Convert.ToDateTime(objDataReader["CADASTR"]);
            obj.Endereco = objDataReader["ENDERECO"].ToString();
            obj.Bairro = objDataReader["BAIRRO"].ToString();
            obj.Cidade = objDataReader["CIDADE"].ToString();
            obj.Uf = objDataReader["UF"].ToString();
            obj.Cep = objDataReader["CEP"].ToString();
            obj.Tel1 = objDataReader["TEL1"].ToString();
            obj.Tel2 = objDataReader["TEL2"].ToString();
            obj.Email = objDataReader["EMAIL"].ToString();
            obj.Pasta = objDataReader["PASTA"].ToString();
            obj.Senha = objDataReader["SENHA"].ToString();

            return obj;
        }

    

        public List<Usuario> getAll(int Ordenacao, string Filtro)
        {

            Usuario obj = null;

            string strStringConexao = DataBase.RunCommand.connectionString;

            List<Usuario> lista = new List<Usuario>();

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

                                obj = new Usuario();

                                obj = PopulaUsuario(objDataReader);

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
                                " CODIGO " +
                                " , CNPJ_CPF " +
                                " , RAZAO " +
                                " , CADASTR " +
                                " , ENDERECO " +
                                " , BAIRRO " +
                                " , CIDADE " +
                                " , UF " +
                                " , CEP " +
                                " , TEL1 " +
                                " , TEL2 " +
                                " , EMAIL " +
                                " , PASTA " +
                                " , SENHA " +
                                " FROM USUARIOS ";




            //Adiciona WHERE 
            if (Filtro.Trim() != "")
            {


                switch (Ordenacao)
                {
                    case 0:
                        Where = $"WHERE CODIGO = {Filtro}";
                        break;
                    case 1:
                        Where = $"WHERE CNPJ_CPF LIKE '%{Filtro.Trim()}%'";
                        break;
                    case 2:
                        Where = $"WHERE RAZAO LIKE '%{Filtro.Trim()}%'";
                        break;
                }


            }

            //Adiciona ORDER BY


            switch (Ordenacao)
            {
                case 0:
                    OrderBy = $"ORDER BY CODIGO";
                    break;
                case 1:
                    OrderBy = $"ORDER BY CNPJ_CPF,RAZAO ";
                    break;
                case 2:
                    OrderBy = $"ORDER BY RAZAO";
                    break;

            }

            strSelect += $" {Where} {OrderBy} ";

            return strSelect;

        }

        public string SqlGridBrowse(int Ordenacao, string Filtro)
        {
            string Where = "";

            string OrderBy = "";

            string strSelect = "SELECT  " +
                                " CODIGO " +
                                " , CNPJ_CPF " +
                                " , RAZAO " +
                                " , CADASTR " +
                                " , ENDERECO " +
                                " , BAIRRO " +
                                " , CIDADE " +
                                " , UF " +
                                " , CEP " +
                                " , TEL1 " +
                                " , TEL2 " +
                                " , EMAIL " +
                                " FROM USUARIOS ";




            //Adiciona WHERE 
            if (Filtro.Trim() != "")
            {


                switch (Ordenacao)
                {
                    case 0:
                        Where = $"WHERE CODIGO = {Filtro}";
                        break;
                    case 1:
                        Where = $"WHERE CNPJ_CPF LIKE '%{Filtro.Trim()}%'";
                        break;
                    case 2:
                        Where = $"WHERE RAZAO LIKE '%{Filtro.Trim()}%'";
                        break;
                }


            }

            //Adiciona ORDER BY


            switch (Ordenacao)
            {
                case 0:
                    OrderBy = $"ORDER BY CODIGO";
                    break;
                case 1:
                    OrderBy = $"ORDER BY CNPJ_CPF,RAZAO ";
                    break;
                case 2:
                    OrderBy = $"ORDER BY RAZAO";
                    break;

            }

            strSelect += $" {Where} {OrderBy} ";

            return strSelect;

        }

        public Usuario Login(String Razao, String Senha)
        {

            Usuario obj = null;


            string strStringConexao = DataBase.RunCommand.connectionString;

            string strSelect = $"SELECT * FROM USUARIOS WHERE RAZAO = '{Razao.Trim()}' AND SENHA = '{Senha.Trim()}' ";

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

                            obj = new Usuario();

                            obj.Codigo = Convert.ToInt32(objDataReader["CODIGO"]);

                            obj.Cnpj_Cpf = objDataReader["CNPJ_CPF"].ToString();
                            obj.Razao    = objDataReader["RAZAO"].ToString();
                            obj.Cadastr  = Convert.ToDateTime(objDataReader["CADASTR"].ToString());
                            obj.Endereco = objDataReader["ENDERECO"].ToString();
                            obj.Bairro   = objDataReader["BAIRRO"].ToString();
                            obj.Cidade   = objDataReader["CIDADE"].ToString();
                            obj.Uf       = objDataReader["UF"].ToString();
                            obj.Cep      = objDataReader["CEP"].ToString();
                            obj.Tel1     = objDataReader["TEL1"].ToString();
                            obj.Tel2  = objDataReader["TEL2"].ToString();
                            obj.Email = objDataReader["EMAIL"].ToString();
                            obj.Pasta = objDataReader["PASTA"].ToString();
                            obj.Senha = objDataReader["SENHA"].ToString();
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
    }
}
