using Trade_GP.Extensoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade_GP.Util
{
    public static class LayOutPadrao
    {
        public static Boolean  IsLayOutPadrao(string campo1,string campo2, string campo3, Boolean saldo = false)
        {
            
            string Coluna1 = campo1.Trim().ToUpper();
            string Coluna2 = campo2.Trim().ToUpper();
            string Coluna3 = campo3.Trim().ToUpper();

            if (saldo)
            {
                return IsSaldo(Coluna1, Coluna2, Coluna3);
            } else
            {
                return IsPadrao(Coluna1, Coluna2, Coluna3);
            }

        }

        public static string QualLayOutPadrao(string campo1, string campo2, string campo3)
        {

            string Coluna1 = campo1.Trim().ToUpper();
            string Coluna2 = campo2.Trim().ToUpper();
            string Coluna3 = campo3.Trim().ToUpper();

            string Layout = "";

            if (IsSaldo(Coluna1, Coluna2, Coluna3)) Layout = "SALDO"; 

            if (IsPadrao(Coluna1, Coluna2, Coluna3)) Layout = "MOVIMENTAÇÃO";

            return Layout;

        }

        private static Boolean IsPadrao(string Coluna1, string Coluna2, string Coluna3)
        {
            Boolean Retorno = false;

            if (((Coluna1 == "EMPR + LOCALNEG") || (Coluna1 == "EMPR+LOCALNEG")) && Coluna2 == "ID" && Coluna3 == "QUANTIDADE")
            {
                Retorno = true;
            }

            return Retorno;
        }

        private static Boolean IsSaldo(string Coluna1, string Coluna2, string Coluna3)
        {
            Boolean Retorno = false;

            if (Coluna1 == "CHAVE" && Coluna2 == "REFERÊNCIA" && Coluna3 == "ANO_NF")
            {
                Retorno = true;
            }

            return Retorno;
        }

    }
}
