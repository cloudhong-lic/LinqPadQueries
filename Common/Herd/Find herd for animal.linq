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

--tp.herd_anml
--http://www.livestock.org.nz/devl/p900_dd/dd_disp.cfm?DB=TP&ST=HERD_ANML
--Key: anml_key, xfer_in_time

select 
	h.crm_id, d.OWNR_PTPT_CD
	,a.MAP_REF, a.HERD_NUM
	,a.XFER_IN_TIME, a.XFER_OUT_TIME
	--,n.anml_num, n.NUM_ST_TIME, n.NUM_END_TIME
	
from tp.herd_anml a
join tp.herd h on (a.map_ref = h.map_ref and a.herd_num = h.herd_num)
join tp.herd_dtl d on (a.map_ref = d.map_ref and a.herd_num = d.herd_num)
--left outer join tp.herd_anml_num as n on (a.anml_key = n.anml_key and a.map_ref = n.map_ref and a.herd_num = n.herd_num)

where a.anml_key = 30996654

group by 
	h.crm_id, d.OWNR_PTPT_CD, a.MAP_REF, a.HERD_NUM
	,a.XFER_IN_TIME, a.XFER_OUT_TIME 
	--,n.anml_num, n.NUM_ST_TIME, n.NUM_END_TIME

order by XFER_IN_TIME desc