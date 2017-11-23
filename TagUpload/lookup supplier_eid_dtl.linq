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
FROM tp.SUPPLIER_EID_DTL
where BIRTH_ID_PFX = 'MGHM' and BIRTH_ID_YR = 2015 and UPD_TIME > '2016-07-01'
--fetch first 100 rows only

DELETE FROM tp.SUPPLIER_EID_DTL 
WHERE BIRTH_ID_PFX = 'MGHM' and BIRTH_ID_YR = 2015 and UPD_TIME > '2016-07-01'