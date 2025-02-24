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
using Trade_GP.Extensoes;
using Trade_GP.Models;
using Trade_GP.Models.Validacoes;
using Npgsql;
using Trade_GP;

namespace Trade_GP
{
    public partial class FormSelic : Form
    {
              Visoes visao = Visoes.Browser;

        Selic selic  = new Selic();

        int Ordenacao = 0; //Ano Mes 

        string ano = "";

        string mes = "";

        public ToolStripMenuItem menu { get; internal set; }
        public FormSelic()
        {
            InitializeComponent();
        }


        private void SetarProperties(bool value)
        {
            if (visao == Visoes.Nova)
            {
                txtAno.Enabled = true;
                txtMes.Enabled = true;
            } else
            {
                txtAno.Enabled = false;
                txtMes.Enabled = false;
            }
            txtTaxa.Enabled   = value;
            txtAno.MaxLength  = 4;
            txtMes.MaxLength  = 2;
            txtTaxa.MaxLength = 6;
        }

        private void loadSelic()
        {

            preencheDataGridView();

        }


        //Botoes da Barra
        private void TbBrowser_Click(object sender, EventArgs e)
        {
            switch (visao)
            {

                case Visoes.Browser:

                    visao = Visoes.Consulta;

                    daoSelic dao = new daoSelic();

                    selic = dao.Seek(ano,mes);

                    if (selic == null)
                    {

                        selic = new Selic();

                        visao = Visoes.Nova;

                    }

                    Atualiza();

                    break;

                default:

                    visao = Visoes.Browser;

                    break;

            }

            SetarVisoes();
        }

        private void TbEditar_Click(object sender, EventArgs e)
        {
            visao = Visoes.Edicao;

            SetarVisoes();
        }

        private void TbIncluir_Click(object sender, EventArgs e)
        {
            visao = Visoes.Nova;

            selic = new Selic();

            Atualiza();

            SetarVisoes();
        }

        private void TbDelete_Click(object sender, EventArgs e)
        {

            DialogResult resultado = MessageBox.Show("Confirma A Exclusão ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            switch (resultado)

            {


                case DialogResult.No:

                    break;

                case DialogResult.Yes:

                    daoSelic dao = new daoSelic();

                    dao.Delete(selic);

                    loadSelic();

                    break;

                default:

                    break;

            }

            visao = Visoes.Browser;

            SetarVisoes();
        }

        private void TbOk_Click(object sender, EventArgs e)
        {

            try
            {

                PopularSelic();

                string Erros = Validacao();

                if (Erros != "")
                {

                    MessageBox.Show(Erros);

                    return;

                }

                daoSelic dao = new daoSelic();


                switch (visao)
                {

                    case Visoes.Nova:

                        Selic retorno = dao.Insert(selic);

                        if (retorno != null)
                        {

                            MessageBox.Show($"SELIC Incluída.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {

                            MessageBox.Show($"Falha Na Inclusão Da SELIC!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);


                        }

                        visao = Visoes.Browser;

                        loadSelic();

                        SetarVisoes();

                        break;

                    case Visoes.Edicao:

                        dao.Update(selic);

                        MessageBox.Show($"SELIC Alterada Com Sucesso!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        visao = Visoes.Browser;

                        loadSelic();

                        SetarVisoes();

                        break;

                }
            }
            catch (Exception exc)
            {

                MessageBox.Show("Falha No Procedimento\n" + exc.Message);

            }


        }

        private void TbCancelar_Click(object sender, EventArgs e)
        {
            visao = Visoes.Browser;

            SetarVisoes();
        }

        private void CbPesquisar_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ordenacao = cbPesquisar.SelectedIndex;

            loadSelic();
        }

        private void BtBuscar_Click(object sender, EventArgs e)
        {
            loadSelic();
        }


        //GridView

        private void DbGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            {
                try
                {

                    ano = ((DataGridView)sender)[0, e.RowIndex].Value.ToString();

                    mes = ((DataGridView)sender)[1, e.RowIndex].Value.ToString();

                }
                catch (Exception exc)
                {
                    ano = "";
                    mes = "";
                }

            }
        }

        private void DbGridView_DoubleClick(object sender, EventArgs e)
        {

            visao = Visoes.Consulta;

            daoSelic dao = new daoSelic();

            selic = dao.Seek(ano,mes);

            if (selic == null)
            {

                selic = new Selic();

                visao = Visoes.Nova;

            }

            Atualiza();

            SetarVisoes();

        }

        private void ConfiguraDbDridView()
        {



            dbGridView.AutoResizeColumns();
            dbGridView.Columns[00].HeaderText = "ANO";
            dbGridView.Columns[01].HeaderText = "MÊS";
            dbGridView.Columns[02].HeaderText = "TAXA";

            dbGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dbGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dbGridView.BorderStyle = BorderStyle.Fixed3D;
            dbGridView.EnableHeadersVisualStyles = false;







        }

        public void preencheDataGridView()
        {
            //faz a conexão
            var conn = new NpgsqlConnection(DataBase.RunCommand.connectionString);

            try //inicio do tratamento de exceções 
            {

                daoSelic dao = new daoSelic();

                string strSelect = dao.SqlGrid(Ordenacao, edPesquisar.Text.Trim());

                conn.Open(); //abre conexão 
                var sql = new NpgsqlCommand(strSelect, conn); //comando SQL 

                //SqlDataAdapter é o adaptador que interliga classes que manipulam dados em C# e o banco de dados em si 
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql);

                // DataSet é um cache na memória dos dados recuperados de uma fonte de dados
                DataSet ds = new DataSet();

                // O método Fill faz o preenchimento do objeto DataTable, inserindo nele os dados que retornaram do SGBD 
                da.Fill(ds);


                // O DataGridView possui o complemento DataSource, e por ele podemos determinar a origem dos dados que irão compor suas linhas e colunas       
                dbGridView.DataSource = ds;

                dbGridView.DataMember = ds.Tables[0].TableName;
            }
            catch (Exception ex) //fim do tratamento de exceções 
            {
                MessageBox.Show("Erro ao obter os dados!\n\n" + ex + ".", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Error); //mostra exceção, se houver 
            }
            finally //Finaliza conexão, independentemente da ocorrência de exceção ou não 
            {
                conn.Close();
            }

            ConfiguraDbDridView();
        }

        private string Validacao()
        {
            string Result = "";


            if (!Validacoes.IsTamanho(selic.Ano, 1, 4))
            {
                Result += "Use 4 dígitos para o ano!\n";
            }

            if (!Validacoes.IsTamanho(selic.Mes, 1, 2))
            {
                Result += "User 2 Mês!\n";
            }


            return Result;

        }

        private void Atualiza()
        {

            txtAno.Text  = selic.Ano;

            txtMes.Text = selic.Mes;

            txtTaxa.Text = selic.Taxa.ToString("###,###,##0.000");

        }


        //Formulario

        private void PopularSelic()
        {

            selic.Ano  = txtAno.Text;
            selic.Mes  = txtMes.Text;
            selic.Taxa = txtTaxa.Text.DoubleParse();

        }

        private void SetarVisoes()
        {

            switch (visao)
            {

                case Visoes.Browser:
                    tabControl.Visible = false;
                    dbGridView.ReadOnly = true;
                    dbGridView.Visible = true;
                    SetarBotoes();
                    break;
                case Visoes.Consulta:
                    tabControl.Visible = true;
                    dbGridView.ReadOnly = true;
                    dbGridView.Visible = false;
                    tabControl.SelectedIndex = 0;
                    SetarBotoes();
                    break;
                case Visoes.Edicao:
                    tabControl.Visible = true;
                    dbGridView.ReadOnly = true;
                    dbGridView.Visible = false;
                    txtTaxa.Focus();
                    SetarBotoes();
                    break;
                case Visoes.Nova:
                    tabControl.Visible = true;
                    dbGridView.ReadOnly = true;
                    dbGridView.Visible = false;
                    txtAno.Focus();
                    SetarBotoes();
                    break;

            }

        }

        private void SetarBotoes()
        {

            switch (visao)
            {
                case Visoes.Browser:
                    tbBrowser.Visible = true;
                    tbIncluir.Visible = false;
                    tbEditar.Visible = false;
                    tbDelete.Visible = false;
                    tbOk.Visible = false;
                    tbCancelar.Visible = false;
                    lbPesquisar.Visible = true;
                    cbPesquisar.Visible = true;
                    edPesquisar.Visible = true;
                    btBuscar.Visible = true;
                    break;
                case Visoes.Consulta:
                    tbBrowser.Visible = true;
                    tbIncluir.Visible = true;
                    tbEditar.Visible = true;
                    tbDelete.Visible = true;
                    tbOk.Visible = false;
                    tbCancelar.Visible = false;
                    lbPesquisar.Visible = false;
                    cbPesquisar.Visible = false;
                    edPesquisar.Visible = false;
                    btBuscar.Visible = false;
                    SetarProperties(false);
                    break;

                case Visoes.Edicao:
                    tbBrowser.Visible = false;
                    tbIncluir.Visible = false;
                    tbEditar.Visible = false;
                    tbDelete.Visible = false;
                    tbOk.Visible = true;
                    tbCancelar.Visible = true;
                    lbPesquisar.Visible = false;
                    cbPesquisar.Visible = false;
                    edPesquisar.Visible = false;
                    btBuscar.Visible = false;
                    SetarProperties(true);
                    break;
                case Visoes.Nova:
                    tbBrowser.Visible = false;
                    tbIncluir.Visible = false;
                    tbEditar.Visible = false;
                    tbDelete.Visible = false;
                    tbOk.Visible = true;
                    tbCancelar.Visible = true;
                    lbPesquisar.Visible = false;
                    cbPesquisar.Visible = false;
                    edPesquisar.Visible = false;
                    btBuscar.Visible = false;
                    SetarProperties(true);
                    break;

            }
        }

        private void CbPesquisar_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Ordenacao = cbPesquisar.SelectedIndex;

            loadSelic();
        }

        private void FormSelic_Activated(object sender, EventArgs e)
        {
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void FormSelic_FormClosed(object sender, FormClosedEventArgs e)
        {
            menu.Enabled = true;
        }

        private void FormSelic_Load(object sender, EventArgs e)
        {
            DateTime hoje = DateTime.Now;

            SetarVisoes();

            edPesquisar.Text = hoje.Year.ToString();

            cbPesquisar.SelectedIndex = Ordenacao;

            loadSelic();
                      
        }

        private void IsDoubleEntry(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == 44 && ((TextBox)sender).Text.IndexOf(",") != -1)
            {

                e.Handled = true;

                return;

            }

            if (!Char.IsDigit(ch) && ch != 8 && ch != 44)
            {

                e.Handled = true;
            }


        }

    }
}
