DROP TYPE IF EXISTS Devo;
CREATE TYPE Devo AS 
(
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



/*

  seek_dev_saida

  função usada na check_devolução

*/

CREATE OR REPLACE FUNCTION "public"."seek_dev_saida" (
in  _id_grupo     int4,
in  _cod_emp      text,
in  _local        text,
in  _id_d         int4,
in  _nro_linha_d  int4,
in  _doc_origem   text,
in  _material     text,
in  _qtd_d        numeric(15,4),
out _id_saida int4, 
out _nro_linha int4
) 
RETURNS record
AS
$$
DECLARE

saida  public.nfe_det_trade%ROWTYPE;

BEGIN
    //Processando as saidas
   _id_saida  := 0;
   _nro_linha := 0;
    FOR saida in  
       SELECT *
       FROM NFE_DET_TRADE SAI
       WHERE  SAI.id_grupo = _id_grupo and SAI.cod_emp = _cod_emp and SAI.local = _local and SAI.material = _material and  sai.id_operacao = 'S' and LEFT(SAI.cfop,4) = '5405' and sai.nro_doc = _doc_origem and sai.material = _material
       ORDER BY SAI.cod_emp, SAI.local, SAI.dt_ref, SAI.nro_doc, SAI.nro_item 
    LOOP     
           
        RAISE NOTICE 'SAIDA.cod_empresa % SAIDA.local % SAIDA.material % SAIDA.dtlanc % SAIDA.quantidade_1 % SAIDA.saldo % SAIDA.status %', SAIDA.cod_emp,SAIDA.local,SAIDA.material,SAIDA.dt_lanc,SAIDA.quantidade_1, SAIDA.saldo, SAIDA.status;

           //RAISE NOTICE '_id_grupo % _id_s  % _nro_linha_s % _cod_empresa % _local % _material  % _data  % _saldo_s % ', _id_grupo,_id_s,_nro_linha_s,_cod_empresa,_local,_material,_data,_saldo_s;

       IF (SAIDA.quantidade_1 = _qtd_d) THEN

           _id_saida  := SAIDA.id_planilha;
           _nro_linha := SAIDA.nro_linha;

           RAISE NOTICE 'ACHOU ID % NRO_LINHA % ',SAIDA.id_planilha, SAIDA.nro_linha; 

       END IF;

    END LOOP;

END;
$$
LANGUAGE 'plpgsql'
go




/*

   check_devolucao

   24/05  

*/
CREATE OR REPLACE FUNCTION "public"."check_devolucao" (
                           in _grupo int4, in _cod_emp text , in _local text , in _mes_ano text  , out _qtd_dev int4)  
AS
$$
DECLARE

 Devo public.Devo%ROWTYPE;


 Comentarios boolean;  

 __id_saida int4;

 __nro_linha int4;

sai_nro_doc text;

BEGIN

        Comentarios = true;

        _qtd_dev     = 0;

        __id_saida  = 0 ;

        __nro_linha = 0 ;
 
        //RAISE NOTICE  'Gravação devolucoes % % % % % ' ,  _empresa  , _filial  ,  _cdcc , _ano   , _mes   ;
       
        FOR Devo in SELECT     --sai.id_grupo,sai.id_planilha,sai.nro_linha,sai.id_operacao,sai.dt_ref,sai.cfop,sai.nro_doc,sai.nro_item,sai.material,sai.denom,sai.unid,sai.quantidade_1,sai.valor,sai.icst_valor,sai.fest_valor,sai.id_saida,sai.nro_linha_saida,
                                dev.id_grupo,dev.id_planilha,dev.nro_linha,dev.id_operacao,dev.dt_ref,dev.cfop,dev.nro_doc,dev.item_ref,dev.material,dev.denom,dev.unid,dev.quantidade_1,dev.valor,dev.icst_valor,dev.fest_valor,dev.doc_origem,dev.id_saida,dev.nro_linha_saida
                              FROM       nfe_det_trade dev 
                              --left join nfe_det_trade sai  ON  sai.id_grupo = _grupo and sai.cod_emp = _cod_emp  and sai.local = _local and ( (left(sai.cfop,4) = '5405')) and sai.id_operacao = 'S' and sai.nro_doc = dev.doc_origem and sai.material = dev.material
                              where      dev.id_grupo = _grupo and dev.cod_emp = _cod_emp  and dev.local = _local and  to_char(dev.dt_ref,'MM/YYYY') = _mes_ano  and dev.id_operacao = 'Z' 
                              order by   dev.id_grupo,dev.cod_emp,dev.local,dev.dt_ref,dev.dt_doc,dev.nro_item

            LOOP            
               
                //RAISE NOTICE  'Nota % ', devo.dev_nro_doc;  


                select nro_doc from nfe_det_trade into sai_nro_doc where  id_grupo = _grupo and cod_emp = _cod_emp  and local = _local and ( (left(cfop,4) = '5405')) and id_operacao = 'S' and nro_doc = devo.dev_doc_origem and material = devo.dev_material;

                if (sai_nro_doc is null) then
                     //RAISE NOTICE  'não achei % ', sai_nro_doc;
                else 
                     //RAISE NOTICE  'encontrado % ', sai_nro_doc;
                end if;

                if (sai_nro_doc is null) 
                     then
                        UPDATE public.nfe_det_trade SET id_operacao = 'z'
                        WHERE id_grupo = devo.dev_id_grupo and id_planilha = devo.dev_id_planilha and nro_linha = devo.dev_nro_linha ;
                     else 
                        select _id_saida, _nro_linha from seek_dev_saida(
                            _grupo                  ,
                            _cod_emp                ,
                            _local                  ,
                            devo.dev_id_planilha ,
                            devo.dev_nro_linha   ,
                            devo.dev_doc_origem  ,
                            devo.dev_material    ,
                            devo.dev_quantidade_1       
                          ) into __id_saida, __nro_linha;
                        RAISE NOTICE  'ID % NRO_LINHA % ',__id_saida, __nro_linha ;
                        if (__id_saida > 0) then
                          UPDATE public.nfe_det_trade SET id_saida = __id_saida, nro_linha_saida = __nro_linha
                          WHERE id_grupo = devo.dev_id_grupo and id_planilha = devo.dev_id_planilha and nro_linha = devo.dev_nro_linha ;
                         _qtd_dev := _qtd_dev + 1;
                        else
                          UPDATE public.nfe_det_trade SET id_operacao = 'z'
                          WHERE id_grupo = devo.dev_id_grupo and id_planilha = devo.dev_id_planilha and nro_linha = devo.dev_nro_linha ;
                        end if;
               end if;

            END LOOP;
            
            RETURN; 
END;
$$
LANGUAGE 'plpgsql'
go

/*
select * from check_devolucao(1,'1002','0025','02/2017');

SELECT sai.id_grupo,sai.id_planilha,sai.nro_linha,sai.id_operacao,sai.dt_ref,sai.cfop,sai.nro_doc,sai.nro_item,sai.material,sai.denom,sai.unid,sai.quantidade_1,sai.valor,sai.icst_valor,sai.fest_valor,sai.id_saida,sai.nro_linha_saida,
                              dev.id_grupo,dev.id_planilha,dev.nro_linha,dev.id_operacao,dev.dt_ref,dev.cfop,dev.nro_doc,dev.item_ref,dev.material,dev.denom,dev.unid,dev.quantidade_1,dev.valor,dev.icst_valor,dev.fest_valor,dev.doc_origem,dev.id_saida,dev.nro_linha_saida
                              FROM       nfe_det_trade dev 
                              left join nfe_det_trade sai  ON  sai.id_grupo = 1 and sai.cod_emp = '1002'  and sai.local = '0025' and ( (left(sai.cfop,4) = '5405')) and sai.id_operacao = 'S' and sai.nro_doc = dev.doc_origem and sai.material = dev.material
                              where      dev.id_grupo = 1 and dev.cod_emp = '1002'  and dev.local = '0025' and   dev.id_operacao = 'Z' and dev.dt_ref >= '2016-12-01' and dev.id_saida <= 0
                              order by   dev.id_grupo,dev.cod_emp,dev.local,dev.dt_ref,dev.dt_doc,dev.nro_item
*/
