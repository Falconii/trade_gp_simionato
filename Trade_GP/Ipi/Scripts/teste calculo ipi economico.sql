

 select * from vlr_enconomico_ipi(1, '1001', '0057', '21/01/2021', 2025,3)
 
 
 select * from nfe_det_trade_val_ipi
 
 
 SELECT det.id_grupo,det.cod_emp,det.local,det.dt_ref,COALESCE(COUNT(det.*), 0) AS TOTAL  FROM nfe_det_trade DET WHERE DET.id_grupo = 1 and DET.cod_emp = '1001' and Det.local IN ('0057') and   ((det.id_operacao = 'B')  and (det.status = '1' or det.status = '2') and    TO_CHAR(det.dt_ref, 'MM/YYYY') IN ('01/2021','02/2021','03/2021','04/2021','05/2021','06/2021','07/2021','08/2021','09/2021','10/2021','11/2021','12/2021')  group by det.id_grupo,det.cod_emp,det.local,det.dt_ref  order by det.id_grupo,det.cod_emp,det.local,det.dt_ref
  
  
     SELECT 
                                bon.id_grupo
                               ,bon.cod_emp
                               ,bon.local
                               ,bon.dt_ref
                               ,COALESCE(COUNT(bon.*), 0) AS TOTAL
                       from     controle_e con 
                       inner join nfe_det_trade bon  on bon  .id_grupo = con.id_grupo and bon  .id_planilha = con.id_s and bon   .nro_linha = con.nro_linha_s
                       inner join nfe_det_trade ven on ven.id_grupo = con.id_grupo and ven.id_planilha  = con.id_e and ven.nro_linha = con.nro_linha_e 
                       where con.id_grupo = 1 and con.id_fechamento = 1  and con.qtd_e > 0 and bon.cod_emp = '1001' and bon.LOCAL = '0057'  and  (bon.STATUS = '1' OR bon.STATUS = '2') and  bon.ID_OPERACAO = 'B' and bon.dt_ref >= '2012-07-25' and  TO_CHAR(bon.dt_ref, 'MM/YYYY') IN ('01/2021','02/2021')
                       group by bon.id_grupo
                               ,bon.cod_emp
                               ,bon.local
                               ,bon.dt_ref  
                       order by  bon.id_grupo
                               ,bon.cod_emp
                               ,bon.local
                               ,bon.dt_ref  
      