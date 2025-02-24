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


BEGIN

        Comentarios := true;

        _saida := 0;

         taxa := 0;
 
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
                        ,con.qtd_e          as qtd_saida
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

                            Base_Pis_Nova        :=  notas.ven_pis_base      - ( notas.con_qtd_usada * Icms_St_Unit);

                            Base_Cofins_Nova     :=  notas.ven_cof_base      - ( notas.con_qtd_usada * Icms_St_Unit);

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
                                      ,'2024-06-30'
                                      ,vlr_economico_pis
                                      ,vlr_economico_cofins
                                      ,'2024-06-30'
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
