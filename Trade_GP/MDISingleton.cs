using Trade_GP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade_GP
{
    class MDISingleton
    {
        private MDISingleton() { }

        private static FormPrincipal instanceFormPrincipal;

        public static FormPrincipal MDIParentPrincipal()
        {

            if (instanceFormPrincipal == null)
            {

                instanceFormPrincipal = new FormPrincipal();

                instanceFormPrincipal.WindowState = System.Windows.Forms.FormWindowState.Maximized;

                return instanceFormPrincipal;

            }

            return instanceFormPrincipal;

        }
    }

}