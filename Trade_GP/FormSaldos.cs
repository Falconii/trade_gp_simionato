using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trade_GP.Dao.postgre;
using Trade_GP.Util;

namespace Trade_GP
{
    public partial class FormSaldos : Form
    {

        private List<ParamLocal> Parametros = new List<ParamLocal>();

        private List<GridLocais> lsLocais = new List<GridLocais>();

        private List<tarefa> lsTarefas = new List<tarefa>();

        private List<meses> lsMeses = new List<meses>();

        private List<validacao> lsValidacoes = new List<validacao>();

        private Boolean btProximoFlag = false;

        private string Cod_Emp = "";

        private string Local = "";

        private Boolean Cancelar = false;
        public ToolStripMenuItem menu { get; internal set; }
        public FormSaldos()
        {
            InitializeComponent();
        }

        private void FormSaldos_Load(object sender, EventArgs e)
        {
            btProximoFlag = false;

            status_inical();
        }



        private void FormSaldos_Activated(object sender, EventArgs e)
        {
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void FormSaldos_FormClosed(object sender, FormClosedEventArgs e)
        {
            menu.Enabled = true;
        }

        private void LoadDbGridValidacoes()
        {
                                   

            var bindingList = new BindingList<validacao>(lsValidacoes);

            var source = new BindingSource(bindingList, null);

            dbMeses.DataSource = source;

            ConfiguraDbValidacoes(); //mostra as validacoes

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

        private void ConfiguraDbValidacoes()
        {
            dbMeses.AutoResizeColumns();
            dbMeses.Columns[00].HeaderText = "SEQ";
            dbMeses.Columns[00].Width = 50;
            dbMeses.Columns[00].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbMeses.Columns[01].HeaderText = "EMPRESA";
            dbMeses.Columns[01].Width = 50;
            dbMeses.Columns[01].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbMeses.Columns[02].HeaderText = "LOCAL";
            dbMeses.Columns[02].Width = 60;
            dbMeses.Columns[02].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbMeses.Columns[03].HeaderText = "DATA";
            dbMeses.Columns[03].Width = 80;
            dbMeses.Columns[03].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbMeses.Columns[04].HeaderText = "STATUS";
            dbMeses.Columns[04].Width = 300;
            dbMeses.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dbMeses.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbMeses.BorderStyle = BorderStyle.Fixed3D;
            dbMeses.EnableHeadersVisualStyles = false;
            dbMeses.ShowEditingIcon = false;

        }
        private void PosicaoInicial()
        {
            btProximo.Enabled = btProximoFlag;
            lblLocalPeriodo.Text = "";
        }
        private void btParametros_Click(object sender, EventArgs e)
        {

            status_inical();

            var parametros = new FormParametros();

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

                PosicaoInicial();
            }

            parametros.Dispose();
        }
        private void NewTarefas(int lotes, string periodo)
        {
            int seq = 1;

            lsTarefas.Clear();

            for (int x = 1; x <= lotes; x++)
            {
                tarefa obj = new tarefa()
                {
                    Sequencia = seq,
                    Periodo = $"{periodo}",
                    Lote = $" Lote {seq}",
                    Inicial = null,
                    Final = null,
                    Observacao = "",
                    Status = "Aguardando"
                };

                lsTarefas.Add(obj);
                seq++;
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
            dtGridLog.Columns[01].HeaderText = "MÊS E ANO";
            dtGridLog.Columns[01].Width = 80;
            dtGridLog.Columns[01].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtGridLog.Columns[02].HeaderText = "LOTE";
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
        private void LoadDbMeses()
        {

            var bindingList = new BindingList<meses>(lsMeses);

            var source = new BindingSource(bindingList, null);

            dbMeses.DataSource = source;

            ConfiguraDbMeses();

        }
        private void ConfiguraDbMeses()
        {
            dbMeses.AutoResizeColumns();
            dbMeses.Columns[00].HeaderText = "Seq";
            dbMeses.Columns[00].Width = 50;
            dbMeses.Columns[00].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbMeses.Columns[01].HeaderText = "MÊS E ANO";
            dbMeses.Columns[01].Width = 100;
            dbMeses.Columns[01].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbMeses.Columns[02].HeaderText = "Notas";
            dbMeses.Columns[02].Width = 100;
            dbMeses.Columns[02].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dbMeses.Columns[03].HeaderText = "Lotes";
            dbMeses.Columns[03].Width = 100;
            dbMeses.Columns[03].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dbMeses.Columns[04].HeaderText = "Status";
            dbMeses.Columns[04].Width = 100;
            dbMeses.Columns[04].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dbMeses.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dbMeses.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbMeses.BorderStyle = BorderStyle.Fixed3D;
            dbMeses.EnableHeadersVisualStyles = false;
            dbMeses.ShowEditingIcon = false;


        }
        private async void btProcessar_Click(object sender, EventArgs e)
        {

            if ((int)btProcessar.Tag == 0) // Processamento
            {
                Cancelar = false;

                lblProcesso.Text = "Iniciando Processo!";
                pgProcesso.Value = 1;
                pgProcesso.Minimum = 0;
                pgProcesso.Maximum = lsTarefas.Count + 1;

                status_processando();

                int resultado = -1;

                foreach (var par in Parametros)
                {
                    getMeses();

                    pgProcesso.Value = 1;
                    pgProcesso.Minimum = 0;
                    pgProcesso.Maximum = lsMeses.Count + 1;

                    resultado = await contagem(UsuarioSistema.Id_Grupo, par.Cod_Emp, par.Local);

                    if (Cancelar)
                    {
                        /*
                        DialogResult resposta = MessageBox.Show("Processamento Cancelado. Deseja Encerrar O Processamento ?", "Atenção!",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (resposta == DialogResult.Yes)
                        {

                            //FechamentoOficial.DtFinal = DateTime.Now;
                            //FechamentoOficial.Status = "1";

                            //daoFechamento dao = new daoFechamento();

                            //dao.Update(FechamentoOficial);




                        }
                        */

                        lblCancelamentoAtivado.Text = "Cancelamento Executado!";

                        status_processado();

                        break;
                    }

                    if (Cancelar)
                    {
                        return;
                    }

                    foreach (var mes in lsMeses)
                    {

                        NewTarefas(mes.Lotes, mes.Mes);

                        resultado = await processamento(UsuarioSistema.Id_Grupo, par.Cod_Emp, par.Local);

                        if (Cancelar)
                        {
                            /*
                            DialogResult resposta = MessageBox.Show("Processamento Cancelado. Deseja Encerrar O Processamento ?", "Atenção!",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (resposta == DialogResult.Yes)
                            {

                                //FechamentoOficial.DtFinal = DateTime.Now;
                                //FechamentoOficial.Status = "1";

                                //daoFechamento dao = new daoFechamento();

                                //dao.Update(FechamentoOficial);




                            }
                            */

                            lblCancelamentoAtivado.Text = "Cancelamento Executado!";

                            status_processado();

                            break;
                        }
                    }
                }

                status_processado();


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
        private async Task<int> processamento(int id_grupo, string cod_emp, string local)
        {
            int i = 0;

            string Periodo = "";

            string _saida = "";

            pgProcesso.Value = 0;

            daoNfeDetTrade daoDet = new daoNfeDetTrade();

            foreach (tarefa tar in lsTarefas)
            {


                lblLocalPeriodo.Text = $"Local {local} - Data {tar.Periodo.Trim()} ";
                i++;
                //lblProcesso.Text = $"Processando {i}/{lsTarefas.Count}";
                //pgProcesso.Value = i;
                Periodo = tar.Periodo.Trim();
                tar.Inicial = DateTime.Now;
                await Task.Run(async delegate
                {
                    await Task.Delay(300);
                });
                try
                {

                    _saida = await daoDet.Saldos(UsuarioSistema.Id_Grupo, cod_emp, local, Periodo);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro: {ex.Message}");
                }
                tar.Final = DateTime.Now;
                tar.Status = "Processado !!!";
                tar.Observacao = $"{_saida}";

                if (Cancelar)
                {
                    tar.Observacao = "Cancelamento Solicitado !";
                }

                LoadDbGridLog();

                if (Cancelar) break;

            }


            if (Cancelar)
            {
                while (i < lsTarefas.Count)
                {
                    lsTarefas[i].Observacao = "Cancelado !!";
                    i++;
                };
            }

            i = lsTarefas.Count;

            return 1;
        }
        private async Task<int> contagem(int id_grupo, string cod_emp, string local)
        {
            int result = 0;

            int i = 0;

            string Periodo = "";

            int _qtd_notas = 0;

            pgProcesso.Value = 0;

            daoNfeDetTrade daoDet = new daoNfeDetTrade();

            foreach (meses mes in lsMeses)
            {


                lblLocalPeriodo.Text = $"Local {local} -  Mês {mes.Mes} ";
                i++;
                lblProcesso.Text = $"Contagem {i}/{lsMeses.Count}";
                pgProcesso.Value = i;
                mes.Status = "Processando...";
                await Task.Run(async delegate
                {
                    await Task.Delay(300);
                });
                try
                {

                    _qtd_notas = await daoDet.Conta_Nfe_Saida(UsuarioSistema.Id_Grupo, cod_emp, local, mes.Mes);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro: {ex.Message}");
                }
                mes.Registros = _qtd_notas;
                Decimal lote = Decimal.Truncate(_qtd_notas / 300);
                var resto = _qtd_notas % 300;
                if (resto > 0)
                {
                    lote++;
                }
                mes.Lotes = Int32.Parse(lote.ToString());

                mes.Status = "OK!";

                if (Cancelar)
                {
                    mes.Status = "Processamento Cancelado!";
                }

                LoadDbMeses();

                if (Cancelar) break;

            }


            if (Cancelar)
            {
                while (i < lsMeses.Count)
                {
                    lsMeses[i].Status = "Cancelado !!";
                    i++;
                };
                result = -1;
            }

            i = lsMeses.Count;

            lblProcesso.Text = $"Processando Mês {i}/{lsMeses.Count}";

            pgProcesso.Value = i;

            return result;
        }
        private void status_inical()
        {
            gbMensaProcessamento.Visible = false;
            lblMeses.Visible = false;
            lblTarefas.Visible = false;
            dbMeses.Visible = false;
            dtGridLog.Visible = false;
            dbLocais.Visible = false;
            btProcessar.Enabled = true;
            lblCancelamentoAtivado.Visible = false;
            btProcessar.Tag = 0;
            btProximo.Enabled = btProximoFlag;
        }
        private void status_contagem()
        {
            gbMensaProcessamento.Visible = false;
            lblMeses.Visible = true;
            lblTarefas.Visible = false;
            dbMeses.Visible = true;
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
            lblMeses.Visible = false;
            lblTarefas.Visible = false;
            dbMeses.Visible = false;
            dtGridLog.Visible = false;
            dbLocais.Visible = true;
            btProcessar.Enabled = true;
            btProcessar.Text = "Processamento";
            btProcessar.Tag = 0;
            lblCancelamentoAtivado.Visible = false;
        }

        private void status_erro_validacao()
        {
            gbMensaProcessamento.Visible = false;
            lblMeses.Visible = false;
            lblTarefas.Visible = false;
            dbMeses.Visible = true;
            dtGridLog.Visible = false;
            dbLocais.Visible = true;
            btProcessar.Enabled = false;
            btProcessar.Text = "Processamento";
            btProcessar.Tag = 0;
            lblCancelamentoAtivado.Visible = false;
        }
        private void status_processando()
        {
            gbMensaProcessamento.Visible = true;
            lblMeses.Visible = true;
            lblTarefas.Visible = true;
            dbMeses.Visible = true;
            dtGridLog.Visible = true;
            dbLocais.Visible = true;
            btProcessar.Text = "Cancelar Processamento";
            btProcessar.Tag = 1;
            lblCancelamentoAtivado.Visible = false;
            Cancelar = false;
        }
        private void status_aguardando_cancelar()
        {
            gbMensaProcessamento.Visible = true;
            lblMeses.Visible = true;
            lblTarefas.Visible = true;
            dbMeses.Visible = true;
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
            Cancelar = false;
            status_inical();
        }
        private async void btProximo_Click(object sender, EventArgs e)
        {

            btProximoFlag = false;

            LoadDbGridLocais();

            getMeses();

            int total = await  validacaoDevAsync();

            if (total > 0)
            {
                LoadDbGridValidacoes();
                status_erro_validacao();
            }
            else
            {
                LoadDbMeses();

                LoadDbGridValidacoes();

                lblProcesso.Text = "Aguardando Inicio!";
                pgProcesso.Value = 0;
                pgProcesso.Minimum = 0;
                pgProcesso.Maximum = lsMeses.Count + 1;

                status_pre_processamento();
            }
        }

        private void getMeses()
        {
            lsMeses.Clear();
            int idx = 1;
            foreach (var periodo in Parametros[0].Periodos)
            {
                meses obj = new meses()
                {
                    Sequencia = idx++,
                    Mes = periodo.Data,
                    Registros = 0,
                    Lotes = 0,
                    Status = "Aguardando Processamento!"
                };
                lsMeses.Add(obj);
            }
                    }

        private void Contagem()
        {
            status_contagem();
            getMeses();
        }
        private class tarefa
        {
            public int Sequencia { get; set; }
            public string Periodo { get; set; }
            public string Lote { get; set; }
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
            public int Lotes { get; set; }
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

        private async Task<int> validacaoDevAsync()
        {

            int idx = 0;

            int total = 0;

            lsValidacoes.Clear();

            foreach (var local in lsLocais)
            {

                foreach (var mes in lsMeses)
                {
                    daoNfeDetTrade dao = new daoNfeDetTrade();

                    total = await dao.Processou_Devolucao(1,this.Parametros[0].Cod_Emp, local.Local, mes.Mes);

                    if (total > 0)
                    {
                        validacao obj = new validacao()
                        {
                            Sequencia = idx++,
                            Emp = this.Parametros[0].Cod_Emp,
                            Local = local.Local,
                            Data = mes.Mes,
                            Status = $"Não Validado ! ({total})"
                        };
                        lsValidacoes.Add(obj);
                    }
                }
            }

            total = lsValidacoes.Count;


            return total;
        }
        private void pgProcesso_Click(object sender, EventArgs e)
        {

        }

        private void lblProcesso_Click(object sender, EventArgs e)
        {

        }
    }

}