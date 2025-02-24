using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trade_GP.Models;

namespace Trade_GP.Dao.postgre
{
    class daoSaldo
    {

        private Saldo PopulaSelic(NpgsqlDataReader objDataReader)
        {

            var obj = new Saldo()
            {
                Id_Grupo = Convert.ToInt32(objDataReader["Id_Grupo"].ToString()),
                Cod_Emp  = objDataReader["Cod_Emp"].ToString(),
                Local    = objDataReader["Local"].ToString(),
                Material = objDataReader["Material"].ToString(),
                Saldo_Inicial = Convert.ToDouble(objDataReader["Saldo_Inicial"]),
                Saldo_Implantado = Convert.ToDouble(objDataReader["Saldo_Inicial"]),
                Status = objDataReader["Status"].ToString(),
            };

            return obj;
        }

        public async Task<int> GetContador(int id_grupo, string cod_emp, string local)
        {

            int Retorno = 0;

            string strStringConexao = DataBase.RunCommand.connectionString;

            string strSelect = $"select coalesce(count(*),0) as total from saldo_inicial where id_grupo = {id_grupo} and cod_emp = '{cod_emp}' and local = '{local}' and fator <> 0 and status = '0' ";

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

        public async Task<int> calculo_saldo_inicial(int id_grupo, string cod_emp, string local)
        {

            int _saida = 0;

            String StringProc = $"select * from calculo_saldo_inicial({id_grupo},'{cod_emp}','{local}',1) ";

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

    }
}
