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