<Query Kind="SQL">
  <Connection>
    <ID>37277f92-1382-4de7-a51a-f114e4523712</ID>
    <Persist>true</Persist>
    <Server>lictinmdtdb11</Server>
    <Database>MindaWeb_TEST</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

declare @eventid uniqueidentifier
set @eventid = '97cd3462-79ee-4ca9-be71-3585c4191b6b'

SELECT 'EPS', * FROM [calendar].[HoldingPenEvent] where eventid = @eventid
SELECT 'EPS', d.* FROM [eventprocessing].[EventData] d
  JOIN [calendar].[HoldingPenEvent] e ON d.[EventId] = e.[Id] and d.[Version] = e.[Version] where e.eventid = @eventid
SELECT 'EPS', m.[ServiceBoundary], r.*, c.[MessageCode] from [calendar].[HoldingPenEvent] h
  JOIN [eventprocessing].[AggregatorExpectedResultsMappings] m on h.[EventType] = m.[EventType]
  LEFT OUTER JOIN [eventprocessing].[ValidationResults] r on h.[Id] = r.[EventId] and h.[Version] = r.[EventVersion] and r.[ServiceBoundary] = m.[ServiceBoundary]
  LEFT OUTER JOIN [eventprocessing].[ValidationResultMessageCodes] c on r.[Id] = c.[ValidationResultId] where h.eventid = @eventid
SELECT 'ARC' AS [SB], * FROM [animalrecordscompliance].[AnimalEvent] where eventid = @eventid
SELECT 'AGM' AS [SB], * FROM [animalgroupmembership].[AnimalEvent] where eventid = @eventid
SELECT 'AGM' AS [SB], * FROM [animalgroupmembership].[ValidationResult] where eventid = @eventid
SELECT 'AB' AS [SB], * FROM [artificialbreeding].[SemenBatchEvent] where eventid = @eventid
--SELECT 'GPD' AS [SB], * FROM [GeneticProductDevelopment].[ProposedDiyMatingEvent] where eventid = @eventid
SELECT 'Repro' AS [SB], * FROM [reproduction].[ProposedDiyMatingEvent] where eventid = @eventid

SELECT 'Repro' AS [SB], * FROM [reproduction].[ProposedDiyMatingEvent] where animalkey = 20663089
--
--DELETE FROM [calendar].[HoldingPenEvent] where eventid = @eventid
--DELETE FROM [eventprocessing].[EventData] where eventid = @eventid
--DELETE FROM [animalcharacteristic].[AnimalEvent] where eventid = @eventid
--DELETE FROM [animalcharacteristic].[ValidationResult] where eventid = @eventid
--DELETE FROM [animalgroupmembership].[AnimalEvent] where eventid = @eventid
--DELETE FROM [animalgroupmembership].[ValidationResult] where eventid = @eventid
--DELETE FROM [artificialbreeding].[SemenBatchEvent] where eventid = @eventid
--DELETE FROM [artificialbreeding].[ValidationResult] where eventid = @eventid
--DELETE FROM [reproduction].[ProposedDiyMatingEvent] where eventid = @eventid