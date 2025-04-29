
namespace Trade_GP
{
    partial class FormRelatorioAnalitico
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
            this.dbLocais = new System.Windows.Forms.DataGridView();
            this.gbMensaProcessamento = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btSearch = new System.Windows.Forms.Button();
            this.lbpath = new System.Windows.Forms.Label();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSepararAno = new System.Windows.Forms.ComboBox();
            this.cbSepararLocal = new System.Windows.Forms.ComboBox();
            this.lbEscopo = new System.Windows.Forms.Label();
            this.cbEscopo = new System.Windows.Forms.ComboBox();
            this.lblLocalPeriodo = new System.Windows.Forms.Label();
            this.lblProcesso = new System.Windows.Forms.Label();
            this.pgProcesso = new System.Windows.Forms.ProgressBar();
            this.btProcessar = new System.Windows.Forms.Button();
            this.gbParametros = new System.Windows.Forms.GroupBox();
            this.btParametros = new System.Windows.Forms.Button();
            this.btProximo = new System.Windows.Forms.Button();
            this.btExcel = new System.Windows.Forms.Button();
            this.lblCancelamentoAtivado = new System.Windows.Forms.Label();
            this.lbTituloErros = new System.Windows.Forms.Label();
            this.dtGridLog = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.cbMes = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dbLocais)).BeginInit();
            this.gbMensaProcessamento.SuspendLayout();
            this.gbParametros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridLog)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.Blue;
            this.lblTitulo.Location = new System.Drawing.Point(1, 9);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(1766, 28);
            this.lblTitulo.TabIndex = 58;
            this.lblTitulo.Text = "Relatórios Analticos";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitulo.Click += new System.EventHandler(this.lblTitulo_Click);
            // 
            // dbLocais
            // 
            this.dbLocais.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbLocais.Location = new System.Drawing.Point(300, 53);
            this.dbLocais.Margin = new System.Windows.Forms.Padding(4);
            this.dbLocais.Name = "dbLocais";
            this.dbLocais.RowHeadersWidth = 51;
            this.dbLocais.Size = new System.Drawing.Size(704, 284);
            this.dbLocais.TabIndex = 61;
            // 
            // gbMensaProcessamento
            // 
            this.gbMensaProcessamento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMensaProcessamento.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gbMensaProcessamento.Controls.Add(this.label4);
            this.gbMensaProcessamento.Controls.Add(this.cbMes);
            this.gbMensaProcessamento.Controls.Add(this.label3);
            this.gbMensaProcessamento.Controls.Add(this.comboBox1);
            this.gbMensaProcessamento.Controls.Add(this.btSearch);
            this.gbMensaProcessamento.Controls.Add(this.lbpath);
            this.gbMensaProcessamento.Controls.Add(this.tbPath);
            this.gbMensaProcessamento.Controls.Add(this.label2);
            this.gbMensaProcessamento.Controls.Add(this.label1);
            this.gbMensaProcessamento.Controls.Add(this.cbSepararAno);
            this.gbMensaProcessamento.Controls.Add(this.cbSepararLocal);
            this.gbMensaProcessamento.Controls.Add(this.lbEscopo);
            this.gbMensaProcessamento.Controls.Add(this.cbEscopo);
            this.gbMensaProcessamento.Controls.Add(this.lblLocalPeriodo);
            this.gbMensaProcessamento.Controls.Add(this.lblProcesso);
            this.gbMensaProcessamento.Controls.Add(this.pgProcesso);
            this.gbMensaProcessamento.Controls.Add(this.btProcessar);
            this.gbMensaProcessamento.Location = new System.Drawing.Point(1012, 56);
            this.gbMensaProcessamento.Margin = new System.Windows.Forms.Padding(4);
            this.gbMensaProcessamento.Name = "gbMensaProcessamento";
            this.gbMensaProcessamento.Padding = new System.Windows.Forms.Padding(4);
            this.gbMensaProcessamento.Size = new System.Drawing.Size(755, 281);
            this.gbMensaProcessamento.TabIndex = 60;
            this.gbMensaProcessamento.TabStop = false;
            this.gbMensaProcessamento.Text = "Atenção";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(591, 38);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "Modelo";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Apuração Créditos"});
            this.comboBox1.Location = new System.Drawing.Point(594, 58);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(154, 24);
            this.comboBox1.TabIndex = 4;
            // 
            // btSearch
            // 
            this.btSearch.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btSearch.Location = new System.Drawing.Point(653, 124);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(95, 22);
            this.btSearch.TabIndex = 6;
            this.btSearch.Text = "...";
            this.btSearch.UseVisualStyleBackColor = false;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // lbpath
            // 
            this.lbpath.AutoSize = true;
            this.lbpath.Location = new System.Drawing.Point(16, 106);
            this.lbpath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbpath.Name = "lbpath";
            this.lbpath.Size = new System.Drawing.Size(295, 17);
            this.lbpath.TabIndex = 11;
            this.lbpath.Text = "Pasta Original Para Os Arquivos Do Relatorio";
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(11, 124);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(634, 22);
            this.tbPath.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(338, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Por Ano";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(238, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Por Local";
            // 
            // cbSepararAno
            // 
            this.cbSepararAno.FormattingEnabled = true;
            this.cbSepararAno.Items.AddRange(new object[] {
            "Sim",
            "Não"});
            this.cbSepararAno.Location = new System.Drawing.Point(341, 58);
            this.cbSepararAno.Name = "cbSepararAno";
            this.cbSepararAno.Size = new System.Drawing.Size(111, 24);
            this.cbSepararAno.TabIndex = 2;
            // 
            // cbSepararLocal
            // 
            this.cbSepararLocal.FormattingEnabled = true;
            this.cbSepararLocal.Items.AddRange(new object[] {
            "Sim",
            "Não"});
            this.cbSepararLocal.Location = new System.Drawing.Point(241, 58);
            this.cbSepararLocal.Name = "cbSepararLocal";
            this.cbSepararLocal.Size = new System.Drawing.Size(81, 24);
            this.cbSepararLocal.TabIndex = 1;
            // 
            // lbEscopo
            // 
            this.lbEscopo.AutoSize = true;
            this.lbEscopo.Location = new System.Drawing.Point(7, 38);
            this.lbEscopo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbEscopo.Name = "lbEscopo";
            this.lbEscopo.Size = new System.Drawing.Size(55, 17);
            this.lbEscopo.TabIndex = 5;
            this.lbEscopo.Text = "Escopo";
            // 
            // cbEscopo
            // 
            this.cbEscopo.FormattingEnabled = true;
            this.cbEscopo.Items.AddRange(new object[] {
            "16/03/2017 a 19/08/2019",
            "20/08/2019 a 30/06/2023",
            "Ambos"});
            this.cbEscopo.Location = new System.Drawing.Point(10, 58);
            this.cbEscopo.Name = "cbEscopo";
            this.cbEscopo.Size = new System.Drawing.Size(225, 24);
            this.cbEscopo.TabIndex = 0;
            // 
            // lblLocalPeriodo
            // 
            this.lblLocalPeriodo.AutoSize = true;
            this.lblLocalPeriodo.Location = new System.Drawing.Point(8, 250);
            this.lblLocalPeriodo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLocalPeriodo.Name = "lblLocalPeriodo";
            this.lblLocalPeriodo.Size = new System.Drawing.Size(46, 17);
            this.lblLocalPeriodo.TabIndex = 3;
            this.lblLocalPeriodo.Text = "label2";
            // 
            // lblProcesso
            // 
            this.lblProcesso.AutoSize = true;
            this.lblProcesso.Location = new System.Drawing.Point(8, 173);
            this.lblProcesso.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProcesso.Name = "lblProcesso";
            this.lblProcesso.Size = new System.Drawing.Size(122, 17);
            this.lblProcesso.TabIndex = 2;
            this.lblProcesso.Text = "Acompanhamento";
            // 
            // pgProcesso
            // 
            this.pgProcesso.Location = new System.Drawing.Point(8, 193);
            this.pgProcesso.Margin = new System.Windows.Forms.Padding(4);
            this.pgProcesso.Name = "pgProcesso";
            this.pgProcesso.Size = new System.Drawing.Size(739, 28);
            this.pgProcesso.TabIndex = 1;
            // 
            // btProcessar
            // 
            this.btProcessar.Location = new System.Drawing.Point(430, 244);
            this.btProcessar.Margin = new System.Windows.Forms.Padding(4);
            this.btProcessar.Name = "btProcessar";
            this.btProcessar.Size = new System.Drawing.Size(317, 28);
            this.btProcessar.TabIndex = 0;
            this.btProcessar.Tag = "7";
            this.btProcessar.Text = "Processamento";
            this.btProcessar.UseVisualStyleBackColor = true;
            this.btProcessar.Click += new System.EventHandler(this.btProcessar_Click);
            // 
            // gbParametros
            // 
            this.gbParametros.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gbParametros.Controls.Add(this.btParametros);
            this.gbParametros.Controls.Add(this.btProximo);
            this.gbParametros.Location = new System.Drawing.Point(5, 53);
            this.gbParametros.Margin = new System.Windows.Forms.Padding(4);
            this.gbParametros.Name = "gbParametros";
            this.gbParametros.Padding = new System.Windows.Forms.Padding(4);
            this.gbParametros.Size = new System.Drawing.Size(287, 284);
            this.gbParametros.TabIndex = 59;
            this.gbParametros.TabStop = false;
            this.gbParametros.Text = "Parâmetros";
            // 
            // btParametros
            // 
            this.btParametros.BackColor = System.Drawing.Color.Red;
            this.btParametros.Location = new System.Drawing.Point(20, 43);
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
            this.btProximo.Location = new System.Drawing.Point(137, 196);
            this.btProximo.Margin = new System.Windows.Forms.Padding(4);
            this.btProximo.Name = "btProximo";
            this.btProximo.Size = new System.Drawing.Size(133, 28);
            this.btProximo.TabIndex = 6;
            this.btProximo.Text = "Próximo";
            this.btProximo.UseVisualStyleBackColor = true;
            this.btProximo.Click += new System.EventHandler(this.btProximo_Click);
            // 
            // btExcel
            // 
            this.btExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btExcel.Image = global::Trade_GP.Properties.Resources.excel_logo;
            this.btExcel.Location = new System.Drawing.Point(1709, 359);
            this.btExcel.Margin = new System.Windows.Forms.Padding(4);
            this.btExcel.Name = "btExcel";
            this.btExcel.Size = new System.Drawing.Size(60, 48);
            this.btExcel.TabIndex = 62;
            this.btExcel.UseVisualStyleBackColor = true;
            // 
            // lblCancelamentoAtivado
            // 
            this.lblCancelamentoAtivado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCancelamentoAtivado.ForeColor = System.Drawing.Color.Red;
            this.lblCancelamentoAtivado.Location = new System.Drawing.Point(0, 379);
            this.lblCancelamentoAtivado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCancelamentoAtivado.Name = "lblCancelamentoAtivado";
            this.lblCancelamentoAtivado.Size = new System.Drawing.Size(1729, 28);
            this.lblCancelamentoAtivado.TabIndex = 63;
            this.lblCancelamentoAtivado.Text = "CANCELAMENTO SOLICITADO!";
            this.lblCancelamentoAtivado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTituloErros
            // 
            this.lbTituloErros.AutoSize = true;
            this.lbTituloErros.Location = new System.Drawing.Point(13, 379);
            this.lbTituloErros.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTituloErros.Name = "lbTituloErros";
            this.lbTituloErros.Size = new System.Drawing.Size(176, 17);
            this.lbTituloErros.TabIndex = 64;
            this.lbTituloErros.Text = "O que está em andamento";
            // 
            // dtGridLog
            // 
            this.dtGridLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtGridLog.CausesValidation = false;
            this.dtGridLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridLog.Location = new System.Drawing.Point(8, 411);
            this.dtGridLog.Margin = new System.Windows.Forms.Padding(4);
            this.dtGridLog.Name = "dtGridLog";
            this.dtGridLog.RowHeadersWidth = 51;
            this.dtGridLog.Size = new System.Drawing.Size(1761, 347);
            this.dtGridLog.TabIndex = 65;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(464, 38);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "Por Mês";
            // 
            // cbMes
            // 
            this.cbMes.FormattingEnabled = true;
            this.cbMes.Items.AddRange(new object[] {
            "Sim",
            "Não"});
            this.cbMes.Location = new System.Drawing.Point(467, 58);
            this.cbMes.Name = "cbMes";
            this.cbMes.Size = new System.Drawing.Size(111, 24);
            this.cbMes.TabIndex = 3;
            // 
            // FormRelatorioAnalitico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1780, 698);
            this.Controls.Add(this.dtGridLog);
            this.Controls.Add(this.lbTituloErros);
            this.Controls.Add(this.btExcel);
            this.Controls.Add(this.lblCancelamentoAtivado);
            this.Controls.Add(this.dbLocais);
            this.Controls.Add(this.gbMensaProcessamento);
            this.Controls.Add(this.gbParametros);
            this.Controls.Add(this.lblTitulo);
            this.Name = "FormRelatorioAnalitico";
            this.Text = "FormRelatorioAnalitico";
            this.Activated += new System.EventHandler(this.FormRelatorioAnalitico_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormRelatorioAnalitico_FormClosed);
            this.Load += new System.EventHandler(this.FormRelatorioAnalitico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dbLocais)).EndInit();
            this.gbMensaProcessamento.ResumeLayout(false);
            this.gbMensaProcessamento.PerformLayout();
            this.gbParametros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGridLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dbLocais;
        private System.Windows.Forms.GroupBox gbMensaProcessamento;
        private System.Windows.Forms.Label lblLocalPeriodo;
        private System.Windows.Forms.Label lblProcesso;
        private System.Windows.Forms.ProgressBar pgProcesso;
        private System.Windows.Forms.Button btProcessar;
        private System.Windows.Forms.GroupBox gbParametros;
        private System.Windows.Forms.Button btParametros;
        private System.Windows.Forms.Button btProximo;
        private System.Windows.Forms.Button btExcel;
        private System.Windows.Forms.Label lblCancelamentoAtivado;
        private System.Windows.Forms.Label lbTituloErros;
        private System.Windows.Forms.DataGridView dtGridLog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbSepararAno;
        private System.Windows.Forms.ComboBox cbSepararLocal;
        private System.Windows.Forms.Label lbEscopo;
        private System.Windows.Forms.ComboBox cbEscopo;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.Label lbpath;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbMes;
    }
}