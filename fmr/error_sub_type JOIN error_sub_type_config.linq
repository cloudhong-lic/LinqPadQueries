<Query Kind="SQL">
  <Connection>
    <ID>f01ef15f-1531-4bd3-9f09-686488ce8d71</ID>
    <Persist>true</Persist>
    <Driver>EntityFrameworkDbContext</Driver>
    <CustomAssemblyPath>C:\LIC\dev\Db2Harness\LIC.Db2Harness\bin\Debug\LIC.Db2Harness.dll</CustomAssemblyPath>
    <CustomTypeName>LIC.Db2Harness.AccpDb2Context</CustomTypeName>
    <AppConfigPath>C:\LIC\dev\Db2Harness\LIC.Db2Harness\bin\Debug\App.config</AppConfigPath>
    <DisplayName>DB2 Accp</DisplayName>
  </Connection>
</Query>

select 
subType.ID, 
subType.FMR_ERROR_TYPE_CD, 
subType.DESCRIPTION, 
subTypeConfig.ACTION_TYPE_CD, 
subTypeConfig.ACTION_IND,
subTypeConfig.ST_DATE,
subTypeConfig.END_DATE
--subType.PROCESSING_ACTION_IND,
--subType.PROCESS_MATING_ACTION_IND,
--subType.ERROR_DESTINATION_CD,
from TP.FMR_ERROR_SUB_TYPE as subType
left outer join TP.FMR_ERROR_SUB_TYPE_CONFIG as subTypeConfig on (subType.ID = subTypeConfig.FMR_ERROR_SUB_TYPE_ID)
--where 
--FMR_ERROR_TYPE_CD = 'H' and ID = 4
--PAYMENT_ACTION_IND = 'Y' and BILLING_ACTION_IND = 'Y' and PROCESS_MATING_ACTION_IND = 'Y'
order by ID --desc