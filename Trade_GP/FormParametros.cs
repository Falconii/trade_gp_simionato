using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Trade_GP.Dao.postgre;
using Trade_GP.Extensoes;
using Trade_GP.Models;
using Trade_GP.Util;

namespace Trade_GP
{
    public partial class FormParametros : Form
    {
        public List<ParamLocal> Parametros = new List<ParamLocal>();

        public string Tipo = "0"; //0-> tudo //1- saldo //2-> março
        public FormParametros( string tipo = "0")
        {
            this.Tipo = tipo;

            InitializeComponent();
        }

        private void lblLocais_Click(object sender, EventArgs e)
        {

        }

        private void FormParametros_Load(object sender, EventArgs e)
        {
            iniciar();
        }

        private void iniciar()
        {
            cbEmpresas.SelectedIndex = 0;
            tvLocais.Nodes.Clear();
            tvPeriodo.Nodes.Clear();
            if (this.Tipo == "1")
            {
                lblPeriodo.Visible = false;
                tvPeriodo.Visible = false;
            }
        }

        private void LoadPeriodo()
        {
            int idx = 0;
            tvPeriodo.Nodes.Clear();
            switch (this.Tipo.IntParse())
            {
                case 3:
                    tvPeriodo.Nodes.Add("ANO 2017");
                    tvPeriodo.Nodes[0].Nodes.Add("03/2017");
                    idx = 0;
                    break;
                default:
                    tvPeriodo.Nodes.Add("ANO 2016");
                    tvPeriodo.Nodes[0].Nodes.Add("12/2016");

                    tvPeriodo.Nodes.Add("ANO 2017");
                    tvPeriodo.Nodes[1].Nodes.Add("01/2017");
                    tvPeriodo.Nodes[1].Nodes.Add("02/2017");
                    tvPeriodo.Nodes[1].Nodes.Add("03/2017");

                    idx = 1;
                    break;
            }

            tvPeriodo.Nodes[idx].Nodes.Add("04/2017");
            tvPeriodo.Nodes[idx].Nodes.Add("05/2017");
            tvPeriodo.Nodes[idx].Nodes.Add("06/2017");
            tvPeriodo.Nodes[idx].Nodes.Add("07/2017");
            tvPeriodo.Nodes[idx].Nodes.Add("08/2017");
            tvPeriodo.Nodes[idx].Nodes.Add("09/2017");
            tvPeriodo.Nodes[idx].Nodes.Add("10/2017");
            tvPeriodo.Nodes[idx].Nodes.Add("11/2017");
            tvPeriodo.Nodes[idx].Nodes.Add("12/2017");
            idx++;


            tvPeriodo.Nodes.Add("ANO 2018");
            tvPeriodo.Nodes[idx].Nodes.Add("01/2018");
            tvPeriodo.Nodes[idx].Nodes.Add("02/2018");
            tvPeriodo.Nodes[idx].Nodes.Add("03/2018");
            tvPeriodo.Nodes[idx].Nodes.Add("04/2018");
            tvPeriodo.Nodes[idx].Nodes.Add("05/2018");
            tvPeriodo.Nodes[idx].Nodes.Add("06/2018");
            tvPeriodo.Nodes[idx].Nodes.Add("07/2018");
            tvPeriodo.Nodes[idx].Nodes.Add("08/2018");
            tvPeriodo.Nodes[idx].Nodes.Add("09/2018");
            tvPeriodo.Nodes[idx].Nodes.Add("10/2018");
            tvPeriodo.Nodes[idx].Nodes.Add("11/2018");
            tvPeriodo.Nodes[idx].Nodes.Add("12/2018");
            idx++;

            tvPeriodo.Nodes.Add("ANO 2019");
            tvPeriodo.Nodes[idx].Nodes.Add("01/2019");
            tvPeriodo.Nodes[idx].Nodes.Add("02/2019");
            tvPeriodo.Nodes[idx].Nodes.Add("03/2019");
            tvPeriodo.Nodes[idx].Nodes.Add("04/2019");
            tvPeriodo.Nodes[idx].Nodes.Add("05/2019");
            tvPeriodo.Nodes[idx].Nodes.Add("06/2019");
            tvPeriodo.Nodes[idx].Nodes.Add("07/2019");
            tvPeriodo.Nodes[idx].Nodes.Add("08/2019");
            tvPeriodo.Nodes[idx].Nodes.Add("09/2019");
            tvPeriodo.Nodes[idx].Nodes.Add("10/2019");
            tvPeriodo.Nodes[idx].Nodes.Add("11/2019");
            tvPeriodo.Nodes[idx].Nodes.Add("12/2019");
            idx++;

            tvPeriodo.Nodes.Add("ANO 2020");
            tvPeriodo.Nodes[idx].Nodes.Add("01/2020");
            tvPeriodo.Nodes[idx].Nodes.Add("02/2020");
            tvPeriodo.Nodes[idx].Nodes.Add("03/2020");
            tvPeriodo.Nodes[idx].Nodes.Add("04/2020");
            tvPeriodo.Nodes[idx].Nodes.Add("05/2020");
            tvPeriodo.Nodes[idx].Nodes.Add("06/2020");
            tvPeriodo.Nodes[idx].Nodes.Add("07/2020");
            tvPeriodo.Nodes[idx].Nodes.Add("08/2020");
            tvPeriodo.Nodes[idx].Nodes.Add("09/2020");
            tvPeriodo.Nodes[idx].Nodes.Add("10/2020");
            tvPeriodo.Nodes[idx].Nodes.Add("11/2020");
            tvPeriodo.Nodes[idx].Nodes.Add("12/2020");
            idx++;

            tvPeriodo.Nodes.Add("ANO 2021");
            tvPeriodo.Nodes[idx].Nodes.Add("01/2021");
            tvPeriodo.Nodes[idx].Nodes.Add("02/2021");
            tvPeriodo.Nodes[idx].Nodes.Add("03/2021");
            tvPeriodo.Nodes[idx].Nodes.Add("04/2021");
            tvPeriodo.Nodes[idx].Nodes.Add("05/2021");
            tvPeriodo.Nodes[idx].Nodes.Add("06/2021");
            tvPeriodo.Nodes[idx].Nodes.Add("07/2021");
            tvPeriodo.Nodes[idx].Nodes.Add("08/2021");
            tvPeriodo.Nodes[idx].Nodes.Add("09/2021");
            tvPeriodo.Nodes[idx].Nodes.Add("10/2021");
            tvPeriodo.Nodes[idx].Nodes.Add("11/2021");
            tvPeriodo.Nodes[idx].Nodes.Add("12/2021");
            idx++;

            tvPeriodo.Nodes.Add("ANO 2022");
            tvPeriodo.Nodes[idx].Nodes.Add("01/2022");
            tvPeriodo.Nodes[idx].Nodes.Add("02/2022");
            tvPeriodo.Nodes[idx].Nodes.Add("03/2022");
            tvPeriodo.Nodes[idx].Nodes.Add("04/2022");
            tvPeriodo.Nodes[idx].Nodes.Add("05/2022");
            tvPeriodo.Nodes[idx].Nodes.Add("06/2022");
            tvPeriodo.Nodes[idx].Nodes.Add("07/2022");
            tvPeriodo.Nodes[idx].Nodes.Add("08/2022");
            tvPeriodo.Nodes[idx].Nodes.Add("09/2022");
            tvPeriodo.Nodes[idx].Nodes.Add("10/2022");
            tvPeriodo.Nodes[idx].Nodes.Add("11/2022");
            tvPeriodo.Nodes[idx].Nodes.Add("12/2022");
            idx++;
            tvPeriodo.Nodes.Add("ANO 2023");
            tvPeriodo.Nodes[idx].Nodes.Add("01/2023");
            tvPeriodo.Nodes[idx].Nodes.Add("02/2023");
            tvPeriodo.Nodes[idx].Nodes.Add("03/2023");
            tvPeriodo.Nodes[idx].Nodes.Add("04/2023");
            tvPeriodo.Nodes[idx].Nodes.Add("05/2023");
            tvPeriodo.Nodes[idx].Nodes.Add("06/2023");
        }

        private void LoadLocais(string titulo,List<ClienteByEmpLocal> lista)
        {
            tvLocais.Nodes.Clear();
            tvLocais.Nodes.Add(titulo);
            foreach (ClienteByEmpLocal cliente in lista)
            {
                tvLocais.Nodes[0].Nodes.Add($"{cliente.Local} - {cliente.Razao}");
            }
            

        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            daoCliente dao = new daoCliente();

            string cod_emp = ((string)cbEmpresas.SelectedItem).Substring(0, 4);

            try
            {
                List<ClienteByEmpLocal> lista = dao.getClienteByEmpLocal(cod_emp);
                LoadLocais((string)cbEmpresas.SelectedItem,lista);
                LoadPeriodo();
            } catch (Exception ex)
            {
                MessageBox.Show("Falha Na Pesquisas Do Locais Ou Perídos");
            }

        }

        private void cbEmpresas_SelectedIndexChanged(object sender, EventArgs e)
        {
            tvLocais.Nodes.Clear();
            tvPeriodo.Nodes.Clear();
        }

        private void tvLocais_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Console.WriteLine(e.Node.Text);
        }

        private void tvLocais_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 0)
            {
                Boolean choice = e.Node.Checked;

                foreach (TreeNode node in tvLocais.Nodes[0].Nodes)
                {
                    node.Checked = choice;
                }

            }
        }

        private void tvPeriodo_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 0)
            {
                Boolean choice = e.Node.Checked;

                foreach (TreeNode node in tvPeriodo.Nodes[e.Node.Index].Nodes)
                {
                    node.Checked = choice;
                }

            }
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            if (this.Tipo == "3")
            {
                if ((ContadorLocais() == 0) || (ContadorPeriodos() == 0))
                {
                    string mensagem = "";

                    if (ContadorLocais() == 0)
                    {
                        mensagem += "Verifique Os Locais";
                    }

                    if ((ContadorPeriodos() == 0))
                    {
                        mensagem = mensagem + (ContadorLocais() == 0 ? " E " : "") + "Verifique Os Períodos";
                    }
                    if (mensagem != "")
                    {
                        MessageBox.Show(mensagem, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {

                    loadLocaisOpcoes();

                    DialogResult = DialogResult.OK;

                    Close();
                }
            } else
            {
                string mensagem = "";

                if (ContadorLocais() == 0)
                {
                    mensagem += "Verifique Os Locais";
                }

                if (mensagem != "")
                {
                    MessageBox.Show(mensagem, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                } else
                {
                    loadLocaisOpcoes();

                    DialogResult = DialogResult.OK;

                    Close();
                }
            }
        }

        private void loadLocaisOpcoes()
        {

            Parametros.Clear();

            foreach (TreeNode item in tvLocais.Nodes[0].Nodes)
            {
                if (item.Checked)
                {
                    Console.WriteLine($"Local {item.Text} - Ckecked ${item.Checked}");

                    ParamLocal param = new ParamLocal();

                    param.Cod_Emp = cbEmpresas.Text.Substring(0, 4);

                    param.Local = item.Text.Substring(0, 4);

                    param.Razao = item.Text.Substring(8);

                    for (int idx = 0; idx < tvPeriodo.Nodes.Count; idx++)
                    {
                        foreach (TreeNode per in tvPeriodo.Nodes[idx].Nodes)
                        {
                            if (per.Checked)
                            {
                                Console.WriteLine($"Mês/Ano {per.Text} - Ckecked ${per.Checked}");
                                Periodo periodo = new Periodo(per.Text);
                                param.Periodos.Add(periodo);
                            }
                            
                        }
                    }

                    Parametros.Add(param);
                }
            }

            Console.WriteLine($"{Parametros.Count}");

        }

        private int ContadorLocais()
        {
            int ct = 0;

            foreach (TreeNode item in tvLocais.Nodes[0].Nodes)
            {
                if (item.Checked)
                {
                    ct++;
                }
            }

            return ct;
        }


        private int ContadorPeriodos()
        {
            int ct = 0;

            for (int idx = 0; idx < tvPeriodo.Nodes.Count; idx++)
            {
                foreach (TreeNode per in tvPeriodo.Nodes[idx].Nodes)
                {
                    if (per.Checked)
                    {
                        ct++;
                    }

                }
            }

            return ct;
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            
            DialogResult = DialogResult.Cancel;

            Close();
        }
    }
}
