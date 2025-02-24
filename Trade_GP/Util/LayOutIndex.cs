namespace Trade_GP.Util
{
    class LayOutIndex
    {
        public string Operacao { get; set; }
        public int Id { get; set; }
        public int Nro_Linha  { get; set; }
        public int Cod_Empresa { get; set; }
        public int Local { get; set; }
        public int Id_Planilha { get; set; }
        public int Dtlanc { get; set; }
        public int Dtnf { get; set; }
        public int Nro { get; set; }
        public int Serie { get; set; }
        public int Uf { get; set; }
        public int Nr_Item { get; set; }
        public int Material { get; set; }
        public int Descricao { get; set; }
        public int Ncm { get; set; }
        public int Unid { get; set; }
        public int Cfop { get; set; }
        public int Cfop_Texto { get; set; }
        public int Qtd { get; set; }
        public int Vlr_Contabil { get; set; }
        public int Vlr_Unit { get; set; }
        public int Sti { get; set; }
        public int Bas_Icms { get; set; }
        public int Per_Icms { get; set; }
        public int Vlr_Icms { get; set; }
        public int Stp { get; set; }
        public int Bas_Pis { get; set; }
        public int Per_Pis { get; set; }
        public int Vlr_Pis { get; set; }
        public int Stc { get; set; }
        public int Bas_Cof { get; set; }
        public int Per_Cof { get; set; }
        public int Vlr_Cof { get; set; }
        public int StIp { get; set; }
        public int Bas_Ipi { get; set; }
        public int Per_Ipi { get; set; }
        public int Vlr_Ipi { get; set; }
        public int Bas_Icms_st { get; set; }
        public int Per_Icms_st { get; set; }
        public int Vlr_Icms_st { get; set; }
        public int Cnpj_Destinatario { get; set; }
        public int Chave { get; set; }
        public int Nome { get; set; }
        public int Saldo { get; set; }
        public int Sobra { get; set; }
        public LayOutIndex(string operacao)
        {
            Operacao = operacao;

            Setar();

        }

        private void Setar()
        {
           
            if (this.Operacao == "A")
            {
                Id = -1;
                Nro_Linha = -1;
                Cod_Empresa = 5;
                Local = 6;
                Id_Planilha = -1;
                Dtlanc = 9;
                Dtnf = 10;
                Nro = 11;
                Serie = 12;
                Uf = -1;
                Nr_Item = -1;
                Material = 14;
                Descricao = 15;
                Ncm = -1;
                Unid = -1;
                Cfop = 13;
                Cfop_Texto = -1;
                Qtd = 16;
                Vlr_Contabil = 17;
                Vlr_Unit = 19;
                Sti = -1;
                Bas_Icms = 18;
                Per_Icms = -1;
                Vlr_Icms = -1;
                Stp = -1;
                Bas_Pis = -1;
                Per_Pis = -1;
                Vlr_Pis = -1;
                Stc = -1;
                Bas_Cof = -1;
                Per_Cof = -1;
                Vlr_Cof = -1;
                StIp = -1;
                Bas_Ipi = 39;
                Per_Ipi = 42;
                Vlr_Ipi = 43;
                Bas_Icms_st = -1;
                Per_Icms_st = -1;
                Vlr_Icms_st = -1;
                Cnpj_Destinatario = 22;
                Chave = 12;
                Nome = 23;
                Saldo = 21;
                Sobra = 20;

            }

            if (this.Operacao == "E" || this.Operacao == "X")
            {
                Id = -1;
                Nro_Linha = -1;
                Cod_Empresa = 21;
                Local = 45;
                Id_Planilha = 1;
                Dtlanc = 17;
                Dtnf = 16;
                Nro = 53;
                Serie = 64;
                Uf = 67;
                Nr_Item = -1;
                Material = 46;
                Descricao = 66;
                Ncm = -1;
                Unid = 68;
                Cfop = 7;
                Cfop_Texto = 8;
                Qtd = 2;
                Vlr_Contabil = 71;
                Sti = 65;
                Bas_Icms = 22;
                Per_Icms = 35;
                Vlr_Icms = 36;
                Stp = 5;
                Bas_Pis = 56;
                Per_Pis = 59;
                Vlr_Pis = 60;
                Stc = 3;
                Bas_Cof = 13;
                Per_Cof = 14;
                Vlr_Cof = 15;
                StIp = -1;
                Bas_Ipi = 39;
                Per_Ipi = 42;
                Vlr_Ipi = 43;
                Bas_Icms_st = -1;
                Per_Icms_st = -1;
                Vlr_Icms_st = -1;
                Cnpj_Destinatario = 11;
                Chave = 9;
                Nome = 50;

            }

            if (this.Operacao == "S" || this.Operacao == "V")
            {
                Id = -1;
                Nro_Linha = -1;
                Cod_Empresa = 23;
                Local = 47;
                Id_Planilha = 1;
                Dtlanc = 19;
                Dtnf = 18;
                Nro = 55;
                Serie = 66;
                Uf = 69;
                Nr_Item = -1;
                Material = 48;
                Descricao = 68;
                Ncm = -1;
                Unid = 70;
                Cfop = 7;
                Cfop_Texto = 8;
                Qtd = 2;
                Vlr_Contabil = 73;
                Sti = 67;
                Bas_Icms = 24;
                Per_Icms = 37;
                Vlr_Icms = 38;
                Stp = 5;
                Bas_Pis = 58;
                Per_Pis = 61;
                Vlr_Pis = 62;
                Stc = 3;
                Bas_Cof = 13;
                Per_Cof = 16;
                Vlr_Cof = 17;
                StIp = -1;
                Bas_Ipi = 41;
                Per_Ipi = 44;
                Vlr_Ipi = 45;
                Bas_Icms_st = -1;
                Per_Icms_st = -1;
                Vlr_Icms_st = -1;
                Cnpj_Destinatario = 11;
                Chave = 9;
                Nome = 52;

            }

        }


        private void Zerar()
        {
            Cod_Empresa = -1;
            Nro_Linha = -1;
            Local = -1;
            Id_Planilha = -1;
            Dtlanc = -1;
            Dtnf = -1;
            Nro = -1;
            Serie = -1;
            Uf = -1;
            Nr_Item = -1;
            Material = -1;
            Descricao = -1;
            Ncm = -1;
            Unid = -1;
            Cfop = -1;
            Qtd = -1;
            Vlr_Contabil = -1;
            Vlr_Unit = -1;
            Sti = -1;
            Bas_Icms = -1;
            Per_Icms = -1;
            Vlr_Icms = -1;
            Stp = -1;
            Bas_Pis = -1;
            Per_Pis = -1;
            Vlr_Pis = -1;
            Stc = -1;
            Bas_Cof = -1;
            Per_Cof = -1;
            Vlr_Cof = -1;
            StIp = -1;
            Bas_Ipi = -1;
            Per_Ipi = -1;
            Vlr_Ipi = -1;
            Bas_Icms_st = -1;
            Per_Icms_st = -1;
            Vlr_Icms_st = -1;
            Cnpj_Destinatario = -1;
            Chave = -1;
            Nome = -1;
            Saldo = -1;
            Sobra = -1;
        }
    }
}
