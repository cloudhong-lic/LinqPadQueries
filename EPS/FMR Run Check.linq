<Query Kind="SQL">
  <Connection>
    <ID>b7dfa058-b828-42a9-bd29-f00d9fd264d1</ID>
    <Persist>true</Persist>
    <Driver>EntityFrameworkDbContext</Driver>
    <CustomAssemblyPath>E:\LIC\dev\Db2Harness\LIC.Db2Harness\bin\Release\LIC.Db2Harness.dll</CustomAssemblyPath>
    <CustomTypeName>LIC.Db2Harness.Db2Context</CustomTypeName>
    <CustomCxString>name=LINQPad_DB2_eps</CustomCxString>
    <DisplayName>DB2 EPS</DisplayName>
  </Connection>
</Query>

select *
from tp.mating m 
where
m.anml_key = 16948370 
order by date desc
fetch first 1 rows only
go
select * 
from tp.fmr_insemination i
where female_anml_key = 16948370 and fmr_proc_status_cd <> 'D'
order by insemination_time desc
--go
--select * from tp.fmr_proc_status