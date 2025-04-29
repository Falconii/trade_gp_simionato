using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trade_GP.Dao.postgre;
using Trade_GP.Models;
using Trade_GP.Util;

namespace Trade_GP
{
    public partial class FormRelatorioAnalitico : Form
    {

        private List<ParamLocal> Parametros = new List<ParamLocal>();

        private List<GridLocais> lsLocais = new List<GridLocais>();

        private List<tarefa> lsTarefas = new List<tarefa>();

        private Boolean btProximoFlag = false;

        private Boolean Cancelar = false;

        private List<meses>     lsMeses = new List<meses>();

        private List<validacao> lsValidacoes = new List<validacao>();

        private string Cod_Emp = "";

        private string Local   = "";

        private List<ContadorModel> contadores = new List<ContadorModel>();

        public ToolStripMenuItem menu { get; internal set; }
        public FormRelatorioAnalitico()
        {
            InitializeComponent();
        }

        private void lblTitulo_Click(object sender, EventArgs e)
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
            status_inical();
        }

        private void status_inical()
        {
            gbMensaProcessamento.Visible = false;
            lbTituloErros.Visible = false;
            btExcel.Visible = false;
            dtGridLog.Visible = false;
            dbLocais.Visible = false;
            btProcessar.Enabled = true;
            lblCancelamentoAtivado.Visible = false;
            btProcessar.Tag = 0;
            btProximo.Enabled = btProximoFlag;
            cbEscopo.SelectedIndex = 0;
            cbSepararLocal.SelectedIndex = 0;
            cbSepararAno.SelectedIndex = 0;

            if (tbPath.Text.Trim() == "")
            {
                tbPath.Text = UsuarioSistema.Usuario.Pasta.Trim();
            }
        }
        private void status_pre_processamento()
        {
            gbMensaProcessamento.Visible = true;
            lbTituloErros.Visible = false;
            btExcel.Visible = false;
            dtGridLog.Visible = false;
            dbLocais.Visible = true;
            btProcessar.Enabled = true;
            btProcessar.Text = "Processamento";
            btProcessar.Tag = 0;
            lblCancelamentoAtivado.Visible = false;
        }
        private void status_processando()
        {
            gbMensaProcessamento.Visible = true;
            lbTituloErros.Visible = true;
            btExcel.Visible = true;
            dtGridLog.Visible = true;
            dbLocais.Visible = true;
            btProcessar.Text = "Cancelar Processamento";
            btProcessar.Tag = 1;
            lblCancelamentoAtivado.Visible = false;
        }
        private void status_aguardando_cancelar()
        {
            gbMensaProcessamento.Visible = true;
            lbTituloErros.Visible = true;
            btExcel.Visible = true;
            dtGridLog.Visible = true;
            dbLocais.Visible = true;
            btProcessar.Text = "Voltar Ao Processamento";
            btProcessar.Tag = 2;
            lblCancelamentoAtivado.Visible = true;
        }
        private void status_processado()
        {
            btProcessar.Text = "Processamento Encerrado!";
            btProcessar.Enabled = false;
            btProximoFlag = false;
            btProximo.Enabled = true;
            btProcessar.Tag = 0;
            Parametros.Clear();
            status_inical();
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Escolha A Pasta Para A Importação";
                folderBrowserDialog.SelectedPath = tbPath.Text;
                folderBrowserDialog.ShowNewFolderButton = false;
                DialogResult result = folderBrowserDialog.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    var folderName = folderBrowserDialog.SelectedPath;
                    tbPath.Text = folderName;
                }
                else
                {
                    //BuscandoArquivo();
                }
            }
        }

        private void btParametros_Click(object sender, EventArgs e)
        {

            status_inical();

            var parametros = new FormParametros("3");

            var Result = parametros.ShowDialog();

            if (Result == DialogResult.OK)
            {

                Parametros = parametros.Parametros;

                btProximoFlag = true;

                PosicaoInicial();

            }
            else
            {

                btProximoFlag = false;

                status_inical();
            }

            parametros.Dispose();
        }

        private async void  btProximo_Click(object sender, EventArgs e)
        {

            btProximoFlag = false;

            LoadDbGridLocais();

            await LoadEscopo();

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

        private async Task<int> LoadEscopo()
        {

            contadores = new List<ContadorModel>();

            FormAviso formAviso = new FormAviso("Verificando Notas Não Processadas");

            try
            {
                this.Cursor = Cursors.WaitCursor;

                formAviso.Show();

                daoNfeDetTrade dao = new daoNfeDetTrade();

                string locais = "";

                string periodos = "";

                locais = string.Join("','", Parametros.Select(p => p.Local));

                periodos = string.Join("','", Parametros[0].Periodos.Select(p => p.Data));

                contadores = await dao.Conta_Nfe_ValoresByDay(1, Parametros[0].Cod_Emp, locais, periodos);

            }
            finally
            {
                this.Cursor = Cursors.Arrow;

                formAviso.Close();
            }


            return contadores.Count();

        }
        
        private class tarefa
        {
            public int Sequencia { get; set; }
            public string Emp { get; set; }
            public string Local { get; set; }
            public string Ano { get; set; }
            public string Mes { get; set; }
            public string Pasta { get; set; }
            public DateTime? Inicial { get; set; }
            public DateTime? Final { get; set; }
            public string Observacao { get; set; }
            public string Status { get; set; }
        }
        
        private class meses
        {
            public int Sequencia { get; set; }
            public string Mes { get; set; }
            public int Registros { get; set; }
            public int Executados { get; set; }
            public string Tempo { get; set; }
            public string Status { get; set; }
        }

        private class validacao
        {
            public int Sequencia { get; set; }
            public string Emp { get; set; }
            public string Local { get; set; }
            public string Data { get; set; }
            public string Status { get; set; }
        }

        private void PosicaoInicial()
        {
            btProximo.Enabled = btProximoFlag;
            lblLocalPeriodo.Text = "";
        }

        private void btProcessar_Click(object sender, EventArgs e)
        {
            /*
            if ((int)btProcessar.Tag == 0) // Processamento
            {
                Cancelar = false;

                lblProcesso.Text = "Locais Em Processamento";
                pgProcesso.Value = 0;
                pgProcesso.Minimum = 0;
                pgProcesso.Maximum = Parametros.Count() - 1;

                status_processando();

                int resultado = -1;

                DateTime tempoInicial = DateTime.Now;

                foreach (var (par, indexPar) in contadores.Select((tar, indexPar) => (tar, indexPar)))
                {

                    DateTime tempoLocalInicial = DateTime.Now;

                    pgProcesso.Value = indexPar;


                    if (Cancelar)
                    {

                        lblCancelamentoAtivado.Text = "Cancelamento Executado!";

                        status_processado();

                        break;
                    }

                    if (Cancelar)
                    {
                        return;
                    }

                    foreach (var (mes, index) in lsMeses.Select((tar, index) => (tar, index)))
                    {

                        DateTime tempoMesesInicial = DateTime.Now;

                        var mes_ano = mes.Mes.Split('/');

                        //NewTarefas(mes.Mes);
                        NewTarefasX(par.Local, mes_ano[0].IntParse(), mes_ano[1].IntParse());
                        resultado = await processamento(UsuarioSistema.Id_Grupo, par.Cod_Emp, par.Local);

                        lsMeses[index].Status = "OK";
                        lsMeses[index].Tempo = "00:00:10";
                        lsMeses[index].Executados = resultado;

                        dbMeses.InvalidateRow(index);

                        if (Cancelar)
                        {

                        }


                        DateTime tempoMesesFinal = DateTime.Now;

                        TimeSpan tempoTotalMeses = (TimeSpan)(tempoMesesFinal - tempoMesesInicial);

                        lsMeses[index].Tempo = String.Format("{0:00}:{1:00}:{2:00}", tempoTotalMeses.Hours, tempoTotalMeses.Minutes, tempoTotalMeses.Seconds);

                    }

                    DateTime tempoLocalFinal = DateTime.Now;

                    TimeSpan tempoTotalLocal = (TimeSpan)(tempoLocalFinal - tempoLocalInicial);

                    lsLocais[indexPar].Obs = String.Format("{0:00}:{1:00}:{2:00}", tempoTotalLocal.Hours, tempoTotalLocal.Minutes, tempoTotalLocal.Seconds);

                    dbLocais.InvalidateRow(indexPar);

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
                DialogResult resposta = MessageBox.Show("Processamento Será Interrompido No Próximo Lote. Concorda ? ", "Atenção!",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resposta == DialogResult.Yes)
                {

                    Cancelar = true;

                    //List<ErrosImportacao> Erros = new List<ErrosImportacao>();
                    //.Add(new ErrosImportacao("ATENÇÃO!", "", "", "", 0, "Cancelamento Solicitado!"));
                    //LoadDbGridErros(Erros, false);

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


        private void LoadTarefas()
        {
 /*           lsTarefas.Clear();

            foreach (var (contador, index) in contadores.Select((contador, index) => (contador, index)))
            {
                tarefa obj = new tarefa()
                {
                    tarefa:Tarefa = new Tarefa(
                                Sequencia = index,
            Emp = contador.Co
            Local =
            Ano =
            Mes =
            Pasta =
            Inicial =
            Final =
            Observacao =
            Status =
                    Inicial = null,
                    Final = null,
                    Observacao = "",
                    Status = "Aguardando"
                    }
                };
                lsTarefas.Add(obj);
            }
            LoadDbGridLog();
 */
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
            dtGridLog.Columns[02].HeaderText = "Lote";
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