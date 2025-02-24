using System;

namespace Trade_GP.Extensoes
{
    public static class IntExtension
    {

        public static string IntNovo(this int sender)
        {

            string response = "";

            if (sender == 0)
            {
                response = "NOVO";

            }
            else
            {
                try
                {

                    response = sender.ToString();

                }
                catch (Exception e)
                {

                    response = "0";

                }

            }

            return response;
        }

        public static string Int(this int sender)
        {

            string response = "";

            if (sender == 0)
            {
                response = "NOVO";

            }
            else
            {
                try
                {

                    response = sender.ToString();

                }
                catch (Exception e)
                {

                    response = "0";

                }

            }

            return response;
        }

        public static string IntParser(this int sender)
        {

            string response = "";

            try
            {

                response = sender.ToString();

            }
            catch (Exception e)
            {

                response = "0";

            }

            return response;
        }

        public static string IntParserMes(this int sender)
        {

            string response = "";

            try
            {

                response = sender.ToString();

                response = "00" + response;

                response = response.Substring(response.Length - 2, 2);

            }
            catch (Exception e)
            {

                response = "00";

            }

            return response;
        }



    }

}
