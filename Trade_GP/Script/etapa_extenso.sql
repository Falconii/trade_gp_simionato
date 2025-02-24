 --DROP FUNCTION public.etapa_extenso(in Date, in Date,in int, in int , out text);
CREATE OR REPLACE FUNCTION public.etapa_extenso(in _dt_saida Date, in _dt_entrada Date , in _validade int, in _qtd_dev int , OUT _retorno text)
 RETURNS text
 LANGUAGE plpgsql
AS $function$ 

DECLARE
   diferenca int;
BEGIN

     diferenca :=  _dt_saida - _dt_entrada;
     
     _retorno :=  CASE 
                        WHEN _qtd_dev      >  0     THEN 'Não Se Aplica'
                        WHEN _validade    <= 60     THEN 'Validade <<' || _validade || '>>' || ' Prazo ' || '<<' || diferenca || '>>'
                        WHEN _validade    <= 120    THEN 'Validade <<' || _validade || '>>' || ' Prazo ' || '<<' || diferenca || '>>'
                        WHEN _validade    >= 120    THEN 'Validade <<' || _validade || '>>' || ' Prazo ' || '<<' || diferenca || '>>'
                        WHEN diferenca    <=  60    THEN 'Até 60 dias ' || '<<' || diferenca || '>>'
                        WHEN diferenca    <= 120    THEN 'Até 120 dias ' || '<<' || diferenca || '>>'
                        ELSE                       'Validade Produto'
                  END;
     
     raise notice 'Diferenca em dias % ',diferenca;
    

END;
$function$
;

go


select * from etapa_extenso('2017-08-31','2017-08-15',180,0);