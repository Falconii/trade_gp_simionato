
namespace Trade_GP.Ipi.Forms
{
    partial class FormParametrosIpi
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
            this.tvLocais = new System.Windows.Forms.TreeView();
            this.tvPeriodo = new System.Windows.Forms.TreeView();
            this.lblPeriodo = new System.Windows.Forms.Label();
            this.lblLocais = new System.Windows.Forms.Label();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.panelEmpresas = new System.Windows.Forms.Panel();
            this.btBuscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbEmpresas = new System.Windows.Forms.ComboBox();
            this.btOK = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.panelEmpresas.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvLocais
            // 
            this.tvLocais.CheckBoxes = true;
            this.tvLocais.Location = new System.Drawing.Point(393, 57);
            this.tvLocais.Margin = new System.Windows.Forms.Padding(4);
            this.tvLocais.Name = "tvLocais";
            this.tvLocais.Size = new System.Drawing.Size(644, 485);
            this.tvLocais.TabIndex = 14;
            this.tvLocais.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvLocais_AfterCheck);
            this.tvLocais.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvLocais_AfterSelect);
            // 
            // tvPeriodo
            // 
            this.tvPeriodo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvPeriodo.CheckBoxes = true;
            this.tvPeriodo.Location = new System.Drawing.Point(1094, 57);
            this.tvPeriodo.Margin = new System.Windows.Forms.Padding(4);
            this.tvPeriodo.Name = "tvPeriodo";
            this.tvPeriodo.Size = new System.Drawing.Size(313, 485);
            this.tvPeriodo.TabIndex = 9;
            this.tvPeriodo.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvPeriodo_AfterCheck);
            // 
            // lblPeriodo
            // 
            this.lblPeriodo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPeriodo.AutoSize = true;
            this.lblPeriodo.Location = new System.Drawing.Point(1090, 37);
            this.lblPeriodo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPeriodo.Name = "lblPeriodo";
            this.lblPeriodo.Size = new System.Drawing.Size(57, 17);
            this.lblPeriodo.TabIndex = 13;
            this.lblPeriodo.Text = "Periodo";
            // 
            // lblLocais
            // 
            this.lblLocais.AutoSize = true;
            this.lblLocais.Location = new System.Drawing.Point(389, 37);
            this.lblLocais.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLocais.Name = "lblLocais";
            this.lblLocais.Size = new System.Drawing.Size(49, 17);
            this.lblLocais.TabIndex = 12;
            this.lblLocais.Text = "Locais";
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.AutoSize = true;
            this.lblEmpresa.Location = new System.Drawing.Point(19, 37);
            this.lblEmpresa.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(71, 17);
            this.lblEmpresa.TabIndex = 11;
            this.lblEmpresa.Text = "Empresas";
            // 
            // panelEmpresas
            // 
            this.panelEmpresas.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelEmpresas.Controls.Add(this.btBuscar);
            this.panelEmpresas.Controls.Add(this.label1);
            this.panelEmpresas.Controls.Add(this.cbEmpresas);
            this.panelEmpresas.Location = new System.Drawing.Point(23, 57);
            this.panelEmpresas.Margin = new System.Windows.Forms.Padding(4);
            this.panelEmpresas.Name = "panelEmpresas";
            this.panelEmpresas.Size = new System.Drawing.Size(323, 156);
            this.panelEmpresas.TabIndex = 10;
            // 
            // btBuscar
            // 
            this.btBuscar.Location = new System.Drawing.Point(204, 112);
            this.btBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(100, 28);
            this.btBuscar.TabIndex = 2;
            this.btBuscar.Text = "Buscar";
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Empresas";
            // 
            // cbEmpresas
            // 
            this.cbEmpresas.FormattingEnabled = true;
            this.cbEmpresas.Items.AddRange(new object[] {
            "1001 – CPSA, ",
            "1002 – CPCO, ",
            "1003 – CPBA, ",
            "1004 – CPPE."});
            this.cbEmpresas.Location = new System.Drawing.Point(16, 36);
            this.cbEmpresas.Margin = new System.Windows.Forms.Padding(4);
            this.cbEmpresas.Name = "cbEmpresas";
            this.cbEmpresas.Size = new System.Drawing.Size(271, 24);
            this.cbEmpresas.TabIndex = 0;
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(1273, 580);
            this.btOK.Margin = new System.Windows.Forms.Padding(4);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(135, 28);
            this.btOK.TabIndex = 16;
            this.btOK.Text = "Continuar";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click_1);
            // 
            // btCancelar
            // 
            this.btCancelar.Location = new System.Drawing.Point(1093, 580);
            this.btCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(152, 28);
            this.btCancelar.TabIndex = 15;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click_1);
            // 
            // FormParametrosIpi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1435, 621);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.tvLocais);
            this.Controls.Add(this.tvPeriodo);
            this.Controls.Add(this.lblPeriodo);
            this.Controls.Add(this.lblLocais);
            this.Controls.Add(this.lblEmpresa);
            this.Controls.Add(this.panelEmpresas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FormParametrosIpi";
            this.Text = "Parâmetros IPI";
            this.Load += new System.EventHandler(this.FormParametrosIpi_Load);
            this.panelEmpresas.ResumeLayout(false);
            this.panelEmpresas.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvLocais;
        private System.Windows.Forms.TreeView tvPeriodo;
        private System.Windows.Forms.Label lblPeriodo;
        private System.Windows.Forms.Label lblLocais;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.Panel panelEmpresas;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbEmpresas;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btCancelar;
    }
}