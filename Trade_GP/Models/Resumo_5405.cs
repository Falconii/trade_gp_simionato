using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade_GP.Models
{
    public class Resumo_5405
    {
        public int id_grupo { get; set; }
        public string cod_emp { get; set; }
        public string local { get; set; }
        public string material { get; set; }
        public string descricao { get; set; }
        public string unid { get; set; }
        public double fator { get; set; }
        public DateTime dt_ref { get; set; }
        public int validade { get; set; }
        public string origem { get; set; }

        public Resumo_5405()
        {
            this.Zerar();
        }

        public Resumo_5405(int id_grupo, string cod_emp, string local, string material, string descricao, string unid, DateTime dt_ref,string origem)
        {
            this.id_grupo = id_grupo;
            this.cod_emp = cod_emp;
            this.local = local;
            this.material = material;
            this.descricao = descricao;
            this.unid = unid;
            this.dt_ref = dt_ref;
            this.fator = 0;
            this.validade = 180;
            this.origem = origem;
        }

        public void Zerar()
        {
            this.id_grupo = 1;
            this.cod_emp = "";
            this.local = "";
            this.material = "";
            this.descricao = "";
            this.unid = "";
            this.fator = 0;
            this.dt_ref = DateTime.Now;
            this.fator = 0;
            this.validade = 180;
            this.origem = "S";
        }
    }
}
