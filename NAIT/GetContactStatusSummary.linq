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

var query = from naitEvent in NaitEvents
	where naitEvent.EntityUpdateTime > new DateTime(2015,9,10)
	group naitEvent by naitEvent.LicStatus into g
	select new {
		StatusCode = g.Key.StatusCode,
		Description = g.Key.Description,
		Count = g.Count()
	};
	
query.Dump();