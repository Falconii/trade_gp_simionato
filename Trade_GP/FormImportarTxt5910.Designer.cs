
namespace Trade_GP
{
    partial class FormImportarTxt5910
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormImportarTxt5910));
            this.lbTitulo = new System.Windows.Forms.Label();
            this.lbArquivo = new System.Windows.Forms.Label();
            this.tbFolder = new System.Windows.Forms.TextBox();
            this.btPesquisar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btExcel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btCancelar = new System.Windows.Forms.Button();
            this.lbPage = new System.Windows.Forms.Label();
            this.cbPage = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbCPFO = new System.Windows.Forms.ComboBox();
            this.BtImportar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbLayOut = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbProcesso = new System.Windows.Forms.Label();
            this.pbProcesso = new System.Windows.Forms.ProgressBar();
            this.lbMensagem = new System.Windows.Forms.Label();
            this.dashboardProgress = new System.Windows.Forms.ProgressBar();
            this.lbTituloErros = new System.Windows.Forms.Label();
            this.dtGridErros = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridErros)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitulo
            // 
            this.lbTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.Location = new System.Drawing.Point(26, 9);
            this.lbTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(1245, 27);
            this.lbTitulo.TabIndex = 35;
            this.lbTitulo.Text = "Rotina Para Importação De Arquivos TXT  5910";
            this.lbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbArquivo
            // 
            this.lbArquivo.AutoSize = true;
            this.lbArquivo.Location = new System.Drawing.Point(19, 70);
            this.lbArquivo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbArquivo.Name = "lbArquivo";
            this.lbArquivo.Size = new System.Drawing.Size(44, 17);
            this.lbArquivo.TabIndex = 38;
            this.lbArquivo.Text = "Pasta";
            // 
            // tbFolder
            // 
            this.tbFolder.Location = new System.Drawing.Point(72, 66);
            this.tbFolder.Margin = new System.Windows.Forms.Padding(4);
            this.tbFolder.Name = "tbFolder";
            this.tbFolder.Size = new System.Drawing.Size(1083, 22);
            this.tbFolder.TabIndex = 36;
            // 
            // btPesquisar
            // 
            this.btPesquisar.Location = new System.Drawing.Point(1164, 64);
            this.btPesquisar.Margin = new System.Windows.Forms.Padding(4);
            this.btPesquisar.Name = "btPesquisar";
            this.btPesquisar.Size = new System.Drawing.Size(100, 28);
            this.btPesquisar.TabIndex = 37;
            this.btPesquisar.Text = "...";
            this.btPesquisar.UseVisualStyleBackColor = true;
            this.btPesquisar.Click += new System.EventHandler(this.btPesquisar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 115);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 17);
            this.label2.TabIndex = 40;
            this.label2.Text = "Lista Dos Arquivos";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(22, 143);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1234, 197);
            this.dataGridView1.TabIndex = 39;
            // 
            // btExcel
            // 
            this.btExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btExcel.Image = ((System.Drawing.Image)(resources.GetObject("btExcel.Image")));
            this.btExcel.Location = new System.Drawing.Point(1194, 563);
            this.btExcel.Margin = new System.Windows.Forms.Padding(4);
            this.btExcel.Name = "btExcel";
            this.btExcel.Size = new System.Drawing.Size(60, 41);
            this.btExcel.TabIndex = 47;
            this.btExcel.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 375);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 17);
            this.label5.TabIndex = 46;
            this.label5.Text = "Parâmetros";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel2.Controls.Add(this.btCancelar);
            this.panel2.Controls.Add(this.lbPage);
            this.panel2.Controls.Add(this.cbPage);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cbCPFO);
            this.panel2.Controls.Add(this.BtImportar);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cbLayOut);
            this.panel2.Location = new System.Drawing.Point(22, 403);
            this.panel2.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(652, 134);
            this.panel2.TabIndex = 45;
            // 
            // btCancelar
            // 
            this.btCancelar.Location = new System.Drawing.Point(527, 87);
            this.btCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(100, 28);
            this.btCancelar.TabIndex = 7;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // lbPage
            // 
            this.lbPage.AutoSize = true;
            this.lbPage.Location = new System.Drawing.Point(7, 95);
            this.lbPage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPage.Name = "lbPage";
            this.lbPage.Size = new System.Drawing.Size(52, 17);
            this.lbPage.TabIndex = 23;
            this.lbPage.Text = "Página";
            // 
            // cbPage
            // 
            this.cbPage.FormattingEnabled = true;
            this.cbPage.ItemHeight = 16;
            this.cbPage.Items.AddRange(new object[] {
            "1",
            "200",
            "500"});
            this.cbPage.Location = new System.Drawing.Point(73, 90);
            this.cbPage.Margin = new System.Windows.Forms.Padding(4);
            this.cbPage.Name = "cbPage";
            this.cbPage.Size = new System.Drawing.Size(171, 24);
            this.cbPage.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(319, 37);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 21;
            this.label3.Text = "Ação:";
            // 
            // cbCPFO
            // 
            this.cbCPFO.FormattingEnabled = true;
            this.cbCPFO.ItemHeight = 16;
            this.cbCPFO.Items.AddRange(new object[] {
            "IMPORTAR NOTAS 5910"});
            this.cbCPFO.Location = new System.Drawing.Point(387, 32);
            this.cbCPFO.Margin = new System.Windows.Forms.Padding(4);
            this.cbCPFO.Name = "cbCPFO";
            this.cbCPFO.Size = new System.Drawing.Size(240, 24);
            this.cbCPFO.TabIndex = 4;
            // 
            // BtImportar
            // 
            this.BtImportar.Location = new System.Drawing.Point(400, 87);
            this.BtImportar.Margin = new System.Windows.Forms.Padding(4);
            this.BtImportar.Name = "BtImportar";
            this.BtImportar.Size = new System.Drawing.Size(100, 28);
            this.BtImportar.TabIndex = 6;
            this.BtImportar.Text = "Importação";
            this.BtImportar.UseVisualStyleBackColor = true;
            this.BtImportar.Click += new System.EventHandler(this.BtImportar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "Lay Out";
            // 
            // cbLayOut
            // 
            this.cbLayOut.FormattingEnabled = true;
            this.cbLayOut.ItemHeight = 16;
            this.cbLayOut.Items.AddRange(new object[] {
            "AUTOMÁTICO",
            "MOVIMENTAÇÃO",
            "SALDO"});
            this.cbLayOut.Location = new System.Drawing.Point(73, 32);
            this.cbLayOut.Margin = new System.Windows.Forms.Padding(4);
            this.cbLayOut.Name = "cbLayOut";
            this.cbLayOut.Size = new System.Drawing.Size(171, 24);
            this.cbLayOut.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.lbProcesso);
            this.panel1.Controls.Add(this.pbProcesso);
            this.panel1.Controls.Add(this.lbMensagem);
            this.panel1.Controls.Add(this.dashboardProgress);
            this.panel1.Location = new System.Drawing.Point(691, 403);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(567, 134);
            this.panel1.TabIndex = 44;
            // 
            // lbProcesso
            // 
            this.lbProcesso.AutoSize = true;
            this.lbProcesso.Location = new System.Drawing.Point(13, 10);
            this.lbProcesso.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbProcesso.Name = "lbProcesso";
            this.lbProcesso.Size = new System.Drawing.Size(77, 17);
            this.lbProcesso.TabIndex = 22;
            this.lbProcesso.Text = "Mensagem";
            // 
            // pbProcesso
            // 
            this.pbProcesso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbProcesso.Location = new System.Drawing.Point(17, 32);
            this.pbProcesso.Margin = new System.Windows.Forms.Padding(4);
            this.pbProcesso.Name = "pbProcesso";
            this.pbProcesso.Size = new System.Drawing.Size(523, 28);
            this.pbProcesso.TabIndex = 21;
            // 
            // lbMensagem
            // 
            this.lbMensagem.AutoSize = true;
            this.lbMensagem.Location = new System.Drawing.Point(13, 70);
            this.lbMensagem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMensagem.Name = "lbMensagem";
            this.lbMensagem.Size = new System.Drawing.Size(77, 17);
            this.lbMensagem.TabIndex = 20;
            this.lbMensagem.Text = "Mensagem";
            // 
            // dashboardProgress
            // 
            this.dashboardProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dashboardProgress.Location = new System.Drawing.Point(17, 90);
            this.dashboardProgress.Margin = new System.Windows.Forms.Padding(4);
            this.dashboardProgress.Name = "dashboardProgress";
            this.dashboardProgress.Size = new System.Drawing.Size(523, 28);
            this.dashboardProgress.Step = 1;
            this.dashboardProgress.TabIndex = 19;
            // 
            // lbTituloErros
            // 
            this.lbTituloErros.AutoSize = true;
            this.lbTituloErros.Location = new System.Drawing.Point(20, 608);
            this.lbTituloErros.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTituloErros.Name = "lbTituloErros";
            this.lbTituloErros.Size = new System.Drawing.Size(132, 17);
            this.lbTituloErros.TabIndex = 49;
            this.lbTituloErros.Text = "Listagem Dos Erros";
            // 
            // dtGridErros
            // 
            this.dtGridErros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtGridErros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridErros.Location = new System.Drawing.Point(19, 631);
            this.dtGridErros.Margin = new System.Windows.Forms.Padding(4);
            this.dtGridErros.Name = "dtGridErros";
            this.dtGridErros.RowHeadersWidth = 51;
            this.dtGridErros.Size = new System.Drawing.Size(1235, 103);
            this.dtGridErros.TabIndex = 48;
            // 
            // FormImportarTxt5910
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1431, 1055);
            this.Controls.Add(this.lbTituloErros);
            this.Controls.Add(this.dtGridErros);
            this.Controls.Add(this.btExcel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lbArquivo);
            this.Controls.Add(this.tbFolder);
            this.Controls.Add(this.btPesquisar);
            this.Controls.Add(this.lbTitulo);
            this.Name = "FormImportarTxt5910";
            this.Text = "Importação TXT 5910";
            this.Activated += new System.EventHandler(this.FormImportarTxt5910_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormImportarTxt5910_FormClosed);
            this.Load += new System.EventHandler(this.FormImportarTxt5910_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridErros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.Label lbArquivo;
        private System.Windows.Forms.TextBox tbFolder;
        private System.Windows.Forms.Button btPesquisar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btExcel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Label lbPage;
        private System.Windows.Forms.ComboBox cbPage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbCPFO;
        private System.Windows.Forms.Button BtImportar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbLayOut;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbProcesso;
        private System.Windows.Forms.ProgressBar pbProcesso;
        private System.Windows.Forms.Label lbMensagem;
        private System.Windows.Forms.ProgressBar dashboardProgress;
        private System.Windows.Forms.Label lbTituloErros;
        private System.Windows.Forms.DataGridView dtGridErros;
    }
}