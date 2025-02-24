using System; // Importa tipos fundamentais do C#
using Npgsql; // Importa tipos relacionados à comunicação com o banco de dados PostgreSQL
using System.Windows.Forms; // Importa tipos relacionados à criação de interfaces gráficas usando Windows Forms
using Trade_GP.Models; // Importa tipos definidos no namespace Trade_GP.Models
using Trade_GP.Util;
using System.Collections.Generic;

namespace Trade_GP.Dao.postgre
{
    public class daoContCabProc
    {
        /*
        public void InsertFromContDetProc()
        {
            try
            {
                // Obter todos os locais únicos da tabela cont_det_proc
                HashSet<string> uniqueLocals = GetUniqueLocalsFromContDetProc();

                // Inserir cada local único na tabela cont_cab_proc
                foreach (string local in uniqueLocals)
                {
                    // Extrair os detalhes do local
                    string[] parts = local.Split(',');
                    int idGrupo = int.Parse(parts[0]);
                    string codEmp = parts[1];
                    string localName = parts[2];
                    string cnpjCpf = parts[3];

                    // Verificar se o registro já existe na tabela cont_cab_proc
                    ContCabProc existingRecord = Seek( idGrupo, codEmp, localName, cnpjCpf, 0);

                    // Se o registro não existir, insira-o na tabela cont_cab_proc
                    if (existingRecord == null)
                    {
                        // Criar um novo objeto ContCabProc
                        ContCabProc newRecord = new ContCabProc()
                        {
                            Id_Grupo = idGrupo,
                            Cod_Emp = codEmp,
                            Local = localName,
                            Cnpj_cpf = cnpjCpf,
                            Id = GetNextId(), // Defina a lógica para obter o próximo ID
                            Status_Imp = 'I', // Defina o status conforme necessário
                            Status_Dev = 'D', // Defina o status conforme necessário
                            Status_Saldos = 'S', // Defina o status conforme necessário
                            Status_Valor = 'V' // Defina o status conforme necessário
                        };

                        // Insira o novo registro na tabela cont_cab_proc
                        Insert(newRecord);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao inserir registros na tabela cont_cab_proc a partir da tabela cont_det_proc");
            }
        }
        
        public HashSet<string> GetUniqueLocalsFromContDetProc()
        {
            HashSet<string> uniqueLocals = new HashSet<string>();

            try
            {
                // Query SQL para selecionar todos os locais únicos da tabela cont_det_proc
                string query = "SELECT DISTINCT id_grupo, cod_emp, local, cnpj_cpf FROM cont_det_proc";

                using (var conexao = new NpgsqlConnection(DataBase.RunCommand.connectionString))
                {
                    using (var comando = new NpgsqlCommand(query, conexao))
                    {
                        conexao.Open();
                        using (var reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Construa a chave usando os detalhes do local
                                string chave = $"{reader.GetInt32(0)},{reader.GetString(1)},{reader.GetString(2)},{reader.GetString(3)}";
                                uniqueLocals.Add(chave);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter locais únicos da tabela cont_det_proc", ex);
            }

            return uniqueLocals;
        }

        public int GetNextId()
        {
            try
            {
                string query = "SELECT NEXTVAL('public.cont_cab_proc_id_seq')";

                using (var conexao = new NpgsqlConnection(DataBase.RunCommand.connectionString))
                {
                    using (var comando = new NpgsqlCommand(query, conexao))
                    {
                        conexao.Open();
                        return Convert.ToInt32(comando.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter o próximo ID da tabela cont_cab_proc", ex);
            }
        }

        public ContCabProc InsertOrUpdate(ContCabProc obj)
        {
            ContCabProc retorno = null;

            // Verifica se o registro já existe
            var existingRecord = Seek(obj.Id_Grupo, obj.Cod_Emp, obj.Local, obj.Cnpj_cpf, obj.Id);

            if (existingRecord != null)
            {
                // Atualiza o registro existente
                Update(obj);
                retorno = obj;
            }
            else
            {
                // Insere um novo registro
                retorno = Insert(obj);
            }

            return retorno;
        }
        */

        public ContCabProc Insert(ContCabProc obj)
        {
            ContCabProc retorno = null;

            string StringInsert = $"INSERT INTO cont_cab_proc " +
                      "(Id_Grupo, Cod_Emp, Local, Cnpj_cpf, Status_Imp, Status_Dev, Status_Saldos, Status_Valor) " +
                      "VALUES (" +
                      $"{obj.Id_Grupo}, '{obj.Cod_Emp}', '{obj.Local}', '{obj.Cnpj_cpf}', '{obj.Status_Imp}', '{obj.Status_Dev}', '{obj.Status_Saldos}', '{obj.Status_Valor}')" +
                      "RETURNING Id"; // Capture o ID gerado automaticamente



            Console.WriteLine($"Insert Cont_Cab_Proc: {StringInsert}");

            try
            {
                using (var objConexao = new NpgsqlConnection(DataBase.RunCommand.connectionString))
                {
                    using (var objCommand = new NpgsqlCommand(StringInsert, objConexao))
                    {
                        objConexao.Open();
                        obj.Id = (int)objCommand.ExecuteScalar(); // Obtenha o ID gerado automaticamente

                        if (obj.Id > 0)
                        {
                            retorno = obj; // Retornar o objeto inserido com o ID gerado
                        }
                    }
                }
            }
            catch (PostgresException ex) when (ex.SqlState == "23505") // Código de erro para chave duplicada
            {
                Console.WriteLine("Registro duplicado encontrado. Tratando a duplicação...");
                // Aqui você pode escolher atualizar o registro existente ou tomar outra ação necessária
                Update(obj.Id_Grupo, obj.Cod_Emp, obj.Local);
                retorno = obj;
            }
            catch (ExceptionErroImportacao ex)
            {
                MessageBox.Show(ex.Message, "Atenção!");
                retorno = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao inserir registro!");
                retorno = null;
            }

            return retorno;
        }

        public void Update(int idGrupo, string codEmp, string localName)
        {
            try
            {
                // Construir a string de atualização
                string stringUpdate = $"UPDATE cont_cab_proc SET " +
                                      $"Status_Imp = ' ', " +
                                      $"Status_Dev = ' ', " +
                                      $"Status_Saldos = ' ', " +
                                      $"Status_Valor = ' ' " +
                                      $"WHERE Id_Grupo = {idGrupo} AND " +
                                      $"Cod_Emp = '{codEmp}' AND " +
                                      $"Local = '{localName}'";

                // Executar o comando de atualização
                DataBase.RunCommand.CreateCommand(stringUpdate);
                Console.WriteLine($"Registros atualizados para o local: Id_Grupo={idGrupo}, Cod_Emp={codEmp}, Local={localName}");
            }
            catch (ExceptionErroImportacao ex)
            {
                MessageBox.Show(ex.Message, "Atenção!");
            }
        }

        public void Delete(ContCabProc obj)
        {
            string StringDelete = $"DELETE FROM cont_cab_proc WHERE " +
                                  $"Id_Grupo = {obj.Id_Grupo} AND " +
                                  $"Cod_Emp = '{obj.Cod_Emp}' AND " +
                                  $"Local = '{obj.Local}' AND " +
                                  $"Cnpj_cpf = '{obj.Cnpj_cpf}' AND " +
                                  $"Id = {obj.Id}";

            DataBase.RunCommand.CreateCommand(StringDelete);
        }

        public ContCabProc Seek(int idGrupo, int id)
        {
            ContCabProc obj = null;

            string strStringConexao = DataBase.RunCommand.connectionString;

            string strSelect = $"SELECT * FROM cont_cab_proc WHERE " +
                               $"Id_Grupo = {idGrupo} AND " +
                               $"Id = {id}";

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
                            obj = PopulaContCabProc(objDataReader);
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

        public ContCabProc SeekByLocal(int idGrupo, string codEmp, string local)
        {
            ContCabProc obj = null;

            string strStringConexao = DataBase.RunCommand.connectionString;

            string strSelect = $"SELECT * FROM cont_cab_proc WHERE " +
                               $"Id_Grupo = {idGrupo} AND " +
                               $"Cod_Emp = '{codEmp}' AND " +
                               $"Local = '{local}'";

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
                            obj = PopulaContCabProc(objDataReader);
                        }
                    }
                    catch (Exception ex)
                    {
                        obj = null;
                        // Aqui você pode lidar com a exceção se necessário
                    }
                    finally
                    {
                        objConexao.Close();
                    }
                }
            }

            return obj;
        }

        public ContCabProc PopulaContCabProc(NpgsqlDataReader objDataReader)
        {
            var obj = new ContCabProc()
            {
                Id_Grupo = Convert.ToInt32(objDataReader["Id_Grupo"]),
                Cod_Emp = objDataReader["Cod_Emp"].ToString(),
                Local = objDataReader["Local"].ToString(),
                Cnpj_cpf = objDataReader["Cnpj_cpf"].ToString(),
                Id = Convert.ToInt32(objDataReader["Id"]),
                Status_Imp = Convert.ToChar(objDataReader["Status_Imp"]),
                Status_Dev = Convert.ToChar(objDataReader["Status_Dev"]),
                Status_Saldos = Convert.ToChar(objDataReader["Status_Saldos"]),
                Status_Valor = Convert.ToChar(objDataReader["Status_Valor"])
            };

            return obj;
        }

        /*public int GetNextId()
        {
            try
            {
                int nextId = 1;

                using (var conexao = new NpgsqlConnection(DataBase.RunCommand.connectionString))
                {
                    // Abrir a conexão com o banco de dados
                    conexao.Open();

                    // Iniciar uma transação para garantir consistência
                    using (var transaction = conexao.BeginTransaction())
                    {
                        try
                        {
                            // Obter o próximo valor da sequência
                            string query = "SELECT NEXTVAL('public.cont_cab_proc_id_seq')";
                            using (var comando = new NpgsqlCommand(query, conexao, transaction))
                            {
                                nextId = Convert.ToInt32(comando.ExecuteScalar());
                            }

                            // Verificar se o próximo ID já foi utilizado
                            string checkQuery = $"SELECT Id FROM public.cont_cab_proc WHERE Id = {nextId}";
                            using (var checkCommand = new NpgsqlCommand(checkQuery, conexao, transaction))
                            {
                                object result = checkCommand.ExecuteScalar();
                                if (result != null)
                                {
                                    // Se o próximo ID já estiver em uso, encontrar o próximo ID disponível
                                    while (true)
                                    {
                                        nextId++;
                                        string checkNextQuery = $"SELECT Id FROM public.cont_cab_proc WHERE Id = {nextId}";
                                        using (var checkNextCommand = new NpgsqlCommand(checkNextQuery, conexao, transaction))
                                        {
                                            object nextResult = checkNextCommand.ExecuteScalar();
                                            if (nextResult == null)
                                            {
                                                // O próximo ID é válido e não está em uso
                                                break;
                                            }
                                        }
                                    }
                                }
                            }

                            // Commit da transação
                            transaction.Commit();
                        }
                        catch (Exception)
                        {
                            // Rollback da transação em caso de erro
                            transaction.Rollback();
                            throw; // Rejeitar a exceção para sinalizar falha na operação
                        }
                    }
                }

                return nextId;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter o próximo ID da tabela cont_cab_proc", ex);
            }
        }*/
    }
}