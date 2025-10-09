CREATE OR REPLACE FUNCTION function_controle_nfe2()
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
           //update nfe_det_trade set saldo2 = saldo2 - NEW.qtd_e, status2 = '1'  where id_grupo = NEW.id_grupo and id_planilha = NEW.id_e and nro_linha = NEW.nro_linha_e;
           update nfe_det_trade set saldo2 = 0, status2 = '1'  where id_grupo = NEW.id_grupo and id_planilha = NEW.id_e and nro_linha = NEW.nro_linha_e;
           RETURN NEW;
       END IF;
       RETURN NEW;
    END ;
    $$
    GO


    DROP TRIGGER IF EXISTS  trigger_controle_nfe2 ON public.controle_e2;
    GO

    CREATE TRIGGER trigger_controle_nfe2
      AFTER INSERT OR UPDATE OR DELETE
      ON controle_e2
      FOR EACH ROW
      EXECUTE PROCEDURE function_controle_nfe2()
    go
go

