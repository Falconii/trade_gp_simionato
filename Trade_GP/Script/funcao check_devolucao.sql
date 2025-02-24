DROP TYPE IF EXISTS Sai_Dev;
CREATE TYPE Sai_Dev AS 
(
sai_id_grupo     int4,
sai_id_planilha  int4,
sai_nro_linha    int4,
sai_id_operacao  text,
sai_dt_ref       text,
sai_cfop         text,
sai_nro_doc      text,
sai_nro_item     text,
sai_material     text,
sai_denom        text,
sai_unid         text,
sai_quantidade_1 numeric(15,4),
sai_valor        numeric(15,4),
sai_icst_valor   numeric(15,2),
sai_fest_valor   numeric(15,2),
sai_id_saida     int4,
sai_nro_linha_saida    int4,
dev_id_grupo     int4,
dev_id_planilha  int4,
dev_nro_linha    int4,
dev_id_operacao  text,
dev_dt_ref       Date,
dev_cfop         text,
dev_nro_doc      text,
dev_nro_item     text,
dev_material     text,
dev_denom        text,
dev_unid         text,
dev_quantidade_1 numeric(15,4),
dev_valor        numeric(15,4),
dev_icst_valor   numeric(15,2),
dev_fest_valor   numeric(15,2),
dev_doc_origem   text,
dev_id_saida     int4,
dev_nro_linha_saida    int4
);

CREATE OR REPLACE FUNCTION "public"."check_devolucao" (
                           in _grupo int4, in _cod_emp text , in _local text , in _mes_ano text  , out _qtd_dev int4)  
AS
$$
DECLARE

 sai_dev public.Sai_Dev%ROWTYPE;


 Comentarios boolean;  

 __id_saida int4;

 __nro_linha int4;

BEGIN

        Comentarios = true;

        _qtd_dev     = 0;

        __id_saida  = 0 ;

        __nro_linha = 0 ;
 
        //RAISE NOTICE  'Gravação de saldos % % % % % ' ,  _empresa  , _filial  ,  _cdcc , _ano   , _mes   ;
       
        FOR sai_dev in SELECT sai.id_grupo,sai.id_planilha,sai.nro_linha,sai.id_operacao,sai.dt_ref,sai.cfop,sai.nro_doc,sai.nro_item,sai.material,sai.denom,sai.unid,sai.quantidade_1,sai.valor,sai.icst_valor,sai.fest_valor,sai.id_saida,sai.nro_linha_saida,
                              dev.id_grupo,dev.id_planilha,dev.nro_linha,dev.id_operacao,dev.dt_ref,dev.cfop,dev.nro_doc,dev.item_ref,dev.material,dev.denom,dev.unid,dev.quantidade_1,dev.valor,dev.icst_valor,dev.fest_valor,dev.doc_origem,dev.id_saida,dev.nro_linha_saida
                              FROM       nfe_det_trade dev 
                              left join nfe_det_trade sai  ON  sai.id_grupo = _grupo and sai.cod_emp = _cod_emp  and sai.local = _local and ( (left(sai.cfop,4) = '5405')) and sai.id_operacao = 'S' and sai.nro_doc = dev.doc_origem and sai.material = dev.material
                              where      dev.id_grupo = _grupo and dev.cod_emp = _cod_emp  and dev.local = _local and  to_char(dev.dt_ref,'MM/YYYY') = _mes_ano  and dev.id_operacao = 'Z' 
                              order by   dev.id_grupo,dev.cod_emp,dev.local,dev.dt_ref,dev.dt_doc,dev.nro_item

            LOOP            
               
                //RAISE NOTICE  'Nota % ', sai_dev.sai_nro_doc;
                
                if (sai_dev.sai_nro_doc is null) 
                     then
                        UPDATE public.nfe_det_trade SET id_operacao = 'z'
                        WHERE id_grupo = sai_dev.dev_id_grupo and id_planilha = sai_dev.dev_id_planilha and nro_linha = sai_dev.dev_nro_linha ;
                     else 
                        select _id_saida, _nro_linha from seek_dev_saida(
                            _grupo               ,
                            _cod_emp              ,
                            _local                  ,
                            sai_dev.dev_id_planilha ,
                            sai_dev.dev_nro_linha   ,
                            sai_dev.dev_doc_origem  ,
                            sai_dev.dev_material    ,
                            sai_dev.dev_quantidade_1       
                          ) into __id_saida, __nro_linha;
                        RAISE NOTICE  'ID % NRO_LINHA % ',__id_saida, __nro_linha ;
                        if (__id_saida > 0) then
                          UPDATE public.nfe_det_trade SET id_saida = __id_saida, nro_linha_saida = __nro_linha
                          WHERE id_grupo = sai_dev.dev_id_grupo and id_planilha = sai_dev.dev_id_planilha and nro_linha = sai_dev.dev_nro_linha ;
                         _qtd_dev := _qtd_dev + 1;
                        else
                          UPDATE public.nfe_det_trade SET id_operacao = 'z'
                          WHERE id_grupo = sai_dev.dev_id_grupo and id_planilha = sai_dev.dev_id_planilha and nro_linha = sai_dev.dev_nro_linha ;
                        end if;
               end if;
            END LOOP;
            
            RETURN; 
END;
$$
LANGUAGE 'plpgsql'
go


select * from check_devolucao(1,'1004','0002','01/2017');
go
select * from check_devolucao(1,'1004','0002','02/2017');
go
select * from check_devolucao(1,'1004','0002','03/2017');
go
select * from check_devolucao(1,'1004','0002','04/2017');
go
select * from check_devolucao(1,'1004','0004','05/2017');
go

select * from check_devolucao(1,'','0004','05/2017');

select * from check_devolucao(1,'1004','0002','06/2017');
go



group by cod_emp,local 



select *
from nfe_det_trade 
where cod_emp = '1004' and local = '0004' and to_char(dt_ref,'MM-YYYY') = '05-2017' and id_operacao = 'z'



//select * from nfe_det_trade where id_operacao = 'z';

select * from nfe_det_trade where cod_emp = '1004' and local = '0002' and id_operacao = 'Z' and  to_char(dt_ref,'MM-YYYY') = '02-2017'

select * from nfe_det_trade where TRIM(nro_doc) = '8624068922'

update nfe_det_trade set id_operacao = 'Z' where id_operacao = 'z'



SELECT                        sai.id_grupo,sai.id_planilha,sai.nro_linha,sai.id_operacao,sai.dt_doc,sai.cfop,sai.nro_doc,sai.nro_item,sai.material,sai.denom,sai.unid,sai.quantidade_1,sai.valor,sai.icst_valor,sai.fest_valor,
                              '<<==>>' as SAIDA_DEVOLUÇÃO,
                              dev.id_grupo,dev.id_planilha,dev.nro_linha,dev.id_operacao,dev.dt_lanc,dev.cfop,dev.nro_doc,dev.nro_item,dev.doc_origem,dev.item_ref,dev.material,dev.denom,dev.unid,dev.quantidade_1,dev.valor,dev.icst_valor,dev.fest_valor,dev.id_saida,dev.nro_linha_saida
                              FROM       nfe_det_trade dev 
                              left join nfe_det_trade sai  ON  sai.id_grupo = 1 and sai.cod_emp = '1004'  and sai.local = '0004'  and  sai.id_planilha = dev.id_saida and sai.nro_linha = dev.nro_linha_saida
                              where      dev.cod_emp = '1004'  and dev.local = '0004' and to_char(dev.dt_ref,'MM/YYYY') = '05/2017'  and dev.id_operacao = 'Z' 
                              order by   sai.dt_doc,sai.nro_item;
go


SELECT * FROM nfe_det_trade SAI  WHERE sai.id_grupo = 1 and sai.cod_emp = '1004'  and sai.local = '0004' and ( (left(sai.cfop,4) = '5405')) and sai.id_operacao = 'S'


select * from nfe_det_trade where nro_doc ='8630841710'


SELECT * FROM nfe_cab_trade
/*
CREATE TABLE DETALHE AS 
        SELECT * FROM nfe_det_trade where (id_planilha = 11 and nro_linha = 8839) or 
                                          (id_planilha = 11 and nro_linha = 8151) or
                                          (id_planilha = 05 and nro_linha = 929)  or
                                          (id_planilha = 05 and nro_linha = 1075);  
*/

/* cria ambiente de teste 


truncate controle_e;
go
DROP TABLE IF EXISTS Nfe_Det_Trade;
CREATE TABLE nfe_det_trade AS select * from detalhe;
GO
ALTER TABLE nfe_det_trade
ADD PRIMARY KEY(id_grupo,id_planilha,nro_linha);
CREATE INDEX indice_cfop
	ON public.nfe_det_trade USING btree (id_grupo int4_ops, cod_emp text_ops, local text_ops, id_operacao bpchar_ops, dt_ref date_ops, cfop bpchar_ops)
GO
*/

select doc_origem,item_ref,id_saida,nro_linha_saida,*
from nfe_det_trade 
where id_operacao = 'Z' and to_char(dt_ref,'MM-YYYY') = '05-2017'

select * from nfe_det_trade where nro_doc = '8630836047'
