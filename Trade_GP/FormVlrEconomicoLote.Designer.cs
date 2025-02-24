
namespace Trade_GP
{
    partial class FormVlrEconomicoLotes
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
            this.lblCancelamentoAtivado = new System.Windows.Forms.Label();
            this.dbMeses = new System.Windows.Forms.DataGridView();
            this.lblMeses = new System.Windows.Forms.Label();
            this.lblTarefas = new System.Windows.Forms.Label();
            this.dtGridLog = new System.Windows.Forms.DataGridView();
            this.gbMensaProcessamento = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSelic = new System.Windows.Forms.ComboBox();
            this.lblTipoProc = new System.Windows.Forms.Label();
            this.cbTipoProcessamento = new System.Windows.Forms.ComboBox();
            this.lblLocalPeriodo = new System.Windows.Forms.Label();
            this.lblProcesso = new System.Windows.Forms.Label();
            this.pgProcesso = new System.Windows.Forms.ProgressBar();
            this.btProcessar = new System.Windows.Forms.Button();
            this.btNovo = new System.Windows.Forms.Button();
            this.gbParametros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbLocais)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbMeses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridLog)).BeginInit();
            this.gbMensaProcessamento.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.Blue;
            this.lblTitulo.Location = new System.Drawing.Point(-4, 25);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(2065, 28);
            this.lblTitulo.TabIndex = 62;
            this.lblTitulo.Text = "Cálculo Do Valor Ecômico Por Lote";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitulo.Click += new System.EventHandler(this.lblTitulo_Click);
            // 
            // gbParametros
            // 
            this.gbParametros.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gbParametros.Controls.Add(this.btParametros);
            this.gbParametros.Controls.Add(this.btProximo);
            this.gbParametros.Location = new System.Drawing.Point(0, 68);
            this.gbParametros.Margin = new System.Windows.Forms.Padding(4);
            this.gbParametros.Name = "gbParametros";
            this.gbParametros.Padding = new System.Windows.Forms.Padding(4);
            this.gbParametros.Size = new System.Drawing.Size(287, 199);
            this.gbParametros.TabIndex = 63;
            this.gbParametros.TabStop = false;
            this.gbParametros.Text = "Perâmetros";
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
            this.btProximo.Location = new System.Drawing.Point(144, 103);
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
            this.dbLocais.Location = new System.Drawing.Point(295, 68);
            this.dbLocais.Margin = new System.Windows.Forms.Padding(4);
            this.dbLocais.Name = "dbLocais";
            this.dbLocais.RowHeadersWidth = 51;
            this.dbLocais.Size = new System.Drawing.Size(941, 199);
            this.dbLocais.TabIndex = 64;
            // 
            // lblCancelamentoAtivado
            // 
            this.lblCancelamentoAtivado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCancelamentoAtivado.ForeColor = System.Drawing.Color.Red;
            this.lblCancelamentoAtivado.Location = new System.Drawing.Point(16, 289);
            this.lblCancelamentoAtivado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCancelamentoAtivado.Name = "lblCancelamentoAtivado";
            this.lblCancelamentoAtivado.Size = new System.Drawing.Size(1783, 28);
            this.lblCancelamentoAtivado.TabIndex = 66;
            this.lblCancelamentoAtivado.Text = "CANCELAMENTO SOLICITADO!";
            this.lblCancelamentoAtivado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCancelamentoAtivado.Click += new System.EventHandler(this.lblCancelamentoAtivado_Click);
            // 
            // dbMeses
            // 
            this.dbMeses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dbMeses.CausesValidation = false;
            this.dbMeses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbMeses.Location = new System.Drawing.Point(16, 354);
            this.dbMeses.Margin = new System.Windows.Forms.Padding(4);
            this.dbMeses.Name = "dbMeses";
            this.dbMeses.RowHeadersWidth = 51;
            this.dbMeses.Size = new System.Drawing.Size(656, 453);
            this.dbMeses.TabIndex = 68;
            // 
            // lblMeses
            // 
            this.lblMeses.AutoSize = true;
            this.lblMeses.Location = new System.Drawing.Point(16, 335);
            this.lblMeses.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMeses.Name = "lblMeses";
            this.lblMeses.Size = new System.Drawing.Size(49, 17);
            this.lblMeses.TabIndex = 67;
            this.lblMeses.Text = "Meses";
            // 
            // lblTarefas
            // 
            this.lblTarefas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTarefas.AutoSize = true;
            this.lblTarefas.Location = new System.Drawing.Point(732, 335);
            this.lblTarefas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTarefas.Name = "lblTarefas";
            this.lblTarefas.Size = new System.Drawing.Size(43, 17);
            this.lblTarefas.TabIndex = 70;
            this.lblTarefas.Text = "Lotes";
            // 
            // dtGridLog
            // 
            this.dtGridLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtGridLog.CausesValidation = false;
            this.dtGridLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridLog.Location = new System.Drawing.Point(689, 354);
            this.dtGridLog.Margin = new System.Windows.Forms.Padding(4);
            this.dtGridLog.Name = "dtGridLog";
            this.dtGridLog.RowHeadersWidth = 51;
            this.dtGridLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dtGridLog.Size = new System.Drawing.Size(1150, 453);
            this.dtGridLog.TabIndex = 69;
            // 
            // gbMensaProcessamento
            // 
            this.gbMensaProcessamento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMensaProcessamento.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gbMensaProcessamento.Controls.Add(this.btNovo);
            this.gbMensaProcessamento.Controls.Add(this.label1);
            this.gbMensaProcessamento.Controls.Add(this.cbSelic);
            this.gbMensaProcessamento.Controls.Add(this.lblTipoProc);
            this.gbMensaProcessamento.Controls.Add(this.cbTipoProcessamento);
            this.gbMensaProcessamento.Controls.Add(this.lblLocalPeriodo);
            this.gbMensaProcessamento.Controls.Add(this.lblProcesso);
            this.gbMensaProcessamento.Controls.Add(this.pgProcesso);
            this.gbMensaProcessamento.Controls.Add(this.btProcessar);
            this.gbMensaProcessamento.Location = new System.Drawing.Point(1244, 68);
            this.gbMensaProcessamento.Margin = new System.Windows.Forms.Padding(4);
            this.gbMensaProcessamento.Name = "gbMensaProcessamento";
            this.gbMensaProcessamento.Padding = new System.Windows.Forms.Padding(4);
            this.gbMensaProcessamento.Size = new System.Drawing.Size(592, 199);
            this.gbMensaProcessamento.TabIndex = 71;
            this.gbMensaProcessamento.TabStop = false;
            this.gbMensaProcessamento.Text = "Atenção";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(249, 96);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Selic";
            // 
            // cbSelic
            // 
            this.cbSelic.FormattingEnabled = true;
            this.cbSelic.Items.AddRange(new object[] {
            "01/2025",
            "02/2025",
            "03/2025"});
            this.cbSelic.Location = new System.Drawing.Point(253, 119);
            this.cbSelic.Margin = new System.Windows.Forms.Padding(4);
            this.cbSelic.Name = "cbSelic";
            this.cbSelic.Size = new System.Drawing.Size(302, 24);
            this.cbSelic.TabIndex = 6;
            // 
            // lblTipoProc
            // 
            this.lblTipoProc.AutoSize = true;
            this.lblTipoProc.Location = new System.Drawing.Point(8, 96);
            this.lblTipoProc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTipoProc.Name = "lblTipoProc";
            this.lblTipoProc.Size = new System.Drawing.Size(138, 17);
            this.lblTipoProc.TabIndex = 5;
            this.lblTipoProc.Text = "Tipo Processamento";
            // 
            // cbTipoProcessamento
            // 
            this.cbTipoProcessamento.FormattingEnabled = true;
            this.cbTipoProcessamento.Items.AddRange(new object[] {
            "1-NORMAL",
            "2-CORREÇÃO",
            "3-ATUALIZAÇÃO"});
            this.cbTipoProcessamento.Location = new System.Drawing.Point(12, 117);
            this.cbTipoProcessamento.Margin = new System.Windows.Forms.Padding(4);
            this.cbTipoProcessamento.Name = "cbTipoProcessamento";
            this.cbTipoProcessamento.Size = new System.Drawing.Size(217, 24);
            this.cbTipoProcessamento.TabIndex = 4;
            // 
            // lblLocalPeriodo
            // 
            this.lblLocalPeriodo.AutoSize = true;
            this.lblLocalPeriodo.Location = new System.Drawing.Point(8, 159);
            this.lblLocalPeriodo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLocalPeriodo.Name = "lblLocalPeriodo";
            this.lblLocalPeriodo.Size = new System.Drawing.Size(46, 17);
            this.lblLocalPeriodo.TabIndex = 3;
            this.lblLocalPeriodo.Text = "label2";
            // 
            // lblProcesso
            // 
            this.lblProcesso.AutoSize = true;
            this.lblProcesso.Location = new System.Drawing.Point(8, 33);
            this.lblProcesso.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProcesso.Name = "lblProcesso";
            this.lblProcesso.Size = new System.Drawing.Size(122, 17);
            this.lblProcesso.TabIndex = 2;
            this.lblProcesso.Text = "Acompanhamento";
            // 
            // pgProcesso
            // 
            this.pgProcesso.Location = new System.Drawing.Point(8, 53);
            this.pgProcesso.Margin = new System.Windows.Forms.Padding(4);
            this.pgProcesso.Name = "pgProcesso";
            this.pgProcesso.Size = new System.Drawing.Size(547, 28);
            this.pgProcesso.TabIndex = 1;
            // 
            // btProcessar
            // 
            this.btProcessar.Location = new System.Drawing.Point(277, 159);
            this.btProcessar.Margin = new System.Windows.Forms.Padding(4);
            this.btProcessar.Name = "btProcessar";
            this.btProcessar.Size = new System.Drawing.Size(135, 28);
            this.btProcessar.TabIndex = 0;
            this.btProcessar.Tag = "0";
            this.btProcessar.Text = "Processamento";
            this.btProcessar.UseVisualStyleBackColor = true;
            this.btProcessar.Click += new System.EventHandler(this.btProcessar_Click);
            // 
            // btNovo
            // 
            this.btNovo.Location = new System.Drawing.Point(420, 159);
            this.btNovo.Margin = new System.Windows.Forms.Padding(4);
            this.btNovo.Name = "btNovo";
            this.btNovo.Size = new System.Drawing.Size(135, 28);
            this.btNovo.TabIndex = 8;
            this.btNovo.Tag = "0";
            this.btNovo.Text = "Novo Proc.";
            this.btNovo.UseVisualStyleBackColor = true;
            this.btNovo.Click += new System.EventHandler(this.btNovo_Click);
            // 
            // FormVlrEconomicoLotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1852, 820);
            this.Controls.Add(this.gbMensaProcessamento);
            this.Controls.Add(this.lblTarefas);
            this.Controls.Add(this.dtGridLog);
            this.Controls.Add(this.dbMeses);
            this.Controls.Add(this.lblMeses);
            this.Controls.Add(this.lblCancelamentoAtivado);
            this.Controls.Add(this.dbLocais);
            this.Controls.Add(this.gbParametros);
            this.Controls.Add(this.lblTitulo);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormVlrEconomicoLotes";
            this.Text = "Calculo Valor Econômico Por Lote";
            this.Activated += new System.EventHandler(this.FormVlrEconomicoLotes_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormVlrEconomicoLotes_FormClosed);
            this.Load += new System.EventHandler(this.FormVlrEconomicoLotes_Load);
            this.gbParametros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dbLocais)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbMeses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridLog)).EndInit();
            this.gbMensaProcessamento.ResumeLayout(false);
            this.gbMensaProcessamento.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox gbParametros;
        private System.Windows.Forms.Button btParametros;
        private System.Windows.Forms.Button btProximo;
        private System.Windows.Forms.DataGridView dbLocais;
        private System.Windows.Forms.Label lblCancelamentoAtivado;
        private System.Windows.Forms.DataGridView dbMeses;
        private System.Windows.Forms.Label lblMeses;
        private System.Windows.Forms.Label lblTarefas;
        private System.Windows.Forms.DataGridView dtGridLog;
        private System.Windows.Forms.GroupBox gbMensaProcessamento;
        private System.Windows.Forms.Label lblTipoProc;
        private System.Windows.Forms.ComboBox cbTipoProcessamento;
        private System.Windows.Forms.Label lblLocalPeriodo;
        private System.Windows.Forms.Label lblProcesso;
        private System.Windows.Forms.ProgressBar pgProcesso;
        private System.Windows.Forms.Button btProcessar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbSelic;
        private System.Windows.Forms.Button btNovo;
    }
}