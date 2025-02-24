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
using Trade_GP.Models;

namespace Trade_GP
{
    public partial class FormLogin : Form
    {
        public Usuario usuario = null;

        public int Id_Grupo = 0; 

        List<Usuario> lsUsuarios;

        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            LoadUsuarios();

            cbGrupo.SelectedIndex = 0;

            if (lsUsuarios.Count == 0)
            {
                var usuario = new Usuario();
                usuario.Cnpj_Cpf = "00000000000000";
                usuario.Razao = "ADM";
                usuario.Senha = "123456";

                try
                {
                    var dao = new daoUsuario();

                    dao.Insert(usuario);

                    LoadUsuarios();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Problemas No Arquivo De Usuários!", "Atenção!");
                }

            }

            if (lsUsuarios.Count == 0)
            {
                MessageBox.Show("Aplicação Será Fechada!", "Atenção!");
                Close();
            }


            cbUsuarios.DataSource = lsUsuarios;

            cbUsuarios.DisplayMember = "Razao";
        }

        private void LoadUsuarios()
        {

            try
            {

                var dao = new daoUsuario();


                lsUsuarios = dao.getAll(2, "");


            }
            catch (Exception e)
            {

                lsUsuarios = new List<Usuario>();

            }


        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            String Usuario;
            String Senha;

            var dao = new daoUsuario();

            Usuario = (cbUsuarios.SelectedItem as Usuario).Razao;
            Senha = txtSenha.Text;

            if (Usuario.Trim() == "")
            {
                MessageBox.Show("Campo Usuário É Obrigatorio !!");

                return;

            }


            if (Senha.Trim() == "")
            {
                MessageBox.Show("Campo Senha É Obrigatorio !!");

                return;

            }


            var login = dao.Login(Usuario, Senha);

            if (login == null)
            {

                MessageBox.Show("Usuário Ou Senha Inválidos");

            }
            else
            {

                usuario = login;

                Id_Grupo = cbGrupo.SelectedIndex + 1;

                DialogResult = DialogResult.OK;

                Close();

            }


        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
