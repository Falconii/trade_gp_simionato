using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade_GP.Models
{
    public class Cliente
    {
        public int Id_Grupo { get; set; }
        public int Codigo { get; set; }
        public string Cnpj_Cpf { get; set; }
        public string Razao { get; set; }
        public string Fantasi { get; set; }
        public string Inscri { get; set; }
        public string Empresa { get; set; }
        public string Local { get; set; }
        public string Cod_Empresa { get; set; }
        public string Cod_Protheus { get; set; }
        public string Cod_Sic { get; set; }
        public string Cod_Sap { get; set; }
        public string Cod_Soja { get; set; }
        public DateTime Cadastr { get; set; }
        public string Enderecof { get; set; }
        public string Nrof { get; set; }
        public string Bairrof { get; set; }
        public string Cidadef { get; set; }
        public string Uff { get; set; }
        public string Cepf { get; set; }
        public string Telf { get; set; }
        public string Celf { get; set; }
        public string Emailf { get; set; }
        public string Obs { get; set; }

        public Cliente()
        {
            Zerar();
        }

        public void Zerar()
        {
            Id_Grupo = 1;
            Codigo = 0;
            Cnpj_Cpf = "";
            Razao = "";
            Fantasi = "";
            Inscri = "";
            Empresa = "";
            Local = "";
            Cod_Empresa = "";
            Cod_Protheus = "";
            Cod_Sic = "";
            Cod_Sap = "";
            Cod_Soja = "";
            Cadastr = DateTime.Now.Date;
            Enderecof = "";
            Bairrof = "";
            Cidadef = "";
            Uff = "SP";
            Cepf = "";
            Telf = "";
            Celf = "";
            Emailf = "";
            Obs = "";

        }
    }
}
