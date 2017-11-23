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

with interested_animals(anml_key) as (values 32891831,32891832,30255540)

select a.anml_key as CalfAnimalKey
	, a.dam_anml_key as DamAnimalKey
	, a.rcpnt_anml_key as RecipientAnimalKey
	, a.brth_date_d as BirthDate
	, b.ssn as Season
	, b.dam_decision_cd as ContractTypeValue
from interested_animals i
	join tp.animal a on (i.anml_key = a.anml_key)
	join tp.bull_acq_approach b on b.dam_anml_key = a.dam_anml_key and b.ssn = year(a.brth_date_d - 271 days)
where 
	a.rcpnt_anml_key = 0
	and b.contract_decision_cd = 'Y'
	and b.dam_decision_cd in ('CS', 'SR')
	and b.calf_sts_cd in ('BU', 'HF')

union

select a.anml_key as CalfAnimalKey
	, a.dam_anml_key as DamAnimalKey
	, a.rcpnt_anml_key as RecipientAnimalKey
	, a.brth_date_d as BirthDate
	, b.ssn as Season
	, 'ES' ContractTypeValue
from interested_animals i
	join tp.animal a on (i.anml_key = a.anml_key)
	join tp.bull_acq_approach b on a.dam_anml_key = b.dam_anml_key and b.ssn = year(a.brth_date_d - 271 days)
	join tp.bull_acq_approach_rcpnt br on b.dam_anml_key = br.dam_anml_key and b.ssn = br.ssn and b.num = br.num and br.et_rcpnt_anml_key = a.rcpnt_anml_key
where a.rcpnt_anml_key <> 0
	and b.contract_decision_cd = 'Y'
	and b.dam_decision_cd in ('CS', 'SR', 'ES')
	and br.calf_sts_cd in ('BU', 'HF')