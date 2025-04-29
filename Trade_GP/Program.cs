using System;
using System.IO;
using System.Windows.Forms;
using Trade_GP.DataBase;

namespace Trade_GP
{
    static class Program
    {
     
            /// <summary>
            /// Ponto de entrada principal para o aplicativo.
            /// </summary>
            [STAThread]
            static void Main(string[] args)
            {
                if (args.Length == 0)
                {
                   
                    string curDir = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory.ToString());

                    RunCommand.SetarBancoV3($"{curDir}//default3.json");

                    //RunCommand.SetarBanco("default");
                }
                else
                {
                    RunCommand.SetarBancoV3(args[0]);
                    //RunCommand.SetarBanco(args[0]);
            }

                Application.EnableVisualStyles();

                Application.SetCompatibleTextRenderingDefault(false);

                FormLogin Login = null;

                Login = new FormLogin();

                if (Login.ShowDialog() == DialogResult.OK)
                {
                    Util.UsuarioSistema.Usuario = Login.usuario;

                    Util.UsuarioSistema.Id_Grupo = Login.Id_Grupo;

                    Application.Run(MDISingleton.MDIParentPrincipal());

                }

            }
        }
    }
