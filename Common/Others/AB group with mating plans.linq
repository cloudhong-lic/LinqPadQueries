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
g.rgn_cd, g.num, g.MAIN_TECH_PTPT_CD, p.num, p.st_date_d, p.end_date_d, p.can_date_d, h.CRM_ID, f.EFF_DATE
from tp.ab_grp g
join tp.AB_MTNG_PLAN p on (g.rgn_cd = p.ab_grp_rgn_cd and g.num = p.ab_grp_num)
join tp.herd h on (p.MAP_REF = h.MAP_REF and p.HERD_NUM = h.HERD_NUM)
left outer join tp.FUTR_MTNG_PLAN_DTL f on (p.MAP_REF = f.MAP_REF and p.HERD_NUM = f.HERD_NUM and p.num = f.MTNG_PLAN_NUM and p.ssn = f.ssn)
where 1=1
and g.CLOSED_IND = 0
and g.DFLT_GRP_IND <> 'Y'
and g.MAIN_TECH_PTPT_CD = 'CXDB'
and p.END_DATE_D >= '2013-12-25'
and p.ST_DATE_D <= '2014-08-20'
--and h.crm_id = 5037447
order by g.MAIN_TECH_PTPT_CD, h.CRM_ID
--fetch first 20 rows only