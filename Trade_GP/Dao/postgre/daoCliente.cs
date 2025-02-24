using Trade_GP.Extensoes;
using Trade_GP.Models;
using Trade_GP.Util;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Trade_GP.Dao.postgre
{
    public class daoCliente
    {

        public Cliente Insert(Cliente obj)
        {
            
            String StringInsert = $" INSERT INTO CLIENTES "+
                                "(ID_GRUPO,CNPJ_CPF, RAZAO, FANTASI, INSCRI, EMPRESA, COD_EMPRESA,LOCAL,COD_PROTHEUS,COD_SIC,COD_SAP,COD_SOJA,CADASTR, ENDERECOF, BAIRROF, CIDADEF, UFF, CEPF, TELF, CELF, EMAILF, OBS) " +
                                " VALUES(" +
                                $"  '{obj.Id_Grupo}'  " +
                                $", '{obj.Cnpj_Cpf}'  " +
                                $", '{obj.Razao}'  " +
                                $", '{obj.Fantasi}'  " +
                                $", '{obj.Inscri}'  " +
                                $", '{obj.Empresa}'  " +
                                $", '{obj.Cod_Empresa}'  " +
                                $", '{obj.Local}'  " +
                                $", '{obj.Cod_Protheus}'  " +
                                $", '{obj.Cod_Sic}'  " +
                                $", '{obj.Cod_Sap}'  " +
                                $", '{obj.Cod_Soja}'  " +
                                $", '{obj.Cadastr}'  " +
                                $", '{obj.Enderecof}'  " +
                                $", '{obj.Bairrof}'  " +
                                $", '{obj.Cidadef}'  " +
                                $", '{obj.Uff}'  " +
                                $", '{obj.Cepf}'  " +
                                $", '{obj.Telf}'  " +
                                $", '{obj.Celf}'  " +
                                $", '{obj.Emailf}'  " +
                                $", '{obj.Obs}'  " +
                                ")  RETURNING CODIGO ";
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

                                    obj.Codigo = Convert.ToInt32(objDataReader["CODIGO"]);

                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Atenção!");
                            obj  = null;
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

        public void Update(Cliente obj)
        {

            String StringUpdate = $" UPDATE CLIENTES SET " +
                    $"  CODIGO = {obj.Codigo }  " +
                    $", CNPJ_CPF ='{obj.Cnpj_Cpf}'  " +
                    $", RAZAO='{obj.Razao}'  " +
                    $", FANTASI ='{obj.Fantasi}'  " +
                    $", INSCRI ='{obj.Inscri}'  " +
                    $", EMPRESA ='{obj.Empresa}'  " +
                    $", LOCAL ='{obj.Local}'  " +
                    $", COD_EMPRESA ='{obj.Cod_Empresa}'  " +
                    $", COD_PROTHEUS = '{obj.Cod_Protheus}'  " +
                    $", COD_SIC  = '{obj.Cod_Sic}'  " +
                    $", COD_SAP  = '{obj.Cod_Sap}'  " +
                    $", COD_SOJA = '{obj.Cod_Soja}'  " +
                    $", CADASTR = '{obj.Cadastr}'  " +
                    $", ENDERECOF ='{obj.Enderecof}'  " +
                    $", NROF ='{obj.Nrof}'  " +
                    $", BAIRROF ='{obj.Bairrof}'  " +
                    $", CIDADEF ='{obj.Cidadef}'  " +
                    $", UFF ='{obj.Uff}'  " +
                    $", CEPF ='{obj.Cepf}'  " +
                    $", TELF ='{obj.Telf}'  " +
                    $", CELF ='{obj.Celf}'  " +
                    $", EMAILF ='{obj.Emailf}'  " +
                    $", OBS ='{obj.Obs}'  " +
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

        public void Delete(Cliente obj)
        {

            String StringDelete = $" DELETE FROM  CLIENTES  WHERE CODIGO = {obj.Codigo} ";

            DataBase.RunCommand.CreateCommand(StringDelete);

        }

        public Cliente Seek(int codigo)
        {

            Cliente obj = null;

            string strStringConexao = DataBase.RunCommand.connectionString;

            string strSelect = $"SELECT * FROM CLIENTES WHERE CODIGO = {codigo}";

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

                            obj = new Cliente();

                            obj = PopulaCliente(objDataReader);


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

        public Cliente SeekByEmpresaLocal(string cod_empresa, string local)
        {

            Cliente obj = null;

            if (local == "Z020") local = "0020";

            string strStringConexao = DataBase.RunCommand.connectionString;

            string strSelect = $"SELECT * FROM CLIENTES WHERE COD_EMPRESA = '{cod_empresa}' AND LOCAL = '{local}'";

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

                            obj = new Cliente();

                            obj = PopulaCliente(objDataReader);


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

        private Cliente PopulaCliente(NpgsqlDataReader objDataReader)
        {

            var obj = new Cliente();

            obj.Codigo = Convert.ToInt32(objDataReader["CODIGO"]);
            obj.Cnpj_Cpf = objDataReader["CNPJ_CPF"].ToString();
            obj.Razao = objDataReader["RAZAO"].ToString();
            obj.Fantasi = objDataReader["FANTASI"].ToString();
            obj.Inscri = objDataReader["INSCRI"].ToString();
            obj.Empresa = objDataReader["EMPRESA"].ToString();
            obj.Local = objDataReader["LOCAL"].ToString();
            obj.Cod_Empresa = objDataReader["COD_EMPRESA"].ToString();
            obj.Cod_Protheus = objDataReader["COD_PROTHEUS"].ToString();
            obj.Cod_Sic = objDataReader["COD_SIC"].ToString();
            obj.Cod_Sap = objDataReader["COD_SAP"].ToString();
            obj.Cod_Soja = objDataReader["COD_SOJA"].ToString();
            obj.Cadastr = Convert.ToDateTime(objDataReader["CADASTR"]);
            obj.Enderecof = objDataReader["ENDERECOF"].ToString();
            obj.Nrof = objDataReader["NROF"].ToString();
            obj.Bairrof = objDataReader["BAIRROF"].ToString();
            obj.Cidadef = objDataReader["CIDADEF"].ToString();
            obj.Uff = objDataReader["UFF"].ToString();
            obj.Cepf = objDataReader["CEPF"].ToString();
            obj.Telf = objDataReader["TELF"].ToString();
            obj.Celf = objDataReader["CELF"].ToString();
            obj.Emailf = objDataReader["EMAILF"].ToString();
            obj.Obs = objDataReader["OBS"].ToString();

            return obj;
        }

        private Cliente PopulaClienteCombo(NpgsqlDataReader objDataReader)
        {

            var obj = new Cliente();

            obj.Codigo = Convert.ToInt32(objDataReader["CODIGO"]);
            obj.Cnpj_Cpf = objDataReader["CNPJ_CPF"].ToString();
            obj.Razao = objDataReader["RAZAO"].ToString();
            obj.Enderecof = objDataReader["ENDERECOF"].ToString();
            obj.Bairrof = objDataReader["BAIRROF"].ToString();
            obj.Cidadef = objDataReader["CIDADEF"].ToString();
            obj.Uff = objDataReader["UFF"].ToString();
            obj.Cepf = objDataReader["CEPF"].ToString();
            obj.Telf = objDataReader["TELF"].ToString();
            obj.Celf = objDataReader["CELF"].ToString();
            obj.Emailf = objDataReader["EMAILF"].ToString();

            return obj;
        }

        private ClienteByEmpLocal PopulaClienteByEmpLocal(NpgsqlDataReader objDataReader)
        {

            var obj = new ClienteByEmpLocal();

            obj.Id_Grupo = Convert.ToInt32(objDataReader["Id_Grupo"]);

            obj.Empresa = objDataReader["Empresa"].ToString();
            obj.Cod_Empresa = objDataReader["Cod_Empresa"].ToString();
            obj.Local = objDataReader["Local"].ToString();
            obj.Cnpj_Cpf = objDataReader["CNPJ_CPF"].ToString();
            obj.Razao = objDataReader["Razao"].ToString();

            return obj;
        }

        public List<Cliente> getAll(int Ordenacao, string Filtro)
        {

            Cliente obj = null;

            string strStringConexao = DataBase.RunCommand.connectionString;

            List<Cliente> lista = new List<Cliente>();

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

                                obj = new Cliente();

                                obj = PopulaCliente(objDataReader);

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

        public List<Cliente> getAllCombo(int Ordenacao,string Filtro)
        {

            Cliente obj = null;

            string strStringConexao = DataBase.RunCommand.connectionString;

            List<Cliente> lista = new List<Cliente>();
            
            string strSelect = SqlGrid2(Ordenacao, Filtro);

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

                                obj = new Cliente();

                                obj = PopulaClienteCombo(objDataReader);

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
                                 "CODIGO,  " +
                                 "RAZAO , " +
                                 "FANTASI , " +
                                 "CNPJ_CPF , " +
                                 "INSCRI , " +
                                 "CADASTR , " +
                                 "EMPRESA, " +
                                 "LOCAL, " +
                                 "COD_EMPRESA, " +
                                 "COD_PROTHEUS, " +
                                 "COD_SIC, " +
                                 "COD_SAP, " +
                                 "ENDERECOF , " +
                                 "BAIRROF , " +
                                 "CIDADEF , " +
                                 "UFF, " +
                                 "CEPF , " +
                                 "TELF , " +
                                 "CELF , " +
                                 "EMAILF " +
                                 "FROM CLIENTES ";



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

        public string SqlGrid2(int Ordenacao, string Filtro)
        {
            string Where = "";

            string OrderBy = "";

            string strSelect = "SELECT  " +
            " CODIGO		" +
            ",CNPJ_CPF	    " +
            ",RAZAO		    " +
            ",ENDERECOF	    " +
            ",BAIRROF		" +
            ",CIDADEF		" +
            ",UFF			" +
            ",CEPF		    " +
            ",TELF		    " +
            ",CELF		    " +
            ",EMAILF		" +
            "FROM CLIENTES ";

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

        public List<ClienteByEmpLocal> getClienteByEmpLocal(string Cod_Emp)
        {
            ClienteByEmpLocal obj = null;

            string strStringConexao = DataBase.RunCommand.connectionString;

            List<ClienteByEmpLocal> lista = new List<ClienteByEmpLocal>();

            string strSelect = SqlClienteByEmpLocal(Cod_Emp);

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

                                obj = new ClienteByEmpLocal();

                                obj = PopulaClienteByEmpLocal(objDataReader);

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

        private string SqlClienteByEmpLocal(string Cod_Empresa)
        {
            string Where = "";

            string OrderBy = "";

            string strSelect = "SELECT  " +
            "  cli.id_grupo " +
            " , cli.empresa " +
            " ,cli.cod_empresa " +
            " ,cli.local " +
            " ,cli.cnpj_cpf " +
            " ,cli.razao " +
            " FROM     clientes cli " +
            "INNER JOIN cont_cab_proc proc on  proc.id_grupo = cli.id_grupo and proc.cod_emp = cli.cod_empresa and proc.local = cli.local ";
            Where = $"WHERE    cli.cod_empresa = '{Cod_Empresa}'";

            OrderBy = $"ORDER BY " +
            "   cli.id_grupo " +
            " , cli.cod_empresa " +
            " , cli.local ";

            strSelect += $" {Where} {OrderBy} ";

            return strSelect;
        }

    }

}
