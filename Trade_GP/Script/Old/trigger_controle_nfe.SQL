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

--TRUNCATE controle_e

SELECT * FROM controle_e

UPDATE nfe_det_trade set saldo = 1 where id_planilha = 8 and nro_linha = 45 
GO
UPDATE nfe_det_trade set saldo = 2880 where id_planilha = 1 and nro_linha = 432 

INSERT INTO public.controle_e(id_grupo, id_fechamento, id_s, nro_linha_s, id_e, nro_linha_e, qtd_s, qtd_e) 
	VALUES(1, 1, 8, 45, 1, 432, 0, 1)
GO

/*

*/