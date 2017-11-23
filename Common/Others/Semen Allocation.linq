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

select h.crm_id, s.ssn,
s.demand_date, b.long_abbr, s.core_prod_cd,
sum(s.lll_dose_cnt) as liquid, sum(s.frz_dose_cnt) as frozen
from tp.herd h
join tp.mtng_plan_rqrd_smn s on (h.map_ref = s.map_ref and h.herd_num = s.herd_num)
join tp.AB_MTNG_PLAN p on (s.map_ref = p.map_ref and s.herd_num = p.herd_num and s.ssn = p.ssn and s.mtng_plan_num = p.num)
join tp.ab_grp g on (g.rgn_cd = p.ab_grp_rgn_cd and g.num = p.ab_grp_num)
join tp.mktg_brd b on s.sire_mktg_brd_cd = b.cd
where 1=1
and g.CLOSED_IND = 0
and g.DFLT_GRP_IND <> 'Y'
and g.MAIN_TECH_PTPT_CD = 'CXDB'
and h.crm_id in (5004669)
and demand_date >= '2014-08-18'
and demand_date <= '2014-12-24'
group by h.crm_id, s.ssn, s.demand_date, b.long_abbr, s.core_prod_cd
order by h.crm_id, s.ssn, b.long_abbr, s.core_prod_cd, s.demand_date