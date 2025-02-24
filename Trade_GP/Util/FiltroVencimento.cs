using System;

namespace Trade_GP.Util
{
    class FiltroVencimento
    {
        public int Id_Grupo { get; set; }
        public DateTime? DtRef { get; set; }
        public DateTime? DtInicial { get; set; }
        public DateTime? DtFinal { get; set; }
        public Boolean Periodo { get; set; }
        public string Fechamentos { get; set; }

        public FiltroVencimento(int id_Grupo, DateTime? dtRef, DateTime? dtInicial, DateTime? dtFinal, bool periodo, string fechamentos)
        {
            Id_Grupo = id_Grupo;
            DtRef = dtRef;
            DtInicial = dtInicial;
            DtFinal = dtFinal;
            Periodo = periodo;
            Fechamentos = fechamentos;
        }

        public FiltroVencimento()
        {
            Zerar();
        }

        private void Zerar()
        {
            Id_Grupo = 0;
            DtRef = DateTime.Now;
            DtInicial = null;
            DtFinal = null;
            Periodo = false;
            Fechamentos = "";
        }
    }
}
