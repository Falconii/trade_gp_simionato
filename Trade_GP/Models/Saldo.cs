using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade_GP.Models
{
    public class Saldo
    {
        public int Id_Grupo { get; set; }
        public string Cod_Emp { get; set; }
        public string Local { get; set; }
        public string Material { get; set; }
        public double Saldo_Inicial { get; set; }
        public double Saldo_Implantado { get; set; }
        public string Status { get; set; }

        public Saldo()
        {
            this.Zerar();
        }

        public Saldo(int id_Grupo, string cod_Emp, string local, string material, double saldo_Inicial, double saldo_Implantado, string status)
        {
            Id_Grupo = id_Grupo;
            Cod_Emp = cod_Emp;
            Local = local;
            Material = material;
            Saldo_Inicial = saldo_Inicial;
            Saldo_Implantado = saldo_Implantado;
            Status = status;
        }

        private void Zerar()
        {
            Id_Grupo = 0;
            Cod_Emp = "";
            Local = "";
            Material = "";
            Saldo_Inicial = 0;
            Saldo_Implantado = 0;
            Status = "0";
        }
    }
}
