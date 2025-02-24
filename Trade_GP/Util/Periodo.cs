using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade_GP.Util
{
    public class Periodo
    {
        public string Data { get; set; }

        public Periodo()
        {
            Zerar();
        }

        public Periodo(string data)
        {
            Data = data;
        }

        private void Zerar()
        {
            Data = "";
        }
    }
}
