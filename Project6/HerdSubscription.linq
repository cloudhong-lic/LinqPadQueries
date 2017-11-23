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

//var orderReference = "a3e0e56ef5cd4c138a713e2277f71420";
var mapRef = "N011423650";
var herdNumber = 1;

var bpNumber = (from herd in Herds
where herd.MapReference == mapRef && herd.HerdNumber == herdNumber
select herd.BpNumber).FirstOrDefault();

bpNumber.Dump();

var q = (from order in MindaOrderRef
join herd in Herds on new { order.MapReference, order.HerdNumber } equals new { herd.MapReference, herd.HerdNumber }
where herd.BpNumber.Trim() == bpNumber.Trim()
select new {
		BpNumber = herd.BpNumber,
		MapReference = order.MapReference, 
		HerdNumber = order.HerdNumber,
		OrderRef = order.OrderRef,
		StartDate = order.StartDate,
		EndDate = order.EndDate
	});

q.Dump();