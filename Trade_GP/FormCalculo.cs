using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
    public partial class FormCalculo : Form
    {
        Boolean Cancelar = false;

        int TotalRegistros = 0;

        int Blocos = 1000;

        DateTime Inicial;

        DateTime Final;

        List<tarefa> tarefas = new List<tarefa>();

        int Horas;

        private Fechamento FechamentoOficial;

        public Visoes visao = Visoes.Browser;
        public ToolStripMenuItem menu { get; internal set; }
        public FormCalculo(Fechamento oficial)
        {
            InitializeComponent();

            FechamentoOficial = oficial;

        }
        private void FormCalculo_Activated(object sender, EventArgs e)
        {

            WindowState = System.Windows.Forms.FormWindowState.Maximized;

        }
        private void FormCalculo_FormClosed(object sender, FormClosedEventArgs e)
        {
            menu.Enabled = true;
        }
        private void FormCalculo_Load(object sender, EventArgs e)
        {
            status_inical();

            if (FechamentoOficial.Id == 0)
            {
                lblFechamento.Text = $"NOVO FECHAMENTO {FechamentoOficial.Descricao}";
            }
            else
            {
                lblFechamento.Text = $"Fechamento: {FechamentoOficial.Id} - {FechamentoOficial.Descricao}";
            }
        }
        private void status_inical()
        {
            gbData.Visible = true;
            gbAtencao.Visible = false;
            gbMensaProcessamento.Visible = false;
            lbTituloErros.Visible = false;
            btExcel.Visible = false;
            dtGridLog.Visible = false;
            btValidar.Enabled = true;
            btPreparar.Enabled = true;
            btProcessar.Enabled = true;
            lblTempoFinal.Text = "";
            lblCancelamentoAtivado.Visible = false;
        }
        private void status_atençao()
        {
            gbData.Visible = true;
            gbAtencao.Visible = true;
            gbMensaProcessamento.Visible = false;
            lbTituloErros.Visible = false;
            btExcel.Visible = false;
            dtGridLog.Visible = false;
            btProcessar.Text = "Processamento";
            btProcessar.Tag = 0;
            lblCancelamentoAtivado.Visible = false;
        }
        private void status_pre_processamento()
        {
            gbData.Visible = true;
            gbAtencao.Visible = true;
            gbMensaProcessamento.Visible = true;
            lbTituloErros.Visible = false;
            btExcel.Visible = false;
            dtGridLog.Visible = false;
            btProcessar.Text = "Processamento";
            btProcessar.Tag = 0;
            lblCancelamentoAtivado.Visible = false;
        }
        private void status_processando()
        {
            gbData.Visible = true;
            gbAtencao.Visible = true;
            gbMensaProcessamento.Visible = true;
            lbTituloErros.Visible = true;
            btExcel.Visible = true;
            dtGridLog.Visible = true;
            btValidar.Enabled = false;
            btPreparar.Enabled = false;
            btProcessar.Text = "Cancelar Processamento";
            btProcessar.Tag = 1;
            lblCancelamentoAtivado.Visible = false;
        }
        private void status_aguardando_cancelar()
        {
            gbData.Visible = true;
            gbAtencao.Visible = true;
            gbMensaProcessamento.Visible = true;
            lbTituloErros.Visible = true;
            btExcel.Visible = true;
            dtGridLog.Visible = true;
            btValidar.Enabled = false;
            btPreparar.Enabled = false;
            btProcessar.Text = "Voltar Ao Processamento";
            btProcessar.Tag = 2;
            lblCancelamentoAtivado.Visible = true;
        }
        private void status_processado()
        {
            btValidar.Enabled   = false;
            btPreparar.Enabled  = false;
            btProcessar.Enabled = false;
            btVoltar.Visible = true;
        }
        private async void btValidar_Click(object sender, EventArgs e)
        {
            string retorno = ValidaDatas();

            FiltroNfDetE Filtro = new FiltroNfDetE();

            if (retorno == "")
            {

                Filtro.DataInicial = Inicial;

                Filtro.DataFinal = Final;

                Filtro.Operacao = "V";

                Filtro.Status = "0";

                status_atençao();

                //FormProcessando _form = new FormProcessando();

                //_form.Show();

                daoNfeDetTrade dao = new daoNfeDetTrade();

                try
                {
                    //TotalRegistros = await dao.GetContadorNFEDETE(Filtro);


                    if (TotalRegistros == 0)
                    {

                        MessageBox.Show("Não Existem Notas Neste Periodo, Para Processamento!");

                        status_inical();

                    }
                    else
                    {
                        AtualizaLabel();

                        status_atençao();

                        NewTarefas();

                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    //_form.Close();
                }

            }
            else
            {

                MessageBox.Show(retorno);

            }
        }
        private void btPreparar_Click(object sender, EventArgs e)
        {
            status_pre_processamento();
        }
        private async void btProcessar_Click(object sender, EventArgs e)
        {

            if ((int)btProcessar.Tag == 0) // Processamento
            {
                Cancelar = false;

                lblProcesso.Text = "Iniciando Processo!";
                pgProcesso.Value   = 1;
                pgProcesso.Minimum = 0;
                pgProcesso.Maximum = tarefas.Count+1;

                status_processando();

                lblTempoFinal.Text = $"Hora Estimado Do Término {DateTime.Now.AddMinutes(Horas).ToString()}";

                int resultado = await processamento();

                if (resultado == 0)
                {
                    MessageBox.Show("Houve Falha No Processamento!");

                }
                else
                {
                    if (Cancelar)
                    {

                        DialogResult resposta = MessageBox.Show("Processamento Cancelado. Deseja Encerrar O Processamento ?", "Atenção!",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (resposta == DialogResult.Yes)
                        {
                            FechamentoOficial.DtFinal = DateTime.Now;
                            FechamentoOficial.Status = "1";

                            daoFechamento dao = new daoFechamento();

                            dao.Update(FechamentoOficial);
                        }

                        lblCancelamentoAtivado.Text = "Cancelamento Executado!";
                    }
                    else
                    {

                        MessageBox.Show("Processamento Executado Com Sucesso!");

                        FechamentoOficial.DtFinal = DateTime.Now;
                        FechamentoOficial.Status = "1";

                        daoFechamento dao = new daoFechamento();

                        dao.Update(FechamentoOficial);
                    }

                    status_processado();

                    return;

                }

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
        private String ValidaDatas()
        {
            String cRetorno = "";

            bool dataValida;

            DateTime data;

            dataValida = DateTime.TryParseExact(txtDataInicial.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                                                     DateTimeStyles.None, out data);

            if (!dataValida) { cRetorno += "Data Inicial Inválida !! \n"; }
            else { Inicial = data; }

            dataValida = DateTime.TryParseExact(txtDataFinal.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                                                     DateTimeStyles.None, out data);


            if (!dataValida) { cRetorno += "Data Final Inválida !!"; }
            else { Final = data; }

            return cRetorno;
        }
        private void AtualizaLabel()
        {
            int Media = 4;
            Horas = ((TotalRegistros / Blocos) * Media) / 60;
            lbMensaAtencao.Text =
                $"Existem {TotalRegistros} Notas.\n\n" +
                $"Essas Notas Serão Processadas Em Blocos De {Blocos} unidades.\n\n" +
                $"Cada Processamento Demora Em Média, {Media} Segundos.\n\n" +
                $"Tempo aproximado {Horas} minutos.";
        }
        private void LoadDbGridLog()
        {

            var bindingList = new BindingList<tarefa>(tarefas);

            var source = new BindingSource(bindingList, null);

            dtGridLog.DataSource = source;

            ConfiguraDbGridLog();

        }
        private void ConfiguraDbGridLog()
        {
            dtGridLog.AutoResizeColumns();
            dtGridLog.Columns[00].HeaderText = "Seq";
            dtGridLog.Columns[00].Width = 50;
            dtGridLog.Columns[01].HeaderText = "Descrição";
            dtGridLog.Columns[01].Width = 400;
            dtGridLog.Columns[01].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtGridLog.Columns[02].HeaderText = "Inicio";
            dtGridLog.Columns[02].Width = 120;
            dtGridLog.Columns[02].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtGridLog.Columns[03].HeaderText = "Final";
            dtGridLog.Columns[03].Width = 120;
            dtGridLog.Columns[03].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtGridLog.Columns[04].HeaderText = "Observação";
            dtGridLog.Columns[04].Width = 350;
            dtGridLog.Columns[04].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtGridLog.Columns[05].HeaderText = "Status";
            dtGridLog.Columns[05].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

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
        private void NewTarefas()
        {
            int n = TotalRegistros / Blocos;

            if (TotalRegistros % Blocos > 0) n++;

            for (int x = 0; x < n; x++)
            {
                tarefa obj = new tarefa()
                {
                    Sequencia = x + 1,
                    Descricao = $"Lote {x + 1}",
                    Inicial = null,
                    Final = null,
                    Observacao = "",
                    Status = "Aguardando"
                };
                tarefas.Add(obj);
            }
            LoadDbGridLog();
        }
        private async Task<int> processamento()
        {
            int i = 0;
            daoFechamento dao = new daoFechamento();
            //Grava Fechamento
            if (FechamentoOficial.Id == 0)
            {
                FechamentoOficial.PInicial = Inicial;
                FechamentoOficial.PFinal = Final;
                FechamentoOficial.DtInicial = DateTime.Now;

                Fechamento fec = dao.Insert(FechamentoOficial);

                if (fec == null)
                {
                    MessageBox.Show("Falha Na Gravação Do Fechamento");

                    return 0;
                }

                FechamentoOficial = fec;

            }
            
            pgProcesso.Value = 0;

            daoNfeDetTrade daoDet = new daoNfeDetTrade();

            foreach (tarefa tar in tarefas)
            {
                i++;
                lblProcesso.Text = $"Processando Lote {i}/{tarefas.Count}";
                pgProcesso.Value = i;
                tar.Inicial = DateTime.Now;
                await Task.Run(async delegate
                {
                    await Task.Delay(1000);
                });
                try
                {

                    //var x = await daoDet.Calcula_Saldo(Inicial, Final, UsuarioSistema.Id_Grupo, FechamentoOficial.Id);

                } catch(Exception ex)
                {
                    MessageBox.Show($"Erro: {ex.Message}");
                }
                tar.Final = DateTime.Now;
                tar.Status = "Processado !!!";

                if (Cancelar)
                {
                    tar.Observacao = "Cancelamento Solicitado !";
                }

                LoadDbGridLog();

                if (Cancelar) break;

            }


            if (Cancelar)
            {
                while (i < tarefas.Count) 
                    {
                        tarefas[i].Observacao = "Cancelado !!";
                        i++;
                }; 
            }
            i = tarefas.Count + 1;
            lblProcesso.Text = $"Processando Lote {i}/{tarefas.Count}";
            pgProcesso.Value = i;
            
            return 1;
        }
        private class tarefa
        {
            public int Sequencia { get; set; }
            public string Descricao { get; set; }
            public DateTime? Inicial { get; set; }
            public DateTime? Final { get; set; }
            public string Observacao { get; set; }
            public string Status { get; set; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btExcel_Click(object sender, EventArgs e)
        {
            if ((dtGridLog.Rows.Count == 1) && (dtGridLog.Rows[0].Cells[0].Value.ToString().Trim() == ""))
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
                for (int i = 1; i < ((dtGridLog.Columns.Count + 1) <= 500 ? dtGridLog.Columns.Count + 1 : 500); i++)
                {
                    xcelApp.Cells[1, i] = dtGridLog.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dtGridLog.Rows.Count; i++)
                {
                    for (int j = 0; j < dtGridLog.Columns.Count; j++)
                    {
                        if (dtGridLog.Rows[i].Cells[j].Value == null)
                        {
                            continue;
                        }
                        if (dtGridLog.Rows[i].Cells[j].Value.GetType().Name == "String")
                        {
                            xcelApp.Cells[i + 2, j + 1] = dtGridLog.Rows[i].Cells[j].Value.ToString();
                        }
                        else if (dtGridLog.Rows[i].Cells[j].Value.GetType().Name == "Double")
                        {
                            double valor = dtGridLog.Rows[i].Cells[j].Value.ToString().DoubleParse();

                            xcelApp.Cells[i + 2, j + 1] = valor;
                        }
                        else if (dtGridLog.Rows[i].Cells[j].Value.GetType().Name == "int32")
                        {
                            int valor = dtGridLog.Rows[i].Cells[j].Value.ToString().IntParse();

                            xcelApp.Cells[i + 2, j + 1] = valor;
                        }
                        else
                        {
                            xcelApp.Cells[i + 2, j + 1] = dtGridLog.Rows[i].Cells[j].Value.ToString();
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
    }
}
