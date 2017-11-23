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

select * from tp.cross_brd b
join tp.herd_anml ha on b.anml_key = ha.anml_key
where b.portion_16th < 14 
and ANML_REG_CD = 1
and HDBK_SECT_CD = 'M'
and BSOC_PROC_DATE_D > '2000-01-01'
and xfer_out_time is null
fetch first 10 rows only