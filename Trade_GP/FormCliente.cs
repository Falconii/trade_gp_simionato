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
using Trade_GP.Dao.postgre;
using Trade_GP.DataBase;
using Trade_GP.Extensoes;
using Trade_GP.Models;
using Npgsql;
using Trade_GP.Models.Validacoes;
using Correios;

namespace Trade_GP
{
    public partial class FormCliente : Form
    {
          public Visoes visao = Visoes.Browser;

        Cliente cliente = new Cliente();

        int Ordenacao = 2; //Razao Social 

        public int Codigo = 0;

        public ToolStripMenuItem menu { get; internal set; }
        public FormCliente()
        {
            InitializeComponent();

            cbUFF.Items.Clear();

            Object[] ItemObject = new Object[FormPrincipal.estados.Count];

            for (int i = 0; i < FormPrincipal.estados.Count; i++)
            {
                ItemObject[i] = FormPrincipal.estados[i].Uf;
            }

            cbUFF.Items.AddRange(ItemObject);

            cbPesquisar.SelectedIndex = Ordenacao;

        }

        private void FormCliente_Load(object sender, EventArgs e)
        {
            if (visao == Visoes.Help)
            {
                WindowState = System.Windows.Forms.FormWindowState.Normal;
                StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            }

            SetarVisoes();

        }

        private void FormCliente_Activated(object sender, EventArgs e)
        {
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void FormCliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            menu.Enabled = true;
        }

        private void loadClientes()
        {

            try
            {

                this.Cursor = Cursors.WaitCursor;

                preencheDataGridView();

            }

            finally
            {
                this.Cursor = Cursors.Default;
            }


        }

        private void SetarVisoes()
        {

            switch (visao)
            {

                case Visoes.Browser:
                    tabCliente.Visible = false;
                    dbGridView.ReadOnly = true;
                    dbGridView.Visible = true;
                    SetarBotoes();
                    break;
                case Visoes.Consulta:
                    tabCliente.Visible = true;
                    dbGridView.ReadOnly = true;
                    dbGridView.Visible = false;
                    tabCliente.SelectedIndex = 0;
                    if (cliente.Codigo == 0)
                    {
                        visao = Visoes.Nova;
                    }
                    SetarBotoes();
                    break;
                case Visoes.Edicao:
                    SetarBotoes();
                    break;
                case Visoes.Nova:
                    SetarBotoes();
                    break;
                case Visoes.Help:
                    tabCliente.Visible = false;
                    dbGridView.ReadOnly = true;
                    dbGridView.Visible = true;
                    SetarBotoes();
                    break;

            }

        }

        private void SetarBotoes()
        {
            tbBrowser.Visible = true;

            switch (visao)
            {
                case Visoes.Browser:
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
                    tbIncluir.Visible = true;
                    tbEditar.Visible = true;
                    tbDelete.Visible = true;
                    tbOk.Visible = false;
                    tbCancelar.Visible = false;
                    lbPesquisar.Visible = false;
                    cbPesquisar.Visible = false;
                    edPesquisar.Visible = false;
                    btBuscar.Visible = false;
                    setProperties(false);
                    break;

                case Visoes.Edicao:
                    tbIncluir.Visible = false;
                    tbEditar.Visible = false;
                    tbDelete.Visible = false;
                    tbOk.Visible = true;
                    tbCancelar.Visible = true;
                    lbPesquisar.Visible = false;
                    cbPesquisar.Visible = false;
                    edPesquisar.Visible = false;
                    btBuscar.Visible = false;
                    setProperties(true);
                    break;
                case Visoes.Nova:
                    tbIncluir.Visible = false;
                    tbEditar.Visible = false;
                    tbDelete.Visible = false;
                    tbOk.Visible = true;
                    tbCancelar.Visible = true;
                    lbPesquisar.Visible = false;
                    cbPesquisar.Visible = false;
                    edPesquisar.Visible = false;
                    btBuscar.Visible = false;
                    setProperties(true);
                    break;
                case Visoes.Help:
                    tbBrowser.Visible = false;
                    tbIncluir.Visible = false;
                    tbEditar.Visible = false;
                    tbDelete.Visible = false;
                    tbOk.Visible = true;
                    tbCancelar.Visible = true;
                    lbPesquisar.Visible = true;
                    cbPesquisar.Visible = true;
                    edPesquisar.Visible = true;
                    btBuscar.Visible = true;
                    break;

            }
        }


        //Botoes da Barra
        private void TbBrowser_Click(object sender, EventArgs e)
        {

            switch (visao)
            {

                case Visoes.Browser:

                    visao = Visoes.Consulta;

                    var dao = new daoCliente();

                    cliente = dao.Seek(Codigo);

                    if (cliente == null)
                    {

                        cliente = new Cliente();

                        cliente.Zerar();

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

            cliente = new Cliente();

            cliente.Zerar();

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

                    daoCliente dao = new daoCliente();

                    dao.Delete(cliente);

                    loadClientes();

                    break;

                default:

                    break;

            }

            visao = Visoes.Browser;

            SetarVisoes();
        }

        private void TbOk_Click(object sender, EventArgs e)
        {
            if (visao == Visoes.Help)
            {

                DialogResult = DialogResult.OK;

                Close();

            }
            else
            {

                try
                {

                    PopularCliente();

                    string Erros = Validacao();

                    if (Erros != "")
                    {

                        MessageBox.Show(Erros);

                        return;

                    }

                    var dao = new daoCliente();


                    switch (visao)
                    {

                        case Visoes.Nova:

                            Cliente retorno = dao.Insert(cliente);

                            if (retorno != null)
                            {

                                MessageBox.Show($"Cliente Incluído No Código {retorno.Codigo}");

                            }
                            else
                            {

                                MessageBox.Show("Falha Na Inclusão Do Cliente !!!");

                            }

                            visao = Visoes.Browser;

                            loadClientes();

                            SetarVisoes();

                            break;

                        case Visoes.Edicao:

                            dao.Update(cliente);

                            MessageBox.Show("Cliente Alterado Com Sucesso !!!");

                            visao = Visoes.Browser;

                            loadClientes();

                            SetarVisoes();

                            break;

                    }
                }
                catch (Exception exc)
                {

                    MessageBox.Show("Falha No Procedimento\n" + exc.Message);

                }

            }

        }

        private void TbCancelar_Click(object sender, EventArgs e)
        {

            if (visao == Visoes.Help)
            {

                DialogResult = DialogResult.Cancel;

                Close();

            }
            else
            {

                visao = Visoes.Browser;

                SetarVisoes();

            }
        }



        //GridView

        private void DbGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            {
                try
                {

                    Codigo = Convert.ToInt32(((DataGridView)sender)[0, e.RowIndex].Value);

                }
                catch (Exception exc)
                {
                    Codigo = 0;
                }

            }
        }

        private void DbGridView_DoubleClick(object sender, EventArgs e)
        {

            if (visao == Visoes.Help)
            {

                DialogResult = DialogResult.OK;

                Close();

            }
            else
            {

                visao = Visoes.Consulta;

                daoCliente dao = new daoCliente();

                cliente = dao.Seek(Codigo);

                if (cliente == null)
                {

                    cliente = new Cliente();

                    cliente.Zerar();

                }

                Atualiza();

                SetarVisoes();

            }
        }

        private void ConfiguraDbGridView()
        {
            dbGridView.AutoResizeColumns();
            dbGridView.Columns[00].HeaderText = "CÓDIGO";
            dbGridView.Columns[00].Width = 100;
            dbGridView.Columns[00].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dbGridView.Columns[01].HeaderText = "RAZÃO SOCIAL";
            dbGridView.Columns[01].Width = 300;
            dbGridView.Columns[01].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dbGridView.Columns[02].HeaderText = "NOME FANTASIA";
            dbGridView.Columns[02].Width = 300;
            dbGridView.Columns[02].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dbGridView.Columns[03].HeaderText = "CNPJ/CPF";
            dbGridView.Columns[03].Width = 150;
            dbGridView.Columns[03].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dbGridView.Columns[04].HeaderText = "INCRIÇÃO EST.";
            dbGridView.Columns[04].Width = 150;
            dbGridView.Columns[04].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dbGridView.Columns[05].HeaderText = "CADASTRO";
            dbGridView.Columns[05].Width = 150;
            dbGridView.Columns[05].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dbGridView.Columns[06].HeaderText = "EMPRESA";
            dbGridView.Columns[06].Width = 150;
            dbGridView.Columns[06].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dbGridView.Columns[07].HeaderText = "LOCAL";
            dbGridView.Columns[07].Width = 150;
            dbGridView.Columns[07].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dbGridView.Columns[08].HeaderText = "COD EMPRESA";
            dbGridView.Columns[08].Width = 150;
            dbGridView.Columns[08].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dbGridView.Columns[09].HeaderText = "PROTHEUS";
            dbGridView.Columns[09].Width = 150;
            dbGridView.Columns[09].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dbGridView.Columns[10].HeaderText = "SIC";
            dbGridView.Columns[10].Width = 150;
            dbGridView.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dbGridView.Columns[11].HeaderText = "SAP";
            dbGridView.Columns[11].Width = 150;
            dbGridView.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dbGridView.Columns[12].HeaderText = "ENDEREÇO";
            dbGridView.Columns[12].Width = 300;
            dbGridView.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dbGridView.Columns[13].HeaderText = "BAIRRO";
            dbGridView.Columns[13].Width = 200;
            dbGridView.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dbGridView.Columns[14].HeaderText = "CIDADE";
            dbGridView.Columns[14].Width = 200;
            dbGridView.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dbGridView.Columns[15].HeaderText = "UF";
            dbGridView.Columns[15].Width = 80;
            dbGridView.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dbGridView.Columns[16].HeaderText = "CEP";
            dbGridView.Columns[16].Width = 80;
            dbGridView.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dbGridView.Columns[17].HeaderText = "TELEFONE";
            dbGridView.Columns[17].Width = 150;
            dbGridView.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dbGridView.Columns[18].HeaderText = "CELULAR";
            dbGridView.Columns[18].Width = 150;
            dbGridView.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dbGridView.Columns[19].HeaderText = "E-MAIL";
            dbGridView.Columns[19].Width = 300;
           //bGridView.Columns[19].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dbGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dbGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridView.BorderStyle = BorderStyle.Fixed3D;
            dbGridView.EnableHeadersVisualStyles = false;
            dbGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(dbGridView_FormatarCnpj);


        }
        private void dbGridView_FormatarCnpj(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dbGridView.Columns[e.ColumnIndex].Name.Equals("cnpj_cpf"))
            {
                string stringValue = e.Value as string;
                if (stringValue == null) return;
                e.Value = stringValue.FormatCnpjCPF();
            }
        }

        public void preencheDataGridView()
        {


            string SqlSelct = "";

            var dao = new daoCliente();

            SqlSelct = dao.SqlGrid(Ordenacao, edPesquisar.Text.Trim());

            //faz a conexão
            NpgsqlConnection conn = new NpgsqlConnection(RunCommand.connectionString);

            try //inicio do tratamento de exceções 
            {
                conn.Open(); //abre conexão 
                NpgsqlCommand sql = new NpgsqlCommand(SqlSelct, conn); //comando SQL 

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

            ConfiguraDbGridView();
        }

        private string Validacao()
        {
            string Result = "";

            if (!cliente.Cnpj_Cpf.LimpaCnpjCpf().IsCnpjCpf())
            {

                Result += "CNPJ Ou CPF Inválidos !!\n";

            }

            if (!Validacoes.IsTamanho(cliente.Razao, 0, 40))
            {
                Result += "Tamanho do Campo Razão Deve Ficar Entre 1 e 40 !\n";
            }

            if (!Validacoes.IsTamanho(cliente.Empresa, 0, 6))
            {
                Result += "Tamanho do Campo Empresa Deve Ficar Entre 1 e 6 !\n";
            }

            if (!Validacoes.IsTamanho(cliente.Enderecof, 0, 80))
            {
                Result += "Tamanho do Campo Endereço Deve Ficar Entre 0 e 80 !\n";
            }
            if (!Validacoes.IsTamanho(cliente.Bairrof, 0, 40))
            {
                Result += "Tamanho do Campo Bairro Deve Ficar Entre 0 e 40 !\n";
            }
            if (!Validacoes.IsTamanho(cliente.Cidadef, 0, 40))
            {
                Result += "Tamanho do Campo Cidade Deve Ficar Entre 0 e 40 !\n";
            }

            if (!Validacoes.IsTamanho(cliente.Uff.Substring(0, 2), 2, 2))
            {
                Result += "Tamanho do Campo Estado Deve Ter 2 Caracteres !\n";
            }

            if (!Validacoes.IsTamanho(cliente.Cepf, 0, 8))
            {
                Result += "Tamanho do Campo CEP Deve Ter 8 Digitos !";
            }


            if (!Validacoes.IsTamanho(cliente.Obs, 0, 200))
            {
                Result += "Tamanho do Campo OBS é no máximo 200 caracteres!";
            }

            if (!Validacoes.IsTamanho(cliente.Emailf, 0, 100))
            {
                Result += "Tamanho do Campo Email Faturamento é no máximo 100 caracteres!";
            }



            if (!Validacoes.IsTamanho(cliente.Emailf, 0, 100))
            {
                Result += "Tamanho do Campo Email Faturamento é no máximo 100 caracteres!";
            }
            return Result;

        }

        private void Atualiza()
        {

            int index = 0;

            foreach (var obj in cbUFF.Items)
            {

                if (cliente.Uff == obj.ToString().Substring(0, 2))
                {

                    break;

                }

                index++;

            }

            if (index > cbUFF.Items.Count - 1) index = 0;

            txtCodigo.Text = cliente.Codigo.IntNovo();
            txtRazao.Text = cliente.Razao.Trim();
            txtCnpjCpf.Text = cliente.Cnpj_Cpf.FormatCnpjCPF();
            txtFantasia.Text = cliente.Fantasi.Trim();
            txtEmpresa.Text = cliente.Empresa.Trim();
            txtCodEmpresa.Text = cliente.Cod_Empresa;
            txtLocal.Text = cliente.Local.Trim();
            txtCadastro.Text = cliente.Cadastr.ToString("dd/MM/yyyy");
            txtEndereco.Text = cliente.Enderecof.Trim();
            txtCidade.Text = cliente.Cidadef.Trim();
            txtBairro.Text = cliente.Bairrof.Trim();
            txtCep.Text = cliente.Cepf.Trim();
            cbUFF.SelectedIndex = index;
            txtTel.Text = cliente.Telf;
            txtCel.Text = cliente.Celf;
            txtEmail.Text = cliente.Emailf.Trim();
            txtObs.Text = cliente.Obs.Trim();




        }


        //Formulario

        private void PopularCliente()
        {

            cliente.Codigo = txtCodigo.Text.IntParse();
            cliente.Razao = txtRazao.Text;
            cliente.Cnpj_Cpf = txtCnpjCpf.Text;
            cliente.Cadastr = Convert.ToDateTime(txtCadastro.Text).Date;
            cliente.Fantasi = txtFantasia.Text;
            cliente.Empresa = txtEmpresa.Text;
            cliente.Cod_Empresa = txtCodEmpresa.Text;
            cliente.Local = txtLocal.Text;
            cliente.Enderecof = txtEndereco.Text;
            cliente.Cidadef = txtCidade.Text;
            cliente.Bairrof = txtBairro.Text;
            cliente.Cepf = txtCep.Text;
            cliente.Uff = cbUFF.Items[cbUFF.SelectedIndex].ToString().Substring(0, 2);//txtEstado.Text;
            cliente.Telf = txtTel.Text;
            cliente.Celf = txtCel.Text;
            cliente.Emailf = txtEmail.Text;
            cliente.Obs = txtObs.Text;


        }

        public void setProperties(bool value)
        {

            txtCodigo.Enabled = false;
            txtRazao.Enabled = value;
            txtCadastro.Enabled = false;
            txtCnpjCpf.Enabled = value;
            txtFantasia.Enabled = value;
            txtEmpresa.Enabled = value;
            txtCodEmpresa.Enabled = value;
            txtLocal.Enabled = value;
            txtEndereco.Enabled = value;
            txtCep.Enabled = value;
            pbCepF.Enabled = value;
            txtCidade.Enabled = value;
            cbUFF.Enabled = value;
            txtBairro.Enabled = value;
            txtTel.Enabled = value;
            txtCel.Enabled = value;
            txtEmail.Enabled = value;
            txtObs.Enabled = value;

            txtRazao.CharacterCasing = CharacterCasing.Upper;
            txtFantasia.CharacterCasing = CharacterCasing.Upper;
            txtEndereco.CharacterCasing = CharacterCasing.Upper;
            txtCidade.CharacterCasing = CharacterCasing.Upper;
            txtBairro.CharacterCasing = CharacterCasing.Upper;
            txtObs.CharacterCasing = CharacterCasing.Upper;

            txtRazao.MaxLength = 40;
            txtFantasia.MaxLength = 20;
            txtEndereco.MaxLength = 80;
            txtCidade.MaxLength = 40;
            txtBairro.MaxLength = 40;
            txtObs.MaxLength = 200;



        }

        private void TxtCnpjCpf_Enter(object sender, EventArgs e)
        {

            txtCnpjCpf.Mask = "";

            txtCnpjCpf.Text = txtCnpjCpf.Text.LimpaCnpjCpf();

        }

        private void TxtCnpjCpf_Leave(object sender, EventArgs e)
        {
            string texto = txtCnpjCpf.Text;

            texto = texto.Trim();

            if (texto.Length == 11 || texto.Length == 14)
            {
                if (texto.Length == 11)
                {

                    if (!texto.IsCnpjCpf())
                    {
                        MessageBox.Show("CPF Inválido !!");
                    }

                    txtCnpjCpf.Mask = "999.999.999-99";

                }
                else
                {
                    if (!texto.IsCnpjCpf())
                    {
                        MessageBox.Show("CNPJ Inválido !!");
                    }

                    txtCnpjCpf.Mask = "99.999.999/9999-99";

                }


            }
            else
            {

                txtCnpjCpf.Mask = "";

            }

        }

        private void BtBuscar_Click(object sender, EventArgs e)
        {
            loadClientes();
        }

        private void CbPesquisar_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ordenacao = cbPesquisar.SelectedIndex;

            edPesquisar.Text = "";

            loadClientes();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

            try
            {

                this.Cursor = Cursors.WaitCursor;

                if (txtCep.Text.Trim() == "")
                {
                    MessageBox.Show("O Campo CEP Está Vazio!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    
                    CorreiosApi correiosApi = new CorreiosApi();

                    var cep = correiosApi.consultaCEP(txtCep.Text.Trim());

                    if (cep.cep == txtCep.Text.Trim())
                    {
                        txtEndereco.Text = cep.end;
                        txtBairro.Text = cep.bairro;
                        txtCidade.Text = cep.cidade;

                        int index = 0;
                        foreach (string estado in cbUFF.Items)
                        {
                            if (cep.uf == estado.Substring(0, 2))
                            {
                                break;
                            }

                            index++;
                        }

                        if (index < cbUFF.Items.Count)
                        {
                            cbUFF.SelectedIndex = index;
                        }

                    }
                    else
                    {

                        MessageBox.Show("CEP Não Encontrado !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                    
                }
                   
            }
            catch (Exception exp)
            {
                MessageBox.Show("Falha Na Pesquisa !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void EdPesquisar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btBuscar.PerformClick();
            }
        }

        private void FormClientes_Activated(object sender, EventArgs e)
        {
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void cbPesquisar_Click(object sender, EventArgs e)
        {

        }

        private void lblCodProtheus_Click(object sender, EventArgs e)
        {

        }

    }
}
