using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade_GP.Util
{
    public class Filtro_Fechamento
    {
        public int Id_Grupo { get; set; }
        public int Id { get; set; }
        public DateTime? PInicial { get; set; }
        public DateTime? PFinal { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }
        public Boolean Periodo { get; set; }
        public List<string> Fechamentos { get; set; }
        public Boolean Excel { get; set; }
        public Filtro_Fechamento()
        {
            Zerar();
        }

        public Filtro_Fechamento(int id_Grupo, int id, DateTime? pInicial, DateTime? pFinal, string descricao, string status, bool periodo, List<string> fechamentos, bool excel)
        {
            Id_Grupo = id_Grupo;
            Id = id;
            PInicial = pInicial;
            PFinal = pFinal;
            Descricao = descricao;
            Status = status;
            Periodo = periodo;
            Fechamentos = fechamentos;
            Excel = excel;
        }

        private void Zerar()
        {
            Id_Grupo = 0;
            Id = 0;
            PInicial = null;
            PFinal = null;
            Descricao = "";
            Status = "";
            Periodo = false;
            Fechamentos = new List<string>();
            Excel = false;
        }
    }
}
