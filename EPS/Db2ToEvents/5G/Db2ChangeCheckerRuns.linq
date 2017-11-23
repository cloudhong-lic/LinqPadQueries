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

--You could update LastDb2ChangedId to trigger the Db2ToEvents messages loading
--Please make sure the Id is the lastest

--UPDATE [eventprocessing].[Db2ChangeCheckerRuns]
--  set [LastDb2ChangeId] = 10444229
--  where id = 3715

SELECT TOP 1000 [Id]
      ,[LastDb2ChangeId]
      ,[RecordsReturned]
      ,[Date]
      ,[Db2TableName]
	FROM [eventprocessing].[Db2ChangeCheckerRuns]
	order by Id desc