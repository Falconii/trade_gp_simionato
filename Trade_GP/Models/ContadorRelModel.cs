using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade_GP.Models
{
    class ContadorRelModel
    {
        public string cod_emp { get; set; }
        public string local { get; set; }
        public string cnpj { get; set; }
        public string ano { get; set; }
        public string mes { get; set; }
        public string arquivo { get; set; }
        public Int32 notas { get; set; }

        public ContadorRelModel()
        {
            this.Zerar();
        }

        public ContadorRelModel(string cod_emp, string local, string cnpj, string ano, string mes, string arquivo, int notas)
        {
            this.cod_emp = cod_emp;
            this.local = local;
            this.cnpj = cnpj;
            this.ano = ano;
            this.mes = mes;
            this.arquivo = arquivo;
            this.notas = notas;
        }

        private void Zerar()
        {
            this.cod_emp = "";
            this.local = "";
            this.cnpj = "";
            this.ano = "";
            this.mes = "";
            this.arquivo = "";
            this.notas = 0;
        }
    }


}
