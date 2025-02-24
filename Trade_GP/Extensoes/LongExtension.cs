using System;

namespace Trade_GP.Extensoes
{
    public static class LongExtension
    {
        public static string SizeKB(this long sender)
        {

            string response = "";

            if (sender == 0)
            {
                response = "0 KB";

            }
            else
            {
                try
                {

                    response = ((long)(sender / 1024)).ToString() + " KB";

                }
                catch (Exception e)
                {

                    response = "0 KB";

                }

            }

            return response;
        }

    }
}
