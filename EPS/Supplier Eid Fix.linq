<Query Kind="SQL">
  <Connection>
    <ID>a5444770-d904-466c-a355-09cee7ee295d</ID>
    <Persist>true</Persist>
    <Driver>EntityFrameworkDbContext</Driver>
    <CustomAssemblyPath>E:\LIC\dev\Db2Harness\LIC.Db2Harness\bin\Release\LIC.Db2Harness.dll</CustomAssemblyPath>
    <CustomTypeName>LIC.Db2Harness.Db2Context</CustomTypeName>
    <CustomCxString>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAdaLX+V7UF0CKszJtYZEmOgAAAAACAAAAAAADZgAAwAAAABAAAAByfA5ivMjobesEXYXmqxdfAAAAAASAAACgAAAAEAAAAGzeZg+7z2TBrMRkNQ1duC0YAAAApPsY8zJZPuQ6Zap02SqvSllkd4gmRx2oFAAAAMgNlfFk36sxCRq+P3os9OR2INLY</CustomCxString>
    <EncryptCustomCxString>true</EncryptCustomCxString>
    <DisplayName>DB2 ACC</DisplayName>
  </Connection>
</Query>

select * from tp.supplier_eid_dtl
where birth_id_pfx = 'DVDW'
and birth_id_yr = 2016
and alloc_cd = 'N'
fetch first 20 rows only
go
--insert into tp.supplier_eid_dtl (hdr_id, num, eid, birth_id_pfx, birth_id_yr, birth_id_num, alloc_cd)
--values (155012, 204, '982 984000000010', 'DVDW', 2016, 4, 'N')
--go
--select * from tp.brth_id where pfx = 'DVDW' and yr = 2016 fetch first 20 rows only
--go
--select max(eid) from tp.supplier_eid_dtl