using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade_GP.Models.Validacoes
{
    public static class Validacoes
    {

        public static Boolean IsTamanho(String campo, int min, int max)
        {
            Boolean Result = true;

            if ( (campo.Trim().Length) <  min || (campo.Trim().Length) >  max)
            {
                Result = false;

            }
            
            return Result;
        }

        public static Boolean NoZero(Double campo)
        {
            Boolean Result = true;

            if ( campo <= 0 )
            {
                Result = false;

            }

            return Result;
        }

    }
}
