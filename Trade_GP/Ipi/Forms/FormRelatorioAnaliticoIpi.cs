using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trade_GP.Util;

namespace Trade_GP.Ipi.Forms
{
    public partial class FormRelatorioAnaliticoIpi : Form
    {
        private List<ParamLocal> Parametros = new List<ParamLocal>();

        private List<GridLocais> lsLocais = new List<GridLocais>();

        private List<tarefa> lsTarefas = new List<tarefa>();

        private Boolean btProximoFlag = false;

        private string Cod_Emp = "";

        private string Local = "";

        private Boolean Cancelar = false;

        public ToolStripMenuItem menu { get; internal set; }
        public FormRelatorioAnaliticoIpi()
        {
            InitializeComponent();
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void FormRelatorioAnalitico_Activated(object sender, EventArgs e)
        {
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void FormRelatorioAnalitico_FormClosed(object sender, FormClosedEventArgs e)
        {
            menu.Enabled = true;
        }

        private void FormRelatorioAnalitico_Load(object sender, EventArgs e)
        {
            btProximoFlag = false;

            recomeco();

            status_inical();
        }

        private class tarefa
        {
            public int Sequencia { get; set; }
            public string Cod_Emp { get; set; }
            public string Local { get; set; }
            public string Ano { get; set; }
            public string Mes { get; set; }
            public string arquivo { get; set; }
            public DateTime? Inicial { get; set; }
            public DateTime? Final { get; set; }
            public string Observacao { get; set; }
            public string Status { get; set; }
        }

        private void btParametros_Click(object sender, EventArgs e)
        {
            status_inical();

            var parametros = new FormParametrosIpi();

            var Result = parametros.ShowDialog();

            if (Result == DialogResult.OK)
            {

                Parametros = parametros.Parametros;

                btProximoFlag = true;


                LoadDbGridLocais();


                PosicaoInicial();
            }
            else
            {

                btProximoFlag = false;

                PosicaoInicial();
            }

            parametros.Dispose();

        }


        private void recomeco()
        {
            Parametros = new List<ParamLocal>();

            lsLocais = new List<GridLocais>();

            lsTarefas = new List<tarefa>();

            btProximoFlag = false;

            Cod_Emp = "";

            Local = "";

            Cancelar = false;

        }
        private void status_inical()
        {
            gbMensaProcessamento.Visible = false;
            dtGridLog.Visible = false;
            dbLocais.Visible = false;
            btProcessar.Enabled = true;
            lblCancelamentoAtivado.Visible = false;
            btProcessar.Tag = 0;
            btProximo.Enabled = btProximoFlag;
            btNovo.Visible = false;
            dtGridLog.ReadOnly = true;
            dbLocais.ReadOnly = true;
            btProcessar.Visible = true;
            cbLocal.SelectedIndex = 0;
            cbMes.SelectedIndex = 1;
            cbAno.SelectedIndex = 1;
        }
        private void status_contagem()
        {
            gbMensaProcessamento.Visible = false;
            dtGridLog.Visible = false;
            dbLocais.Visible = false;
            btProcessar.Enabled = false;
            btProcessar.Text = "Processamento";
            btProcessar.Tag = 0;
            lblCancelamentoAtivado.Visible = false;
        }
        private void status_pre_processamento()
        {
            gbMensaProcessamento.Visible = true;
            dtGridLog.Visible = false;
            dbLocais.Visible = true;
            btProcessar.Enabled = true;
            btProcessar.Text = "Processamento";
            btProcessar.Tag = 0;
            lblCancelamentoAtivado.Visible = false;
            btNovo.Visible = false;
        }
        private void status_erro_validacao()
        {
            gbMensaProcessamento.Visible = false;
            dtGridLog.Visible = false;
            dbLocais.Visible = true;
            btProcessar.Enabled = false;
            btProcessar.Text = "Processamento";
            btProcessar.Tag = 0;
            lblCancelamentoAtivado.Visible = false;
            btNovo.Visible = false;
        }
        private void status_processando()
        {
            gbMensaProcessamento.Visible = true;
            dtGridLog.Visible = true;
            dbLocais.Visible = true;
            btProcessar.Text = "Cancelar Processamento";
            btProcessar.Tag = 1;
            lblCancelamentoAtivado.Visible = false;
            Cancelar = false;
            btNovo.Visible = false;
        }
        private void status_aguardando_cancelar()
        {
            gbMensaProcessamento.Visible = true;
            dtGridLog.Visible = true;
            dbLocais.Visible = true;
            btProcessar.Text = "Voltar Ao Processamento";
            btProcessar.Tag = 2;
            lblCancelamentoAtivado.Visible = true;
            btNovo.Visible = false;
        }
        private void status_processado()
        {
            btProcessar.Text = "Processamento Encerrado!";
            btProcessar.Enabled = false;
            btProximoFlag = false;
            btProximo.Enabled = true;
            btProcessar.Tag = 0;
            btNovo.Visible = false;
            Parametros.Clear();
            Cancelar = false;
            status_inical();
        }
        private void status_terminado()
        {
            btNovo.Visible = true;
            btProcessar.Visible = false;
        }
        private void PosicaoInicial()
        {
            btProximo.Enabled = btProximoFlag;
        }

        private void btProximo_Click(object sender, EventArgs e)
        {
            btProximoFlag = false;

            status_pre_processamento();
        }

        private void LoadDbGridLocais()
        {

            lsLocais.Clear();

            foreach (var param in Parametros)
            {
                GridLocais grid = new GridLocais();

                grid.Cod_Emp = param.Cod_Emp;
                grid.Local = param.Local;
                grid.Razao = param.Razao;
                grid.Obs = "";

                lsLocais.Add(grid);

            }

            var bindingList = new BindingList<GridLocais>(lsLocais);

            var source = new BindingSource(bindingList, null);

            dbLocais.DataSource = source;

            ConfiguraDbLocais();

        }
        private void ConfiguraDbLocais()
        {
            dbLocais.AutoResizeColumns();
            dbLocais.Columns[00].HeaderText = "Empresa";
            dbLocais.Columns[00].Width = 60;
            dbLocais.Columns[00].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbLocais.Columns[01].HeaderText = "Local";
            dbLocais.Columns[01].Width = 50;
            dbLocais.Columns[01].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbLocais.Columns[02].HeaderText = "Razao";
            dbLocais.Columns[02].Width = 300;
            dbLocais.Columns[02].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dbLocais.Columns[03].HeaderText = "Observacao";
            dbLocais.Columns[03].Width = 300;

            dbLocais.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dbLocais.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbLocais.BorderStyle = BorderStyle.Fixed3D;
            dbLocais.EnableHeadersVisualStyles = false;
            dbLocais.ShowEditingIcon = false;

        }
        private void btPesquisar_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Escolha A Pasta Gravar Os Relatórios";
                folderBrowserDialog.SelectedPath = tbFolder.Text;
                folderBrowserDialog.ShowNewFolderButton = false;
                DialogResult result = folderBrowserDialog.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    var folderName = folderBrowserDialog.SelectedPath;
                    tbFolder.Text = folderName;
                }
            }
        }
        private async void btProcessar_Click(object sender, EventArgs e)
        {
            if ((int)btProcessar.Tag == 0) // Processamento
            {

                if (!Directory.Exists(tbFolder.Text))
                {
                    MessageBox.Show("Pasta Para Gravação Dos Relários Inválida!");

                    return;
                }

                Cancelar = false;

                status_processando();

                int resultado = -1;

                DateTime tempoInicial = DateTime.Now;

                int resultado_total = 0;

                NewTarefas();

                foreach (var (tar, index) in lsTarefas.Select((tar, index) => (tar, index)))
                {
                    tar.Inicial = DateTime.Now;

                    await Task.Run(async delegate
                    {
                        await Task.Delay(3000);
                    });

                    tar.Final = DateTime.Now;

                    TimeSpan tempoDia = (TimeSpan)(tar.Final - tar.Inicial);

                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}", tempoDia.Hours, tempoDia.Minutes, tempoDia.Seconds);

                    tar.Status = $"Tempo Gasto {elapsedTime}";

                    tar.Observacao = $"Processamento Encerrado!";

                    if (Cancelar)
                    {
                        tar.Observacao = "Cancelamento Solicitado !";
                    }

                    dtGridLog.InvalidateRow(index);

                    if (Cancelar) break;

                }

                status_terminado();

                DateTime tempoFinal = DateTime.Now;

                TimeSpan tempo = (TimeSpan)(tempoFinal - tempoInicial);

                string tempoDecorrido = String.Format("{0:00}:{1:00}:{2:00}", tempo.Hours, tempo.Minutes, tempo.Seconds);

                MessageBox.Show($"Tempo Decorrido Total : {tempoDecorrido}");

                return;
            }
            if ((int)btProcessar.Tag == 1) // Cancelamento
            {
                DialogResult resposta = MessageBox.Show("Impressão Dos Relatorios Será Interrompida. Concorda ? ", "Atenção!",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resposta == DialogResult.Yes)
                {

                    Cancelar = true;

                    status_aguardando_cancelar();
                }
                else
                {

                    Cancelar = false;

                    status_processando();

                }

                return;
            }
            if ((int)btProcessar.Tag == 2) // Voltar Ao Processamento
            {
                Cancelar = false;

                status_processando();

            }
        }

        private void NewTarefas()
        {
            lsTarefas.Clear();

            string Ano = "";

            string Mes = "";

            int Indice = 1;

            if (cbLocal.SelectedIndex == 1)
            {
                tarefa obj = new tarefa()
                {
                    Sequencia = Indice++,
                    Cod_Emp = Parametros[0].Cod_Emp,
                    Local = "",
                    Ano = "",
                    Mes = "",
                    arquivo = $"{ Parametros[0].Cod_Emp}.cvs",
                    Inicial = null,
                    Final = null,
                    Observacao = "",
                    Status = "Aguardando"
                };
                lsTarefas.Add(obj);
            }
            else
            {
                foreach (var (parametro, index) in Parametros.Select((param, index) => (param, index)))
                {
                    if (cbLocal.SelectedIndex == 0 && cbAno.SelectedIndex == 1)
                    {
                        tarefa obj = new tarefa()
                        {
                            Sequencia = Indice++,
                            Cod_Emp = parametro.Cod_Emp,
                            Local = parametro.Local,
                            Ano = "",
                            Mes = "",
                            arquivo = $"{parametro.Cod_Emp}_{parametro.Local}.cvs",
                            Inicial = null,
                            Final = null,
                            Observacao = "",
                            Status = "Aguardando"
                        };
                        lsTarefas.Add(obj);
                    }
                    if (cbLocal.SelectedIndex == 0 && cbAno.SelectedIndex == 0 && cbMes.SelectedIndex == 1)
                    {
                        foreach ((Periodo periodo, int index2) in parametro.Periodos
                                .GroupBy(p => p.Data.Substring(3,4)) // Agrupa pelo campo Data
                                .Select(group => group.First()) // Pega o primeiro item de cada grupo
                                .Select((periodo, index2) => (periodo, index2))) // Adiciona o índice
                        {

                            Mes = cbMes.SelectedIndex == 0 ? $"_{periodo.Data.Split('/')[0]}" : "";

                            Ano = $"_{periodo.Data.Split('/')[1]}";


                            tarefa obj = new tarefa()
                            {
                                Sequencia = Indice++,
                                Cod_Emp = parametro.Cod_Emp,
                                Local = parametro.Local,
                                Ano = periodo.Data.Split('/')[1],
                                arquivo = $"{parametro.Cod_Emp}_{parametro.Local}{Ano}{Mes}.cvs",
                                Inicial = null,
                                Final = null,
                                Observacao = "",
                                Status = "Aguardando"
                            };
                            lsTarefas.Add(obj);
                        }

                    }
                    if (cbLocal.SelectedIndex == 0 && cbAno.SelectedIndex == 0 && cbMes.SelectedIndex == 0)
                    {
                        foreach ((Periodo periodo, int index2) in parametro.Periodos
                                .GroupBy(p => (p.Data.Substring(3, 4), p.Data.Substring(0, 2)))
                                .Select(group => group.First()) // Pega o primeiro item de cada grupo
                                .Select((periodo, index2) => (periodo, index2))) // Adiciona o índice
                        {

                            Mes = cbMes.SelectedIndex == 0 ? $"_{periodo.Data.Split('/')[0]}" : "";

                            Ano = $"_{periodo.Data.Split('/')[1]}";

                            Console.WriteLine($"{parametro.Cod_Emp}_{parametro.Local}{Ano}{Mes}");

                            tarefa obj = new tarefa()
                            {
                                Sequencia = Indice++,
                                Cod_Emp = parametro.Cod_Emp,
                                Local = parametro.Local,
                                Ano = periodo.Data.Split('/')[1],
                                Mes = periodo.Data.Split('/')[0],
                                arquivo = $"{parametro.Cod_Emp}_{parametro.Local}{Ano}{Mes}.cvs",
                                Inicial = null,
                                Final = null,
                                Observacao = "",
                                Status = "Aguardando"
                            };
                            lsTarefas.Add(obj);
                        }

                    }
                }
            }
            LoadDbGridLog();
        }
        private void LoadDbGridLog()
        {

            var bindingList = new BindingList<tarefa>(lsTarefas);

            var source = new BindingSource(bindingList, null);

            dtGridLog.DataSource = source;

            ConfiguraDbGridLog();

        }
        private void ConfiguraDbGridLog()
        {
            dtGridLog.AutoResizeColumns();
            dtGridLog.Columns[00].HeaderText = "Seq";
            dtGridLog.Columns[00].Width = 50;
            dtGridLog.Columns[00].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtGridLog.Columns[01].HeaderText = "Emp";
            dtGridLog.Columns[01].Width = 80;
            dtGridLog.Columns[01].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtGridLog.Columns[02].HeaderText = "Local";
            dtGridLog.Columns[02].Width = 80;
            dtGridLog.Columns[02].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; 
            dtGridLog.Columns[03].HeaderText = "Ano";
            dtGridLog.Columns[03].Width = 80;
            dtGridLog.Columns[03].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtGridLog.Columns[04].HeaderText = "Mês";
            dtGridLog.Columns[04].Width = 80;
            dtGridLog.Columns[04].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtGridLog.Columns[05].HeaderText = "Arquivo";
            dtGridLog.Columns[05].Width = 120;
            dtGridLog.Columns[05].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtGridLog.Columns[06].HeaderText = "Inicio";
            dtGridLog.Columns[06].Width = 120;
            dtGridLog.Columns[06].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtGridLog.Columns[07].HeaderText = "Final";
            dtGridLog.Columns[07].Width = 120;
            dtGridLog.Columns[07].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtGridLog.Columns[08].HeaderText = "Observação";
            dtGridLog.Columns[08].Width = 180;
            dtGridLog.Columns[08].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtGridLog.Columns[09].HeaderText = "Status";
            dtGridLog.Columns[09].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dtGridLog.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dtGridLog.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtGridLog.BorderStyle = BorderStyle.Fixed3D;
            dtGridLog.EnableHeadersVisualStyles = false;
            dtGridLog.ShowEditingIcon = false;

            dtGridLog.CellFormatting += new DataGridViewCellFormattingEventHandler(dtGridLog_FormatarData);


        }
        private void dtGridLog_FormatarData(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dtGridLog.Columns[e.ColumnIndex].Name.Equals("Inicial") || dtGridLog.Columns[e.ColumnIndex].Name.Equals("Final"))
            {
                if (e.Value == null || e.Value.GetType().Name == "String") return;
                String stringValue = ((DateTime)e.Value).ToString("dd-MM-yyyy hh:mm:ss");
                e.Value = stringValue;
            }
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            recomeco();
            status_processado();
        }
    }
}
