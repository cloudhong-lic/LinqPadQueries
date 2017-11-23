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

SELECT
	a.anml_key,
	bi.pfx, bi.yr, bi.num,
	an.ahb_herd_num, an.yr as ahb_yr, an.num as ahb_num,
	ei.eid, ei.st_date,ei.end_date,
	lia.tattoo_cd, lia.RGN_CD,lia.HERD_CD,lia.BRTH_YR,
	herdbook.HDBK_NUM, herdbook.BSOC_PTPT_CD, herdbook.SEX_CD,
	han.anml_num
FROM (values 30047732) as k(ANML_KEY)
INNER JOIN tp.animal a
	ON a.ANML_KEY = k.ANML_KEY
LEFT OUTER JOIN tp.brth_id bi
	ON bi.anml_key = a.anml_key
LEFT OUTER JOIN tp.ahb_num an
	ON an.anml_key = a.anml_key
LEFT OUTER JOIN tp.electronic_id ei
	ON ei.anml_key = a.anml_key AND ei.end_date is null
LEFT OUTER JOIN TP.LIA_ANML_ID lia
	ON lia.anml_key = a.anml_key
LEFT OUTER JOIN TP.BSOC_ANML_ID herdbook
	ON herdbook.anml_key = a.anml_key
LEFT OUTER JOIN TP.herd_anml_num han
	ON han.anml_key = a.anml_key AND num_end_time IS NULL