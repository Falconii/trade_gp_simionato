using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade_GP.Models
{
    public class Selic
    {
        public string Ano { get; set; }
        public string Mes { get; set; }
        public double Taxa { get; set; }

        public Selic()
        {
            Zerar();
        }

        public Selic(string ano, string mes, double taxa)
        {
            Ano = ano;
            Mes = mes;
            Taxa = taxa;
        }

        private void Zerar()
        {
            this.Ano = "";
            this.Mes = "";
            this.Taxa = 0;
        }
    }
}
