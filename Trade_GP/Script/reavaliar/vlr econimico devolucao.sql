CREATE OR REPLACE FUNCTION "public"."vlr_enconomico_c" (
                           in _grupo int4, in _cod_emp text , in _local text , in _mes_ano text, in _ano_selic int4, in _mes_selic int4, out _saida int4)  
AS
$$
DECLARE
 notas public.NOTAS%ROWTYPE;
 Comentarios boolean;  
 Icms_St_Unit numeric(15,4);
 Base_Pis_Nova numeric(15,4);
 Base_Cofins_Nova numeric(15,4);
 Perc_Pis_Novo numeric(6,2);
 Vlr_Pis_Novo numeric(15,4); 
 Perc_Cofins_Novo numeric(6,2);
 Vlr_Cofins_Novo                numeric(15,4);
 _vlr_economico_pis              numeric(15,4);
 _vlr_economico_cofins           numeric(15,4);
 _vlr_economico_pis_corrigido    numeric(15,4);
 _vlr_economico_cofins_corrigido numeric(15,4);
 taxa numeric(6,2);
 old_id int4;
 old_nro_linha int4;
 old_qtd  numeric(15,4);
 qtd_calculo  numeric(15,4);
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
                                  ,'2024-06-30'
                                  ,_vlr_economico_pis
                                  ,_vlr_economico_cofins
                                  ,'2024-06-30'
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
                                  ,'2024-06-30'
                                  ,_vlr_economico_pis * -1
                                  ,_vlr_economico_cofins * -1
                                  ,'2024-06-30'
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


