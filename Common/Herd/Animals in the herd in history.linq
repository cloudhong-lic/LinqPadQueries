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
	,a.XFER_IN_TIME
	,a.XFER_OUT_TIME
	,a.FATE_CD

from tp.herd_anml as a
join tp.herd as h on (a.map_ref = h.map_ref and a.herd_num = h.herd_num)

where 
	--h.crm_id = 5057217
	a.map_ref = 'N066265359' and a.herd_num = 7
	
	--|----in....out----> find all animals in the herd between in and out date
	and (a.xfer_out_time is null or a.xfer_out_time >= '2006-06-01') and (h.end_date_d is null or h.end_date_d >= '2006-06-01')
	and a.xfer_in_time <= '2016-12-08' and h.st_date_d <= '2016-12-08'
	
	--|----in...........> find all animals in the herd 
--	and (a.xfer_out_time is null or a.xfer_out_time >= '2006-06-01') and (h.end_date_d is null or h.end_date_d >= '2006-06-01')
	
	--|..........out---->
--	and a.xfer_in_time <= '2016-12-08' and h.st_date_d <= '2016-12-08'

order by XFER_IN_TIME desc
fetch first 100 rows only

--select count(a.anml_key)
--from tp.herd_anml as a
--JOIN tp.herd as h on (a.map_ref = h.map_ref and a.herd_num = h.herd_num)
--where a.map_ref = 'N066265359' and a.herd_num = 7