using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade_GP.Util
{
    public static class Coluna_Copy
    {
        public static string NumericLikeText(string field, string alias)
        {
            string retorno = $"'=' || '\"' || {field} || '\"'  AS {alias}";

            return retorno;
        }

        public static string NumericFormat(string field, int inteiro, int decimais,string alias)
        {

            string _alias = alias.Trim() == "" ? "" : $"AS {alias}";
            string retorno = $"TO_CHAR({field}, '{string.Concat(Enumerable.Repeat("9", inteiro))}D{string.Concat(Enumerable.Repeat("0", decimais))}') {_alias}";

            return retorno;
        }

        public static string AgeFormat(string field, string dataInicial, string alias)
        {
            string _alias = alias.Trim() == "" ? "" : $"AS {alias}";
            string retorno = $"TO_CHAR(AGE('{dataInicial}',{field}), 'YY \"ANO(S)\" MM \"MES(S)\" DD \"DIA(S)\"')  {_alias}";

            return retorno;
        }



    }
}
