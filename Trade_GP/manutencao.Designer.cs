
namespace Trade_GP
{
    partial class manutencao
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
            this.lblManutenção = new System.Windows.Forms.Label();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btOk = new System.Windows.Forms.Button();
            this.cbReindex = new System.Windows.Forms.CheckBox();
            this.cbVaccum = new System.Windows.Forms.CheckBox();
            this.lbMensagem = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblManutenção
            // 
            this.lblManutenção.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblManutenção.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManutenção.Location = new System.Drawing.Point(12, 23);
            this.lblManutenção.Name = "lblManutenção";
            this.lblManutenção.Size = new System.Drawing.Size(813, 23);
            this.lblManutenção.TabIndex = 1;
            this.lblManutenção.Text = "Manutenção Dos Arquivos";
            this.lblManutenção.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btCancelar
            // 
            this.btCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancelar.Location = new System.Drawing.Point(629, 393);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(84, 40);
            this.btCancelar.TabIndex = 2;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btOk
            // 
            this.btOk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btOk.Location = new System.Drawing.Point(728, 393);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(97, 40);
            this.btOk.TabIndex = 3;
            this.btOk.Text = "Processar";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_ClickAsync);
            // 
            // cbReindex
            // 
            this.cbReindex.AutoSize = true;
            this.cbReindex.Location = new System.Drawing.Point(39, 105);
            this.cbReindex.Name = "cbReindex";
            this.cbReindex.Size = new System.Drawing.Size(90, 21);
            this.cbReindex.TabIndex = 4;
            this.cbReindex.Text = "REINDEX";
            this.cbReindex.UseVisualStyleBackColor = true;
            // 
            // cbVaccum
            // 
            this.cbVaccum.AutoSize = true;
            this.cbVaccum.Location = new System.Drawing.Point(39, 168);
            this.cbVaccum.Name = "cbVaccum";
            this.cbVaccum.Size = new System.Drawing.Size(87, 21);
            this.cbVaccum.TabIndex = 5;
            this.cbVaccum.Text = "VACCUM";
            this.cbVaccum.UseVisualStyleBackColor = true;
            // 
            // lbMensagem
            // 
            this.lbMensagem.Location = new System.Drawing.Point(39, 253);
            this.lbMensagem.Name = "lbMensagem";
            this.lbMensagem.Size = new System.Drawing.Size(786, 23);
            this.lbMensagem.TabIndex = 6;
            this.lbMensagem.Text = "Procesando....";
            // 
            // manutencao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 467);
            this.Controls.Add(this.lbMensagem);
            this.Controls.Add(this.cbVaccum);
            this.Controls.Add(this.cbReindex);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.lblManutenção);
            this.Name = "manutencao";
            this.Text = "manutencao";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.manutencao_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblManutenção;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.CheckBox cbReindex;
        private System.Windows.Forms.CheckBox cbVaccum;
        private System.Windows.Forms.Label lbMensagem;
    }
}