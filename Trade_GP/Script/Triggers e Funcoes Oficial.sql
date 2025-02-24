/*
 Triggers e Funções

 Trade GP 

*/

/*

   funcao seek_entrada_2

   usada na função calculo_saldo

*/

CREATE OR REPLACE FUNCTION "public"."seek_entrada_2" (
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
    //_data    := Date '2023-01-01';
    //_last    := _hoje  - interval '4 years 11 months';
    //Processando as entradas
    FOR entrada in  
       SELECT *
       FROM NFE_DET_TRADE ENT
       WHERE  ENT.id_grupo = _id_grupo and ENT.cod_emp = _cod_empresa and ENT.local = _local and ENT.material = _material and ( (ENT.id_operacao = 'E' AND ENT.cof_vlr > 0 AND ENT.saldo > 0)) and ( ENT.dt_ref <= _data)
       ORDER BY ENT.cod_emp,ENT.local,ENT.material,ENT.id_operacao,ENT.dt_ref asc
    LOOP     
           
           //RAISE NOTICE 'ENTRADA.cod_empresa % ENTRADA.local % ENTRADA.material % ENTRADA.dtlanc % ENTRADA.qtd % ENTRADA.saldo % ENTRADA.status %', entrada.cod_empresa,entrada.local,entrada.material,entrada.dtlanc,entrada.qtd, entrada.saldo, entrada.status;

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

   função seek_saida_2

   usada na função calculo_saldo


*/ 
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


/*

  Calculo do saldo de estoque

  24/05/2024

*/

CREATE OR REPLACE FUNCTION "public"."calculo_saldo" (in _id_grupo int4, in _cod_emp text, in _local text , in _mes_ano text, in _id_fechamento int, out _saida text) 
RETURNS text
AS
$$
DECLARE

tempo    public.nfe_det_trade%ROWTYPE;

__saldo_f     numeric(15,4);


BEGIN

  FOR tempo in  
     
      SELECT *
      FROM   nfe_det_trade DET
      WHERE  DET.id_grupo = _id_grupo and DET.cod_emp = _cod_emp and Det.local = _local and ( (det.id_operacao = 'S' and det.status = '0') OR (det.id_operacao = 'Z' and det.status = '0')) and (TO_CHAR(det.dt_ref,'MM/YYYY') = _mes_ano)  
      ORDER BY DET.id_grupo,DET.cod_emp,DET.local,DET.dt_ref,DET.nro_doc,DET.nro_item limit 1000

      LOOP      
             //Processando as entradas

           RAISE NOTICE  'DATA % NRO % ITEM % OPERACAO % ', tempo.dt_ref,tempo.nro_doc,tempo.nro_item,tempo.id_operacao;

           IF (tempo.id_operacao = 'Z') then
 
               RAISE NOTICE  'calculo_saldo Z ';
               select _saldo_f from  seek_saida_2(tempo.id_grupo,tempo.cod_emp,tempo.local,tempo.id_planilha,tempo.nro_linha,tempo.material,tempo.quantidade_1,tempo.dt_ref,tempo.id_saida,tempo.nro_linha_saida,_id_fechamento) into __saldo_f ;
               update nfe_det_trade set status = '1' where id_grupo = tempo.id_grupo and id_planilha = tempo.id_planilha and nro_linha = tempo.nro_linha;

           else 

              select _saldo_f from seek_entrada_2(tempo.id_grupo,tempo.id_planilha,tempo.nro_linha,tempo.cod_emp,tempo.local,tempo.material,tempo.dt_ref,tempo.saldo,_id_fechamento) into __saldo_f ;
            
              update nfe_det_trade set saldo = __saldo_f , status = '1' where id_grupo = tempo.id_grupo and id_planilha = tempo.id_planilha and nro_linha = tempo.nro_linha;

           end if;

      END LOOP;

     _saida = 'OK';

END;
$$
LANGUAGE 'plpgsql'
go


/*
-- Exemplo
select * from calculo_saldo(1,'1004','0004','04/2017',1);
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

 sai_dev public.Sai_Dev%ROWTYPE;


 Comentarios boolean;  

 __id_saida int4;

 __nro_linha int4;

BEGIN

        Comentarios = true;

        _qtd_dev     = 0;

        __id_saida  = 0 ;

        __nro_linha = 0 ;
 
        //RAISE NOTICE  'Gravação devolucoes % % % % % ' ,  _empresa  , _filial  ,  _cdcc , _ano   , _mes   ;
       
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
BEGIN
   IF  (TG_OP = 'INSERT') THEN
       // NFE ENTRADA
       if (new.flag = 'D') then 
            RAISE NOTICE  'Inclusao D  NEW.qtd_d % NEW.id_grupo % NEW.id_s %  NEW.nro_linha_s % ',NEW.qtd_d , NEW.id_grupo , NEW.id_s ,  NEW.nro_linha_s  ;
            update nfe_det_trade set qtd_dev = qtd_dev + NEW.qtd_d where id_grupo = NEW.id_grupo and id_planilha = NEW.id_s and nro_linha = NEW.nro_linha_s;
       else 
            update nfe_det_trade set saldo = saldo - NEW.qtd_e where id_grupo = NEW.id_grupo and id_planilha = NEW.id_e and nro_linha = NEW.nro_linha_e;
       end if;
       RETURN NEW;
   END IF;
   IF  (TG_OP = 'UPDATE') THEN

        if (new.flag = 'D') then 
               RAISE NOTICE  'Atualizacao D ';
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
             RAISE NOTICE  'Exclusao D ';
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
         ven_quantidade_1	numeric(15,4),
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
CREATE OR REPLACE FUNCTION "public"."vlr_enconomico" (
                           in _grupo int4, in _cod_emp text , in _local text , in _mes_ano text, in _ano_selic int4, in _mes_selic int4, out _saida text)  
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


BEGIN

        Comentarios := true;

        _saida := 'OK';
 
        //RAISE NOTICE  'Gravação de vlr economico % % % % % ' ,  _empresa  , _filial  ,  _cdcc , _ano   , _mes   ;
       
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
               inner join nfe_det_trade ent on ent.id_planilha  = con.id_e and ent.nro_linha = con.nro_linha_e 
               inner join nfe_det_trade ven on ven.id_planilha = con.id_s and ven.nro_linha = con.nro_linha_s
               where  VEN.ID_GRUPO = _grupo and VEN.cod_emp = _cod_emp and VEN.LOCAL = _local  and to_char(VEN.dt_ref,'MM/YYYY') = _mes_ano  and  VEN.STATUS = '1' and  VEN.ID_OPERACAO = 'S'  and  con.id_fechamento = 1
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

                            Base_Pis_Nova        :=  notas.ven_pis_base      - ( notas.con_qtd_usada * Icms_St_Unit);

                            Base_Cofins_Nova     :=  notas.ven_cof_base      - ( notas.con_qtd_usada * Icms_St_Unit);

                            Perc_Pis_Novo        :=  notas.ven_pis_taxa;

                            Vlr_Pis_Novo         :=  Base_Pis_Nova  * (Perc_Pis_Novo / 100);

                            Perc_Cofins_Novo     :=  notas.ven_cof_taxa;

                            Vlr_Cofins_Novo      :=  Base_Cofins_Nova  * (Perc_Cofins_Novo / 100);

                            taxa = (SELECT get_selic as tax FROM get_selic( cast( to_char(notas.ven_dt_ref, 'YYYY') AS INT4), cast (to_char(notas.ven_dt_ref, 'MM') AS INT4),_ano_selic,_mes_selic) );

                            IF (notas.ven_pis_vlr > Vlr_Pis_Novo) THEN
                               vlr_economico_pis              :=      notas.ven_pis_vlr - Vlr_Pis_Novo;
                               vlr_economico_pis_corrigido  = vlr_economico_pis  * ( (taxa / 100) + 1);
                            ELSE 
                               vlr_economico_pis              :=      0;
                               vlr_economico_pis_corrigido    :=      0;
                            END IF; 
                            
                            RAISE NOTICE  'notas.ven_cof_vlr % Vlr_Cofins_Novo % Base_Cofins_Nova % Base_Pis_Nova % notas.ent_cof_base %' ,  notas.ven_cof_vlr , Vlr_Cofins_Novo , Base_Cofins_Nova, Base_Pis_Nova , notas.ent_cof_base;

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
                                      , usuarioinclusao
                                      , usuarioatualizacao) 
                            VALUES(   notas.ven_id_grupo
                                      ,notas.ven_id_planilha
                                      ,notas.ven_nro_linha
                                      ,notas.ent_id_planilha
                                      ,notas.ent_nro_linha
                                      ,notas.ven_dt_ref
                                      ,'2024-06-30'
                                      ,vlr_economico_pis
                                      ,vlr_economico_cofins
                                      ,'2024-06-30'
                                      ,vlr_economico_pis_corrigido
                                      ,vlr_economico_cofins_corrigido
                                      ,taxa
                                      ,1
                                      ,1);

                    END IF;
                    
            END LOOP;
            
            RETURN; 
END;
$$
LANGUAGE 'plpgsql'
go

/*

select * from vlr_enconomico(1,'1004', '0002', '02/2017',2024,6 )  ;

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

  

  mes_inicial = mes_inicial+1;

  if (mes_inicial > 12) then
 
      mes_inicial = 1;

      ano_inicial = ano_inicial + 1;

  end if;
      
  DataInicial =  cast(ano_inicial as char(4)) ||  right( '00' ||  cast(mes_inicial as char(2)),2) ;

  
 
  DataFinal   =  cast(ano_final as char(4)) ||  right( '00' ||  cast(mes_final as char(2)),2) ;

  

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