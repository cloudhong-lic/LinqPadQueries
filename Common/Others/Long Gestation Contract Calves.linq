<Query Kind="SQL">
  <Connection>
    <ID>ce948c42-b700-4880-ae48-f7676dc73819</ID>
    <Persist>true</Persist>
    <Driver>EntityFrameworkDbContext</Driver>
    <CustomAssemblyPath>C:\LIC\dev\Db2Harness\LIC.Db2Harness\bin\Release\LIC.Db2Harness.dll</CustomAssemblyPath>
    <CustomTypeName>LIC.Db2Harness.Db2Context</CustomTypeName>
    <CustomCxString>name=LINQPad_DB2_dev</CustomCxString>
    <DisplayName>DB2 DEV</DisplayName>
  </Connection>
</Query>

with contract_calves as (

select a.anml_key, a.dam_anml_key, a.rcpnt_anml_key,
a.brth_date_d, m.mtng_tp_cd, m.date_d, days(a.brth_date_d) - days(m.date_d) as diff,
year(m.date_d + 11 days) as season,
ROW_NUMBER() OVER (PARTITION BY a.anml_key ORDER BY a.brth_date_d - m.date_d) as rn
from tp.animal a
join tp.mating m on a.dam_anml_key = m.anml_key
where
year(a.brth_date_d) >= 2012
and a.brth_date_d > m.date_d
and days(a.brth_date_d) - days(m.date_d) < 365
and days(a.brth_date_d) - days(m.date_d) > 170
and a.rcpnt_anml_key = 0

) select c.*, b.contract_decision_cd, b.dam_decision_cd, b.calf_sts_cd  from contract_calves c
join tp.bull_acq_approach b on b.dam_anml_key = c.dam_anml_key and b.ssn = c.season
where
c.rn = 1 and c.mtng_tp_cd = 1 
and c.diff > 300
and (b.contract_decision_cd is null or b.contract_decision_cd = 'Y')
and b.dam_decision_cd in ('CS', 'SR')
and b.calf_sts_cd in ('BU', 'HF')
order by anml_key

select s.diff, s.contract_decision_cd, s.dam_decision_cd, count(*) from contract_calves s 
where s.rn = 1 and mtng_tp_cd = 1
group by s.diff, s.contract_decision_cd, s.dam_decision_cd