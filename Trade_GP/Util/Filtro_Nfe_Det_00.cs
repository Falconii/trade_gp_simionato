using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade_GP.Util
{
    class Filtro_Nfe_Det_00
    {
        public int Id_Grupo { get; set; }
        public int Id { get; set; }
        public string Planilha { get; set; }
        public string Empresa { get; set; }
        public string Cnpj { get; set; }
        public string Nro { get; set; }
        public string Serie  { get; set; }
        public string Material { get; set; }
        public string Descricao { get; set; }
        public string Operacao { get; set; }
        public int Ordenacao { get; set; }

        public Filtro_Nfe_Det_00()
        {
        }

        public Filtro_Nfe_Det_00(int id_grupo, int id, string planilha, string empresa, string cnpj, string nro, string serie, string material, string descricao, string operacao, int ordenacao)
        {
            Id_Grupo = id_grupo;
            Id = id;
            Planilha = planilha;
            Empresa = empresa;
            Cnpj = cnpj;
            Nro = nro;
            Serie = serie;
            Material = material;
            Descricao = descricao;
            Operacao = operacao;
            Ordenacao = ordenacao;
        }

        private void Zerar()
        {
            Id_Grupo = 0;
            Id = 0;
            Planilha = "";
            Empresa = "";
            Cnpj = "";
            Nro = "";
            Serie = "";
            Material = "";
            Descricao = "";
            Operacao = "";
            Ordenacao = 0;
        }

    }

}
