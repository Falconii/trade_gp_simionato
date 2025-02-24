using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade_GP.Models
{
    public class LayOutPosicaoModel
    {


        public int idx { get; set; }
        public string nome { get; set; }
        public string tipo { get; set; }
        public int tam { get; set; }
        public int cd { get; set; }
        public int tratativa { get; set; }
        public bool obrigatorio { get; set; }
        public string padrao { get; set; }
        public string usado { get; set; }
        public string conteudo { get; set; }

        public LayOutPosicaoModel()
        {
        }

        public LayOutPosicaoModel(int idx, string nome, string tipo, int tam, int cd, int tratativa, bool obrigatorio, string padrao, string usado, string conteudo)
        {
            this.idx = idx;
            this.nome = nome;
            this.tipo = tipo;
            this.tam = tam;
            this.cd = cd;
            this.tratativa = tratativa;
            this.obrigatorio = obrigatorio;
            this.padrao = padrao;
            this.usado = usado;
            this.conteudo = conteudo;
        }
    }

    }
