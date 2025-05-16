CREATE OR REPLACE FUNCTION public.bonixvenda_nota(_id_grupo integer, _cod_emp text, _local text, _dia_mes_ano text, _id_fechamento integer, OUT _saida integer)
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
        
        __metodo_qtd     text;
        
        __metodo_pesquisa text;
        
        BEGIN

          _saida := 0;
          
          __saldo_f := 0;
          
          __metodo_qtd := '';
          
          __metodo_pesquisa := 'N';

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
                    det.saldo
              FROM   nfe_det_trade DET
              WHERE  DET.id_grupo = _id_grupo and DET.cod_emp = _cod_emp and DET.local = _local  and det.id_operacao = 'B' and to_char(det.dt_ref,'DD/MM/YYYY') = _dia_mes_ano and det.status = '0' and det.saldo > 0
              ORDER BY det.id_grupo,det.cod_emp,det.local,DET.dt_ref , DET.id_operacao desc ,DET.nro_doc,DET.nro_item 

              LOOP      
              
                    //RAISE NOTICE 'id_grupo: %, id_planilha: %, nro_linha: %, id_operacao: %, cnpj_cpf: %, dt_ref: %, cfop: %, nro_doc: %, nro_item: %, material: %, quantidade_1: %', 
                    //tempo.id_grupo, tempo.id_planilha, tempo.nro_linha, tempo.id_operacao, tempo.cnpj_cpf, tempo.dt_ref, tempo.cfop, tempo.nro_doc, tempo.nro_item, tempo.material, tempo.quantidade_1;

                    //Dentro da nota
                    select coalesce(nota.id_planilha,0),
                           coalesce(nota.nro_linha,0),
                           coalesce(nota.saldo,0) 
                    into   __id_planilha_v,__nro_linha_v,__qtd_venda
                    from   nfe_det_trade bon
                    inner join clientes cli on cli.cod_empresa = bon.cod_emp and cli.local = bon.local
                    inner join nfe_det_trade nota on 
                              nota.id_grupo = bon.id_grupo and bon.cod_emp = nota.cod_emp and bon.local = nota.local 
                              and  nota.id_operacao = 'V' and nota.dt_ref = bon.dt_ref and bon.material = nota.material 
                              and  nota.nro_doc = bon.nro_doc  and nota.ipi_vlr > 0
                    where  bon.id_grupo = _id_grupo and bon.id_planilha  = tempo.id_planilha and bon.nro_linha = tempo.nro_linha and left(cli.cnpj_cpf,8) <> left(nota.cnpj_cpf,8) limit 1;

                    if (__qtd_venda > 0) then
                                        
                      __total_operacao := tempo.saldo + __qtd_venda;
                      
                      __perc_bon  := round((tempo.saldo / __total_operacao) * 100,2);
                      
                      if (__perc_bon <= 40) then
                      
                          __qtd_usada :=  tempo.saldo;
                          
                          __metodo_qtd := 'D';
                          
                      else 
                      
                          __qtd_usada :=  round((__qtd_venda * 40)/60,0);
                          
                          __metodo_qtd := 'F';
                      
                      end if;
                    
                      __saldo_f := tempo.quantidade_1 - __qtd_usada;
                    
                      RAISE NOTICE 'Venda % Bonif. % Perc.  % Qtd Aproveitada %' , __qtd_venda, tempo.saldo, __perc_bon, __qtd_usada;
                               
                      INSERT INTO controle_e(id_grupo,id_fechamento,id_s, nro_linha_s, id_e, nro_linha_e, qtd_s, qtd_e,metodo_qtd,metodo_pesquisa) 
                      VALUES(_id_grupo,_id_fechamento,tempo.id_planilha,tempo.nro_linha, __id_planilha_v, __nro_linha_v, 0, __qtd_usada,__metodo_qtd,__metodo_pesquisa);
                      
                      if (__saldo_f = 0) then
                           update nfe_det_trade set saldo = __saldo_f , status = '1'
                           where id_grupo = tempo.id_grupo and id_planilha = tempo.id_planilha and nro_linha = tempo.nro_linha;
                      else 
                           update nfe_det_trade set saldo = __saldo_f 
                           where id_grupo = tempo.id_grupo and id_planilha = tempo.id_planilha and nro_linha = tempo.nro_linha;
                      end if;
    
                      _saida := _saida + 1;

                    
                    end if ;
                     
                  
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
    saldo           numeric(15,4)
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

CREATE OR REPLACE FUNCTION public.bonixvenda_periodo(_id_grupo integer, _cod_emp text, _local text, _dia_mes_ano text, _id_fechamento integer, OUT _saida integer)
 RETURNS integer
 LANGUAGE plpgsql
AS $function$ DECLARE

        tempo    Boni_Ven%ROWTYPE;
        
        __id_planilha_v int4;
        
        __nro_linha_v   int4;
        
        __saldo_f       numeric(15,4);
        
        __cnpj_local    text;
        
        
        BEGIN

           select left(cnpj_cpf,8) from clientes  into __cnpj_local where id_grupo = _id_grupo and cod_empresa = _cod_emp and local = _local;

          _saida := 0;
          
          __saldo_f := 0;
          
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
                    det.saldo       
              FROM   nfe_det_trade DET
              WHERE  DET.id_grupo = _id_grupo and DET.cod_emp = _cod_emp and DET.local = _local  and det.id_operacao = 'B' and to_char(det.dt_ref,'DD/MM/YYYY') = _dia_mes_ano 
                     and det.status = '0'  
                     and  radical_cnpj <> __cnpj_local and det.saldo > 0 
              ORDER BY det.id_grupo,det.cod_emp,det.local,DET.dt_ref , DET.id_operacao ,DET.nro_doc,DET.nro_item 

              LOOP      
              
                    //RAISE NOTICE 'id_grupo: %, id_planilha: %, nro_linha: %,_cod_emp %,_local %,tempo.material %,tempo.dt_ref %,tempo.saldo %,_id_fechamento %, Prazo %', 
                    
                    //tempo.id_grupo, tempo.id_planilha, tempo.nro_linha, _cod_emp,_local,tempo.material,tempo.dt_ref,tempo.saldo,_id_fechamento,30;
                     
                    select _saldo_f from seek_vend_boni(_id_grupo,tempo.id_planilha,tempo.nro_linha,_cod_emp,_local,tempo.material,tempo.dt_ref,tempo.saldo,_id_fechamento,30,tempo.cnpj_cpf) into __saldo_f ; 
                    
                    update nfe_det_trade set saldo = __saldo_f , status = '1' where id_grupo = tempo.id_grupo and id_planilha = tempo.id_planilha and nro_linha = tempo.nro_linha;
                    
                    _saida := _saida + 1;
                  
              END LOOP;
              
              

        END;
        $function$
;

go



CREATE OR REPLACE FUNCTION public.seek_vend_boni(_id_grupo integer, _id_s integer, _nro_linha_s integer, _cod_empresa text, _local text, _material text, _data date, _saldo_s numeric, _id_fechamento integer, _validade integer, _cnpj text , OUT _saldo_f numeric)
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


        BEGIN
         
            _saldo_f := _saldo_s;
            _qtd     := 0;
            _last      := _data - (_validade * interval '1 day');
            
            __metodo_qtd := '';
          
            __metodo_pesquisa := 'P';
            
            __dias := 0;
            
            FOR vendas in  
            SELECT det.id_grupo, det.id_planilha , det.nro_linha, det.dt_ref, det.saldo, det.radical_cnpj
               FROM NFE_DET_TRADE DET
               WHERE  DET.id_grupo = _id_grupo and DET.cod_emp = _cod_empresa and DET.local = _local and det.cnpj_cpf = _cnpj
                      and DET.material = _material and 
                      ((DET.id_operacao = 'V'  AND DET.status = '0') ) 
                      and ( DET.dt_ref >= _LAST AND DET.dt_ref <= _data) and det.ipi_vlr > 0 
               ORDER BY DET.cod_emp,DET.local,DET.material,DET.dt_ref,DET.id_operacao 
            LOOP     
            
                    RAISE NOTICE 'id_grupo: %, id_planilha: %, nro_linha: %, saldo : % data %', 
                    vendas.id_grupo, vendas.id_planilha, vendas.nro_linha, vendas.saldo, vendas.dt_ref;
                    
                    __dias :=  _data - vendas.dt_ref ;
                    
                    __qtd_venda := vendas.saldo;
                                        
                    __total_operacao := _saldo_f + __qtd_venda;
                      
                    __perc_bon  := round((_saldo_f / __total_operacao) * 100,2);
                    
                    __perc_ven  := round((vendas.saldo / __total_operacao) * 100,2);
                      
                    if (__perc_bon <= 40) then
                      
                        __qtd_usada :=  _saldo_f;
                          
                        __metodo_qtd := 'D';
                          
                    else 
                      
                        __qtd_usada :=  round((__qtd_venda * 40)/60,0);
                          
                        __metodo_qtd := 'F';
                      
                    end if;
                    
                    RAISE NOTICE 'vendas.saldo % __qtd_usada %' , vendas.saldo , __qtd_usada ; 

                    IF (vendas.saldo >= __qtd_usada) then
                    
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
              
                      INSERT INTO controle_e(id_grupo,id_fechamento,id_s, nro_linha_s, id_e, nro_linha_e, qtd_s, qtd_e,metodo_qtd,metodo_pesquisa,perc_boni,perc_ven,dias) VALUES
                                            (_id_grupo,_id_fechamento,_id_s, _nro_linha_s,vendas.id_planilha , vendas.nro_linha, _saldo_f, _qtd,__metodo_qtd,__metodo_pesquisa,__perc_bon,__perc_ven,__dias);
                    end if;
                    
                    IF (_saldo_f = 0) THEN
    
                       return;
    
                    END IF;
                    
            END LOOP;

        END;
        $function$
;

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



