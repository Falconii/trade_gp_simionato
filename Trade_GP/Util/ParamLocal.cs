using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade_GP.Util
{
    public class ParamLocal
    {
        public string Cod_Emp { get; set; }
        public string Local { get; set; }
        public string Razao { get; set; }
        public List<Periodo>  Periodos { get; set; }
        public ParamLocal(string cod_Emp, string local, string razao, List<Periodo> periodos, string obs = "")
        {
            Cod_Emp = cod_Emp;
            Local = local;
            Razao = razao;
            Periodos = periodos;
        }
        public ParamLocal()
        {
            Zerar();
        }
        private void Zerar()
        {
            Cod_Emp = "";
            Local = "";
            Razao = "";
            Periodos = new List<Periodo>();
        }
    }
}
