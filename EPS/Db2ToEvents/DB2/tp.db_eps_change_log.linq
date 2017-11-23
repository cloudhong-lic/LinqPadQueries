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

-- tp.DB_EPS_CHANGE_LOG 
-- http://www.livestock.org.nz/devl/p900_dd/dd_disp.cfm?DB=TP&ST=DB_EPS_CHANGE_LOG
-- Columns: ID, UPD_TIME, CHANGE_TIME, ACTION_CD, TABLE_NAME, DATA
-- TABLE_NAME: herd_upd, herd_upd_err, batch_upd_err
-- ACTION_CD: ins, upd, del

select *
from tp.DB_EPS_CHANGE_LOG
where table_name = 'herd_upd_err'
--and data like '%"err_data":"AN1%'
--and data like '%"anml_key":"34094689"%'
--and ACTION_CD = 'upd'
and id >= 10454229
order by id desc
fetch first 1000 rows only

go