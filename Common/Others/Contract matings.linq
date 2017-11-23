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

select b1.dam_anml_key, b1.ssn, b1.dam_decision_cd, b1.contract_decision_cd, b1.calf_sts_cd
from tp.bull_acq_approach b1
where b1.ssn = 2013
AND b1.dam_decision_cd in ('CS', 'SR', 'ES')
AND (b1.contract_decision_cd ='Y' or b1.contract_decision_cd is null)
AND (b1.calf_sts_cd is null or b1.calf_sts_cd in ('BU', 'HF'))
fetch first 20 rows only