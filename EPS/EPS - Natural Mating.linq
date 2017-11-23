<Query Kind="SQL">
  <Connection>
    <ID>882b9adc-eacd-4d55-a302-405be1ce361b</ID>
    <Persist>true</Persist>
    <Server>lictinmdtdb99</Server>
    <Database>MindaWeb_TEST</Database>
    <ShowServer>true</ShowServer>
  </Connection>
  <Output>DataGrids</Output>
</Query>

declare @eventid uniqueidentifier
set @eventid = 'df87134a-9bcd-4f81-8886-f71678e130ad'

SELECT 'EPS', * FROM [calendar].[HoldingPenEvent] where eventid = @eventid
SELECT 'EPS', d.* FROM [eventprocessing].[EventData] d
  JOIN [calendar].[HoldingPenEvent] e ON d.[EventId] = e.[Id] and d.[Version] = e.[Version] where e.eventid = @eventid
SELECT 'EPS', m.[ServiceBoundary], r.*, c.[MessageCode] from [calendar].[HoldingPenEvent] h
  JOIN [eventprocessing].[AggregatorExpectedResultsMappings] m on h.[EventType] = m.[EventType]
  LEFT OUTER JOIN [eventprocessing].[ValidationResults] r on h.[Id] = r.[EventId] and h.[Version] = r.[EventVersion] and r.[ServiceBoundary] = m.[ServiceBoundary]
  LEFT OUTER JOIN [eventprocessing].[ValidationResultMessageCodes] c on r.[Id] = c.[ValidationResultId] where h.eventid = @eventid
SELECT 'AI' AS [SB], * FROM [animalidentity].[AnimalEvent] where eventid = @eventid
SELECT 'AI' AS [SB], * FROM [animalidentity].[SupplementaryAnimalEvent] where eventid = @eventid
SELECT 'ARC' AS [SB], * FROM [animalrecordscompliance].[AnimalEvent] where eventid = @eventid
SELECT 'AGM' AS [SB], * FROM [animalgroupmembership].[AnimalEvent] where eventid = @eventid
SELECT 'AGM' AS [SB], * FROM [animalgroupmembership].[SupplementaryAnimalEvent] where eventid = @eventid
SELECT 'Repro' AS [SB], * FROM [reproduction].[ProposedNaturalMatingEvent] where eventid = @eventid

SELECT 'Repro' AS [SB], * FROM [reproduction].[ProposedNaturalMatingEvent] where animalkey = 16948370

--
--DELETE FROM [eventprocessing].[ValidationResults] WHERE EventId = (SELECT Id FROM calendar.HoldingPenEvent WHERE EventId = @eventid)
--DELETE FROM [eventprocessing].[EventData] where eventid = (SELECT Id FROM calendar.HoldingPenEvent WHERE EventId = @eventid)
--DELETE FROM [calendar].[HoldingPenEvent] where eventid = @eventid
--DELETE FROM [animalidentity].[AnimalEvent] where eventid = @eventid
--DELETE FROM [animalidentity].[SupplementaryAnimalEvent] where eventid = @eventid
--DELETE FROM [animalidentity].[ValidationResult] where eventid = @eventid
--DELETE FROM [animalrecordscompliance].[AnimalEvent] where eventid = @eventid
--DELETE FROM [animalrecordscompliance].[ValidationResult] where eventid = @eventid
--DELETE FROM [animalgroupmembership].[AnimalEvent] where eventid = @eventid
--DELETE FROM [animalgroupmembership].[SupplementaryAnimalEvent] where eventid = @eventid
--DELETE FROM [animalgroupmembership].[ValidationResult] where eventid = @eventid
--DELETE FROM [reproduction].[ProposedNaturalMatingEvent] where eventid = @eventid