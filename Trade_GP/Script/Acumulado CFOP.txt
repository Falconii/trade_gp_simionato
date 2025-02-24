SELECT 
    id_grupo,
    cod_emp, 
    local, 
    to_char(dt_doc,'YYYY') AS ANO,
    to_char(dt_doc,'MM') AS MES,
    left(cfop,4),
    SUM(quantidade_1) AS total_quantidade_1,
    SUM(quantidade_2) AS total_quantidade_2,
    SUM(preco_liq) AS total_preco_liq,
    SUM(liquido) AS total_liquido,
    SUM(valor) AS total_valor,
    SUM(vlr_contb) AS total_vlr_contb,
    SUM(pis_base) AS total_pis_base,
    SUM(pis_vlr) AS total_pis_vlr,
    SUM(cof_base) AS total_cof_base,
    SUM(cof_vlr) AS total_cof_vlr,
    SUM(ipi_base) AS total_ipi_base,
    SUM(ipi_vlr) AS total_ipi_vlr,
    SUM(icms_base) AS total_icms_base,
    SUM(icms_vlr) AS total_icms_vlr,
    SUM(fecp_vlr) AS total_fecp_vlr,
    SUM(icst_base) AS total_icst_base,
    SUM(icst_valor) AS total_icst_valor,
    SUM(fest_valor) AS total_fest_valor,
    SUM(bc_icms_rt) AS total_bc_icms_rt,
    SUM(vlr_icms_str) AS total_vlr_icms_str,
    SUM(vlr_fcps_st_rt) AS total_vlr_fcps_st_rt
FROM 
    nfe_det_trade
where
    COD_EMP = '1002'
GROUP BY 
    id_grupo,cod_emp, local, to_char(dt_doc,'YYYY'),to_char(dt_doc,'MM'),left(cfop,4) 


TRUNCATE TABLE acum_emp_local_cfop_ano_mes;
INSERT INTO public.acum_emp_local_cfop_ano_mes(id_grupo, cod_emp, local, ano, mes, cfop, quantidade_1, quantidade_2, preco_liq, liquido, valor, vlr_contb, pis_base, pis_vlr, cof_base, cof_vlr, ipi_base, ipi_vlr, icms_base, icms_vlr, fecp_vlr, icst_base, icst_valor, fest_valor, bc_icms_rt, vlr_icms_str, vlr_fcps_st_rt) 
	SELECT 
    id_grupo,
    cod_emp, 
    local, 
    to_char(dt_doc,'YYYY') AS ANO,
    to_char(dt_doc,'MM') AS MES,
    left(cfop,4),
    SUM(quantidade_1) AS total_quantidade_1,
    SUM(quantidade_2) AS total_quantidade_2,
    SUM(preco_liq) AS total_preco_liq,
    SUM(liquido) AS total_liquido,
    SUM(valor) AS total_valor,
    SUM(vlr_contb) AS total_vlr_contb,
    SUM(pis_base) AS total_pis_base,
    SUM(pis_vlr) AS total_pis_vlr,
    SUM(cof_base) AS total_cof_base,
    SUM(cof_vlr) AS total_cof_vlr,
    SUM(ipi_base) AS total_ipi_base,
    SUM(ipi_vlr) AS total_ipi_vlr,
    SUM(icms_base) AS total_icms_base,
    SUM(icms_vlr) AS total_icms_vlr,
    SUM(fecp_vlr) AS total_fecp_vlr,
    SUM(icst_base) AS total_icst_base,
    SUM(icst_valor) AS total_icst_valor,
    SUM(fest_valor) AS total_fest_valor,
    SUM(bc_icms_rt) AS total_bc_icms_rt,
    SUM(vlr_icms_str) AS total_vlr_icms_str,
    SUM(vlr_fcps_st_rt) AS total_vlr_fcps_st_rt
FROM 
    nfe_det_trade
GROUP BY 
    id_grupo,cod_emp, local, to_char(dt_doc,'YYYY'),to_char(dt_doc,'MM'),left(cfop,4) 
GO

select * from acum_emp_local_cfop_ano_mes


CREATE INDEX indice_cfop
	ON public.nfe_det_trade USING btree (id_grupo int4_ops, cod_emp text_ops, local text_ops, id_operacao bpchar_ops, dt_doc date_ops, cfop bpchar_ops)
GO

