/* Script Para Voltar O Banco Para Processar Estoque */
ALTER TABLE public.controle_e DISABLE TRIGGER ALL;
go
TRUNCATE controle_e  RESTART IDENTITY;
go
TRUNCATE public.nfe_det_trade_val  RESTART IDENTITY;
go
update nfe_det_trade set saldo = qtd_convertida, status = 0, qtd_dev = 0, etapa = 0 
where  id_grupo = 1 and cod_emp = '1004' and local = '0001' and (id_operacao = 'S' or id_operacao = 'E' or id_operacao = 'Z');
go
update nfe_det_trade set saldo = qtd_convertida, status = 0, qtd_dev = 0, etapa = 0 
where  id_grupo = 1 and cod_emp = '1004' and local = '0002' and (id_operacao = 'S' or id_operacao = 'E' or id_operacao = 'Z');
go
update nfe_det_trade set saldo = qtd_convertida, status = 0, qtd_dev = 0, etapa = 0 
where  id_grupo = 1 and cod_emp = '1004' and local = '0003' and (id_operacao = 'S' or id_operacao = 'E' or id_operacao = 'Z');
go
update nfe_det_trade set saldo = qtd_convertida, status = 0, qtd_dev = 0, etapa = 0 
where  id_grupo = 1 and cod_emp = '1004' and local = '0004' and (id_operacao = 'S' or id_operacao = 'E' or id_operacao = 'Z');
go
update nfe_det_trade set saldo = qtd_convertida, status = 0, qtd_dev = 0, etapa = 0 
where  id_grupo = 1 and cod_emp = '1004' and local = '0005' and (id_operacao = 'S' or id_operacao = 'E' or id_operacao = 'Z');
go

update nfe_det_trade set saldo = qtd_convertida, status = 0, qtd_dev = 0, etapa = 0 
where  id_grupo = 1 and cod_emp = '1004' and local = '0006' and (id_operacao = 'S' or id_operacao = 'E' or id_operacao = 'Z');
go
update nfe_det_trade set saldo = qtd_convertida, status = 0, qtd_dev = 0, etapa = 0 
where  id_grupo = 1 and cod_emp = '1004' and local = '0007' and (id_operacao = 'S' or id_operacao = 'E' or id_operacao = 'Z');
go
update nfe_det_trade set saldo = qtd_convertida, status = 0, qtd_dev = 0, etapa = 0 
where  id_grupo = 1 and cod_emp = '1004' and local = '0008' and (id_operacao = 'S' or id_operacao = 'E' or id_operacao = 'Z');
go
update nfe_det_trade set saldo = qtd_convertida, status = 0, qtd_dev = 0, etapa = 0 
where  id_grupo = 1 and cod_emp = '1004' and local = '0009' and (id_operacao = 'S' or id_operacao = 'E' or id_operacao = 'Z');
go
update nfe_det_trade set saldo = qtd_convertida, status = 0, qtd_dev = 0, etapa = 0 
where  id_grupo = 1 and cod_emp = '1004' and local = '0010' and (id_operacao = 'S' or id_operacao = 'E' or id_operacao = 'Z');
go
ALTER TABLE public.controle_e ENABLE  TRIGGER ALL;
go
