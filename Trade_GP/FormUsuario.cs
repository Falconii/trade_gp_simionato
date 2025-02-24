using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Correios;
using Npgsql;
using Trade_GP.Dao.postgre;
using Trade_GP.DataBase;
using Trade_GP.Extensoes;
using Trade_GP.Models;
using Trade_GP.Models.Validacoes;

using static Trade_GP.FormPrincipal;

namespace Trade_GP
{
    public partial class FormUsuario : Form
    {
         Visoes visao = Visoes.Browser;

        Usuario usuario = new Usuario();

        int Ordenacao = 2; //Razao Social 

        int Codigo = 0;
        public ToolStripMenuItem menu { get; internal set; }
        public FormUsuario()
        {
            InitializeComponent();

            cbUF.Items.Clear();

            Object[] ItemObject = new Object[FormPrincipal.estados.Count];

            for (int i = 0; i < FormPrincipal.estados.Count; i++)
            {
                ItemObject[i] = FormPrincipal.estados[i].Uf;
            }

            cbUF.Items.AddRange(ItemObject);

            cbPesquisar.SelectedIndex = Ordenacao;
        }

        private void FormUsuario_Load(object sender, EventArgs e)
        {
            SetarVisoes();
            loadUsuario();
        }

        private void SetarProperties(bool value)
        {
            txtCodigo.Enabled = false;
            txtRazao.Enabled = value;
            txtCadastro.Enabled = value;
            txtCnpjCpf.Enabled = value;
            txtEndereco.Enabled = value;
            txtCep.Enabled = value;
            txtCidade.Enabled = value;
            cbUF.Enabled = value;
            pbCepF.Enabled = value;
            txtBairro.Enabled = value;
            txtTel1.Enabled = value;
            txtTel2.Enabled = value;
            txtEmail.Enabled = value;
            txtPasta.Enabled = value;
            txtSenha.Enabled = value;


            txtRazao.CharacterCasing = CharacterCasing.Upper;
            txtEndereco.CharacterCasing = CharacterCasing.Upper;
            txtCidade.CharacterCasing = CharacterCasing.Upper;
            txtBairro.CharacterCasing = CharacterCasing.Upper;


            txtRazao.MaxLength = 40;
            txtEndereco.MaxLength = 40;
            txtCidade.MaxLength = 40;
            txtBairro.MaxLength = 40;
            txtEmail.MaxLength = 100;
            txtPasta.MaxLength = 255;
            txtSenha.MaxLength = 10;
        }

        private void loadUsuario()
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

                    daoUsuario dao = new daoUsuario();

                    usuario = dao.Seek(Codigo);

                    if (usuario == null)
                    {

                        usuario = new Usuario();

                        usuario.Zerar();

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

            usuario = new Usuario();

            usuario.Zerar();

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

                    daoUsuario dao = new daoUsuario();

                    dao.Delete(usuario);

                    loadUsuario();

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

                PopularUsuario();

                string Erros = Validacao();

                if (Erros != "")
                {

                    MessageBox.Show(Erros);

                    return;

                }

                daoUsuario dao = new daoUsuario();


                switch (visao)
                {

                    case Visoes.Nova:

                        Usuario retorno = dao.Insert(usuario);

                        if (retorno != null)
                        {

                            MessageBox.Show($"USUÁRIO Incluído No Código {retorno.Codigo}", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {

                            MessageBox.Show($"Falha Na Inclusão Do USUÁRIO!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);


                        }

                        visao = Visoes.Browser;

                        loadUsuario();

                        SetarVisoes();

                        break;

                    case Visoes.Edicao:

                        dao.Update(usuario);

                        MessageBox.Show($"USUÁRIO Alterado Com Sucesso!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        visao = Visoes.Browser;

                        loadUsuario();

                        SetarVisoes();

                        break;

                }
            }
            catch (Exception exc)
            {

                MessageBox.Show("Falha No Procedimento\n" + exc.Message);

            }


        }

        private void CbPesquisar_Click(object sender, EventArgs e)
        {



        }

        private void TbCancelar_Click(object sender, EventArgs e)
        {
            visao = Visoes.Browser;

            SetarVisoes();
        }

        private void CbPesquisar_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ordenacao = cbPesquisar.SelectedIndex;

            edPesquisar.Text = "";

            loadUsuario();
        }

        private void BtBuscar_Click(object sender, EventArgs e)
        {
            loadUsuario();
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

            visao = Visoes.Consulta;

            daoUsuario dao = new daoUsuario();

            usuario = dao.Seek(Codigo);

            if (usuario == null)
            {

                usuario = new Usuario();

                usuario.Zerar();

                visao = Visoes.Nova;

            }

            Atualiza();

            SetarVisoes();

        }

        private void ConfiguraDbDridView()
        {



            dbGridView.AutoResizeColumns();
            dbGridView.Columns[00].HeaderText = "CÓDIGO";
            dbGridView.Columns[00].Width = 80;
            dbGridView.Columns[00].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dbGridView.Columns[01].HeaderText = "CNPJ/CPF";
            dbGridView.Columns[01].Width = 120;
            dbGridView.Columns[01].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dbGridView.Columns[02].HeaderText = "RAZÃO SOCIAL";
            dbGridView.Columns[02].Width = 300;
            dbGridView.Columns[02].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dbGridView.Columns[03].HeaderText = "CADASTRO";
            dbGridView.Columns[03].Width = 120;
            dbGridView.Columns[03].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dbGridView.Columns[04].HeaderText = "ENDEREÇO";
            dbGridView.Columns[04].Width = 300;
            dbGridView.Columns[04].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dbGridView.Columns[05].HeaderText = "BAIRRO";
            dbGridView.Columns[05].Width = 200;
            dbGridView.Columns[05].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dbGridView.Columns[06].HeaderText = "CIDADE";
            dbGridView.Columns[06].Width = 300;
            dbGridView.Columns[06].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dbGridView.Columns[07].HeaderText = "EST.";
            dbGridView.Columns[07].Width = 40;
            dbGridView.Columns[07].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            dbGridView.Columns[08].HeaderText = "CEP";
            dbGridView.Columns[08].Width = 200;
            dbGridView.Columns[08].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dbGridView.Columns[09].HeaderText = "TEL 01";
            dbGridView.Columns[09].Width = 200;
            dbGridView.Columns[09].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dbGridView.Columns[10].HeaderText = "TEL 02";
            dbGridView.Columns[10].Width = 300;
            dbGridView.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dbGridView.Columns[11].HeaderText = "EMAIL";
            dbGridView.Columns[02].Width = 300;
            dbGridView.Columns[02].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;


            dbGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dbGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dbGridView.BorderStyle = BorderStyle.Fixed3D;
            dbGridView.EnableHeadersVisualStyles = false;







        }

        public void preencheDataGridView()
        {
            //faz a conexão
            var conn = new NpgsqlConnection(RunCommand.connectionString);

            try //inicio do tratamento de exceções 
            {

                daoUsuario dao = new daoUsuario();

                string strSelect = dao.SqlGridBrowse(Ordenacao, edPesquisar.Text.Trim());

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

            if (!usuario.Cnpj_Cpf.LimpaCnpjCpf().IsCnpjCpf())
            {

                Result += "CNPJ Ou CPF Inválidos !!\n";

            }

            if (!Validacoes.IsTamanho(usuario.Razao, 1, 40))
            {
                Result += "Tamanho do Campo Razão Deve Ficar Entre 1 e 40 !\n";
            }

            if (!Validacoes.IsTamanho(usuario.Senha, 4, 10))
            {
                Result += "Tamanho do Campo Senha Deve Ficar Entre 4 e 10 !\n";
            }

            if (!Validacoes.IsTamanho(usuario.Endereco, 0, 40))
            {
                Result += "Tamanho do Campo Endereço Deve Ficar Entre 0 e 40 !\n";
            }
            if (!Validacoes.IsTamanho(usuario.Bairro, 0, 40))
            {
                Result += "Tamanho do Campo Bairro Deve Ficar Entre 0 e 40 !\n";
            }
            if (!Validacoes.IsTamanho(usuario.Cidade, 0, 40))
            {
                Result += "Tamanho do Campo Cidade Deve Ficar Entre 1 e 40 !\n";
            }
            if (!Validacoes.IsTamanho(usuario.Uf.Substring(0, 2), 2, 2))
            {
                Result += "Tamanho do Campo Estado Deve Ter 2 Caracteres !\n";
            }
            if (!Validacoes.IsTamanho(usuario.Cep, 0, 8))
            {
                Result += "Tamanho do Campo CEP Deve Ter De 0 a 8 Digitos !";
            }

            return Result;

        }

        private void Atualiza()
        {

            int index = 0;

            foreach (var obj in cbUF.Items)
            {

                if (usuario.Uf == obj.ToString().Substring(0, 2))
                {

                    break;

                }

                index++;

            }

            index = index >= 27 ? 24 : index;

            txtCodigo.Text = usuario.Codigo.IntNovo();
            txtRazao.Text = usuario.Razao.Trim();
            txtCnpjCpf.Mask = "";
            txtCnpjCpf.Text = usuario.Cnpj_Cpf.FormatCnpjCPF();
            txtCadastro.Text = usuario.Cadastr.ToString("dd/MM/yyyy");
            txtEndereco.Text = usuario.Endereco.Trim();
            txtCidade.Text = usuario.Cidade.Trim();
            txtBairro.Text = usuario.Bairro.Trim();
            txtCep.Text = usuario.Cep;
            cbUF.SelectedIndex = index;
            txtTel1.Text = usuario.Tel1;
            txtTel2.Text = usuario.Tel2;
            txtEmail.Text = usuario.Email.Trim();
            txtPasta.Text = usuario.Pasta.Trim();
            txtSenha.Text = usuario.Senha.Trim();

        }


        //Formulario

        private void PopularUsuario()
        {

            usuario.Codigo = txtCodigo.Text.IntParse();
            usuario.Razao = txtRazao.Text;
            usuario.Cnpj_Cpf = txtCnpjCpf.Text.LimpaCnpjCpf();
            usuario.Cadastr = Convert.ToDateTime(txtCadastro.Text).Date;
            usuario.Endereco = txtEndereco.Text;
            usuario.Cidade = txtCidade.Text;
            usuario.Bairro = txtBairro.Text;
            usuario.Cep = txtCep.Text;
            usuario.Uf = cbUF.Items[cbUF.SelectedIndex].ToString().Substring(0, 2);//txtEstado.Text;
            usuario.Tel1 = txtTel1.Text;
            usuario.Tel2 = txtTel2.Text;
            usuario.Email = txtEmail.Text;
            usuario.Pasta = txtPasta.Text;
            usuario.Senha = txtSenha.Text;

        }

        private void TxtCnpj_CpfCpf_Enter(object sender, EventArgs e)
        {

            txtCnpjCpf.Mask = "";

            txtCnpjCpf.Text = txtCnpjCpf.Text.LimpaCnpjCpf();

        }

        private void TxtCnpj_CpfCpf_Leave(object sender, EventArgs e)
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
                    SetarBotoes();
                    break;
                case Visoes.Nova:
                    tabControl.Visible = true;
                    dbGridView.ReadOnly = true;
                    dbGridView.Visible = false;
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

            loadUsuario();
        }

        private void PbCepF_Click(object sender, EventArgs e)
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
                        foreach (string estado in cbUF.Items)
                        {
                            if (cep.uf == estado.Substring(0, 2))
                            {
                                break;
                            }

                            index++;
                        }

                        if (index < cbUF.Items.Count)
                        {
                            cbUF.SelectedIndex = index;
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


        private void FormUsuario_Activated(object sender, EventArgs e)
        {
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void FormUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            menu.Enabled = true;
        }

        private void dbGridView_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            visao = Visoes.Consulta;

            daoUsuario dao = new daoUsuario();

            usuario = dao.Seek(Codigo);

            if (usuario == null)
            {

                usuario = new Usuario();

                usuario.Zerar();

                visao = Visoes.Nova;

            }

            Atualiza();

            SetarVisoes();

        }

        private void dbGridView_RowEnter_1(object sender, DataGridViewCellEventArgs e)
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
    }
}
