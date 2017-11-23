<Query Kind="Expression">
  <Connection>
    <ID>177cd3cc-a4db-4d86-a8d0-96d2db8e0f45</ID>
    <Persist>true</Persist>
    <Driver>EntityFrameworkDbContext</Driver>
    <CustomAssemblyPath>C:\LIC\hub\hub-NAIT\LIC.Hub.NAIT.Datastore\bin\Debug\LIC.Hub.NAIT.Datastore.dll</CustomAssemblyPath>
    <CustomTypeName>LIC.Hub.NAIT.Datastore.Contexts.NaitContext</CustomTypeName>
    <AppConfigPath>C:\LIC\hub\hub-NAIT\LIC.Hub.NAIT.Datastore\bin\Debug\LIC.Hub.NAIT.Datastore.dll.config</AppConfigPath>
  </Connection>
</Query>

from p in NaitEvents
where p.EntityEventTime > new DateTime(2015, 5, 1)
select new
    {       	
		p
    }