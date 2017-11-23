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

select h.CRM_ID
	,ownr_ptpt_cd
	,sr_area_ssn
from tp.herd_dtl as d
join tp.herd as h on h.map_ref = d.map_ref and h.herd_num = d.herd_num
where
	--h.crm_id = '5000278'
	ownr_ptpt_cd = ' BNP'
fetch first 100 rows only