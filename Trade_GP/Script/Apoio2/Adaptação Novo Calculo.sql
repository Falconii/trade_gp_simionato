
       DROP TYPE IF EXISTS fields_entrada;
       CREATE TYPE fields_entrada AS 
        (
	        id_grupo        int4,
            id_planilha     int4,
            nro_linha       int4,
		    id_operacao     text,
		    cod_emp         text,
		    local           text,
		    material        text,     
		    dt_ref          date,
		    saldo           numeric(15,4),
		    quantidade_1    numeric(15,4),
		    id_saida        int4,
		    nro_linha_saida int4,
		    qtd_convertida  numeric(15,4),
		    alternativo     text,
            validade        int4
        );
    
    CREATE OR REPLACE FUNCTION "public"."seek_in_2v1"(
        in  _id_grupo     int4,
        in  _id_s         int4,
        in  _nro_linha_s  int4,
        in  _cod_empresa  text,
        in  _local        text,
        in  _material     text,
        in  _data         date, 
        in  _saldo_s      numeric(15,4),
        in  _id_fechamento int4,
        in  _validade      int4,
        out _saldo_f      numeric(15,4)
        ) 
        RETURNS numeric(15,4)
        AS
        $$
        DECLARE

        entrada  public.nfe_det_trade%ROWTYPE;
        _saldo_e numeric(15,4);
        _qtd     numeric(15,4);
        _last    date;
        _hoje    date;

        BEGIN
    
        
            /*RAISE NOTICE 'seek_in_2v1';*/


            _saldo_f := _saldo_s;
            _qtd     := 0;
            _hoje    := CURRENT_DATE;
            //_data    := Date '2017-02-28';
            //_last    := _hoje  - interval '4 years 11 months';
            _last      := _data - (_validade * interval '1 day');
            //Processando as entradas
            FOR entrada in  
               SELECT *
               FROM NFE_DET_TRADE ENT
               WHERE  ENT.id_grupo = _id_grupo and ENT.cod_emp = _cod_empresa and ENT.local = _local and ENT.material = _material and 
                      ((ENT.id_operacao = 'E'  AND ENT.saldo > 0) ) 
                      and ( ENT.dt_ref >= _LAST AND ENT.dt_ref <= _data)
               ORDER BY ENT.cod_emp,ENT.local,ENT.material,ENT.dt_ref,ENT.id_operacao 
            LOOP     
           
                   //RAISE NOTICE 'ENTRADA.cod_empresa % ENTRADA.local % ENTRADA.material % ENTRADA.dtlanc % ENTRADA.qtd % ENTRADA.saldo % ENTRADA.status %', entrada.cod_emp,entrada.local,entrada.material,entrada.dtlanc,entrada.qtd, entrada.saldo, entrada.status;

                   //RAISE NOTICE '_id_grupo % _id_s  % _nro_linha_s % _cod_empresa % _local % _material  % _data  % _saldo_s % ', _id_grupo,_id_s,_nro_linha_s,_cod_empresa,_local,_material,_data,_saldo_s;

                    _saldo_e := entrada.saldo;

                   //Tratamento
                   IF (_saldo_s >= _saldo_e) THEN

                       _qtd     := _saldo_e;

                       _saldo_s := _saldo_s - _saldo_e;

                       _saldo_e :=  0;

                   ELSE 

                      _qtd      := _saldo_s;

                      _saldo_e  := _saldo_e - _saldo_s;

                      _saldo_s  := 0; 

                   END IF;

                   _saldo_f := _saldo_s;

                  //atualizacao feita pela trigger
                  //Atualiza nota e
                  //update nfe_det_trade set saldo = _saldo_e where id_grupo = entrada.id_grupo and id_planilha = entrada.id_planilha and nro_linha = entrada.nro_linha;
          
                  INSERT INTO controle_e(id_grupo,id_fechamento,id_s, nro_linha_s, id_e, nro_linha_e, qtd_s, qtd_e) VALUES(_id_grupo,_id_fechamento,_id_s, _nro_linha_s,entrada.id_planilha , entrada.nro_linha, _saldo_f, _qtd);
 
                  IF (_saldo_f = 0) THEN

                      return;

                  END IF;

            END LOOP;

        END;
        $$
        LANGUAGE 'plpgsql'
        go

    /*
    DROP FUNCTION IF EXISTS public.calculo_saldov2(integer, text, text, text, integer);
    CREATE OR REPLACE FUNCTION public.calculo_saldov2(
	        _id_grupo integer,
	        _cod_emp text,
	        _local text,
	        _mes_ano text,
	        _id_fechamento integer,
	        OUT _saida integer)
            RETURNS integer
            LANGUAGE 'plpgsql'
            COST 100
            VOLATILE PARALLEL UNSAFE
        AS $$
        DECLARE

        tempo    fields_entrada%ROWTYPE;

        __saldo_f     numeric(15,4);

        BEGIN

          _saida := 0;

          FOR tempo in  
     
            SELECT  det.id_grupo	,   
                    det.id_planilha	,   
                    det.nro_linha	,   
                    det.id_operacao ,
                    det.cod_emp	,       
                    det.local,	       
                    det.material,	   
                    det.dt_ref	,       
                    det.saldo	,       
                    det.quantidade_1,
                    det.id_saida,	   
                    det.nro_linha_saida,
                    det.qtd_convertida,
                    coalesce(depara.para_material,'') as alternativo,
                    res.validade                      as validade
              FROM   nfe_det_trade DET
              INNER JOIN RESUMO_5405 RES    ON RES.id_grupo = det.id_grupo and RES.cod_emp = det.cod_emp and RES.local = det.local and RES.material = det.material
              LEFT  JOIN de_para     depara on depara.id_grupo = det.id_grupo and depara.cod_emp = det.cod_emp and depara.local = det.local and depara.de_material = det.material
              WHERE  DET.id_grupo = _id_grupo and DET.cod_emp = _cod_emp and Det.local = _local and 
                     ( 
                       ( ((det.id_operacao = 'S'))  and det.status = '0') 
                       OR 
                       ( ((det.id_operacao = 'Z'))  and det.status = '0')
                     )
                     and (det.dt_ref >= '2017-03-16') and (TO_CHAR(det.dt_ref,'DD/MM/YYYY') = _mes_ano) 
               ORDER BY DET.id_grupo,DET.cod_emp,DET.local,DET.dt_ref , DET.id_operacao desc ,DET.nro_doc,DET.nro_item 

              LOOP      
                     
                   IF ((tempo.id_operacao = 'Z')) then
                
                       select _saldo_f from seek_saida_2(tempo.id_grupo,tempo.cod_emp,tempo.local,tempo.id_planilha,tempo.nro_linha,tempo.material,tempo.qtd_convertida,tempo.dt_ref,tempo.id_saida,tempo.nro_linha_saida,_id_fechamento) into __saldo_f ;
                       update nfe_det_trade set status = '1' where id_grupo = tempo.id_grupo and id_planilha = tempo.id_planilha and nro_linha = tempo.nro_linha;

                   else 

                      if (tempo.id_operacao = 'S') then

                          //RAISE NOTICE 'tempo.material % tempo.dt_ref % tempo.saldo % tempo.validade ',tempo.material , tempo.dt_ref , tempo.saldo, tempo.validade;
                      
                          select _saldo_f from seek_in_2V1(tempo.id_grupo,tempo.id_planilha,tempo.nro_linha,tempo.cod_emp,tempo.local,tempo.material,tempo.dt_ref,tempo.saldo,_id_fechamento,tempo.validade) into __saldo_f ;

                          if (__saldo_f > 0  and tempo.alternativo <> '') then 
                      
                             select _saldo_f from seek_in_2V1(tempo.id_grupo,tempo.id_planilha,tempo.nro_linha,tempo.cod_emp,tempo.local,tempo.alternativo,tempo.dt_ref,__saldo_f,_id_fechamento,tempo.validade) into __saldo_f ;

                          end if;

                          update nfe_det_trade set saldo = __saldo_f , status = '1' where id_grupo = tempo.id_grupo and id_planilha = tempo.id_planilha and nro_linha = tempo.nro_linha;
             
                       end if;
                   
                   end if;

                   _saida := _saida + 1;

              END LOOP;

        END;
        $$;
    go
    */

    DROP FUNCTION IF EXISTS public.calculo_saldov2(integer, text, text, text, integer);
    CREATE OR REPLACE FUNCTION public.calculo_saldov2(
	        _id_grupo integer,
	        _cod_emp text,
	        _local text,
	        _mes_ano text,
	        _id_fechamento integer,
	        OUT _saida integer)
            RETURNS integer
            LANGUAGE 'plpgsql'
            COST 100
            VOLATILE PARALLEL UNSAFE
        AS $$
        DECLARE

        tempo    fields_entrada%ROWTYPE;

        __saldo_f     numeric(15,4);

        _Prazo int4;

        _Fim_Val int4;

        _Etapa int4;

        BEGIN

          _saida := 0;

          FOR tempo in  
     
            SELECT  det.id_grupo	,   
                    det.id_planilha	,   
                    det.nro_linha	,   
                    det.id_operacao ,
                    det.cod_emp	,       
                    det.local,	       
                    det.material,	   
                    det.dt_ref	,       
                    det.saldo	,       
                    det.quantidade_1,
                    det.id_saida,	   
                    det.nro_linha_saida,
                    det.qtd_convertida,
                    coalesce(depara.para_material,'') as alternativo,
                    res.validade                      as validade
              FROM   nfe_det_trade DET
              INNER JOIN RESUMO_5405 RES    ON RES.id_grupo = det.id_grupo and RES.cod_emp = det.cod_emp and RES.local = det.local and RES.material = det.material
              LEFT  JOIN de_para     depara on depara.id_grupo = det.id_grupo and depara.cod_emp = det.cod_emp and depara.local = det.local and depara.de_material = det.material
                  WHERE  DET.id_grupo = _id_grupo and DET.cod_emp = _cod_emp and Det.local = _local and 
                         ( 
                           ( ((det.id_operacao = 'S'))  and det.status = '0') 
                           OR 
                           ( ((det.id_operacao = 'Z'))  and det.status = '0')
                         )
                         and (det.dt_ref >= '2017-03-16') and (TO_CHAR(det.dt_ref,'DD/MM/YYYY') = _mes_ano) 
                   ORDER BY DET.id_grupo,DET.cod_emp,DET.local,DET.dt_ref , DET.id_operacao desc ,DET.nro_doc,DET.nro_item 

              LOOP      
                     
                   IF ((tempo.id_operacao = 'Z')) then
                
                       select _saldo_f from seek_saida_2(tempo.id_grupo,tempo.cod_emp,tempo.local,tempo.id_planilha,tempo.nro_linha,tempo.material,tempo.qtd_convertida,tempo.dt_ref,tempo.id_saida,tempo.nro_linha_saida,_id_fechamento) into __saldo_f ;
                       update nfe_det_trade set status = '1' where id_grupo = tempo.id_grupo and id_planilha = tempo.id_planilha and nro_linha = tempo.nro_linha;

                   else 

                      if (tempo.id_operacao = 'S') then

                          //RAISE NOTICE 'tempo.material % tempo.dt_ref % tempo.saldo % tempo.validade ',tempo.material , tempo.dt_ref , tempo.saldo, tempo.validade;
                      
                          _Prazo    := 0;
                          _Fim_Val  := 0;
                          _Etapa    := 1;

                          //Etapa 1 
                          if tempo.validade > 60 then
                             _Prazo := 60;
                          else
                             _Prazo := tempo.validade;
                             _Fim_val := 1;
                          end if;

                          select _saldo_f from seek_in_2V1(tempo.id_grupo,tempo.id_planilha,tempo.nro_linha,tempo.cod_emp,tempo.local,tempo.material,tempo.dt_ref,tempo.saldo,_id_fechamento,_Prazo) into __saldo_f ;

                          if (__saldo_f > 0  and tempo.alternativo <> '') then 
                      
                             select _saldo_f from seek_in_2V1(tempo.id_grupo,tempo.id_planilha,tempo.nro_linha,tempo.cod_emp,tempo.local,tempo.alternativo,tempo.dt_ref,__saldo_f,_id_fechamento,_Prazo) into __saldo_f ;

                          end if;

                          //Etapa 2
                          if (__saldo_f > 0 and _Final_Val = 0) then 
                              _Etapa := 2;
                              if tempo.validade > 120 then
                                 _Prazo := 120;
                              else
                                 _Prazo := tempo.validade;
                                 _Fim_val := 1;
                              end if;

                              select _saldo_f from seek_in_2V1(tempo.id_grupo,tempo.id_planilha,tempo.nro_linha,tempo.cod_emp,tempo.local,tempo.material,tempo.dt_ref,tempo.saldo,_id_fechamento,_Prazo) into __saldo_f ;

                              if (__saldo_f > 0  and tempo.alternativo <> '') then 
                      
                                 select _saldo_f from seek_in_2V1(tempo.id_grupo,tempo.id_planilha,tempo.nro_linha,tempo.cod_emp,tempo.local,tempo.alternativo,tempo.dt_ref,__saldo_f,_id_fechamento,_Prazo) into __saldo_f ;

                              end if;

                          end if;

                          //Etapa 3
                          if (__saldo_f > 0 and _Final_Val = 0) then 

                              _Etapa := 3;

                              _Prazo := tempo.validade;

                              select _saldo_f from seek_in_2V1(tempo.id_grupo,tempo.id_planilha,tempo.nro_linha,tempo.cod_emp,tempo.local,tempo.material,tempo.dt_ref,tempo.saldo,_id_fechamento,_Prazo) into __saldo_f ;

                              if (__saldo_f > 0  and tempo.alternativo <> '') then 
                      
                                 select _saldo_f from seek_in_2V1(tempo.id_grupo,tempo.id_planilha,tempo.nro_linha,tempo.cod_emp,tempo.local,tempo.alternativo,tempo.dt_ref,__saldo_f,_id_fechamento,_Prazo) into __saldo_f ;

                              end if;

                          end if;

                          update nfe_det_trade set saldo = __saldo_f , status = '1', etapa = _etapa where id_grupo = tempo.id_grupo and id_planilha = tempo.id_planilha and nro_linha = tempo.nro_linha;
             
                       end if;
                   
                   end if;

                   _saida := _saida + 1;

              END LOOP;

        END;
        $$;
    go




    //Não Usado Mais
    CREATE OR REPLACE FUNCTION public.seek_entrada_saldo(in _id_grupo integer, in _cod_empresa text, in _local text, in _material text, in _oficial text, in _saldo_s numeric, in _id_fechamento integer, OUT _saldo_f numeric)
     RETURNS numeric
     LANGUAGE plpgsql
    AS $$
        DECLARE

        entrada  public.nfe_det_trade%ROWTYPE;
        _saldo_e numeric(15,4);
        _qtd     numeric(15,4);
        _last    date;
        _hoje    date;
        _data    date;

        BEGIN

            _saldo_f := _saldo_s;
            _qtd     := 0;
            _hoje    := CURRENT_DATE;
            _data    := Date '2017-02-28';
        
        
            FOR entrada in  
               SELECT *
               FROM NFE_DET_TRADE ENT
               WHERE  ENT.id_grupo = _id_grupo and ENT.cod_emp = _cod_empresa and ENT.local = _local and ENT.material = _material and (ENT.id_operacao = 'X' OR ENT.id_operacao = 'x') and (ENT.saldo > 0) and ( ENT.dt_ref <= _data)
               ORDER BY ENT.cod_emp,ENT.local,ENT.material,ENT.dt_ref desc, ENT.id_operacao desc
            LOOP     
           

                   _saldo_e := entrada.saldo;

               
                   IF (_saldo_s >= _saldo_e) THEN

                       _qtd     := _saldo_e;

                       _saldo_s := _saldo_s - _saldo_e;

                       _saldo_e :=  0;

                   ELSE 

                      _qtd      := _saldo_s;

                      _saldo_e  := _saldo_e - _saldo_s;

                      _saldo_s  := 0; 

                   END IF;

                   _saldo_f := _saldo_s;


                   /*RAISE NOTICE 'Qtd _qtd % _saldo_f % _material % ', _qtd, _saldo_f, _material;*/

                         
                  INSERT INTO controle_s(id_grupo,id_fechamento,cod_emp,local,material,id_e, nro_linha_e, qtd_e ,qtd_s) VALUES(_id_grupo,_id_fechamento,_cod_empresa, _local,_oficial, entrada.id_planilha , entrada.nro_linha, _qtd ,_saldo_f);
  
                  IF (_saldo_f = 0) THEN

                      return;

                  END IF;

            END LOOP;

        END;
        $$
    ;


