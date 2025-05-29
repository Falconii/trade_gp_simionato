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
           //update nfe_det_trade set saldo = saldo - NEW.qtd_e, status = '1'  where id_grupo = NEW.id_grupo and id_planilha = NEW.id_e and nro_linha = NEW.nro_linha_e;
           update nfe_det_trade set saldo = 0, status = '1'  where id_grupo = NEW.id_grupo and id_planilha = NEW.id_e and nro_linha = NEW.nro_linha_e;
           RETURN NEW;
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


-- DROP FUNCTION public.get_selic(int4, int4, int4, int4);
CREATE OR REPLACE FUNCTION public.get_selic(ano_inicial integer, mes_inicial integer, ano_final integer, mes_final integer)
 RETURNS numeric
 LANGUAGE plpgsql
AS $function$
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
    $function$
;
go