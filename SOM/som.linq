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
FROM TP.minda_order_ref
where ST_DATE > '2016-1-1'
fetch first 100 rows only

UPDATE TP.minda_order_ref
  SET ST_DATE = '2016-03-01'
  WHERE ORDER_REF = '693bca0f5c68453399fdbf9cb3733ebf' and HERD_NUM = 5
  
INSERT INTO TP.minda_order_ref ( END_DATE, ORDER_REF, ST_DATE, MAP_REF, HERD_NUM )
     VALUES (NULL, '693bca0f5c68453399fdbf9cb3733ebf', '2016-03-11', 'N052988956', 1)  