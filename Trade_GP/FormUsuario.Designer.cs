
namespace Trade_GP
{
    partial class FormUsuario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

       #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUsuario));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbBrowser = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lbPesquisar = new System.Windows.Forms.ToolStripLabel();
            this.cbPesquisar = new System.Windows.Forms.ToolStripComboBox();
            this.edPesquisar = new System.Windows.Forms.ToolStripTextBox();
            this.btBuscar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbIncluir = new System.Windows.Forms.ToolStripButton();
            this.tbEditar = new System.Windows.Forms.ToolStripButton();
            this.tbDelete = new System.Windows.Forms.ToolStripButton();
            this.tbOk = new System.Windows.Forms.ToolStripButton();
            this.tbCancelar = new System.Windows.Forms.ToolStripButton();
            this.dbGridView = new System.Windows.Forms.DataGridView();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPrincipal = new System.Windows.Forms.TabPage();
            this.gbOutros = new System.Windows.Forms.GroupBox();
            this.txtSenha = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPasta = new System.Windows.Forms.TextBox();
            this.lblPasta = new System.Windows.Forms.Label();
            this.gbComunicacao = new System.Windows.Forms.GroupBox();
            this.txtTel2 = new System.Windows.Forms.MaskedTextBox();
            this.txtTel1 = new System.Windows.Forms.MaskedTextBox();
            this.lblTel2 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblTel1 = new System.Windows.Forms.Label();
            this.gbEndereco = new System.Windows.Forms.GroupBox();
            this.pbCepF = new System.Windows.Forms.PictureBox();
            this.txtCep = new System.Windows.Forms.MaskedTextBox();
            this.cbUF = new System.Windows.Forms.ComboBox();
            this.lblCEP = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.txtCidade = new System.Windows.Forms.TextBox();
            this.lblCidade = new System.Windows.Forms.Label();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.lblBairro = new System.Windows.Forms.Label();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.lblEndereco = new System.Windows.Forms.Label();
            this.gbIdentificacao = new System.Windows.Forms.GroupBox();
            this.txtCnpjCpf = new System.Windows.Forms.MaskedTextBox();
            this.txtCadastro = new System.Windows.Forms.TextBox();
            this.lblCadastro = new System.Windows.Forms.Label();
            this.txtRazao = new System.Windows.Forms.TextBox();
            this.lblRazao = new System.Windows.Forms.Label();
            this.lbl_CNPJCPF = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbGridView)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPrincipal.SuspendLayout();
            this.gbOutros.SuspendLayout();
            this.gbComunicacao.SuspendLayout();
            this.gbEndereco.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCepF)).BeginInit();
            this.gbIdentificacao.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbBrowser,
            this.toolStripSeparator1,
            this.lbPesquisar,
            this.cbPesquisar,
            this.edPesquisar,
            this.btBuscar,
            this.toolStripSeparator2,
            this.tbIncluir,
            this.tbEditar,
            this.tbDelete,
            this.tbOk,
            this.tbCancelar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1007, 39);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "TooBar";
            // 
            // tbBrowser
            // 
            this.tbBrowser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbBrowser.Image = ((System.Drawing.Image)(resources.GetObject("tbBrowser.Image")));
            this.tbBrowser.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbBrowser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbBrowser.Name = "tbBrowser";
            this.tbBrowser.Size = new System.Drawing.Size(34, 36);
            this.tbBrowser.ToolTipText = "Click Para Alternar As Visões de Browser e Consulta";
            this.tbBrowser.Click += new System.EventHandler(this.TbBrowser_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AutoSize = false;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(100, 39);
            // 
            // lbPesquisar
            // 
            this.lbPesquisar.Name = "lbPesquisar";
            this.lbPesquisar.Size = new System.Drawing.Size(53, 36);
            this.lbPesquisar.Text = "Pesquisa";
            // 
            // cbPesquisar
            // 
            this.cbPesquisar.Items.AddRange(new object[] {
            "CÓDIGO",
            "CNPJ/CPF",
            "RAZÃO SOCIAL"});
            this.cbPesquisar.Name = "cbPesquisar";
            this.cbPesquisar.Size = new System.Drawing.Size(121, 39);
            // 
            // edPesquisar
            // 
            this.edPesquisar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.edPesquisar.Name = "edPesquisar";
            this.edPesquisar.Size = new System.Drawing.Size(250, 39);
            // 
            // btBuscar
            // 
            this.btBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btBuscar.Image")));
            this.btBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(23, 36);
            this.btBuscar.Text = "Click Aqui Para Pesquisar";
            this.btBuscar.Click += new System.EventHandler(this.BtBuscar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.AutoSize = false;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(50, 39);
            // 
            // tbIncluir
            // 
            this.tbIncluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbIncluir.Image = ((System.Drawing.Image)(resources.GetObject("tbIncluir.Image")));
            this.tbIncluir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbIncluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbIncluir.Name = "tbIncluir";
            this.tbIncluir.Size = new System.Drawing.Size(34, 36);
            this.tbIncluir.ToolTipText = "Clicl Aqui Para Incluir Um Usuario  Novo";
            this.tbIncluir.Click += new System.EventHandler(this.TbIncluir_Click);
            // 
            // tbEditar
            // 
            this.tbEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbEditar.Image = ((System.Drawing.Image)(resources.GetObject("tbEditar.Image")));
            this.tbEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbEditar.Name = "tbEditar";
            this.tbEditar.Size = new System.Drawing.Size(34, 36);
            this.tbEditar.ToolTipText = "Click Aqui Para Editar O Usuário";
            this.tbEditar.Click += new System.EventHandler(this.TbEditar_Click);
            // 
            // tbDelete
            // 
            this.tbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tbDelete.Image")));
            this.tbDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbDelete.Name = "tbDelete";
            this.tbDelete.Size = new System.Drawing.Size(34, 36);
            this.tbDelete.ToolTipText = "Click Aqui Para Excluir O Usuário";
            this.tbDelete.Click += new System.EventHandler(this.TbDelete_Click);
            // 
            // tbOk
            // 
            this.tbOk.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbOk.Image = ((System.Drawing.Image)(resources.GetObject("tbOk.Image")));
            this.tbOk.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbOk.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbOk.Name = "tbOk";
            this.tbOk.Size = new System.Drawing.Size(34, 36);
            this.tbOk.ToolTipText = "Click Aqui Para Confirmar";
            this.tbOk.Click += new System.EventHandler(this.TbOk_Click);
            // 
            // tbCancelar
            // 
            this.tbCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbCancelar.Image = ((System.Drawing.Image)(resources.GetObject("tbCancelar.Image")));
            this.tbCancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbCancelar.Name = "tbCancelar";
            this.tbCancelar.Size = new System.Drawing.Size(36, 36);
            this.tbCancelar.ToolTipText = "Click Aqui Para Cancelar";
            this.tbCancelar.Click += new System.EventHandler(this.TbCancelar_Click);
            // 
            // dbGridView
            // 
            this.dbGridView.AllowUserToAddRows = false;
            this.dbGridView.AllowUserToDeleteRows = false;
            this.dbGridView.AllowUserToOrderColumns = true;
            this.dbGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbGridView.Location = new System.Drawing.Point(0, 42);
            this.dbGridView.Margin = new System.Windows.Forms.Padding(5);
            this.dbGridView.Name = "dbGridView";
            this.dbGridView.ReadOnly = true;
            this.dbGridView.Size = new System.Drawing.Size(1007, 621);
            this.dbGridView.TabIndex = 4;
            this.dbGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dbGridView_RowEnter_1);
            this.dbGridView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dbGridView_MouseDoubleClick);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPrincipal);
            this.tabControl.Location = new System.Drawing.Point(10, 42);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1229, 605);
            this.tabControl.TabIndex = 5;
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Controls.Add(this.gbOutros);
            this.tabPrincipal.Controls.Add(this.gbComunicacao);
            this.tabPrincipal.Controls.Add(this.gbEndereco);
            this.tabPrincipal.Controls.Add(this.gbIdentificacao);
            this.tabPrincipal.Location = new System.Drawing.Point(4, 22);
            this.tabPrincipal.Name = "tabPrincipal";
            this.tabPrincipal.Padding = new System.Windows.Forms.Padding(3);
            this.tabPrincipal.Size = new System.Drawing.Size(1221, 579);
            this.tabPrincipal.TabIndex = 1;
            this.tabPrincipal.Text = "Principal";
            this.tabPrincipal.UseVisualStyleBackColor = true;
            // 
            // gbOutros
            // 
            this.gbOutros.Controls.Add(this.txtSenha);
            this.gbOutros.Controls.Add(this.label1);
            this.gbOutros.Controls.Add(this.txtPasta);
            this.gbOutros.Controls.Add(this.lblPasta);
            this.gbOutros.Location = new System.Drawing.Point(37, 448);
            this.gbOutros.Name = "gbOutros";
            this.gbOutros.Size = new System.Drawing.Size(965, 100);
            this.gbOutros.TabIndex = 35;
            this.gbOutros.TabStop = false;
            this.gbOutros.Text = "Outros";
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(408, 60);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.PromptChar = ' ';
            this.txtSenha.Size = new System.Drawing.Size(160, 20);
            this.txtSenha.TabIndex = 35;
            this.txtSenha.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(408, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Senha";
            // 
            // txtPasta
            // 
            this.txtPasta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPasta.Location = new System.Drawing.Point(13, 60);
            this.txtPasta.Name = "txtPasta";
            this.txtPasta.Size = new System.Drawing.Size(352, 20);
            this.txtPasta.TabIndex = 32;
            // 
            // lblPasta
            // 
            this.lblPasta.AutoSize = true;
            this.lblPasta.Location = new System.Drawing.Point(10, 44);
            this.lblPasta.Name = "lblPasta";
            this.lblPasta.Size = new System.Drawing.Size(34, 13);
            this.lblPasta.TabIndex = 27;
            this.lblPasta.Text = "Pasta";
            // 
            // gbComunicacao
            // 
            this.gbComunicacao.Controls.Add(this.txtTel2);
            this.gbComunicacao.Controls.Add(this.txtTel1);
            this.gbComunicacao.Controls.Add(this.lblTel2);
            this.gbComunicacao.Controls.Add(this.txtEmail);
            this.gbComunicacao.Controls.Add(this.lblEmail);
            this.gbComunicacao.Controls.Add(this.lblTel1);
            this.gbComunicacao.Location = new System.Drawing.Point(37, 327);
            this.gbComunicacao.Name = "gbComunicacao";
            this.gbComunicacao.Size = new System.Drawing.Size(965, 100);
            this.gbComunicacao.TabIndex = 23;
            this.gbComunicacao.TabStop = false;
            this.gbComunicacao.Text = "Comunicação";
            // 
            // txtTel2
            // 
            this.txtTel2.Location = new System.Drawing.Point(205, 50);
            this.txtTel2.Mask = "(999) #9999-9999";
            this.txtTel2.Name = "txtTel2";
            this.txtTel2.PromptChar = ' ';
            this.txtTel2.Size = new System.Drawing.Size(160, 20);
            this.txtTel2.TabIndex = 30;
            this.txtTel2.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // txtTel1
            // 
            this.txtTel1.Location = new System.Drawing.Point(13, 50);
            this.txtTel1.Mask = "(999) #9999-9999";
            this.txtTel1.Name = "txtTel1";
            this.txtTel1.PromptChar = ' ';
            this.txtTel1.Size = new System.Drawing.Size(160, 20);
            this.txtTel1.TabIndex = 28;
            this.txtTel1.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // lblTel2
            // 
            this.lblTel2.AutoSize = true;
            this.lblTel2.Location = new System.Drawing.Point(205, 34);
            this.lblTel2.Name = "lblTel2";
            this.lblTel2.Size = new System.Drawing.Size(58, 13);
            this.lblTel2.TabIndex = 31;
            this.lblTel2.Text = "Telefone 2";
            // 
            // txtEmail
            // 
            this.txtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtEmail.Location = new System.Drawing.Point(408, 50);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(352, 20);
            this.txtEmail.TabIndex = 32;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(405, 34);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(36, 13);
            this.lblEmail.TabIndex = 27;
            this.lblEmail.Text = "E-Mail";
            // 
            // lblTel1
            // 
            this.lblTel1.AutoSize = true;
            this.lblTel1.Location = new System.Drawing.Point(10, 34);
            this.lblTel1.Name = "lblTel1";
            this.lblTel1.Size = new System.Drawing.Size(58, 13);
            this.lblTel1.TabIndex = 29;
            this.lblTel1.Text = "Telefone 1";
            // 
            // gbEndereco
            // 
            this.gbEndereco.Controls.Add(this.pbCepF);
            this.gbEndereco.Controls.Add(this.txtCep);
            this.gbEndereco.Controls.Add(this.cbUF);
            this.gbEndereco.Controls.Add(this.lblCEP);
            this.gbEndereco.Controls.Add(this.lblEstado);
            this.gbEndereco.Controls.Add(this.txtCidade);
            this.gbEndereco.Controls.Add(this.lblCidade);
            this.gbEndereco.Controls.Add(this.txtBairro);
            this.gbEndereco.Controls.Add(this.lblBairro);
            this.gbEndereco.Controls.Add(this.txtEndereco);
            this.gbEndereco.Controls.Add(this.lblEndereco);
            this.gbEndereco.Location = new System.Drawing.Point(37, 146);
            this.gbEndereco.Name = "gbEndereco";
            this.gbEndereco.Size = new System.Drawing.Size(965, 154);
            this.gbEndereco.TabIndex = 22;
            this.gbEndereco.TabStop = false;
            this.gbEndereco.Text = "Endereço";
            // 
            // pbCepF
            // 
            this.pbCepF.Location = new System.Drawing.Point(664, 120);
            this.pbCepF.Name = "pbCepF";
            this.pbCepF.Size = new System.Drawing.Size(39, 21);
            this.pbCepF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCepF.TabIndex = 29;
            this.pbCepF.TabStop = false;
            // 
            // txtCep
            // 
            this.txtCep.Location = new System.Drawing.Point(561, 120);
            this.txtCep.Mask = "99999-999";
            this.txtCep.Name = "txtCep";
            this.txtCep.PromptChar = ' ';
            this.txtCep.Size = new System.Drawing.Size(97, 20);
            this.txtCep.TabIndex = 7;
            this.txtCep.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // cbUF
            // 
            this.cbUF.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbUF.FormattingEnabled = true;
            this.cbUF.Location = new System.Drawing.Point(781, 119);
            this.cbUF.Name = "cbUF";
            this.cbUF.Size = new System.Drawing.Size(161, 21);
            this.cbUF.TabIndex = 8;
            this.cbUF.Tag = "23";
            // 
            // lblCEP
            // 
            this.lblCEP.AutoSize = true;
            this.lblCEP.Location = new System.Drawing.Point(558, 103);
            this.lblCEP.Name = "lblCEP";
            this.lblCEP.Size = new System.Drawing.Size(28, 13);
            this.lblCEP.TabIndex = 26;
            this.lblCEP.Text = "CEP";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(778, 103);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(40, 13);
            this.lblEstado.TabIndex = 24;
            this.lblEstado.Text = "Estado";
            // 
            // txtCidade
            // 
            this.txtCidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCidade.Location = new System.Drawing.Point(208, 119);
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Size = new System.Drawing.Size(324, 20);
            this.txtCidade.TabIndex = 6;
            // 
            // lblCidade
            // 
            this.lblCidade.AutoSize = true;
            this.lblCidade.Location = new System.Drawing.Point(205, 103);
            this.lblCidade.Name = "lblCidade";
            this.lblCidade.Size = new System.Drawing.Size(40, 13);
            this.lblCidade.TabIndex = 22;
            this.lblCidade.Text = "Cidade";
            // 
            // txtBairro
            // 
            this.txtBairro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBairro.Location = new System.Drawing.Point(13, 119);
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(161, 20);
            this.txtBairro.TabIndex = 5;
            // 
            // lblBairro
            // 
            this.lblBairro.AutoSize = true;
            this.lblBairro.Location = new System.Drawing.Point(10, 103);
            this.lblBairro.Name = "lblBairro";
            this.lblBairro.Size = new System.Drawing.Size(34, 13);
            this.lblBairro.TabIndex = 20;
            this.lblBairro.Text = "Bairro";
            // 
            // txtEndereco
            // 
            this.txtEndereco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEndereco.Location = new System.Drawing.Point(13, 46);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(747, 20);
            this.txtEndereco.TabIndex = 4;
            // 
            // lblEndereco
            // 
            this.lblEndereco.AutoSize = true;
            this.lblEndereco.Location = new System.Drawing.Point(10, 30);
            this.lblEndereco.Name = "lblEndereco";
            this.lblEndereco.Size = new System.Drawing.Size(49, 13);
            this.lblEndereco.TabIndex = 18;
            this.lblEndereco.Text = "Rua, Av.";
            // 
            // gbIdentificacao
            // 
            this.gbIdentificacao.Controls.Add(this.txtCnpjCpf);
            this.gbIdentificacao.Controls.Add(this.txtCadastro);
            this.gbIdentificacao.Controls.Add(this.lblCadastro);
            this.gbIdentificacao.Controls.Add(this.txtRazao);
            this.gbIdentificacao.Controls.Add(this.lblRazao);
            this.gbIdentificacao.Controls.Add(this.lbl_CNPJCPF);
            this.gbIdentificacao.Controls.Add(this.txtCodigo);
            this.gbIdentificacao.Controls.Add(this.lblCodigo);
            this.gbIdentificacao.Location = new System.Drawing.Point(37, 30);
            this.gbIdentificacao.Name = "gbIdentificacao";
            this.gbIdentificacao.Size = new System.Drawing.Size(965, 100);
            this.gbIdentificacao.TabIndex = 1;
            this.gbIdentificacao.TabStop = false;
            this.gbIdentificacao.Text = "Identificação";
            // 
            // txtCnpjCpf
            // 
            this.txtCnpjCpf.Location = new System.Drawing.Point(141, 47);
            this.txtCnpjCpf.Name = "txtCnpjCpf";
            this.txtCnpjCpf.PromptChar = ' ';
            this.txtCnpjCpf.Size = new System.Drawing.Size(164, 20);
            this.txtCnpjCpf.TabIndex = 1;
            this.txtCnpjCpf.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtCnpjCpf.Enter += new System.EventHandler(this.TxtCnpj_CpfCpf_Enter);
            this.txtCnpjCpf.Leave += new System.EventHandler(this.TxtCnpj_CpfCpf_Leave);
            // 
            // txtCadastro
            // 
            this.txtCadastro.Location = new System.Drawing.Point(781, 47);
            this.txtCadastro.Name = "txtCadastro";
            this.txtCadastro.Size = new System.Drawing.Size(161, 20);
            this.txtCadastro.TabIndex = 3;
            // 
            // lblCadastro
            // 
            this.lblCadastro.AutoSize = true;
            this.lblCadastro.Location = new System.Drawing.Point(778, 31);
            this.lblCadastro.Name = "lblCadastro";
            this.lblCadastro.Size = new System.Drawing.Size(92, 13);
            this.lblCadastro.TabIndex = 14;
            this.lblCadastro.Text = "Data Do Cadastro";
            // 
            // txtRazao
            // 
            this.txtRazao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRazao.Location = new System.Drawing.Point(331, 48);
            this.txtRazao.Name = "txtRazao";
            this.txtRazao.Size = new System.Drawing.Size(429, 20);
            this.txtRazao.TabIndex = 2;
            // 
            // lblRazao
            // 
            this.lblRazao.AutoSize = true;
            this.lblRazao.Location = new System.Drawing.Point(328, 31);
            this.lblRazao.Name = "lblRazao";
            this.lblRazao.Size = new System.Drawing.Size(70, 13);
            this.lblRazao.TabIndex = 12;
            this.lblRazao.Text = "Razão Social";
            // 
            // lbl_CNPJCPF
            // 
            this.lbl_CNPJCPF.AutoSize = true;
            this.lbl_CNPJCPF.Location = new System.Drawing.Point(138, 31);
            this.lbl_CNPJCPF.Name = "lbl_CNPJCPF";
            this.lbl_CNPJCPF.Size = new System.Drawing.Size(59, 13);
            this.lbl_CNPJCPF.TabIndex = 10;
            this.lbl_CNPJCPF.Text = "CNPJ/CPF";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(13, 48);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(100, 20);
            this.txtCodigo.TabIndex = 0;
            this.txtCodigo.TabStop = false;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(10, 32);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(40, 13);
            this.lblCodigo.TabIndex = 8;
            this.lblCodigo.Text = "Codigo";
            // 
            // FormUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 663);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.dbGridView);
            this.Name = "FormUsuario";
            this.Text = "FormUsuario";
            this.Activated += new System.EventHandler(this.FormUsuario_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormUsuario_FormClosed);
            this.Load += new System.EventHandler(this.FormUsuario_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbGridView)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPrincipal.ResumeLayout(false);
            this.gbOutros.ResumeLayout(false);
            this.gbOutros.PerformLayout();
            this.gbComunicacao.ResumeLayout(false);
            this.gbComunicacao.PerformLayout();
            this.gbEndereco.ResumeLayout(false);
            this.gbEndereco.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCepF)).EndInit();
            this.gbIdentificacao.ResumeLayout(false);
            this.gbIdentificacao.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tbBrowser;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel lbPesquisar;
        private System.Windows.Forms.ToolStripComboBox cbPesquisar;
        private System.Windows.Forms.ToolStripTextBox edPesquisar;
        private System.Windows.Forms.ToolStripButton btBuscar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tbIncluir;
        private System.Windows.Forms.ToolStripButton tbEditar;
        private System.Windows.Forms.ToolStripButton tbDelete;
        private System.Windows.Forms.ToolStripButton tbOk;
        private System.Windows.Forms.ToolStripButton tbCancelar;
        private System.Windows.Forms.DataGridView dbGridView;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPrincipal;
        private System.Windows.Forms.GroupBox gbComunicacao;
        private System.Windows.Forms.MaskedTextBox txtTel2;
        private System.Windows.Forms.MaskedTextBox txtTel1;
        private System.Windows.Forms.Label lblTel2;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblTel1;
        private System.Windows.Forms.GroupBox gbEndereco;
        private System.Windows.Forms.PictureBox pbCepF;
        private System.Windows.Forms.MaskedTextBox txtCep;
        private System.Windows.Forms.ComboBox cbUF;
        private System.Windows.Forms.Label lblCEP;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.TextBox txtCidade;
        private System.Windows.Forms.Label lblCidade;
        private System.Windows.Forms.TextBox txtBairro;
        private System.Windows.Forms.Label lblBairro;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.Label lblEndereco;
        private System.Windows.Forms.GroupBox gbIdentificacao;
        private System.Windows.Forms.MaskedTextBox txtCnpjCpf;
        private System.Windows.Forms.TextBox txtCadastro;
        private System.Windows.Forms.Label lblCadastro;
        private System.Windows.Forms.TextBox txtRazao;
        private System.Windows.Forms.Label lblRazao;
        private System.Windows.Forms.Label lbl_CNPJCPF;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.GroupBox gbOutros;
        private System.Windows.Forms.MaskedTextBox txtSenha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPasta;
        private System.Windows.Forms.Label lblPasta;
    }
}