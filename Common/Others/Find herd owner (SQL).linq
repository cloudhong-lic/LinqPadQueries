<Query Kind="SQL">
  <Connection>
    <ID>f98fe28b-414d-4e97-a25f-2e33742da8c7</ID>
    <Persist>true</Persist>
    <Server>DDFP4J4Y1\SQLEXPRESS</Server>
    <DisplayName>Sql server in localhost</DisplayName>
    <Database>MINDAWeb_local</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

SELECT u.Name, u.UserName, H.HERDNUMBER, H.PTPTCODE
FROM [core].[Herd] h
       join core.ConcernPermission cp on cp.HerdId = h.Id
       join core.PermissionSetMember psm on psm.ConcernPermissionId = cp.Id
       join core.PermissionSet ps on ps.Id = psm.PermissionSetId
       join core.[User] u on u.Id = ps.AppliesToUserId
where h.PtPtCode = 'BLQL'
--where h.herdnumber = 5200759
--group by u.Name, u.UserName