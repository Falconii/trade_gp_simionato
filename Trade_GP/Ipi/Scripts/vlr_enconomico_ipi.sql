
DROP TYPE IF EXISTS VALORRECORD;
CREATE TYPE VALORRECORD AS 
(
    
    bon_id_grupo  INT4,
    bon_id_planilha INT4,
    bon_nro_linha INT4,
    bon_dt_ref date,
    bon_quantidade_1  numeric(15,4),
    bon_ipi_vlr  numeric(15,4),
    con_qtd_e     numeric(15,2),       
    ven_id_grupo  INT4,
    ven_id_planilha INT4,
    ven_nro_linha INT4
);
go
CREATE OR REPLACE FUNCTION public.vlr_enconomico_ipi(_grupo integer, _cod_emp text, _local text, _dia_mes_ano text, _ano_selic integer, _mes_selic integer, OUT _saida integer)
 RETURNS integer
 LANGUAGE plpgsql
AS $function$
    DECLARE
     
     notas public.VALORRECORD%ROWTYPE;
   
     __taxa          numeric(6,2);
     
     __ipi_unit      numeric(15,4);
            
     __ipi_economico numeric(15,4);

     __ipi_economico_corrigido numeric(15,4);

     data_inicial Date;
	 
    BEGIN

            data_inicial := Date '2012-07-25';

            _saida := 0;
            
            __taxa := 0;
  
            __ipi_unit := 0;
            
            __ipi_economico := 0;

            __ipi_economico_corrigido := 0;
             
            FOR notas in  
                   SELECT 
                            bon.id_grupo
                           ,bon.id_planilha
                           ,bon.nro_linha
                           ,bon.dt_ref
                           ,bon.quantidade_1
                           ,bon.ipi_vlr
                           ,con.qtd_e          
                           ,ven.id_grupo
                           ,ven.id_planilha
                           ,ven.nro_linha
                   from     controle_e con 
                   inner join nfe_det_trade bon  on bon  .id_grupo = con.id_grupo and bon  .id_planilha = con.id_s and bon   .nro_linha = con.nro_linha_s
                   inner join nfe_det_trade ven on ven.id_grupo = con.id_grupo and ven.id_planilha  = con.id_e and ven.nro_linha = con.nro_linha_e 
                   where con.id_grupo = _grupo and con.id_fechamento = 1  and con.qtd_e > 0 and bon.cod_emp = _cod_emp and bon.LOCAL = _local  and bon.dt_ref >= data_inicial and to_char(bon.dt_ref,'DD/MM/YYYY') = _dia_mes_ano and  (bon.STATUS = '1' OR bon.STATUS = '2') and  bon.ID_OPERACAO = 'B'  
                   order by bon.cod_emp
                           ,bon.local
                           ,bon.id_planilha
                           ,bon.dt_ref
                           ,bon.nro_doc
                           ,bon.nro_item
                           ,bon.material
                LOOP            
                               if (__taxa = 0 ) then

								   SELECT get_selic FROM get_selic( cast( to_char(notas.bon_dt_ref, 'YYYY') AS INT4), cast (to_char(notas.bon_dt_ref, 'MM') AS INT4),_ano_selic,_mes_selic) into __taxa ;
                                  
								end if;
                                 
                                __ipi_unit              := notas.bon_ipi_vlr / notas.bon_quantidade_1;

                                __ipi_economico         := notas.con_qtd_e * __ipi_unit;
        
                               __ipi_economico_corrigido := __ipi_economico * ( (__taxa / 100) + 1);

								
								INSERT INTO 
                                    nfe_det_trade_val_ipi(
	                                    id_grupo,
	                                    id,
	                                    nro_linha,
	                                    id_planilha_entrada,
	                                    nro_linha_entrada,
	                                    dtnfe,
	                                    dtcredito,
	                                    vlr_economico_ipi,
	                                    dtfcorrecao,
	                                    vlr_economico_ipi_corrigido,
	                                    taxa,
	                                    ipi_unit,
	                                    qtd_calculada,
	                                    usuarioinclusao,
	                                    usuarioatualizacao
                                    ) 
                                    VALUES(
	                                    _grupo,
	                                    notas.bon_id_planilha,
	                                    notas.bon_nro_linha,
	                                    notas.ven_id_planilha,
	                                    notas.ven_nro_linha,
	                                    notas.bon_dt_ref,
	                                    '2025-05-22',
	                                    __ipi_economico,
	                                    '2025-05-22',
	                                    __ipi_economico_corrigido,
	                                    __taxa,
	                                    __ipi_unit,
	                                    notas.con_qtd_e,
	                                    16,
	                                    0
                                    )
									ON CONFLICT (id_grupo,id,nro_linha,id_planilha_entrada,nro_linha_entrada)
									DO UPDATE SET 
											   vlr_economico_ipi            = __ipi_economico
											  ,vlr_economico_ipi_corrigido  = __ipi_economico_corrigido
											  ,taxa                         = __taxa
											  ,qtd_calculada                = notas.con_qtd_e;
                             _saida = _saida + 1;

                END LOOP;
            
                RETURN; 
    END;
    $function$
;
go





