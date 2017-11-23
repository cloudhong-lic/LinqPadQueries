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

select datamate_prod_cd, long_abbr, liquid_semen_batch_pfx
from tp.smn_splr_brand b
join tp.semen_splr_brand_brd br on b.cd = br.semen_splr_brand_cd
join tp.mktg_brd m on br.mktg_brd_cd = m.cd
--join tp.datamate_prod p on b.datamate_prod_cd = p.cd
order by 1