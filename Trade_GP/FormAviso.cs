using System;
using System.Windows.Forms;

namespace Trade_GP
{
    public partial class FormAviso : Form
    {
        public string Mensagem { get; set; }

        public FormAviso(string mensagem)
        {
            InitializeComponent();
            Mensagem = mensagem;

        }


        private void FormAviso_Load(object sender, EventArgs e)
        {
            if (Mensagem != "") lbMensagem.Text = Mensagem;
        }
    }
}
