using Trade_GP.Util;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Trade_GP.Extensoes
{
    public static class StringExtension
    {

        public static string FormatCnpjCPF(this string sender)
        {   //99.999.999/9999-99
            string response = sender.Trim();

            if (response.Length == 11 || response.Length == 14)
            {
                if (response.Length == 14)
                {
                    response = response.Insert(12, "-");
                    response = response.Insert(8, "/");
                    response = response.Insert(5, ".");
                    response = response.Insert(2, ".");
                }
                else
                {
                    response = response.Insert(9, "-");
                    response = response.Insert(6, ".");
                    response = response.Insert(3, ".");
                }
            }

            return response;
        }

        public static string LimpaCnpjCpf(this string sender)
        {
            string response = sender;

            response = Regex.Replace(response, "[\\.\\/\\-\\ ]", "");

            return response;
        }

        public static double DoubleParseUSA(this string sender)
        {

            double response = 0.0;

            var culture = new System.Globalization.CultureInfo("en-US");

            try
            {

                response = Convert.ToDouble(sender, culture);

            }
            catch (Exception e)
            {

                response = 0.0;

            }


            return response;
        }

        public static double DoubleParseUSAError(this string sender,string fileName, string fieldName , int ContadorLinhas)
        {

            double response = 0.0;

            if (sender is null || sender.ToUpper() == "NULL")
            {
                return 0.0;
            }

            var culture = new System.Globalization.CultureInfo("en-US");

            try
            {

                response = Convert.ToDouble(sender.Replace(",","."), culture);

            }
            catch (Exception e)
            {

                response = 0.0;

                ImportacaoAsync.StaticLsErrosImportacao.Add(new ErrosImportacao("E", fileName, $"{ContadorLinhas}", fieldName, sender, 0, $"Converção Numérica Inválida!"));

            }


            return response;
        }

        public static double DoubleParse(this string sender)
        {

            double response = 0.0;

            var culture = new System.Globalization.CultureInfo("pt-BR");

            try
            {

                response = Convert.ToDouble(sender, culture);

            }
            catch (Exception e)
            {

                response = 0.0;

            }


            return response;
        }

        public static string DoubleParseDb(this double sender)
        {

            string response = "0.0";

            var culture = new System.Globalization.CultureInfo("en-US");

            try
            {

                response = Convert.ToString(sender, culture);

            }
            catch (Exception e)
            {

                response = "0.0";

            }


            return response;
        }

        public static int IntParse(this string sender)
        {

            int response = 0;

            try
            {

                response = Convert.ToInt32(sender);

            }
            catch (Exception e)
            {

                response = 0;

            }


            return response;
        }

        public static bool IsCnpjCpf(this string documento)
        {

            bool retorno = false;

            if (documento.Trim().Length == 11)
            {

                retorno = IsCpf(documento.Trim());

            }
            else
            {
                retorno = IsCnpj(documento.Trim());

            }

            return retorno;
        }

        public static String MMAA(this string sender)
        {

            String retorno = "";
            String mes = "";



            switch (sender.Substring(0, 2))
            {
                case "01":
                    mes = "Jan";
                    break;
                case "02":
                    mes = "Fev";
                    break;
                case "03":
                    mes = "Mar";
                    break;
                case "04":
                    mes = "Abr";
                    break;
                case "05":
                    mes = "Mai";
                    break;
                case "06":
                    mes = "Jun";
                    break;
                case "07":
                    mes = "Jul";
                    break;
                case "08":
                    mes = "Ago";
                    break;
                case "09":
                    mes = "Set";
                    break;
                case "10":
                    mes = "Out";
                    break;
                case "11":
                    mes = "Nov";
                    break;
                case "12":
                    mes = "Dez";
                    break;
                default:
                    mes = "";
                    break;
            }

            retorno = mes + "/" + sender.Substring(sender.Length - 2, 2); ;

            return retorno;
        }

        private static bool IsCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito += resto.ToString();
            return cnpj.EndsWith(digito);
        }

        private static bool IsCpf(string cpf)
        {

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);

        }

        public static string SmartBreak(this string sender, int part)
        {

            int index = -1;

            string response = sender;

            if (response.Trim().Length <= 60)
            {
                index = -1;

            }
            else
            {
                index = response.Substring(0, 60).LastIndexOf(' ');
            }


            if (part == 1)
            {
                if (index == -1)
                {
                    response = response.Trim();
                }
                else
                {
                    response = response.Substring(0, index);
                }

                return response;
            }
            else
            {
                response = sender;

                if (index == -1) return "";

                int Comprimento = response.Length - (index + 1);

                return response.Substring(index + 1, Comprimento).Trim();

            }


        }

        public static string DateToDb(this String sender)
        {

            string response = "";

            response = sender.Substring(06, 04) + "-" + sender.Substring(03, 02) + "-" + sender.Substring(0, 02);

            return response;
        }

        public static string MaxLength(this String sender, string fileName, Int64 ContadorLinhas, string fieldName, int Max)
        {
            ErrosImportacao response = null;

            if (sender.Length > Max)
            {
                ImportacaoAsync.StaticLsErrosImportacao.Add(new ErrosImportacao("E", fileName, $"{ContadorLinhas}", fieldName, sender, Max, $"Tamanho Maximo {Max} - {sender.Length}"));
            }

            return sender;

        }

        public static string WithMaxLength(this string value, int maxLength)
        {
            return value?.Substring(0, Math.Min(value.Length, maxLength));
        }

        public static string CopyRigth(this string value)
        {
            string retorno = value;

            int pos = value.IndexOf('-');

            if (pos > -1)
            {
                value = value.Substring(pos + 1).Trim();
            }
            return value;
        }

        public static string CopyLeft(this string value)
        {
            string retorno = value;

            int pos = value.IndexOf('-');

            if (pos > -1)
            {
                if (pos >   1)
                {
                    value = value.Substring(0, pos - 1).Trim();
                }
             }

            return value;
        }
        public static string StrZeroRigth(this string value, int tam)
        {
            string retorno = value;

            string zeros = String.Concat(Enumerable.Repeat("0", tam));

            value = zeros + value.Trim();

            value = value.Substring((value.Length - tam));
                
            return value;
        }

        public static int HasLetter(this string value)
        {
            int retorno = -1;
            
            for(int x = 0; x < value.Length; x++)
            {
                if (Char.IsLetter(value[x])){
                    retorno = x;
                    break;
                }
            }

            return retorno;
        }

        public static string ToLayOut(this string sender, string Campo, string LayOut, string Filial)
        {
            
            string response = sender;

            if (LayOut == "ENTRADA")
            {
                if (Campo == "Empresa")
                {
                    response = response;
                }
                if (Campo == "Material")
                {
                    int x = (response.HasLetter());

                    if (x > 0)
                    {
                        response = response.Substring(0, x);
                    }
                }
                if (Campo == "Descricao")
                {
                    int x = (response.IndexOf('-'));

                    if (x != -1)
                    {
                        response = response.Substring(x+1).Trim();
                    }
                }
            }

            return response;
        }

        public static string TirarControle(this string value)
        {
            string retorno = "";

            for (int x = 0; x < value.Length; x++)
            {
                if (Char.IsControl(value[x]))
                {
                    continue;
                }

                retorno += value.Substring(x, 1);
            }

            return retorno;
        }

        public static string TpOperacao(this string value)
        {

            string retorno = "";

            if (value.Trim().Length > 1)
            {

                if ((value.Substring(0,1) == "1") || (value.Substring(0, 1) == "2") || (value.Substring(0, 1) == "3"))
                {
                    //Excluido pelo email do Ricardo 01/08/22
                    if ((value == "1551") || (value == "2551") || (value == "1949") || (value == "2949") || (value == "1910") || (value == "2910"))
                    {
                        retorno = "X";
                    } else
                    {
                        retorno = "E";
                    }
                }


                if ((value.Substring(0, 1) == "5") || (value.Substring(0, 1) == "6") || (value.Substring(0, 1) == "7"))
                {
                    if ((value.Trim() == "5100") ||
                        (value.Trim() == "5101") ||
                        (value.Trim() == "5102") ||
                        (value.Trim() == "5103") ||
                        (value.Trim() == "5104") ||
                        (value.Trim() == "5105") ||
                        (value.Trim() == "5106") ||
                        (value.Trim() == "5109") ||
                        (value.Trim() == "5110") ||
                        (value.Trim() == "5111") ||
                        (value.Trim() == "5112") ||
                        (value.Trim() == "5113") ||
                        (value.Trim() == "5114") ||
                        (value.Trim() == "5115") ||
                        (value.Trim() == "5116") ||
                        (value.Trim() == "5117") ||
                        (value.Trim() == "5118") ||
                        (value.Trim() == "5119") ||
                        (value.Trim() == "5120") ||
                        (value.Trim() == "5122") ||
                        (value.Trim() == "5123") ||
                        (value.Trim() == "5250") ||
                        (value.Trim() == "5251") ||
                        (value.Trim() == "5252") ||
                        (value.Trim() == "5253") ||
                        (value.Trim() == "5254") ||
                        (value.Trim() == "5255") ||
                        (value.Trim() == "5256") ||
                        (value.Trim() == "5257") ||
                        (value.Trim() == "5258") ||
                        (value.Trim() == "5401") ||
                        (value.Trim() == "5402") ||
                        (value.Trim() == "5403") ||
                        (value.Trim() == "5405") ||
                        //(value.Trim() == "5551") || //Excluido pelo email do Ricardo 01/08/22
                        (value.Trim() == "5651") ||
                        (value.Trim() == "5652") ||
                        (value.Trim() == "5653") ||
                        (value.Trim() == "5654") ||
                        (value.Trim() == "5655") ||
                        (value.Trim() == "5656") ||
                        (value.Trim() == "6100") ||
                        (value.Trim() == "6101") ||
                        (value.Trim() == "6102") ||
                        (value.Trim() == "6103") ||
                        (value.Trim() == "6104") ||
                        (value.Trim() == "6105") ||
                        (value.Trim() == "6106") ||
                        (value.Trim() == "6107") ||
                        (value.Trim() == "6108") ||
                        (value.Trim() == "6109") ||
                        (value.Trim() == "6110") ||
                        (value.Trim() == "6111") ||
                        (value.Trim() == "6112") ||
                        (value.Trim() == "6113") ||
                        (value.Trim() == "6114") ||
                        (value.Trim() == "6115") ||
                        (value.Trim() == "6116") ||
                        (value.Trim() == "6117") ||
                        (value.Trim() == "6118") ||
                        (value.Trim() == "6119") ||
                        (value.Trim() == "6120") ||
                        (value.Trim() == "6122") ||
                        (value.Trim() == "6123") ||
                        (value.Trim() == "6250") ||
                        (value.Trim() == "6251") ||
                        (value.Trim() == "6252") ||
                        (value.Trim() == "6253") ||
                        (value.Trim() == "6254") ||
                        (value.Trim() == "6255") ||
                        (value.Trim() == "6256") ||
                        (value.Trim() == "6257") ||
                        (value.Trim() == "6258") ||
                        (value.Trim() == "6401") ||
                        (value.Trim() == "6402") ||
                        (value.Trim() == "6403") ||
                        (value.Trim() == "6404") ||
                        //(value.Trim() == "6551") || //Excluido pelo email do Ricardo 01/08/22
                        (value.Trim() == "6651") ||
                        (value.Trim() == "6652") ||
                        (value.Trim() == "6653") ||
                        (value.Trim() == "6654") ||
                        (value.Trim() == "6655") ||
                        (value.Trim() == "6656") ||
                        (value.Trim() == "7100") ||
                        (value.Trim() == "7101") ||
                        (value.Trim() == "7102") ||
                        (value.Trim() == "7105") ||
                        (value.Trim() == "7106") ||
                        (value.Trim() == "7127") ||
                        (value.Trim() == "7250") ||
                        (value.Trim() == "7251") ||
                        (value.Trim() == "7551") ||
                        (value.Trim() == "7651") ||
                        (value.Trim() == "7654"))
                    {
                        retorno = "V";
                    }
                    else
                    {
                        retorno = "S";
                    }  
                }
            }
            else
            {
                retorno = "";

            }

            return retorno;
        }
    }

}
