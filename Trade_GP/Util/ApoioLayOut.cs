using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trade_GP.Models;

namespace Trade_GP.Util
{
    public static class ApoioLayOut
    {

        public static List<ErrosImportacao> StaticLsErrosImportacao = new List<ErrosImportacao>();


        public static List<LayOutPosicaoModel> lsLayOutPosicao = new List<LayOutPosicaoModel>();

        public static List<AssinaturaModel> lsAssinatura = new List<AssinaturaModel>();

        public static async Task RunLoadPlanilhaAsync(string FileName, int Linha)
        {
            string FullName = FileName;

            bool isNUm = false;

            DataTableCollection tableCollection;

            lsLayOutPosicao.Clear();

            lsAssinatura.Clear();

            await Task.Run(() =>
            {
                int IndicePlanlha = 0;

                int LinhaAtual = 0;

                using (var stream = File.Open(FullName, FileMode.Open, FileAccess.Read))
                {
                    using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                    {

                        DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                        {

                            ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }

                        }

                        );

                        tableCollection = result.Tables;

                        IndicePlanlha = GetIndicePlanilha(tableCollection);

                        if (IndicePlanlha != -1)
                        {
                            string Planilha = tableCollection[IndicePlanlha].TableName;

                            DataTable dt = tableCollection[Planilha];
                            try
                            {
                                StaticLsErrosImportacao.Clear();

                                for (int x = 0; x < dt.Rows.Count; x++)
                                {

                                    LinhaAtual = (x + 1);

                                    if (x < Linha)
                                    {
                                        continue;
                                    }



                                    try
                                    {

                                        if (StaticLsErrosImportacao.Count > 15)
                                        {
                                            StaticLsErrosImportacao.Add(new ErrosImportacao("E", FileName, (x + 2).ToString(), "", "", 0, "Excedeu O Nro De Erros!"));
                                            break;
                                        }

                                        if (Linha == 0)
                                        {
                                            for (int c = 0; c < dt.Columns.Count; c++)
                                            {
                                                AssinaturaModel assi = new AssinaturaModel();
                                                assi.idx = c;
                                                if (dt.Columns[c].ToString().Trim() == "")
                                                {
                                                    assi.coluna = "VAZIO";
                                                    lsAssinatura.Add(assi);
                                                    continue;
                                                }
                                                if (dt.Columns[c].ToString().Trim() == null)
                                                {
                                                    assi.coluna = "VAZIO";
                                                    lsAssinatura.Add(assi);
                                                    continue;
                                                }
                                                assi.coluna = dt.Columns[c].ToString().Trim();
                                                lsAssinatura.Add(assi);
                                            }
                                        }
                                        else
                                        {
                                            for (int c = 0; c < dt.Rows[x].ItemArray.Length; c++)
                                            {
                                                AssinaturaModel assi = new AssinaturaModel();
                                                assi.idx = c;
                                                if (dt.Rows[x].ItemArray[c].ToString().Trim() == "")
                                                {
                                                    assi.coluna = "VAZIO";
                                                    lsAssinatura.Add(assi);
                                                    continue;
                                                }
                                                if (dt.Rows[x].ItemArray[c] == null)
                                                {
                                                    assi.coluna = "VAZIO";
                                                    lsAssinatura.Add(assi);
                                                    continue;
                                                }
                                                assi.coluna = dt.Rows[x].ItemArray[c].ToString().Trim();
                                                lsAssinatura.Add(assi);
                                            }
                                            x++;
                                        }

                                        //carrega dos dados
                                        Console.WriteLine($" ==> {x}");
                                        for (int c = 0; c < dt.Rows[x].ItemArray.Length; c++)
                                        {
                                            LayOutPosicaoModel coluna = new LayOutPosicaoModel();

                                            coluna.idx = c;
                                            coluna.nome = lsAssinatura[c].coluna;
                                            try
                                            {
                                                double num = Convert.ToDouble(dt.Rows[x].ItemArray[c].ToString().Trim());
                                                isNUm = true;
                                            }
                                            catch (Exception error)
                                            {
                                                isNUm = false;
                                            }

                                            if (isNUm)
                                            {
                                                coluna.tipo = "N";
                                                coluna.tam = 15;
                                                coluna.cd = 2;
                                            }
                                            else
                                            {
                                                coluna.tipo = "C";
                                                coluna.tam = 100;
                                                coluna.cd = 0;
                                            }
                                            coluna.tratativa = 0;
                                            coluna.obrigatorio = true;
                                            coluna.padrao = "";
                                            coluna.usado = "S";
                                            coluna.conteudo = dt.Rows[x].ItemArray[c].ToString().Trim();
                                            lsLayOutPosicao.Add(coluna);

                                        }



                                    }
                                    catch (Exception e)
                                    {
                                        StaticLsErrosImportacao.Add(new ErrosImportacao("E", FullName, "", "", "", 0, e.Message));
                                    }
                                    x = dt.Rows.Count + 1;
                                }
                            }
                            catch (Exception e)
                            {
                                StaticLsErrosImportacao.Add(new ErrosImportacao("E", FullName, LinhaAtual.ToString(), "", "Campo Não Definido", 0, "Favor Analisar A Linha"));
                            }
                        }
                        else
                        {
                            StaticLsErrosImportacao.Add(new ErrosImportacao("E", FullName, "", "", "", 0, "Planilha Com Mais De Uma Aba!"));
                        }
                    }

                }
            });
        }
        private static int GetIndicePlanilha(DataTableCollection tableCollection)
        {
            int retorno = -1;

            if (tableCollection.Count == 1)
            {
                retorno = 0;
            }
            return retorno;
        }

        public static async Task RunLoadPlanilhaToTxT(string path, string fileOut, List<AssinaturaModel> colunas, List<LayOutPosicaoModel> layout)
        {
            string FullName = path + @"/" + fileOut;

            try
            {

                string lineFile = "{\t";

                StaticLsErrosImportacao.Clear();

                StreamWriter sw = new StreamWriter(FullName);

                lineFile += "\t\"layouts\": [{ \n";
                lineFile += "\t\t\"nome\": \"SALDO\", \n";
                lineFile += "\t\t\"assinatura\" : [ \n";
                for (int x = 0; x < colunas.Count; x++)
                {
                    lineFile += "\t\t\t{ \n";
                    lineFile += $"\t\t\t\t\"idx\" : {colunas[x].idx} , \n";
                    lineFile += $"\t\t\t\t\"coluna\" : \"{colunas[x].coluna}\" \n";
                    lineFile += "\t\t\t}" + $"{ultimaVirgula(x, colunas.Count-1)} \n";
                }
                lineFile += "], \n";
                lineFile += "\t\t\"colunas\" : [ \n";
                for (int x = 0; x < layout.Count; x++)
                {
                    lineFile += "\t\t\t{\n";
                    lineFile += $"\t\t\t\t\"idx\" : {layout[x].idx} ,\n";
                    lineFile += $"\t\t\t\t\"nome\" : \"{layout[x].nome}\" ,\n";
                    lineFile += $"\t\t\t\t\"tipo\" : \"{layout[x].tipo}\" ,\n";
                    lineFile += $"\t\t\t\t\"tam\" : {layout[x].tam} ,\n";
                    lineFile += $"\t\t\t\t\"cd\" : {layout[x].cd} ,\n";
                    lineFile += $"\t\t\t\t\"tratativa\" : {layout[x].tratativa} ,\n";
                    lineFile += $"\t\t\t\t\"padrao\" : \"{layout[x].padrao}\" ,\n";
                    lineFile += $"\t\t\t\t\"usado\" : \"{layout[x].usado}\" ,\n";
                    lineFile += $"\t\t\t\t\"conteudo\" : \"{layout[x].conteudo}\" \n";
                    lineFile += "\t\t\t}" + $"{ultimaVirgula(x, layout.Count - 1)}\n";
                }
                lineFile += "\t\t] \n";
                lineFile += "\t} \n";
                lineFile += "]\n";
                lineFile += "} \n";


                sw.WriteLine(lineFile);

                sw.Close();


            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }

        }

        private static string ultimaVirgula(int x, int contador)
        {
            return (x < contador ? "," : "");
        }
    }
}
