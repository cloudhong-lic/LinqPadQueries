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

select h.crm_id, sts.T2_PCT, sts.T2_PCT_DATE
from tp.HERD_ERR_STS as sts
join tp.herd as h on h.map_ref = sts.map_ref and h.herd_num = sts.herd_num
where 
	h.map_ref = 'N004530134' and h.herd_num = 2
	--crm_id = 5011459
fetch first 10 rows only