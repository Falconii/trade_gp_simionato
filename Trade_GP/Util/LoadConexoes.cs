using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trade_GP.Util
{

    public class AppConnection
    {
        public string app_text { get; set; }
        public Dictionary<string, string> string_conection { get; set; }
    }

    public class AppData
    {
        public string name { get; set; }
        public List<AppConnection> conexoes { get; set; }
    }

    public class Root
    {
        public string master { get; set; }
        public List<AppData> app { get; set; }
    }
    class LoadConexoes
    {
        public string FileConfig { get; set; }

        public LoadConexoes(string fileConfig)
        {
            FileConfig = fileConfig;
        }

        public void LoadFile()
        {
            try
            {
              
                Root root = JsonConvert.DeserializeObject<Root>(FileConfig);

                // Exemplo de manipulação: listando os nomes dos apps
                foreach (AppData app in root.app)
                {
                    Console.WriteLine($"App: {app.name}");
                    foreach (var conexao in app.conexoes)
                    {
                        Console.WriteLine($"Conexão: {conexao.app_text}");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro:/n{ex.Message}", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public AppConnection getAppConnection(string appName)
        {
            AppConnection appConnection = null; 
            try
            {

                Root root = JsonConvert.DeserializeObject<Root>(FileConfig);

                // Exemplo de manipulação: listando os nomes dos apps
                foreach (AppData app in root.app)
                {
                    if (app.name == appName)
                    {
                        Console.WriteLine($"App: {app.name}");

                        if (app.conexoes.Count == 1)
                        {
                            appConnection = app.conexoes[0];
                        }
                    }
                }

                return appConnection;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro:/n{ex.Message}", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return appConnection;
        }

        public Root getRoot()
        {
            Root root = null;

            try
            {

                root = JsonConvert.DeserializeObject<Root>(FileConfig);

                return root;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro:/n{ex.Message}", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return root; 


        }

    }
}
