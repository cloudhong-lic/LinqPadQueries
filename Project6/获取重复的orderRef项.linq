<Query Kind="Statements">
  <Connection>
    <ID>197e2379-85cf-4d86-be79-3cfb3b0f8c68</ID>
    <Persist>true</Persist>
    <Driver>EntityFrameworkDbContext</Driver>
    <CustomAssemblyPath>C:\LIC\services\SalesOrderManagement\LIC.Services.SalesOrderManagement.Datastore\bin\Debug\LIC.Services.SalesOrderManagement.Datastore.dll</CustomAssemblyPath>
    <CustomTypeName>LIC.Services.SalesOrderManagement.Datastore.AnimalDb2Context</CustomTypeName>
    <AppConfigPath>C:\LIC\services\SalesOrderManagement\LIC.Services.SalesOrderManagement.Datastore\bin\Debug\LIC.Services.SalesOrderManagement.Datastore.dll.config</AppConfigPath>
  </Connection>
</Query>

var q = from order in MindaOrderRef
        group order by order.OrderRef into grp
		where grp.Count() > 1
        select new { key = grp.Key, cnt = grp.Count()};
		
q.Dump();		