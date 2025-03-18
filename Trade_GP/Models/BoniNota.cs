using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade_GP.Models
{
    public class BoniNota
    {
        public int Id_Grupo { get; set; }
        public int Id_Planilha { get; set; }
        public int Nro_Linha { get; set; }
        public double Qtd_Convertida { get; set; }
        public int Boni_Planilha { get; set; }
        public int Boni_Linha { get; set; }
    }
}
