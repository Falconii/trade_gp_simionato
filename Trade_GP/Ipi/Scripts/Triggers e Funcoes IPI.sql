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
