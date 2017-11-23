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

var q = (from herd in Herds
where herd.MapReference == "N066294450" && herd.HerdNumber == 2
select herd.BpNumber).FirstOrDefault();

q.Dump();