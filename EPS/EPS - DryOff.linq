<Query Kind="SQL">
  <Connection>
    <ID>882b9adc-eacd-4d55-a302-405be1ce361b</ID>
    <Persist>true</Persist>
    <Server>lictinmdtdb99</Server>
    <Database>MindaWeb_TEST</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

declare @eventid uniqueidentifier
set @eventid = '4b8739f8-447a-4ef0-8f18-85d87feccc4f'

SELECT 'EPS', * FROM [calendar].[HoldingPenEvent] where eventid = @eventid
SELECT 'EPS', d.* FROM [eventprocessing].[EventData] d
  JOIN [calendar].[HoldingPenEvent] e ON d.[EventId] = e.[Id] and d.[Version] = e.[Version] where e.eventid = @eventid
SELECT 'EPS', m.[ServiceBoundary], r.*, c.[MessageCode] from [calendar].[HoldingPenEvent] h
  JOIN [eventprocessing].[AggregatorExpectedResultsMappings] m on h.[EventType] = m.[EventType]
  LEFT OUTER JOIN [eventprocessing].[ValidationResults] r on h.[Id] = r.[EventId] and h.[Version] = r.[EventVersion] and r.[ServiceBoundary] = m.[ServiceBoundary]
  LEFT OUTER JOIN [eventprocessing].[ValidationResultMessageCodes] c on r.[Id] = c.[ValidationResultId] where h.eventid = @eventid
SELECT 'Repro', * FROM [reproduction].[AnimalEvent] where eventid = @eventid
SELECT 'ARC', * FROM [animalrecordscompliance].[AnimalEvent] where eventid = @eventid
SELECT 'AGM', * FROM [animalgroupmembership].[AnimalEvent] where eventid = @eventid
SELECT 'Milk', * FROM [MilkProduction_test].[MilkProduction].[ProposedDryOffEvent] where eventid = @eventid
SELECT 'Milk', * FROM [MilkProduction].[ValidationResult] where eventid = @eventid

SELECT 'OtherMilk', * FROM [MilkProduction_test].[MilkProduction].[ProposedDryOffEvent] where animalkey = 22865382
--
--DELETE FROM [eventprocessing].[ValidationResults] WHERE EventId = (SELECT Id FROM calendar.HoldingPenEvent WHERE EventId = @eventid)
--DELETE FROM [eventprocessing].[EventData] where eventid = (SELECT Id FROM calendar.HoldingPenEvent WHERE EventId = @eventid)
--DELETE FROM [calendar].[HoldingPenEvent] where eventid = @eventid
--DELETE FROM [reproduction].[AnimalEvent] where eventid = @eventid
--DELETE FROM [animalgroupmembership].[AnimalEvent] where eventid = @eventid
--DELETE FROM [animalgroupmembership].[ValidationResult] where eventid = @eventid
--DELETE FROM [MilkProduction_test].[MilkProduction].[ProposedDryOffEvent] where eventid = @eventid
--DELETE FROM [MilkProduction].[ValidationResult] where eventid = @eventid