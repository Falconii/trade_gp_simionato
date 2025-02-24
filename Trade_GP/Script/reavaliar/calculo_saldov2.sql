CREATE OR REPLACE FUNCTION "public"."calculo_saldov2" (in _id_grupo int4, in _cod_emp text, in _local text , in _mes_ano text, in _id_fechamento int, out _saida int) 
AS
$$
DECLARE

tempo    public.nfe_det_trade%ROWTYPE;

__saldo_f     numeric(15,4);


BEGIN

  _saida := 0;

  FOR tempo in  
     
      SELECT *
      FROM   nfe_det_trade DET
      WHERE  DET.id_grupo = _id_grupo and DET.cod_emp = _cod_emp and Det.local = _local and ( (det.id_operacao = 'S' and det.status = '0') OR (det.id_operacao = 'Z' and det.status = '0')) and (TO_CHAR(det.dt_ref,'DD/MM/YYYY') = _mes_ano)  
      ORDER BY DET.id_grupo,DET.cod_emp,DET.local,DET.dt_ref,DET.nro_doc,DET.nro_item 

      LOOP      
             //Processando as entradas

           //RAISE NOTICE  'DATA % NRO % ITEM % OPERACAO % ', tempo.dt_ref,tempo.nro_doc,tempo.nro_item,tempo.id_operacao;

           IF (tempo.id_operacao = 'Z') then
 
               //RAISE NOTICE  'calculo_saldo Z ';
               select _saldo_f from seek_saida_2(tempo.id_grupo,tempo.cod_emp,tempo.local,tempo.id_planilha,tempo.nro_linha,tempo.material,tempo.quantidade_1,tempo.dt_ref,tempo.id_saida,tempo.nro_linha_saida,_id_fechamento) into __saldo_f ;
               update nfe_det_trade set status = '1' where id_grupo = tempo.id_grupo and id_planilha = tempo.id_planilha and nro_linha = tempo.nro_linha;

           else 

              select _saldo_f from seek_entrada_2(tempo.id_grupo,tempo.id_planilha,tempo.nro_linha,tempo.cod_emp,tempo.local,tempo.material,tempo.dt_ref,tempo.saldo,_id_fechamento) into __saldo_f ;
            
              update nfe_det_trade set saldo = __saldo_f , status = '1' where id_grupo = tempo.id_grupo and id_planilha = tempo.id_planilha and nro_linha = tempo.nro_linha;

           end if;

            _saida := _saida + 1;

      END LOOP;

    

END;
$$
LANGUAGE 'plpgsql'
go
