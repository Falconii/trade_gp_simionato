using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trade_GP.Dao.postgre;
using Trade_GP.Extensoes;
using Trade_GP.Models;
using Trade_GP.Util;

namespace Trade_GP
{
    public partial class FormImportacao : Form
    {
        List<ErrosImportacao> ListaErros = new List<ErrosImportacao>();
        List<Arquivos> lsArquivos = new List<Arquivos>();
        Boolean Cancelar = false;
        string LayOut = "MOVIMENTAÇÃO";
        int Page = 200;
        public Visoes visao = Visoes.Browser;
        public ToolStripMenuItem menu { get; internal set; }
        public FormImportacao()
        {
            InitializeComponent();
        }

        private void lbTituloErros_Click(object sender, EventArgs e)
        {

        }

        private void FormImportacao_Activated(object sender, EventArgs e)
        {
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void FormImportacao_FormClosed(object sender, FormClosedEventArgs e)
        {
            menu.Enabled = true;
        }



        private void FormImportacao_Load(object sender, EventArgs e)
        {
            FileInfo[] fileInformation = null;
            List<ErrosImportacao> Erros = new List<ErrosImportacao>();
            Erros.Add(new ErrosImportacao("", "", "", "", "", 0, ""));
            LoadDbGridErros(Erros, true);
            LoadDbGridView(fileInformation);
            BuscandoArquivo();
        }

        private void ConfiguraDbGridView()
        {
            dataGridView1.AutoResizeColumns();
            dataGridView1.Columns[00].HeaderText = "ITEM";
            dataGridView1.Columns[00].Width = 100;
            dataGridView1.Columns[00].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[01].HeaderText = "PASTA";
            dataGridView1.Columns[01].Width = 300;
            dataGridView1.Columns[02].HeaderText = "NOME DO ARQUIVO";
            dataGridView1.Columns[02].Width = 300;
            dataGridView1.Columns[03].HeaderText = "DATA";
            dataGridView1.Columns[03].Width = 150;
            dataGridView1.Columns[03].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[04].HeaderText = "TAMANHO";
            dataGridView1.Columns[04].Width = 150;
            dataGridView1.Columns[04].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[05].HeaderText = "OBSERVAÇÃO";
            dataGridView1.Columns[05].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.BorderStyle = BorderStyle.Fixed3D;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ShowEditingIcon = false;



        }

        private void LoadDbGridView(FileInfo[] fileInformation)
        {
            int contador = 1;
            var list = new List<Arquivos>();
            if (fileInformation == null)
            {
                Arquivos obj = new Arquivos();
                list.Add(obj);
            }
            else
            {
                foreach (FileInfo info in fileInformation)
                {
                    if (info.Extension.ToUpper() != ".TXT" || info.Length == 0)
                    {
                        continue;
                    }
                    Arquivos obj = new Arquivos()
                    {
                        Item = contador++,
                        Pasta = info.DirectoryName,
                        Nome = info.Name,
                        Data = info.LastWriteTime,
                        Tamanho = info.Length.SizeKB(),
                        Obs = ""

                    };
                    list.Add(obj);
                }

                var totais = Soma_EntSai(fileInformation);

                cbCPFO.SelectedIndex = 2;

                if (totais.Saida > 0 && totais.Entrada == 0)
                {
                    cbCPFO.SelectedIndex = 0;
                }

                if (totais.Saida == 0 && totais.Entrada > 0)
                {
                    cbCPFO.SelectedIndex = 1;
                }
            }

            var bindingList = new BindingList<Arquivos>(list);
            var source = new BindingSource(bindingList, null);
            dataGridView1.DataSource = source;
            ConfiguraDbGridView();
        }

        private void LoadDbGridView(List<Arquivos> list)
        {

            var bindingList = new BindingList<Arquivos>(list);

            var source = new BindingSource(bindingList, null);

            dataGridView1.DataSource = source;

            ConfiguraDbGridView();

        }

        private void ConfiguraDbGridErros()
        {
            dtGridErros.AutoResizeColumns();
            dtGridErros.Columns[00].HeaderText = "Flag";
            dtGridErros.Columns[00].Width = 50;
            dtGridErros.Columns[01].HeaderText = "Planilha";
            dtGridErros.Columns[01].Width = 200;
            dtGridErros.Columns[01].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtGridErros.Columns[02].HeaderText = "N° Pagina";
            dtGridErros.Columns[02].Width = 120;
            dtGridErros.Columns[02].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtGridErros.Columns[03].HeaderText = "Campo";
            dtGridErros.Columns[03].Width = 150;
            dtGridErros.Columns[03].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtGridErros.Columns[04].HeaderText = "Conteúdo";
            dtGridErros.Columns[04].Width = 300;
            dtGridErros.Columns[04].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtGridErros.Columns[05].HeaderText = "Tamanho Máximo";
            dtGridErros.Columns[05].Width = 150;
            dtGridErros.Columns[05].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtGridErros.Columns[06].HeaderText = "Observação";
            dtGridErros.Columns[06].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dtGridErros.Columns[06].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;


            dtGridErros.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dtGridErros.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtGridErros.BorderStyle = BorderStyle.Fixed3D;
            dtGridErros.EnableHeadersVisualStyles = false;
            dtGridErros.ShowEditingIcon = false;

        }

        private void LoadDbGridErros(List<ErrosImportacao> Erros, bool Zerar)
        {
            if (Zerar) ListaErros.Clear();


            foreach (ErrosImportacao Erro in Erros)
            {

                ErrosImportacao obj = new ErrosImportacao("E", Erro.Planilha, Erro.Linha, Erro.Campo, Erro.ValorCampo, Erro.TamanhoMax, Erro.Obs);

                ListaErros.Add(obj);
            }
            var bindingList = new BindingList<ErrosImportacao>(ListaErros);
            var source = new BindingSource(bindingList, null);
            dtGridErros.DataSource = source;
            ConfiguraDbGridErros();
        }

        private void ReportProgress(object sender, ProgressReportModel e)
        {
            lbMensagem.Text = e.Mensagem;
            dashboardProgress.Value = (e.PercentageComplete > dashboardProgress.Maximum ? dashboardProgress.Maximum : e.PercentageComplete);
        }

        private void BuscandoArquivo()
        {
            btPesquisar.Enabled = true;
            cbCPFO.Enabled = false;
            cbPage.Enabled = false;
            cbLayOut.Enabled = false;
            BtImportar.Enabled = false;
            btCancelar.Enabled = false;
            ParametrosIniciais();
        }

        private void PreProcessamento()
        {
            btPesquisar.Enabled = true;
            cbCPFO.Enabled = true;
            cbPage.Enabled = true;
            cbLayOut.Enabled = true;
            BtImportar.Enabled = true;
            btCancelar.Enabled = false;
        }

        private void DuranteValidacao()
        {
            btPesquisar.Enabled = false;
            cbCPFO.Enabled = false;
            cbPage.Enabled = false;
            cbLayOut.Enabled = false;
            BtImportar.Enabled = false;
            btCancelar.Enabled = true;
        }

        private void DuranteProcessamento()
        {
            btPesquisar.Enabled = false;
            cbCPFO.Enabled = false;
            cbPage.Enabled = false;
            cbLayOut.Enabled = false;
            BtImportar.Enabled = false;
            btCancelar.Enabled = true;
        }

        private void ParametrosIniciais()
        {
            Cancelar = false;
            cbLayOut.SelectedIndex = 0;
            cbCPFO.SelectedIndex = 0;
            cbPage.SelectedIndex = 1;
            if (tbFolder.Text.Trim() == "")
            {
                tbFolder.Text = UsuarioSistema.Usuario.Pasta.Trim();
            }
        }

        private async void BtImportar_Click(object sender, EventArgs e)
        {
            DuranteProcessamento();

            Boolean ErroPlanilhaOpen = false;

            string Path = $"{tbFolder.Text}\\";

            string FileName = "";

            string FullName = "";

            string PathDestino = "";

            ImportacaoAsync.lsMoviDet.Clear();

            ImportacaoAsync.StaticLsErrosImportacao.Clear();

            LoadDbGridErros(ImportacaoAsync.StaticLsErrosImportacao, true);

            lbProcesso.Text = "Iniciando Processo!";
            pbProcesso.Value = 0;
            pbProcesso.Minimum = 0;
            pbProcesso.Maximum = dataGridView1.Rows.Count - 1;

            dashboardProgress.Value = 0;

            lbMensagem.Text = "Iniciando O Processo!";

            var watch = Stopwatch.StartNew();

            for (int y = 0; y < dataGridView1.Rows.Count; y++)
            {
                pbProcesso.Value = y;

                if (dataGridView1.Rows[y].Cells[2].Value == null)
                {

                    continue;

                }

                FileName = $"{dataGridView1.Rows[y].Cells[2].Value.ToString()}";

                FullName = $"{Path}{FileName}";

                lbProcesso.Text = $"FASE 01 - Processando {FullName} - {y + 1}//{dataGridView1.Rows.Count - 1} ";

                //Verificando Arquivo TXT

                try
                {

                    var stream = File.Open(FullName, FileMode.Open, FileAccess.Read);

                    stream.Close();

                    ErroPlanilhaOpen = false;

                }
                catch (Exception ex)
                {

                    ImportacaoAsync.StaticLsErrosImportacao.Add(new ErrosImportacao("W", FileName, "", "", "", 0, "Planilha Esta Aberta Ou Não Existe!"));

                    ErroPlanilhaOpen = true;
                }

                daoNfeCabTrade dao = new daoNfeCabTrade();

                NfeCabTrade result = dao.SeekByPlanilhaV2(UsuarioSistema.Id_Grupo, FileName);

                string EntradaSaida = getTipoEntradaSaida(FileName);

                //RESUMO 5405
                if (cbCPFO.SelectedIndex == 0)
                {
                    if (EntradaSaida != "S")
                    {
                        ImportacaoAsync.StaticLsErrosImportacao.Add(new ErrosImportacao("W", FileName, "", "", "", 0, "Arquivo Não Compativel Com A Opção, Escolha Apenas Saidas"));
                    }
                    else
                    {
                        if (ErroPlanilhaOpen)
                        {
                            ImportacaoAsync.StaticLsErrosImportacao.Add(new ErrosImportacao("W", FileName, "", "", "", 0, "Planilha Aberta Por Outra Aplicação"));
                        }
                        if (result != null)
                        {
                            ImportacaoAsync.StaticLsErrosImportacao.Add(new ErrosImportacao("W", FileName, "", "", "", 0, "Arquivo Duplicado -CABEÇALHO!"));
                        }
                    }
                }
                else
                {
                    //Resumo_5405 ENTRADAS
                    if (cbCPFO.SelectedIndex == 1)
                    {
                        if (EntradaSaida != "E")
                        {
                            ImportacaoAsync.StaticLsErrosImportacao.Add(new ErrosImportacao("W", FileName, "", "", "", 0, "Arquivo Não Compativel Com A Opção, Escolha Apenas Saidas"));
                        }
                        else
                        {
                            if (ErroPlanilhaOpen)
                            {
                                ImportacaoAsync.StaticLsErrosImportacao.Add(new ErrosImportacao("W", FileName, "", "", "", 0, "Planilha Aberta Por Outra Aplicação"));
                            }
                            if (result != null && getTipoEntradaSaida(FileName) == "E")
                            {
                                ImportacaoAsync.StaticLsErrosImportacao.Add(new ErrosImportacao("W", FileName, "", "", "", 0, "Arquivo Duplicado -CABEÇALHO!"));
                            }
                            if (result != null && getTipoEntradaSaida(FileName) == "S" && result.resumo_5405 == "N")
                            {
                                ImportacaoAsync.StaticLsErrosImportacao.Add(new ErrosImportacao("W", FileName, "", "", "", 0, "ESte Arquivo Não Passou Pelo Resumo!"));
                            }
                        }
                    }
                    else
                    {   //AMBAS SAIDA E ENTRADA
                        if (ErroPlanilhaOpen)
                        {
                            ImportacaoAsync.StaticLsErrosImportacao.Add(new ErrosImportacao("W", FileName, "", "", "", 0, "Planilha Aberta Por Outra Aplicação"));
                        }
                        if (result != null && getTipoEntradaSaida(FileName) == "S" && result.resumo_5405 == "N")
                        {
                            ImportacaoAsync.StaticLsErrosImportacao.Add(new ErrosImportacao("W", FileName, "", "", "", 0, "ESte Arquivo Não Passou Pelo Resumo!"));
                        }
                    }
                }
                if (ImportacaoAsync.StaticLsErrosImportacao.Count == 0)
                {
                    if (result == null)
                    {

                        ImportacaoAsync.Cabecalho.Zerar();

                        ImportacaoAsync.Cabecalho.Arquivo = FileName;

                        if (cbCPFO.SelectedIndex == 0)
                        {
                            ImportacaoAsync.Cabecalho.resumo_5405 = "S";
                        }
                    }
                    else
                    {
                        ImportacaoAsync.Cabecalho = result;
                    }
                    await ProcessaPlanilha(Path, FileName);
                }
                if (ImportacaoAsync.StaticLsErrosImportacao.Count > 0)
                {
                    await Task.Run(async delegate
                    {
                        await Task.Delay(500);
                    });

                    LoadDbGridErros(ImportacaoAsync.StaticLsErrosImportacao, false);
                }

                ImportacaoAsync.lsMoviDet.Clear();

                Boolean TemWarming = false;

                for (int x = 0; x < ImportacaoAsync.StaticLsErrosImportacao.Count; x++)
                {
                    if (ImportacaoAsync.StaticLsErrosImportacao[x].Flag == "W")
                    {
                        ImportacaoAsync.StaticLsErrosImportacao.RemoveAt(x);
                        x--;
                        TemWarming = true;
                    }
                }


                if ((ImportacaoAsync.StaticLsErrosImportacao.Count > 0) || TemWarming)
                {

                    PathDestino = $"{tbFolder.Text}\\RECUSADAS\\";

                    if (ImportacaoAsync.StaticLsErrosImportacao.Count > 0)
                    {
                       
                        try
                        {

                            dao.DeleteAll(ImportacaoAsync.Cabecalho);

                        }
                        catch (System.IO.IOException ex)
                        {

                            MessageBox.Show($"Falha Na Exclusão Da Planilha.{ex.Message}. Processamento Cancelado.", "Atenção!");

                        }
                    }

                }
                else
                {

                    PathDestino = $"{tbFolder.Text}\\IMPORTADAS\\";

                    //Atualiza 

                    ImportacaoAsync.Cabecalho.Status = 1;
                    ImportacaoAsync.Cabecalho.UsuarioInclusao = UsuarioSistema.Usuario.Codigo;
                    ImportacaoAsync.Cabecalho.DataFechamento = DateTime.Now;

                    try
                    {

                        dao.Update(ImportacaoAsync.Cabecalho);

                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show($"Falha Na Gravação Do Cabeçalho ! {Ex.Message}");
                    }

                }


                ImportacaoAsync.StaticLsErrosImportacao.Clear();

                CopiaArquivo(FullName, PathDestino, FileName);


                if (Cancelar)
                {
                    break;
                }
            }

            watch.Stop();

            TimeSpan ts = watch.Elapsed;

            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);

            lbMensagem.Text = $"Tempo Do Processamento: {elapsedTime}" + (Cancelar ? " - Processo Cancelado!" : "");

            dashboardProgress.Value = 0;

            BuscandoArquivo();

            DirectoryInfo di           = new DirectoryInfo(tbFolder.Text);
            FileInfo[] fileInformation = di.GetFiles();
            LoadDbGridView(fileInformation);

        }

        private void DeletarPastas()
        {
            string PastaErro = $"{tbFolder.Text}\\RECUSADAS";
            string PastaOk   = $"{tbFolder.Text}\\IMPORTADAS";

            if (System.IO.Directory.Exists(PastaErro))
            {
                try
                {
                    System.IO.Directory.Delete(PastaErro, true);
                    System.IO.Directory.Delete(PastaOk, true);
                }

                catch (System.IO.IOException e)
                {
                    throw e;
                }
            }
        }

        private async Task ProcessaPlanilha(string Path, string FileName, Boolean FlAtualizar = false)
        {
            Progress<ProgressReportModel> progress = new Progress<ProgressReportModel>();

            progress.ProgressChanged += ReportProgress;

            Page = (cbPage.SelectedItem as string).IntParse();

            if (Page == 0)
            {
                Page = 200;
            }

            await ImportacaoAsync.leArquivoCervejaria(progress, FileName, Path + @"\" + FileName, Page, cbCPFO.SelectedIndex == 0 ? "5405S" : cbCPFO.SelectedIndex == 1 ? "5405E" : "TODAS");

        }

        private async Task ProcessaCliente(string Path, string FileName, Boolean FlAtualizar = false)
        {
            Progress<ProgressReportModel> progress = new Progress<ProgressReportModel>();

            progress.ProgressChanged += ReportProgress;

            Page = (cbPage.SelectedItem as string).IntParse();

            if (Page == 0)
            {
                Page = 200;
            }

            await ImportacaoAsync.leArquivoValidaCliente(progress, FileName, Path + @"\" + FileName, Page, cbCPFO.SelectedIndex == 0 ? "S" : "N");

        }

        private async Task Save_Planilha()
        {
            Progress<ProgressReportModel> progress = new Progress<ProgressReportModel>();
            progress.ProgressChanged += ReportProgress;

            if (ImportacaoAsync.StaticLsErrosImportacao.Count > 0)
            {

                LoadDbGridErros(ImportacaoAsync.StaticLsErrosImportacao, false);

            }
            else
            {

                //await ImportacaoAsync.MultInsertAsyncNFE_DET(progress, Page);

            }

            if (ImportacaoAsync.StaticLsErrosImportacao.Count > 0)
            {

                LoadDbGridErros(ImportacaoAsync.StaticLsErrosImportacao, false);

            }


        }

        private void CopiaArquivo(string Origem, string Path, string Destino)
        {

            try
            {

                System.IO.Directory.CreateDirectory(Path);

                if (System.IO.File.Exists(Path + Destino))
                {

                    try
                    {
                        System.IO.File.Delete(Path + Destino);
                    }
                    catch (System.IO.IOException e)
                    {
                        MessageBox.Show(e.Message, "ERRO");
                    }
                }

                System.IO.File.Move(Origem, Path + Destino);

            }
            catch (System.IO.IOException e)
            {
                MessageBox.Show(e.Message, "ERRO");
            }
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Escolha A Pasta Para A Importação";
                folderBrowserDialog.SelectedPath = tbFolder.Text;
                folderBrowserDialog.ShowNewFolderButton = false;
                DialogResult result = folderBrowserDialog.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    var folderName = folderBrowserDialog.SelectedPath;
                    tbFolder.Text = folderName;
                    DirectoryInfo di = new DirectoryInfo(folderName);
                    FileInfo[] fileInformation = di.GetFiles();
                    if (fileInformation.Length == 0)
                    {
                        MessageBox.Show("Não Existem Arquivos Compativeis Com a Importação!", "Atenção!");
                        BuscandoArquivo();
                    }
                    else
                    {
                        dashboardProgress.Value = 0;
                        dashboardProgress.Minimum = 0;
                        dashboardProgress.Maximum = 100;
                        LoadDbGridView(fileInformation);
                        PreProcessamento();
                    }
                }
                else
                {
                    BuscandoArquivo();
                }
            }

        }

        private void cbLayOut_SelectedIndexChanged(object sender, EventArgs e)
        {
            LayOut = ((ComboBox)(sender)).SelectedItem.ToString();
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            if ((dtGridErros.Rows.Count == 1) && (dtGridErros.Rows[0].Cells[0].Value.ToString().Trim() == ""))
            {
                MessageBox.Show("Nenhum Erro Registrado!", "ERRO");

                return;
            }

            btExcel.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                xcelApp.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < ((dtGridErros.Columns.Count + 1) <= 500 ? dtGridErros.Columns.Count + 1 : 500); i++)
                {
                    xcelApp.Cells[1, i] = dtGridErros.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dtGridErros.Rows.Count; i++)
                {
                    for (int j = 0; j < dtGridErros.Columns.Count; j++)
                    {
                        if (dtGridErros.Rows[i].Cells[j].Value.GetType().Name == "String")
                        {
                            xcelApp.Cells[i + 2, j + 1] = dtGridErros.Rows[i].Cells[j].Value.ToString();
                        }
                        else if (dtGridErros.Rows[i].Cells[j].Value.GetType().Name == "Double")
                        {
                            double valor = dtGridErros.Rows[i].Cells[j].Value.ToString().DoubleParse();

                            xcelApp.Cells[i + 2, j + 1] = valor;
                        }
                        else if (dtGridErros.Rows[i].Cells[j].Value.GetType().Name == "int32")
                        {
                            int valor = dtGridErros.Rows[i].Cells[j].Value.ToString().IntParse();

                            xcelApp.Cells[i + 2, j + 1] = valor;
                        }
                        else
                        {
                            xcelApp.Cells[i + 2, j + 1] = dtGridErros.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                }
                xcelApp.Columns.AutoFit();
                xcelApp.Visible = true;
                btExcel.Enabled = true;
            }
            finally
            {
                btExcel.Enabled = true;
                this.Cursor = Cursors.Arrow;
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            DialogResult resposta = MessageBox.Show("Processamento Será Interrompido Na Próxima Planilha. Concorda ? ", "Atenção!",
              MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (resposta == DialogResult.Yes)
            {

                Cancelar = true;

                List<ErrosImportacao> Erros = new List<ErrosImportacao>();
                Erros.Add(new ErrosImportacao("W", "ATENÇÃO!", "", "", "", 0, "Cancelamento Solcitado!"));
                LoadDbGridErros(Erros, false);

                btCancelar.Enabled = false;

            }
            else
            {
                Cancelar = false;
            }

        }

        private async void btValidarCliente_Click(object sender, EventArgs e)
        {
            DuranteProcessamento();

            Boolean ErroPlanilhaOpen = false;


            string Path = $"{tbFolder.Text}\\";

            string FileName = "";

            string FullName = "";

            string PathDestino = "";

            ImportacaoAsync.lsMoviDet.Clear();
            ImportacaoAsync.StaticLsErrosImportacao.Clear();

            LoadDbGridErros(ImportacaoAsync.StaticLsErrosImportacao, true);

            lbProcesso.Text = "Iniciando Processo!";
            pbProcesso.Value = 0;
            pbProcesso.Minimum = 0;
            pbProcesso.Maximum = dataGridView1.Rows.Count - 1;

            dashboardProgress.Value = 0;
            lbMensagem.Text = "Iniciando O Processo!";

            var watch = Stopwatch.StartNew();

            for (int y = 0; y < dataGridView1.Rows.Count; y++)
            {
                pbProcesso.Value = y;

                if (dataGridView1.Rows[y].Cells[2].Value == null)
                {

                    continue;

                }

                FileName = $"{dataGridView1.Rows[y].Cells[2].Value.ToString()}";

                FullName = $"{Path}{FileName}";

                lbProcesso.Text = $"FASE 01 - Processando {FullName} - {y + 1}//{dataGridView1.Rows.Count - 1} ";

                //Verificando Arquivo TXT

                try
                {

                    var stream = File.Open(FullName, FileMode.Open, FileAccess.Read);

                    stream.Close();

                    ErroPlanilhaOpen = false;

                }
                catch (Exception ex)
                {

                    ImportacaoAsync.StaticLsErrosImportacao.Add(new ErrosImportacao("W", FileName, "", "", "", 0, "Planilha Esta Aberta Ou Não Existe!"));

                    ErroPlanilhaOpen = true;
                }


                await ProcessaCliente(Path, FileName);


                if (ImportacaoAsync.StaticLsErrosImportacao.Count > 0)
                {
                    await Task.Run(async delegate
                    {
                        await Task.Delay(500);
                    });

                    LoadDbGridErros(ImportacaoAsync.StaticLsErrosImportacao, true);
                }

                if (Cancelar)
                {
                    break;
                }
            }

            watch.Stop();

            TimeSpan ts = watch.Elapsed;

            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);

            lbMensagem.Text = $"Tempo Do Processamento: {elapsedTime}" + (Cancelar ? " - Processo Cancelado!" : "");

            dashboardProgress.Value = 0;

            BuscandoArquivo();

            DirectoryInfo di = new DirectoryInfo(tbFolder.Text);
            FileInfo[] fileInformation = di.GetFiles();
            LoadDbGridView(fileInformation);

        }

        private void lbTitulo_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tbFolder_TextChanged(object sender, EventArgs e)
        {

        }

        private string getTipoEntradaSaida(string arquivo)
        {
            string retorno = "";

            if (arquivo.Contains("-E_"))
            {
                retorno = "E";
            }

            if (arquivo.Contains("-S_"))
            {
                retorno = "S";
            }

            return retorno;
        }



        private TotalSaiEnt Soma_EntSai(FileInfo[] fileInformation)
        {
            TotalSaiEnt Retorno = new TotalSaiEnt();

            Retorno.Entrada = 0;
            Retorno.Saida = 0;

            foreach (FileInfo info in fileInformation)
            {
                if (getTipoEntradaSaida(info.Name) == "S")
                {
                    Retorno.Saida++;
                }
                else
                {
                    Retorno.Entrada++;
                }
            }
            return Retorno;
        }

        class Arquivos
        {
            public int Item { get; set; }
            public String Pasta { get; set; }
            public String Nome { get; set; }
            public DateTime Data { get; set; }
            public String Tamanho { get; set; }
            public String Obs { get; set; }

        }

        class TotalSaiEnt
        {
            public int Entrada { get; set; }
            public int Saida { get; set; }
        }
    }
}
