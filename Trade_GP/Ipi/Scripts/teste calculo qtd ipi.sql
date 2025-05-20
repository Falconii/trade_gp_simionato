select local,dt_ref,id_operacao
from nfe_det_trade 
where to_char(dt_ref,'MM/YYYY') = '07/2021'
GROUP BY local,dt_ref,id_operacao
ORDER BY local,dt_ref,id_operacao

select * from bonixvenda_periodo(1,'1001','0003','16/07/2021',1)

select * from bonixvenda_nota(1,'1001','0003','16/07/2021',1)

select * from nfe_det_trade where dt_ref = '2021/03/04' and id_operacao = 'B'

select * from controle_e

select  con.*
       ,bon.cnpj_cpf as cnpj_boni
       ,ven.cnpj_cpf as cnpj_venda
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
       ,bon.status as status_bon
       ,bon.ipi_vlr
       ,ven.nro_doc
       ,ven.cfop
       ,ven.material
       ,ven.quantidade_1
       ,ven.saldo
       ,ven.ipi_vlr
       ,ven.status
from controle_e con
inner join nfe_det_trade bon on bon.id_grupo = con.id_grupo and bon.id_planilha = con.id_s and bon.nro_linha = con.nro_linha_s
inner join nfe_det_trade ven on ven.id_grupo = con.id_grupo and ven.id_planilha = con.id_e and ven.nro_linha = con.nro_linha_e
where bon.id_grupo = 1 and bon.cod_emp = '1001' and to_char(bon.dt_ref,'DD/MM/YYYY') = '04/03/2021'
order by con.id_grupo,con.id_fechamento,con.id_s,con.nro_linha_s,con.seq

select left(cnpj_cpf,8) from clientes where id_grupo = 1 and cod_empresa = '1004' and local = '0010'
