<Query Kind="SQL">
  <Connection>
    <ID>841b8d2a-f2dd-4ae3-9dc0-e7bde6f49330</ID>
    <Persist>true</Persist>
    <Server>DDFP4J4Y1\SQLEXPRESS</Server>
    <Database>MINDAWeb_local</Database>
    <DisplayName>Sql in Local</DisplayName>
  </Connection>
</Query>

SELECT TOP (1000) qt.[Id] as QueryTypeId
      ,qc.[Title] as Category
	  ,m.[SourceErrorType]
      ,qt.[Title]
      ,qt.[Description]
--      ,qt.[Visible]
      ,qt.[Ranking]
--      ,qt.[UpdateTime]
--      ,qt.[RetrieveAnimalIdentifier]
--      ,qt.[DisplayModeId]
	  ,r.Description as Resolution
  FROM [ResolutionCentre].[QueryType] as qt
  join [ResolutionCentre].[QueryTypeMap] as m on m.QueryTypeId = qt.Id
  join [ResolutionCentre].[QueryTypeResolution] as qtr on qtr.QueryTypeId = qt.Id
  join [ResolutionCentre].[Resolution] as r on r.Id = qtr.ResolutionId
  join [ResolutionCentre].[QueryCategory] as qc on qc.Id = qt.QueryCategoryId
  where m.[SourceErrorType] in ('4630')