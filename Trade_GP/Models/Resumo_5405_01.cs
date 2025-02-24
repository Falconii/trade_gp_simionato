using System;

namespace Trade_GP.Models
{
    public class Resumo_5405_01
    {
        
        public string material { get; set; }
        public string descricao { get; set; }
        public string unid     { get; set; }
        public double fator    { get; set; }
        public DateTime dt_ref  {get; set; }
        public int validade { get; set; }
        public Resumo_5405_01()
        {
            Zerar();
        }
  
        public void Zerar()
        {
            this.material = "";
            this.descricao = "";
            this.unid = "";
            this.fator = 0;
            this.validade = 180;
            this.dt_ref = DateTime.Now;
        }
    }
}
