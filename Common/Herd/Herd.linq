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

--tp.herd
--http://www.livestock.org.nz/devl/p900_dd/dd_disp.cfm?DB=TP&ST=HERD
--Key: map_ref, herd_num

select 
	map_ref, herd_num
	,crm_id
	,herd_cd
	,spcs_cd, descr
	,st_date_d, end_date_d
	,ahb_herd_num
	,name
	
from tp.herd
join tp.SPECIES as s on s.cd = spcs_cd

where 
	map_ref = 'S082119579' and herd_num = 1
	--crm_id = 5011459