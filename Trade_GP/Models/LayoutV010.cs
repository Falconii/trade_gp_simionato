using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade_GP.Models
{
    public class LayoutV010
    {
        public LayOut layout { get; set; }
    }

    public class Assinatura
    {
        public int idx { get; set; }
        public string coluna { get; set; }
    }

    public class Coluna
    {
        public int idx { get; set; }
        public string nome { get; set; }
        public string tipo { get; set; }
        public int tam { get; set; }
        public int cd { get; set; }
        public int tratativa { get; set; }
        public string padrao { get; set; }
        public string usado { get; set; }
        public string conteudo { get; set; }
    }

    public class Layout
    {
        public string nome { get; set; }
        public List<Assinatura> assinatura { get; set; }
        public List<Coluna> colunas { get; set; }
    }

    public class LayOut
    {
        public List<Layout> layouts { get; set; }
    }
}
