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
using Trade_GP.DataBase;
using Trade_GP.Models;
using Trade_GP.Util;

namespace Trade_GP
{

    public enum Visoes { Browser, Consulta, Nova, Edicao, Exclusao, Help };

    

    public partial class FormPrincipal : Form
    {
        public int ID_GRUPO = 1;

        public static List<Estado> estados = new List<Estado>()
        {
            new Estado("AC-Acre"),
            new Estado("AL-Alagoas"),
            new Estado("AP-Amapá"),
            new Estado("AM-Amazonas"),
            new Estado("BA-Bahia"),
            new Estado("CE-Ceará"),
            new Estado("DF-Distrito Federal"),
            new Estado("ES-Espírito Santo"),
            new Estado("GO-Goiás"),
            new Estado("MA-Maranhão"),
            new Estado("MT-Mato Grosso"),
            new Estado("MS-Mato Grosso do Sul"),
            new Estado("MG-Minas Gerais"),
            new Estado("PA-Pará"),
            new Estado("PB-Paraíba"),
            new Estado("PR-Paraná"),
            new Estado("PE-Pernambuco"),
            new Estado("PI-Piauí"),
            new Estado("RJ-Rio de Janeiro"),
            new Estado("RN-Rio Grande do Norte"),
            new Estado("RS-Rio Grande do Sul"),
            new Estado("RO-Rondônia"),
            new Estado("RR-Roraima"),
            new Estado("SC-Santa Catarina"),
            new Estado("SP-São Paulo"),
            new Estado("SE-Sergipe"),
            new Estado("TO-Tocantins"),
            new Estado("  -         "),

        };

        public static Usuario usuario = new Usuario();
        public FormPrincipal()
        {
            InitializeComponent();
            Text = RunCommand.Banco;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void layOutsManutençãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

      
        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCliente form = new FormCliente();

            ((System.Windows.Forms.ToolStripMenuItem)sender).Enabled = false;

            form.MdiParent = this;

            form.menu = (ToolStripMenuItem)sender;

            form.Show();

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormSelic form = new FormSelic();

            ((System.Windows.Forms.ToolStripMenuItem)sender).Enabled = false;

            form.MdiParent = this;

            form.menu = (ToolStripMenuItem)sender;

            form.Show();
        }

        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUsuario form = new FormUsuario();

            ((System.Windows.Forms.ToolStripMenuItem)sender).Enabled = false;

            form.MdiParent = this;

            form.menu = (ToolStripMenuItem)sender;

            form.Show();
        }

        private void processamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormImportacao form = new FormImportacao();

            ((System.Windows.Forms.ToolStripMenuItem)sender).Enabled = false;

            form.MdiParent = this;

            form.menu = (ToolStripMenuItem)sender;

            form.Show();
        }

        private void processamentoEstoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSaldos form = new FormSaldos();

            ((System.Windows.Forms.ToolStripMenuItem)sender).Enabled = false;

            form.MdiParent = this;

            form.menu = (ToolStripMenuItem)sender;

            form.Show();
            /*
            daoFechamento dao = new daoFechamento();
            Fechamento antigo = dao.SeekLast(UsuarioSistema.Id_Grupo);

            Fechamento novo = new Fechamento()
            {
                Id_Grupo = UsuarioSistema.Id_Grupo,
                Id = 0,
                Descricao = "",
                PInicial = DateTime.Today,
                PFinal = DateTime.Today,
                DtInicial = DateTime.Now,
                DtFinal = DateTime.Now,
                User_Insert = UsuarioSistema.Usuario.Codigo,
                Status = "0"
            };

            FormFechamento _form = new FormFechamento(antigo, novo);

            var Result = _form.ShowDialog();

            var fechamentoOficial = _form.fechamento;

            _form.Dispose();

            if (Result == DialogResult.OK)
            {

                FormCalculo calculo = new FormCalculo(fechamentoOficial);

                ((System.Windows.Forms.ToolStripMenuItem)sender).Enabled = false;

                calculo.MdiParent = this;

                calculo.menu = (ToolStripMenuItem)sender;

                calculo.Show();
            }
            */
        }

        private void validaçãoDevuluçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FormValidacoes form = new FormValidacoes();

            ((System.Windows.Forms.ToolStripMenuItem)sender).Enabled = false;

            form.MdiParent = this;

            form.menu = (ToolStripMenuItem)sender;

            form.Show();
        }

        private void cálculoValorEconômicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormVlrEconomico form = new FormVlrEconomico();

            ((System.Windows.Forms.ToolStripMenuItem)sender).Enabled = false;

            form.MdiParent = this;

            form.menu = (ToolStripMenuItem)sender;

            form.Show();
        }

        private void atualizaçãoVrlEconômicoSELICToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAtualizaSelic form = new FormAtualizaSelic();

            ((System.Windows.Forms.ToolStripMenuItem)sender).Enabled = false;

            form.MdiParent = this;

            form.menu = (ToolStripMenuItem)sender;

            form.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var form = new FormVlrEconomicoLotes();

            ((System.Windows.Forms.ToolStripMenuItem)sender).Enabled = false;

            form.MdiParent = this;

            form.menu = (ToolStripMenuItem)sender;

            form.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            var form = new FormSaldosLote();

            ((System.Windows.Forms.ToolStripMenuItem)sender).Enabled = false;

            form.MdiParent = this;

            form.menu = (ToolStripMenuItem)sender;

            form.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            var form = new FormImplacaoSaldo();

            ((System.Windows.Forms.ToolStripMenuItem)sender).Enabled = false;

            form.MdiParent = this;

            form.menu = (ToolStripMenuItem)sender;

            form.Show();
        }

        private void manuteçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new manutencao();

            form.ShowDialog();
        }

        private void analíticoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormRelatorioAnalitico();

            ((System.Windows.Forms.ToolStripMenuItem)sender).Enabled = false;

            form.MdiParent = this;

            form.menu = (ToolStripMenuItem)sender;

            form.Show();
        }

        private void importarTXT5910_Click(object sender, EventArgs e)
        {
            FormImportarTxt5910 form = new FormImportarTxt5910();

            ((System.Windows.Forms.ToolStripMenuItem)sender).Enabled = false;

            form.MdiParent = this;

            form.menu = (ToolStripMenuItem)sender;

            form.Show();
        }

        private void processamentoDestinatárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBoniDestinatario form = new FormBoniDestinatario();

            ((System.Windows.Forms.ToolStripMenuItem)sender).Enabled = false;

            form.MdiParent = this;

            form.menu = (ToolStripMenuItem)sender;

            form.Show();
        }
    }
}
