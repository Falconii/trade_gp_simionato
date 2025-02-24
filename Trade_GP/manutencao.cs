using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trade_GP.Dao.postgre;

namespace Trade_GP
{
    public partial class manutencao : Form
    {
        public manutencao()
        {
            InitializeComponent();
        }


        private void manutencao_Load(object sender, EventArgs e)
        {
            posicaoProcessar();
        }

        private void posicaoProcessar()
        {
            lbMensagem.Visible = false;
            cbReindex.Enabled = true;
            cbVaccum.Enabled = true;
            cbReindex.Checked = false;
            cbVaccum.Checked = false;
            btOk.Enabled = true;
            btCancelar.Enabled = true;
        }

        private void posicaoProcessando()
        {
            lbMensagem.Visible = true;
            cbReindex.Enabled = false;
            cbVaccum.Enabled = false;
                   }

        private Boolean itsOK()
        {
            if (cbReindex.Checked || cbVaccum.Checked)
            {
                return true; 
            }

            return false;
        }

        private async void btCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btOk_ClickAsync(object sender, EventArgs e)
        {
            if (itsOK())
            {
                btOk.Enabled = false;

                posicaoProcessando();

                daoResumo5405 dao = new daoResumo5405();

                DateTime tempoInicial = DateTime.Now;

                if (cbReindex.Checked)
                {
                    lbMensagem.Text = "Processando Reindex...";

                    await Task.Run(async delegate
                    {
                        await Task.Delay(300);
                    });

                    dao.reindex();
                }

                if (cbVaccum.Checked)
                {
                    lbMensagem.Text = "Processando Vacuum...";

                    await Task.Run(async delegate
                    {
                        await Task.Delay(300);
                    });

                    dao.vacuum();
                }

                await Task.Run(async delegate
                {
                    await Task.Delay(300);
                });

                DateTime tempoFinal = DateTime.Now;

                TimeSpan tempo = (TimeSpan)(tempoFinal - tempoInicial);

                string tempoDecorrido = String.Format("{0:00}:{1:00}:{2:00}", tempo.Hours, tempo.Minutes, tempo.Seconds);

                lbMensagem.Text = $"Processamento Finalizado. Tempo : {tempoDecorrido}";

                MessageBox.Show($"Processamento Finalizado. Tempo : {tempoDecorrido}");

            } else
            {
                MessageBox.Show("Marque Pelo Menos Uma Opção!");
            }
        }

      
    }
}
