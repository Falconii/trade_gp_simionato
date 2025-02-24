
namespace Trade_GP
{
    partial class FormFechamento
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
            this.gbNext = new System.Windows.Forms.GroupBox();
            this.bt_next_usar = new System.Windows.Forms.Button();
            this.lbl_next_descricao = new System.Windows.Forms.Label();
            this.txNext_descricao = new System.Windows.Forms.TextBox();
            this.bt_next_cancel = new System.Windows.Forms.Button();
            this.gbOpened = new System.Windows.Forms.GroupBox();
            this.bt_opened_usar = new System.Windows.Forms.Button();
            this.lblOpened_Descricao = new System.Windows.Forms.Label();
            this.txBox_opened_descricao = new System.Windows.Forms.TextBox();
            this.bt_opened_encerrar = new System.Windows.Forms.Button();
            this.bt_opened_cancel = new System.Windows.Forms.Button();
            this.gbNext.SuspendLayout();
            this.gbOpened.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbNext
            // 
            this.gbNext.Controls.Add(this.bt_next_usar);
            this.gbNext.Controls.Add(this.lbl_next_descricao);
            this.gbNext.Controls.Add(this.txNext_descricao);
            this.gbNext.Controls.Add(this.bt_next_cancel);
            this.gbNext.Location = new System.Drawing.Point(26, 121);
            this.gbNext.Name = "gbNext";
            this.gbNext.Size = new System.Drawing.Size(707, 90);
            this.gbNext.TabIndex = 5;
            this.gbNext.TabStop = false;
            this.gbNext.Text = "Proximo Fechamento";
            // 
            // bt_next_usar
            // 
            this.bt_next_usar.Location = new System.Drawing.Point(626, 45);
            this.bt_next_usar.Name = "bt_next_usar";
            this.bt_next_usar.Size = new System.Drawing.Size(75, 23);
            this.bt_next_usar.TabIndex = 8;
            this.bt_next_usar.Text = "Usar";
            this.bt_next_usar.UseVisualStyleBackColor = true;
            this.bt_next_usar.Click += new System.EventHandler(this.bt_next_usar_Click);
            // 
            // lbl_next_descricao
            // 
            this.lbl_next_descricao.AutoSize = true;
            this.lbl_next_descricao.Location = new System.Drawing.Point(17, 26);
            this.lbl_next_descricao.Name = "lbl_next_descricao";
            this.lbl_next_descricao.Size = new System.Drawing.Size(86, 13);
            this.lbl_next_descricao.TabIndex = 7;
            this.lbl_next_descricao.Text = "Breve Descrição";
            // 
            // txNext_descricao
            // 
            this.txNext_descricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txNext_descricao.Location = new System.Drawing.Point(17, 47);
            this.txNext_descricao.Name = "txNext_descricao";
            this.txNext_descricao.Size = new System.Drawing.Size(399, 20);
            this.txNext_descricao.TabIndex = 6;
            // 
            // bt_next_cancel
            // 
            this.bt_next_cancel.Location = new System.Drawing.Point(535, 45);
            this.bt_next_cancel.Name = "bt_next_cancel";
            this.bt_next_cancel.Size = new System.Drawing.Size(75, 23);
            this.bt_next_cancel.TabIndex = 7;
            this.bt_next_cancel.Text = "Cancelar";
            this.bt_next_cancel.UseVisualStyleBackColor = true;
            this.bt_next_cancel.Click += new System.EventHandler(this.bt_next_cancel_Click);
            // 
            // gbOpened
            // 
            this.gbOpened.Controls.Add(this.bt_opened_usar);
            this.gbOpened.Controls.Add(this.lblOpened_Descricao);
            this.gbOpened.Controls.Add(this.txBox_opened_descricao);
            this.gbOpened.Controls.Add(this.bt_opened_encerrar);
            this.gbOpened.Controls.Add(this.bt_opened_cancel);
            this.gbOpened.Location = new System.Drawing.Point(26, 12);
            this.gbOpened.Name = "gbOpened";
            this.gbOpened.Size = new System.Drawing.Size(707, 90);
            this.gbOpened.TabIndex = 0;
            this.gbOpened.TabStop = false;
            this.gbOpened.Text = "Ultimo Fechamento";
            // 
            // bt_opened_usar
            // 
            this.bt_opened_usar.Location = new System.Drawing.Point(626, 45);
            this.bt_opened_usar.Name = "bt_opened_usar";
            this.bt_opened_usar.Size = new System.Drawing.Size(75, 23);
            this.bt_opened_usar.TabIndex = 4;
            this.bt_opened_usar.Text = "Usar";
            this.bt_opened_usar.UseVisualStyleBackColor = true;
            this.bt_opened_usar.Click += new System.EventHandler(this.bt_opened_usar_Click);
            // 
            // lblOpened_Descricao
            // 
            this.lblOpened_Descricao.AutoSize = true;
            this.lblOpened_Descricao.Location = new System.Drawing.Point(17, 26);
            this.lblOpened_Descricao.Name = "lblOpened_Descricao";
            this.lblOpened_Descricao.Size = new System.Drawing.Size(98, 13);
            this.lblOpened_Descricao.TabIndex = 7;
            this.lblOpened_Descricao.Text = "Último Fechamento";
            this.lblOpened_Descricao.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // txBox_opened_descricao
            // 
            this.txBox_opened_descricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txBox_opened_descricao.Location = new System.Drawing.Point(17, 47);
            this.txBox_opened_descricao.Name = "txBox_opened_descricao";
            this.txBox_opened_descricao.Size = new System.Drawing.Size(399, 20);
            this.txBox_opened_descricao.TabIndex = 1;
            // 
            // bt_opened_encerrar
            // 
            this.bt_opened_encerrar.Location = new System.Drawing.Point(535, 45);
            this.bt_opened_encerrar.Name = "bt_opened_encerrar";
            this.bt_opened_encerrar.Size = new System.Drawing.Size(75, 23);
            this.bt_opened_encerrar.TabIndex = 3;
            this.bt_opened_encerrar.Text = "Encerrar";
            this.bt_opened_encerrar.UseVisualStyleBackColor = true;
            this.bt_opened_encerrar.Click += new System.EventHandler(this.bt_opened_encerrar_Click);
            // 
            // bt_opened_cancel
            // 
            this.bt_opened_cancel.Location = new System.Drawing.Point(442, 45);
            this.bt_opened_cancel.Name = "bt_opened_cancel";
            this.bt_opened_cancel.Size = new System.Drawing.Size(75, 23);
            this.bt_opened_cancel.TabIndex = 2;
            this.bt_opened_cancel.Text = "Cancelar";
            this.bt_opened_cancel.UseVisualStyleBackColor = true;
            this.bt_opened_cancel.Click += new System.EventHandler(this.bt_opened_cancel_Click);
            // 
            // FormFechamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 228);
            this.Controls.Add(this.gbOpened);
            this.Controls.Add(this.gbNext);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormFechamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro De Fechamentos";
            this.Load += new System.EventHandler(this.FormFechamento_Load);
            this.gbNext.ResumeLayout(false);
            this.gbNext.PerformLayout();
            this.gbOpened.ResumeLayout(false);
            this.gbOpened.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbNext;
        private System.Windows.Forms.Button bt_next_usar;
        private System.Windows.Forms.Label lbl_next_descricao;
        private System.Windows.Forms.TextBox txNext_descricao;
        private System.Windows.Forms.Button bt_next_cancel;
        private System.Windows.Forms.GroupBox gbOpened;
        private System.Windows.Forms.Button bt_opened_usar;
        private System.Windows.Forms.Label lblOpened_Descricao;
        private System.Windows.Forms.TextBox txBox_opened_descricao;
        private System.Windows.Forms.Button bt_opened_encerrar;
        private System.Windows.Forms.Button bt_opened_cancel;
    }
}