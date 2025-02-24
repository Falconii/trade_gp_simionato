using System;
using System.Windows.Forms;
using Trade_GP.Dao.postgre;
using Trade_GP.Models;

namespace Trade_GP
{
    public partial class FormFechamento : Form
    {
               public Fechamento fechamento { get; set; }

        private Fechamento fechamento_last = new Fechamento();
        private Fechamento fechamento_next = new Fechamento();

        public FormFechamento(Fechamento last, Fechamento next)
        {
            InitializeComponent();

            fechamento      = new Fechamento();

            fechamento_last = last;

            fechamento_next = next;

        }

        private void FormFechamento_Load(object sender, EventArgs e)
        {
            if (fechamento_last == null)
            {
                txBox_opened_descricao.Text = "";

            } else
            {
                txBox_opened_descricao.Text = fechamento_last.Descricao;
            }
            
            txNext_descricao.Text  =  fechamento_next.Descricao;

            opened((fechamento_last == null || fechamento_last.Status == "1" ) ? false : true);

            closed((fechamento_last == null || fechamento_last.Status == "1"  ) ? true : false);

        }

        private void opened(Boolean value)
        {
            gbOpened.Enabled = value;
            txBox_opened_descricao.ReadOnly = true;
            bt_opened_cancel.Enabled = value;
            bt_opened_encerrar.Enabled = value;
            bt_opened_usar.Enabled = value;
        }

        private void closed(Boolean value)
        {
            gbNext.Enabled = value;
            txNext_descricao.Enabled = value;
            bt_next_cancel.Enabled = value;
            bt_next_usar.Enabled = value;
        }

        private void bt_opened_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();

        }

        private void bt_next_cancel_Click(object sender, EventArgs e)
        {
           
            DialogResult = DialogResult.Cancel;

            Close();

        }

        private void bt_opened_usar_Click(object sender, EventArgs e)
        {
            this.fechamento = fechamento_last;

            DialogResult = DialogResult.OK;

            Close();
        }

        private void bt_next_usar_Click(object sender, EventArgs e)
        {
            if (txNext_descricao.Text.Trim() == "")
            {
                MessageBox.Show("Descrição Obrigatória");
                txNext_descricao.Focus();
                return;
            }
            this.fechamento = fechamento_next;

            this.fechamento.Descricao = txNext_descricao.Text;

            DialogResult = DialogResult.OK;

            Close();
        }

        private void bt_opened_encerrar_Click(object sender, EventArgs e)
        {
            try
            {
                daoFechamento dao = new daoFechamento();

                fechamento_last.DtFinal = DateTime.Now;

                fechamento_last.Status = "1";

                dao.Update(fechamento_last);

                opened(false);

                closed(true);

            } catch(Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }

        }
    }
}
