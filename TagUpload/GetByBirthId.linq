<Query Kind="SQL">
  <Connection>
    <ID>d6f2b19a-ae75-4d4c-a4a4-58aac933ce8e</ID>
    <Persist>true</Persist>
    <Driver>EntityFrameworkDbContext</Driver>
    <CustomAssemblyPath>C:\LIC\dev\Db2Harness\LIC.Db2Harness\bin\Debug\LIC.Db2Harness.dll</CustomAssemblyPath>
    <CustomTypeName>LIC.Db2Harness.Db2Context</CustomTypeName>
    <AppConfigPath>C:\LIC\dev\Db2Harness\LIC.Db2Harness\bin\Debug\App.config</AppConfigPath>
    <DisplayName>DB2 Dev</DisplayName>
  </Connection>
</Query>

select a.anml_key, bi.pfx, bi.yr, bi.num, an.ahb_herd_num, an.yr as ahb_yr, an.num as ahb_num, ei.eid, ei.st_date,ei.end_date, a.brth_date_d
from tp.animal a
left outer join tp.brth_id bi on bi.anml_key = a.anml_key
left outer join tp.ahb_num an on an.anml_key = a.anml_key
left outer join tp.electronic_id ei on ei.anml_key = a.anml_key and ei.end_date is null
where bi.pfx = 'CYVC' and bi.yr = 2016 and bi.num = 200
order by ei.st_date desc