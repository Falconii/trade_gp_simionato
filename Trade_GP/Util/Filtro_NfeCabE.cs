using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade_GP.Util
{
    public class Filtro_NfeCabE
    {
        public int Id_Grupo { get; set; }
        public int Id { get; set; }
        public string Planilha { get; set; }
        public int Status { get; set; }
        public int Ordenacao { get; set; }

        public Filtro_NfeCabE()
        {
            Zerar();
        }

        public Filtro_NfeCabE(int id_Grupo, int id, string planilha, int status, int ordenacao)
        {
            Id_Grupo = id_Grupo;
            Id = id;
            Planilha = planilha;
            Status = status;
            Ordenacao = ordenacao;
        }

        public void Zerar()
        {
            Id_Grupo = 0;
            Id = 0;
            Planilha = "";
            Status = -1;
            Ordenacao = 0;
        }
    }
}
