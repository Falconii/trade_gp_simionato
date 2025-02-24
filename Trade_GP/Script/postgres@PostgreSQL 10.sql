TRUNCATE TABLE nfe_cab_trade RESTART IDENTITY;
go
TRUNCATE TABLE nfe_det_trade; 
go
TRUNCATE TABLE controle_e; 
go

SELECT * FROM nfe_det_trade where (id_planilha = 22 and nro_linha = 10128) or 
                                  (id_planilha = 17 and nro_linha = 806)   or
                                  (id_planilha = 13 and nro_linha = 414) 

select * from controle_e where qtd_d > 0
select * from controle_e where (id_e = 13 and nro_linha_e = 414)


SELECT * FROM nfe_det_trade where ( nro_doc = '8630836047' OR NRO_DOC = '8631263372') ORDER BY NRO_DOC,nro_item