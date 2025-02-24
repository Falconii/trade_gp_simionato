using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trade_GP.Dao.postgre;
using Trade_GP.Extensoes;
using Trade_GP.Models;
using Trade_GP.Util;

namespace Trade_GP
{
    public partial class FormVlrEconomicoLotes : Form
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

        private List<ContadorModel> contadores = new List<ContadorModel>();
        public ToolStripMenuItem menu { get; internal set; }

        public FormVlrEconomicoLotes()
        {
            InitializeComponent();
        }

        private void FormVlrEconomicoLotes_Load(object sender, EventArgs e)
        {
            btProximoFlag = false;

            recomeco();

            status_inicial();
        }

        private void FormVlrEconomicoLotes_Activated(object sender, EventArgs e)
        {
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void FormVlrEconomicoLotes_FormClosed(object sender, FormClosedEventArgs e)
        {
            menu.Enabled = true;
        }

        private void FormSaldos_Load(object sender, EventArgs e)
        {
            btProximoFlag = false;

            status_inicial();
        }

        private void recomeco()
        {

            Parametros = new List<ParamLocal>();

            lsLocais = new List<GridLocais>();

            lsTarefas = new List<tarefa>();

            lsMeses = new List<meses>();

            lsValidacoes = new List<validacao>();

            btProximoFlag = false;

            Cod_Emp = "";

            Local = "";

            Cancelar = false;

            contadores = new List<ContadorModel>();
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
        private void PosicaoInicial()
        {
            btProximo.Enabled = btProximoFlag;
            lblLocalPeriodo.Text = "";
        }
        private void btParametros_Click(object sender, EventArgs e)
        {

            status_inicial();

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

                PosicaoInicial();
            }

            parametros.Dispose();
        }
        private void NewTarefas(string periodo)
        {
            int seq = 1;

            string[] mes_ano = periodo.Split('/');

            int primeiroDia = (mes_ano[1] == "2017" && mes_ano[0] == "03") ? 16 : 1; 

            int ultimoDia   = DateTime.DaysInMonth(mes_ano[1].IntParse(), mes_ano[0].IntParse());

            lsTarefas.Clear();

            for (int dia = primeiroDia; dia <= ultimoDia; dia++)
            {
                var  hoje = new DateTime(mes_ano[1].IntParse(), mes_ano[0].IntParse(), dia);

                tarefa obj = new tarefa()
                {
                    Sequencia = seq,
                    Periodo = $"{periodo}",
                    Data = hoje.ToString("dd/MM/yyyy"),
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

        private void NewTarefasX(string local, int mes, int ano)
        {
            lsTarefas.Clear();

            var filtrados = contadores
                .Where(c => c.local == local && c.ano == ano && c.mes == mes)
                .GroupBy(c => new { c.local, c.ano, c.mes, c.dt_ref })
                .Select(g => new { Local = g.Key.local, Ano = g.Key.ano, Mes = g.Key.mes, dt_ref = g.Key.dt_ref, Notas = g.Sum(c => c.notas) })
                .ToList();

            foreach (var (filtro, index) in filtrados.Select((tar, index) => (tar, index)))
            {
                tarefa obj = new tarefa()
                {
                    Sequencia = index,
                    Periodo = $"{filtro.Mes.ToString("D2")}/{filtro.Ano.ToString("D2")}",
                    Data = filtro.dt_ref.ToString("dd/MM/yyyy"),
                    Inicial = null,
                    Final = null,
                    Observacao = "",
                    Status = "Aguardando"
                };
                lsTarefas.Add(obj);
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
            dbMeses.Columns[01].HeaderText = "Mês Ano";
            dbMeses.Columns[01].Width = 80;
            dbMeses.Columns[01].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dbMeses.Columns[02].HeaderText = "Notas";
            dbMeses.Columns[02].Width = 80;
            dbMeses.Columns[02].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dbMeses.Columns[03].HeaderText = "Executadas";
            dbMeses.Columns[03].Width = 80;
            dbMeses.Columns[03].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dbMeses.Columns[04].HeaderText = "Tempo";
            dbMeses.Columns[04].Width = 80;
            dbMeses.Columns[04].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbMeses.Columns[05].HeaderText = "Status";
            dbMeses.Columns[05].Width = 80;
            dbMeses.Columns[05].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

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

                lblProcesso.Text = "Locais Em Processamento";
                pgProcesso.Value = 0;
                pgProcesso.Minimum = 0;
                pgProcesso.Maximum = Parametros.Count() - 1;

                status_processando();

                int resultado = -1;

                DateTime tempoInicial = DateTime.Now;

                foreach (var (par, indexPar) in Parametros.Select((tar, indexPar) => (tar, indexPar)))
                {
                    //getMeses();

                    DateTime tempoLocalInicial = DateTime.Now;

                    getMesesX(par.Local);

                    pgProcesso.Value = indexPar;

                    LoadDbMeses();

                    //resultado = await contagem(UsuarioSistema.Id_Grupo, par.Cod_Emp, par.Local);

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
        private async Task<int> processamento(int id_grupo, string cod_emp, string local)
        {
            int i = 0;

            string Periodo = "";

            int _saida = 0;

            pgProcesso.Value = 0;

            daoNfeDetTrade daoDet = new daoNfeDetTrade();

            var selic = (cbSelic.SelectedItem as string).Split('/');

            int anoSelic = selic[1].IntParse();

            int mesSeleic = selic[0].IntParse();

            int tota_notas = 0;

            foreach (var (tar, index) in lsTarefas.Select((tar, index) => (tar, index)))
            {

                lblLocalPeriodo.Text = $"Local {local} -  Mês {tar.Periodo} ";

                i++;
                                
                Periodo = tar.Data.Trim();

                tar.Inicial = DateTime.Now;

                await Task.Run(async delegate
                {
                    await Task.Delay(300);
                });
                try
                {
                    if (cbTipoProcessamento.SelectedIndex == 0)
                    {
                        _saida = await daoDet.Vlr_Economico_V3(UsuarioSistema.Id_Grupo, cod_emp, local, Periodo, anoSelic, mesSeleic);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro: {ex.Message}");
                }
                tar.Final = DateTime.Now;

                TimeSpan tempo = (TimeSpan)(tar.Final - tar.Inicial);

                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}", tempo.Hours, tempo.Minutes, tempo.Seconds);

                tar.Status = $"Processado {elapsedTime}";

                tar.Observacao = $"ToTal De Notas {_saida}.";

                tota_notas += _saida;

                if (Cancelar)
                {
                    tar.Observacao = "Cancelamento Solicitado !";
                }

                dtGridLog.InvalidateRow(index);

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

            return tota_notas;
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

                try
                {

                    _qtd_notas = await daoDet.Conta_Nfe_Saida_Val(UsuarioSistema.Id_Grupo, cod_emp, local, mes.Mes);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro: {ex.Message}");
                }

                mes.Registros = _qtd_notas;
               
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
        private void status_inicial()
        {
            gbMensaProcessamento.Visible = false;
            cbTipoProcessamento.SelectedIndex = 0;
            cbSelic.SelectedIndex = 0;
            lblMeses.Visible = false;
            lblTarefas.Visible = false;
            dbMeses.Visible = false;
            dtGridLog.Visible = false;
            dbLocais.Visible = false;
            dbMeses.ReadOnly = true;
            dtGridLog.ReadOnly = true;
            dbLocais.ReadOnly = true;
            btProcessar.Enabled = true;
            lblCancelamentoAtivado.Visible = false;
            btProcessar.Tag = 0;
            btProcessar.Visible = true;
            btNovo.Visible = false;
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
            lblMeses.Visible   = false;
            lblTarefas.Visible  = false;
            dbMeses.Visible     = true;
            dtGridLog.Visible   = false;
            dbLocais.Visible    = true;
            btProcessar.Enabled = false;
            btProcessar.Text    = "Processamento";
            btProcessar.Tag     = 0;
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
            status_inicial();
        }
        private void status_terminado()
        {
            btNovo.Visible = true;
            btNovo.Enabled = true;
            btProcessar.Visible = false;
        }
        private async void btProximo_Click(object sender, EventArgs e)
        {

            btProximoFlag = false;

            LoadDbGridLocais();

            await LoadEscopo();

            status_pre_processamento();

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
                    Status = "Aguardando Processamento!"
                };
                lsMeses.Add(obj);
            }
        }



        private void getMesesX(string local)
        {
            int idx = 1;
            lsMeses.Clear();

            var filtrados = contadores
                .Where(c => c.local == local)
                .GroupBy(c => new { c.local, c.ano, c.mes })
                .Select(g => new { Local = g.Key.local, Ano = g.Key.ano, Mes = g.Key.mes, Notas = g.Sum(c => c.notas) })
                .ToList();
            filtrados.ForEach(filtro =>
            {
                meses obj = new meses()
                {
                    Sequencia = idx++,
                    Mes = $"{filtro.Mes.ToString("D2")}/{filtro.Ano.ToString("D2")}",
                    Registros = filtro.Notas,
                    Tempo = "",
                    Status = "Aguardando Processamento!"
                };
                lsMeses.Add(obj);
            });
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
            public string Data { get; set; }
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

                    total = await dao.Processou_Devolucao(1, this.Parametros[0].Cod_Emp, local.Local, mes.Mes);

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

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void lblCancelamentoAtivado_Click(object sender, EventArgs e)
        {

        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            btProximoFlag = false;

            recomeco();

            status_inicial();
        }
    }
}
