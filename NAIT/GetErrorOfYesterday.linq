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

var startDate = DateTimeOffset.Now.AddYears(-1).DateTime;
var endDate = DateTimeOffset.Now.DateTime;
			
var query = NaitEvents
	.Where(e => e.EntityEventTime > startDate
		&& e.EntityEventTime < endDate
		&& e.EntityResponseStatus == "F")
	.Take(100);
	
query.Dump();