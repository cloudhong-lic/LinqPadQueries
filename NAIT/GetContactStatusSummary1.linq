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

var joinQuery = from naitGroup in NaitEvents
	where naitGroup.EntityUpdateTime > new DateTime(2015,9,10)
	group naitGroup by naitGroup.LicStatus into g
	select new {
		StatusCode = g.Key.StatusCode,
		Count = (int?)g.Count()
	};

var query = from code in NaitLicStatuses
	join jq in joinQuery on code.StatusCode equals jq.StatusCode into joinCodeCount
	from jcc in joinCodeCount.DefaultIfEmpty()
	select new {
		StatusCode = code.StatusCode,
		Description = code.Description, 
		Count = jcc.Count ?? 0
	};
	
query.Dump();