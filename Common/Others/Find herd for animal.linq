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

select h.crm_id, d.OWNR_PTPT_CD, max(d.SR_AREA_SSN)
from tp.herd_anml a
join tp.herd h on (a.map_ref = h.map_ref and a.herd_num = h.herd_num)
join tp.herd_dtl d on (a.map_ref = d.map_ref
      and a.herd_num = d.herd_num)
where a.anml_key = 30996654
group by h.crm_id, d.OWNR_PTPT_CD
order by 2 desc