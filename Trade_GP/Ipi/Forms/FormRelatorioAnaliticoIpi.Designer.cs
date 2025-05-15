
namespace Trade_GP.Ipi.Forms
{
    partial class FormRelatorioAnaliticoIpi
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.gbParametros = new System.Windows.Forms.GroupBox();
            this.btParametros = new System.Windows.Forms.Button();
            this.btProximo = new System.Windows.Forms.Button();
            this.dbLocais = new System.Windows.Forms.DataGridView();
            this.gbMensaProcessamento = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btPesquisar = new System.Windows.Forms.Button();
            this.tbFolder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbMes = new System.Windows.Forms.ComboBox();
            this.cbAno = new System.Windows.Forms.ComboBox();
            this.cbLocal = new System.Windows.Forms.ComboBox();
            this.btNovo = new System.Windows.Forms.Button();
            this.btProcessar = new System.Windows.Forms.Button();
            this.dtGridLog = new System.Windows.Forms.DataGridView();
            this.lblCancelamentoAtivado = new System.Windows.Forms.Label();
            this.gbParametros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbLocais)).BeginInit();
            this.gbMensaProcessamento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridLog)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.Blue;
            this.lblTitulo.Location = new System.Drawing.Point(13, 9);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(1898, 28);
            this.lblTitulo.TabIndex = 65;
            this.lblTitulo.Text = "Relatório Analítico Do IPI";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitulo.Click += new System.EventHandler(this.lblTitulo_Click);
            // 
            // gbParametros
            // 
            this.gbParametros.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gbParametros.Controls.Add(this.btParametros);
            this.gbParametros.Controls.Add(this.btProximo);
            this.gbParametros.Location = new System.Drawing.Point(17, 41);
            this.gbParametros.Margin = new System.Windows.Forms.Padding(4);
            this.gbParametros.Name = "gbParametros";
            this.gbParametros.Padding = new System.Windows.Forms.Padding(4);
            this.gbParametros.Size = new System.Drawing.Size(287, 205);
            this.gbParametros.TabIndex = 66;
            this.gbParametros.TabStop = false;
            this.gbParametros.Text = "Perâmetros";
            // 
            // btParametros
            // 
            this.btParametros.BackColor = System.Drawing.Color.Red;
            this.btParametros.Location = new System.Drawing.Point(8, 49);
            this.btParametros.Margin = new System.Windows.Forms.Padding(4);
            this.btParametros.Name = "btParametros";
            this.btParametros.Size = new System.Drawing.Size(193, 28);
            this.btParametros.TabIndex = 7;
            this.btParametros.Text = "PARÂMETROS";
            this.btParametros.UseVisualStyleBackColor = false;
            this.btParametros.Click += new System.EventHandler(this.btParametros_Click);
            // 
            // btProximo
            // 
            this.btProximo.ForeColor = System.Drawing.Color.Green;
            this.btProximo.Location = new System.Drawing.Point(146, 160);
            this.btProximo.Margin = new System.Windows.Forms.Padding(4);
            this.btProximo.Name = "btProximo";
            this.btProximo.Size = new System.Drawing.Size(133, 28);
            this.btProximo.TabIndex = 6;
            this.btProximo.Text = "Próximo";
            this.btProximo.UseVisualStyleBackColor = true;
            this.btProximo.Click += new System.EventHandler(this.btProximo_Click);
            // 
            // dbLocais
            // 
            this.dbLocais.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbLocais.Location = new System.Drawing.Point(312, 41);
            this.dbLocais.Margin = new System.Windows.Forms.Padding(4);
            this.dbLocais.Name = "dbLocais";
            this.dbLocais.RowHeadersWidth = 51;
            this.dbLocais.Size = new System.Drawing.Size(952, 205);
            this.dbLocais.TabIndex = 67;
            // 
            // gbMensaProcessamento
            // 
            this.gbMensaProcessamento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMensaProcessamento.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gbMensaProcessamento.Controls.Add(this.label4);
            this.gbMensaProcessamento.Controls.Add(this.btPesquisar);
            this.gbMensaProcessamento.Controls.Add(this.tbFolder);
            this.gbMensaProcessamento.Controls.Add(this.label3);
            this.gbMensaProcessamento.Controls.Add(this.label2);
            this.gbMensaProcessamento.Controls.Add(this.label1);
            this.gbMensaProcessamento.Controls.Add(this.cbMes);
            this.gbMensaProcessamento.Controls.Add(this.cbAno);
            this.gbMensaProcessamento.Controls.Add(this.cbLocal);
            this.gbMensaProcessamento.Controls.Add(this.btNovo);
            this.gbMensaProcessamento.Controls.Add(this.btProcessar);
            this.gbMensaProcessamento.Location = new System.Drawing.Point(1272, 44);
            this.gbMensaProcessamento.Margin = new System.Windows.Forms.Padding(4);
            this.gbMensaProcessamento.Name = "gbMensaProcessamento";
            this.gbMensaProcessamento.Padding = new System.Windows.Forms.Padding(4);
            this.gbMensaProcessamento.Size = new System.Drawing.Size(639, 202);
            this.gbMensaProcessamento.TabIndex = 68;
            this.gbMensaProcessamento.TabStop = false;
            this.gbMensaProcessamento.Text = "Atenção";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 17);
            this.label4.TabIndex = 72;
            this.label4.Text = "Separar Por Mês";
            // 
            // btPesquisar
            // 
            this.btPesquisar.Location = new System.Drawing.Point(527, 116);
            this.btPesquisar.Margin = new System.Windows.Forms.Padding(4);
            this.btPesquisar.Name = "btPesquisar";
            this.btPesquisar.Size = new System.Drawing.Size(100, 28);
            this.btPesquisar.TabIndex = 71;
            this.btPesquisar.Text = "...";
            this.btPesquisar.UseVisualStyleBackColor = true;
            this.btPesquisar.Click += new System.EventHandler(this.btPesquisar_Click);
            // 
            // tbFolder
            // 
            this.tbFolder.Location = new System.Drawing.Point(17, 122);
            this.tbFolder.Margin = new System.Windows.Forms.Padding(4);
            this.tbFolder.Name = "tbFolder";
            this.tbFolder.Size = new System.Drawing.Size(502, 22);
            this.tbFolder.TabIndex = 70;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(307, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Separar Por Mês";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(163, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Separar Por Ano";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Separar Por Local";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cbMes
            // 
            this.cbMes.FormattingEnabled = true;
            this.cbMes.Items.AddRange(new object[] {
            "Sim",
            "Não"});
            this.cbMes.Location = new System.Drawing.Point(310, 60);
            this.cbMes.Name = "cbMes";
            this.cbMes.Size = new System.Drawing.Size(121, 24);
            this.cbMes.TabIndex = 7;
            // 
            // cbAno
            // 
            this.cbAno.FormattingEnabled = true;
            this.cbAno.Items.AddRange(new object[] {
            "Sim",
            "Não"});
            this.cbAno.Location = new System.Drawing.Point(166, 60);
            this.cbAno.Name = "cbAno";
            this.cbAno.Size = new System.Drawing.Size(121, 24);
            this.cbAno.TabIndex = 6;
            // 
            // cbLocal
            // 
            this.cbLocal.FormattingEnabled = true;
            this.cbLocal.Items.AddRange(new object[] {
            "Sim",
            "Não"});
            this.cbLocal.Location = new System.Drawing.Point(17, 60);
            this.cbLocal.Name = "cbLocal";
            this.cbLocal.Size = new System.Drawing.Size(121, 24);
            this.cbLocal.TabIndex = 5;
            // 
            // btNovo
            // 
            this.btNovo.Location = new System.Drawing.Point(475, 166);
            this.btNovo.Margin = new System.Windows.Forms.Padding(4);
            this.btNovo.Name = "btNovo";
            this.btNovo.Size = new System.Drawing.Size(156, 28);
            this.btNovo.TabIndex = 4;
            this.btNovo.Tag = "0";
            this.btNovo.Text = "Novo Processamento";
            this.btNovo.UseVisualStyleBackColor = true;
            this.btNovo.Click += new System.EventHandler(this.btNovo_Click);
            // 
            // btProcessar
            // 
            this.btProcessar.Location = new System.Drawing.Point(311, 167);
            this.btProcessar.Margin = new System.Windows.Forms.Padding(4);
            this.btProcessar.Name = "btProcessar";
            this.btProcessar.Size = new System.Drawing.Size(156, 28);
            this.btProcessar.TabIndex = 0;
            this.btProcessar.Tag = "0";
            this.btProcessar.Text = "Processamento";
            this.btProcessar.UseVisualStyleBackColor = true;
            this.btProcessar.Click += new System.EventHandler(this.btProcessar_Click);
            // 
            // dtGridLog
            // 
            this.dtGridLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtGridLog.CausesValidation = false;
            this.dtGridLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridLog.Location = new System.Drawing.Point(17, 333);
            this.dtGridLog.Margin = new System.Windows.Forms.Padding(4);
            this.dtGridLog.Name = "dtGridLog";
            this.dtGridLog.RowHeadersWidth = 51;
            this.dtGridLog.Size = new System.Drawing.Size(1894, 352);
            this.dtGridLog.TabIndex = 78;
            // 
            // lblCancelamentoAtivado
            // 
            this.lblCancelamentoAtivado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCancelamentoAtivado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCancelamentoAtivado.ForeColor = System.Drawing.Color.Red;
            this.lblCancelamentoAtivado.Location = new System.Drawing.Point(13, 262);
            this.lblCancelamentoAtivado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCancelamentoAtivado.Name = "lblCancelamentoAtivado";
            this.lblCancelamentoAtivado.Size = new System.Drawing.Size(1900, 28);
            this.lblCancelamentoAtivado.TabIndex = 79;
            this.lblCancelamentoAtivado.Text = "CANCELAMENTO SOLICITADO!";
            this.lblCancelamentoAtivado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormRelatorioAnaliticoIpi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 698);
            this.Controls.Add(this.lblCancelamentoAtivado);
            this.Controls.Add(this.dtGridLog);
            this.Controls.Add(this.gbMensaProcessamento);
            this.Controls.Add(this.dbLocais);
            this.Controls.Add(this.gbParametros);
            this.Controls.Add(this.lblTitulo);
            this.Name = "FormRelatorioAnaliticoIpi";
            this.Text = "Relatório Analitico";
            this.Activated += new System.EventHandler(this.FormRelatorioAnalitico_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormRelatorioAnalitico_FormClosed);
            this.Load += new System.EventHandler(this.FormRelatorioAnalitico_Load);
            this.gbParametros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dbLocais)).EndInit();
            this.gbMensaProcessamento.ResumeLayout(false);
            this.gbMensaProcessamento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox gbParametros;
        private System.Windows.Forms.Button btParametros;
        private System.Windows.Forms.Button btProximo;
        private System.Windows.Forms.DataGridView dbLocais;
        private System.Windows.Forms.GroupBox gbMensaProcessamento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbMes;
        private System.Windows.Forms.ComboBox cbAno;
        private System.Windows.Forms.ComboBox cbLocal;
        private System.Windows.Forms.Button btNovo;
        private System.Windows.Forms.Button btProcessar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbFolder;
        private System.Windows.Forms.Button btPesquisar;
        private System.Windows.Forms.DataGridView dtGridLog;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCancelamentoAtivado;
    }
}