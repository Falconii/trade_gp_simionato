
namespace Trade_GP
{
    partial class FormVlrEconomico
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
            this.dbLocais = new System.Windows.Forms.DataGridView();
            this.gbMensaProcessamento = new System.Windows.Forms.GroupBox();
            this.lblLocalPeriodo = new System.Windows.Forms.Label();
            this.lblProcesso = new System.Windows.Forms.Label();
            this.pgProcesso = new System.Windows.Forms.ProgressBar();
            this.btProcessar = new System.Windows.Forms.Button();
            this.gbParametros = new System.Windows.Forms.GroupBox();
            this.btParametros = new System.Windows.Forms.Button();
            this.btProximo = new System.Windows.Forms.Button();
            this.btExcel = new System.Windows.Forms.Button();
            this.lbTituloErros = new System.Windows.Forms.Label();
            this.dtGridLog = new System.Windows.Forms.DataGridView();
            this.lblCancelamentoAtivado = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.cbTipoProcessamento = new System.Windows.Forms.ComboBox();
            this.lblTipoProc = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dbLocais)).BeginInit();
            this.gbMensaProcessamento.SuspendLayout();
            this.gbParametros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridLog)).BeginInit();
            this.SuspendLayout();
            // 
            // dbLocais
            // 
            this.dbLocais.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbLocais.Location = new System.Drawing.Point(227, 27);
            this.dbLocais.Name = "dbLocais";
            this.dbLocais.Size = new System.Drawing.Size(658, 162);
            this.dbLocais.TabIndex = 55;
            // 
            // gbMensaProcessamento
            // 
            this.gbMensaProcessamento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMensaProcessamento.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gbMensaProcessamento.Controls.Add(this.lblTipoProc);
            this.gbMensaProcessamento.Controls.Add(this.cbTipoProcessamento);
            this.gbMensaProcessamento.Controls.Add(this.lblLocalPeriodo);
            this.gbMensaProcessamento.Controls.Add(this.lblProcesso);
            this.gbMensaProcessamento.Controls.Add(this.pgProcesso);
            this.gbMensaProcessamento.Controls.Add(this.btProcessar);
            this.gbMensaProcessamento.Location = new System.Drawing.Point(891, 27);
            this.gbMensaProcessamento.Name = "gbMensaProcessamento";
            this.gbMensaProcessamento.Size = new System.Drawing.Size(458, 162);
            this.gbMensaProcessamento.TabIndex = 54;
            this.gbMensaProcessamento.TabStop = false;
            this.gbMensaProcessamento.Text = "Atenção";
            // 
            // lblLocalPeriodo
            // 
            this.lblLocalPeriodo.AutoSize = true;
            this.lblLocalPeriodo.Location = new System.Drawing.Point(6, 129);
            this.lblLocalPeriodo.Name = "lblLocalPeriodo";
            this.lblLocalPeriodo.Size = new System.Drawing.Size(35, 13);
            this.lblLocalPeriodo.TabIndex = 3;
            this.lblLocalPeriodo.Text = "label2";
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
            this.pgProcesso.Size = new System.Drawing.Size(422, 23);
            this.pgProcesso.TabIndex = 1;
            // 
            // btProcessar
            // 
            this.btProcessar.Location = new System.Drawing.Point(190, 95);
            this.btProcessar.Name = "btProcessar";
            this.btProcessar.Size = new System.Drawing.Size(238, 23);
            this.btProcessar.TabIndex = 0;
            this.btProcessar.Tag = "0";
            this.btProcessar.Text = "Processamento";
            this.btProcessar.UseVisualStyleBackColor = true;
            this.btProcessar.Click += new System.EventHandler(this.btProcessar_Click);
            // 
            // gbParametros
            // 
            this.gbParametros.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gbParametros.Controls.Add(this.btParametros);
            this.gbParametros.Controls.Add(this.btProximo);
            this.gbParametros.Location = new System.Drawing.Point(6, 27);
            this.gbParametros.Name = "gbParametros";
            this.gbParametros.Size = new System.Drawing.Size(215, 162);
            this.gbParametros.TabIndex = 53;
            this.gbParametros.TabStop = false;
            this.gbParametros.Text = "Perâmetros";
            // 
            // btParametros
            // 
            this.btParametros.BackColor = System.Drawing.Color.Red;
            this.btParametros.Location = new System.Drawing.Point(15, 35);
            this.btParametros.Name = "btParametros";
            this.btParametros.Size = new System.Drawing.Size(145, 23);
            this.btParametros.TabIndex = 7;
            this.btParametros.Text = "PARÂMETROS";
            this.btParametros.UseVisualStyleBackColor = false;
            this.btParametros.Click += new System.EventHandler(this.btParametros_Click);
            // 
            // btProximo
            // 
            this.btProximo.ForeColor = System.Drawing.Color.Green;
            this.btProximo.Location = new System.Drawing.Point(109, 124);
            this.btProximo.Name = "btProximo";
            this.btProximo.Size = new System.Drawing.Size(100, 23);
            this.btProximo.TabIndex = 6;
            this.btProximo.Text = "Próximo";
            this.btProximo.UseVisualStyleBackColor = true;
            this.btProximo.Click += new System.EventHandler(this.btProximo_Click);
            // 
            // btExcel
            // 
            this.btExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btExcel.Image = global::Trade_GP.Properties.Resources.excel_logo;
            this.btExcel.Location = new System.Drawing.Point(1305, 198);
            this.btExcel.Name = "btExcel";
            this.btExcel.Size = new System.Drawing.Size(45, 39);
            this.btExcel.TabIndex = 58;
            this.btExcel.UseVisualStyleBackColor = true;
            // 
            // lbTituloErros
            // 
            this.lbTituloErros.AutoSize = true;
            this.lbTituloErros.Location = new System.Drawing.Point(3, 224);
            this.lbTituloErros.Name = "lbTituloErros";
            this.lbTituloErros.Size = new System.Drawing.Size(132, 13);
            this.lbTituloErros.TabIndex = 57;
            this.lbTituloErros.Text = "O que está em andamento";
            // 
            // dtGridLog
            // 
            this.dtGridLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtGridLog.CausesValidation = false;
            this.dtGridLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridLog.Location = new System.Drawing.Point(5, 240);
            this.dtGridLog.Name = "dtGridLog";
            this.dtGridLog.Size = new System.Drawing.Size(1347, 306);
            this.dtGridLog.TabIndex = 56;
            // 
            // lblCancelamentoAtivado
            // 
            this.lblCancelamentoAtivado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCancelamentoAtivado.ForeColor = System.Drawing.Color.Red;
            this.lblCancelamentoAtivado.Location = new System.Drawing.Point(2, 217);
            this.lblCancelamentoAtivado.Name = "lblCancelamentoAtivado";
            this.lblCancelamentoAtivado.Size = new System.Drawing.Size(1297, 23);
            this.lblCancelamentoAtivado.TabIndex = 59;
            this.lblCancelamentoAtivado.Text = "CANCELAMENTO SOLICITADO!";
            this.lblCancelamentoAtivado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.Blue;
            this.lblTitulo.Location = new System.Drawing.Point(12, 1);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(1350, 23);
            this.lblTitulo.TabIndex = 60;
            this.lblTitulo.Text = "Cálculo Do Valor Ecômico";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbTipoProcessamento
            // 
            this.cbTipoProcessamento.FormattingEnabled = true;
            this.cbTipoProcessamento.Items.AddRange(new object[] {
            "1-NORMAL",
            "2-CORREÇÃO"});
            this.cbTipoProcessamento.Location = new System.Drawing.Point(9, 95);
            this.cbTipoProcessamento.Name = "cbTipoProcessamento";
            this.cbTipoProcessamento.Size = new System.Drawing.Size(164, 21);
            this.cbTipoProcessamento.TabIndex = 4;
            // 
            // lblTipoProc
            // 
            this.lblTipoProc.AutoSize = true;
            this.lblTipoProc.Location = new System.Drawing.Point(6, 78);
            this.lblTipoProc.Name = "lblTipoProc";
            this.lblTipoProc.Size = new System.Drawing.Size(104, 13);
            this.lblTipoProc.TabIndex = 5;
            this.lblTipoProc.Text = "Tipo Processamento";
            // 
            // FormVlrEconomico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1361, 450);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btExcel);
            this.Controls.Add(this.lbTituloErros);
            this.Controls.Add(this.dtGridLog);
            this.Controls.Add(this.lblCancelamentoAtivado);
            this.Controls.Add(this.dbLocais);
            this.Controls.Add(this.gbMensaProcessamento);
            this.Controls.Add(this.gbParametros);
            this.Name = "FormVlrEconomico";
            this.Text = "Valor Economico";
            this.Activated += new System.EventHandler(this.FormVlrEconomico_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormVlrEconomico_FormClosed);
            this.Load += new System.EventHandler(this.FormVlrEconomico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dbLocais)).EndInit();
            this.gbMensaProcessamento.ResumeLayout(false);
            this.gbMensaProcessamento.PerformLayout();
            this.gbParametros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGridLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.Label lbTituloErros;
        private System.Windows.Forms.DataGridView dtGridLog;
        private System.Windows.Forms.Label lblCancelamentoAtivado;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblTipoProc;
        private System.Windows.Forms.ComboBox cbTipoProcessamento;
    }
}