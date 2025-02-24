using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade_GP.Models
{
    public class Fechamento
    {
        public int Id_Grupo { get; set; }
        public int Id { get; set; }
        public DateTime PInicial { get; set; }
        public DateTime PFinal { get; set; }
        public string Descricao { get; set; }
        public int User_Insert { get; set; }
        public DateTime DtInicial { get; set; }
        public DateTime DtFinal { get; set; }
        public string Status { get; set; }

        public Fechamento()
        {
            Zerar();
        }

        public Fechamento(int id_Grupo, int id, DateTime pinicial, DateTime pfinal, string descricao, int user_Insert, DateTime dtInicial, DateTime dtFinal, string status)
        {
            Id_Grupo = id_Grupo;
            Id = id;
            PInicial = pinicial;
            PFinal = pfinal;
            Descricao = descricao;
            User_Insert = user_Insert;
            DtInicial = dtInicial;
            DtFinal = dtFinal;
            Status = status;
        }

        private void Zerar()
        {
            Id_Grupo = 1;
            Id = 0;
            PInicial = DateTime.Today;
            PFinal   = DateTime.Today;
            Descricao = "";
            User_Insert = 0;
            DtInicial = DateTime.Today;
            DtFinal = DateTime.Today;
            Status = "0";
        }
    }
}
