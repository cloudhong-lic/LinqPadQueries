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
	a.anml_key
	,a.MAP_REF, a.HERD_NUM, h.crm_id
	,a.XFER_IN_TIME, a.XFER_OUT_TIME
	,n.anml_num, n.NUM_ST_TIME, n.NUM_END_TIME

from tp.herd_anml as a
JOIN tp.herd as h on (a.map_ref = h.map_ref and a.herd_num = h.herd_num)
left outer join tp.herd_anml_num as n on (a.anml_key = n.anml_key and a.map_ref = n.map_ref and a.herd_num = n.herd_num)

where 
	a.xfer_out_time is null
	--and a.MAP_REF = 'S176250261' and a.HERD_NUM = 1
	and h.crm_id = 5011459
	--a.anml_key = 30996654
	
fetch first 100 rows only

--select count(a.anml_key)
--from tp.herd_anml as a
--JOIN tp.herd as h on (a.map_ref = h.map_ref and a.herd_num = h.herd_num)
--where 
--	a.xfer_out_time is null
--	and h.crm_id = 5011459