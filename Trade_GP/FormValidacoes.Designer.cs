
namespace Trade_GP
{
    partial class FormValidacoes
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
            this.gbParametros = new System.Windows.Forms.GroupBox();
            this.btParametros = new System.Windows.Forms.Button();
            this.btProximo = new System.Windows.Forms.Button();
            this.gbMensaProcessamento = new System.Windows.Forms.GroupBox();
            this.lblLocalPeriodo = new System.Windows.Forms.Label();
            this.lblProcesso = new System.Windows.Forms.Label();
            this.pgProcesso = new System.Windows.Forms.ProgressBar();
            this.btProcessar = new System.Windows.Forms.Button();
            this.btExcel = new System.Windows.Forms.Button();
            this.lbTituloMeses = new System.Windows.Forms.Label();
            this.dtGridLog = new System.Windows.Forms.DataGridView();
            this.lblCancelamentoAtivado = new System.Windows.Forms.Label();
            this.dbLocais = new System.Windows.Forms.DataGridView();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.dbMeses = new System.Windows.Forms.DataGridView();
            this.btNovo = new System.Windows.Forms.Button();
            this.gbParametros.SuspendLayout();
            this.gbMensaProcessamento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbLocais)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbMeses)).BeginInit();
            this.SuspendLayout();
            // 
            // gbParametros
            // 
            this.gbParametros.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gbParametros.Controls.Add(this.btParametros);
            this.gbParametros.Controls.Add(this.btProximo);
            this.gbParametros.Location = new System.Drawing.Point(16, 46);
            this.gbParametros.Margin = new System.Windows.Forms.Padding(4);
            this.gbParametros.Name = "gbParametros";
            this.gbParametros.Padding = new System.Windows.Forms.Padding(4);
            this.gbParametros.Size = new System.Drawing.Size(287, 151);
            this.gbParametros.TabIndex = 42;
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
            // gbMensaProcessamento
            // 
            this.gbMensaProcessamento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMensaProcessamento.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gbMensaProcessamento.Controls.Add(this.btNovo);
            this.gbMensaProcessamento.Controls.Add(this.lblLocalPeriodo);
            this.gbMensaProcessamento.Controls.Add(this.lblProcesso);
            this.gbMensaProcessamento.Controls.Add(this.pgProcesso);
            this.gbMensaProcessamento.Controls.Add(this.btProcessar);
            this.gbMensaProcessamento.Location = new System.Drawing.Point(1235, 46);
            this.gbMensaProcessamento.Margin = new System.Windows.Forms.Padding(4);
            this.gbMensaProcessamento.Name = "gbMensaProcessamento";
            this.gbMensaProcessamento.Padding = new System.Windows.Forms.Padding(4);
            this.gbMensaProcessamento.Size = new System.Drawing.Size(573, 151);
            this.gbMensaProcessamento.TabIndex = 44;
            this.gbMensaProcessamento.TabStop = false;
            this.gbMensaProcessamento.Text = "Atenção";
            // 
            // lblLocalPeriodo
            // 
            this.lblLocalPeriodo.AutoSize = true;
            this.lblLocalPeriodo.Location = new System.Drawing.Point(8, 110);
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
            this.pgProcesso.Size = new System.Drawing.Size(557, 28);
            this.pgProcesso.TabIndex = 1;
            // 
            // btProcessar
            // 
            this.btProcessar.Location = new System.Drawing.Point(258, 103);
            this.btProcessar.Margin = new System.Windows.Forms.Padding(4);
            this.btProcessar.Name = "btProcessar";
            this.btProcessar.Size = new System.Drawing.Size(150, 28);
            this.btProcessar.TabIndex = 0;
            this.btProcessar.Tag = "0";
            this.btProcessar.Text = "Processamento";
            this.btProcessar.UseVisualStyleBackColor = true;
            this.btProcessar.Click += new System.EventHandler(this.btProcessar_Click);
            // 
            // btExcel
            // 
            this.btExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btExcel.Image = global::Trade_GP.Properties.Resources.excel_logo;
            this.btExcel.Location = new System.Drawing.Point(1748, 205);
            this.btExcel.Margin = new System.Windows.Forms.Padding(4, 4, 10, 4);
            this.btExcel.Name = "btExcel";
            this.btExcel.Size = new System.Drawing.Size(60, 48);
            this.btExcel.TabIndex = 50;
            this.btExcel.UseVisualStyleBackColor = true;
            // 
            // lbTituloMeses
            // 
            this.lbTituloMeses.AutoSize = true;
            this.lbTituloMeses.Location = new System.Drawing.Point(12, 230);
            this.lbTituloMeses.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTituloMeses.Name = "lbTituloMeses";
            this.lbTituloMeses.Size = new System.Drawing.Size(49, 17);
            this.lbTituloMeses.TabIndex = 49;
            this.lbTituloMeses.Text = "Meses";
            // 
            // dtGridLog
            // 
            this.dtGridLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtGridLog.CausesValidation = false;
            this.dtGridLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridLog.Location = new System.Drawing.Point(619, 255);
            this.dtGridLog.Margin = new System.Windows.Forms.Padding(4, 4, 10, 4);
            this.dtGridLog.Name = "dtGridLog";
            this.dtGridLog.RowHeadersWidth = 51;
            this.dtGridLog.Size = new System.Drawing.Size(1189, 406);
            this.dtGridLog.TabIndex = 48;
            // 
            // lblCancelamentoAtivado
            // 
            this.lblCancelamentoAtivado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCancelamentoAtivado.ForeColor = System.Drawing.Color.Red;
            this.lblCancelamentoAtivado.Location = new System.Drawing.Point(9, 223);
            this.lblCancelamentoAtivado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCancelamentoAtivado.Name = "lblCancelamentoAtivado";
            this.lblCancelamentoAtivado.Size = new System.Drawing.Size(1729, 28);
            this.lblCancelamentoAtivado.TabIndex = 51;
            this.lblCancelamentoAtivado.Text = "CANCELAMENTO SOLICITADO!";
            this.lblCancelamentoAtivado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbLocais
            // 
            this.dbLocais.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbLocais.Location = new System.Drawing.Point(337, 46);
            this.dbLocais.Margin = new System.Windows.Forms.Padding(4);
            this.dbLocais.Name = "dbLocais";
            this.dbLocais.RowHeadersWidth = 51;
            this.dbLocais.Size = new System.Drawing.Size(877, 154);
            this.dbLocais.TabIndex = 52;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.Blue;
            this.lblTitulo.Location = new System.Drawing.Point(11, 11);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(1800, 28);
            this.lblTitulo.TabIndex = 53;
            this.lblTitulo.Text = "Validações Das Devoluções";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbMeses
            // 
            this.dbMeses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dbMeses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbMeses.Location = new System.Drawing.Point(13, 255);
            this.dbMeses.Margin = new System.Windows.Forms.Padding(4);
            this.dbMeses.Name = "dbMeses";
            this.dbMeses.RowHeadersWidth = 51;
            this.dbMeses.Size = new System.Drawing.Size(598, 406);
            this.dbMeses.TabIndex = 54;
            // 
            // btNovo
            // 
            this.btNovo.Location = new System.Drawing.Point(415, 104);
            this.btNovo.Margin = new System.Windows.Forms.Padding(4);
            this.btNovo.Name = "btNovo";
            this.btNovo.Size = new System.Drawing.Size(150, 28);
            this.btNovo.TabIndex = 4;
            this.btNovo.Tag = "0";
            this.btNovo.Text = "Novo Processamento";
            this.btNovo.UseVisualStyleBackColor = true;
            this.btNovo.Click += new System.EventHandler(this.btNovo_Click_1);
            // 
            // FormValidacoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1827, 676);
            this.Controls.Add(this.dbMeses);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.dbLocais);
            this.Controls.Add(this.btExcel);
            this.Controls.Add(this.lbTituloMeses);
            this.Controls.Add(this.dtGridLog);
            this.Controls.Add(this.lblCancelamentoAtivado);
            this.Controls.Add(this.gbMensaProcessamento);
            this.Controls.Add(this.gbParametros);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormValidacoes";
            this.Text = "Validar As Devoluções";
            this.Activated += new System.EventHandler(this.FormValidacoes_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormValidacoes_FormClosed);
            this.Load += new System.EventHandler(this.FormValidacoes_Load);
            this.gbParametros.ResumeLayout(false);
            this.gbMensaProcessamento.ResumeLayout(false);
            this.gbMensaProcessamento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbLocais)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbMeses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbParametros;
        private System.Windows.Forms.Button btParametros;
        private System.Windows.Forms.Button btProximo;
        private System.Windows.Forms.GroupBox gbMensaProcessamento;
        private System.Windows.Forms.Label lblLocalPeriodo;
        private System.Windows.Forms.Label lblProcesso;
        private System.Windows.Forms.ProgressBar pgProcesso;
        private System.Windows.Forms.Button btProcessar;
        private System.Windows.Forms.Button btExcel;
        private System.Windows.Forms.Label lbTituloMeses;
        private System.Windows.Forms.DataGridView dtGridLog;
        private System.Windows.Forms.Label lblCancelamentoAtivado;
        private System.Windows.Forms.DataGridView dbLocais;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dbMeses;
        private System.Windows.Forms.Button btNovo;
    }
}