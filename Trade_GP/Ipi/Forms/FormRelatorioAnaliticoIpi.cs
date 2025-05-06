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
            public string Periodo { get; set; }
            public string Data { get; set; }
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
        private void btProcessar_Click(object sender, EventArgs e)
        {
            status_processando();

            NewTarefas();
        }

        private void NewTarefas()
        {
            lsTarefas.Clear();

            string Ano = "";

            string Mes = "";

            if (cbLocal.SelectedIndex == 1)
            {
                tarefa obj = new tarefa()
                {
                    Sequencia = 0,
                    Cod_Emp = Parametros[0].Cod_Emp,
                    Local = "",
                    Ano =  "",
                    Mes = "",
                    Periodo = "",//$"{filtro.Mes.ToString("D2")}/{filtro.Ano.ToString("D2")}",
                    Data = "",//filtro.dt_ref.ToString("dd/MM/yyyy"),
                    Inicial = null,
                    Final = null,
                    Observacao = $"{Parametros[0].Cod_Emp}",
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
                            Sequencia = 0,
                            Cod_Emp = parametro.Cod_Emp,
                            Local   = parametro.Local,
                            Ano = "",
                            Mes = "",
                            Periodo = "",//$"{filtro.Mes.ToString("D2")}/{filtro.Ano.ToString("D2")}",
                            Data = "",//filtro.dt_ref.ToString("dd/MM/yyyy"),
                            Inicial = null,
                            Final = null,
                            Observacao = $"{Cod_Emp} {Local}",
                            Status = "Aguardando"
                        };
                        lsTarefas.Add(obj);
                    }
                    if (cbLocal.SelectedIndex == 0 && cbAno.SelectedIndex == 0 && cbMes.SelectedIndex == 1)
                    {
                        foreach (var (periodo, index2) in parametro.Periodos.Select((periodo, index2) => (periodo, index2)))
                        {

                            Mes = cbMes.SelectedIndex == 0 ? $"_{periodo.Data.Split('/')[0]}" : "";

                            Ano = $"_{periodo.Data.Split('/')[1]}";

                            Console.WriteLine($"{parametro.Cod_Emp}_{parametro.Local}{Ano}{Mes}");
                        
                            tarefa obj = new tarefa()
                            {
                                Sequencia = index2,
                                Cod_Emp = parametro.Cod_Emp,
                                Local = parametro.Local,
                                Ano = "",
                                Mes = "",
                                Periodo = "",//$"{filtro.Mes.ToString("D2")}/{filtro.Ano.ToString("D2")}",
                                Data = "",//filtro.dt_ref.ToString("dd/MM/yyyy"),
                                Inicial = null,
                                Final = null,
                                Observacao = $"{Cod_Emp} {Local}",
                                Status = "Aguardando"
                            };
                            lsTarefas.Add(obj);
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
            dtGridLog.Columns[01].HeaderText = "mês/ano";
            dtGridLog.Columns[01].Width = 80;
            dtGridLog.Columns[01].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtGridLog.Columns[02].HeaderText = "dia";
            dtGridLog.Columns[02].Width = 80;
            dtGridLog.Columns[02].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtGridLog.Columns[03].HeaderText = "Inicio";
            dtGridLog.Columns[03].Width = 120;
            dtGridLog.Columns[03].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtGridLog.Columns[04].HeaderText = "Final";
            dtGridLog.Columns[04].Width = 120;
            dtGridLog.Columns[04].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtGridLog.Columns[05].HeaderText = "Observação";
            dtGridLog.Columns[05].Width = 180;
            dtGridLog.Columns[05].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtGridLog.Columns[06].HeaderText = "Status";
            dtGridLog.Columns[06].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

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
    }
}
