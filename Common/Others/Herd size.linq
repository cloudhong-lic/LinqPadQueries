<Query Kind="SQL">
  <Connection>
    <ID>d6f2b19a-ae75-4d4c-a4a4-58aac933ce8e</ID>
    <Persist>true</Persist>
    <Driver>EntityFrameworkDbContext</Driver>
    <CustomAssemblyPath>C:\LIC\dev\Db2Harness\LIC.Db2Harness\bin\Debug\LIC.Db2Harness.dll</CustomAssemblyPath>
    <CustomTypeName>LIC.Db2Harness.Db2Context</CustomTypeName>
    <AppConfigPath>C:\LIC\dev\Db2Harness\LIC.Db2Harness\bin\Debug\App.config</AppConfigPath>
    <DisplayName>DB2 Dev</DisplayName>
  </Connection>
</Query>

select herd_size, min(hdl.ownr_ptpt_cd) as participant_code
from
(select (count(ha.anml_key)) as herd_size, ha.herd_num, ha.map_ref
from tp.herd_anml ha,
      tp.herd hd
where (ha.xfer_out_time is null     
    or  ha.xfer_out_time > current_timestamp)   
    and ha.map_ref = hd.map_ref     
    and ha.herd_num = hd.herd_num
    and hd.end_date = 0
group by ha.map_ref, ha.herd_num
) hs,
tp.herd_dtl hdl
where hs.map_ref = hdl.map_ref
      and hs.herd_num = hdl.herd_num
group by hs.map_ref, hs.herd_num, herd_size
order by herd_size desc