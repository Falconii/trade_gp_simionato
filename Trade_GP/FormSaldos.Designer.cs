
namespace Trade_GP
{
    partial class FormSaldos
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
            this.dtGridLog = new System.Windows.Forms.DataGridView();
            this.lblCancelamentoAtivado = new System.Windows.Forms.Label();
            this.lblMeses = new System.Windows.Forms.Label();
            this.dbMeses = new System.Windows.Forms.DataGridView();
            this.lblTarefas = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dbLocais)).BeginInit();
            this.gbMensaProcessamento.SuspendLayout();
            this.gbParametros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbMeses)).BeginInit();
            this.SuspendLayout();
            // 
            // dbLocais
            // 
            this.dbLocais.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbLocais.Location = new System.Drawing.Point(245, 38);
            this.dbLocais.Name = "dbLocais";
            this.dbLocais.Size = new System.Drawing.Size(658, 125);
            this.dbLocais.TabIndex = 55;
            // 
            // gbMensaProcessamento
            // 
            this.gbMensaProcessamento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMensaProcessamento.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gbMensaProcessamento.Controls.Add(this.lblLocalPeriodo);
            this.gbMensaProcessamento.Controls.Add(this.lblProcesso);
            this.gbMensaProcessamento.Controls.Add(this.pgProcesso);
            this.gbMensaProcessamento.Controls.Add(this.btProcessar);
            this.gbMensaProcessamento.Location = new System.Drawing.Point(932, 38);
            this.gbMensaProcessamento.Name = "gbMensaProcessamento";
            this.gbMensaProcessamento.Size = new System.Drawing.Size(417, 123);
            this.gbMensaProcessamento.TabIndex = 54;
            this.gbMensaProcessamento.TabStop = false;
            this.gbMensaProcessamento.Text = "Atenção";
            // 
            // lblLocalPeriodo
            // 
            this.lblLocalPeriodo.AutoSize = true;
            this.lblLocalPeriodo.Location = new System.Drawing.Point(6, 73);
            this.lblLocalPeriodo.Name = "lblLocalPeriodo";
            this.lblLocalPeriodo.Size = new System.Drawing.Size(206, 13);
            this.lblLocalPeriodo.TabIndex = 3;
            this.lblLocalPeriodo.Text = "asabanmbsnmbamnsbnmabsn   ambsasba";
            // 
            // lblProcesso
            // 
            this.lblProcesso.AutoSize = true;
            this.lblProcesso.Location = new System.Drawing.Point(6, 22);
            this.lblProcesso.Name = "lblProcesso";
            this.lblProcesso.Size = new System.Drawing.Size(93, 13);
            this.lblProcesso.TabIndex = 2;
            this.lblProcesso.Text = "Acompanhamento";
            this.lblProcesso.Click += new System.EventHandler(this.lblProcesso_Click);
            // 
            // pgProcesso
            // 
            this.pgProcesso.Location = new System.Drawing.Point(6, 38);
            this.pgProcesso.Name = "pgProcesso";
            this.pgProcesso.Size = new System.Drawing.Size(403, 23);
            this.pgProcesso.TabIndex = 1;
            this.pgProcesso.Click += new System.EventHandler(this.pgProcesso_Click);
            // 
            // btProcessar
            // 
            this.btProcessar.Location = new System.Drawing.Point(199, 94);
            this.btProcessar.Name = "btProcessar";
            this.btProcessar.Size = new System.Drawing.Size(210, 23);
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
            this.gbParametros.Location = new System.Drawing.Point(4, 38);
            this.gbParametros.Name = "gbParametros";
            this.gbParametros.Size = new System.Drawing.Size(215, 123);
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
            this.btProximo.Location = new System.Drawing.Point(108, 84);
            this.btProximo.Name = "btProximo";
            this.btProximo.Size = new System.Drawing.Size(100, 23);
            this.btProximo.TabIndex = 6;
            this.btProximo.Text = "Próximo";
            this.btProximo.UseVisualStyleBackColor = true;
            this.btProximo.Click += new System.EventHandler(this.btProximo_Click);
            // 
            // dtGridLog
            // 
            this.dtGridLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtGridLog.CausesValidation = false;
            this.dtGridLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridLog.Location = new System.Drawing.Point(515, 217);
            this.dtGridLog.Name = "dtGridLog";
            this.dtGridLog.Size = new System.Drawing.Size(834, 524);
            this.dtGridLog.TabIndex = 56;
            // 
            // lblCancelamentoAtivado
            // 
            this.lblCancelamentoAtivado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCancelamentoAtivado.ForeColor = System.Drawing.Color.Red;
            this.lblCancelamentoAtivado.Location = new System.Drawing.Point(245, 191);
            this.lblCancelamentoAtivado.Name = "lblCancelamentoAtivado";
            this.lblCancelamentoAtivado.Size = new System.Drawing.Size(1104, 23);
            this.lblCancelamentoAtivado.TabIndex = 57;
            this.lblCancelamentoAtivado.Text = "CANCELAMENTO SOLICITADO!";
            this.lblCancelamentoAtivado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMeses
            // 
            this.lblMeses.AutoSize = true;
            this.lblMeses.Location = new System.Drawing.Point(1, 201);
            this.lblMeses.Name = "lblMeses";
            this.lblMeses.Size = new System.Drawing.Size(38, 13);
            this.lblMeses.TabIndex = 58;
            this.lblMeses.Text = "Meses";
            // 
            // dbMeses
            // 
            this.dbMeses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dbMeses.CausesValidation = false;
            this.dbMeses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbMeses.Location = new System.Drawing.Point(4, 217);
            this.dbMeses.Name = "dbMeses";
            this.dbMeses.Size = new System.Drawing.Size(492, 524);
            this.dbMeses.TabIndex = 59;
            // 
            // lblTarefas
            // 
            this.lblTarefas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTarefas.AutoSize = true;
            this.lblTarefas.Location = new System.Drawing.Point(512, 198);
            this.lblTarefas.Name = "lblTarefas";
            this.lblTarefas.Size = new System.Drawing.Size(33, 13);
            this.lblTarefas.TabIndex = 60;
            this.lblTarefas.Text = "Lotes";
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.Blue;
            this.lblTitulo.Location = new System.Drawing.Point(1, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(1350, 23);
            this.lblTitulo.TabIndex = 61;
            this.lblTitulo.Text = "Cálculo Dos Saldos De Estoque";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormSaldos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 744);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblTarefas);
            this.Controls.Add(this.dbMeses);
            this.Controls.Add(this.lblMeses);
            this.Controls.Add(this.dtGridLog);
            this.Controls.Add(this.lblCancelamentoAtivado);
            this.Controls.Add(this.dbLocais);
            this.Controls.Add(this.gbMensaProcessamento);
            this.Controls.Add(this.gbParametros);
            this.Name = "FormSaldos";
            this.Text = "Saldos De Estoque";
            this.Activated += new System.EventHandler(this.FormSaldos_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormSaldos_FormClosed);
            this.Load += new System.EventHandler(this.FormSaldos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dbLocais)).EndInit();
            this.gbMensaProcessamento.ResumeLayout(false);
            this.gbMensaProcessamento.PerformLayout();
            this.gbParametros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGridLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbMeses)).EndInit();
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
        private System.Windows.Forms.DataGridView dtGridLog;
        private System.Windows.Forms.Label lblCancelamentoAtivado;
        private System.Windows.Forms.Label lblMeses;
        private System.Windows.Forms.DataGridView dbMeses;
        private System.Windows.Forms.Label lblTarefas;
        private System.Windows.Forms.Label lblTitulo;
    }
}