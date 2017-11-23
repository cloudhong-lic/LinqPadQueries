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
set @eventid = '258004cd-7044-4be2-b313-6022e52cd533'

SELECT * FROM [calendar].[HoldingPenEvent] where eventid = @eventid
SELECT 'EPS', d.* FROM [eventprocessing].[EventData] d
  JOIN [calendar].[HoldingPenEvent] e ON d.[EventId] = e.[Id] and d.[Version] = e.[Version] where e.eventid = @eventid
SELECT 'EPS', m.[ServiceBoundary], r.*, c.[MessageCode] from [calendar].[HoldingPenEvent] h
  JOIN [eventprocessing].[AggregatorExpectedResultsMappings] m on h.[EventType] = m.[EventType]
  LEFT OUTER JOIN [eventprocessing].[ValidationResults] r on h.[Id] = r.[EventId] and h.[Version] = r.[EventVersion] and r.[ServiceBoundary] = m.[ServiceBoundary]
  LEFT OUTER JOIN [eventprocessing].[ValidationResultMessageCodes] c on r.[Id] = c.[ValidationResultId] where h.eventid = @eventid
SELECT 'AComp' AS [SB], * FROM [AnimalCompliance].[ProposedRemoveAnimalEvent] where eventid = @eventid
SELECT 'AGI' AS [SB], * FROM [AnimalGroupIdentity].[ProposedRemoveAnimalEvent] where eventid = @eventid
SELECT 'AGM' AS [SB], * FROM [animalgroupmembership].[ProposedRemoveAnimalEvent] where eventid = @eventid
SELECT 'AI' AS [SB], * FROM [AnimalIdentity].[AnimalEvent] where eventid = @eventid
SELECT 'ARC' AS [SB], * FROM [animalrecordscompliance].[AnimalEvent] where eventid = @eventid
SELECT 'Con' AS [SB], * FROM [Condition].[AnimalEvent] where eventid = @eventid
SELECT 'Milk' AS [SB], * FROM [MilkProduction_Test].[MilkProduction].[AnimalEvent] where eventid = @eventid
SELECT 'Repro' AS [SB], * FROM [Reproduction].[ProposedPurchaseEvent] where eventid = @eventid
SELECT 'SOM' AS [SB], * FROM [SalesOrderManagement].[ProposedRemoveAnimalEvent] where eventid = @eventid
SELECT 'TOP' AS [SB], * FROM [TraitsOtherThanProduction].[AnimalEvent] where eventid = @eventid
SELECT 'Treat' AS [SB], * FROM [Treatment].[RemoveAnimalEvent] where eventid = @eventid