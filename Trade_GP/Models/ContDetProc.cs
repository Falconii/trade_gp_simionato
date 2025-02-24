using System;

namespace Trade_GP.Models
{
    public class ContDetProc
    {
        public int Id_Grupo { get; set; }
        public string Cod_Emp { get; set; }
        public string Local { get; set; }
        public int Id_Cabec { get; set; }
        public string Ano { get; set; }
        public string Mes { get; set; }
        public string Id_Processo { get; set; }
        public string Status { get; set; }

        // inicializa os campos
        public ContDetProc(int id_Grupo, string cod_Emp, string local, int id_Cabec, string ano, string mes, string id_Processo, string status)
        {
            Id_Grupo = id_Grupo;
            Cod_Emp = cod_Emp;
            Local = local;
            Id_Cabec = id_Cabec;
            Ano = ano;
            Mes = mes;
            Id_Processo = id_Processo;
            Status = status;
        }
        public ContDetProc()
        {
            Zerar();
        }

        public void Zerar()
        {
            Id_Grupo = 1;
            Cod_Emp = "";
            Local = "";
            Id_Cabec = 1;
            Ano = "";
            Mes = "";
            Id_Processo = "";
            Status = "";
        }

        /*
           0 => Em Aberto
           1 => Encerrado Com Sucesso
        */
    }
}

