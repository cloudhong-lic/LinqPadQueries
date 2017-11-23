<Query Kind="Statements">
  <Connection>
    <ID>177cd3cc-a4db-4d86-a8d0-96d2db8e0f45</ID>
    <Persist>true</Persist>
    <Driver>EntityFrameworkDbContext</Driver>
    <CustomAssemblyPath>C:\LIC\hub\hub-NAIT\LIC.Hub.NAIT.Datastore\bin\Debug\LIC.Hub.NAIT.Datastore.dll</CustomAssemblyPath>
    <CustomTypeName>LIC.Hub.NAIT.Datastore.Contexts.NaitContext</CustomTypeName>
    <AppConfigPath>C:\LIC\hub\hub-NAIT\LIC.Hub.NAIT.Datastore\bin\Debug\LIC.Hub.NAIT.Datastore.dll.config</AppConfigPath>
  </Connection>
</Query>

var query = NaitEvents
	.Where(e => e.EntityEventTime > new DateTime(2015, 4, 1)
		&& e.EntityEventTime < new DateTime(2015, 6, 1)
		&& e.EntityResponseStatus == "F")
	.GroupBy(e => new { e.AnimalGroupBpNumber, e.ResponseMessage })
	.Select(s => new { AnimalGroupBpNumber = s.Key.AnimalGroupBpNumber.Trim(), ResponseMessage = s.Key.ResponseMessage.Trim(), HerdErrorCount = s.Count() });
	
query.Dump();