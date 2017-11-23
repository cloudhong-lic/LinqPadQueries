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

select r.et_rcpnt_anml_key as dam_anml_key
	, b.ssn
	, 'ES' as dam_decision_cd
	, b.contract_decision_cd
	, b.calf_sts_cd
from tp.bull_acq_approach_rcpnt r
	join tp.bull_acq_approach b on b.dam_anml_key = r.dam_anml_key
		and b.ssn = r.ssn
		and b.num = r.num
where 
	r.et_rcpnt_anml_key in (26548829, 20265966, 21892577)
	and b.dam_decision_cd in ('CS', 'SR', 'ES')
	and b.ssn in (2013,2014)
	and (b.contract_decision_cd ='Y' or b.contract_decision_cd is null)
	--and {1}
group by r.et_rcpnt_anml_key, b.ssn, b.contract_decision_cd, b.calf_sts_cd