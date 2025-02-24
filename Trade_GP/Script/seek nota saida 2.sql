CREATE OR REPLACE FUNCTION "public"."seek_saida_2" (
in  _id_grupo      int4,
in  _cod_empresa   text,
in  _local         text,
in  _id_d          int4,
in  _nro_linha_d   int4,
in  _material_d    text,
in  _qtd_d         numeric(15,4),
in  _dt_ref_d      date,
in  _id_s          int4,
in  _nro_linha_s   int4,
in  _id_fechamento int4,
out _saldo_f       numeric(15,4)
) 
RETURNS numeric(15,4)
AS
$$
DECLARE

controle  public.controle_e%ROWTYPE;
_saldo_e numeric(15,4);
_qtd_abatida numeric(15,4);
_last    date;
_hoje    date;

BEGIN

    _saldo_f = 0;

    RAISE NOTICE  'seek_saida_2 _id_grupo % - _cod_empresa % - _local % - _id_d  % - _nro_linha_d   % -_m aterial_d % - _qtd_d % - _dt_ref_d  % - _id_s  % - _nro_linha_s   % - _id_fechamento % ',
                   _id_grupo  , _cod_empresa , _local , _id_d  , _nro_linha_d   ,_material_d , _qtd_d , _dt_ref_d  , _id_s  , _nro_linha_s   , _id_fechamento   ;

    _qtd_abatida := _qtd_d;

     FOR controle in  
     
      SELECT *
      FROM   controle_e CONTROL 
      WHERE  CONTROL.id_grupo = _id_grupo and CONTROL.id_fechamento = _id_fechamento and CONTROL.id_s = _id_s and CONTROL.nro_linha_s = _nro_linha_s
      ORDER BY  CONTROL.id_grupo , CONTROL.id_fechamento , CONTROL.id_s , CONTROL.nro_linha_s 
      LOOP      

          RAISE NOTICE  'ID_S % - NRO_LINHA_S % QTD % ', controle.id_s, controle.nro_linha_s, controle.qtd_e;

          IF (_qtd_abatida > 0 ) THEN 

                IF ( _qtd_abatida >= controle.qtd_e ) THEN

                    UPDATE controle_e set qtd_e = 0 where id_grupo = _id_grupo and id_fechamento = _id_fechamento and id_s = _id_s and nro_linha_s = _nro_linha_s;

                    _qtd_abatida := _qtd_abatida - controle.qtd_e;

                ELSE

                   UPDATE controle_e set qtd_e = qtd_e - _qtd_abatida  where id_grupo = _id_grupo and id_fechamento = _id_fechamento and id_s = _id_s and nro_linha_s = _nro_linha_s;

                    _qtd_abatida := 0;

               END IF;

         END IF;
      END LOOP;
      INSERT INTO controle_e(id_grupo,id_fechamento,id_s, nro_linha_s, id_e, nro_linha_e, qtd_s, qtd_e, qtd_d,flag) 	
      VALUES(_id_grupo,_id_fechamento,_id_s, _nro_linha_s,_id_d , _nro_linha_d, 0, 0 , _qtd_d, 'D');
END;
$$
LANGUAGE 'plpgsql'
go
