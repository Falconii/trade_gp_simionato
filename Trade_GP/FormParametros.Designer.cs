
namespace Trade_GP
{
    partial class FormParametros
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
            this.panelEmpresas = new System.Windows.Forms.Panel();
            this.btBuscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbEmpresas = new System.Windows.Forms.ComboBox();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.lblLocais = new System.Windows.Forms.Label();
            this.lblPeriodo = new System.Windows.Forms.Label();
            this.tvPeriodo = new System.Windows.Forms.TreeView();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btOK = new System.Windows.Forms.Button();
            this.tvLocais = new System.Windows.Forms.TreeView();
            this.panelEmpresas.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEmpresas
            // 
            this.panelEmpresas.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelEmpresas.Controls.Add(this.btBuscar);
            this.panelEmpresas.Controls.Add(this.label1);
            this.panelEmpresas.Controls.Add(this.cbEmpresas);
            this.panelEmpresas.Location = new System.Drawing.Point(22, 37);
            this.panelEmpresas.Name = "panelEmpresas";
            this.panelEmpresas.Size = new System.Drawing.Size(242, 127);
            this.panelEmpresas.TabIndex = 0;
            // 
            // btBuscar
            // 
            this.btBuscar.Location = new System.Drawing.Point(153, 91);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(75, 23);
            this.btBuscar.TabIndex = 2;
            this.btBuscar.Text = "Buscar";
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
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
            this.cbEmpresas.Location = new System.Drawing.Point(12, 29);
            this.cbEmpresas.Name = "cbEmpresas";
            this.cbEmpresas.Size = new System.Drawing.Size(204, 21);
            this.cbEmpresas.TabIndex = 0;
            this.cbEmpresas.SelectedIndexChanged += new System.EventHandler(this.cbEmpresas_SelectedIndexChanged);
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.AutoSize = true;
            this.lblEmpresa.Location = new System.Drawing.Point(19, 21);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(53, 13);
            this.lblEmpresa.TabIndex = 1;
            this.lblEmpresa.Text = "Empresas";
            // 
            // lblLocais
            // 
            this.lblLocais.AutoSize = true;
            this.lblLocais.Location = new System.Drawing.Point(296, 21);
            this.lblLocais.Name = "lblLocais";
            this.lblLocais.Size = new System.Drawing.Size(38, 13);
            this.lblLocais.TabIndex = 3;
            this.lblLocais.Text = "Locais";
            this.lblLocais.Click += new System.EventHandler(this.lblLocais_Click);
            // 
            // lblPeriodo
            // 
            this.lblPeriodo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPeriodo.AutoSize = true;
            this.lblPeriodo.Location = new System.Drawing.Point(822, 21);
            this.lblPeriodo.Name = "lblPeriodo";
            this.lblPeriodo.Size = new System.Drawing.Size(43, 13);
            this.lblPeriodo.TabIndex = 5;
            this.lblPeriodo.Text = "Periodo";
            // 
            // tvPeriodo
            // 
            this.tvPeriodo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvPeriodo.CheckBoxes = true;
            this.tvPeriodo.Location = new System.Drawing.Point(825, 37);
            this.tvPeriodo.Name = "tvPeriodo";
            this.tvPeriodo.Size = new System.Drawing.Size(236, 395);
            this.tvPeriodo.TabIndex = 0;
            this.tvPeriodo.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvPeriodo_AfterCheck);
            // 
            // btCancelar
            // 
            this.btCancelar.Location = new System.Drawing.Point(825, 466);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(114, 23);
            this.btCancelar.TabIndex = 6;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(960, 466);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(101, 23);
            this.btOK.TabIndex = 7;
            this.btOK.Text = "Continuar";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // tvLocais
            // 
            this.tvLocais.CheckBoxes = true;
            this.tvLocais.Location = new System.Drawing.Point(299, 37);
            this.tvLocais.Name = "tvLocais";
            this.tvLocais.Size = new System.Drawing.Size(484, 395);
            this.tvLocais.TabIndex = 8;
            this.tvLocais.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvLocais_AfterCheck);
            this.tvLocais.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvLocais_AfterSelect);
            // 
            // FormParametros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 501);
            this.Controls.Add(this.tvLocais);
            this.Controls.Add(this.tvPeriodo);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.lblPeriodo);
            this.Controls.Add(this.lblLocais);
            this.Controls.Add(this.lblEmpresa);
            this.Controls.Add(this.panelEmpresas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FormParametros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parametros Para Processamento";
            this.Load += new System.EventHandler(this.FormParametros_Load);
            this.panelEmpresas.ResumeLayout(false);
            this.panelEmpresas.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelEmpresas;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.Label lblLocais;
        private System.Windows.Forms.Label lblPeriodo;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.TreeView tvPeriodo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbEmpresas;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.TreeView tvLocais;
    }
}