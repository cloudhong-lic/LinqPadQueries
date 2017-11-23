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

-- tp.herd_upd
-- http://www.livestock.org.nz/devl/p900_dd/dd_disp.cfm?DB=TP&ST=HERD_UPD
-- Keys: OWNR_PTPT_CD, MAP_REF, HERD_NUM

select *
from tp.herd_upd
--where
order by UPD_TIME desc
fetch first 100 rows only

--UPDATE tp.herd_upd
--  SET HERD_UPD_STS_CD = 'F'
--  WHERE OWNR_PTPT_CD = 'QNRC' and MAP_REF = 'S136438754' and HERD_NUM = 2

go