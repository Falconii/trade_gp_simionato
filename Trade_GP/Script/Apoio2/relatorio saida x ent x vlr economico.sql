--sintetico
select tabela.* from 
(
    select ven.cod_emp,ven.local,cli.razao,cli.cnpj_cpf,cli.cidadef,
           to_char(ven.dt_ref,'MM/YYYY')           as data ,
           sum(val.vlr_economico_pis)              as vlr_economico_pis,
           sum(val.vlr_economico_pis_corrigido)    as vlr_economico_pis_corrigido,
           sum(val.vlr_economico_cofins)           as vlr_economico_cofins,
           sum(val.vlr_economico_cofins_corrigido) as vlr_economico_cofins_corrigido
    from controle_e con
        INNER JOIN 
        nfe_det_trade ven 
        ON  ven.id_grupo = 1 and ven.id_planilha = con.id_s AND ven.nro_linha = con.nro_linha_s
        INNER JOIN 
        nfe_det_trade ent 
        ON  ent.id_grupo = 1 and ent.id_planilha = con.id_e  AND ent.nro_linha = con.nro_linha_e
        INNER JOIN  nfe_det_trade_val val
        ON val.id_grupo = con.id_grupo 
          and (val.id = con.id_s and val.nro_linha = con.nro_linha_s )
          and (val.id_planilha_entrada = con.id_e and val.nro_linha_entrada = con.nro_linha_e)
        INNER JOIN 
        clientes cli
        ON cli.id_grupo = 1 and cli.cod_empresa = ven.cod_emp and cli.local = ven.local
    where ven.id_grupo = 1 and ven.cod_emp = '1004' 
    group by ven.cod_emp,ven.local,cli.razao,cli.cnpj_cpf,cli.cidadef,to_char(ven.dt_ref,'MM/YYYY')
    order by ven.cod_emp,ven.local,cli.razao,cli.cnpj_cpf,cli.cidadef,to_char(ven.dt_ref,'MM/YYYY')
) as tabela
order by cod_emp,local,razao,cnpj_cpf,cidadef,right(data,4) || left(data,2)


--0001
select 
   ven.*
         ,case
            when ven.id_operacao = 'S' then 'SAIDA 5405'
            else                            'OUTRAS SAIDAS'
         end as Operacao
        ,'<== ==>' as ENTRADA_SAIDA
        ,con.qtd_e as QTD_USADA
        ,case
            when ent.id_operacao = 'E' then 'ENTRADAS'
            when ent.id_operacao = 'e' then 'entrada'
            when ent.id_operacao = 'X' then 'SALDO'
            when ent.id_operacao = 'x' then 'saldo'
            else                            'NAO DEFINIDO'
         end as Operacao
        ,ent.*
        ,case
            when ent.id_operacao in('E','e') then ent.saldo
            when ent.id_operacao in('X','x') then ent.saldo_inicial
         end as saldo
        ,val.*
from controle_e con
    INNER JOIN 
    nfe_det_trade ven 
    ON  ven.id_grupo = 1 and ven.id_planilha = con.id_s AND ven.nro_linha = con.nro_linha_s
    INNER JOIN 
    nfe_det_trade ent 
    ON  ent.id_grupo = 1 and ent.id_planilha = con.id_e  AND ent.nro_linha = con.nro_linha_e
    INNER JOIN  nfe_det_trade_val val
    ON val.id_grupo = con.id_grupo 
      and (val.id = con.id_s and val.nro_linha = con.nro_linha_s )
      and (val.id_planilha_entrada = con.id_e and val.nro_linha_entrada = con.nro_linha_e)
where ven.id_grupo = 1 and ven.cod_emp = '1004' and ven.local = '0001'
order by ven.cod_emp,ven.local,ven.dt_ref,ven.nro_doc
go
--0002
select 
   ven.*
         ,case
            when ven.id_operacao = 'S' then 'SAIDA 5405'
            else                            'OUTRAS SAIDAS'
         end as Operacao
        ,'<== ==>' as ENTRADA_SAIDA
        ,con.qtd_e as QTD_USADA
        ,case
            when ent.id_operacao = 'E' then 'ENTRADAS'
            when ent.id_operacao = 'e' then 'entrada'
            when ent.id_operacao = 'X' then 'SALDO'
            when ent.id_operacao = 'x' then 'saldo'
            else                            'NAO DEFINIDO'
         end as Operacao
        ,ent.*
        ,case
            when ent.id_operacao in('E','e') then ent.saldo
            when ent.id_operacao in('X','x') then ent.saldo_inicial
         end as saldo
        ,val.*
from controle_e con
    INNER JOIN 
    nfe_det_trade ven 
    ON  ven.id_grupo = 1 and ven.id_planilha = con.id_s AND ven.nro_linha = con.nro_linha_s
    INNER JOIN 
    nfe_det_trade ent 
    ON  ent.id_grupo = 1 and ent.id_planilha = con.id_e  AND ent.nro_linha = con.nro_linha_e
    INNER JOIN  nfe_det_trade_val val
    ON val.id_grupo = con.id_grupo 
      and (val.id = con.id_s and val.nro_linha = con.nro_linha_s )
      and (val.id_planilha_entrada = con.id_e and val.nro_linha_entrada = con.nro_linha_e)
where ven.id_grupo = 1 and ven.cod_emp = '1004' and ven.local = '0002'
order by ven.cod_emp,ven.local,ven.dt_ref,ven.nro_doc
go
--0003
select 
   ven.*
         ,case
            when ven.id_operacao = 'S' then 'SAIDA 5405'
            else                            'OUTRAS SAIDAS'
         end as Operacao
        ,'<== ==>' as ENTRADA_SAIDA
        ,con.qtd_e as QTD_USADA
        ,case
            when ent.id_operacao = 'E' then 'ENTRADAS'
            when ent.id_operacao = 'e' then 'entrada'
            when ent.id_operacao = 'X' then 'SALDO'
            when ent.id_operacao = 'x' then 'saldo'
            else                            'NAO DEFINIDO'
         end as Operacao
        ,ent.*
        ,case
            when ent.id_operacao in('E','e') then ent.saldo
            when ent.id_operacao in('X','x') then ent.saldo_inicial
         end as saldo
        ,val.*
from controle_e con
    INNER JOIN 
    nfe_det_trade ven 
    ON  ven.id_grupo = 1 and ven.id_planilha = con.id_s AND ven.nro_linha = con.nro_linha_s
    INNER JOIN 
    nfe_det_trade ent 
    ON  ent.id_grupo = 1 and ent.id_planilha = con.id_e  AND ent.nro_linha = con.nro_linha_e
    INNER JOIN  nfe_det_trade_val val
    ON val.id_grupo = con.id_grupo 
      and (val.id = con.id_s and val.nro_linha = con.nro_linha_s )
      and (val.id_planilha_entrada = con.id_e and val.nro_linha_entrada = con.nro_linha_e)
where ven.id_grupo = 1 and ven.cod_emp = '1004' and ven.local = '0003'
order by ven.cod_emp,ven.local,ven.dt_ref,ven.nro_doc
go
--0004
select 
   ven.*
         ,case
            when ven.id_operacao = 'S' then 'SAIDA 5405'
            else                            'OUTRAS SAIDAS'
         end as Operacao
        ,'<== ==>' as ENTRADA_SAIDA
        ,con.qtd_e as QTD_USADA
        ,case
            when ent.id_operacao = 'E' then 'ENTRADAS'
            when ent.id_operacao = 'e' then 'entrada'
            when ent.id_operacao = 'X' then 'SALDO'
            when ent.id_operacao = 'x' then 'saldo'
            else                            'NAO DEFINIDO'
         end as Operacao
        ,ent.*
        ,case
            when ent.id_operacao in('E','e') then ent.saldo
            when ent.id_operacao in('X','x') then ent.saldo_inicial
         end as saldo
        ,val.*
from controle_e con
    INNER JOIN 
    nfe_det_trade ven 
    ON  ven.id_grupo = 1 and ven.id_planilha = con.id_s AND ven.nro_linha = con.nro_linha_s
    INNER JOIN 
    nfe_det_trade ent 
    ON  ent.id_grupo = 1 and ent.id_planilha = con.id_e  AND ent.nro_linha = con.nro_linha_e
    INNER JOIN  nfe_det_trade_val val
    ON val.id_grupo = con.id_grupo 
      and (val.id = con.id_s and val.nro_linha = con.nro_linha_s )
      and (val.id_planilha_entrada = con.id_e and val.nro_linha_entrada = con.nro_linha_e)
where ven.id_grupo = 1 and ven.cod_emp = '1004' and ven.local = '0004'
order by ven.cod_emp,ven.local,ven.dt_ref,ven.nro_doc
go
--0005
select 
   ven.*
         ,case
            when ven.id_operacao = 'S' then 'SAIDA 5405'
            else                            'OUTRAS SAIDAS'
         end as Operacao
        ,'<== ==>' as ENTRADA_SAIDA
        ,con.qtd_e as QTD_USADA
        ,case
            when ent.id_operacao = 'E' then 'ENTRADAS'
            when ent.id_operacao = 'e' then 'entrada'
            when ent.id_operacao = 'X' then 'SALDO'
            when ent.id_operacao = 'x' then 'saldo'
            else                            'NAO DEFINIDO'
         end as Operacao
        ,ent.*
        ,case
            when ent.id_operacao in('E','e') then ent.saldo
            when ent.id_operacao in('X','x') then ent.saldo_inicial
         end as saldo
        ,val.*
from controle_e con
    INNER JOIN 
    nfe_det_trade ven 
    ON  ven.id_grupo = 1 and ven.id_planilha = con.id_s AND ven.nro_linha = con.nro_linha_s
    INNER JOIN 
    nfe_det_trade ent 
    ON  ent.id_grupo = 1 and ent.id_planilha = con.id_e  AND ent.nro_linha = con.nro_linha_e
    INNER JOIN  nfe_det_trade_val val
    ON val.id_grupo = con.id_grupo 
      and (val.id = con.id_s and val.nro_linha = con.nro_linha_s )
      and (val.id_planilha_entrada = con.id_e and val.nro_linha_entrada = con.nro_linha_e)
where ven.id_grupo = 1 and ven.cod_emp = '1004' and ven.local = '0005'
order by ven.cod_emp,ven.local,ven.dt_ref,ven.nro_doc
go
--0006
select 
   ven.*
         ,case
            when ven.id_operacao = 'S' then 'SAIDA 5405'
            else                            'OUTRAS SAIDAS'
         end as Operacao
        ,'<== ==>' as ENTRADA_SAIDA
        ,con.qtd_e as QTD_USADA
        ,case
            when ent.id_operacao = 'E' then 'ENTRADAS'
            when ent.id_operacao = 'e' then 'entrada'
            when ent.id_operacao = 'X' then 'SALDO'
            when ent.id_operacao = 'x' then 'saldo'
            else                            'NAO DEFINIDO'
         end as Operacao
        ,ent.*
        ,case
            when ent.id_operacao in('E','e') then ent.saldo
            when ent.id_operacao in('X','x') then ent.saldo_inicial
         end as saldo
        ,val.*
from controle_e con
    INNER JOIN 
    nfe_det_trade ven 
    ON  ven.id_grupo = 1 and ven.id_planilha = con.id_s AND ven.nro_linha = con.nro_linha_s
    INNER JOIN 
    nfe_det_trade ent 
    ON  ent.id_grupo = 1 and ent.id_planilha = con.id_e  AND ent.nro_linha = con.nro_linha_e
    INNER JOIN  nfe_det_trade_val val
    ON val.id_grupo = con.id_grupo 
      and (val.id = con.id_s and val.nro_linha = con.nro_linha_s )
      and (val.id_planilha_entrada = con.id_e and val.nro_linha_entrada = con.nro_linha_e)
where ven.id_grupo = 1 and ven.cod_emp = '1004' and ven.local = '0006'
order by ven.cod_emp,ven.local,ven.dt_ref,ven.nro_doc
go
--0007
select 
   ven.*
         ,case
            when ven.id_operacao = 'S' then 'SAIDA 5405'
            else                            'OUTRAS SAIDAS'
         end as Operacao
        ,'<== ==>' as ENTRADA_SAIDA
        ,con.qtd_e as QTD_USADA
        ,case
            when ent.id_operacao = 'E' then 'ENTRADAS'
            when ent.id_operacao = 'e' then 'entrada'
            when ent.id_operacao = 'X' then 'SALDO'
            when ent.id_operacao = 'x' then 'saldo'
            else                            'NAO DEFINIDO'
         end as Operacao
        ,ent.*
        ,case
            when ent.id_operacao in('E','e') then ent.saldo
            when ent.id_operacao in('X','x') then ent.saldo_inicial
         end as saldo
        ,val.*
from controle_e con
    INNER JOIN 
    nfe_det_trade ven 
    ON  ven.id_grupo = 1 and ven.id_planilha = con.id_s AND ven.nro_linha = con.nro_linha_s
    INNER JOIN 
    nfe_det_trade ent 
    ON  ent.id_grupo = 1 and ent.id_planilha = con.id_e  AND ent.nro_linha = con.nro_linha_e
    INNER JOIN  nfe_det_trade_val val
    ON val.id_grupo = con.id_grupo 
      and (val.id = con.id_s and val.nro_linha = con.nro_linha_s )
      and (val.id_planilha_entrada = con.id_e and val.nro_linha_entrada = con.nro_linha_e)
where ven.id_grupo = 1 and ven.cod_emp = '1004' and ven.local = '0007'
order by ven.cod_emp,ven.local,ven.dt_ref,ven.nro_doc
go
--0008
select 
   ven.*
         ,case
            when ven.id_operacao = 'S' then 'SAIDA 5405'
            else                            'OUTRAS SAIDAS'
         end as Operacao
        ,'<== ==>' as ENTRADA_SAIDA
        ,con.qtd_e as QTD_USADA
        ,case
            when ent.id_operacao = 'E' then 'ENTRADAS'
            when ent.id_operacao = 'e' then 'entrada'
            when ent.id_operacao = 'X' then 'SALDO'
            when ent.id_operacao = 'x' then 'saldo'
            else                            'NAO DEFINIDO'
         end as Operacao
        ,ent.*
        ,case
            when ent.id_operacao in('E','e') then ent.saldo
            when ent.id_operacao in('X','x') then ent.saldo_inicial
         end as saldo
        ,val.*
from controle_e con
    INNER JOIN 
    nfe_det_trade ven 
    ON  ven.id_grupo = 1 and ven.id_planilha = con.id_s AND ven.nro_linha = con.nro_linha_s
    INNER JOIN 
    nfe_det_trade ent 
    ON  ent.id_grupo = 1 and ent.id_planilha = con.id_e  AND ent.nro_linha = con.nro_linha_e
    INNER JOIN  nfe_det_trade_val val
    ON val.id_grupo = con.id_grupo 
      and (val.id = con.id_s and val.nro_linha = con.nro_linha_s )
      and (val.id_planilha_entrada = con.id_e and val.nro_linha_entrada = con.nro_linha_e)
where ven.id_grupo = 1 and ven.cod_emp = '1004' and ven.local = '0008'
order by ven.cod_emp,ven.local,ven.dt_ref,ven.nro_doc
go
--0009
select 
   ven.*
         ,case
            when ven.id_operacao = 'S' then 'SAIDA 5405'
            else                            'OUTRAS SAIDAS'
         end as Operacao
        ,'<== ==>' as ENTRADA_SAIDA
        ,con.qtd_e as QTD_USADA
        ,case
            when ent.id_operacao = 'E' then 'ENTRADAS'
            when ent.id_operacao = 'e' then 'entrada'
            when ent.id_operacao = 'X' then 'SALDO'
            when ent.id_operacao = 'x' then 'saldo'
            else                            'NAO DEFINIDO'
         end as Operacao
        ,ent.*
        ,case
            when ent.id_operacao in('E','e') then ent.saldo
            when ent.id_operacao in('X','x') then ent.saldo_inicial
         end as saldo
        ,val.*
from controle_e con
    INNER JOIN 
    nfe_det_trade ven 
    ON  ven.id_grupo = 1 and ven.id_planilha = con.id_s AND ven.nro_linha = con.nro_linha_s
    INNER JOIN 
    nfe_det_trade ent 
    ON  ent.id_grupo = 1 and ent.id_planilha = con.id_e  AND ent.nro_linha = con.nro_linha_e
    INNER JOIN  nfe_det_trade_val val
    ON val.id_grupo = con.id_grupo 
      and (val.id = con.id_s and val.nro_linha = con.nro_linha_s )
      and (val.id_planilha_entrada = con.id_e and val.nro_linha_entrada = con.nro_linha_e)
where ven.id_grupo = 1 and ven.cod_emp = '1004' and ven.local = '0009'
order by ven.cod_emp,ven.local,ven.dt_ref,ven.nro_doc
go
--0010
select 
   ven.*
         ,case
            when ven.id_operacao = 'S' then 'SAIDA 5405'
            else                            'OUTRAS SAIDAS'
         end as Operacao
        ,'<== ==>' as ENTRADA_SAIDA
        ,con.qtd_e as QTD_USADA
        ,case
            when ent.id_operacao = 'E' then 'ENTRADAS'
            when ent.id_operacao = 'e' then 'entrada'
            when ent.id_operacao = 'X' then 'SALDO'
            when ent.id_operacao = 'x' then 'saldo'
            else                            'NAO DEFINIDO'
         end as Operacao
        ,ent.*
        ,case
            when ent.id_operacao in('E','e') then ent.saldo
            when ent.id_operacao in('X','x') then ent.saldo_inicial
         end as saldo
        ,val.*
from controle_e con
    INNER JOIN 
    nfe_det_trade ven 
    ON  ven.id_grupo = 1 and ven.id_planilha = con.id_s AND ven.nro_linha = con.nro_linha_s
    INNER JOIN 
    nfe_det_trade ent 
    ON  ent.id_grupo = 1 and ent.id_planilha = con.id_e  AND ent.nro_linha = con.nro_linha_e
    INNER JOIN  nfe_det_trade_val val
    ON val.id_grupo = con.id_grupo 
      and (val.id = con.id_s and val.nro_linha = con.nro_linha_s )
      and (val.id_planilha_entrada = con.id_e and val.nro_linha_entrada = con.nro_linha_e)
where ven.id_grupo = 1 and ven.cod_emp = '1004' and ven.local = '0010'
order by ven.cod_emp,ven.local,ven.dt_ref,ven.nro_doc
