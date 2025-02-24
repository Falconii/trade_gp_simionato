using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trade_GP.Dao.postgre;
using Trade_GP.Extensoes;
using Trade_GP.Models;

namespace Trade_GP.Util
{
    public static class ImportacaoAsync
    {

        /* mamamamam */

        public static NfeCabTrade Cabecalho = new NfeCabTrade();

        public static List<NfeDetTrade> lsMoviDet = new List<NfeDetTrade>();

        public static List<ErrosImportacao> StaticLsErrosImportacao = new List<ErrosImportacao>();

        public static ContCabProc Cabecalhos = new ContCabProc(); // Objeto para armazenar informações de cabeçalho

        public static List<ContDetProc> lsMoviDets = new List<ContDetProc>(); // Lista para armazenar detalhes de movimentação

        public static DateTime Data_Implantacao_Saldo = DateTime.Parse("28/02/2017");

        public static DateTime Data_DEBUG = DateTime.Parse("18/02/2017");

        //public static string FiltroCFOP = "1000#1100#1101#1102#1111#1116#1117#1118#1120#1121#1122#1150#1151#1152#1201#1202#1203#1204#1208#1209#1401#1403#1408#1409#1410#1411#1949#2000#2100#2101#2102#2111#2113#2116#2117#2118#2120#2121#2122#2150#2151#2152#2153#2154#2200#2201#2202#2203#2204#2208#2209#2401#2403#2408#2409#2410#2411#2949#5100#5101#5102#5103#5104#5105#5106#5109#5110#5111#5112#5113#5114#5115#5116#5117#5118#5119#5120#5122#5123#5124#5125#5150#5151#5152#5200#5201#5202#5208#5209#5400#5401#5402#5403#5405#5408#5409#5410#5411#5949#6000#6100#6101#6102#6103#6104#6105#6106#6107#6108#6109#6110#6111#6112#6113#6114#6115#6116#6117#6118#6119#6120#6122#6123#6124#6125#6150#6151#6152#6155#6156#6200#6201#6202#6208#6209#6400#6401#6402#6403#6404#6408#6409#6410#6411#6949";

        //public static string FiltroCFOP = "1000#1100#1101#1102#1111#1116#1117#1118#1120#1121#1122#1150#1151#1152#1201#1202#1203#1204#1208#1209#1401#1403#1408#1409#1410#1411#1949#2000#2100#2101#2102#2111#2113#2116#2117#2118#2120#2121#2122#2150#2151#2152#2153#2154#2200#2201#2202#2203#2204#2208#2209#2401#2403#2408#2409#2410#2411#2949" +
        //                                  "#5405";


        public static string FiltroCFOPTodas = "1#2#3#5#6#7";

        public static string FiltroCFOP5405 = "5405";

        public static List<Resumo_5405_01> materiais = new List<Resumo_5405_01>();



        /*
        public static List<string> cnpjsFabricas = new List<string> {
                    "08415791000122",
                    "15350602000146",
                    "16622166000180",
                    "73410326000322",
                    "73410326000403",
                    "73410326000918",
                    "73410326012509",
                    "73410326014706"
                };
        */
        public static async Task leArquivoCervejaria(IProgress<ProgressReportModel> progress, string fileName, string fullName, int Page, string filtroCfop)
        {
            ProgressReportModel report = new ProgressReportModel();

            int ContadorLinhas = 0;

            int TamanhoPadrao = 50;

            string line;

            string buffer;

            List<string> fields = new List<string>();

            List<Propriedades> Tamanhos = new List<Propriedades>();

            buffer = "";

            string cod_emp = "";

            string local = "";

            Boolean loadMaterais = false;

            Resumo_5405_01 material = new Resumo_5405_01();

            Boolean existe5405 = false;

            await Task.Run(async () =>
            {
                using (StreamReader file = new StreamReader(fullName))
                {
                    while (((line = file.ReadLine()) != null))
                    {
                        if (StaticLsErrosImportacao.Count > 5)
                        {
                            ImportacaoAsync.StaticLsErrosImportacao.Add(new ErrosImportacao("E", fileName, "", "", "", 0, "Excesso De Erros No Arquivo"));
                            break;
                        }

                        report.Mensagem = $"Lendo E Gravando {ContadorLinhas.ToString("N0")}";

                        report.PercentageComplete = 0;

                        progress.Report(report);

                        if (ContadorLinhas == 0)
                        {
                            ContadorLinhas++;

                            Console.WriteLine(line);

                            continue;

                        }


                        fields.Clear();

                        fields.AddRange(line.Split(';').ToList());


                        if (fields.Count != 51 && fields.Count != 52)
                        {
                            ImportacaoAsync.StaticLsErrosImportacao.Add(new ErrosImportacao("E", fileName, $"{ContadorLinhas}", "", "", fields.Count, $"{line}"));

                            break;

                        }
                        else
                        {
                            try
                            {
                                fields[0] = fields[0].Replace("\"","");

                                fields[1] = Regex.Replace(fields[1], "[A-Za-z]", "0");
                                if (!loadMaterais)
                                {
                                    try
                                    {
                                        daoResumo5405 daoMaterais = new daoResumo5405();
                                        int contador = await daoMaterais.existe5405(1, fields[0]);
                                        if (contador > 0)
                                        {
                                            existe5405 = true;
                                        }
                                        materiais =  daoMaterais.getAll(1, fields[0], fields[1]);
                                        loadMaterais = true;
                                    }
                                    catch (Exception ex)
                                    {
                                        ImportacaoAsync.StaticLsErrosImportacao.Add(new ErrosImportacao(
                                            "E",
                                            fileName,
                                            $"{ContadorLinhas}",
                                            "Materiais",
                                            fields[0],
                                            0,
                                            $"Erro ao carregar materiais: {ex.Message}"
                                        ));
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                ImportacaoAsync.StaticLsErrosImportacao.Add(new ErrosImportacao(
                                    "E",
                                    fileName,
                                    $"{ContadorLinhas}",
                                    "Dt_Lanc",
                                    fields[11],
                                    0,
                                    $"Erro na execução: {ex.Message}"
                                ));
                            }

                            if (filtroCfop == "5405E" && !existe5405)
                            {

                                ImportacaoAsync.StaticLsErrosImportacao.Add(new ErrosImportacao("E", fileName, "", "", "", 0, "Para Resumo Das Entradas Preciso Do Resumo De Materais Saidas!"));

                                break;
                            }

                            if (filtroCfop == "TODAS" && !existe5405)
                            {

                                ImportacaoAsync.StaticLsErrosImportacao.Add(new ErrosImportacao("E", fileName, "", "", "", 0, "Para Importação Total Preciso Do Resumo De Materais!"));

                                break;
                            }

                            if (filtroCfop == "TODAS" && materiais.Count() == 0)
                            {
                                return;
                            }



                            DateTime dt_ref;

                            if (fields[15].Trim() == "")
                            {

                                ContadorLinhas++;

                                continue;

                            }

                            if (fields[12].Trim() == "")
                            {

                                ContadorLinhas++;

                                continue;

                            }
                            if ("123".Contains(fields[12].Substring(0, 1)))
                            {
                                if (!DateTime.TryParseExact(fields[11], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt_ref))
                                {
                                    ContadorLinhas++;

                                    continue;
                                }
                            }
                            else if ("567".Contains(fields[12].Substring(0, 1)))
                            {
                                if (!DateTime.TryParseExact(fields[10], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt_ref))
                                {
                                    ContadorLinhas++;

                                    Console.WriteLine(line);

                                    continue;
                                }
                            }
                            else
                            {

                                ImportacaoAsync.StaticLsErrosImportacao.Add(new ErrosImportacao("E", fileName, ContadorLinhas.ToString(), "CPOP", fields[12], 0, "Excesso De Erros No Arquivo"));

                                ContadorLinhas++;

                                continue;
                            }

                            if (cod_emp != fields[0] || local != fields[1])
                            {
                                //verifica cliente
                                daoCliente daoCli = new daoCliente();

                                cod_emp = fields[0];

                                local = fields[1];

                                Cliente cli = daoCli.SeekByEmpresaLocal(cod_emp, local);

                                if (cli == null)
                                {
                                    ImportacaoAsync.StaticLsErrosImportacao.Add(new ErrosImportacao("E", fileName, $"{ContadorLinhas}", "cod_emp-local", "", 0, $"Cliente {cod_emp} {local} Não Cadastrado!"));
                                    break;
                                }

                                Cabecalho.Layout = fields.Count == 51 ? "S" : "C";

                                if (Cabecalho.Id == 0)
                                 {
                                        daoNfeCabTrade daoCabec = new daoNfeCabTrade();

                                        NfeCabTrade Cabec = daoCabec.Insert(Cabecalho);

                                        if (Cabec == null)
                                        {
                                            ImportacaoAsync.StaticLsErrosImportacao.Add(new ErrosImportacao("E", fileName, $"{ContadorLinhas}", "cod_emp-local", "", 0, $"Cabeçalho {cod_emp} {local} Não Incluido!"));

                                            break;
                                        }

                                        Cabecalho.Id = Cabec.Id;
                                 }
                            }


                            if (!(ItsOK(fields[12], filtroCfop)))
                            {

                                ContadorLinhas++;

                                continue;

                            }


                            if (filtroCfop == "TODAS")
                            {
                                if (fields[15].Trim() == "")
                                {
                                    Console.WriteLine("Em Branco");
                                }

                                var achou = materiais.FirstOrDefault(mat => mat.material.Trim() == fields[15].Trim() && mat.unid == fields[19].Trim());


                                if (achou == null)
                                {
                                    /*
                                    if ("123".Contains(fields[12].Substring(0, 1))) //entrada
                                    {
                                       
                                        material = new Resumo_5405_01();

                                    } else
                                    {

                                        ContadorLinhas++;

                                        continue;
                                    }
                                    */
                                    ContadorLinhas++;

                                    continue;
                                } else
                                {
                                    material = achou;
                                }
                              
                            }

                            NfeDetTrade Det = new NfeDetTrade(); // Lembre-se de inicializá-lo conforme necessário

                            populalsMoviDet(fields, fileName, ContadorLinhas,material);
                            populalsMoviDets(fields, fileName, ContadorLinhas, lsMoviDets);

                            if (filtroCfop == "5405S" || filtroCfop == "5405E")
                            {

                                daoResumo5405 daoresumo = new daoResumo5405();
                                Resumo_5405 resumo = new Resumo_5405()
                                {
                                    id_grupo  = 1,
                                    cod_emp   = lsMoviDet[lsMoviDet.Count - 1].Cod_Emp,
                                    local     = lsMoviDet[lsMoviDet.Count - 1].Local,
                                    material  = lsMoviDet[lsMoviDet.Count - 1].Material,
                                    descricao = lsMoviDet[lsMoviDet.Count - 1].Denom,
                                    unid      = lsMoviDet[lsMoviDet.Count - 1].Unid,
                                    dt_ref    = lsMoviDet[lsMoviDet.Count - 1].Dt_Ref
                                };

                                if (filtroCfop == "5405S")
                                {
                                    //pesquisa com unidade
                                    var comUnid = materiais.FirstOrDefault(mat => mat.material.Trim() == fields[15].Trim() && mat.unid == fields[19].Trim());

                                    if (comUnid == null)
                                    {

                                        daoresumo.UpdateX(resumo);

                                        Resumo_5405_01 tempo = new Resumo_5405_01();

                                        tempo.material  = resumo.material;
                                        tempo.descricao = resumo.descricao;
                                        tempo.unid      = resumo.unid;
                                        tempo.fator     = resumo.fator;
                                        tempo.dt_ref    = resumo.dt_ref;
                                        tempo.validade  = resumo.validade;
                                        materiais.Add(tempo);

                                    }
                                 }
                                else
                                {
                                    //pesquisa com unidade
                                    var comUnid = materiais.FirstOrDefault(mat => mat.material.Trim() == fields[15].Trim() && mat.unid.Trim() == fields[19].Trim());

                                    if (comUnid == null)
                                    {
                                        var semUnid = materiais.FirstOrDefault(mat => mat.material.Trim() == fields[15].Trim());

                                        if (semUnid != null)
                                        {
                                            resumo.origem = "E";

                                            daoresumo.UpdateX(resumo);

                                            Resumo_5405_01 tempo = new Resumo_5405_01();

                                            tempo.material = resumo.material;
                                            tempo.descricao = resumo.descricao;
                                            tempo.unid = resumo.unid;
                                            tempo.fator = resumo.fator;
                                            tempo.dt_ref = resumo.dt_ref;
                                            tempo.validade = resumo.validade;

                                            materiais.Add(tempo);
                                        }
                                       
                                    }

                                }

                                if (lsMoviDets.Count() == Page)
                                {
                                    lsMoviDets.Clear();
                                }
                            }
                            else
                            {

                                if (lsMoviDet.Count() == Page)
                                {
                                    await MultInsertAsyncMOVI_DET();
                                    lsMoviDet.Clear();
                                }

                                if (lsMoviDets.Count() == Page)
                                {
                                    await MultInsertAsyncMOVI_DETs();
                                    lsMoviDets.Clear();
                                }
                            }

                            ContadorLinhas++;

                        }
                        //Grava a sobra do  while

                        if (lsMoviDet.Count() > 0)
                        {
                            if (filtroCfop == "5405S" || filtroCfop == "5405E")
                            {
                             
                                daoResumo5405 daoresumo = new daoResumo5405();
                                Resumo_5405 resumo = new Resumo_5405()
                                {
                                    id_grupo = 1,
                                    cod_emp  = lsMoviDet[lsMoviDet.Count - 1].Cod_Emp,
                                    local    = lsMoviDet[lsMoviDet.Count - 1].Local,
                                    material = lsMoviDet[lsMoviDet.Count - 1].Material,
                                    unid     = lsMoviDet[lsMoviDet.Count - 1].Unid,
                                    dt_ref   = lsMoviDet[lsMoviDet.Count - 1].Dt_Ref
                                };


                                if (filtroCfop == "5405S")
                                {
                                    //pesquisa com unidade
                                    var comUnid2 = materiais.FirstOrDefault(mat => mat.material.Trim() == fields[15].Trim() && mat.unid.Trim() == fields[19].Trim());

                                    if (comUnid2 == null)
                                    {

                                        daoresumo.UpdateX(resumo);

                                        Resumo_5405_01 tempo = new Resumo_5405_01();

                                        tempo.material = resumo.material;
                                        tempo.descricao = resumo.descricao;
                                        tempo.unid = resumo.unid;
                                        tempo.fator = resumo.fator;
                                        tempo.dt_ref = resumo.dt_ref;
                                        tempo.validade = resumo.validade;
                                        materiais.Add(tempo);

                                    }
                                }
                                else
                                {
                                    //pesquisa com unidade
                                    var comUnid2 = materiais.FirstOrDefault(mat => mat.material.Trim() == fields[15].Trim() && mat.unid.Trim() == fields[19].Trim());

                                    if (comUnid2 == null)
                                    {
                                        var semUnid2 = materiais.FirstOrDefault(mat => mat.material.Trim() == fields[15].Trim());

                                        if (semUnid2 != null)
                                        {
                                            resumo.origem = "E";

                                            daoresumo.UpdateX(resumo);

                                            Resumo_5405_01 tempo = new Resumo_5405_01();

                                            tempo.material = resumo.material;
                                            tempo.descricao = resumo.descricao;
                                            tempo.unid = resumo.unid;
                                            tempo.fator = resumo.fator;
                                            tempo.dt_ref = resumo.dt_ref;
                                            tempo.validade = resumo.validade;
                                            materiais.Add(tempo);
                                        }

                                    }

                                }

                                lsMoviDet.Clear();

                            } else
                            {
                                await MultInsertAsyncMOVI_DET();

                                lsMoviDet.Clear();
                            }
                        }

                        if (lsMoviDets.Count() > 0)
                        {
                            if (filtroCfop == "5405S" || filtroCfop == "5405E")
                            {

                                //await MultInsertAsyncMOVI_DETs();

                                lsMoviDets.Clear();

                            } else
                            {
                                await MultInsertAsyncMOVI_DETs();

                                lsMoviDets.Clear();
                            }
                        }

                        Console.WriteLine($"TOTAL DE LINHAS: {ImportacaoAsync.lsMoviDet.Count}");
                        Console.WriteLine($"TOTAL DE LINHAS: {ImportacaoAsync.lsMoviDets.Count}");
                    }

                }
            });
        }

        private static void populalsMoviDet(List<string> fields, string fileName, int ContadorLinhas, Resumo_5405_01 material )
        {

            try
            {
                NfeDetTrade Det = new NfeDetTrade();
                             

                Det.Id_Grupo = Cabecalho.Id_Grupo;
                Det.Id_Planilha = Cabecalho.Id;
                Det.Id_Operacao = "Z";
                Det.Nro_Linha = ContadorLinhas;
                Det.Cod_Emp = fields[00].MaxLength(fileName, ContadorLinhas, "Cod_Emp", 6);
                Det.Local = fields[01].MaxLength(fileName, ContadorLinhas, "Local", 6);
                Det.Id_Parc = fields[02].MaxLength(fileName, ContadorLinhas, "Id_Parc", 15);
                Det.Cnpj_Cpf = fields[03].LimpaCnpjCpf().MaxLength(fileName, ContadorLinhas, "Cnpj_Cpf", 14);
                Det.Nome = "";
                Det.UF = fields[05].MaxLength(fileName, ContadorLinhas, "UF", 02);
                Det.Chave_Acesso = fields[06].MaxLength(fileName, ContadorLinhas, "Chave_Acesso", 44);
                Det.Nro_Doc = fields[07].MaxLength(fileName, ContadorLinhas, "Nro_Doc", 20);
                Det.Nro_Item = fields[08].MaxLength(fileName, ContadorLinhas, "Nro_Item", 15);
                Det.Nro_Posicao = fields[09].MaxLength(fileName, ContadorLinhas, "Nro_Posicao", 10);
                try
                {
                    Det.Dt_Doc = DateTime.ParseExact(fields[10],
                                                              "dd/MM/yyyy",
                                                              CultureInfo.InvariantCulture);
                }
                catch (Exception ex)
                {
                    ImportacaoAsync.StaticLsErrosImportacao.Add(new ErrosImportacao("E", fileName, $"{ContadorLinhas}", "Dt_Lanc", fields[10], 0, $"Converção Inválida!"));
                }
                try
                {
                    Det.Dt_Lanc = DateTime.ParseExact(fields[11],
                                                              "dd/MM/yyyy",
                                                              CultureInfo.InvariantCulture);
                }
                catch (Exception ex)
                {
                    ImportacaoAsync.StaticLsErrosImportacao.Add(new ErrosImportacao("E", fileName, $"{ContadorLinhas}", "Dt_Lanc", fields[11], 0, $"Converção Inválida!"));
                }
                Det.Cfop = fields[12].MaxLength(fileName, ContadorLinhas, "Cfop", 6);
                try
                {
                    if ("123".Contains(Det.Cfop.Substring(0, 1)))
                    {
                        Det.Dt_Ref = Det.Dt_Lanc;
                    }

                    if ("567".Contains(Det.Cfop.Substring(0, 1)))
                    {
                        Det.Dt_Ref = Det.Dt_Doc;
                    }

                }
                catch (Exception ex)
                {
                    ImportacaoAsync.StaticLsErrosImportacao.Add(new ErrosImportacao("E", fileName, $"{ContadorLinhas}", "Dt_Lanc", fields[11], 0, $"Converção Inválida!"));
                }
                Det.Origem = fields[13].MaxLength(fileName, ContadorLinhas, "Origem", 1);
                Det.Sit_Trib = fields[14].MaxLength(fileName, ContadorLinhas, "Sit_Trib", 2);
                if ((fields[15] is null) || (fields[15].ToUpper() == "NULL")) fields[15] = "";
                Det.Material = fields[15].MaxLength(fileName, ContadorLinhas, "Material", 20);
                Det.Tp_Aval = fields[16].MaxLength(fileName, ContadorLinhas, "Tp_Aval", 15);
                Det.Cod_Controle = fields[17].MaxLength(fileName, ContadorLinhas, "Cod_Controle", 15);
                Det.Denom = fields[18].MaxLength(fileName, ContadorLinhas, "Denon", 120).Replace("'", "''");
                Det.Unid = fields[19].MaxLength(fileName, ContadorLinhas, "Unid", 5);
                Det.Quantidade_1 = fields[20].DoubleParseUSAError(fileName, "Quantidade_1", ContadorLinhas);
                Det.Quantidade_2 = fields[21].DoubleParseUSAError(fileName, "Quantidade_2", ContadorLinhas);
                Det.Qtd_Conv = fields[22].DoubleParseUSAError(fileName, "Qtd_Conv", ContadorLinhas); ;
                Det.Preco_Liq = fields[23].DoubleParseUSAError(fileName, "Preco_Liq", ContadorLinhas); ;
                Det.Liquido = fields[24].DoubleParseUSAError(fileName, "Liquido", ContadorLinhas); ;
                Det.Valor = fields[25].DoubleParseUSAError(fileName, "Valor", ContadorLinhas); ;
                Det.Vlr_Contb = fields[26].DoubleParseUSAError(fileName, "Vlr_Contb", ContadorLinhas); ;
                Det.PIS_Base = fields[27].DoubleParseUSAError(fileName, "PIS_Base", ContadorLinhas); ;
                Det.StPis = fields[28].MaxLength(fileName, ContadorLinhas, "StPis", 2);
                Det.Pis_Taxa = fields[29].DoubleParseUSAError(fileName, "Pis_Taxa", ContadorLinhas); ;
                Det.Pis_Vlr = fields[30].DoubleParseUSAError(fileName, "Pis_Vlr", ContadorLinhas); ;
                Det.StCof = fields[31].MaxLength(fileName, ContadorLinhas, "StCof", 2);
                Det.Cof_Base = fields[32].DoubleParseUSAError(fileName, "Cof_Base", ContadorLinhas);
                Det.Cof_Taxa = fields[33].DoubleParseUSAError(fileName, "Cof_Taxa", ContadorLinhas);
                Det.Cof_Vlr = fields[34].DoubleParseUSAError(fileName, "Cof_Vlr", ContadorLinhas);
                Det.Ipi_Base = fields[35].DoubleParseUSAError(fileName, "Ipi_Base", ContadorLinhas);
                Det.Ipi_Taxa = fields[36].DoubleParseUSAError(fileName, "Ipi_Taxa", ContadorLinhas);
                Det.Ipi_Vlr = fields[37].DoubleParseUSAError(fileName, "Ipi_Vlr", ContadorLinhas);
                Det.Icms_Base = fields[38].DoubleParseUSAError(fileName, "Icms_Base", ContadorLinhas);
                Det.Icms_Taxa = fields[39].DoubleParseUSAError(fileName, "Icms_Taxa", ContadorLinhas);
                Det.Icms_Vlr = fields[40].DoubleParseUSAError(fileName, "Icms_Vlr", ContadorLinhas);
                Det.Fecp_Vlr = fields[41].DoubleParseUSAError(fileName, "Fecp_Vlr", ContadorLinhas);
                Det.Icst_Base = fields[42].DoubleParseUSAError(fileName, "Icst_Base", ContadorLinhas);
                Det.Icst_Taxa = fields[43].DoubleParseUSAError(fileName, "Icst_Taxa", ContadorLinhas);
                Det.Icst_Valor = fields[44].DoubleParseUSAError(fileName, "Icst_Valor", ContadorLinhas);
                Det.Fest_Valor = fields[45].DoubleParseUSAError(fileName, "Fest_Valor", ContadorLinhas);
                Det.Bc_Icms_Rt = fields[46].DoubleParseUSAError(fileName, "Bc_Icms_Rt", ContadorLinhas);
                Det.Vlr_Icms_Str = fields[47].DoubleParseUSAError(fileName, "Vlr_Icms_Str", ContadorLinhas);
                Det.Vlr_Fcps_St_Rt = fields[48].DoubleParseUSAError(fileName, "Vlr_Fcps_St_Rt", ContadorLinhas);
                Det.Doc_Origem = fields[49].MaxLength(fileName, ContadorLinhas, "Doc_Origem", 20);
                Det.Item_Ref = fields[50].MaxLength(fileName, ContadorLinhas, "Item_Ref", 15).IntParse().ToString();
                Det.Saldo = fields[20].DoubleParseUSAError(fileName, "Saldo", ContadorLinhas);
                Det.Saldo = Det.Saldo * material.fator;
                Det.Sobra = 0;
                Det.Status = "0";
                Det.Layout = fields.Count == 51 ? "S" : "C";
                Det.Qtd_Dev = 0;
                Det.Id_Saida = 0;
                Det.Nro_Linha_Saida = 0;
                Det.Id_Operacao = getOperacao(Det);
                Det.Qtd_Convertida = (Det.Quantidade_1 * material.fator);
                Det.Fator = material.fator;
                if (Det.Id_Operacao == "E")
                {
                    Console.WriteLine("PARE");
                }
                lsMoviDet.Add(Det);

                Cabecalho.Qtd += Det.Quantidade_1;
                Cabecalho.Vlr_Contabil += Det.Vlr_Contb;
                Cabecalho.Bas_Icms += Det.Icms_Base;
                Cabecalho.Vlr_Icms += Det.Icms_Vlr;
                Cabecalho.Bas_Pis += Det.PIS_Base;
                Cabecalho.Vlr_Pis += Det.Pis_Vlr;
                Cabecalho.Bas_Cof += Det.Cof_Base;
                Cabecalho.Vlr_Cof += Det.Cof_Vlr;
                Cabecalho.Bas_Ipi += Det.Ipi_Base;
                Cabecalho.Vlr_Ipi += Det.Ipi_Vlr;
                Cabecalho.Bas_Icms_st += Det.Icst_Base;
                Cabecalho.Vlr_Icms_st += Det.Icst_Valor;
                Cabecalho.NroLinha = Cabecalho.NroLinha + 1;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        private static void populalsMoviDets(List<string> fields, string fileName, int ContadorLinhas, List<ContDetProc> lsMoviDets)
        {
            try
            {
                ContDetProc Det = new ContDetProc();

                Det.Id_Grupo = Cabecalho.Id_Grupo;
                Det.Id_Cabec = Cabecalhos.Id;
                Det.Cod_Emp = fields[00].MaxLength(fileName, ContadorLinhas, "Cod_Emp", 6);
                Det.Local = fields[01].MaxLength(fileName, ContadorLinhas, "Local", 6);
                Det.Ano = fields[11].Substring(fields[11].Length - 4);
                Det.Mes = fields[11].Substring(fields[11].Length - 7, 2);
                Det.Id_Processo = "1";
                Det.Status = "0";

                lsMoviDets.Add(Det);

                //Cabecalho.NroLinha = Cabecalho.NroLinha + 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static async Task MultInsertAsyncMOVI_DET()
        {

            ProgressReportModel report = new ProgressReportModel();

            int Contador = 0;

            int NroPage = 1;

            String StringInsert = "";

            String Virgula = "";

            String StringInsertCabec = " insert into nfe_det_trade(  " +
                                        "id_grupo,		 " +
                                        "id_planilha,    " +
                                        "id_operacao,    " +
                                        "nro_linha,      " +
                                        "cod_emp,        " +
                                        "local,          " +
                                        "id_parc,        " +
                                        "cnpj_cpf,       " +
                                        "uf,             " +
                                        "chave_acesso,   " +
                                        "nro_doc,        " +
                                        "nro_item,       " +
                                        "nro_posicao,    " +
                                        "dt_doc,         " +
                                        "dt_lanc,        " +
                                        "dt_ref ,         " +
                                        "cfop,           " +
                                        "origem,         " +
                                        "sit_trib,       " +
                                        "material,       " +
                                        "tp_aval,        " +
                                        "cod_controle,   " +
                                        "denom,          " +
                                        "unid,           " +
                                        "quantidade_1,   " +
                                        "quantidade_2,   " +
                                        "qtd_conv,		 " +
                                        "preco_liq,      " +
                                        "liquido,        " +
                                        "valor,          " +
                                        "vlr_contb,      " +
                                        "pis_base,       " +
                                        "stpis,          " +
                                        "pis_taxa,       " +
                                        "pis_vlr,        " +
                                        "stcof,          " +
                                        "cof_base,       " +
                                        "cof_taxa,       " +
                                        "cof_vlr,        " +
                                        "ipi_base,       " +
                                        "ipi_taxa,       " +
                                        "ipi_vlr,        " +
                                        "icms_base,      " +
                                        "icms_taxa,      " +
                                        "icms_vlr,       " +
                                        "fecp_vlr,       " +
                                        "icst_base,      " +
                                        "icst_taxa,      " +
                                        "icst_valor,     " +
                                        "fest_valor,     " +
                                        "bc_icms_rt,     " +
                                        "vlr_icms_str,   " +
                                        "vlr_fcps_st_rt, " +
                                        "doc_origem,     " +
                                        "item_ref,       " +
                                        "saldo,          " +
                                        "sobra,          " +
                                        "status,         " +
                                        "layout,         " +
                                        "qtd_dev,           " +
                                        "Id_Saida,          " +
                                        "Nro_Linha_Saida,    " +
                                        "Saldo_Inicial  ,    " +
                                        "qtd_convertida   ,   " +
                                        "fator      " +
                                        "   ) " +
                                        " VALUES ";

            await Task.Run(
                () =>
                {

                    foreach (NfeDetTrade obj in ImportacaoAsync.lsMoviDet)
                    {

                        if (Contador == 0)
                        {
                            StringInsert = StringInsertCabec;

                            Virgula = "";

                        }

                        try
                        {
                            StringInsert += Virgula + "(" +
                                                        $"  {Cabecalho.Id_Grupo} ," +
                                                            $"  {Cabecalho.Id} ," +
                                                            $" '{obj.Id_Operacao}'," +
                                                            $"  {obj.Nro_Linha}," +
                                                            $" '{obj.Cod_Emp}'," +
                                                            $" '{obj.Local}'," +
                                                            $" '{obj.Id_Parc}'," +
                                                            $" '{obj.Cnpj_Cpf}'," +
                                                            $" '{obj.UF}'," +
                                                            $" '{obj.Chave_Acesso}'," +
                                                            $" '{obj.Nro_Doc}'," +
                                                            $" '{obj.Nro_Item}'," +
                                                            $" '{obj.Nro_Posicao}'," +
                                                            $" '{obj.Dt_Doc.ToString("yyyy-MM-dd")}'," +
                                                            $" '{obj.Dt_Lanc.ToString("yyyy-MM-dd")}'," +
                                                            $" '{obj.Dt_Ref.ToString("yyyy-MM-dd")}'," +
                                                            $" '{obj.Cfop}'," +
                                                            $" '{obj.Origem}'," +
                                                            $" '{obj.Sit_Trib}'," +
                                                            $" '{obj.Material}'," +
                                                            $" '{obj.Tp_Aval}'," +
                                                            $" '{obj.Cod_Controle}'," +
                                                            $" '{obj.Denom}'," +
                                                            $" '{obj.Unid}'," +
                                                            $" {obj.Quantidade_1.DoubleParseDb()}," +
                                                            $" {obj.Quantidade_2.DoubleParseDb()}," +
                                                            $" {obj.Qtd_Conv.DoubleParseDb()}," +
                                                            $" {obj.Preco_Liq.DoubleParseDb()}," +
                                                            $" {obj.Liquido.DoubleParseDb()}," +
                                                            $" {obj.Valor.DoubleParseDb()}," +
                                                            $" {obj.Vlr_Contb.DoubleParseDb()}," +
                                                            $" {obj.PIS_Base.DoubleParseDb()}," +
                                                            $" '{obj.StPis}'," +
                                                            $" {obj.Pis_Taxa.DoubleParseDb()}," +
                                                            $" {obj.Pis_Vlr.DoubleParseDb()}," +
                                                            $" '{obj.StCof}'," +
                                                            $" {obj.Cof_Base.DoubleParseDb()}," +
                                                            $" {obj.Cof_Taxa.DoubleParseDb()}," +
                                                            $" {obj.Cof_Vlr.DoubleParseDb()}," +
                                                            $" {obj.Ipi_Base.DoubleParseDb()}," +
                                                            $" {obj.Ipi_Taxa.DoubleParseDb()}," +
                                                            $" {obj.Ipi_Vlr.DoubleParseDb()}," +
                                                            $" {obj.Icms_Base.DoubleParseDb()}," +
                                                            $" {obj.Icms_Taxa.DoubleParseDb()}," +
                                                            $" {obj.Icms_Vlr.DoubleParseDb()}," +
                                                            $" {obj.Fecp_Vlr.DoubleParseDb()}," +
                                                            $" {obj.Icst_Base.DoubleParseDb()}," +
                                                            $" {obj.Icst_Taxa.DoubleParseDb()}," +
                                                            $" {obj.Icst_Valor.DoubleParseDb()}," +
                                                            $" {obj.Fest_Valor.DoubleParseDb()}," +
                                                            $" {obj.Bc_Icms_Rt.DoubleParseDb()}," +
                                                            $" {obj.Vlr_Icms_Str.DoubleParseDb()}," +
                                                            $" {obj.Vlr_Fcps_St_Rt.DoubleParseDb()}," +
                                                            $" '{obj.Doc_Origem}'," +
                                                            $" '{obj.Item_Ref}'," +
                                                            $"  {obj.Saldo.DoubleParseDb()}," +
                                                            $"  {obj.Sobra.DoubleParseDb()}," +
                                                            $" '{obj.Status}', " +
                                                            $" '{obj.Layout}'," +
                                                            $"  {obj.Qtd_Dev.DoubleParseDb()}, " +
                                                            $"  {obj.Id_Saida}, " +
                                                            $"  {obj.Nro_Linha_Saida} , " +
                                                            $"  {obj.Saldo_Inicial.DoubleParseDb()} , " +
                                                            $"  {obj.Qtd_Convertida.DoubleParseDb()} , " +
                                                            $"  {obj.Fator.DoubleParseDb()}  " +
                                                            " ) ";


                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message, "Atenção!");
                        }

                        Virgula = " , ";

                        Contador++;

                    }

                    if (Contador > 0)
                    {
                        try
                        {

                            NroPage++;

                            DataBase.RunCommand.CreateCommand(StringInsert);


                        }
                        catch (ExceptionErroImportacao e)
                        {
                            e.Erros.Planilha = Cabecalho + "\\" + Cabecalho.Arquivo;


                            ImportacaoAsync.StaticLsErrosImportacao.Add(e.Erros);
                        }

                    }
                }
        );

        }

        public static async Task MultInsertAsyncMOVI_DETs()
        {
            ProgressReportModel report = new ProgressReportModel();

            try
            {
                Console.WriteLine("Iniciando a operação MultInsertAsyncMOVI_DETs.");

                var daoCabProc = new daoContCabProc();
                var daoDetProc = new daoContDetProc();

                // 1. Inserir registros na tabela cont_cab_proc e manter um dicionário de locais para IDs
                Dictionary<string, int> locaisParaIds = new Dictionary<string, int>();

                foreach (var obj in lsMoviDets)
                {
                    obj.Local = Regex.Replace(obj.Local, "[A-Za-z]", "0");
                    string chave = $"{obj.Id_Grupo},{obj.Cod_Emp},{obj.Local}";

                    if (!locaisParaIds.ContainsKey(chave))
                    {
                        // Extrair os detalhes do local
                        string[] parts = chave.Split(',');
                        if (parts.Length < 3)
                        {
                            Console.WriteLine("Formato da chave é inválido. Esperado: 'Id_Grupo,Cod_Emp,Local'.");
                            MessageBox.Show("Formato da chave é inválido. Esperado: 'Id_Grupo,Cod_Emp,Local'.", "Erro");
                            continue;
                        }

                        int idGrupo;
                        if (!int.TryParse(parts[0], out idGrupo))
                        {
                            Console.WriteLine($"Id_Grupo inválido: {parts[0]}");
                            MessageBox.Show($"Id_Grupo inválido: {parts[0]}", "Erro");
                            continue;
                        }

                        string codEmp = parts[1];
                        string localName = parts[2];

                        Console.WriteLine($"Verificando se o registro já existe na tabela cont_cab_proc: Id_Grupo={idGrupo}, Cod_Emp={codEmp}, Local={localName}");
                        // Verificar se o registro já existe na tabela cont_cab_proc
                        ContCabProc existingRecord = daoCabProc.SeekByLocal(idGrupo, codEmp, localName);

                        int idCabec;
                        // Se o registro não existir, insira-o na tabela cont_cab_proc
                        if (existingRecord == null)
                        {
                            Console.WriteLine($"Registro não encontrado. Inserindo novo registro na tabela cont_cab_proc: Id_Grupo={idGrupo}, Cod_Emp={codEmp}, Local={localName}");

                            // Criar um novo objeto ContCabProc
                            ContCabProc newRecord = new ContCabProc()
                            {
                                Id_Grupo = idGrupo,
                                Cod_Emp = codEmp,
                                Local = localName,
                                Status_Imp = ' ',
                                Status_Dev = ' ',
                                Status_Saldos = ' ',
                                Status_Valor = ' '
                            };

                            // Insira o novo registro na tabela cont_cab_proc e obtenha o ID gerado
                            ContCabProc insertedRecord = daoCabProc.Insert(newRecord);
                            idCabec = insertedRecord.Id;
                            Console.WriteLine($"Novo registro inserido na tabela cont_cab_proc: {insertedRecord.Id}");
                        }
                        else
                        {
                            idCabec = existingRecord.Id;
                            Console.WriteLine($"Registro já existe na tabela cont_cab_proc: Id_Grupo={idGrupo}, Cod_Emp={codEmp}, Local={localName}");
                        }

                        locaisParaIds[chave] = idCabec; // Mapear chave para ID_Cabec
                    }
                }

                // 2. Inserir registros na tabela cont_det_proc
                foreach (var obj in lsMoviDets)
                {
                    string chave = $"{obj.Id_Grupo},{obj.Cod_Emp},{obj.Local}";

                    if (locaisParaIds.ContainsKey(chave))
                    {
                        obj.Id_Cabec = locaisParaIds[chave];

                        string chaveMesAno = $"{obj.Mes}-{obj.Ano}-{obj.Local}";

                        // Verifica se o registro já existe na tabela cont_det_proc
                        if (daoDetProc.Seek(obj.Id_Grupo, obj.Cod_Emp, obj.Local, obj.Id_Cabec.ToString(), obj.Ano, obj.Mes, obj.Id_Processo) == null)
                        {
                            // Insere o novo registro na tabela cont_det_proc
                            daoDetProc.Insert(new ContDetProc
                            {
                                Id_Grupo = obj.Id_Grupo,
                                Cod_Emp = obj.Cod_Emp,
                                Local = obj.Local,
                                Id_Cabec = obj.Id_Cabec,
                                Ano = obj.Ano,
                                Mes = obj.Mes,
                                Id_Processo = obj.Id_Processo,
                                Status = obj.Status
                            });

                            Console.WriteLine($"Inserido na tabela cont_det_proc: {chaveMesAno}");
                        }
                    }
                }

                Console.WriteLine("Operação MultInsertAsyncMOVI_DETs concluída.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro na operação MultInsertAsyncMOVI_DETs: {e.Message}\n{e.StackTrace}");
                MessageBox.Show(e.Message, "Atenção!");
            }
        }

        private class Propriedades
        {
            public int Qtd { get; set; }
            public int Tamanho { get; set; }
            public string Exemplo { get; set; }
        }

        public static async Task leArquivoValidaCliente(IProgress<ProgressReportModel> progress, string fileName, string fullName, int Page, string filtroCfop)
        {
            ProgressReportModel report = new ProgressReportModel();

            int ContadorLinhas = 0;

            int TamanhoPadrao = 50;

            string line;

            string buffer;

            List<string> fields = new List<string>();

            List<Propriedades> Tamanhos = new List<Propriedades>();

            buffer = "";

            string cod_emp = "";

            string local = "";

            await Task.Run(async () =>
            {
                using (StreamReader file = new StreamReader(fullName))
                {
                    while (((line = file.ReadLine()) != null))
                    {
                        if (StaticLsErrosImportacao.Count > 20000)
                        {
                            ImportacaoAsync.StaticLsErrosImportacao.Add(new ErrosImportacao("E", fileName, "", "", "", 0, "Excesso De Erros No Arquivo"));
                            break;
                        }

                        report.Mensagem = $"Lendo E Gravando {ContadorLinhas.ToString("N0")}";

                        report.PercentageComplete = 0;

                        progress.Report(report);

                        if (ContadorLinhas == 0)
                        {
                            ContadorLinhas++;

                            Console.WriteLine(line);

                            continue;

                        }


                        fields.Clear();

                        fields.AddRange(line.Split(';').ToList());


                        if (fields.Count != 51 && fields.Count != 52)
                        {
                            ImportacaoAsync.StaticLsErrosImportacao.Add(new ErrosImportacao("E", fileName, $"{ContadorLinhas}", "", "", fields.Count, $"{line}"));

                            break;

                        }
                        else
                        {

                            fields[1] = Regex.Replace(fields[1], "[A-Za-z]", "0");

                            if (cod_emp != fields[0] || local != fields[1])
                            {
                                //verifica cliente
                                daoCliente daoCli = new daoCliente();

                                cod_emp = fields[0];

                                local = fields[1];

                                local = Regex.Replace(local, "[A-Za-z]", "0");

                                Cliente cli = daoCli.SeekByEmpresaLocal(cod_emp, local);

                                if (cli == null)
                                {
                                    ImportacaoAsync.StaticLsErrosImportacao.Add(new ErrosImportacao("E", fileName, $"{ContadorLinhas}", "cod_emp-local", "", 0, $"Cliente {cod_emp} {local} Não Cadastrado!"));
                                }

                            }

                        }

                        ContadorLinhas++;

                    }


                }
            });
        }

        private static bool ItsOK(string cfop, string filtroCfop)
        {
            bool retorno = false;

            if (cfop.Trim().Length < 6)
            {
                return retorno;
            }

            if (filtroCfop == "TODAS")
            {
                /*
                if (cfop.Substring(0, 4) == "5405")
                {

                    retorno = false;

                }
                else
                {
                    retorno = (FiltroCFOPTodas.Contains(cfop.Substring(0, 1)));
                }
                */

                retorno = (FiltroCFOPTodas.Contains(cfop.Substring(0, 1)));
            }

            if (filtroCfop == "5405S")
            {
                retorno = (cfop.Substring(0, 4) == "5405");
            }

            if (filtroCfop == "5405E")
            {
                retorno = "123".Contains(cfop.Substring(0, 1));
            }

            return retorno;
        }

        private static string getOperacao(NfeDetTrade det)
        {
            string retorno = "";

            if ("123".Contains(det.Cfop.Substring(0, 1)))
            {

                retorno = "";

                if (!((det.Doc_Origem.Trim() == "0") || (det.Doc_Origem.Trim() == "")))
                {
                    if (((det.Icst_Valor + det.Fest_Valor) == 0) && (det.Sit_Trib == "6"))
                    {
                        retorno = "Z";

                    } else
                    {
                        retorno = "Y";
                    }
                }
                else
                {
                    if ((det.Icst_Valor + det.Fest_Valor) > 0)
                    {
                        retorno = "E";
                    }
                }

               
            }


            if ("567".Contains(det.Cfop.Substring(0, 1)))
            {
                if (det.Cfop.Substring(0, 4) == "5405")
                {
                    if ((det.PIS_Base + det.Cof_Base) > 0)
                    {
                        retorno = "S";
                    }
                    else
                    {
                        retorno = "s";
                    }
                }

            }

            return retorno;
        }
    }
}
