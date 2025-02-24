using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade_GP.Models
{
    public class ContadorModel
    {
        public string local { get; set; }
        public int    ano { get; set; }
        public int    mes { get; set; }
        public DateTime dt_ref { get; set; }
        public Int32 notas { get; set; }

        public ContadorModel()
        {
        }

        public ContadorModel(string local, int ano, int mes , DateTime dt_ref, int notas)
        {
            this.local = local;
            this.ano = ano;
            this.mes = mes;
            this.dt_ref = dt_ref;
            this.notas = notas;
        }

        private void Zerar()
        {
            this.local  = "";
            this.ano = 0;
            this.mes = 0;
            this.dt_ref = DateTime.Now;
            this.notas  = notas;
        }
    }
}
