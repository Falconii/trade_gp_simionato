DROP TABLE IF EXISTS CLIENTES;
CREATE TABLE public.clientes  ( 
    id_grupo        int4   NOT NULL,
	codigo      	serial NOT NULL,
	cnpj_cpf    	varchar(18) NULL,
	razao       	varchar(100) NULL,
	fantasi     	varchar(100) NULL,
	inscri      	varchar(20) NULL DEFAULT ''::character varying,
	empresa     	char(6) NOT NULL DEFAULT ''::bpchar,
    local           char(6) NOT NULL DEFAULT '',
	cod_empresa 	char(6) NOT NULL DEFAULT ''::bpchar,
	cod_protheus	char(6) NULL DEFAULT ''::bpchar,
	cod_sic     	char(6) NULL DEFAULT ''::bpchar,
	cod_sap     	char(6) NULL DEFAULT ''::bpchar,
	cod_soja    	char(6) NULL DEFAULT ''::bpchar,
	cadastr     	date NULL,
	enderecof   	varchar(80) NULL DEFAULT ''::character varying,
	nrof        	char(10) NULL DEFAULT ''::bpchar,
	bairrof     	varchar(40) NULL DEFAULT ''::character varying,
	cidadef     	varchar(40) NULL DEFAULT ''::character varying,
	uff         	varchar(2) NULL DEFAULT ''::character varying,
	cepf        	varchar(8) NULL DEFAULT ''::character varying,
	telf        	varchar(23) NULL DEFAULT ''::character varying,
	celf        	varchar(23) NULL DEFAULT ''::character varying,
	faxf        	varchar(23) NULL DEFAULT ''::character varying,
	emailf      	varchar(100) NULL DEFAULT ''::character varying,
	obs         	varchar(200) NULL DEFAULT ''::character varying,
	PRIMARY KEY(id_grupo,codigo)
)
WITHOUT OIDS 
TABLESPACE "Producao"
GO
CREATE UNIQUE INDEX clientes_cnpj
	ON public.clientes USING btree (id_grupo,cnpj_cpf text_ops)
GO
CREATE UNIQUE INDEX clientes_codempres_local
	ON public.clientes USING btree (id_grupo,cod_empresa bpchar_ops, local bpchar_ops)
GO

DROP TABLE IF EXISTS USUARIOS;
CREATE TABLE Public.USUARIOS (
	 CODIGO   serial NOT  NULL,
	 RAZAO   varchar(40) NULL,
	 CNPJ_CPF   varchar(14) NULL,
	 CADASTR   date  NULL,
	 ENDERECO   varchar(40) NULL,
	 BAIRRO   varchar(40) NULL,
	 CIDADE   varchar(40) NULL,
	 UF   varchar(2) NULL,
	 CEP   varchar(8) NULL,
	 TEL1   varchar(23) NULL,
	 TEL2   varchar(23) NOT NULL,
	 EMAIL   varchar(100) NULL,
	 SENHA   varchar(10) NULL,
     PASTA   varchar(255) NULL,
     PRIMARY KEY(codigo)
)
WITHOUT OIDS 
TABLESPACE "Producao"
GO

INSERT INTO public.usuarios(razao, cnpj_cpf, cadastr, endereco, bairro, cidade, uf, cep, tel1, tel2, email, senha, pasta) 
	VALUES('ADM', '', '2022-08-01', '', '', '', '', '', '', '', '', '123456','C:\RICARDO')
GO

DROP TABLE IF EXISTS Nfe_Det_Trade;
CREATE TABLE public.Nfe_Det_Trade  ( 
            id_grupo  int4 NOT NULL,
            id_planilha  int4 NOT NULL,
            id_operacao char(1) NOT NULL, 
            nro_linha  int4 NOT NULL,
            cod_emp varchar(6) NOT NULL, 
            local varchar(6) NOT NULL, 
            id_parc varchar(15) NOT NULL, 
            cnpj_cpf varchar(14) NOT NULL, 
            uf char(2) NOT NULL, 
            chave_acesso varchar(44) NOT NULL, 
            nro_doc varchar(20) NOT NULL, 
            nro_item varchar(15) NOT NULL, 
            nro_posicao varchar(9) NOT NULL, 
            dt_doc date NOT NULL,
            dt_lanc date NOT NULL,
            dt_ref date NOT NULL,
            cfop char(6) NOT NULL, 
            origem char(2) NOT NULL, 
            sit_trib char(2) NOT NULL, 
            material varchar(20) NOT NULL, 
            tp_aval varchar(15) NOT NULL, 
            cod_controle varchar(15) NOT NULL, 
            denom varchar(120) NOT NULL, 
            unid char(5) NOT NULL, 
            quantidade_1 numeric(15,4) NOT NULL ,
            quantidade_2 numeric(15,4) NOT NULL ,
            qtd_conv numeric(15,4) NOT NULL ,
            preco_liq numeric(15,2) NOT NULL ,
            liquido numeric(15,2) NOT NULL ,
            valor numeric(15,2) NOT NULL ,
            vlr_contb numeric(15,2) NOT NULL ,
            pis_base numeric(15,2) NOT NULL ,
            stpis char(2) NOT NULL, 
            pis_taxa numeric(6,2) NOT NULL ,
            pis_vlr numeric(15,2) NOT NULL ,
            stcof char(2) NOT NULL, 
            cof_base numeric(15,2) NOT NULL ,
            cof_taxa numeric(6,2) NOT NULL ,
            cof_vlr numeric(15,2) NOT NULL ,
            ipi_base numeric(15,2) NOT NULL ,
            ipi_taxa numeric(6,2) NOT NULL ,
            ipi_vlr numeric(15,2) NOT NULL ,
            icms_base numeric(15,2) NOT NULL ,
            icms_taxa numeric(6,2) NOT NULL ,
            icms_vlr numeric(15,2) NOT NULL ,
            fecp_vlr numeric(15,2) NOT NULL ,
            icst_base numeric(15,2) NOT NULL ,
            icst_taxa numeric(6,2) NOT NULL ,
            icst_valor numeric(15,2) NOT NULL ,
            fest_valor numeric(15,2) NOT NULL ,
            bc_icms_rt numeric(15,2) NOT NULL ,
            vlr_icms_str numeric(15,2) NOT NULL ,
            vlr_fcps_st_rt numeric(15,2) NOT NULL ,
            doc_origem varchar(20) NOT NULL, 
            item_ref varchar(15) NOT NULL, 
            saldo numeric(15,4) NOT NULL ,
            sobra numeric(15,4) NOT NULL ,
            status char(1) NOT NULL, 
			layout char(1) NOT NULL, 
            qtd_dev numeric(15,4) NOT NULL ,
            id_saida  int4 NOT NULL,
            nro_linha_saida  int4 NOT NULL,
            saldo_inicial   numeric(15,4) NOT NULL ,
            qtd_convertida  numeric(15,4) NOT NULL ,
            fator           numeric(06,2) NOT NULL ,
            etapa           int4          NOT NULL default 0,
 	PRIMARY KEY(id_grupo,id_planilha,nro_linha)
)
WITHOUT OIDS 
TABLESPACE "Producao"
GO
CREATE INDEX indice_cfop
	ON public.nfe_det_trade USING btree (id_grupo int4_ops, cod_emp text_ops, local text_ops, id_operacao bpchar_ops, dt_ref date_ops, cfop bpchar_ops)
GO
CREATE INDEX indice_calculo_saldo
	ON public.nfe_det_trade USING btree (id_grupo int4_ops, cod_emp text_ops, local text_ops, dt_ref date_ops, status bpchar_ops, id_operacao bpchar_ops)
GO
CREATE INDEX indice_sai_dev
	ON public.nfe_det_trade USING btree (id_grupo int4_ops, id_operacao bpchar_ops, id_saida int4_ops, nro_linha_saida int4_ops)
GO
CREATE INDEX indice_dev_saida
	ON public.nfe_det_trade USING btree (id_grupo int4_ops, cod_emp text_ops, local text_ops, cfop bpchar_ops, id_operacao bpchar_ops, nro_doc text_ops, material text_ops)
GO
CREATE INDEX indice_dev_entrada
	ON public.nfe_det_trade USING btree (id_grupo int4_ops, cod_emp text_ops, local text_ops, id_operacao bpchar_ops, dt_ref date_ops)
GO



DROP TABLE IF EXISTS nfe_cab_trade;
CREATE TABLE public.nfe_cab_trade  ( 
	id_grupo          	int4 NOT NULL,
	id                	serial NOT NULL,
	arquivo          	varchar(200) NOT NULL,
	qtd               	numeric(15,4) NULL,
	vlr_contabil      	numeric(15,4) NULL,
	bas_icms          	numeric(15,2) NULL,
	vlr_icms          	numeric(15,2) NULL,
	bas_pis           	numeric(15,2) NULL,
	vlr_pis           	numeric(15,4) NULL,
	bas_cof           	numeric(15,2) NULL,
	vlr_cof           	numeric(15,4) NULL,
	bas_ipi           	numeric(15,2) NULL,
	vlr_ipi           	numeric(15,2) NULL,
	bas_icms_st       	numeric(15,2) NULL,
	vlr_icms_st       	numeric(15,2) NULL,
	nro_linha         	int4 NULL,
	usuarioinclusao   	int4 NULL,
	usuarioatualizacao	int4 NULL,
	data_criacao      	timestamp NULL,
	data_fechamento   	timestamp NULL,
	status            	int4 NULL,
	ultima            	int4 NULL,
	layout              char(1) NOT NULL DEFAULT  'S',
    resumo_5405         char(1) NOT NULL DEFAULT  'N',
	PRIMARY KEY(id_grupo,id)
)
WITHOUT OIDS 
TABLESPACE "Producao"
GO
CREATE INDEX nfe_cab_trade_arquivo
	ON public.nfe_cab_trade USING btree (id_grupo int4_ops, arquivo bpchar_ops)
GO

DROP TABLE IF EXISTS Acum_Emp_Local_Cfop_Ano_mes;
CREATE TABLE public.Acum_Emp_Local_Cfop_Ano_mes  ( 
            id_grupo  int4 NOT NULL,
            cod_emp varchar(6) NOT NULL, 
            local varchar(6) NOT NULL,
            ano varchar(4) NOT NULL,
            mes varchar(2) NOT NULL,
            cfop char(4) NOT NULL, 
            quantidade_1 numeric(15,4) NOT NULL ,
            quantidade_2 numeric(15,4) NOT NULL ,
            preco_liq numeric(15,2) NOT NULL ,
            liquido numeric(15,2) NOT NULL ,
            valor numeric(15,2) NOT NULL ,
            vlr_contb numeric(15,2) NOT NULL ,
            pis_base numeric(15,2) NOT NULL ,
            pis_vlr numeric(15,2) NOT NULL ,
            cof_base numeric(15,2) NOT NULL ,
            cof_vlr numeric(15,2) NOT NULL ,
            ipi_base numeric(15,2) NOT NULL ,
            ipi_vlr numeric(15,2) NOT NULL ,
            icms_base numeric(15,2) NOT NULL ,
            icms_vlr numeric(15,2) NOT NULL ,
            fecp_vlr numeric(15,2) NOT NULL ,
            icst_base numeric(15,2) NOT NULL ,
            icst_valor numeric(15,2) NOT NULL ,
            fest_valor numeric(15,2) NOT NULL ,
            bc_icms_rt numeric(15,2) NOT NULL ,
            vlr_icms_str numeric(15,2) NOT NULL ,
            vlr_fcps_st_rt numeric(15,2) NOT NULL ,
 	PRIMARY KEY(id_grupo,cod_emp,local,ano,mes,cfop)
)
WITHOUT OIDS 
TABLESPACE "Producao"
GO


DROP TABLE IF EXISTS Acum_Emp_Local;
CREATE TABLE public.Acum_Emp_Local ( 
            id_grupo  int4 NOT NULL,
            cod_emp varchar(6) NOT NULL, 
            local varchar(6) NOT NULL,
            quantidade_1 numeric(15,4) NOT NULL ,
            quantidade_2 numeric(15,4) NOT NULL ,
            preco_liq numeric(15,2) NOT NULL ,
            liquido numeric(15,2) NOT NULL ,
            valor numeric(15,2) NOT NULL ,
            vlr_contb numeric(15,2) NOT NULL ,
            pis_base numeric(15,2) NOT NULL ,
            pis_vlr numeric(15,2) NOT NULL ,
            cof_base numeric(15,2) NOT NULL ,
            cof_vlr numeric(15,2) NOT NULL ,
            ipi_base numeric(15,2) NOT NULL ,
            ipi_vlr numeric(15,2) NOT NULL ,
            icms_base numeric(15,2) NOT NULL ,
            icms_vlr numeric(15,2) NOT NULL ,
            fecp_vlr numeric(15,2) NOT NULL ,
            icst_base numeric(15,2) NOT NULL ,
            icst_valor numeric(15,2) NOT NULL ,
            fest_valor numeric(15,2) NOT NULL ,
            bc_icms_rt numeric(15,2) NOT NULL ,
            vlr_icms_str numeric(15,2) NOT NULL ,
            vlr_fcps_st_rt numeric(15,2) NOT NULL ,
 	PRIMARY KEY(id_grupo,cod_emp,local)
)
WITHOUT OIDS 
TABLESPACE "Producao"
GO


DROP TABLE IF EXISTS controle_e;
CREATE TABLE public.controle_e  ( 
    id_grupo        int4 NOT NULL,
    id_fechamento   int4 NOT NULL,
	id_s          	int4 NOT NULL,
    nro_linha_s     int4 NOT NULL,
    seq             serial NOT NULL,
	id_e          	int4 NOT NULL,
    nro_linha_e     int4 NOT NULL,
    qtd_s           numeric(15,4) NULL,
	qtd_e   	    numeric(15,4) NULL,
    qtd_d           numeric(15,4) NULL,
    sld_dev         numeric(15,4) NULL,
    flag            char(1) default ' ',
	PRIMARY KEY(id_grupo,id_fechamento,id_s,nro_linha_s,id_e,nro_linha_e)
)
WITHOUT OIDS 
TABLESPACE "Producao"
GO
CREATE INDEX controle_e_id_grupo_id_fec_id_e_nro_e
	ON public.controle_e USING btree (id_grupo int4_ops, id_fechamento int4_ops, id_e int4_ops, nro_linha_e int4_ops)
GO

DROP TABLE IF EXISTS fechamento;
CREATE TABLE public.fechamento  ( 
	id_grupo        int4 NOT NULL,
    id              serial NOT NULL,
	pinicial       	Date NOT NULL,
    pfinal       	Date NOT NULL,
    descricao       varchar(30) NOT NULL,
	user_insert    	int4 NOT NULL,
    dtinicial       timestamp NOT NULL,
    dtfinal         timestamp NOT NULL,
	status          char(1) NOT NULL,
	PRIMARY KEY(id_grupo,id)
)
WITHOUT OIDS 
TABLESPACE "Producao"
GO

DROP TABLE IF EXISTS selic;
CREATE TABLE public.selic  ( 
	ano 	char(4) NOT NULL,
	mes 	char(2) NOT NULL,
	taxa	numeric(6,3) NULL DEFAULT 1,
	PRIMARY KEY(mes,ano)
)
WITHOUT OIDS 
TABLESPACE "Producao"
GO



DROP TABLE IF EXISTS nfe_det_trade_val;
CREATE TABLE public.nfe_det_trade_val  ( 
    id_grupo                        int4 NOT NULL,
	id                            	int4 NOT NULL,
	nro_linha                     	int4 NOT NULL,
    id_planilha_entrada             int4 NOT NULL,
    nro_linha_entrada               int4 NOT NULL,
	dtnfe                         	date NOT NULL,
	dtcredito                     	date NULL,
	vlr_economico_pis             	numeric(18,4) NULL,
	vlr_economico_cofins          	numeric(18,4) NULL,
	dtfcorrecao                   	date NULL,
	vlr_economico_pis_corrigido   	numeric(18,4) NULL,
	vlr_economico_cofins_corrigido	numeric(18,4) NULL,
	taxa                          	numeric(7,2) NULL,
    Icms_St_Unit                    numeric(15,4) NULL,
    qtd_calculada                   numeric(15,4) NULL,
	vlr_economico_pis_pauta         numeric(18,4) NULL,
	vlr_economico_cofins_pauta      numeric(18,4) NULL,
    vlr_economico_pis_corrigido_pauta numeric(18,4) NOT NULL ,
    vlr_economico_cofins_corrigido_pauta    numeric(18,4) ,
	usuarioinclusao               	int4 NULL,
	usuarioatualizacao            	int4 NULL,
	PRIMARY KEY(id_grupo,id,nro_linha,id_planilha_entrada,nro_linha_entrada)
)
WITHOUT OIDS 
TABLESPACE "Producao"
GO

/*
alter table 
nfe_det_trade_val
add column vlr_economico_pis_pauta                 numeric(18,4) not null default 0,
add column vlr_economico_cofins_pauta              numeric(18,4) not null default 0;   
add column vlr_economico_pis_corrigido_pauta       numeric(18,4) not null default 0,
add column vlr_economico_cofins_corrigido_pauta    numeric(18,4) not null default 0;   
*/

DROP TABLE IF EXISTS cont_cab_proc;
CREATE TABLE public.cont_cab_proc( 
    id_grupo      int4        NOT NULL,
    cod_emp       varchar(6)  NOT NULL, 
    local          varchar(6)  NOT NULL,
    CNPJ_CPF       varchar(14) NULL,
    id             serial  NOT NULL,
	status_imp	   char(1) NOT NULL,
    status_dev	   char(1) NOT NULL,
    status_saldos  char(1) NOT NULL,
    status_valor   char(1) NOT NULL,
	PRIMARY KEY(id_grupo,cod_emp,local,cnpj_cpf)
)
WITHOUT OIDS 
TABLESPACE "Producao"
GO
/*
* 0 - Não      Efetuado
* 1 - Efetuado Parcialmente 
* 2 - Efetuado Integralmente
*/

DROP TABLE IF EXISTS cont_det_proc;
CREATE TABLE public.cont_det_proc  ( 
    id_grupo       int4 NOT NULL,
    cod_emp        varchar(6) NOT NULL, 
    local          varchar(6) NOT NULL,
    id_cabec       int4 NOT NULL,
	ano 	       char(4) NOT NULL,
	mes 	       char(2) NOT NULL,
    id_processo    char(1) NOT NULL,
	status  	   char(1) NOT NULL,
	PRIMARY KEY(id_grupo,cod_emp,local,id_cabec,mes,ano,id_processo)
)
WITHOUT OIDS 
TABLESPACE "Producao"
GO
/* id_processo
   1 - Importação
   2 - Devolução
   3 - Saldos
   4 - Calculos
*/
DROP TABLE IF EXISTS controle_s;
CREATE TABLE public.controle_s  ( 
    id_grupo        int4 NOT NULL,
    id_fechamento   int4 NOT NULL,    
    cod_emp         varchar(6) NOT NULL, 
    local           varchar(6) NOT NULL,
    material        varchar(15) NOT NULL,
    id_e            int4 NOT NULL,
    nro_linha_e     int4 NOT NULL,
	qtd_e   	    numeric(15,4) NULL,
    qtd_s   	    numeric(15,4) NULL,
	PRIMARY KEY(id_grupo,id_fechamento,cod_emp,local,material,id_e,nro_linha_e)
)
WITHOUT OIDS 
TABLESPACE "Producao"
GO

DROP TABLE IF EXISTS saldo_inicial;
CREATE TABLE public.saldo_inicial  ( 
    id_grupo         int4 NOT NULL,
    cod_emp          varchar(6) NOT NULL, 
    local            varchar(6) NOT NULL,
	material         char(15) NOT NULL,
    unid             char(5) NOT NULL,
    descricao        varchar(100)  NOT NULL,
	saldo_inicial    numeric(15,4) NOT NULL ,
    saldo_ini_conv   numeric(15,4) NOT NULL ,
    saldo_imp_conv   numeric(15,4) NOT NULL ,
    fator            numeric(06,2) NOT NULL ,
    ct               int4 NOT NULL,
    status           char(1) NOT NULL,
	PRIMARY KEY(id_grupo,cod_emp,local,material,unid)
)
WITHOUT OIDS 
TABLESPACE "Producao"
GO


DROP TABLE IF EXISTS pauta;
CREATE TABLE public.pauta  ( 
    id_grupo         int4 NOT NULL,
    material         varchar(15) NOT NULL,
	descricao        varchar(100) NOT NULL,
	ml   	         int4 NOT NULL,
    pis_vlr_litro    numeric(15,4) NOT NULL,
	cofins_vlr_litro numeric(15,4) NOT NULL,
	PRIMARY KEY(id_grupo,material)
)
WITHOUT OIDS 
TABLESPACE "Producao"
GO



DROP TABLE IF EXISTS resumo_5405;
CREATE TABLE public.resumo_5405  ( 
    id_grupo       int4 NOT NULL,
    cod_emp        varchar(6) NOT NULL, 
    local          varchar(6) NOT NULL,
	material       varchar(15) NOT NULL,
    descricao      varchar(150) NOT NULL,
    unid           char(05) NOT NULL,
    fator          numeric(06,2) NOT NULL ,
    dt_ref         date NOT NULL,
    validade       int4 NOT NULL,
    origem         char(01) NOT NULL default "S"
	PRIMARY KEY(id_grupo,cod_emp,local,material,unid)
)
WITHOUT OIDS 
TABLESPACE "Producao"
GO



DROP TABLE IF EXISTS DE_PARA;
CREATE TABLE public.de_para  ( 
    id_grupo         int4 NOT NULL,
    cod_emp          varchar(6) NOT NULL, 
    local            varchar(6) NOT NULL,
	de_material      char(15) NOT NULL,
    de_unid          char(10) NOT NULL,
    de_descricao     char(150) NOT NULL,
	para_material    char(15) NOT NULL,
    para_unid        char(10) NOT NULL,
    para_descricao   char(150) NOT NULL,
	PRIMARY KEY(id_grupo,cod_emp,local,de_material,para_material)
)
WITHOUT OIDS 
TABLESPACE "Producao"
GO



