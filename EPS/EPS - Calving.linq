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
set @eventid = '92cc73dd-bc9c-4aed-9711-9c8d4a4e6714'

SELECT 'EPS', * FROM [calendar].[HoldingPenEvent] where eventid = @eventid
SELECT 'EPS', d.* FROM [eventprocessing].[EventData] d
  JOIN [calendar].[HoldingPenEvent] e ON d.[EventId] = e.[Id] and d.[Version] = e.[Version] where e.eventid = @eventid
SELECT 'EPS', m.[ServiceBoundary], r.*, c.[MessageCode] from [calendar].[HoldingPenEvent] h
  JOIN [eventprocessing].[AggregatorExpectedResultsMappings] m on h.[EventType] = m.[EventType]
  LEFT OUTER JOIN [eventprocessing].[ValidationResults] r on h.[Id] = r.[EventId] and h.[Version] = r.[EventVersion] and r.[ServiceBoundary] = m.[ServiceBoundary]
  LEFT OUTER JOIN [eventprocessing].[ValidationResultMessageCodes] c on r.[Id] = c.[ValidationResultId] where h.eventid = @eventid
SELECT 'AI', * FROM [animalidentity].[AnimalEvent] where eventid = @eventid
SELECT 'AI', * FROM [animalidentity].[NewAnimalProposed] where eventid = @eventid
SELECT 'AGM', * FROM [animalgroupmembership].[AnimalEvent] where eventid = @eventid
SELECT 'ARC', * FROM [animalrecordscompliance].[AnimalEvent] where eventid = @eventid
SELECT 'SOM', * FROM [SalesOrderManagement].[NewAnimalProposed] where eventid = @eventid
--SELECT 'CTS', * FROM [ctsintegration].[ProposedCalvingEvent] where eventid = @eventid
SELECT 'Repro', * FROM [reproduction].[ProposedCalvingEvent] where eventid = @eventid

SELECT 'Repro', * FROM [reproduction].[ProposedCalvingEvent] where animalkey = 32542982
--select * from [animalidentity].[NewAnimalProposed] where BirthIdPrefix = 'DVDW' and BirthIdYear = 2016 and BirthIdSequenceNumber = 1
--select * from [animalidentity].[NewAnimalProposed] where LifetimeId = 'UK123456499999'

--
--DELETE FROM [eventprocessing].[ValidationResults] WHERE EventId = (SELECT Id FROM calendar.HoldingPenEvent WHERE EventId = @eventid)
--DELETE FROM [eventprocessing].[EventData] where eventid = (SELECT Id FROM calendar.HoldingPenEvent WHERE EventId = @eventid)
--DELETE FROM [calendar].[HoldingPenEvent] where eventid = @eventid
--DELETE FROM [animalidentity].[AnimalEvent] where eventid = @eventid
--DELETE FROM [animalidentity].[NewAnimalProposed] where eventid = @eventid
--DELETE FROM [animalidentity].[ValidationResult] where eventid = @eventid
--DELETE FROM [animalrecordscompliance].[AnimalEvent] where eventid = @eventid
--DELETE FROM [animalrecordscompliance].[ValidationResult] where eventid = @eventid
--DELETE FROM [animalgroupmembership].[AnimalEvent] where eventid = @eventid
--DELETE FROM [animalgroupmembership].[ValidationResult] where eventid = @eventid
--DELETE FROM [SalesOrderManagement].[NewAnimalProposed] where eventid = @eventid
--DELETE FROM [SalesOrderManagement].[ValidationResult] where eventid = @eventid
--DELETE FROM [ctsintegration].[ProposedCalvingEvent] where eventid = @eventid
--DELETE FROM [reproduction].[ProposedCalvingEventComment] WHERE ProposedCalvingEventId = (SELECT [Id] FROM [reproduction].[ProposedCalvingEvent] where eventid = @eventid)
--DELETE FROM [reproduction].[ProposedCalvingEvent] where eventid = @eventid