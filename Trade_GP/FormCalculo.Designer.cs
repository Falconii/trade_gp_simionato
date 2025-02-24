
namespace Trade_GP
{
    partial class FormCalculo
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
            this.lbTitulo = new System.Windows.Forms.Label();
            this.gbData = new System.Windows.Forms.GroupBox();
            this.btValidar = new System.Windows.Forms.Button();
            this.txtDataFinal = new System.Windows.Forms.MaskedTextBox();
            this.txtDataInicial = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.gbAtencao = new System.Windows.Forms.GroupBox();
            this.btPreparar = new System.Windows.Forms.Button();
            this.lbMensaAtencao = new System.Windows.Forms.Label();
            this.btExcel = new System.Windows.Forms.Button();
            this.lbTituloErros = new System.Windows.Forms.Label();
            this.dtGridLog = new System.Windows.Forms.DataGridView();
            this.gbMensaProcessamento = new System.Windows.Forms.GroupBox();
            this.lblTempoFinal = new System.Windows.Forms.Label();
            this.lblProcesso = new System.Windows.Forms.Label();
            this.pgProcesso = new System.Windows.Forms.ProgressBar();
            this.btProcessar = new System.Windows.Forms.Button();
            this.lblFechamento = new System.Windows.Forms.Label();
            this.lblCancelamentoAtivado = new System.Windows.Forms.Label();
            this.btVoltar = new System.Windows.Forms.Button();
            this.gbData.SuspendLayout();
            this.gbAtencao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridLog)).BeginInit();
            this.gbMensaProcessamento.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTitulo
            // 
            this.lbTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.Location = new System.Drawing.Point(-2, 9);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(1315, 22);
            this.lbTitulo.TabIndex = 36;
            this.lbTitulo.Text = "Distribuição das QTDS da Notas De Venda Para as NOTAS De Estoque";
            this.lbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbData
            // 
            this.gbData.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gbData.Controls.Add(this.btValidar);
            this.gbData.Controls.Add(this.txtDataFinal);
            this.gbData.Controls.Add(this.txtDataInicial);
            this.gbData.Controls.Add(this.label6);
            this.gbData.Controls.Add(this.label7);
            this.gbData.Location = new System.Drawing.Point(12, 92);
            this.gbData.Name = "gbData";
            this.gbData.Size = new System.Drawing.Size(308, 123);
            this.gbData.TabIndex = 41;
            this.gbData.TabStop = false;
            this.gbData.Text = "Período";
            // 
            // btValidar
            // 
            this.btValidar.Location = new System.Drawing.Point(177, 84);
            this.btValidar.Name = "btValidar";
            this.btValidar.Size = new System.Drawing.Size(100, 23);
            this.btValidar.TabIndex = 6;
            this.btValidar.Text = "Validar";
            this.btValidar.UseVisualStyleBackColor = true;
            this.btValidar.Click += new System.EventHandler(this.btValidar_Click);
            // 
            // txtDataFinal
            // 
            this.txtDataFinal.Location = new System.Drawing.Point(177, 43);
            this.txtDataFinal.Mask = "99/99/9999";
            this.txtDataFinal.Name = "txtDataFinal";
            this.txtDataFinal.PromptChar = ' ';
            this.txtDataFinal.Size = new System.Drawing.Size(100, 20);
            this.txtDataFinal.TabIndex = 5;
            this.txtDataFinal.Text = "31122021";
            // 
            // txtDataInicial
            // 
            this.txtDataInicial.Location = new System.Drawing.Point(7, 43);
            this.txtDataInicial.Mask = "99/99/9999";
            this.txtDataInicial.Name = "txtDataInicial";
            this.txtDataInicial.PromptChar = ' ';
            this.txtDataInicial.Size = new System.Drawing.Size(100, 20);
            this.txtDataInicial.TabIndex = 4;
            this.txtDataInicial.Text = "01012021";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(174, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Data Final";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Data Inicial";
            // 
            // gbAtencao
            // 
            this.gbAtencao.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gbAtencao.Controls.Add(this.btPreparar);
            this.gbAtencao.Controls.Add(this.lbMensaAtencao);
            this.gbAtencao.Location = new System.Drawing.Point(358, 92);
            this.gbAtencao.Name = "gbAtencao";
            this.gbAtencao.Size = new System.Drawing.Size(506, 123);
            this.gbAtencao.TabIndex = 42;
            this.gbAtencao.TabStop = false;
            this.gbAtencao.Text = "Atenção";
            // 
            // btPreparar
            // 
            this.btPreparar.Location = new System.Drawing.Point(425, 84);
            this.btPreparar.Name = "btPreparar";
            this.btPreparar.Size = new System.Drawing.Size(75, 23);
            this.btPreparar.TabIndex = 1;
            this.btPreparar.Text = "Preparação";
            this.btPreparar.UseVisualStyleBackColor = true;
            this.btPreparar.Click += new System.EventHandler(this.btPreparar_Click);
            // 
            // lbMensaAtencao
            // 
            this.lbMensaAtencao.Location = new System.Drawing.Point(6, 27);
            this.lbMensaAtencao.Name = "lbMensaAtencao";
            this.lbMensaAtencao.Size = new System.Drawing.Size(399, 92);
            this.lbMensaAtencao.TabIndex = 0;
            this.lbMensaAtencao.Text = "Existem 3000 Notas.\r\n\r\nEssas Notas Serão Processadas Em Blocos De 1000 unidades.\r" +
    "\n\r\nCada Processamento Demora Em Média, 9 Minutos.\r\n\r\nTempo estimado 4 horas.\r\n";
            // 
            // btExcel
            // 
            this.btExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btExcel.Image = global::Trade_GP.Properties.Resources.excel_logo;
            this.btExcel.Location = new System.Drawing.Point(1254, 239);
            this.btExcel.Name = "btExcel";
            this.btExcel.Size = new System.Drawing.Size(45, 39);
            this.btExcel.TabIndex = 45;
            this.btExcel.UseVisualStyleBackColor = true;
            this.btExcel.Click += new System.EventHandler(this.btExcel_Click);
            // 
            // lbTituloErros
            // 
            this.lbTituloErros.AutoSize = true;
            this.lbTituloErros.Location = new System.Drawing.Point(9, 265);
            this.lbTituloErros.Name = "lbTituloErros";
            this.lbTituloErros.Size = new System.Drawing.Size(132, 13);
            this.lbTituloErros.TabIndex = 44;
            this.lbTituloErros.Text = "O que está em andamento";
            // 
            // dtGridLog
            // 
            this.dtGridLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtGridLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridLog.Location = new System.Drawing.Point(12, 284);
            this.dtGridLog.Name = "dtGridLog";
            this.dtGridLog.Size = new System.Drawing.Size(1287, 245);
            this.dtGridLog.TabIndex = 43;
            // 
            // gbMensaProcessamento
            // 
            this.gbMensaProcessamento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMensaProcessamento.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gbMensaProcessamento.Controls.Add(this.lblTempoFinal);
            this.gbMensaProcessamento.Controls.Add(this.lblProcesso);
            this.gbMensaProcessamento.Controls.Add(this.pgProcesso);
            this.gbMensaProcessamento.Controls.Add(this.btProcessar);
            this.gbMensaProcessamento.Location = new System.Drawing.Point(901, 92);
            this.gbMensaProcessamento.Name = "gbMensaProcessamento";
            this.gbMensaProcessamento.Size = new System.Drawing.Size(398, 123);
            this.gbMensaProcessamento.TabIndex = 43;
            this.gbMensaProcessamento.TabStop = false;
            this.gbMensaProcessamento.Text = "Atenção";
            // 
            // lblTempoFinal
            // 
            this.lblTempoFinal.AutoSize = true;
            this.lblTempoFinal.Location = new System.Drawing.Point(6, 89);
            this.lblTempoFinal.Name = "lblTempoFinal";
            this.lblTempoFinal.Size = new System.Drawing.Size(35, 13);
            this.lblTempoFinal.TabIndex = 3;
            this.lblTempoFinal.Text = "label2";
            // 
            // lblProcesso
            // 
            this.lblProcesso.AutoSize = true;
            this.lblProcesso.Location = new System.Drawing.Point(6, 27);
            this.lblProcesso.Name = "lblProcesso";
            this.lblProcesso.Size = new System.Drawing.Size(93, 13);
            this.lblProcesso.TabIndex = 2;
            this.lblProcesso.Text = "Acompanhamento";
            // 
            // pgProcesso
            // 
            this.pgProcesso.Location = new System.Drawing.Point(6, 43);
            this.pgProcesso.Name = "pgProcesso";
            this.pgProcesso.Size = new System.Drawing.Size(403, 23);
            this.pgProcesso.TabIndex = 1;
            // 
            // btProcessar
            // 
            this.btProcessar.Location = new System.Drawing.Point(251, 84);
            this.btProcessar.Name = "btProcessar";
            this.btProcessar.Size = new System.Drawing.Size(141, 23);
            this.btProcessar.TabIndex = 0;
            this.btProcessar.Tag = "0";
            this.btProcessar.Text = "Processamento";
            this.btProcessar.UseVisualStyleBackColor = true;
            this.btProcessar.Click += new System.EventHandler(this.btProcessar_Click);
            // 
            // lblFechamento
            // 
            this.lblFechamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechamento.ForeColor = System.Drawing.Color.Red;
            this.lblFechamento.Location = new System.Drawing.Point(2, 50);
            this.lblFechamento.Name = "lblFechamento";
            this.lblFechamento.Size = new System.Drawing.Size(1297, 23);
            this.lblFechamento.TabIndex = 46;
            this.lblFechamento.Text = "Fechamento";
            this.lblFechamento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCancelamentoAtivado
            // 
            this.lblCancelamentoAtivado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCancelamentoAtivado.ForeColor = System.Drawing.Color.Red;
            this.lblCancelamentoAtivado.Location = new System.Drawing.Point(7, 259);
            this.lblCancelamentoAtivado.Name = "lblCancelamentoAtivado";
            this.lblCancelamentoAtivado.Size = new System.Drawing.Size(1297, 23);
            this.lblCancelamentoAtivado.TabIndex = 47;
            this.lblCancelamentoAtivado.Text = "CANCELAMENTO SOLICITADO!";
            this.lblCancelamentoAtivado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btVoltar
            // 
            this.btVoltar.Location = new System.Drawing.Point(1218, 50);
            this.btVoltar.Name = "btVoltar";
            this.btVoltar.Size = new System.Drawing.Size(75, 23);
            this.btVoltar.TabIndex = 48;
            this.btVoltar.Text = "Voltar";
            this.btVoltar.UseVisualStyleBackColor = true;
            this.btVoltar.Visible = false;
            this.btVoltar.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormCalculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1311, 541);
            this.Controls.Add(this.btVoltar);
            this.Controls.Add(this.gbMensaProcessamento);
            this.Controls.Add(this.btExcel);
            this.Controls.Add(this.lbTituloErros);
            this.Controls.Add(this.dtGridLog);
            this.Controls.Add(this.gbAtencao);
            this.Controls.Add(this.gbData);
            this.Controls.Add(this.lbTitulo);
            this.Controls.Add(this.lblCancelamentoAtivado);
            this.Controls.Add(this.lblFechamento);
            this.Name = "FormCalculo";
            this.Text = "Calculo do estoque";
            this.Activated += new System.EventHandler(this.FormCalculo_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormCalculo_FormClosed);
            this.Load += new System.EventHandler(this.FormCalculo_Load);
            this.gbData.ResumeLayout(false);
            this.gbData.PerformLayout();
            this.gbAtencao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGridLog)).EndInit();
            this.gbMensaProcessamento.ResumeLayout(false);
            this.gbMensaProcessamento.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.GroupBox gbData;
        private System.Windows.Forms.Button btValidar;
        private System.Windows.Forms.MaskedTextBox txtDataFinal;
        private System.Windows.Forms.MaskedTextBox txtDataInicial;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox gbAtencao;
        private System.Windows.Forms.Button btPreparar;
        private System.Windows.Forms.Label lbMensaAtencao;
        private System.Windows.Forms.Button btExcel;
        private System.Windows.Forms.Label lbTituloErros;
        private System.Windows.Forms.DataGridView dtGridLog;
        private System.Windows.Forms.GroupBox gbMensaProcessamento;
        private System.Windows.Forms.Button btProcessar;
        private System.Windows.Forms.Label lblProcesso;
        private System.Windows.Forms.ProgressBar pgProcesso;
        private System.Windows.Forms.Label lblTempoFinal;
        private System.Windows.Forms.Label lblFechamento;
        private System.Windows.Forms.Label lblCancelamentoAtivado;
        private System.Windows.Forms.Button btVoltar;
    }
}