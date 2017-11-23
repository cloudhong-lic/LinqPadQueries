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

var q = from c in NaitEvents
where c.EntityEventTime > new DateTime(2015, 5, 1) && c.EntityEventTime < new DateTime(2015, 6, 1)
group c by c.AnimalGroupBpNumber into g
select new 
    {       	
		AnimalGroupBpNumber = g.Key.Trim(),
		Count = g.Count(),
		
		subGroups = (from c in g
        //group c by c.ResponseMessage into g2
		//where c.ResponseMessage == null
        select new
		{ 
			//g2.Key
			//c
			ResponseMessage = c.ResponseMessage.Trim()  
		})
    };
	
q.Dump();