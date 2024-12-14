USE [master]
Go 

CREATE DATABASE nonkDB 
Go 

USE nonkDB
Go 

If OBJECT_ID('Users') IS NOT NULL 
Drop table Users
Go 

If OBJECT_ID('Investments') IS NOT NULL 
Drop table Investments 
Go

If OBJECT_ID('Skills') IS NOT NULL
Drop table Skills 
Go

if OBJECT_ID('Missions') IS NOT NULL 
Drop table Missions 
Go

If OBJECT_ID('Codes') IS NOT NULL 
Drop table Codes
Go 


Create table Users 
(
	[UserId] tinyint constraint pk_UserId Primary key Identity,
	[UserName] Varchar(20) constraint  uq_UserName Unique,
	[Password] varchar(15) NOT NULL,
	[Age] tinyint constraint chk_Age CHECK(Age>22) NOT NULL,
	[Gender] char constraint chk_Gender CHECK(Gender='M' OR Gender='F') NOT NULL,
	[EmailId] varchar(30) constraint chk_EmailId Check(EmailId Like '%@gmail.com') NoT null,
	[PhoneNumber] NUMERIC(10) NOT NULL  ,
	[DateOfBirth] date constraint chk_DateOfBirth Check(DateOfBirth<GETDATE()) NOT NULL
)
GO 

set identity_insert  Users off
insert into Users
values('Rekhanth','Abbulu$23',24,'M','rekhanthms23@gmail.com',9381546533,'2000-03-23')

select * from Users

update Users
set UserName = 'AgentR' where UserId=1

Create table Skills
(
	--[UserName] Varchar(20) constraint pk_UserName Primary key,
	[SkillId] tinyint constraint pk_SkillId Primary key Identity,
	[UserName] Varchar(20) constraint  fk_UserName REFERENCES  Users(UserName),
	[Grade] tinyint constraint chk_Grade check(Grade >5.0) NOT NULL,
	[Qualification] Varchar(10) Not null ,
	[Specialization] varchar(55) not null 
)
Go 

set identity_insert Skills OFF
 insert into Skills 
 values('AgentR',6.0,'B.E','Quick Learner')

 select * from Skills

Create table Investments 
(
	[UserName] Varchar(20) constraint pk_UserName Primary key,
	[InvestmentAmount] decimal(10,2) constraint chk_InvestmentAmount Check([InvestmentAmount]>0.0),
	[Entity] varchar(55) not null ,
	[Assets] varchar(55) not null,
	[liabilities] varchar(55) not null
)
Go 

insert into Investments
values('AgentR',427.95,'Stock Market','Stocks','Loans')

select * from Investments



Create table Codes 
(
	[CodeNames] varchar(10) constraint pk_CodeNames Primary key,
	[Codewords] varchar(10) not null,
	[UserName] Varchar(20) constraint  fk_UserName1 REFERENCES  Users(UserName),
	[Area] varchar(10) not null 
)
Go 

insert into Codes
values('Vrukah','Thelidhu','AgentR','Ecity')

select * from Codes

drop table Missions

Create table Missions
(
	[MissionCode] numeric(7) constraint pk_MissionCode Primary key  Identity(10070,1),
	[UserName] Varchar(20) constraint  fk_UserName2 REFERENCES  Investments(UserName),
	[NoOfMissions] numeric(4) Not null, 
	[Status] varchar(1000) not null
)
Go 

alter table Missions
 
insert into Missions
values( 'AgentR','1','created DB from NONK')

select * from Missions




	