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

-- tp.herd_upd_err
-- http://www.livestock.org.nz/devl/p900_dd/dd_disp.cfm?DB=TP&ST=HERD_UPD_ERR
-- Columns: OWNR_PTPT_CD, MAP_REF, HERD_NUM, REF_NUM, UPD_TIME, ANML_KEY, BATCH_UPD_ERR_CD, ERR_LVL_CD, DOC_NUM, DATA, DESCR
-- Keys: OWNR_PTPT_CD, MAP_REF, HERD_NUM, REF_NUM
-- Record types in Data: 
-- Animal Event query (AN1), Animal Health query (AH1), Herd Test query (HT1), Liveweight file query (LW1), 
-- Movement event query (MV1), Non-LIC Herd test query (HX1), Animal Transfer Certificate (TC1), LIMS Test (LM1)

select *
from tp.herd_upd_err
where 
data like '%AN1%'
--or data like '%HT1%'
order by UPD_TIME desc
fetch first 100 rows only

--UPDATE tp.herd_upd_err
--  SET DATA = 'TC1;1;;24/02/2017;7065;'
--  WHERE OWNR_PTPT_CD = 'QNRC' and MAP_REF = 'S136438754' and HERD_NUM = 2 and REF_NUM = 338

go