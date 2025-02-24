CREATE OR REPLACE FUNCTION "public"."busca_saida_devolucao" (
in  _id_grupo      int4,
in  _cod_emp       text,
in  _local         text,
in  _doc_origem    text,
in  _material      text,
in  _data          date,
in  _qtd_dev       numeric(15,4),
in  _id_dev        int4,
in  _nro_linha_dev int4,   
in  _id_fechamento int4,
out _saldo_f       numeric(15,4)
) 
RETURNS numeric(15,4)
AS
$$
DECLARE

SAIDA  public.nfe_det_trade%ROWTYPE;

BEGIN

    //Processando as entradas
    FOR SAIDA in  
       SELECT *
       FROM NFE_DET_TRADE SAI
       WHERE  SAI.id_grupo = _id_grupo and SAI.cod_emp = _cod_emp and SAI.local = _local and SAI.id_operacao = 'S' and SAI.material = _material and left(SAI.cfop,4) = '5405'
       ORDER BY SAI.cod_emp,SAI.local,SAI.material,SAI.nro_item asc
    LOOP     
           
           RAISE NOTICE 'SAIDA.cod_empresa % SAIDA.local % SAIDA.material % SAIDA.dtlanc % SAIDA.qtd % SAIDA.saldo % SAIDA.status %', saida.cod_empresa,saida.local,saida.material,saida.dtlanc,saida.qtd, saida.saldo, saida.status;

           RAISE NOTICE '_id_grupo % _id_s  % _nro_linha_s % _cod_empresa % _local % _material  % _data  % _saldo_s % ', _id_grupo,_id_s,_nro_linha_s,_cod_empresa,_local,_material,_data,_saldo_s;

          // _saldo_e := saida.saldo;

           //Tratamento
           //IF (_saldo_s >= _saldo_e) THEN

           //    _qtd     := _saldo_e;

           //    _saldo_s := _saldo_s - _saldo_e;

           //    _saldo_e :=  0;

          // ELSE 

         //     _qtd      := _saldo_s;

         //     _saldo_e  := _saldo_e - _saldo_s;

         //     _saldo_s  := 0; 

         //  END IF;

         //  _saldo_f := _saldo_s;

          //Atualiza nota e

          //update nfe_det_trade set saldo = _saldo_e where id_grupo = entrada.id_grupo and id_planilha = entrada.id_planilha and nro_linha = entrada.nro_linha;
          
          //INSERT INTO controle_e(id_grupo,id_fechamento,id_s, nro_linha_s, id_e, nro_linha_e, qtd_s, qtd_e) 	VALUES(_id_grupo,_id_fechamento,_id_s, _nro_linha_s,entrada.id_planilha , entrada.nro_linha, _saldo_f, _qtd);


          //IF (_saldo_f = 0) THEN

          //    return;

         // END IF;

    END LOOP;

END;
$$
LANGUAGE 'plpgsql'
go

select * from busca_saida_devolucao(1,'1004','0004','8631841723','1010947','2017-05-17',15,5,929,1);

SELECT *
       FROM NFE_DET_TRADE SAI
       WHERE  SAI.id_grupo = 1 and SAI.cod_emp = '10041 and SAI.local = '0004' and SAI.id_operacao = 'S' and SAI.material = _material and left(SAI.cfop,4) = '5405'
       ORDER BY SAI.cod_emp,SAI.local,SAI.material,SAI.nro_item asc

//select * from nfe_det_trade