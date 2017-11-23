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

select *
from tp.mdc_pay_claim
--where 
fetch first 100 rows only