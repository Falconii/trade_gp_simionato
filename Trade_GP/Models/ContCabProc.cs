using System;

namespace Trade_GP.Models
{
    public class ContCabProc
    {
        public int Id_Grupo { get; set; }
        public string Cod_Emp { get; set; }
        public string Local { get; set; }
        public string Cnpj_cpf { get; set; }
        public int Id { get; set; }
        public char Status_Imp { get; set; }
        public char Status_Dev { get; set; }
        public char Status_Saldos { get; set; }
        public char Status_Valor { get; set; }

        // Inicializar os campos
        public ContCabProc(int id_Grupo, string cod_Emp, string local, string cnpj_cpf, int id, char status_Imp, char status_Dev, char status_Saldos, char status_Valor)
        {
            Id_Grupo = id_Grupo;
            Cod_Emp = cod_Emp;
            Local = local;
            Cnpj_cpf = cnpj_cpf;
            Id = id;
            Status_Imp = status_Imp;
            Status_Dev = status_Dev;
            Status_Saldos = status_Saldos;
            Status_Valor = status_Valor;
        }

        public ContCabProc()
        {
            Zerar();
        }

        public void Zerar()
        {
            Id_Grupo = 1;
            Id = 1;
            Cod_Emp = "";
            Local = "";
            Cnpj_cpf = "";
            Status_Imp = ' ';
            Status_Dev = ' ';
            Status_Saldos = ' ';
            Status_Valor = ' ';
        }

        /*
           0 => Em Aberto
           1 => Encerrado Com Sucesso
        */
    }
}
