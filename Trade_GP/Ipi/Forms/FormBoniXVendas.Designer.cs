
namespace Trade_GP.Ipi.Forms
{
    partial class FormBoniXVendas
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbSelic = new System.Windows.Forms.ComboBox();
            this.btNovo = new System.Windows.Forms.Button();
            this.lblLocalPeriodo = new System.Windows.Forms.Label();
            this.lblProcesso = new System.Windows.Forms.Label();
            this.pgProcesso = new System.Windows.Forms.ProgressBar();
            this.btProcessar = new System.Windows.Forms.Button();
            this.lblTarefas = new System.Windows.Forms.Label();
            this.lblMeses = new System.Windows.Forms.Label();
            this.lblCancelamentoAtivado = new System.Windows.Forms.Label();
            this.dbMeses = new System.Windows.Forms.DataGridView();
            this.dtGridLog = new System.Windows.Forms.DataGridView();
            this.gbParametros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbLocais)).BeginInit();
            this.gbMensaProcessamento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbMeses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridLog)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.Blue;
            this.lblTitulo.Location = new System.Drawing.Point(8, 9);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(1903, 28);
            this.lblTitulo.TabIndex = 64;
            this.lblTitulo.Text = "Notas Bonificação X Vendas";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbParametros
            // 
            this.gbParametros.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gbParametros.Controls.Add(this.btParametros);
            this.gbParametros.Controls.Add(this.btProximo);
            this.gbParametros.Location = new System.Drawing.Point(13, 41);
            this.gbParametros.Margin = new System.Windows.Forms.Padding(4);
            this.gbParametros.Name = "gbParametros";
            this.gbParametros.Padding = new System.Windows.Forms.Padding(4);
            this.gbParametros.Size = new System.Drawing.Size(287, 235);
            this.gbParametros.TabIndex = 65;
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
            this.btProximo.Location = new System.Drawing.Point(135, 156);
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
            this.dbLocais.Location = new System.Drawing.Point(318, 41);
            this.dbLocais.Margin = new System.Windows.Forms.Padding(4);
            this.dbLocais.Name = "dbLocais";
            this.dbLocais.RowHeadersWidth = 51;
            this.dbLocais.Size = new System.Drawing.Size(952, 235);
            this.dbLocais.TabIndex = 66;
            // 
            // gbMensaProcessamento
            // 
            this.gbMensaProcessamento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMensaProcessamento.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gbMensaProcessamento.Controls.Add(this.label1);
            this.gbMensaProcessamento.Controls.Add(this.cbSelic);
            this.gbMensaProcessamento.Controls.Add(this.btNovo);
            this.gbMensaProcessamento.Controls.Add(this.lblLocalPeriodo);
            this.gbMensaProcessamento.Controls.Add(this.lblProcesso);
            this.gbMensaProcessamento.Controls.Add(this.pgProcesso);
            this.gbMensaProcessamento.Controls.Add(this.btProcessar);
            this.gbMensaProcessamento.Location = new System.Drawing.Point(1290, 44);
            this.gbMensaProcessamento.Margin = new System.Windows.Forms.Padding(4);
            this.gbMensaProcessamento.Name = "gbMensaProcessamento";
            this.gbMensaProcessamento.Padding = new System.Windows.Forms.Padding(4);
            this.gbMensaProcessamento.Size = new System.Drawing.Size(621, 232);
            this.gbMensaProcessamento.TabIndex = 67;
            this.gbMensaProcessamento.TabStop = false;
            this.gbMensaProcessamento.Text = "Atenção";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 96);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Selic";
            // 
            // cbSelic
            // 
            this.cbSelic.FormattingEnabled = true;
            this.cbSelic.Items.AddRange(new object[] {
            "01/2025",
            "02/2025",
            "03/2025"});
            this.cbSelic.Location = new System.Drawing.Point(11, 119);
            this.cbSelic.Margin = new System.Windows.Forms.Padding(4);
            this.cbSelic.Name = "cbSelic";
            this.cbSelic.Size = new System.Drawing.Size(574, 24);
            this.cbSelic.TabIndex = 8;
            // 
            // btNovo
            // 
            this.btNovo.Location = new System.Drawing.Point(435, 195);
            this.btNovo.Margin = new System.Windows.Forms.Padding(4);
            this.btNovo.Name = "btNovo";
            this.btNovo.Size = new System.Drawing.Size(156, 28);
            this.btNovo.TabIndex = 4;
            this.btNovo.Tag = "0";
            this.btNovo.Text = "Novo Processamento";
            this.btNovo.UseVisualStyleBackColor = true;
            this.btNovo.Click += new System.EventHandler(this.btNovo_Click);
            // 
            // lblLocalPeriodo
            // 
            this.lblLocalPeriodo.AutoSize = true;
            this.lblLocalPeriodo.Location = new System.Drawing.Point(8, 164);
            this.lblLocalPeriodo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLocalPeriodo.Name = "lblLocalPeriodo";
            this.lblLocalPeriodo.Size = new System.Drawing.Size(277, 17);
            this.lblLocalPeriodo.TabIndex = 3;
            this.lblLocalPeriodo.Text = "asabanmbsnmbamnsbnmabsn   ambsasba";
            // 
            // lblProcesso
            // 
            this.lblProcesso.AutoSize = true;
            this.lblProcesso.Location = new System.Drawing.Point(8, 27);
            this.lblProcesso.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProcesso.Name = "lblProcesso";
            this.lblProcesso.Size = new System.Drawing.Size(122, 17);
            this.lblProcesso.TabIndex = 2;
            this.lblProcesso.Text = "Acompanhamento";
            // 
            // pgProcesso
            // 
            this.pgProcesso.Location = new System.Drawing.Point(8, 47);
            this.pgProcesso.Margin = new System.Windows.Forms.Padding(4);
            this.pgProcesso.Name = "pgProcesso";
            this.pgProcesso.Size = new System.Drawing.Size(577, 28);
            this.pgProcesso.TabIndex = 1;
            // 
            // btProcessar
            // 
            this.btProcessar.Location = new System.Drawing.Point(271, 196);
            this.btProcessar.Margin = new System.Windows.Forms.Padding(4);
            this.btProcessar.Name = "btProcessar";
            this.btProcessar.Size = new System.Drawing.Size(156, 28);
            this.btProcessar.TabIndex = 0;
            this.btProcessar.Tag = "0";
            this.btProcessar.Text = "Processamento";
            this.btProcessar.UseVisualStyleBackColor = true;
            this.btProcessar.Click += new System.EventHandler(this.btProcessar_Click);
            // 
            // lblTarefas
            // 
            this.lblTarefas.AutoSize = true;
            this.lblTarefas.Location = new System.Drawing.Point(696, 324);
            this.lblTarefas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTarefas.Name = "lblTarefas";
            this.lblTarefas.Size = new System.Drawing.Size(43, 17);
            this.lblTarefas.TabIndex = 75;
            this.lblTarefas.Text = "Lotes";
            this.lblTarefas.Click += new System.EventHandler(this.lblTarefas_Click);
            // 
            // lblMeses
            // 
            this.lblMeses.AutoSize = true;
            this.lblMeses.Location = new System.Drawing.Point(13, 324);
            this.lblMeses.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMeses.Name = "lblMeses";
            this.lblMeses.Size = new System.Drawing.Size(49, 17);
            this.lblMeses.TabIndex = 74;
            this.lblMeses.Text = "Meses";
            // 
            // lblCancelamentoAtivado
            // 
            this.lblCancelamentoAtivado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCancelamentoAtivado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCancelamentoAtivado.ForeColor = System.Drawing.Color.Red;
            this.lblCancelamentoAtivado.Location = new System.Drawing.Point(16, 296);
            this.lblCancelamentoAtivado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCancelamentoAtivado.Name = "lblCancelamentoAtivado";
            this.lblCancelamentoAtivado.Size = new System.Drawing.Size(1900, 28);
            this.lblCancelamentoAtivado.TabIndex = 73;
            this.lblCancelamentoAtivado.Text = "CANCELAMENTO SOLICITADO!";
            this.lblCancelamentoAtivado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbMeses
            // 
            this.dbMeses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dbMeses.CausesValidation = false;
            this.dbMeses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbMeses.Location = new System.Drawing.Point(13, 345);
            this.dbMeses.Margin = new System.Windows.Forms.Padding(4);
            this.dbMeses.Name = "dbMeses";
            this.dbMeses.RowHeadersWidth = 51;
            this.dbMeses.Size = new System.Drawing.Size(656, 320);
            this.dbMeses.TabIndex = 76;
            // 
            // dtGridLog
            // 
            this.dtGridLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtGridLog.CausesValidation = false;
            this.dtGridLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridLog.Location = new System.Drawing.Point(699, 345);
            this.dtGridLog.Margin = new System.Windows.Forms.Padding(4);
            this.dtGridLog.Name = "dtGridLog";
            this.dtGridLog.RowHeadersWidth = 51;
            this.dtGridLog.Size = new System.Drawing.Size(1212, 320);
            this.dtGridLog.TabIndex = 77;
            // 
            // FormBoniXVendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 678);
            this.Controls.Add(this.dtGridLog);
            this.Controls.Add(this.dbMeses);
            this.Controls.Add(this.lblTarefas);
            this.Controls.Add(this.lblMeses);
            this.Controls.Add(this.lblCancelamentoAtivado);
            this.Controls.Add(this.gbMensaProcessamento);
            this.Controls.Add(this.dbLocais);
            this.Controls.Add(this.gbParametros);
            this.Controls.Add(this.lblTitulo);
            this.Name = "FormBoniXVendas";
            this.Text = "Cruzamento Bonificaçãoes x Vendas";
            this.Activated += new System.EventHandler(this.FormBoniXVendas_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormBoniXVendas_FormClosed);
            this.Load += new System.EventHandler(this.FormBoniXVendas_Load);
            this.gbParametros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dbLocais)).EndInit();
            this.gbMensaProcessamento.ResumeLayout(false);
            this.gbMensaProcessamento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbMeses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox gbParametros;
        private System.Windows.Forms.Button btParametros;
        private System.Windows.Forms.Button btProximo;
        private System.Windows.Forms.DataGridView dbLocais;
        private System.Windows.Forms.GroupBox gbMensaProcessamento;
        private System.Windows.Forms.Button btNovo;
        private System.Windows.Forms.Label lblLocalPeriodo;
        private System.Windows.Forms.Label lblProcesso;
        private System.Windows.Forms.ProgressBar pgProcesso;
        private System.Windows.Forms.Button btProcessar;
        private System.Windows.Forms.Label lblTarefas;
        private System.Windows.Forms.Label lblMeses;
        private System.Windows.Forms.Label lblCancelamentoAtivado;
        private System.Windows.Forms.DataGridView dbMeses;
        private System.Windows.Forms.DataGridView dtGridLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbSelic;
    }
}