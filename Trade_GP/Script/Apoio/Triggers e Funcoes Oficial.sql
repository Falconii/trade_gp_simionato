    /*
     Triggers e Funções

     Trade GP 
     
    */

    /*

       funcao seek_entrada_2V1 - ENTRADAS DA 5405 "E"

       usada na função calculo_saldo

    */

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
        _last      := _data  - interval '6 months';
        //Processando as entradas
        FOR entrada in  
           SELECT *
           FROM NFE_DET_TRADE ENT
           WHERE  ENT.id_grupo = _id_grupo and ENT.cod_emp = _cod_empresa and ENT.local = _local and ENT.material = _material and 
                  ((ENT.dt_ref >= '2017-03-01' AND ENT.id_operacao = 'E' AND ENT.cof_vlr > 0 AND ENT.saldo > 0) OR (ENT.dt_ref <= '2017-02-28' AND ENT.id_operacao = 'X' AND ENT.cof_vlr > 0 AND ENT.saldo_inicial > 0)) 
                  and ( ENT.dt_ref >= _LAST AND ENT.dt_ref <= _data)
           ORDER BY ENT.cod_emp,ENT.local,ENT.material,ENT.dt_ref desc , ENT.id_operacao desc
        LOOP     
           
               //RAISE NOTICE 'ENTRADA.cod_empresa % ENTRADA.local % ENTRADA.material % ENTRADA.dtlanc % ENTRADA.qtd % ENTRADA.saldo % ENTRADA.status %', entrada.cod_emp,entrada.local,entrada.material,entrada.dtlanc,entrada.qtd, entrada.saldo, entrada.status;

               //RAISE NOTICE '_id_grupo % _id_s  % _nro_linha_s % _cod_empresa % _local % _material  % _data  % _saldo_s % ', _id_grupo,_id_s,_nro_linha_s,_cod_empresa,_local,_material,_data,_saldo_s;

               if (entrada.dt_lanc >= '2017-03-01') then
                   _saldo_e := entrada.saldo;
               else 
                   _saldo_e := entrada.saldo_inicial;
               end if;

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

       funcao seek_entrada_2V2 - ENTRADAS  "e"

       usada na função calculo_saldo

    */

 CREATE OR REPLACE FUNCTION "public"."seek_in_2v2"(
    in  _id_grupo     int4,
    in  _id_s         int4,
    in  _nro_linha_s  int4,
    in  _cod_empresa  text,
    in  _local        text,
    in  _material     text,
    in  _data         date,
    in  _saldo_s      numeric(15,4),
    in  _id_fechamento int4,
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

        _saldo_f := _saldo_s;
        _qtd     := 0;
        _hoje    := CURRENT_DATE;
        //_data    := Date '2017-02-28';
        //_last    := _hoje  - interval '4 years 11 months';
        _last    := _data  - interval '6 months';
        
        RAISE NOTICE ' _saldo_f % ',_saldo_f;
        //Processando as entradas
        FOR entrada in  
           SELECT *
           FROM NFE_DET_TRADE ENT
           WHERE  ENT.id_grupo = _id_grupo and ENT.cod_emp = _cod_empresa and ENT.local = _local and ENT.material = _material and 
                  ((ENT.dt_ref >= '2017-03-01' AND ENT.id_operacao = 'e' AND ENT.saldo > 0) OR (ENT.dt_ref <= '2017-02-28' AND ENT.id_operacao = 'x'  AND ENT.saldo_inicial > 0)) 
                  and ( ENT.dt_ref >= _LAST AND ENT.dt_ref <= _data)
           ORDER BY ENT.cod_emp,ENT.local,ENT.material,ENT.dt_ref desc, ENT.id_operacao desc
        LOOP     
           
               //RAISE NOTICE 'ENTRADA.cod_empresa % ENTRADA.local % ENTRADA.material % ENTRADA.dtlanc % ENTRADA.qtd % ENTRADA.saldo % ENTRADA.status %', entrada.cod_empresa,entrada.local,entrada.material,entrada.dtlanc,entrada.qtd, entrada.saldo, entrada.status;

               //RAISE NOTICE '_id_grupo % _id_s  % _nro_linha_s % _cod_empresa % _local % _material  % _data  % _saldo_s % ', _id_grupo,_id_s,_nro_linha_s,_cod_empresa,_local,_material,_data,_saldo_s;

               if (entrada.dt_lanc >= '2017-03-01') then
                   _saldo_e := entrada.saldo;
               else 
                   _saldo_e := entrada.saldo_inicial;
               end if;

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

               RAISE NOTICE 'Saldo Final % ',_saldo_f;

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
		alternativo     text
    );

CREATE OR REPLACE FUNCTION public.seek_saida_2(_id_grupo integer, _cod_empresa text, _local text, _id_d integer, _nro_linha_d integer, _material_d text, _qtd_d numeric, _dt_ref_d date, _id_s integer, _nro_linha_s integer, _id_fechamento integer, OUT _saldo_f numeric)
 RETURNS numeric
 LANGUAGE plpgsql
 AS $$
    DECLARE

    controle  public.controle_e%ROWTYPE;
    _saldo_e numeric(15,4);
    _qtd_abatida numeric(15,4);
    _last    date;
    _hoje    date;

    BEGIN

        _saldo_f = 0;

        _qtd_abatida := _qtd_d;

         FOR controle in  
     
          SELECT *
          FROM   controle_e CONTROL 
          WHERE  CONTROL.id_grupo = _id_grupo and CONTROL.id_fechamento = _id_fechamento and CONTROL.id_s = _id_s and CONTROL.nro_linha_s = _nro_linha_s
          ORDER BY  CONTROL.id_grupo , CONTROL.id_fechamento , CONTROL.id_s , CONTROL.nro_linha_s 
          LOOP      
  
              IF (_qtd_abatida > 0 ) THEN 

                    IF ( _qtd_abatida >= controle.qtd_e ) THEN

                        UPDATE controle_e set  qtd_d = qtd_e , qtd_e = 0 
                        
                        where id_grupo = _id_grupo and id_fechamento = _id_fechamento and id_s = _id_s and nro_linha_s = _nro_linha_s;

                        _qtd_abatida := _qtd_abatida - controle.qtd_e;

                    ELSE

                       UPDATE controle_e set qtd_d = qtd_e - _qtd_abatida,  qtd_e = qtd_e - _qtd_abatida  where id_grupo = _id_grupo and id_fechamento = _id_fechamento and id_s = _id_s and nro_linha_s = _nro_linha_s;

                        _qtd_abatida := 0;

                   END IF;

             END IF;
          END LOOP;
          INSERT INTO controle_e(id_grupo,id_fechamento,id_s, nro_linha_s, id_e, nro_linha_e, qtd_s, qtd_e, qtd_d,flag) 	
            VALUES(_id_grupo,_id_fechamento,_id_s, _nro_linha_s,_id_d , _nro_linha_d, 0, 0 , _qtd_d, 'D');
      
    END;
    $$
    ;


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
                coalesce(depara.para_material,'') as alternativo
          FROM   nfe_det_trade DET
          LEFT  JOIN de_para     depara on depara.id_grupo = det.id_grupo and depara.cod_emp = det.cod_emp and depara.local = det.local and depara.de_material = det.material
          WHERE  DET.id_grupo = _id_grupo and DET.cod_emp = _cod_emp and Det.local = _local and 
                 ( 
                   ( ((det.id_operacao = 'S') OR (det.id_operacao = 's'))  and det.status = '0') 
                   OR 
                   ( ((det.id_operacao = 'Z') OR (det.id_operacao = 'Y'))  and det.status = '0')
                 )
                 and (TO_CHAR(det.dt_ref,'DD/MM/YYYY') = _mes_ano) 
           ORDER BY DET.id_grupo,DET.cod_emp,DET.local,DET.dt_ref , DET.id_operacao desc ,DET.nro_doc,DET.nro_item 

          LOOP      
                     
               IF ((tempo.id_operacao = 'Z') OR (tempo.id_operacao = 'Y')) then
                
                   select _saldo_f from seek_saida_2(tempo.id_grupo,tempo.cod_emp,tempo.local,tempo.id_planilha,tempo.nro_linha,tempo.material,tempo.qtd_convertida,tempo.dt_ref,tempo.id_saida,tempo.nro_linha_saida,_id_fechamento) into __saldo_f ;
                   update nfe_det_trade set status = '1' where id_grupo = tempo.id_grupo and id_planilha = tempo.id_planilha and nro_linha = tempo.nro_linha;

               else 

                  if (tempo.id_operacao = 'S') then

                      //RAISE NOTICE 'tempo.material % tempo.dt_ref % tempo.saldo %',tempo.material , tempo.dt_ref , tempo.saldo;
                      
                      select _saldo_f from seek_in_2V1(tempo.id_grupo,tempo.id_planilha,tempo.nro_linha,tempo.cod_emp,tempo.local,tempo.material,tempo.dt_ref,tempo.saldo,_id_fechamento) into __saldo_f ;

                      if (__saldo_f > 0  and tempo.alternativo <> '') then 
                      
                         select _saldo_f from seek_in_2V1(tempo.id_grupo,tempo.id_planilha,tempo.nro_linha,tempo.cod_emp,tempo.local,tempo.alternativo,tempo.dt_ref,__saldo_f,_id_fechamento) into __saldo_f ;

                      end if;

                      update nfe_det_trade set saldo = __saldo_f , status = '1' where id_grupo = tempo.id_grupo and id_planilha = tempo.id_planilha and nro_linha = tempo.nro_linha;

                  else 
                  
                      //RAISE NOTICE 'Primeiro tempo.material % tempo.dt_ref % tempo.saldo %',tempo.material , tempo.dt_ref , tempo.saldo;

                      select _saldo_f from seek_in_2V2(tempo.id_grupo,tempo.id_planilha,tempo.nro_linha,tempo.cod_emp,tempo.local,tempo.material,tempo.dt_ref,tempo.saldo,_id_fechamento) into __saldo_f ;
                      
                      //RAISE NOTICE 'Segundo tempo.material % tempo.dt_ref % __saldo_f %',tempo.material , tempo.dt_ref , __saldo_f;

                       if (__saldo_f > 0  and tempo.alternativo <> '') then 

                         select _saldo_f from seek_in_2V2(tempo.id_grupo,tempo.id_planilha,tempo.nro_linha,tempo.cod_emp,tempo.local,tempo.alternativo,tempo.dt_ref,__saldo_f,_id_fechamento) into __saldo_f ;

                         //raise NOTICE 'terceiro tempo.material % tempo.dt_ref % __saldo_f %',tempo.material , tempo.dt_ref , __saldo_f;

                      end if;
                      if (__saldo_f > 0) then
                        select _saldo_f from seek_in_2V1(tempo.id_grupo,tempo.id_planilha,tempo.nro_linha,tempo.cod_emp,tempo.local,tempo.material,tempo.dt_ref,__saldo_f,_id_fechamento) into __saldo_f ;
                        // NOTICE 'Quarto tempo.material % tempo.dt_ref % __saldo_f %',tempo.material , tempo.dt_ref , __saldo_f;
                        if (__saldo_f > 0  and tempo.alternativo <> '') then 
                      
                            select _saldo_f from seek_in_2V1(tempo.id_grupo,tempo.id_planilha,tempo.nro_linha,tempo.cod_emp,tempo.local,tempo.alternativo,tempo.dt_ref,__saldo_f,_id_fechamento) into __saldo_f ;
                            //RAISE NOTICE 'quinto tempo.material % tempo.dt_ref % __saldo_f %',tempo.material , tempo.dt_ref , __saldo_f;
                        end if;
                      end if;
                      update nfe_det_trade set saldo = __saldo_f , status = '1' where id_grupo = tempo.id_grupo and id_planilha = tempo.id_planilha and nro_linha = tempo.nro_linha;
                      
                  end if;
              
               end if;

                _saida := _saida + 1;

          END LOOP;

    

    END;
    $$;


   DROP TYPE IF EXISTS Reg_Saldo;
    CREATE TYPE Reg_Saldo AS 
    (
        id_grupo    int4,
        cod_emp     text,
        local       text,
        material    text,
        saldo_ini_conv numeric(15,4),
        saldo_imp_conv numeric(15,4),
        alternativo  text
    );

-- DROP FUNCTION public.seek_entrada_saldo(in int4, in text, in text, in text, in numeric, in int4, out numeric);

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

 DROP FUNCTION IF EXISTS calculo_saldo_inicial;
CREATE OR REPLACE FUNCTION "public"."calculo_saldo_inicial" (in _id_grupo int4, in _cod_emp text, in _local text , in _id_fechamento int, out _saida int) 
    RETURNS int
    AS
    $$
    DECLARE
    tempo    public.Reg_Saldo%ROWTYPE;
    __saldo_f     numeric(15,4);
    _status text ;
    BEGIN
       _saida = 0;
      FOR tempo in  
          SELECT    DISTINCT sld.id_grupo         as id_grupo,
                    sld.cod_emp          as cod_emp,
                    sld.local            as local,
                    sld.material         as material,
                    sld.saldo_ini_conv   as saldo_ini_conv ,
                    sld.saldo_imp_conv   as saldo_imp_conv ,
                    coalesce(depara.para_material,'') as alternativo
          FROM   saldo_inicial SLD
          INNER JOIN resumo_5405 resumo on resumo.id_grupo = sld.id_grupo and resumo.cod_emp = sld.cod_emp and resumo.local = sld.local and resumo.material = sld.material  and resumo.dt_ref <= '2017/08/31'
          LEFT  JOIN de_para     depara on depara.id_grupo = sld.id_grupo and depara.cod_emp = sld.cod_emp and depara.local = sld.local and depara.de_material = sld.material
          WHERE  SLD.id_grupo = _id_grupo and SLD.cod_emp = _cod_emp and SLD.local = _local and  saldo_inicial > 0 and SLD.status = '0' 
          ORDER BY SLD.id_grupo,SLD.cod_emp,SLD.local,SLD.material limit 300

          LOOP      
          
                 
                 _status = '0';
             
                 /* RAISE NOTICE 'Vou Procurar Material Principal reg % ', tempo; */
                 select _saldo_f from seek_entrada_saldo(tempo.id_grupo,tempo.cod_emp,tempo.local,tempo.material,tempo.material,tempo.saldo_ini_conv,_id_fechamento) into __saldo_f ;
            
                 if (__saldo_f = 0) then
                    _status = '1';
                 else    
                     if (__saldo_f = tempo.saldo_ini_conv) then
                       _status := '3';
                     else 
                       _status := '2';
                     end if;
                 end if;
                 
                 /* RAISE NOTICE 'Vou Procurar Material ALTERNATIVO __saldo_f % alternativo  ', __saldo_f, tempo.alternativo ; */
                 if ((__saldo_f > 0) and (tempo.alternativo != '')) then
                 
                     select _saldo_f from seek_entrada_saldo(tempo.id_grupo,tempo.cod_emp,tempo.local,tempo.alternativo,tempo.material,__saldo_f,_id_fechamento) into __saldo_f ;
                     if (__saldo_f = 0) then
                        _status = '1';
                     else    
                         if (__saldo_f = tempo.saldo_ini_conv) then
                           _status := '3';
                         else 
                           _status := '2';
                         end if;
                     end if;
                 end if;
         
                 update saldo_inicial set status = _status, saldo_imp_conv = saldo_ini_conv - __saldo_f  where id_grupo = tempo.id_grupo and cod_emp = tempo.cod_emp and local = tempo.local and material = tempo.material;
                 
                 _saida := _saida + 1;

          END LOOP;

    

    END;
    $$
    LANGUAGE 'plpgsql'
    go
   
    /*
    
 select * from public.resumo_5405 where local = '0002'

//Update para atualizar os saldos com fator de conversão
UPDATE  saldo_inicial sld
        SET  saldo_ini_conv = saldo_inicial * resumo.fator, fator = resumo.fator 
        FROM resumo_5405 resumo 
        WHERE   resumo.id_grupo = sld.id_grupo and resumo.cod_emp = sld.cod_emp and resumo.local = sld.local and resumo.material = sld.material

select * from saldo_inicial where local = '0002' and fator <> 0

select * from de_para

update saldo_inicial set status = '0', saldo_imp_conv = 0

select * from 
   
    saldo_imp_conv
    
    saldo_imp_conv
            
    select * from public.nfe_det_trade where material = '1096594'
    
    
    select * from calculo_saldo_inicial(1,'1004','0002',1)
     
    select sld.*,ent.nro_doc,ent.material,coalesce(depara.para_material,'') as alternativo,ent.quantidade_1,ent.qtd_convertida,ent.saldo,con.qtd_e, ent.saldo as restante ,ent.saldo_inicial as saldo_inicial
    from   saldo_inicial sld
    inner join controle_s con on con.id_grupo = sld.id_grupo and con.id_fechamento = 1 and con.cod_emp = sld.cod_emp and con.local = sld.local and con.material = sld.material
    inner join nfe_det_trade  ent    on ent.id_grupo = sld.id_grupo and ent.id_planilha = con.id_e and ent.nro_linha = con.nro_linha_e
    left  join de_para        depara on depara.id_grupo = sld.id_grupo and depara.cod_emp = sld.cod_emp and depara.local = sld.local and depara.de_material = sld.material
    where  sld.id_grupo = 1 and sld.cod_emp = '1004' and sld.local = '0002'
    order by ent.dt_ref,ent.nro_doc,sld.material
    
    
    select * from controle_s
    
    
    */

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
    sai_qtd_convertida numeric(15,4),
    sai_valor          numeric(15,4),
    sai_icst_valor     numeric(15,2),
    sai_fest_valor     numeric(15,2),
    sai_id_saida       int4,
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
    dev_qtd_convertida numeric(15,4),
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
    DROP FUNCTION "public"."seek_dev_saida";
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
           WHERE  SAI.id_grupo = _id_grupo and SAI.cod_emp = _cod_emp and SAI.local = _local and SAI.material = _material and  sai.id_operacao = 'S' and LEFT(SAI.cfop,4) = '5405' and sai.nro_doc = _doc_origem and sai.material = _material and sai.dt_ref >= '2017-03-01'
           ORDER BY SAI.cod_emp, SAI.local, SAI.dt_ref, SAI.nro_doc, SAI.nro_item 
        LOOP     
           
           // RAISE NOTICE 'SAIDA.cod_empresa % SAIDA.local % SAIDA.material % SAIDA.dtlanc % SAIDA.quantidade_1 % SAIDA.saldo % SAIDA.status %', SAIDA.cod_emp,SAIDA.local,SAIDA.material,SAIDA.dt_lanc,SAIDA.quantidade_1, SAIDA.saldo, SAIDA.status;

           //RAISE NOTICE '_id_grupo % _id_s  % _nro_linha_s % _cod_empresa % _local % _material  % _data  % _saldo_s % ', _id_grupo,_id_s,_nro_linha_s,_cod_empresa,_local,_material,_data,_saldo_s;

           IF (SAIDA.qtd_convertida = _qtd_d) THEN

               _id_saida  := SAIDA.id_planilha;
               _nro_linha := SAIDA.nro_linha;

               //RAISE NOTICE 'ACHOU ID % NRO_LINHA % ',SAIDA.id_planilha, SAIDA.nro_linha; 

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
       
            FOR sai_dev in SELECT sai.id_grupo,sai.id_planilha,sai.nro_linha,sai.id_operacao,sai.dt_ref,sai.cfop,sai.nro_doc,sai.nro_item,sai.material,sai.denom,sai.unid,sai.qtd_convertida,sai.valor,sai.icst_valor,sai.fest_valor,sai.id_saida,sai.nro_linha_saida,
                                  dev.id_grupo,dev.id_planilha,dev.nro_linha,dev.id_operacao,dev.dt_ref,dev.cfop,dev.nro_doc,dev.item_ref,dev.material,dev.denom,dev.unid,dev.qtd_convertida,dev.valor,dev.icst_valor,dev.fest_valor,dev.doc_origem,dev.id_saida,dev.nro_linha_saida
                                  FROM       nfe_det_trade dev 
                                  left join nfe_det_trade sai  ON  sai.id_grupo = _grupo and sai.cod_emp = _cod_emp  and sai.local = _local and ( (left(sai.cfop,4) = '5405')) and sai.saldo = 0 and sai.id_operacao = 'S' and sai.nro_doc = dev.doc_origem and sai.material = dev.material
                                  where      dev.id_grupo = _grupo and dev.cod_emp = _cod_emp  and dev.local = _local and  to_char(dev.dt_ref,'DD/MM/YYYY') = _mes_ano  and dev.id_operacao = 'Z' 
                                  order by   dev.id_grupo,dev.cod_emp,dev.local,dev.dt_ref,dev.dt_doc,dev.nro_item

                LOOP            
               
                    //RAISE NOTICE  'Nota % ', sai_dev.sai_nro_doc;
                
                    if (sai_dev.sai_nro_doc is null) 
                         then
                            UPDATE public.nfe_det_trade SET id_operacao = 'z'
                            WHERE id_grupo = sai_dev.dev_id_grupo and id_planilha = sai_dev.dev_id_planilha and nro_linha = sai_dev.dev_nro_linha ;
                         else 
                            select _id_saida, _nro_linha from seek_dev_saida(
                                _grupo                  ,
                                _cod_emp                ,
                                _local                  ,
                                sai_dev.dev_id_planilha ,
                                sai_dev.dev_nro_linha   ,
                                sai_dev.dev_doc_origem  ,
                                sai_dev.dev_material    ,
                                sai_dev.dev_qtd_convertida       
                              ) into __id_saida, __nro_linha;
                            //RAISE NOTICE  'ID % NRO_LINHA % ',__id_saida, __nro_linha ;
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


    CREATE OR REPLACE FUNCTION "public"."check_devolucaox" (
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

            __id_saida   = 0 ;

            __nro_linha  = 0 ;
 
            //RAISE NOTICE  'Gravação de saldos % % % % % ' ,  _empresa  , _filial  ,  _cdcc , _ano   , _mes   ;
       
            FOR sai_dev in SELECT sai.id_grupo,sai.id_planilha,sai.nro_linha,sai.id_operacao,sai.dt_ref,sai.cfop,sai.nro_doc,sai.nro_item,sai.material,sai.denom,sai.unid,sai.qtd_convertida,sai.valor,sai.icst_valor,sai.fest_valor,sai.id_saida,sai.nro_linha_saida,
                                  dev.id_grupo,dev.id_planilha,dev.nro_linha,dev.id_operacao,dev.dt_ref,dev.cfop,dev.nro_doc,dev.item_ref,dev.material,dev.denom,dev.unid,dev.qtd_convertida,dev.valor,dev.icst_valor,dev.fest_valor,dev.doc_origem,dev.id_saida,dev.nro_linha_saida
                                  FROM       nfe_det_trade dev 
                                  left join  nfe_det_trade sai  ON  sai.id_grupo = _grupo and sai.cod_emp = _cod_emp  and sai.local = _local and ( (left(sai.cfop,4) = '5405')) and sai.id_operacao = 'S' and sai.nro_doc = dev.doc_origem and sai.material = dev.material 
                                             and sai.dt_ref >= '2017-03-16' and sai.qtd_convertida = dev.qtd_convertida 
                                  where      dev.id_grupo = _grupo and dev.cod_emp = _cod_emp  and dev.local = _local and  to_char(dev.dt_ref,'DD/MM/YYYY') = _mes_ano  and dev.id_operacao = 'Z' 
                                  order by   dev.id_grupo,dev.cod_emp,dev.local,dev.dt_ref,dev.dt_doc,dev.nro_item

                LOOP            
               
                    //RAISE NOTICE  'Nota % ', sai_dev.sai_nro_doc;
                
                    if (sai_dev.sai_nro_doc is null) then
                            UPDATE public.nfe_det_trade SET id_operacao = 'z'
                            WHERE id_grupo = sai_dev.dev_id_grupo and id_planilha = sai_dev.dev_id_planilha and nro_linha = sai_dev.dev_nro_linha ;
                    else                                               
                            UPDATE public.nfe_det_trade SET id_saida = sai_dev.sai_id_planilha, nro_linha_saida = sai_dev.sai_nro_linha
                            WHERE id_grupo = sai_dev.dev_id_grupo and id_planilha = sai_dev.dev_id_planilha and nro_linha = sai_dev.dev_nro_linha ;
                    end if;

                    _qtd_dev := _qtd_dev + 1;

                END LOOP;
            
                RETURN; 
    END;
    $$
    LANGUAGE 'plpgsql'
    go



    /*

      seek_dev_saida

      função usada na check_devolução 2

    */

    CREATE OR REPLACE FUNCTION "public"."seek_dev_saida2" (
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
           WHERE  SAI.id_grupo = _id_grupo and SAI.cod_emp = _cod_emp and SAI.local = _local and SAI.material = _material and  sai.id_operacao = 's' and sai.nro_doc = _doc_origem and sai.material = _material and sai.dt_ref >= '2017-03-01'
           ORDER BY SAI.cod_emp, SAI.local, SAI.dt_ref, SAI.nro_doc, SAI.nro_item 
        LOOP     
           
           //RAISE NOTICE 'SAIDA.cod_empresa % SAIDA.local % SAIDA.material % SAIDA.dtlanc % SAIDA.quantidade_1 % SAIDA.saldo % SAIDA.status %', SAIDA.cod_emp,SAIDA.local,SAIDA.material,SAIDA.dt_lanc,SAIDA.quantidade_1, SAIDA.saldo, SAIDA.status;

           //RAISE NOTICE '_id_grupo % _id_s  % _nro_linha_s % _cod_empresa % _local % _material  % _data  % _saldo_s % ', _id_grupo,_id_s,_nro_linha_s,_cod_empresa,_local,_material,_data,_saldo_s;

           IF (SAIDA.qtd_convertida = _qtd_d) THEN

               _id_saida  := SAIDA.id_planilha;
               _nro_linha := SAIDA.nro_linha;

               //RAISE NOTICE 'ACHOU ID % NRO_LINHA % ',SAIDA.id_planilha, SAIDA.nro_linha; 

           END IF;

        END LOOP;

    END;
    $$
    LANGUAGE 'plpgsql'
    go


    CREATE OR REPLACE FUNCTION "public"."check_devolucao2" (
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
       
            FOR sai_dev in SELECT sai.id_grupo,sai.id_planilha,sai.nro_linha,sai.id_operacao,sai.dt_ref,sai.cfop,sai.nro_doc,sai.nro_item,sai.material,sai.denom,sai.unid,sai.qtd_convertida,sai.valor,sai.icst_valor,sai.fest_valor,sai.id_saida,sai.nro_linha_saida,
                                  dev.id_grupo,dev.id_planilha,dev.nro_linha,dev.id_operacao,dev.dt_ref,dev.cfop,dev.nro_doc,dev.item_ref,dev.material,dev.denom,dev.unid,dev.qtd_convertida,dev.valor,dev.icst_valor,dev.fest_valor,dev.doc_origem,dev.id_saida,dev.nro_linha_saida
                                  FROM       nfe_det_trade dev 
                                  left join nfe_det_trade sai  ON  sai.id_grupo = _grupo and sai.cod_emp = _cod_emp  and sai.local = _local and  sai.id_operacao = 's' and sai.nro_doc = dev.doc_origem and sai.material = dev.material
                                  where      dev.id_grupo = _grupo and dev.cod_emp = _cod_emp  and dev.local = _local and  to_char(dev.dt_ref,'DD/MM/YYYY') = _mes_ano  and (dev.id_operacao = 'Y') 
                                  order by   dev.id_grupo,dev.cod_emp,dev.local,dev.dt_ref,dev.dt_doc,dev.nro_item

                LOOP            
               
                    //RAISE NOTICE  'Nota % ', sai_dev.sai_nro_doc;
                
                    if (sai_dev.sai_nro_doc is null) 
                         then
                            UPDATE public.nfe_det_trade SET id_operacao = 'y'
                            WHERE id_grupo = sai_dev.dev_id_grupo and id_planilha = sai_dev.dev_id_planilha and nro_linha = sai_dev.dev_nro_linha ;
                         else 
                            select _id_saida, _nro_linha from seek_dev_saida2(
                                _grupo               ,
                                _cod_emp              ,
                                _local                  ,
                                sai_dev.dev_id_planilha ,
                                sai_dev.dev_nro_linha   ,
                                sai_dev.dev_doc_origem  ,
                                sai_dev.dev_material    ,
                                sai_dev.dev_qtd_convertida       
                              ) into __id_saida, __nro_linha;
                            //RAISE NOTICE  'ID % NRO_LINHA % ',__id_saida, __nro_linha ;
                            if (__id_saida > 0) then
                              UPDATE public.nfe_det_trade SET id_saida = __id_saida, nro_linha_saida = __nro_linha
                              WHERE id_grupo = sai_dev.dev_id_grupo and id_planilha = sai_dev.dev_id_planilha and nro_linha = sai_dev.dev_nro_linha ;
                             _qtd_dev := _qtd_dev + 1;
                            else
                              UPDATE public.nfe_det_trade SET id_operacao = 'y'
                              WHERE id_grupo = sai_dev.dev_id_grupo and id_planilha = sai_dev.dev_id_planilha and nro_linha = sai_dev.dev_nro_linha ;
                            end if;
                   end if;
                END LOOP;
            
                RETURN; 
    END;
    $$
    LANGUAGE 'plpgsql'
    go



    CREATE OR REPLACE FUNCTION "public"."check_devolucao2x" (
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
       
            FOR sai_dev in SELECT sai.id_grupo,sai.id_planilha,sai.nro_linha,sai.id_operacao,sai.dt_ref,sai.cfop,sai.nro_doc,sai.nro_item,sai.material,sai.denom,sai.unid,sai.qtd_convertida,sai.valor,sai.icst_valor,sai.fest_valor,sai.id_saida,sai.nro_linha_saida,
                                  dev.id_grupo,dev.id_planilha,dev.nro_linha,dev.id_operacao,dev.dt_ref,dev.cfop,dev.nro_doc,dev.item_ref,dev.material,dev.denom,dev.unid,dev.qtd_convertida,dev.valor,dev.icst_valor,dev.fest_valor,dev.doc_origem,dev.id_saida,dev.nro_linha_saida
                                  FROM       nfe_det_trade dev 
                                  left join  nfe_det_trade sai  ON  sai.id_grupo = _grupo and sai.cod_emp = _cod_emp  and sai.local = _local and  sai.id_operacao = 's' and sai.nro_doc = dev.doc_origem and sai.material = dev.material and 
                                             sai.dt_ref >= '2017-03-01' and sai.qtd_convertida = dev.qtd_convertida 
                                  where      dev.id_grupo = _grupo and dev.cod_emp = _cod_emp  and dev.local = _local and  to_char(dev.dt_ref,'DD/MM/YYYY') = _mes_ano  and (dev.id_operacao = 'Y') and dev.id_saida = 0
                                  order by   dev.id_grupo,dev.cod_emp,dev.local,dev.dt_ref,dev.dt_doc,dev.nro_item

                LOOP            
               
                    //RAISE NOTICE  'Nota % ID SAIDA % LINHA SAIDA % ID_ENTRADA % LINHA %', sai_dev.sai_nro_doc,sai_dev.sai_id_saida,sai_dev.sai_nro_linha_saida,sai_dev.dev_id_planilha,sai_dev.dev_nro_linha ;
                
                    if (sai_dev.sai_nro_doc is null) then
                            UPDATE public.nfe_det_trade SET id_operacao = 'y'
                            WHERE id_grupo = sai_dev.dev_id_grupo and id_planilha = sai_dev.dev_id_planilha and nro_linha = sai_dev.dev_nro_linha;
                    else                                               
                            UPDATE public.nfe_det_trade SET id_saida = sai_dev.sai_id_planilha, nro_linha_saida = sai_dev.sai_nro_linha
                            WHERE id_grupo = sai_dev.dev_id_grupo and id_planilha = sai_dev.dev_id_planilha and nro_linha = sai_dev.dev_nro_linha ;
                    end if;

                    _qtd_dev := _qtd_dev + 1;

                END LOOP;
            
                RETURN; 
    END;
    $$
    LANGUAGE 'plpgsql'
    go



    /*
     exemplo
     select * from check_devolucao(1,'1004','0002','01/2017');
     go
    */

    /*

       trigger controle_nfe

    */

    CREATE OR REPLACE FUNCTION function_controle_nfe()
      RETURNS TRIGGER 
      LANGUAGE PLPGSQL
      AS
    $$
    DECLARE 
       _saldo   numeric(15,4);
       _qtd     numeric(15,4);
       _status  text;
       _dt_ref  date;
       _data    date;
    BEGIN
       IF  (TG_OP = 'INSERT') THEN
           // NFE ENTRADA
           if (new.flag = 'D') then 
                //RAISE NOTICE  'Inclusao D  NEW.qtd_d % NEW.id_grupo % NEW.id_s %  NEW.nro_linha_s % ',NEW.qtd_d , NEW.id_grupo , NEW.id_s ,  NEW.nro_linha_s  ;
                update nfe_det_trade set qtd_dev = qtd_dev + NEW.qtd_d where id_grupo = NEW.id_grupo and id_planilha = NEW.id_s and nro_linha = NEW.nro_linha_s;
           else 
                _data    := Date '2017-02-28';
                select dt_ref from nfe_det_trade  into _dt_ref where id_grupo = NEW.id_grupo and id_planilha = NEW.id_e and nro_linha = NEW.nro_linha_e;
                if (_dt_ref <= _data) then
                    update nfe_det_trade set saldo_inicial = saldo_inicial - NEW.qtd_e where id_grupo = NEW.id_grupo and id_planilha = NEW.id_e and nro_linha = NEW.nro_linha_e;
                else 
                    update nfe_det_trade set saldo = saldo - NEW.qtd_e                 where id_grupo = NEW.id_grupo and id_planilha = NEW.id_e and nro_linha = NEW.nro_linha_e;
                end if;
           end if;
           RETURN NEW;
       END IF;
       IF  (TG_OP = 'UPDATE') THEN

            if (new.flag = 'D') then 
                   //RAISE NOTICE  'Atualizacao D ';
                   update nfe_det_trade set qtd_dev = (qtd_dev - OLD.qtd_d) + NEW.qtd_d where id_grupo = NEW.id_grupo and id_planilha = NEW.id_s and nro_linha = NEW.nro_linha_s;
            else 
                    // NFE ENTRADA
                   update nfe_det_trade set saldo = ( saldo + OLD.qtd_e) - NEW.qtd_e where id_grupo = NEW.id_grupo and id_planilha = NEW.id_e and nro_linha = NEW.nro_linha_e;

                   select saldo,quantidade_1 from nfe_det_trade into _saldo,_qtd where id_grupo = OLD.id_grupo and id_planilha = OLD.id_s and nro_linha = OLD.nro_linha_s;
                   if ( ((_saldo  +   OLD.qtd_e) - NEW.qtd_e ) = _qtd ) then
                      _status = '0';
                   else 
                      _status = '1';
                   end if;
                   update nfe_det_trade set saldo = (saldo + OLD.qtd_e) - NEW.qtd_e where id_grupo = OLD.id_grupo and id_planilha = OLD.id_s and nro_linha = OLD.nro_linha_s;
           end if;       
           RETURN NEW;
       END IF;
       IF  (TG_OP = 'DELETE') THEN
            _saldo = 0;
            if (old.flag = 'D') then 
                 //RAISE NOTICE  'Exclusao D ';
                update nfe_det_trade set qtd_dev = qtd_dev - OLD.qtd_d where id_grupo = OLD.id_grupo and id_planilha = OLD.id_s and nro_linha = NEW.nro_linha_s;
            else 
                // NFE ENTRADA
                update nfe_det_trade set saldo = saldo + OLD.qtd_e where id_grupo = OLD.id_grupo and id_planilha = OLD.id_e and nro_linha = OLD.nro_linha_e;
                // NFE SAIDA
                select saldo,quantidade_1 from nfe_det_trade into _saldo,_qtd where id_grupo = OLD.id_grupo and id_planilha = OLD.id_s and nro_linha = OLD.nro_linha_s;
                if ( (_saldo +   OLD.qtd_e) = _qtd ) then
                   _status = '0';
                else 
                   _status = '1';
                end if;
                update nfe_det_trade set saldo = saldo + OLD.qtd_e  where id_grupo = OLD.id_grupo and id_planilha = OLD.id_s and nro_linha = OLD.nro_linha_s;
           end if; 
           RETURN OLD;
       END IF;
       RETURN NEW;
    END ;
    $$
    GO


    DROP TRIGGER IF EXISTS  trigger_controle_nfe ON public.controle_e;
    GO

    CREATE TRIGGER trigger_controle_nfe
      AFTER INSERT OR UPDATE OR DELETE
      ON controle_e
      FOR EACH ROW
      EXECUTE PROCEDURE function_controle_nfe()
    go

    DROP TYPE IF EXISTS NOTAS;
    CREATE TYPE notas AS 
    (
             ven_id_grupo		int4,
             ven_id_planilha	int4,
             ven_id_operacao	text,
             ven_nro_linha		int4,
             ven_cod_emp		text,
             ven_local		    text,
             ven_dt_ref		    Date,
             ven_nro_doc		text,
             ven_nro_item		text,
             ven_material		text,
             ven_qtd_convertida	numeric(15,4),
             ven_preco_liq		numeric(15,4),
             ven_vlr_contb		numeric(15,4),
             ven_saldo		    numeric(15,4),
             ven_qtd_dev		numeric(15,4),
             ven_pis_base		numeric(15,4),
             ven_pis_taxa		numeric(6,2),
             ven_pis_vlr		numeric(15,4),
             ven_cof_base		numeric(15,4),
             ven_cof_taxa		numeric(6,2),
             ven_cof_vlr		numeric(15,4),
             con_qtd_usada		numeric(15,4),
             con_qtd_saida      numeric(15,4),
             ent_qtd_entrada	numeric(15,4),
             ent_icst_valor		numeric(15,4),
             ent_fest_valor		numeric(15,4),
             ent_saldo		    numeric(15,4),
             ent_id_grupo		int4,
             ent_id_planilha	int4,
             ent_id_operacao	text,
             ent_nro_linha		int4,
             ent_cod_emp		text,
             ent_local		    text,
             ent_nro_doc        text,
             ent_dt_ref		    Date,
             ent_nro_item		text,
             ent_material		text,
             ent_pis_base		numeric(15,4),
             ent_pis_taxa		numeric(6,2),
             ent_pis_vlr		numeric(15,4),
             ent_cof_base		numeric(15,4),
             ent_cof_taxa		numeric(6,2),
             ent_cof_vlr		numeric(15,4)
    );
    go

    CREATE OR REPLACE FUNCTION "public"."vlr_enconomico_v2" (
                               in _grupo int4, in _cod_emp text , in _local text , in _mes_ano text, in _ano_selic int4, in _mes_selic int4, out _saida int4)  
    AS
    $$
    DECLARE
     notas public.NOTAS%ROWTYPE;
     Comentarios boolean;  
     Icms_St_Unit numeric(15,4);
     Qtd_Usada numeric(15,4);
     Base_Pis_Nova numeric(15,4);
     Base_Cofins_Nova numeric(15,4);
     Perc_Pis_Novo numeric(6,2);
     Vlr_Pis_Novo numeric(15,4); 
     Perc_Cofins_Novo numeric(6,2);
     Vlr_Cofins_Novo                numeric(15,4);
     vlr_economico_pis              numeric(15,4);
     vlr_economico_cofins           numeric(15,4);
     vlr_economico_pis_corrigido    numeric(15,4);
     vlr_economico_cofins_corrigido numeric(15,4);
     taxa numeric(6,2);
     data_inicial  Date ;

    BEGIN

            data_inicial  := Date '2017-03-16';

            Comentarios   := true;

            _saida := 0;

             taxa  := 0;
 
            //RAISE NOTICE  'Gravação de saldos % % % % % ' ,  _empresa  , _filial  ,  _cdcc , _ano   , _mes   ;
       
            FOR notas in SELECT 
                            ven.id_grupo
                           ,ven.id_planilha
                           ,ven.id_operacao
                           ,ven.nro_linha
                           ,ven.cod_emp
                           ,ven.local
                           ,ven.dt_ref
                           ,ven.nro_doc
                           ,ven.nro_item
                           ,ven.material
                           ,ven.qtd_convertida
                           ,ven.preco_liq
                           ,ven.vlr_contb
                           ,ven.saldo
                           ,ven.qtd_dev
                           ,ven.pis_base
                           ,ven.pis_taxa
                           ,ven.pis_vlr
                           ,ven.cof_base
                           ,ven.cof_taxa
                           ,ven.cof_vlr
                           ,con.qtd_e           as qtd_usada
                           ,con.qtd_e           as qtd_saida
                           ,ent.quantidade_1    as qtd_entrada
                           ,ent.icst_valor
                           ,ent.fest_valor
                           ,ent.saldo
                           ,ent.id_grupo
                           ,ent.id_planilha
                           ,ent.id_operacao
                           ,ent.nro_linha
                           ,ent.cod_emp
                           ,ent.local
                           ,ent.nro_doc
                           ,ent.dt_ref
                           ,ent.nro_item
                           ,ent.material
                           ,ent.pis_base
                           ,ent.pis_taxa
                           ,ent.pis_vlr
                           ,ent.cof_base
                           ,ent.cof_taxa
                           ,ent.cof_vlr
                   from     controle_e con 
                   inner join nfe_det_trade ven on ven.id_grupo = con.id_grupo and ven.id_planilha = con.id_s and ven.nro_linha = con.nro_linha_s
                   inner join nfe_det_trade ent on ent.id_grupo = con.id_grupo and ent.id_planilha  = con.id_e and ent.nro_linha = con.nro_linha_e 
                   where con.id_grupo = _grupo and con.id_fechamento = 1  and VEN.cod_emp = _cod_emp and VEN.LOCAL = _local   and to_char(VEN.dt_ref,'DD/MM/YYYY') = _mes_ano  and  VEN.STATUS = '1' and  VEN.ID_OPERACAO = 'S'  and  con.id_fechamento = 1
                   order by ven.cod_emp
                           ,ven.local
                           ,ven.id_planilha
                           ,ven.dt_ref
                           ,ven.nro_doc
                           ,ven.nro_item
                           ,ven.material
                LOOP            
                   
                        IF ( notas.con_qtd_usada  <= 0) THEN

                                // RAISE NOTICE  'Nota Sem Saldo Saida %  Entrada %' ,  notas.ven_nro_doc,notas.ent_nro_doc   ;
                        ELSE 

                                // RAISE NOTICE  'Nota % ' ,  notas.ven_nro_doc   ;

                                Icms_St_Unit         :=  (notas.ent_icst_valor + notas.ent_fest_valor) / notas.ent_qtd_entrada  ;

                                Base_Pis_Nova        :=  notas.ven_pis_base - ( notas.con_qtd_usada * Icms_St_Unit);

                                Base_Cofins_Nova     :=  notas.ven_cof_base - ( notas.con_qtd_usada * Icms_St_Unit);

                                Perc_Pis_Novo        :=  notas.ven_pis_taxa;

                                Vlr_Pis_Novo         :=  Base_Pis_Nova  * (Perc_Pis_Novo / 100);

                                Perc_Cofins_Novo     :=  notas.ven_cof_taxa;

                                Vlr_Cofins_Novo      :=  Base_Cofins_Nova  * (Perc_Cofins_Novo / 100);

                                if (taxa = 0 ) then

                                   taxa = (SELECT get_selic as tax FROM get_selic( cast( to_char(notas.ven_dt_ref, 'YYYY') AS INT4), cast (to_char(notas.ven_dt_ref, 'MM') AS INT4),_ano_selic,_mes_selic) );

                                end if;

                                IF (notas.ven_pis_vlr > Vlr_Pis_Novo) THEN
                                   vlr_economico_pis              :=      notas.ven_pis_vlr - Vlr_Pis_Novo;
                                   vlr_economico_pis_corrigido  = vlr_economico_pis  * ( (taxa / 100) + 1);
                                ELSE 
                                   vlr_economico_pis              :=      0;
                                   vlr_economico_pis_corrigido    :=      0;
                                END IF; 
                            
                                //RAISE NOTICE  'notas.ven_cof_vlr % Vlr_Cofins_Novo % Base_Cofins_Nova % Base_Pis_Nova % notas.ent_cof_base %' ,  notas.ven_cof_vlr , Vlr_Cofins_Novo , Base_Cofins_Nova, Base_Pis_Nova , notas.ent_cof_base;

                                IF (notas.ven_cof_vlr > Vlr_Cofins_Novo) THEN
                                   vlr_economico_cofins              :=  notas.ven_cof_vlr - Vlr_Cofins_Novo;
                                   vlr_economico_cofins_corrigido    :=  vlr_economico_cofins  * ( (taxa / 100) + 1);
                                ELSE 
                                   vlr_economico_cofins              :=  0;
                                   vlr_economico_cofins_corrigido    :=  0;
                                END IF; 

                                INSERT INTO nfe_det_trade_val(
                                            id_grupo
                                          , id
                                          , nro_linha
                                          , id_planilha_entrada   
                                          , nro_linha_entrada  
                                          , dtnfe
                                          , dtcredito
                                          , vlr_economico_pis
                                          , vlr_economico_cofins
                                          , dtfcorrecao
                                          , vlr_economico_pis_corrigido
                                          , vlr_economico_cofins_corrigido
                                          , taxa
                                          , Icms_St_Unit
                                          , qtd_calculada
                                          , usuarioinclusao
                                          , usuarioatualizacao) 
                                VALUES(   notas.ven_id_grupo
                                          ,notas.ven_id_planilha
                                          ,notas.ven_nro_linha
                                          ,notas.ent_id_planilha
                                          ,notas.ent_nro_linha
                                          ,notas.ven_dt_ref
                                          ,'2024-08-31'
                                          ,vlr_economico_pis
                                          ,vlr_economico_cofins
                                          ,'2024-08-31'
                                          ,vlr_economico_pis_corrigido
                                          ,vlr_economico_cofins_corrigido
                                          ,taxa
                                          ,Icms_St_Unit
                                          ,notas.con_qtd_usada
                                          ,1
                                          ,1);
                             _saida = _saida + 1;

                        END IF;
                    
                END LOOP;
            
                RETURN; 
    END;
    $$
    LANGUAGE 'plpgsql'
    go


    CREATE OR REPLACE FUNCTION "public"."vlr_enconomico_v3" (
                               in _grupo int4, in _cod_emp text , in _local text , in _mes_ano text, in _ano_selic int4, in _mes_selic int4, out _saida int4)  
    AS
    $$
    DECLARE
     notas public.NOTAS%ROWTYPE;
     Comentarios boolean;  
     Icms_St_Unit numeric(15,4);
     Qtd_Usada numeric(15,4);
     Base_Pis_Nova numeric(15,4);
     Base_Cofins_Nova numeric(15,4);
     Perc_Pis_Novo numeric(6,2);
     Vlr_Pis_Novo numeric(15,4); 
     Perc_Cofins_Novo numeric(6,2);
     Vlr_Cofins_Novo                numeric(15,4);
     vlr_economico_pis              numeric(15,4);
     vlr_economico_cofins           numeric(15,4);
     vlr_economico_pis_corrigido    numeric(15,4);
     vlr_economico_cofins_corrigido numeric(15,4);
     taxa numeric(6,2);
     data_inicial Date;

    BEGIN

            data_inicial := Date '2017-03-16';

            Comentarios  := true;

            _saida := 0;

             taxa  := 0;
 
            //RAISE NOTICE  'Gravação de saldos % % % % % ' ,  _empresa  , _filial  ,  _cdcc , _ano   , _mes   ;
       
            FOR notas in SELECT 
                            ven.id_grupo
                           ,ven.id_planilha
                           ,ven.id_operacao
                           ,ven.nro_linha
                           ,ven.cod_emp
                           ,ven.local
                           ,ven.dt_ref
                           ,ven.nro_doc
                           ,ven.nro_item
                           ,ven.material
                           ,ven.qtd_convertida
                           ,ven.preco_liq
                           ,ven.vlr_contb
                           ,ven.saldo
                           ,ven.qtd_dev
                           ,ven.pis_base
                           ,ven.pis_taxa
                           ,ven.pis_vlr
                           ,ven.cof_base
                           ,ven.cof_taxa
                           ,ven.cof_vlr
                           ,con.qtd_e           as qtd_usada
                           ,con.qtd_e           as qtd_saida
                           ,ent.qtd_convertida  as qtd_entrada
                           ,ent.icst_valor
                           ,ent.fest_valor
                           ,ent.saldo
                           ,ent.id_grupo
                           ,ent.id_planilha
                           ,ent.id_operacao
                           ,ent.nro_linha
                           ,ent.cod_emp
                           ,ent.local
                           ,ent.nro_doc
                           ,ent.dt_ref
                           ,ent.nro_item
                           ,ent.material
                           ,ent.pis_base
                           ,ent.pis_taxa
                           ,ent.pis_vlr
                           ,ent.cof_base
                           ,ent.cof_taxa
                           ,ent.cof_vlr
                   from     controle_e con 
                   inner join nfe_det_trade ven on ven.id_grupo = con.id_grupo and ven.id_planilha = con.id_s and ven.nro_linha = con.nro_linha_s
                   inner join nfe_det_trade ent on ent.id_grupo = con.id_grupo and ent.id_planilha  = con.id_e and ent.nro_linha = con.nro_linha_e 
                   where con.id_grupo = _grupo and con.id_fechamento = 1  and VEN.cod_emp = _cod_emp and VEN.LOCAL = _local  and ven.dt_ref >= data_inicial and to_char(VEN.dt_ref,'DD/MM/YYYY') = _mes_ano  and  VEN.STATUS = '1' and  VEN.ID_OPERACAO = 'S'  and  con.id_fechamento = 1
                   order by ven.cod_emp
                           ,ven.local
                           ,ven.id_planilha
                           ,ven.dt_ref
                           ,ven.nro_doc
                           ,ven.nro_item
                           ,ven.material
                LOOP            
                   
                        IF ( notas.con_qtd_usada  <= 0) THEN

                                // RAISE NOTICE  'Nota Sem Saldo Saida %  Entrada %' ,  notas.ven_nro_doc,notas.ent_nro_doc   ;
                        ELSE 

                                // RAISE NOTICE  'Nota % ' ,  notas.ven_nro_doc   ;

                                Icms_St_Unit         :=  (notas.ent_icst_valor + notas.ent_fest_valor) / notas.ent_qtd_entrada  ;

                                Base_Pis_Nova        :=  notas.ven_pis_base  - ( notas.con_qtd_usada * Icms_St_Unit);

                                Base_Cofins_Nova     :=  notas.ven_cof_base  - ( notas.con_qtd_usada * Icms_St_Unit);

                                Perc_Pis_Novo        :=  notas.ven_pis_taxa;

                                Vlr_Pis_Novo         :=  Base_Pis_Nova  * (Perc_Pis_Novo / 100);

                                Perc_Cofins_Novo     :=  notas.ven_cof_taxa;

                                Vlr_Cofins_Novo      :=  Base_Cofins_Nova  * (Perc_Cofins_Novo / 100);

                                if (taxa = 0 ) then

                                   taxa = (SELECT get_selic as tax FROM get_selic( cast( to_char(notas.ven_dt_ref, 'YYYY') AS INT4), cast (to_char(notas.ven_dt_ref, 'MM') AS INT4),_ano_selic,_mes_selic) );

                                end if;

                                IF (notas.ven_pis_vlr > Vlr_Pis_Novo) THEN
                                   vlr_economico_pis              :=      notas.ven_pis_vlr - Vlr_Pis_Novo;
                                   vlr_economico_pis_corrigido    :=      vlr_economico_pis  * ( (taxa / 100) + 1);
                                ELSE 
                                   vlr_economico_pis              :=      0;
                                   vlr_economico_pis_corrigido    :=      0;
                                END IF; 
                            
                                //RAISE NOTICE  'notas.ven_cof_vlr % Vlr_Cofins_Novo % Base_Cofins_Nova % Base_Pis_Nova % notas.ent_cof_base %' ,  notas.ven_cof_vlr , Vlr_Cofins_Novo , Base_Cofins_Nova, Base_Pis_Nova , notas.ent_cof_base;

                                IF (notas.ven_cof_vlr > Vlr_Cofins_Novo) THEN
                                   vlr_economico_cofins              :=  notas.ven_cof_vlr - Vlr_Cofins_Novo;
                                   vlr_economico_cofins_corrigido    :=  vlr_economico_cofins  * ( (taxa / 100) + 1);
                                ELSE 
                                   vlr_economico_cofins              :=  0;
                                   vlr_economico_cofins_corrigido    :=  0;
                                END IF; 

                                INSERT INTO nfe_det_trade_val(
                                            id_grupo
                                          , id
                                          , nro_linha
                                          , id_planilha_entrada   
                                          , nro_linha_entrada  
                                          , dtnfe
                                          , dtcredito
                                          , vlr_economico_pis
                                          , vlr_economico_cofins
                                          , dtfcorrecao
                                          , vlr_economico_pis_corrigido
                                          , vlr_economico_cofins_corrigido
                                          , taxa
                                          , Icms_St_Unit
                                          , qtd_calculada
                                          , usuarioinclusao
                                          , usuarioatualizacao) 
                                VALUES(   notas.ven_id_grupo
                                          ,notas.ven_id_planilha
                                          ,notas.ven_nro_linha
                                          ,notas.ent_id_planilha
                                          ,notas.ent_nro_linha
                                          ,notas.ven_dt_ref
                                          ,'2025-01-31'
                                          ,vlr_economico_pis
                                          ,vlr_economico_cofins
                                          ,'2025-01-31'
                                          ,vlr_economico_pis_corrigido
                                          ,vlr_economico_cofins_corrigido
                                          ,taxa
                                          ,Icms_St_Unit
                                          ,0
                                          ,1
                                          ,1);
                             _saida = _saida + 1;

                        END IF;
                    
                END LOOP;
            
                RETURN; 
    END;
    $$
    LANGUAGE 'plpgsql'
    go


    CREATE OR REPLACE FUNCTION "public"."vlr_enconomico_c" (
                               in _grupo int4, in _cod_emp text , in _local text , in _mes_ano text, in _ano_selic int4, in _mes_selic int4, out _saida int4)  
    AS
    $$
    DECLARE
     notas public.NOTAS%ROWTYPE;
     Comentarios boolean;  
     Icms_St_Unit     numeric(15,4);
     Base_Pis_Nova    numeric(15,4);
     Base_Cofins_Nova numeric(15,4);
     Perc_Pis_Novo    numeric(6,2);
     Vlr_Pis_Novo     numeric(15,4); 
     Perc_Cofins_Novo numeric(6,2);
     Vlr_Cofins_Novo                 numeric(15,4);
     _vlr_economico_pis              numeric(15,4);
     _vlr_economico_cofins           numeric(15,4);
     _vlr_economico_pis_corrigido    numeric(15,4);
     _vlr_economico_cofins_corrigido numeric(15,4);
     taxa                            numeric(6,2);
     old_id int4;
     old_nro_linha int4;
     old_qtd                          numeric(15,4);
     qtd_calculo                      numeric(15,4);
     id_devolucao int4;
     nro_linha_devolucao int4;
    _id_grupo int4;
    BEGIN

            Comentarios := true;   
            _saida := 0;
            id_devolucao := 0;
            nro_linha_devolucao := 0;
 
             old_id := 0;
             old_nro_linha := 00;
             old_qtd  := 0;
             qtd_calculo := 0;
            //RAISE NOTICE  'Gravação de vlr economico % % % % % ' ,  _cod_emp  , _local  ,  _mes_ano , _ano_selic   , _mes_selic   ;
       
            FOR notas in SELECT 
                            ven.id_grupo
                           ,ven.id_planilha
                           ,ven.id_operacao
                           ,ven.nro_linha
                           ,ven.cod_emp
                           ,ven.local
                           ,ven.dt_ref
                           ,ven.nro_doc
                           ,ven.nro_item
                           ,ven.material
                           ,ven.quantidade_1
                           ,ven.preco_liq
                           ,ven.vlr_contb
                           ,ven.saldo
                           ,ven.qtd_dev
                           ,ven.pis_base
                           ,ven.pis_taxa
                           ,ven.pis_vlr
                           ,ven.cof_base
                           ,ven.cof_taxa
                           ,ven.cof_vlr
                           ,con.qtd_e           as qtd_usada
                           ,con.qtd_s           as qtd_saida
                           ,ent.quantidade_1    as qtd_entrada
                           ,ent.icst_valor
                           ,ent.fest_valor
                           ,ent.saldo
                           ,ent.id_grupo
                           ,ent.id_planilha
                           ,ent.id_operacao
                           ,ent.nro_linha
                           ,ent.cod_emp
                           ,ent.local
                           ,ent.nro_doc
                           ,ent.dt_ref
                           ,ent.nro_item
                           ,ent.material
                           ,ent.pis_base
                           ,ent.pis_taxa
                           ,ent.pis_vlr
                           ,ent.cof_base
                           ,ent.cof_taxa
                           ,ent.cof_vlr
                    from   controle_e con 
                    inner join nfe_det_trade ent on ent.id_planilha  = con.id_e and ent.nro_linha = con.nro_linha_e 
                    inner join nfe_det_trade ven on ven.id_planilha = con.id_s and ven.nro_linha = con.nro_linha_s
                    where   --con.id_s = 2065 and con.nro_linha_s = 22190  and con.flag = ''
                    VEN.ID_GRUPO = _grupo and VEN.cod_emp = _cod_emp and VEN.LOCAL = _local  and to_char(VEN.dt_ref,'DD/MM/YYYY') = _mes_ano  and ( ven.STATUS = '1' and  ven.ID_OPERACAO = 'S' and con.qtd_e = 0 and ven.qtd_dev > 0 and ent.id_operacao = 'E') and  con.id_fechamento = 1
                    order by ven.id_grupo,ven.cod_emp,ven.local,ven.dt_ref,ven.nro_doc,con.qtd_s desc

            LOOP            
   
    /*                
		    RAISE NOTICE  'Nota % % % % % % % % % %' , 
            notas.ven_id_planilha,
            notas.ven_nro_linha,
		    Notas.ven_dt_ref,
		    Notas.ven_id_operacao,
		    notas.ven_nro_doc,
		    notas.ven_qtd_dev, 
		    Notas.ent_dt_ref,
		    Notas.ent_id_operacao,
		    notas.ent_nro_doc  , 
            notas.con_qtd_saida;
    */
			    //Buscar Devolucao
			    select coalesce(id_planilha,0),coalesce(nro_linha,0) from nfe_det_trade into id_devolucao, nro_linha_devolucao  where id_grupo = notas.ven_id_grupo and id_operacao = 'Z' 
									       and id_saida = notas.ven_id_planilha 
									       and nro_linha_saida = notas.ven_nro_linha limit 1;

			    if (id_devolucao IS NOT NULL) then


                    //RAISE NOTICE  'Achou a devolução' ; 

                    if ((notas.ven_id_planilha <> old_id) or (notas.ven_nro_linha <> old_nro_linha )) then

                       old_qtd       := notas.ven_quantidade_1  ;
                       old_id        := notas.ven_id_planilha;
                       old_nro_linha := notas.ven_nro_linha;
                       //RAISE NOTICE  'Troquei...';
                    end if; 
   
                    qtd_calculo := old_qtd - notas.con_qtd_saida;

                
                    old_qtd := notas.con_qtd_saida;

                   // RAISE NOTICE  ' old_qtd % notas.con_qtd_saida % qtd_calculo % ' , 
                   //                 old_qtd,
                   //                 notas.con_qtd_saida,
                   //                 qtd_calculo;
                    Icms_St_Unit         :=  (notas.ent_icst_valor + notas.ent_fest_valor) / notas.ent_qtd_entrada  ;

                    Base_Pis_Nova        :=  notas.ven_pis_base      - ( qtd_calculo * Icms_St_Unit);

                    Base_Cofins_Nova     :=  notas.ven_cof_base      - ( qtd_calculo * Icms_St_Unit);

                    Perc_Pis_Novo        :=  notas.ven_pis_taxa;

                    Vlr_Pis_Novo         :=  Base_Pis_Nova  * (Perc_Pis_Novo / 100);

                    Perc_Cofins_Novo     :=  notas.ven_cof_taxa;

                    Vlr_Cofins_Novo      :=  Base_Cofins_Nova  * (Perc_Cofins_Novo / 100);

                    taxa = (SELECT get_selic as tax FROM get_selic( cast( to_char(notas.ven_dt_ref, 'YYYY') AS INT4), cast (to_char(notas.ven_dt_ref, 'MM') AS INT4),_ano_selic,_mes_selic) );

                    IF (notas.ven_pis_vlr > Vlr_Pis_Novo) THEN
                       _vlr_economico_pis              :=  notas.ven_pis_vlr - Vlr_Pis_Novo;
                       _vlr_economico_pis_corrigido    :=  _vlr_economico_pis  * ( (taxa / 100) + 1);
                    ELSE 
                       _vlr_economico_pis              :=      0;
                       _vlr_economico_pis_corrigido    :=      0;
                    END IF; 

                    //RAISE NOTICE  'notas.ven_cof_vlr % Vlr_Cofins_Novo % Base_Cofins_Nova % Base_Pis_Nova % notas.ent_cof_base %' ,  notas.ven_cof_vlr , Vlr_Cofins_Novo , Base_Cofins_Nova, Base_Pis_Nova , notas.ent_cof_base;

                    IF (notas.ven_cof_vlr > Vlr_Cofins_Novo) THEN
                       _vlr_economico_cofins              :=  notas.ven_cof_vlr - Vlr_Cofins_Novo;
                       _vlr_economico_cofins_corrigido    :=  _vlr_economico_cofins  * ( (taxa / 100) + 1);
                    ELSE 
                       _vlr_economico_cofins              :=  0;
                       _vlr_economico_cofins_corrigido    :=  0;
                    END IF; 

                    //RAISE NOTICE  'CHEGUEI AQUI ' ;

                   select coalesce(id_grupo,0) 
                           from nfe_det_trade_val  into _id_grupo
                           where id_grupo = 1 and id = notas.ven_id_planilha and nro_linha = notas.ven_nro_linha and 
                                                  id_planilha_entrada = notas.ent_id_planilha and nro_linha_entrada =  notas.ent_nro_linha;
                    RAISE NOTICE 'Pesquisa S %',_id_grupo;

                    if ( _id_grupo is null) then 
                        
                            INSERT INTO nfe_det_trade_val(
                                        id_grupo
                                      , id
                                      , nro_linha
                                      , id_planilha_entrada   
                                      , nro_linha_entrada  
                                      , dtnfe
                                      , dtcredito
                                      , vlr_economico_pis
                                      , vlr_economico_cofins
                                      , dtfcorrecao
                                      , vlr_economico_pis_corrigido
                                      , vlr_economico_cofins_corrigido
                                      , taxa
                                      , Icms_St_Unit
                                      , qtd_calculada
                                      , usuarioinclusao
                                      , usuarioatualizacao) 
                            VALUES(   notas.ven_id_grupo
                                      ,notas.ven_id_planilha
                                      ,notas.ven_nro_linha
                                      ,notas.ent_id_planilha
                                      ,notas.ent_nro_linha
                                      ,notas.ven_dt_ref
                                      ,'2024-08-31'
                                      ,_vlr_economico_pis
                                      ,_vlr_economico_cofins
                                      ,'2024-08-31'
                                      ,_vlr_economico_pis_corrigido
                                      ,_vlr_economico_cofins_corrigido
                                      ,taxa
                                      ,Icms_St_Unit
                                      ,qtd_calculo * -1
                                      ,1 
                                      ,1);

                    else 
                    /*
                           insert into warning(
                                        tipo               ,
                                        id_planilha        ,
                                        nro_linha          ,
                                        id_planilha_entrada	,
                                        nro_linha_entrada   )
                                       values
                                      ('V',
                                       notas.ven_id_planilha
                                      ,notas.ven_nro_linha
                                      ,notas.ent_id_planilha
                                      ,notas.ent_nro_linha);
                  */



                    end if;
            
                    select coalesce(id_grupo,0) 
                           from nfe_det_trade_val  into _id_grupo
                           where id_grupo = 1 and id = notas.ven_id_planilha and nro_linha = notas.ven_nro_linha and 
                                                  id_planilha_entrada = id_devolucao and nro_linha_entrada =  nro_linha_devolucao;
                
                    if ( _id_grupo is null) then 

                            INSERT INTO nfe_det_trade_val(
                                        id_grupo
                                      , id
                                      , nro_linha
                                      , id_planilha_entrada   
                                      , nro_linha_entrada  
                                      , dtnfe
                                      , dtcredito
                                      , vlr_economico_pis
                                      , vlr_economico_cofins
                                      , dtfcorrecao
                                      , vlr_economico_pis_corrigido
                                      , vlr_economico_cofins_corrigido
                                      , taxa
                                      , Icms_St_Unit
                                      , qtd_calculada
                                      , usuarioinclusao
                                      , usuarioatualizacao) 
                            VALUES(  notas.ven_id_grupo
                                      ,notas.ven_id_planilha
                                      ,notas.ven_nro_linha
                                      ,id_devolucao
                                      ,nro_linha_devolucao
                                      ,notas.ven_dt_ref
                                      ,'2024-08-31'
                                      ,_vlr_economico_pis * -1
                                      ,_vlr_economico_cofins * -1
                                      ,'2024-08-31'
                                      ,_vlr_economico_pis_corrigido * -1
                                      ,_vlr_economico_cofins_corrigido * -1
                                      ,taxa
                                      ,Icms_St_Unit
                                      ,0
                                      ,1
                                      ,1);

                   else
                               UPDATE nfe_det_trade_val
                                      SET 
                                            vlr_economico_pis              = vlr_economico_pis              + (_vlr_economico_pis * -1)
                                          , vlr_economico_cofins           = vlr_economico_cofins           + (_vlr_economico_cofins * -1)
                                          , vlr_economico_pis_corrigido    = vlr_economico_pis_corrigido    + (_vlr_economico_pis_corrigido * -1)
                                          , vlr_economico_cofins_corrigido = vlr_economico_cofins_corrigido + (_vlr_economico_cofins_corrigido * -1)
                               where          
                                            id_grupo    = notas.ven_id_grupo
                                        and id          = notas.ven_id_planilha
                                        and nro_linha   = notas.ven_nro_linha
                                        and id_planilha_entrada = id_devolucao
                                        and nro_linha_entrada   = nro_linha_devolucao;

                  end if;
             

			    end if;
					  
                _saida := _saida + 1;
			    //RAISE NOTICE  'GRAVAEI !!!' ;

		    END LOOP;
            
    END;
    $$
    LANGUAGE 'plpgsql';
    go


    /*
    select * from vlr_enconomico_c(1,'1003','0024','22/02/2020', 2024, 06)
    1821	S	1359
    1806	E	823


    CREATE TABLE public.warning  ( 
	    seq                	serial NOT NULL,
	    tipo               	char(1) NOT NULL,
        id_planilha         int4 NOT NULL,
	    nro_linha          	int4 NOT NULL,
	    id_planilha_entrada	int4 NOT NULL,
	    nro_linha_entrada  	int4 NOT NULL 
	    )

    select * from warning 

    delete from warning

    alter table nfe_det_trade_val add column Icms_St_Unit numeric(18,4) NULL;
    alter table nfe_det_trade_val add column qtd_calculada numeric(15,4) NULL

    */
    GO


    CREATE OR REPLACE FUNCTION "public"."atualizacao_selic" (
                               in _grupo int4, in _cod_emp text , in _local text , in _mes_ano text, in _ano_selic int4, in _mes_selic int4, out _saida int4)  
    AS
    $$
    DECLARE
     notas public.nfe_det_trade_val%ROWTYPE;
     Comentarios boolean;  
     _vlr_economico_pis_corrigido    numeric(15,4);
     _vlr_economico_cofins_corrigido numeric(15,4);
     taxa numeric(6,2);


    BEGIN

            Comentarios := true;

            _saida := 0;

             taxa := 0;
 
            //RAISE NOTICE  'Gravação de saldos % % % % % ' ,  _empresa  , _filial  ,  _cdcc , _ano   , _mes   ;
       
            FOR notas in select val.*
                    from  nfe_det_trade_val val
                    inner join nfe_det_trade  det on det.id_grupo = val.id_grupo and det.id_planilha = val.id and det.nro_linha = val.nro_linha
                    where   val.id_grupo = _grupo and det.cod_emp = _cod_emp and det.local = _local and to_char(val.dtnfe,'DD/MM/YYYY') = _mes_ano
                    order by det.cod_emp
                            ,det.local
                            ,det.id_planilha
                            ,det.dt_ref
                LOOP            
                            

                               taxa = (SELECT get_selic as tax FROM get_selic( cast( to_char(notas.dtnfe, 'YYYY') AS INT4), cast (to_char(notas.dtnfe, 'MM') AS INT4),_ano_selic,_mes_selic) );

                                            
                                RAISE NOTICE  'Nota % ' ,  notas.nro_linha   ;

                                if ( notas.vlr_economico_pis > 0) then 
                                    _vlr_economico_pis_corrigido  =( notas.vlr_economico_pis * -1)  * ( (taxa / 100) + 1);
                                    _vlr_economico_pis_corrigido  = notas.vlr_economico_pis  * ( (taxa / 100) + 1);

                                    //RAISE NOTICE  'notas.ven_cof_vlr % Vlr_Cofins_Novo % Base_Cofins_Nova % Base_Pis_Nova % notas.ent_cof_base %' ,  notas.ven_cof_vlr , Vlr_Cofins_Novo , Base_Cofins_Nova, Base_Pis_Nova , notas.ent_cof_base;

                                    _vlr_economico_cofins_corrigido    :=  notas.vlr_economico_cofins  * ( (taxa / 100) + 1);

                                    update nfe_det_trade_val
                                           set vlr_economico_pis_corrigido    =  _vlr_economico_pis_corrigido,
                                               vlr_economico_cofins_corrigido =  _vlr_economico_cofins_corrigido
                                    where 
                                            id_grupo                = notas.id_grupo
                                            and id                      = notas.id
                                            and nro_linha               = notas.nro_linha
                                            and id_planilha_entrada     = notas.id_planilha_entrada
                                            and nro_linha_entrada       = notas.nro_linha_entrada;
                             end if;

                             _saida = _saida + 1;

                        //END IF;
                    
                END LOOP;
            
                RETURN; 
    END;
    $$
    LANGUAGE 'plpgsql'
    go


    /*

    select * from atualizacao_selic(1,'1003','0024','22/02/2020',2024,06);



    */




    /*

      GetSelic

    */

   CREATE OR REPLACE FUNCTION "public"."get_selic" (in ano_inicial int4, in mes_inicial int4, in ano_final int4, in mes_final int4) RETURNS numeric AS
    $$
    DECLARE

      Retorno decimal(7,2);
      DataInicial text;
      DataFinal   text; 
      DataMinima  text;
      DataMaxima  text;

    BEGIN

      SELECT MIN(ANO || MES) AS MIN_DATA, MAX(ANO || MES) AS MAX_DATA 
      FROM SELIC INTO DataMinima, DataMaxima;
      
      if mes_inicial = 11 OR mes_inicial = 12 then

         if mes_inicial = 11 then

            mes_inicial := 1;

         else 

            mes_inicial := 2;

         end if;

         ano_inicial := ano_inicial + 1;

      else 

         mes_inicial := mes_inicial+2;

      end if ;

      
      DataInicial :=  cast(ano_inicial as char(4)) ||  right( '00' ||  cast(mes_inicial as char(2)),2) ;

  
 
      DataFinal   :=  cast(ano_final as char(4)) ||  right( '00' ||  cast(mes_final as char(2)),2) ;

  

      if (DataInicial < DataMinima) then

        return -1;

      end if;

     if (DataInicial > DataMaxima) then

        return -1;

      end if;

      SELECT SUM(TAXA)
      FROM   SELIC INTO Retorno
      WHERE  ANO || MES >= DataInicial AND ANO || MES <= DataFinal;

      return Retorno; 
  
    END;
    $$
    LANGUAGE 'plpgsql'
    GO



    CREATE OR REPLACE FUNCTION function_controle_sld()
      RETURNS TRIGGER 
      LANGUAGE PLPGSQL
      AS
    $$
    DECLARE 
       _saldo   numeric(15,4);
       _qtd     numeric(15,4);
       _status  text;
       _operacao text;
    BEGIN
       IF  (TG_OP = 'INSERT') THEN
           // NFE ENTRADA
           select id_operacao from nfe_det_trade into _operacao
           where id_grupo = NEW.id_grupo and id_planilha = NEW.id_e and nro_linha = NEW.nro_linha_e;
           //if (_operacao = 'X' OR _operacao = 'x') THEN
           //   if (_operacao = 'X') THEN
           //       _operacao := 'E';
           //   else 
           //       _operacao := 'e';
           //   end if;
              update nfe_det_trade set saldo = saldo - NEW.qtd_e, saldo_inicial = saldo_inicial + NEW.qtd_e , id_operacao = _operacao 
              where id_grupo = NEW.id_grupo and id_planilha = NEW.id_e and nro_linha = NEW.nro_linha_e;
           //ELSE
           // update nfe_det_trade set saldo = saldo - NEW.qtd_e, saldo_inicial = saldo_inicial + NEW.qtd_e 
           // where id_grupo = NEW.id_grupo and id_planilha = NEW.id_e and nro_linha = NEW.nro_linha_e;
           //end if;
           RETURN NEW;
       END IF;
    END ;
    $$
    GO


    DROP TRIGGER IF EXISTS  trigger_controle_sld ON public.controle_s;
    GO

    CREATE TRIGGER trigger_controle_sld
      AFTER INSERT
      ON controle_s
      FOR EACH ROW
      EXECUTE PROCEDURE function_controle_sld()
    go



    drop function  "public"."importa_sld_excel";
go
CREATE OR REPLACE FUNCTION "public"."importa_sld_excel"(
    in  _id_grupo     int4,
    in  _cod_empresa  text,
    in  _local        text,
    in  _material     text,
    in  _saldo        numeric(15,4),
    in  _descricao    text,
    out _saida        int4
    ) 
    RETURNS int4
    AS
    $$
    DECLARE

    _saldo_inicial numeric(15,4);
    
    BEGIN

       select saldo_inicial from saldo_inicial into _saldo_inicial where id_grupo = _id_grupo and cod_emp = _cod_empresa and local = _local and material = _material;
    
       if (_saldo_inicial is null) then
           //RAISE NOTICE  'Saldo Inicial Não Encontrado ';
           INSERT INTO saldo_inicial(id_grupo,cod_emp,local,material,descricao,saldo_inicial,saldo_ini_conv,saldo_imp_conv,fator,ct,status) 
           values (
            _id_grupo     ,
            _cod_empresa  ,
            _local        ,
            _material     ,
            _descricao    ,
            _saldo        ,
            0,0,0,1,'0');
       else 
           //RAISE NOTICE  'Saldo Inicial % ',_saldo_inicial;
           update  public.saldo_inicial set saldo_inicial = saldo_inicial + _saldo,  ct = ct + 1
           where id_grupo = _id_grupo and cod_emp = _cod_empresa and local = _local and material = _material ;
       end if;
       
       _saida = 1;
       
    END;
    $$
    LANGUAGE 'plpgsql'
    go

CREATE OR REPLACE FUNCTION public.reindex( OUT _ok INT4)
    RETURNS int4
    AS
    $$
    DECLARE
    
    BEGIN
    
        _ok = 0;

        EXECUTE 'REINDEX TABLE NFE_DET_TRADE';
       
    END;
    $$
    LANGUAGE 'plpgsql'
    go
