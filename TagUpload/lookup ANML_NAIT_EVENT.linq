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

SELECT *
FROM tp.ANML_NAIT_EVENT
WHERE ANML_KEY = '35770578' or ANML_KEY = '35770583'
fetch first 1000 rows only

DELETE FROM tp.ANML_NAIT_EVENT
WHERE anml_key = '35770578' or anml_key = '35770583'