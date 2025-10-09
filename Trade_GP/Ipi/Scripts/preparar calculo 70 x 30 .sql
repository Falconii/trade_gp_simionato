alter table nfe_det_trade
add column saldo2  numeric(15,4) default 0,
add column status2 char(1) default '0'   

update nfe_det_trade set saldo2 =  quantidade_1, status2 = 0