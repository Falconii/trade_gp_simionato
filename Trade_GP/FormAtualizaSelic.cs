using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trade_GP.Util;

namespace Trade_GP
{
    public partial class FormAtualizaSelic : Form
    {
        private List<ParamLocal> Parametros = new List<ParamLocal>();

        private List<GridLocais> lsLocais = new List<GridLocais>();

        private List<tarefa> lsTarefas = new List<tarefa>();

        private Boolean btProximoFlag = false;

        private string Cod_Emp = "";

        private string Local = "";

        private Boolean Cancelar = false;

        public ToolStripMenuItem menu { get; internal set; }
        public FormAtualizaSelic()
        {
            InitializeComponent();
        }

        private void FormAtualizaSelic_Load(object sender, EventArgs e)
        {

        }

        private void FormAtualizaSelic_Activated(object sender, EventArgs e)
        {
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void FormAtualizaSelic_FormClosed(object sender, FormClosedEventArgs e)
        {
            menu.Enabled = true;
        }

        private class tarefa
        {
            public int Sequencia { get; set; }
            public string Descricao { get; set; }
            public DateTime? Inicial { get; set; }
            public DateTime? Final { get; set; }
            public string Observacao { get; set; }
            public string Status { get; set; }
        }
    }
}
