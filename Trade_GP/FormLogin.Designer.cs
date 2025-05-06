
namespace Trade_GP
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.cbUsuarios = new System.Windows.Forms.ComboBox();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btLogin = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.cbGrupo = new System.Windows.Forms.ComboBox();
            this.lblGrupo = new System.Windows.Forms.Label();
            this.labelProjeto = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbUsuarios
            // 
            this.cbUsuarios.FormattingEnabled = true;
            this.cbUsuarios.Location = new System.Drawing.Point(381, 96);
            this.cbUsuarios.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbUsuarios.Name = "cbUsuarios";
            this.cbUsuarios.Size = new System.Drawing.Size(276, 24);
            this.cbUsuarios.TabIndex = 7;
            // 
            // btCancelar
            // 
            this.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancelar.Location = new System.Drawing.Point(551, 278);
            this.btCancelar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(100, 28);
            this.btCancelar.TabIndex = 13;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btLogin
            // 
            this.btLogin.Location = new System.Drawing.Point(415, 278);
            this.btLogin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btLogin.Name = "btLogin";
            this.btLogin.Size = new System.Drawing.Size(100, 28);
            this.btLogin.TabIndex = 12;
            this.btLogin.Text = "Login";
            this.btLogin.UseVisualStyleBackColor = true;
            this.btLogin.Click += new System.EventHandler(this.btLogin_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(31, 30);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(225, 225);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(377, 143);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Senha";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(377, 76);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Usuário";
            // 
            // txtSenha
            // 
            this.txtSenha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSenha.Location = new System.Drawing.Point(381, 162);
            this.txtSenha.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(276, 22);
            this.txtSenha.TabIndex = 8;
            // 
            // cbGrupo
            // 
            this.cbGrupo.AutoCompleteCustomSource.AddRange(new string[] {
            "Cervejaria"});
            this.cbGrupo.FormattingEnabled = true;
            this.cbGrupo.Items.AddRange(new object[] {
            "Cervejaria\t"});
            this.cbGrupo.Location = new System.Drawing.Point(380, 222);
            this.cbGrupo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbGrupo.Name = "cbGrupo";
            this.cbGrupo.Size = new System.Drawing.Size(276, 24);
            this.cbGrupo.TabIndex = 14;
            // 
            // lblGrupo
            // 
            this.lblGrupo.AutoSize = true;
            this.lblGrupo.Location = new System.Drawing.Point(383, 202);
            this.lblGrupo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(48, 17);
            this.lblGrupo.TabIndex = 15;
            this.lblGrupo.Text = "Grupo";
            // 
            // labelProjeto
            // 
            this.labelProjeto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProjeto.ForeColor = System.Drawing.Color.Red;
            this.labelProjeto.Location = new System.Drawing.Point(386, 30);
            this.labelProjeto.Name = "labelProjeto";
            this.labelProjeto.Size = new System.Drawing.Size(265, 46);
            this.labelProjeto.TabIndex = 16;
            this.labelProjeto.Text = "Projeto IPI";
            this.labelProjeto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 359);
            this.Controls.Add(this.labelProjeto);
            this.Controls.Add(this.lblGrupo);
            this.Controls.Add(this.cbGrupo);
            this.Controls.Add(this.cbUsuarios);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btLogin);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSenha);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormLogin";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbUsuarios;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btLogin;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.ComboBox cbGrupo;
        private System.Windows.Forms.Label lblGrupo;
        private System.Windows.Forms.Label labelProjeto;
    }
}