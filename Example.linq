<Query Kind="SQL">
  <Connection>
    <ID>d6f2b19a-ae75-4d4c-a4a4-58aac933ce8e</ID>
    <Persist>true</Persist>
    <Driver>EntityFrameworkDbContext</Driver>
    <CustomAssemblyPath>C:\LIC\dev\Db2Harness\LIC.Db2Harness\bin\Debug\LIC.Db2Harness.dll</CustomAssemblyPath>
    <CustomTypeName>LIC.Db2Harness.Db2Context</CustomTypeName>
    <AppConfigPath>C:\LIC\dev\Db2Harness\LIC.Db2Harness\bin\Debug\App.config</AppConfigPath>
    <DisplayName>DB2 Dev</DisplayName>
  </Connection>
</Query>

SELECT *
FROM FMR_RUN
WHERE id < 100

SELECT *
FROM TP.HERD
fetch first 10 rows only

DELETE FROM DEPARTMENT
WHERE DEPTNO = 'D11'

select h.map_ref, h.herd_num, hdtl.OWNR_PTPT_CD, h.RGN_CD, h.HERD_CD, h.ST_DATE_D, h.END_DATE_D, h.crm_id, hdtl.SR_AREA_SSN, h.END_DATE,
hdtl.HR_RCD_DATE, hdtl.HR_CAN_DATE, hdtl.AB_RCD_DATE, hdtl.AB_CAN_DATE,hdtl.tdm_sps_herd_ind from herd h
join herd_dtl hdtl on hdtl.map_ref = h.map_ref
fetch first 100 row only


select hd.map_ref, hd.herd_num, hd.ownr_ptpt_cd, hd.sr_area_ssn, h.rgn_cd, h.herd_cd, h.crm_id, cp.name, cp.id AS CustomerId
					 from tp.herd h 
					 join tp.herd_dtl hd 
					 on h.map_ref = hd.map_ref 
					 and h.herd_num = hd.herd_num 
					 join tp.curr_pfx_user cpu 
					 on cpu.anml_id_pfx_cd = hd.ownr_ptpt_cd 
					 join tp.curr_party cp 
					 on cp.id = cpu.party_id 
					 where  h.crm_id < 0
					 order by hd.rcd_date_d desc 
					 fetch first 100 row only
					 
select hd.map_ref, hd.herd_num, hd.ownr_ptpt_cd, hd.sr_area_ssn, h.rgn_cd, h.herd_cd, h.crm_id, cp.name, cp.id AS CustomerId
					 from tp.herd h 
					 join tp.herd_dtl hd 
					 on h.map_ref = hd.map_ref 
					 and h.herd_num = hd.herd_num 
					 join tp.curr_pfx_user cpu 
					 on cpu.anml_id_pfx_cd = hd.ownr_ptpt_cd 
					 join tp.curr_party cp 
					 on cp.id = cpu.party_id 
					 where  hd.ownr_ptpt_cd = 'MFBJ'
					 order by hd.rcd_date_d desc 
					 fetch first 100 row only
					 
					 
select *
from tp.pre_mtng_heat
where anml_key = 30554066			 

select r.anml_key 			as DamAnimalKey,
	x.implant_date - 7 days 	as MatingDate,
	r.doc_num 			as EmbryoTransferDocumentId
from tp.embryo_rcpnt r 
	join tp.embryo_xfer x on r.doc_num = x.doc_num
where x.implant_date - 7 days > 		'2016-1-1'
and 	r.anml_key  =      			3055406					 

select * 
from fmr_error as e 
left outer join fmr_insemination as i on i.Guid = e.object_Guid 
where e.fmr_run_id = 172800

SELECT *
FROM nait_error_code

SELECT *
FROM ANML_NAIT_EVENT
WHERE NAIT_RESPONSE_STS_CD = 'F' AND EVENT_TIME > '2015-5-19'

select ne.id, ne.event_time, ne.NAIT_RESPONSE_STS_CD  
from anml_nait_event ne
where ne.NAIT_RESPONSE_STS_CD = 'F'
and ne.EVENT_TIME >= '2015-05-25 00:00:00.000000'
and ne.EVENT_TIME <= '2015-05-25 00:00:00.000000'
order by ne.EVENT_TIME desc

select ANML_GRP_BSNS_PARTNER_NUM
from anml_nait_event ne
where ne.EVENT_TIME >= '2015-05-25 00:00:00.000000'
and ne.EVENT_TIME <= '2015-05-25 00:00:00.000000'
group by ANML_GRP_BSNS_PARTNER_NUM
fetch first 2 rows only

SELECT 
"Limit1".C2 AS C1,
"Limit1".ANML_GRP_BSNS_PARTNER_NUM,
"Limit1".NAIT_RESPONSE_MSG,
"Limit1".C1 AS C2
FROM ( SELECT 
	"GroupBy1".A1 AS C1,
	"GroupBy1".K1 AS ANML_GRP_BSNS_PARTNER_NUM,
	"GroupBy1".K2 AS NAIT_RESPONSE_MSG,
	1 AS C2
	FROM ( SELECT "Extent1".ANML_GRP_BSNS_PARTNER_NUM AS K1, "Extent1".NAIT_RESPONSE_MSG AS K2, Count(1) AS A1
		FROM TP.ANML_NAIT_EVENT "Extent1"
		WHERE ("Extent1".EVENT_TIME >= TIMESTAMP '2015-04-08 00:00:00') AND ("Extent1".EVENT_TIME <= TIMESTAMP '2015-06-09 23:59:59')
		GROUP BY "Extent1".ANML_GRP_BSNS_PARTNER_NUM, "Extent1".NAIT_RESPONSE_MSG
	)  "GroupBy1"
	FETCH FIRST 100 ROWS ONLY
)  "Limit1"


INSERT INTO TP.NAIT_ERR_GRP (NAIT_ERR_ID, ERR_GRP)
     VALUES ('Animal is not at the specified NAIT Number', 1) 


SELECT *
FROM ANML_NAIT_EVENT
WHERE NAIT_RESPONSE_MSG like 'Date of death cannot be less than%'
and NAIT_RESPONSE_MSG != 'Date of death cannot be less than estimated date of birth, missing date, found date, import date or animal registration date'
and EVENT_TIME >= '2010-12-02'
and EVENT_TIME <= '2015-12-04'
order by EVENT_TIME desc	


SELECT *
FROM ANML_NAIT_EVENT
WHERE LIC_SUBMIT_STS_CD = 'S' and NAIT_RESPONSE_MSG != 'NULL' AND NAIT_RESPONSE_MSG != ''

UPDATE ANML_NAIT_EVENT
  SET NAIT_RESPONSE_MSG = 'Animal is not at the specified NAIT Number',
  	  NAIT_ERR_CD = '99321',
	  LIC_SUBMIT_STS_CD = 'S'
  WHERE ID = '334992'
  
SELECT *
FROM ANML_NAIT_EVENT
WHERE ID = '334992'   