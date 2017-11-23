<Query Kind="SQL">
  <Connection>
    <ID>f01ef15f-1531-4bd3-9f09-686488ce8d71</ID>
    <Persist>true</Persist>
    <Driver>EntityFrameworkDbContext</Driver>
    <CustomAssemblyPath>C:\LIC\dev\Db2Harness\LIC.Db2Harness\bin\Debug\LIC.Db2Harness.dll</CustomAssemblyPath>
    <CustomTypeName>LIC.Db2Harness.AccpDb2Context</CustomTypeName>
    <AppConfigPath>C:\LIC\dev\Db2Harness\LIC.Db2Harness\bin\Debug\App.config</AppConfigPath>
    <DisplayName>DB2 Accp</DisplayName>
  </Connection>
</Query>

with contract_calves as (

select a.anml_key, a.dam_anml_key, a.rcpnt_anml_key,
a.brth_date_d, b.ssn, b.dam_decision_cd, b.contract_decision_cd, b.calf_sts_cd,
ROW_NUMBER() OVER (PARTITION BY a.anml_key ORDER BY abs(a.brth_date_d - 282 days - m.date_d)) as rn
from tp.animal a
join tp.mating m on a.dam_anml_key = m.anml_key
join tp.bull_acq_approach b on b.dam_anml_key = a.dam_anml_key and b.ssn = year(m.date_d + 11 days)
where a.anml_key in (32891831,32891832,30255540)
and a.rcpnt_anml_key = 0
and (b.contract_decision_cd is null or b.contract_decision_cd = 'Y')
and b.dam_decision_cd in ('CS', 'SR')
and b.calf_sts_cd in ('BU', 'HF')

union

select a.anml_key, a.dam_anml_key, a.rcpnt_anml_key,
a.brth_date_d, b.ssn, 'ES' as dam_decision_cd, b.contract_decision_cd, br.calf_sts_cd,
ROW_NUMBER() OVER (PARTITION BY a.anml_key ORDER BY abs(a.brth_date_d - 282 days - x.insem_date)) as rn
from tp.animal a
join tp.embryo_xfer x on a.dam_anml_key = x.donor_anml_key
join tp.embryo_rcpnt r on x.doc_num = r.doc_num and a.rcpnt_anml_key = r.anml_key
join tp.bull_acq_approach b on a.dam_anml_key = b.dam_anml_key and b.ssn = year(x.insem_date + 11 days)
join tp.bull_acq_approach_rcpnt br on b.dam_anml_key = br.dam_anml_key and b.ssn = br.ssn and b.num = br.num and br.et_rcpnt_anml_key = a.rcpnt_anml_key
where a.anml_key in (32891831,32891832,30255540)
and a.rcpnt_anml_key <> 0
and (b.contract_decision_cd is null or b.contract_decision_cd = 'Y')
and b.dam_decision_cd in ('CS', 'SR', 'ES')
and br.calf_sts_cd in ('BU', 'HF')

) select * from contract_calves s where s.rn = 1