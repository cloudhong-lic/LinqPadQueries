<Query Kind="SQL">
  <Connection>
    <ID>0374dd4c-b2da-4bfa-a07d-f009c641be78</ID>
    <Server>LICRRWDSPA1</Server>
    <DisplayName>EPS ACCP</DisplayName>
    <Database>MindaWeb_ACCP</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

SELECT *
FROM [core].[Herd] h
where h.PtPtCode = 'JYGY'
or h.HerdNumber = 5035011