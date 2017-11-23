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

--tp.animal
--http://www.livestock.org.nz/devl/p900_dd/dd_disp.cfm?DB=TP&ST=ANIMAL
--Key: anml_key

select 
	a.anml_key
	,a.sex_cd
	,a.BRTH_DATE_D
	,bi.pfx, bi.yr, bi.num	-- birth id
	,a.SPCS_CD
	,a.SIRE_ANML_KEY
	,a.DAM_ANML_KEY
	,a.BRTH_CTRY_CD
	,a.AE_BRD_CD, ae.ABBR as AE_ABBR	
	,a.SPS_STS_CD
--	,an.ahb_herd_num, an.yr as ahb_yr, an.num as ahb_num
--	,ei.eid, ei.st_date,ei.end_date
	
from tp.animal a
JOIN tp.AE_BRD as ae on ae.cd = a.ae_brd_cd
JOIN tp.brth_id as bi on bi.anml_key = a.anml_key
--JOIN tp.ahb_num as an on an.anml_key = a.anml_key
--JOIN tp.electronic_id as ei on ei.anml_key = a.anml_key

where 
	a.anml_key = 28455855
	
order by anml_key
fetch first 10 rows only

go