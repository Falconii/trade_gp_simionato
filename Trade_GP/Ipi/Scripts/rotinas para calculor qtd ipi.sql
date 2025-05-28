/*
  status do det na bonificação
  0 -> Não processado
  1 -> Processando Normalmente
  2 -> Processado Intercompany
  3 -> Não Processado  "Não é bebida"
  4 -> Não Processando "Bonificação Própria"
*/

CREATE OR REPLACE FUNCTION public.bonixvenda_nota(_id_grupo integer, _cod_emp text, _local text, _dia_mes_ano text, _id_fechamento integer, _ano_selic int4, _mes_selic int4,OUT _saida integer)
 RETURNS integer
 LANGUAGE plpgsql
AS $function$ DECLARE

        tempo    Boni_Ven%ROWTYPE;
        
        __id_planilha_v int4;
        
        __nro_linha_v   int4;
        
        __saldo_f       numeric(15,4);
        
        __qtd_venda     numeric(15,4);

        __qtd_usada     numeric(15,4);
        
        __total_operacao numeric(15,4);
       
        __perc_bon       numeric(15,4);
        
        __perc_ven       numeric(15,4);
        
        __metodo_qtd     text;
        
        __metodo_pesquisa text;
        
        __dias Int4;

        __ipi_unit      numeric(15,4);
            
        __ipi_economico numeric(15,4);

        __ipi_economico_corrigido numeric(15,4);

        __taxa  numeric(6,2);
 
        __total_intercompany int4;
        
        __cnpj_empresa text;
        
        __status text;
        
         data_inicial Date;
        
        BEGIN

          _saida := 0;
          
          __saldo_f := 0;
          
          __metodo_qtd := '';
          
          __metodo_pesquisa := 'N';

          __dias := 0;

          __total_intercompany := 0;

          __ipi_unit := 0;
            
          __ipi_economico := 0;

          __ipi_economico_corrigido := 0;
          
          __status := '1';

          SELECT get_selic FROM into __taxa get_selic( cast(SUBSTRING(_dia_mes_ano,7,4) AS INT4), cast(SUBSTRING(_dia_mes_ano,4,2) AS INT4) ,2025,03) ;
                             
          FOR tempo in  
     
            SELECT  det.id_grupo     ,
                    det.id_planilha  ,
                    det.nro_linha    ,
                    det.id_operacao  ,
                    det.cnpj_cpf     ,
                    det.dt_ref       ,
                    det.cfop         ,
                    det.nro_doc      ,
                    det.nro_item     ,
                    det.material     ,
                    det.quantidade_1 ,
                    det.saldo        ,
                    det.radical_cnpj ,
                    det.ipi_vlr      ,
                    det.status       ,
                    det.bebida
              FROM   nfe_det_trade DET
              WHERE  DET.id_grupo = _id_grupo and DET.cod_emp = _cod_emp and DET.local = _local  and det.id_operacao = 'B' and to_char(det.dt_ref,'DD/MM/YYYY') = _dia_mes_ano and det.status = '0' and det.saldo > 0
              ORDER BY det.id_grupo,det.cod_emp,det.local,DET.dt_ref ,DET.nro_doc,DET.nro_item 

              LOOP      
                     __saldo_f   := tempo.saldo; 
                     __qtd_venda := 0;
                     __ipi_unit  := tempo.ipi_vlr / tempo.quantidade_1;
                     
                     RAISE NOTICE 'Tempo.bebida % ', tempo.bebida;

                    // Propria nota
                    select cli.cnpj_cpf from clientes cli into __cnpj_empresa where cli.id_grupo = _id_grupo and cli.cod_empresa = _cod_emp and cli.local = _local;
                    
                    if (__cnpj_empresa = tempo.cnpj_cpf) then 
                          RAISE NOTICE 'Saiu Bonificação Propria ';
                          update nfe_det_trade set status = '4'
                           where id_grupo = tempo.id_grupo and id_planilha = tempo.id_planilha and nro_linha = tempo.nro_linha;
                         continue;
                    end if;
                    if (  tempo.bebida = 'N') then 
                          RAISE NOTICE 'Saiu Por Não Ser Bebida ';
                          update nfe_det_trade set status = '3'
                           where id_grupo = tempo.id_grupo and id_planilha = tempo.id_planilha and nro_linha = tempo.nro_linha;
                         continue;
                    end if ;

                    // rejeita intercompany
                    select coalesce(count(*),0) from clientes cli into __total_intercompany where cli.id_grupo = _id_grupo and left(cli.cnpj_cpf,8) = tempo.radical_cnpj ;
                  
                    if (__total_intercompany = 0) then
                         __status :=  '1';
                    else 
                          __status :=  '1';
                    end if;
                    
                   //Dentro da nota
                    select coalesce(nota.id_planilha,0),
                           coalesce(nota.nro_linha,0),
                           coalesce(nota.saldo,0) 
                    into   __id_planilha_v,__nro_linha_v,__qtd_venda
                    from   nfe_det_trade bon
                    inner join clientes cli on cli.cod_empresa = bon.cod_emp and cli.local = bon.local
                    inner join nfe_det_trade nota on 
                              nota.id_grupo = bon.id_grupo and bon.cod_emp = nota.cod_emp and bon.local = nota.local 
                              and  nota.id_operacao = 'V' and nota.status = '0'  and nota.dt_ref = bon.dt_ref and bon.material = nota.material and  nota.saldo > 0 
                              and  nota.nro_doc = bon.nro_doc  and nota.ipi_vlr > 0
                    where  bon.id_grupo = _id_grupo and bon.id_planilha  = tempo.id_planilha and bon.nro_linha = tempo.nro_linha limit 1;

                    RAISE NOTICE '__id_planilha_v % __nro_linha_v % Venda % ' , __id_planilha_v , __nro_linha_v , __qtd_venda;
                               
                    if (__qtd_venda is not null) then
            
                        __dias :=  0 ;
                                                        
                        __total_operacao := tempo.saldo + __qtd_venda;
                  
                        __perc_bon  := trunc((tempo.saldo / __total_operacao) * 100);
                
                        __perc_ven  := trunc((__qtd_venda / __total_operacao) * 100);
                  
                        if (__perc_bon <= 40) then
                  
                            __qtd_usada :=  tempo.saldo;
                      
                            __metodo_qtd := 'D';
                      
                        else 
                  
                            __qtd_usada :=  trunc((__qtd_venda * 40)/60);
                      
                            __metodo_qtd := 'F';
                  
                        end if;
           
                        if ( __qtd_usada > 0 ) then
                               __saldo_f               := tempo.saldo - __qtd_usada;
        
                               __ipi_economico         := __qtd_usada * __ipi_unit;
        
                               __ipi_economico_corrigido := __ipi_economico * ( (__taxa / 100) + 1);
                        
                               RAISE NOTICE 'Gravando -- Venda % Bonif. % Perc.  % Qtd Aproveitada %' , __qtd_venda, tempo.saldo, __perc_bon, __qtd_usada;
                                   
                               INSERT INTO controle_e(id_grupo,id_fechamento,id_s, nro_linha_s, id_e, nro_linha_e, qtd_s, qtd_e,metodo_qtd,metodo_pesquisa,perc_boni,perc_ven,dias) 
                               VALUES(_id_grupo,_id_fechamento,tempo.id_planilha,tempo.nro_linha, __id_planilha_v, __nro_linha_v,__saldo_f, __qtd_usada,__metodo_qtd,__metodo_pesquisa,__perc_bon,__perc_ven,__dias);
                                
                               INSERT INTO nfe_det_trade_val_ipi(id_grupo,id,nro_linha,id_planilha_entrada,nro_linha_entrada,dtnfe,dtcredito,vlr_economico_ipi,dtfcorrecao,vlr_economico_ipi_corrigido,taxa,ipi_unit,qtd_calculada,usuarioinclusao,usuarioatualizacao) VALUES
                                                                 (_id_grupo,tempo.id_planilha,tempo.nro_linha, __id_planilha_v, __nro_linha_v,tempo.dt_ref,'2025-05-22',__ipi_economico,'2025-05-22',__ipi_economico_corrigido,__taxa,__ipi_unit,__qtd_usada,16,0);
                        end if;
                        
                        if (__saldo_f = 0) then
                               update nfe_det_trade set saldo = __saldo_f , status = __status
                               where id_grupo = tempo.id_grupo and id_planilha = tempo.id_planilha and nro_linha = tempo.nro_linha;
                        else 
                               update nfe_det_trade set saldo = __saldo_f , status = '0'
                               where id_grupo = tempo.id_grupo and id_planilha = tempo.id_planilha and nro_linha = tempo.nro_linha;
                        end if;

                end if;

                _saida := _saida + 1;
 
                  
              END LOOP;

        END;
        $function$
;
go
DROP TYPE IF EXISTS Boni_Ven;
CREATE TYPE Boni_Ven AS 
(
    id_grupo     	int4,
    id_planilha  	int4,
    nro_linha    	int4,
    id_operacao  	text,
    cnpj_cpf        text,
    dt_ref       	date,
    cfop        	text,
    nro_doc      	text,
    nro_item     	text,
    material     	text,
    quantidade_1 	numeric(15,4),
    saldo           numeric(15,4),
    radical_cnpj    text ,
    ipi_vlr         numeric(15,2),
    status          text,
    bebida          text
);
go


/*


select  bon.cnpj_cpf
       ,bon.local
       ,bon.cnpj_cpf
       ,bon.nro_doc
       ,bon.cfop
       ,bon.material
       ,bon.denom
       ,bon.quantidade_1
       ,bon.saldo
       ,con.qtd_e as qtd_usada
       ,case
           when con.metodo_qtd = 'D' then 'DIRETO'
           else                           'FORMULA'
        end as calculo_qtd   
       ,case
           when con.metodo_pesquisa = 'N' then 'NOTA BONIFICAÇÃO'
           else                                'PERIODO 30 DIAS'
        end as encontrou_venda   
       ,bon.status as status_bon
       ,bon.ipi_vlr
       ,bon.dt_ref
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
where bon.id_grupo = 1 and bon.cod_emp = '1004' and to_char(bon.dt_ref,'DD/MM/YYYY') = '13/12/2018'



*/

//DROP FUNCTION seek_vend_boni(integer,integer,integer,text,text,text,date,numeric,integer,integer,text);
CREATE OR REPLACE FUNCTION public.seek_vend_boni(_id_grupo integer, _id_s integer, _nro_linha_s integer, _cod_empresa text, _local text, _material text, _data date, _saldo_s numeric, _id_fechamento integer, _validade integer, _cnpj_radical text , _ipi_unit  numeric , _ano_selic int4, _mes_selic int4, OUT _saldo_f numeric)
 RETURNS numeric
 LANGUAGE plpgsql
AS $function$
        DECLARE

        vendas  public.Vendas%ROWTYPE;
        _saldo_e numeric(15,4);
        _qtd     numeric(15,4);
        _last    date;
                
        __saldo_f       numeric(15,4);
        
        __qtd_venda     numeric(15,4);
        
        __qtd_usada     numeric(15,4);
        
        __total_operacao numeric(15,4);
        
        __perc_bon       numeric(15,4);
        
        __perc_ven       numeric(15,4);
        
        __metodo_qtd     text;
        
        __metodo_pesquisa text;
        
        __dias Int4;
            
        __ipi_economico numeric(15,4);

        __ipi_economico_corrigido numeric(15,4);

        __taxa  numeric(6,2);
        

        BEGIN
        
            
            _saldo_f           := _saldo_s;

            _qtd               := 0;

            _last              := _data - (_validade * interval '1 day');
            
            __metodo_qtd       := '';
          
            __metodo_pesquisa  := 'P';
            
            __dias := 0;
            
            __ipi_economico := 0;

            __ipi_economico_corrigido := 0;

            __taxa  := 0;

            SELECT get_selic FROM into __taxa get_selic( cast(to_char(_data,'YYYY') AS INT4), cast(to_char(_data,'MM') AS INT4) ,_ano_selic,_mes_selic) ;
            
            RAISE NOTICE 'Ponto A';
             
            FOR vendas in  
            SELECT det.id_grupo, det.id_planilha , det.nro_linha, det.dt_ref, det.saldo, det.radical_cnpj
               FROM NFE_DET_TRADE DET
               WHERE  DET.id_grupo = _id_grupo and DET.cod_emp = _cod_empresa and DET.local = _local and det.cnpj_cpf = _cnpj_radical
                      and DET.material = _material and 
                      ((DET.id_operacao = 'V'  AND DET.status = '0') ) 
                      and ( DET.dt_ref >= _LAST AND DET.dt_ref <= _data) and det.ipi_vlr > 0 AND det.saldo > 0
               ORDER BY DET.cod_emp,DET.local,DET.material,DET.dt_ref 
            LOOP     
            
                    RAISE NOTICE 'id_grupo: %, id_planilha: %, nro_linha: %, saldo : % data %', 
                    vendas.id_grupo, vendas.id_planilha, vendas.nro_linha, vendas.saldo, vendas.dt_ref;
                     
                    __dias :=  _data - vendas.dt_ref ;
                    
                    __qtd_venda := vendas.saldo;
                                        
                    __total_operacao := _saldo_f + __qtd_venda;
                      
                    __perc_bon  := trunc((_saldo_f / __total_operacao) * 100);
                    
                    __perc_ven  := trunc((vendas.saldo / __total_operacao) * 100);
                      
                    if (__perc_bon <= 40) then
                      
                        __qtd_usada :=  _saldo_f;
                          
                        __metodo_qtd := 'D';
                          
                    else 
                      
                        __qtd_usada  :=  trunc((__qtd_venda * 40)/60);
                          
                        __metodo_qtd := 'F';
                      
                    end if;
                    
                    IF ((__qtd_usada > 0) and (vendas.saldo >= __qtd_usada) ) then
                    
                        _saldo_e := __qtd_usada;
                       
                       IF (_saldo_s >= _saldo_e) THEN
    
                           _qtd     := _saldo_e;
    
                           _saldo_s := _saldo_s - _saldo_e;
    
                           _saldo_e :=  0;
    
                       ELSE 
    
                          _qtd      := _saldo_s;
    
                          _saldo_e  := _saldo_e - _saldo_s;
    
                          _saldo_s  := 0; 
    
                       END IF;
    
                       _saldo_f := _saldo_s;
                       
                       __ipi_economico         := _qtd * _ipi_unit;
        
                       __ipi_economico_corrigido := __ipi_economico * ( (__taxa / 100) + 1);
              
                       INSERT INTO controle_e(id_grupo,id_fechamento,id_s, nro_linha_s, id_e, nro_linha_e, qtd_s, qtd_e,metodo_qtd,metodo_pesquisa,perc_boni,perc_ven,dias) VALUES
                                             (_id_grupo,_id_fechamento,_id_s,_nro_linha_s,vendas.id_planilha , vendas.nro_linha, _saldo_f, _qtd,__metodo_qtd,__metodo_pesquisa,__perc_bon,__perc_ven,__dias);
                                             
                                         
                                                    
                       INSERT INTO nfe_det_trade_val_ipi(id_grupo,id,nro_linha,id_planilha_entrada,nro_linha_entrada,dtnfe,dtcredito,vlr_economico_ipi,dtfcorrecao,vlr_economico_ipi_corrigido,taxa,ipi_unit,qtd_calculada,usuarioinclusao,usuarioatualizacao) VALUES
                                              (_id_grupo,_id_s,_nro_linha_s,vendas.id_planilha , vendas.nro_linha,_data,'2025-01-01',__ipi_economico,'2025-01-01',__ipi_economico_corrigido,__taxa,_ipi_unit,_qtd,16,0);
                   
                    end if;
                    
                    IF (_saldo_f = 0) THEN
    
                       return;
    
                    END IF;
                    
            END LOOP;

        END;
        $function$
;
go


CREATE OR REPLACE FUNCTION public.bonixvenda_periodo(_id_grupo integer, _cod_emp text, _local text, _dia_mes_ano text, _id_fechamento integer, _ano_selic int4, _mes_selic int4, OUT _saida integer)
 RETURNS integer
 LANGUAGE plpgsql
AS $function$ DECLARE

        tempo    Boni_Ven%ROWTYPE;
        
        __id_planilha_v int4;
        
        __nro_linha_v   int4;
        
        __saldo_f       numeric(15,4);
        
        __cnpj_empresa text;
        
        __total_intercompany    int4;
                
        __status text;
        
        __ipi_unit  numeric(15,4);
                
         data_inicial Date;
        
        
        BEGIN

          _saida := 0;
          
          __saldo_f := 0;
          
          data_inicial := Date '2012-07-25';
          
          FOR tempo in  
     
            SELECT  det.id_grupo     ,
                    det.id_planilha  ,
                    det.nro_linha    ,
                    det.id_operacao  ,
                    det.cnpj_cpf     ,
                    det.dt_ref       ,
                    det.cfop         ,
                    det.nro_doc      ,
                    det.nro_item     ,
                    det.material     ,
                    det.quantidade_1 ,
                    det.saldo        ,
                    det.radical_cnpj ,
                    det.ipi_vlr      ,
                    det.status       ,
                    det.bebida
              FROM   nfe_det_trade DET
              WHERE  DET.id_grupo = _id_grupo and DET.cod_emp = _cod_emp and DET.local = _local  and det.id_operacao = 'B' and ( DET.dt_ref >= data_inicial ) and to_char(det.dt_ref,'DD/MM/YYYY') = _dia_mes_ano 
                     and det.status = '0'  
                     and det.saldo > 0 
              ORDER BY det.id_grupo,det.cod_emp,det.local,DET.dt_ref , DET.id_operacao ,DET.nro_doc,DET.nro_item 

              LOOP      
              
                  // Propria nota
                  select cli.cnpj_cpf from clientes cli into __cnpj_empresa where cli.id_grupo = _id_grupo and cli.cod_empresa = _cod_emp and cli.local = _local;
                    
                  if (  __cnpj_empresa = tempo.cnpj_cpf) then 
                          RAISE NOTICE 'Saiu Bonificação Propria ';
                          update nfe_det_trade set status = '4'
                           where id_grupo = tempo.id_grupo and id_planilha = tempo.id_planilha and nro_linha = tempo.nro_linha;
                         continue;
                  end if ;
                  if (  tempo.bebida = 'N' ) then 
                          RAISE NOTICE 'Saiu Por Não Ser Bebida ';
                          update nfe_det_trade set status = '3'
                           where id_grupo = tempo.id_grupo and id_planilha = tempo.id_planilha and nro_linha = tempo.nro_linha;
                         continue;
                  end if ;
         
                   // verifica intercompany
                   select coalesce(count(*),0) from clientes cli into __total_intercompany where cli.id_grupo = _id_grupo and left(cli.cnpj_cpf,8) = tempo.radical_cnpj ;

                    if (__total_intercompany = 0) then
                        __status := '1';
                    else 
                        __status := '2'; //Intercompany
                    end if;

                    __ipi_unit := round((tempo.ipi_vlr/tempo.quantidade_1),4);
                    
                    RAISE NOTICE 'id_grupo: %, id_planilha: %, nro_linha: %,_cod_emp %,_local %,tempo.material %,tempo.dt_ref %,tempo.saldo %,_id_fechamento %, Prazo % __status % tempo.radical_cnpj % __total_intercompany % bebida % __ipi_unit %', 
            
                    tempo.id_grupo, tempo.id_planilha, tempo.nro_linha, _cod_emp,_local,tempo.material,tempo.dt_ref,tempo.saldo,_id_fechamento,30,__status,tempo.radical_cnpj,__total_intercompany, tempo.bebida, __ipi_unit;
                          
                     RAISE NOTICE '***_id_grupo % tempo.id_planilha % tempo.nro_linha % _cod_emp % _local % tempo.material % tempo.dt_ref % tempo.saldo % _id_fechamento % Prazo % tempo.cnpj_cpf % __ipi_unit %', 
                                      _id_grupo , tempo.id_planilha,tempo.nro_linha,_cod_emp,_local,tempo.material,tempo.dt_ref,tempo.saldo,_id_fechamento,30,tempo.cnpj_cpf,__ipi_unit;
                  
                     select _saldo_f from seek_vend_boni(_id_grupo,tempo.id_planilha,tempo.nro_linha,_cod_emp,_local,tempo.material,tempo.dt_ref,tempo.saldo,_id_fechamento,30,tempo.cnpj_cpf,__ipi_unit,_ano_selic,_mes_selic) into __saldo_f ; 
            
                     update nfe_det_trade set saldo = __saldo_f , status = __status where id_grupo = tempo.id_grupo and id_planilha = tempo.id_planilha and nro_linha = tempo.nro_linha;
                   
                    _saida := _saida + 1;
                  
              END LOOP;
              
              

        END;
        $function$
;

go



DROP TYPE IF EXISTS Vendas;
CREATE TYPE Vendas AS 
(
    id_grupo     	int4,
    id_planilha  	int4,
    nro_linha    	int4,
    dt_ref          date,
    saldo           numeric(15,4),
    radical_cnpj    text
);
go




