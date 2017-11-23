<Query Kind="SQL">
  <Connection>
    <ID>a43ca058-538b-458b-beb7-2745ccca05e4</ID>
    <Persist>true</Persist>
    <Server>lictinmdtdb01.test01.lic.co.nz</Server>
    <Database>MindaWeb_TEST</Database>
    <DisplayName>Sql in Test01</DisplayName>
  </Connection>
</Query>

SELECT u.Name, u.UserName, H.HERDNUMBER, H.PTPTCODE
FROM [core].[Herd] h
       join core.ConcernPermission cp on cp.HerdId = h.Id
       join core.PermissionSetMember psm on psm.ConcernPermissionId = cp.Id
       join core.PermissionSet ps on ps.Id = psm.PermissionSetId
       join core.[User] u on u.Id = ps.AppliesToUserId
where h.PtPtCode = 'BCCY'
--where h.herdnumber = 5200759
--group by u.Name, u.UserName