//8709726455

//bonificacao
select id_operacao,cnpj_cpf,nro_doc,material,quantidade_1,dt_ref,radical_cnpj
from nfe_det_trade where nro_doc = '8709726455'
go
//venda
select id_operacao,nro_doc,material,quantidade_1,dt_ref
from nfe_det_trade where id_operacao = 'V' and material = '2000076' and dt_ref <= '21/10/2021' and quantidade_1 = 10 order by dt_ref 
go
select * 
from  nfe_det_trade 
where id_operacao = 'V' and material = '2000076' and dt_ref <= '21/10/2021' and nro_doc = '8708842714' order by dt_ref

update nfe_det_trade set nro_doc = '8709726455', cfop = '5910', dt_ref = '2021-01-21',cnpj_cpf = '02526303516'  , radical_cnpj = '02526303'
where nro_doc = '8710043482' and material = '2000076'
