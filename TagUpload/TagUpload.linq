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

--SELECT *
--FROM tp.SUPPLIER_EID_DTL
--WHERE UPD_TIME > '2016-5-20'

--SELECT *
--FROM tp.SUPPLIER_EID_DTL
--WHERE BIRTH_ID_PFX = 'BWHT' AND BIRTH_ID_YR = '2016' AND BIRTH_ID_NUM = '1099' AND ALLOC_CD = 'N'

SELECT * 
FROM tp.SUPPLIER_EID_HDR
WHERE UPD_TIME > '2016-5-20'

DELETE FROM tp.SUPPLIER_EID_HDR
WHERE FILENAME = 'LIC24949139-BWHT-YearNumberHerd-5.txt'

--SELECT *
--FROM tp.SUPPLIER_EID_HDR
--WHERE UPD_TIME > '2016-5-20'

--SELECT * FROM tp.SUPPLIER_EID_DTL WHERE BIRTH_ID_PFX = 'BWHT' AND BIRTH_ID_YR = '2016' AND BIRTH_ID_NUM <> '100' AND ALLOC_CD = 'N'

--DELETE FROM tp.SUPPLIER_EID_DTL WHERE BIRTH_ID_PFX = 'BWHT' AND BIRTH_ID_YR = '2016' AND BIRTH_ID_NUM = '1104' AND ALLOC_CD = 'N'

SELECT *
FROM SUPPLIER_EID_HDR
WHERE filename like '%-DHW-%'

SELECT *
FROM SUPPLIER_EID_DTL
WHERE HDR_ID = '201923'

SELECT *
FROM SUPPLIER_EID_HDR
WHERE UPD_TIME > '2016-4-20'

SELECT *
FROM SUPPLIER_EID_HDR
WHERE FILENAME like '%BWHT%'

SELECT *
FROM SUPPLIER_EID_HDR
WHERE UPD_TIME > '2016-5-20'