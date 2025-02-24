using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade_GP.Models
{
    public class ClienteByEmpLocal
    {
        public int Id_Grupo { get; set; }
        public string Empresa { get; set; }
        public string Cod_Empresa { get; set; }
        public string Local { get; set; }
        public string Cnpj_Cpf { get; set; }
        public string Razao { get; set; }

        public ClienteByEmpLocal()
        {
        }

        public ClienteByEmpLocal(int id_Grupo, string empresa, string cod_Empresa, string local, string cnpj_Cpf, string razao)
        {
            Id_Grupo = id_Grupo;
            Empresa = empresa;
            Cod_Empresa = cod_Empresa;
            Local = local;
            Cnpj_Cpf = cnpj_Cpf;
            Razao = razao;
        }

        private void Zerar()
        {
            Id_Grupo = 1;
            Empresa = "";
            Cod_Empresa = "";
            Local = "";
            Cnpj_Cpf = "";
            Razao = "";
        }
    }
}
