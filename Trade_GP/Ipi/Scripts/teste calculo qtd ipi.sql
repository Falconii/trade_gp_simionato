select local,dt_ref,id_operacao,status
from nfe_det_trade 
where    to_char(dt_ref,'MM/YYYY') = '01/2021' and 
         local = '0057'
GROUP BY local,dt_ref,id_operacao,status
ORDER BY local,dt_ref,id_operacao,status

73410326005715

select * from clientes cli  where cli.id_grupo = 1 and cli.cnpj_cpf = '73410326001213' and  left(cli.cnpj_cpf,8) = '73410326' ;

select * from clientes cli where cli.id_grupo = 1 and cli.cod_empresa = '1001' and cli.local = '0057' 

select * from bonixvenda_periodo(1,'1001','0057','21/01/2021',1,2025,03)

select * from bonixvenda_nota(1,'1001','0057','21/01/2021',1,2025,03)

select * from nfe_det_trade where dt_ref = '2021/03/04' and id_operacao = 'B'

select * from controle_e

select * from nfe_det_trade_val_ipi

select cli.cnpj_cpf  as cnpj_empresa
       ,bon.cnpj_cpf as cnpj_boni
       ,ven.cnpj_cpf as cnpj_venda
       ,case
           when bon.status = '0' then 'Não Processado'
           when bon.status = '1' then 'Processado Normalmente'
           when bon.status = '2' then 'Processado Intercompany'
           when bon.status = '3' then 'Não Processado  "Não é bebida"'
           when bon.status = '4' then 'Não Processado  "Bonificação Própria"'
           else                       'Não Identificado -> ' || bon.status
        end as status_bon
       ,bon.local
       ,bon.nro_doc
       ,bon.cfop
       ,bon.material
       ,bon.denom
       ,bon.quantidade_1
       ,bon.saldo
       ,(con.qtd_s + con.qtd_e) as saldo_operacao
       ,con.qtd_e as qtd_usada
       ,case
           when con.metodo_qtd = 'D' then 'DIRETO'
           else                           'FORMULA'
        end as calculo_qtd   
       ,case
           when con.metodo_pesquisa = 'N' then 'NOTA BONIFICAÇÃO'
           else                                'PERIODO 30 DIAS'
        end as encontrou_venda   
       ,con.perc_boni
       ,con.perc_ven
       ,((con.qtd_s + con.qtd_e)) + ven.quantidade_1 as total_operacao
       ,bon.dt_ref as bonificacao_emissao
       ,ven.dt_ref as venda_emissao
       ,con.dias
       ,bon.ipi_vlr
       ,ven.nro_doc
       ,ven.cfop
       ,ven.material
       ,ven.quantidade_1
       ,ven.saldo
       ,ven.ipi_vlr
       ,ven.status
       ,val.*
from controle_e con
inner join nfe_det_trade bon on bon.id_grupo = con.id_grupo and bon.id_planilha = con.id_s and bon.nro_linha = con.nro_linha_s
inner join nfe_det_trade ven on ven.id_grupo = con.id_grupo and ven.id_planilha = con.id_e and ven.nro_linha = con.nro_linha_e
left  join nfe_det_trade_val_ipi val on val.id_grupo = bon.id_grupo and val.id = bon.id_planilha and val.nro_linha = bon.nro_linha 
           and val.id_planilha_entrada = ven.id_planilha and val.nro_linha_entrada = ven.nro_linha
inner join clientes cli      on cli.id_grupo = bon.id_grupo and cli.cod_empresa = bon.cod_emp and cli.local = bon.local
where bon.id_grupo = 1 and bon.cod_emp = '1001' and bon.local = '0057' 
    --and to_char(bon.dt_ref,'YYYY') = '2017'
order by con.id_grupo,con.id_fechamento,con.id_s,con.nro_linha_s,con.seq


select  cli.cnpj_cpf  as cnpj_empresa
        ,bon.cnpj_cpf as cnpj_boni
       ,bon.local
       ,case
           when bon.status = '0' then bon.status || ' -> Não Processado'
           when bon.status = '1' then bon.status || ' -> Processado Normalmente'
           when bon.status = '2' then bon.status || ' -> Processado Intercompany'
           when bon.status = '3' then bon.status || ' -> Não Processado  "Não é bebida"'
           when bon.status = '4' then bon.status || ' -> Não Processado  "Bonificação Própria"'
           else           ' Não Identificado -> ' || bon.status
        end as status_bon
       ,bon.id_operacao 
       ,bon.nro_doc
       ,bon.cfop
       ,bon.material
       ,bon.denom
       ,bon.quantidade_1
       ,bon.saldo
       ,bon.dt_ref as bonificacao_emissao
       ,bon.ipi_vlr
       ,bon.bebida
from nfe_det_trade bon
inner join clientes cli on cli.id_grupo = bon.id_grupo and cli.cod_empresa = bon.cod_emp and cli.local = bon.local
where bon.id_grupo = 1 and bon.cod_emp = '1001' and bon.local = '0057' and to_char(bon.dt_ref,'YYYY') = '2017' and id_operacao = 'B' 
and quantidade_1 = saldo
order by bon.id_grupo,bon.cod_emp,bon.local,bon.id_operacao


select  distinct bon.nro_doc
       ,bon.cfop
       ,bon.material
from controle_e con
inner join nfe_det_trade bon on bon.id_grupo = con.id_grupo and bon.id_planilha = con.id_s and bon.nro_linha = con.nro_linha_s
inner join nfe_det_trade ven on ven.id_grupo = con.id_grupo and ven.id_planilha = con.id_e and ven.nro_linha = con.nro_linha_e
left  join nfe_det_trade_val_ipi val on val.id_grupo = bon.id_grupo and val.id = bon.id_planilha and val.nro_linha = bon.nro_linha 
           and val.id_planilha_entrada = ven.id_planilha and val.nro_linha_entrada = ven.nro_linha
inner join clientes cli      on cli.id_grupo = bon.id_grupo and cli.cod_empresa = bon.cod_emp and cli.local = bon.local
where bon.id_grupo = 1 and bon.cod_emp = '1001' and bon.local = '0057' and to_char(bon.dt_ref,'YYYY') = '2017'






select left(cnpj_cpf,8) from clientes where id_grupo = 1 and cod_empresa = '1004' and local = '0010'

select * from clientes where cnpj_cpf = '02526303516' 


select * from nfe_det_trade where nro_posicao = '000003016'


select * from nfe_det_trade where id_operacao = 'V' and cnpj_cpf = '02526303516' and material = '2000076' and dt_ref <= '2021-01-21' order by  dt_ref desc


select * from nfe_det_trade where cod_emp = '1001' and local = '0057' and id_operacao = 'B' and dt_ref = '2021-01-21' 
 
 
 and status = '0'  
                     and saldo > 0 
                     
                     
 /* teste intercompany */
 
 select * from clientes cli where cod_empresa = '1001' and ( local = '0001' or local = '0057' )
 
 select coalesce(count(*),0) from clientes cli  where cli.id_grupo = 1 and left(cli.cnpj_cpf,8) = '73410326' ;

 //73410326
 CERVEJARIA PETROPOLIS S/A
 
 73410326000160
 
 //bonificacao
 select * from nfe_det_trade where cod_emp = '1001' and local = '0057' and nro_doc = '8709726455'
 go
//venda
 select * from nfe_det_trade where cod_emp = '1001' and local = '0057' and nro_doc = '8708985417' or nro_doc = '8709305845'
 go
 
 
 update nfe_det_trade set cnpj_cpf = '73410326000160', radical_cnpj = '73410326' where cod_emp = '1001' and local = '0057' and nro_doc = '8709726455'
 go
 update nfe_det_trade set cnpj_cpf = '73410326000160', radical_cnpj = '73410326' where cod_emp = '1001' and local = '0057' and nro_doc = '8708985417' or nro_doc = '8709305845'
 go
 
 
 select coalesce(count(*),0) from clientes cli into __total_intercompany where cli.id_grupo = _id_grupo and left(cli.cnpj_cpf,8) = tempo.radical_cnpj ;


 //Teste Não Bebida
 
 update nfe_det_trade set bebida = 'N' where cod_emp = '1001' and local = '0057' and nro_doc = '8709726455'
 go
 
 
 select * from selic order by ano desc, mes desc limit 3
 
 
 select * from parametro
 
 UPDATE PARAMETRO SET  VALOR = '02/2025'  WHERE  CHAVE = 'SELIC' 
 
 
 select * from nfe_det_trade where id_operacao = 'B'
 
 
 /*
 
 Validação de bonificações não aproveitadas
 
8625382509	5910	1010808	CERV CRY PILS LT 269ML PAC C/12	38	38	26/01/2017
8625577833	5910	1010934	CERV ITA PILS LN 355ML PAC C/12	20	20	30/01/2017
8625655491	5910	1010808	CERV CRY PILS LT 269ML PAC C/12	19	19	31/01/2017
8625300612	5910	1010799	CERV CRY PILS GRF RET 600ML CX C/24	3	3	25/01/2017
 
 */
 
 //select * from nfe_det_trade where nro_doc = '8625655491' and material = '1010808' and dt_ref <= '2017-01-26' and id_operacao = 'V'