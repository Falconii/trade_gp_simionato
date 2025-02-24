using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade_GP.Models
{
    public class AssinaturaModel
    {
        public int idx { get; set; }
        public string coluna { get; set; }

        public AssinaturaModel()
        {
            Zerar();
        }

        public AssinaturaModel(int idx, string coluna)
        {
            this.idx = idx;
            this.coluna = coluna;
        }

        private void Zerar()
        {
            this.idx = 0;
            this.coluna = "";
        }
    }
}
