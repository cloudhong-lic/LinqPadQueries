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

select 
h.crm_id
, test_date_d
, comply_tags_reqd_prcnt
, comply_tags_reqd
, sts.comply_herd_2yr_tags_prcnt
, sts.comply_herd_2yr_tags_reqd
, comply_calvings_reqd_prcnt
, comply_calvings_reqd

from tp.HT_VST as sts
join tp.herd as h on h.map_ref = sts.map_ref and h.herd_num = sts.herd_num
where 
	comply_status = 'N' and
	h.map_ref = 'N004530134' and h.herd_num = 2
	--crm_id = 5011459
	--TEST_DATE_D > '2017-01-01'
fetch first 100 rows only