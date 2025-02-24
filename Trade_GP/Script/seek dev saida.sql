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
