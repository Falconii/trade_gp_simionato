
namespace Trade_GP
{
    partial class FormCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCliente));
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
            this.tabCliente = new System.Windows.Forms.TabControl();
            this.tabPrincipal = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtObs = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.gbTelefones = new System.Windows.Forms.GroupBox();
            this.txtCel = new System.Windows.Forms.MaskedTextBox();
            this.txtTel = new System.Windows.Forms.MaskedTextBox();
            this.lblTel2 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblTel1 = new System.Windows.Forms.Label();
            this.gbEndereco = new System.Windows.Forms.GroupBox();
            this.pbCepF = new System.Windows.Forms.PictureBox();
            this.txtCep = new System.Windows.Forms.MaskedTextBox();
            this.cbUFF = new System.Windows.Forms.ComboBox();
            this.lblCEP = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.txtCidade = new System.Windows.Forms.TextBox();
            this.lblCidade = new System.Windows.Forms.Label();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.lblBairro = new System.Windows.Forms.Label();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.lblEndereco = new System.Windows.Forms.Label();
            this.gbIdentificacao = new System.Windows.Forms.GroupBox();
            this.txtLocal = new System.Windows.Forms.TextBox();
            this.lblLocal = new System.Windows.Forms.Label();
            this.txtCodEmpresa = new System.Windows.Forms.TextBox();
            this.lblCodEmpresa = new System.Windows.Forms.Label();
            this.txtEmpresa = new System.Windows.Forms.TextBox();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.txtFantasia = new System.Windows.Forms.TextBox();
            this.lblFantasia = new System.Windows.Forms.Label();
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
            this.tabCliente.SuspendLayout();
            this.tabPrincipal.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.gbTelefones.SuspendLayout();
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
            this.toolStrip1.Size = new System.Drawing.Size(1003, 39);
            this.toolStrip1.TabIndex = 4;
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
            this.cbPesquisar.SelectedIndexChanged += new System.EventHandler(this.CbPesquisar_SelectedIndexChanged);
            this.cbPesquisar.Click += new System.EventHandler(this.cbPesquisar_Click);
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
            this.dbGridView.Location = new System.Drawing.Point(0, 44);
            this.dbGridView.Margin = new System.Windows.Forms.Padding(5);
            this.dbGridView.Name = "dbGridView";
            this.dbGridView.ReadOnly = true;
            this.dbGridView.Size = new System.Drawing.Size(1003, 690);
            this.dbGridView.TabIndex = 5;
            this.dbGridView.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DbGridView_RowEnter);
            this.dbGridView.DoubleClick += new System.EventHandler(this.DbGridView_DoubleClick);
            // 
            // tabCliente
            // 
            this.tabCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabCliente.Controls.Add(this.tabPrincipal);
            this.tabCliente.Location = new System.Drawing.Point(0, 44);
            this.tabCliente.Name = "tabCliente";
            this.tabCliente.SelectedIndex = 0;
            this.tabCliente.Size = new System.Drawing.Size(1003, 690);
            this.tabCliente.TabIndex = 6;
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Controls.Add(this.groupBox7);
            this.tabPrincipal.Controls.Add(this.gbTelefones);
            this.tabPrincipal.Controls.Add(this.gbEndereco);
            this.tabPrincipal.Controls.Add(this.gbIdentificacao);
            this.tabPrincipal.Location = new System.Drawing.Point(4, 22);
            this.tabPrincipal.Name = "tabPrincipal";
            this.tabPrincipal.Padding = new System.Windows.Forms.Padding(3);
            this.tabPrincipal.Size = new System.Drawing.Size(995, 664);
            this.tabPrincipal.TabIndex = 1;
            this.tabPrincipal.Text = "Principal";
            this.tabPrincipal.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txtObs);
            this.groupBox7.Controls.Add(this.label26);
            this.groupBox7.Location = new System.Drawing.Point(37, 466);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(965, 89);
            this.groupBox7.TabIndex = 27;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Observação";
            // 
            // txtObs
            // 
            this.txtObs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtObs.Location = new System.Drawing.Point(13, 51);
            this.txtObs.Name = "txtObs";
            this.txtObs.Size = new System.Drawing.Size(495, 20);
            this.txtObs.TabIndex = 18;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(10, 35);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(65, 13);
            this.label26.TabIndex = 22;
            this.label26.Text = "Observação";
            // 
            // gbTelefones
            // 
            this.gbTelefones.Controls.Add(this.txtCel);
            this.gbTelefones.Controls.Add(this.txtTel);
            this.gbTelefones.Controls.Add(this.lblTel2);
            this.gbTelefones.Controls.Add(this.txtEmail);
            this.gbTelefones.Controls.Add(this.lblEmail);
            this.gbTelefones.Controls.Add(this.lblTel1);
            this.gbTelefones.Location = new System.Drawing.Point(37, 346);
            this.gbTelefones.Name = "gbTelefones";
            this.gbTelefones.Size = new System.Drawing.Size(965, 100);
            this.gbTelefones.TabIndex = 23;
            this.gbTelefones.TabStop = false;
            this.gbTelefones.Text = "Telefones";
            // 
            // txtCel
            // 
            this.txtCel.Location = new System.Drawing.Point(205, 47);
            this.txtCel.Mask = "(99)#9999-9999";
            this.txtCel.Name = "txtCel";
            this.txtCel.PromptChar = ' ';
            this.txtCel.Size = new System.Drawing.Size(160, 20);
            this.txtCel.TabIndex = 16;
            this.txtCel.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(13, 47);
            this.txtTel.Mask = "(99)#9999-9999";
            this.txtTel.Name = "txtTel";
            this.txtTel.PromptChar = ' ';
            this.txtTel.Size = new System.Drawing.Size(160, 20);
            this.txtTel.TabIndex = 15;
            this.txtTel.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // lblTel2
            // 
            this.lblTel2.AutoSize = true;
            this.lblTel2.Location = new System.Drawing.Point(205, 31);
            this.lblTel2.Name = "lblTel2";
            this.lblTel2.Size = new System.Drawing.Size(22, 13);
            this.lblTel2.TabIndex = 26;
            this.lblTel2.Text = "Cel";
            // 
            // txtEmail
            // 
            this.txtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtEmail.Location = new System.Drawing.Point(408, 47);
            this.txtEmail.MaxLength = 100;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(495, 20);
            this.txtEmail.TabIndex = 17;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(405, 31);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(36, 13);
            this.lblEmail.TabIndex = 22;
            this.lblEmail.Text = "E-Mail";
            // 
            // lblTel1
            // 
            this.lblTel1.AutoSize = true;
            this.lblTel1.Location = new System.Drawing.Point(10, 31);
            this.lblTel1.Name = "lblTel1";
            this.lblTel1.Size = new System.Drawing.Size(49, 13);
            this.lblTel1.TabIndex = 24;
            this.lblTel1.Text = "Telefone";
            // 
            // gbEndereco
            // 
            this.gbEndereco.Controls.Add(this.pbCepF);
            this.gbEndereco.Controls.Add(this.txtCep);
            this.gbEndereco.Controls.Add(this.cbUFF);
            this.gbEndereco.Controls.Add(this.lblCEP);
            this.gbEndereco.Controls.Add(this.lblEstado);
            this.gbEndereco.Controls.Add(this.txtCidade);
            this.gbEndereco.Controls.Add(this.lblCidade);
            this.gbEndereco.Controls.Add(this.txtBairro);
            this.gbEndereco.Controls.Add(this.lblBairro);
            this.gbEndereco.Controls.Add(this.txtEndereco);
            this.gbEndereco.Controls.Add(this.lblEndereco);
            this.gbEndereco.Location = new System.Drawing.Point(37, 170);
            this.gbEndereco.Name = "gbEndereco";
            this.gbEndereco.Size = new System.Drawing.Size(965, 154);
            this.gbEndereco.TabIndex = 9;
            this.gbEndereco.TabStop = false;
            this.gbEndereco.Text = "Endereço Faturamento";
            // 
            // pbCepF
            // 
            this.pbCepF.Image = ((System.Drawing.Image)(resources.GetObject("pbCepF.Image")));
            this.pbCepF.Location = new System.Drawing.Point(620, 119);
            this.pbCepF.Name = "pbCepF";
            this.pbCepF.Size = new System.Drawing.Size(39, 21);
            this.pbCepF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCepF.TabIndex = 28;
            this.pbCepF.TabStop = false;
            this.pbCepF.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // txtCep
            // 
            this.txtCep.Location = new System.Drawing.Point(517, 119);
            this.txtCep.Mask = "99999-999";
            this.txtCep.Name = "txtCep";
            this.txtCep.PromptChar = ' ';
            this.txtCep.Size = new System.Drawing.Size(97, 20);
            this.txtCep.TabIndex = 13;
            this.txtCep.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // cbUFF
            // 
            this.cbUFF.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbUFF.FormattingEnabled = true;
            this.cbUFF.ItemHeight = 13;
            this.cbUFF.Location = new System.Drawing.Point(781, 119);
            this.cbUFF.Name = "cbUFF";
            this.cbUFF.Size = new System.Drawing.Size(161, 21);
            this.cbUFF.TabIndex = 11;
            this.cbUFF.Tag = "23";
            // 
            // lblCEP
            // 
            this.lblCEP.AutoSize = true;
            this.lblCEP.Location = new System.Drawing.Point(514, 102);
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
            this.txtCidade.Size = new System.Drawing.Size(280, 20);
            this.txtCidade.TabIndex = 12;
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
            this.txtBairro.TabIndex = 11;
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
            this.txtEndereco.TabIndex = 10;
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
            this.gbIdentificacao.Controls.Add(this.txtLocal);
            this.gbIdentificacao.Controls.Add(this.lblLocal);
            this.gbIdentificacao.Controls.Add(this.txtCodEmpresa);
            this.gbIdentificacao.Controls.Add(this.lblCodEmpresa);
            this.gbIdentificacao.Controls.Add(this.txtEmpresa);
            this.gbIdentificacao.Controls.Add(this.lblEmpresa);
            this.gbIdentificacao.Controls.Add(this.txtFantasia);
            this.gbIdentificacao.Controls.Add(this.lblFantasia);
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
            this.gbIdentificacao.Size = new System.Drawing.Size(965, 122);
            this.gbIdentificacao.TabIndex = 1;
            this.gbIdentificacao.TabStop = false;
            this.gbIdentificacao.Text = "Identificação";
            // 
            // txtLocal
            // 
            this.txtLocal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLocal.Enabled = false;
            this.txtLocal.Location = new System.Drawing.Point(660, 96);
            this.txtLocal.Name = "txtLocal";
            this.txtLocal.Size = new System.Drawing.Size(130, 20);
            this.txtLocal.TabIndex = 7;
            // 
            // lblLocal
            // 
            this.lblLocal.AutoSize = true;
            this.lblLocal.Location = new System.Drawing.Point(657, 80);
            this.lblLocal.Name = "lblLocal";
            this.lblLocal.Size = new System.Drawing.Size(33, 13);
            this.lblLocal.TabIndex = 22;
            this.lblLocal.Text = "Local";
            // 
            // txtCodEmpresa
            // 
            this.txtCodEmpresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodEmpresa.Enabled = false;
            this.txtCodEmpresa.Location = new System.Drawing.Point(508, 96);
            this.txtCodEmpresa.Name = "txtCodEmpresa";
            this.txtCodEmpresa.Size = new System.Drawing.Size(130, 20);
            this.txtCodEmpresa.TabIndex = 6;
            // 
            // lblCodEmpresa
            // 
            this.lblCodEmpresa.AutoSize = true;
            this.lblCodEmpresa.Location = new System.Drawing.Point(505, 80);
            this.lblCodEmpresa.Name = "lblCodEmpresa";
            this.lblCodEmpresa.Size = new System.Drawing.Size(73, 13);
            this.lblCodEmpresa.TabIndex = 20;
            this.lblCodEmpresa.Text = "Cod. Empresa";
            this.lblCodEmpresa.Click += new System.EventHandler(this.lblCodProtheus_Click);
            // 
            // txtEmpresa
            // 
            this.txtEmpresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEmpresa.Enabled = false;
            this.txtEmpresa.Location = new System.Drawing.Point(331, 96);
            this.txtEmpresa.Name = "txtEmpresa";
            this.txtEmpresa.Size = new System.Drawing.Size(161, 20);
            this.txtEmpresa.TabIndex = 5;
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.AutoSize = true;
            this.lblEmpresa.Location = new System.Drawing.Point(328, 80);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(48, 13);
            this.lblEmpresa.TabIndex = 18;
            this.lblEmpresa.Text = "Empresa";
            // 
            // txtFantasia
            // 
            this.txtFantasia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFantasia.Enabled = false;
            this.txtFantasia.Location = new System.Drawing.Point(13, 96);
            this.txtFantasia.Name = "txtFantasia";
            this.txtFantasia.Size = new System.Drawing.Size(292, 20);
            this.txtFantasia.TabIndex = 4;
            // 
            // lblFantasia
            // 
            this.lblFantasia.AutoSize = true;
            this.lblFantasia.Location = new System.Drawing.Point(10, 80);
            this.lblFantasia.Name = "lblFantasia";
            this.lblFantasia.Size = new System.Drawing.Size(78, 13);
            this.lblFantasia.TabIndex = 16;
            this.lblFantasia.Text = "Nome Fantasia";
            // 
            // txtCnpjCpf
            // 
            this.txtCnpjCpf.Enabled = false;
            this.txtCnpjCpf.Location = new System.Drawing.Point(141, 47);
            this.txtCnpjCpf.Name = "txtCnpjCpf";
            this.txtCnpjCpf.Size = new System.Drawing.Size(164, 20);
            this.txtCnpjCpf.TabIndex = 1;
            this.txtCnpjCpf.TabStop = false;
            this.txtCnpjCpf.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtCnpjCpf.Enter += new System.EventHandler(this.TxtCnpjCpf_Enter);
            this.txtCnpjCpf.Leave += new System.EventHandler(this.TxtCnpjCpf_Leave);
            // 
            // txtCadastro
            // 
            this.txtCadastro.Enabled = false;
            this.txtCadastro.Location = new System.Drawing.Point(781, 47);
            this.txtCadastro.Name = "txtCadastro";
            this.txtCadastro.Size = new System.Drawing.Size(161, 20);
            this.txtCadastro.TabIndex = 3;
            this.txtCadastro.TabStop = false;
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
            this.txtRazao.Enabled = false;
            this.txtRazao.Location = new System.Drawing.Point(331, 47);
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
            this.txtCodigo.Enabled = false;
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
            // FormCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 737);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tabCliente);
            this.Controls.Add(this.dbGridView);
            this.Name = "FormCliente";
            this.Text = "FormCliente";
            this.Activated += new System.EventHandler(this.FormCliente_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormCliente_FormClosed);
            this.Load += new System.EventHandler(this.FormCliente_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbGridView)).EndInit();
            this.tabCliente.ResumeLayout(false);
            this.tabPrincipal.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.gbTelefones.ResumeLayout(false);
            this.gbTelefones.PerformLayout();
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
        private System.Windows.Forms.TabControl tabCliente;
        private System.Windows.Forms.TabPage tabPrincipal;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox txtObs;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.GroupBox gbTelefones;
        private System.Windows.Forms.MaskedTextBox txtCel;
        private System.Windows.Forms.MaskedTextBox txtTel;
        private System.Windows.Forms.Label lblTel2;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblTel1;
        private System.Windows.Forms.GroupBox gbEndereco;
        private System.Windows.Forms.PictureBox pbCepF;
        private System.Windows.Forms.MaskedTextBox txtCep;
        private System.Windows.Forms.ComboBox cbUFF;
        private System.Windows.Forms.Label lblCEP;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.TextBox txtCidade;
        private System.Windows.Forms.Label lblCidade;
        private System.Windows.Forms.TextBox txtBairro;
        private System.Windows.Forms.Label lblBairro;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.Label lblEndereco;
        private System.Windows.Forms.GroupBox gbIdentificacao;
        private System.Windows.Forms.TextBox txtLocal;
        private System.Windows.Forms.Label lblLocal;
        private System.Windows.Forms.TextBox txtCodEmpresa;
        private System.Windows.Forms.Label lblCodEmpresa;
        private System.Windows.Forms.TextBox txtEmpresa;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.TextBox txtFantasia;
        private System.Windows.Forms.Label lblFantasia;
        private System.Windows.Forms.MaskedTextBox txtCnpjCpf;
        private System.Windows.Forms.TextBox txtCadastro;
        private System.Windows.Forms.Label lblCadastro;
        private System.Windows.Forms.TextBox txtRazao;
        private System.Windows.Forms.Label lblRazao;
        private System.Windows.Forms.Label lbl_CNPJCPF;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
    }
}