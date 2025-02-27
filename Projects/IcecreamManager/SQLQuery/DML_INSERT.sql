---- .Utility
-- ID seed 초기화
--save

delete from TmpProduct;

INSERT INTO TmpProduct
([pro_No], [pro_Name], [mat_No], [pro_Price], [pro_Img])
SELECT [pro_No], [pro_Name], [mat_No], [pro_Price], [pro_Img]
FROM Product

------------------------------------------------------------------------------Delete All and Set Identity

delete from Customer_Order_Detail
delete from Customer_Order
delete from BOM
delete from Product
delete from Offerer_Order
delete from Offerer
delete from CompleteType
delete from Customer
delete from Materials 
delete from Materials_Type

dbcc checkident(CompleteType, reseed, 0)
dbcc checkident(Materials_Type, reseed, 0)
dbcc checkident(Product, reseed, 999)
dbcc checkident(Materials, reseed, 1999)
dbcc checkident(Offerer, reseed, 2999)
dbcc checkident(Customer, reseed, 4999)
dbcc checkident(Offerer_Order, reseed, 3999)
------------------------------------------------------------------------------Offerer
-- select Offerer
SELECT TOP (1000) [off_No]
      ,[off_Name]
      ,[off_OwnerName]
      ,[off_OwnerMobile]
      ,[off_Manager]
      ,[off_ManagerMobile]
      ,[off_Addr]
  FROM [TEAM4].[dbo].[Offerer]
  
DELETE FROM Offerer;

-- insert Offerer
insert into Offerer 
(off_Name,		off_OwnerName,	off_OwnerMobile,			off_Manager,	off_ManagerMobile,			off_Addr	  )
values
(	'티라유텍'		,'김정하'			,'010-1111-1111'			,'심은주'		,'010-2222-2222'				,'서울 강남구'			  )
,(	'티라링'		,'조원철'			,'010-3333-3333'			,'이정철'		,'010-4444-4444'				,'서울 강남구'			  )
,(	'디투엘'			,'김길동'			,'010-5555-5555'			,'장길동'		,'010-6666-6666'				,'경기도 수원'			  )
,(	'엑센 솔루션'	,'파이썬'			,'010-7777-7777'			,'이승찬'		,'010-8888-8888'				,'서울 구로구'			  )
,(	'빅데이터'		,'이상한'			,'010-9999-9999'			,'정명훈'		,'010-1010-1010'				,'울산 남구'			  )
,(	'아리랑'			,'김아리'			,'010-3434-3434'			,'강아리'		,'010-4545-4545'				,'경기도 파주'			  )




------------------------------------------------------------------------------Materials_Type
-- Select Materials_Type
SELECT TOP (1000) [mtt_No]
      ,[mtt_Name]
 FROM [TEAM4].[dbo].[Materials_Type]

-- insert table Materials_Type
insert into Materials_Type(mtt_Name) 
values ('완제품'), ('반제품'),('원재료')


-------------------------------------------------------------------------------Materials
-- Select Materials
SELECT TOP (1000) [mat_No]
      ,[mtt_No]
      ,[off_No]
      ,[mat_Name]
      ,[mat_Cost]
      ,[mat_Each]
      ,[mat_MinSize]
      ,[mat_Unit]
  FROM [TEAM4].[dbo].[Materials]
-- truncate table Materials
insert into Materials 
(mtt_No,	off_No,	 mat_Name,	mat_Cost,	mat_Each,	mat_MinSize, mat_Unit)
values
 (3	,	3000,	'콘'				,	100,	10,	30, 'E')
,(2	,	3001,	'딸기시럽'		,	100,	10,	30, 'ml')
,(2	,	3002,	'초코시럽'		,	100,	10,	30, 'ml')
,(2	,	3003,	'바닐라시럽'	,	100,	10,	30, 'ml')
,(2	,	3004,	'녹차시럽'		,	100,	10,	30, 'ml')
,(2	,	3005,	'카라멜시럽'	,	100,	10,	30, 'ml')
,(1, null, '그린티 아이스크림', 1500, 0, 10, 'E')
,(1, null, '뉴욕 치즈케이크 아이스크림', 1500, 0, 10, 'E')
,(1, null, '레인보우 샤베트 아이스크림', 1500, 0, 10, 'E')
,(1, null, '민트 초콜릿 칩 아이스크림', 1500, 0, 10, 'E')
,(1, null, '바닐라 아이스크림', 1500, 0, 10, 'E')
,(1, null, '슈팅스타 아이스크림', 1500, 0, 10, 'E')
,(1, null, '자모카 아몬드 훠지 아이스크림', 1500, 0, 10, 'E')
,(1, null, '체리쥬빌레 아이스크림', 1500, 0, 10, 'E')
,(1, null, '초콜릿 무스 아이스크림', 1500, 0, 10, 'E')
,(1, null, '초콜릿 아이스크림', 1500, 0, 10, 'E')
,(3, 3000, '우유', 1500, 100000, 10000, 'ml')
,(3, 3000, '생크림', 1500, 100000, 10000, 'ml')
,(3, 3000, '바닐라익스트랙 ', 1500, 550, 500, 'ml')
,(3, 3000, '설탕', 1500, 100000, 10000, 'g')
,(3, 3000, '크림치즈', 1500, 800, 500, 'g')
,(3, 3000, '플레인 요거트', 1500, 800, 500, 'g')

,(3, 3001, '체리', 1500, 500, 50, 'g')
,(3, 3001, '체리시럽', 1500, 550, 550, 'g')
,(3, 3001, '붉은 식용 색소', 1500, 600, 500, 'ml')

,(3, 3003, '녹차파우더', 1500, 10000, 1000, 'g')
insert into Materials 
(mtt_No,	off_No,	 mat_Name,	mat_Cost,	mat_Each,	mat_MinSize, mat_Unit)
values
(3, 3003, '계란 노른자', 1500, 800, 500, 'g')



------------------------------------------------------------------------------Customer
-- select Customer
SELECT TOP (1000) [cus_No]
      ,[cus_Id]
      ,[cus_Password]
      ,[cus_Name]
      ,[cus_Phone]
      ,[cus_Addr]
      ,[cus_Email]
      ,[IsManager]
  FROM [TEAM4].[dbo].[Customer]
  
 -- insert Customer
insert into Customer
(cus_Id,cus_Password,cus_Name,cus_Phone,cus_Addr,cus_Email,IsManager )
values
('qwe'	,'qwe'		,'반고흐'				,'010-1111-1111'	,		'서울 강남구'		,'qwe@gmail.com'	,1			     )
,('asd'	,'asd'		,'김기리'				,'010-2222-2222'	,		'서울 구로구'		,'asd@gmail.com'		,0			     )
,('zxc'	,'zxc'	  		,'도라희'				,'010-3333-3333'	,		'경기도 광명시'	,'zxc@gmail.com'		,0			     )
,('rty'	,'rty'	  		,'땡칠이'				,'010-4444-4444'	,		'울산 남구'			,'rty@gmail.com'		,0			     )
,('fgh'	,'fgh'		,'송아지'				,'010-5555-5555'	,		'부산 서구'			,'fgh@gmail.com'		,0			     )


------------------------------------------------------------------------------CompleteType
SELECT TOP (1000) [cmt_No]
      ,[cmt_Type]
  FROM [TEAM4].[dbo].[CompleteType]
  
  insert into CompleteType (cmt_Type)
  values
  ('발주완료')
  ,('배송중')
  ,('배송완료')
  ,('발주')

 
------------------------------------------------------------------------------Product
SELECT TOP (1000) [mat_No]
      ,[mtt_No]
      ,[off_No]
      ,[mat_Name]
      ,[mat_Cost]
      ,[mat_Each]
      ,[mat_MinSize]
  FROM [TEAM4].[dbo].[Materials]

SELECT TOP (1000) [pro_No]
      ,[pro_Price]
      ,[pro_Name]
      ,[pro_Img]
      ,[mat_No]
  FROM [TEAM4].[dbo].[Product]
 
 INSERT INTO Product
( [pro_Name], [mat_No], [pro_Price], [pro_Img])
SELECT  [pro_Name], [mat_No], [pro_Price], [pro_Img]
FROM TmpProduct

 -- insert into Product(pro_Price, pro_Name, pro_Img, mat_No)
 -- values
 -- (1500, '그린티 아이스크림',null, 2006)
 --, (1500, '뉴욕 치즈케이크 아이스크림', null, 2007)
 --, (1500, '레인보우 샤베트 아이스크림', null, 2008)
 --, (1500, '민트 초콜릿 칩 아이스크림', null, 2009)
 --, (1500, '바닐라 아이스크림', null, 2010)
 --, (1500, '슈팅스타 아이스크림', null, 2011)
 --, (1500, '자모카 아몬드 훠지 아이스크림', null, 2012)
 --, (1500, '체리쥬빌레 아이스크림', null, 2013)
 --, (1500, '초콜릿 무스 아이스크림', null, 2014)
 --, (1500, '초콜릿 아이스크림', null, 2015)


 
------------------------------------------------------------------------------Customer_Order
SELECT TOP (1000) [cuo_No]
      ,[cus_No]
      ,[cuo_Datetime]
      ,[cuo_TotalPrice]
  FROM [TEAM4].[dbo].[Customer_Order]

------------------------------------------------------------------------------BOM
SELECT TOP (1000) [mat_No]
      ,[mtt_No]
      ,[off_No]
      ,[mat_Name]
      ,[mat_Cost]
      ,[mat_Each]
      ,[mat_MinSize]
  FROM [TEAM4].[dbo].[Materials]
SELECT TOP (1000) [mat_ParentNo]
      ,[mat_ChildNo]
      ,[bom_ChildEach]
	  ,[bom_ChildUnit]
  FROM [TEAM4].[dbo].[BOM]

 SELECT m.mat_No, m.mat_Name, m.mat_Cost, m.mat_Each, m.mtt_No, m.off_No, m.mat_MinSize, mat_ParentNo, mat_ChildNo, bom_ChildEach
 FROM BOM b 
	RIGHT OUTER JOIN Materials m ON b.mat_ChildNo = m.mat_No 

insert into BOM (mat_ParentNo, mat_ChildNo, bom_ChildEach, bom_ChildUnit)
values
(2006, 2000, 1, 'E'),
(2007, 2000, 1, 'E'),
(2008, 2000, 1, 'E'),
(2009, 2000, 1, 'E'),
(2010, 2000, 1, 'E'),
(2015, 2002, 10,'ml'),
(2008, 2001, 1,'ml'),
(2008, 2002, 1,'ml'),
(2009, 2003, 1,'ml'),
(2010, 2003, 1,'ml'),
(2011, 2003, 1,'ml'),
(2012, 2003, 1,'ml'),
(2013, 2003, 1,'ml'),
(2014, 2003, 1,'ml'),
(2015, 2003, 1,'ml')
;



------------------------------------------------------------------------------OFFERER ORDER
insert into Offerer_Order (ofo_Each,	mat_No,	off_No,	cmt_No,	ofo_Price,	ofo_Date)
values

(	108,	2000,	3000,	1,	10800  	,2019-12-12			)
,(	112,	2001,	3001,	1,	11200  	,2019-12-12 			)
,(	624,	2000,	3000,	4,	62400  	,2019-12-12 			)
,(	107,	2018,	3000,	4,	160500	,2019-12-12 		)
,(	108,	2021,	3000,	4,	162000	,2019-12-12 		)
,(	102,	2020,	3000,	3,	153000	,2019-12-12 		)
,(	307,	2023,	3001,	4,	460500	,2019-12-12 		)
,(	204,	2017,	3000,	4,	306000	,2019-12-12 		)
,(	107,	2000,	3000,	4,	10700	    ,2019-12-12 			)
,(	114,	2024,	3001,	4,	171000	,2019-12-12 		)
,(	118,	2017,	3000,	4,	177000	,2019-12-12 		)


