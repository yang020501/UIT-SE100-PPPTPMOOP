Create database HoKhau
Use HoKhau

Create table UserRole
(
	Id int identity(1,1) primary key,
	NameRole varchar(50)
)
go

Create table Users
(
	Id int identity(1000,1) primary key,
	Username varchar(100),
	Password varchar(max),
	Tier int,
	Name varchar(100),
	DateOfBirth date,
	Sex Bit,
	IdentityNum varchar(12),
	
	foreign key (Tier) references UserRole(Id)
)
go

Create table Population
(
	Stt int identity(1,1),
	Id varchar(12) primary key,
	Name varchar(100),
	Id_Household varchar(5),
	PlaceOfBirth varchar(500),
	Address varchar(500),
	DateOfBirth date,
	Sex bit,
	Relegion varchar(100),
	Career varchar(200),
	isAbsence bit Default(0),
	isTResidence bit Default(0),

)
go

Create table Household_Registration
(
	Stt int identity(1,1),
	Id varchar(5) primary key,
	IdOfOwner varchar(12),
	NameOfOwner varchar(100),
	Address varchar(max),

	foreign key (IdOfOwner) references Population(Id)	
)
go

alter table Population add constraint Fk_Id_Household_w_Id  foreign key (Id_Household) references Household_Registration(Id)

Create table Family_Household
(
	Id_Household varchar(5),
	Id_Owner varchar(12),
	Id_Person varchar(12),
	Name_Person varchar(100),

	constraint Pk_Family_Household Primary key (Id_Household, Id_Owner, Id_Person),
	foreign key (Id_Household) references Household_Registration(Id),
	foreign key (Id_Owner) references Population(Id),
	foreign key (Id_Person) references Population(Id),
	
)
go


Create table Temporary_Absence
(
	Stt int identity(1,1),
	Id varchar(5) primary key,
	Id_Owner varchar(12),
	NameOfOwner varchar(100),
	Id_Household varchar(5),
	HouseOwnerName varchar(100),		
	CreateDate date,
	ExpireDate date,

	foreign key (Id_Owner) references Population(Id),
	foreign key (Id_Household) references Household_Registration(Id),
	
	constraint CreateDate_w_ExpireDate Check (CreateDate < ExpireDate)
)
go

Create table Temporary_Residence
(
	Stt int identity(1,1),
	Id varchar(5) primary key,
	Id_Owner varchar(12),
	NameOfOwner varchar(100),
	Id_Household varchar(5),
	HouseOwnerName varchar(100),	
	PAddress varchar(max),
	TAddress varchar(max),
	CreateDate date,
	ExpireDate date,

	foreign key (Id_Owner) references Population(Id),
	foreign key (Id_Household) references Household_Registration(Id),

	constraint CreateDate_w_ExpireDatex Check (CreateDate < ExpireDate)
)
go

Create table Transfer_Household
(
	Stt int identity(1,1),
	Id varchar(5) primary key,
	Id_Owner varchar(12),	
	CreateDate date,
	Id_Household varchar(5),
	Old_Address varchar(max),
	New_Address varchar(max),

	foreign key (Id_Owner) references Population(Id),
	foreign key (Id_Household) references Household_Registration(Id),
)
go


insert into UserRole(NameRole) values ('Manager')
insert into UserRole(NameRole) values ('Employee')

insert into Users(Username, Password, Tier, Name, DateOfBirth, Sex, IdentityNum) values('DUONG1', 'ZHVvbmcxMjM=', '2', 'Nguyen Hoang Thai Duong', '2001-03-14', '1', '564502310213')
insert into Users(Username, Password, Tier, Name, DateOfBirth, Sex, IdentityNum) values('DUY1', 'ZHVvbmcxMjM=', '2', 'Nguyen Au Duy', '2001-04-11', '1', '785420057035')
insert into Users(Username, Password, Tier, Name, DateOfBirth, Sex, IdentityNum) values('ADMIN', 'YWRtaW4=', '1', 'Admin', '2021-09-05', '1', '000000000000')
insert into Users(Username, Password, Tier, Name, DateOfBirth, Sex, IdentityNum) values('MANAGER', 'bWFuYWdlcjEyMw==', '1', 'Diabolic Esper', '2099-01-15', '1', '101010101010')

