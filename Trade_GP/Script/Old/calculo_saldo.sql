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
               select _saldo_f from seek_saida_2(tempo.id_grupo,tempo.cod_emp,tempo.local,tempo.id_planilha,tempo.nro_linha,tempo.material,tempo.quantidade_1,tempo.dt_ref,tempo.id_saida,tempo.nro_linha_saida,_id_fechamento) into __saldo_f ;
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



select * from calculo_saldo(1,'1004','0004','04/2017',1);

 SELECT COUNT(*)
      FROM   nfe_det_trade DET
      WHERE  DET.id_grupo = 1 and DET.cod_emp = '1004' and Det.local = '0004' and det.id_operacao = 'S' and det.status = '0' and (det.dt_ref >=  '2017-05-01' and  det.dt_ref <= '2017-05-31')  
     

      SELECT *
      FROM   nfe_det_trade DET
      WHERE  DET.id_grupo = 1 and DET.cod_emp = '1004' and Det.local = '0002' and det.id_operacao = 'S' and det.status = '0' and (det.dt_ref >=  '2017-02-01' and  det.dt_ref <= '2017-02-28')  
      ORDER BY DET.id_grupo,DET.cod_emp,DET.local,DET.dt_ref,DET.nro_doc,DET.nro_item limit 1000


//Com Base Nas Saidas
select   ven.id_grupo
        ,ven.id_planilha
        ,ven.id_operacao
        ,ven.nro_linha
        ,ven.cod_emp
        ,ven.local
        ,ven.id_planilha
        ,ven.dt_doc
        ,ven.dt_lanc
        ,ven.nro_doc
        ,ven.nro_item
        ,ven.material
        ,ven.denom
        ,ven.quantidade_1 
        ,ven.unid
        ,ven.preco_liq
        ,ven.vlr_contb
        ,ven.cfop
        ,ven.saldo
        ,ven.qtd_dev
        ,ven.pis_base
        ,ven.pis_taxa
        ,ven.pis_vlr
        ,ven.cof_base
        ,ven.cof_taxa
        ,ven.cof_vlr
        ,con.qtd_e    as qtd_usada
        ,ven.qtd_dev 
        ,'<===>'      as saidas_entradas
        ,ent.quantidade_1   as qtd_entrada
        ,con.qtd_e  as qtd_usada
        ,ent.pis_base
        ,ent.pis_vlr
        ,ent.cof_base
        ,ent.cof_vlr
        ,ent.icst_valor
        ,ent.fest_valor
        ,ent.saldo
        ,ent.id_grupo
        ,ent.id_planilha
        ,ent.id_operacao
        ,ent.nro_linha
        ,ent.cod_emp
        ,ent.local
        ,ent.id_planilha
        ,ent.dt_doc
        ,ent.dt_lanc
        ,ent.nro_doc
        ,ent.nro_item
        ,ent.material
        ,ent.denom
        ,ent.cod_controle
        ,ent.unid
        ,ven.preco_liq
        ,ven.vlr_contb
        ,ent.cfop
from     controle_e con 
inner join nfe_det_trade ent on ent.id_planilha  = con.id_e and ent.nro_linha = con.nro_linha_e 
inner join nfe_det_trade ven on ven.id_planilha = con.id_s and ven.nro_linha = con.nro_linha_s 
inner join clientes cli on cli.cod_empresa = ven.cod_emp and cli.local = ven.local 
--inner join fechamento fec on fec.id_grupo = con.id_grupo and fec.id = con.id_fechamento   
where  VEN.ID_GRUPO = 1  and  con.id_fechamento = 1  and  VEN.STATUS = '1'  and   VEN.ID_OPERACAO = 'S'  
order by ven.cod_emp,ven.local,ven.nro_doc,ven.nro_item  
go

SELECT *  FROM nfe_det_trade where nro_doc = '8625807652' and id_operacao = 'S' and status = '0' limit 100

SELECT *  FROM nfe_det_trade where  id_planilha = 17 and nro_linha = 806 union all
SELECT *  FROM nfe_det_trade where  id_planilha = 22 and nro_linha = 10128
go

SELECT * FROM CONTROLE_E where   id_s = 22 and nro_linha_s = 10128

DELETE FROM CONTROLE_E where   id_s = 8 and nro_linha_s = 107 and id_e = 1 and nro_linha_e = 432;

SELECT *  FROM nfe_det_trade where LOCAL = '0002' AND id_operacao = 'S' and TO_CHAR(DT_DOC,'MM-YYYY') = '02-2017'; 

SELECT * FROM controle_e

SELECT * FROM USUARIOS