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

select a.anml_key
from tp.herd_anml a
join tp.herd h on (a.map_ref = h.map_ref and a.herd_num = h.herd_num)
where h.crm_id = 5057217
and (a.xfer_out_time is null or a.xfer_out_time >= '2006-06-01') and (h.end_date_d is null or h.end_date_d >= '2006-06-01')
and a.xfer_in_time <= '2016-12-08' and h.st_date_d <= '2016-12-08' 