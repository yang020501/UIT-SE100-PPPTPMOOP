USE [master]
GO
/****** Object:  Database [HoKhau]    Script Date: 11/25/2021 7:01:40 PM ******/
CREATE DATABASE [HoKhau]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HoKhau', FILENAME = N'D:\SQL Sever\MSSQL15.MSSQLSERVER\MSSQL\DATA\HoKhau.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HoKhau_log', FILENAME = N'D:\SQL Sever\MSSQL15.MSSQLSERVER\MSSQL\DATA\HoKhau_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [HoKhau] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HoKhau].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HoKhau] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HoKhau] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HoKhau] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HoKhau] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HoKhau] SET ARITHABORT OFF 
GO
ALTER DATABASE [HoKhau] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HoKhau] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HoKhau] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HoKhau] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HoKhau] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HoKhau] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HoKhau] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HoKhau] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HoKhau] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HoKhau] SET  ENABLE_BROKER 
GO
ALTER DATABASE [HoKhau] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HoKhau] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HoKhau] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HoKhau] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HoKhau] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HoKhau] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HoKhau] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HoKhau] SET RECOVERY FULL 
GO
ALTER DATABASE [HoKhau] SET  MULTI_USER 
GO
ALTER DATABASE [HoKhau] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HoKhau] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HoKhau] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HoKhau] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HoKhau] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HoKhau] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'HoKhau', N'ON'
GO
ALTER DATABASE [HoKhau] SET QUERY_STORE = OFF
GO
USE [HoKhau]
GO
/****** Object:  Table [dbo].[Family_Household]    Script Date: 11/25/2021 7:01:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Family_Household](
	[Id_Household] [varchar](5) NOT NULL,
	[Id_Owner] [varchar](12) NOT NULL,
	[Id_Person] [varchar](12) NOT NULL,
	[Name_Person] [nvarchar](100) NULL,
 CONSTRAINT [Pk_Family_Household] PRIMARY KEY CLUSTERED 
(
	[Id_Household] ASC,
	[Id_Owner] ASC,
	[Id_Person] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Household_Registration]    Script Date: 11/25/2021 7:01:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Household_Registration](
	[Stt] [int] IDENTITY(1,1) NOT NULL,
	[Id] [varchar](5) NOT NULL,
	[IdOfOwner] [varchar](12) NULL,
	[NameOfOwner] [nvarchar](100) NULL,
	[Address] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Population]    Script Date: 11/25/2021 7:01:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Population](
	[Stt] [int] IDENTITY(1,1) NOT NULL,
	[Id] [varchar](12) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Photo] [varchar](max) NULL,
	[Id_Household] [varchar](5) NULL,
	[PlaceOfBirth] [nvarchar](500) NULL,
	[Address] [nvarchar](500) NULL,
	[DateOfBirth] [date] NULL,
	[Sex] [bit] NULL,
	[Relegion] [nvarchar](100) NULL,
	[Career] [nvarchar](200) NULL,
	[isAbsence] [bit] NULL,
	[isTResidence] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Temporary_Absence]    Script Date: 11/25/2021 7:01:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Temporary_Absence](
	[Stt] [int] IDENTITY(1,1) NOT NULL,
	[Id] [varchar](5) NOT NULL,
	[Id_Owner] [varchar](12) NULL,
	[NameOfOwner] [nvarchar](100) NULL,
	[Id_Household] [varchar](5) NULL,
	[HouseOwnerName] [nvarchar](100) NULL,
	[CreateDate] [date] NULL,
	[ExpireDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Temporary_Residence]    Script Date: 11/25/2021 7:01:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Temporary_Residence](
	[Stt] [int] IDENTITY(1,1) NOT NULL,
	[Id] [varchar](5) NOT NULL,
	[Id_Owner] [varchar](12) NULL,
	[NameOfOwner] [nvarchar](100) NULL,
	[Id_Household] [varchar](5) NULL,
	[HouseOwnerName] [nvarchar](100) NULL,
	[PAddress] [nvarchar](max) NULL,
	[TAddress] [nvarchar](max) NULL,
	[CreateDate] [date] NULL,
	[ExpireDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transfer_Household]    Script Date: 11/25/2021 7:01:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transfer_Household](
	[Stt] [int] IDENTITY(1,1) NOT NULL,
	[Id] [varchar](5) NOT NULL,
	[Id_Owner] [varchar](12) NULL,
	[CreateDate] [date] NULL,
	[Id_Household] [varchar](5) NULL,
	[Old_Address] [nvarchar](max) NULL,
	[New_Address] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 11/25/2021 7:01:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NameRole] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/25/2021 7:01:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1000,1) NOT NULL,
	[Username] [varchar](100) NULL,
	[Password] [varchar](max) NULL,
	[Tier] [int] NULL,
	[Name] [nvarchar](100) NULL,
	[PhotoUser] [varchar](max) NULL,
	[DateOfBirth] [date] NULL,
	[Sex] [bit] NULL,
	[IdentityNum] [varchar](12) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Population] ADD  DEFAULT ((0)) FOR [isAbsence]
GO
ALTER TABLE [dbo].[Population] ADD  DEFAULT ((0)) FOR [isTResidence]
GO
ALTER TABLE [dbo].[Family_Household]  WITH CHECK ADD FOREIGN KEY([Id_Household])
REFERENCES [dbo].[Household_Registration] ([Id])
GO
ALTER TABLE [dbo].[Family_Household]  WITH CHECK ADD FOREIGN KEY([Id_Owner])
REFERENCES [dbo].[Population] ([Id])
GO
ALTER TABLE [dbo].[Family_Household]  WITH CHECK ADD FOREIGN KEY([Id_Person])
REFERENCES [dbo].[Population] ([Id])
GO
ALTER TABLE [dbo].[Household_Registration]  WITH CHECK ADD FOREIGN KEY([IdOfOwner])
REFERENCES [dbo].[Population] ([Id])
GO
ALTER TABLE [dbo].[Population]  WITH CHECK ADD  CONSTRAINT [Fk_Id_Household_w_Id] FOREIGN KEY([Id_Household])
REFERENCES [dbo].[Household_Registration] ([Id])
GO
ALTER TABLE [dbo].[Population] CHECK CONSTRAINT [Fk_Id_Household_w_Id]
GO
ALTER TABLE [dbo].[Temporary_Absence]  WITH CHECK ADD FOREIGN KEY([Id_Household])
REFERENCES [dbo].[Household_Registration] ([Id])
GO
ALTER TABLE [dbo].[Temporary_Absence]  WITH CHECK ADD FOREIGN KEY([Id_Owner])
REFERENCES [dbo].[Population] ([Id])
GO
ALTER TABLE [dbo].[Temporary_Residence]  WITH CHECK ADD FOREIGN KEY([Id_Household])
REFERENCES [dbo].[Household_Registration] ([Id])
GO
ALTER TABLE [dbo].[Temporary_Residence]  WITH CHECK ADD FOREIGN KEY([Id_Owner])
REFERENCES [dbo].[Population] ([Id])
GO
ALTER TABLE [dbo].[Transfer_Household]  WITH CHECK ADD FOREIGN KEY([Id_Household])
REFERENCES [dbo].[Household_Registration] ([Id])
GO
ALTER TABLE [dbo].[Transfer_Household]  WITH CHECK ADD FOREIGN KEY([Id_Owner])
REFERENCES [dbo].[Population] ([Id])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([Tier])
REFERENCES [dbo].[UserRole] ([Id])
GO
ALTER TABLE [dbo].[Temporary_Absence]  WITH CHECK ADD  CONSTRAINT [CreateDate_w_ExpireDate] CHECK  (([CreateDate]<[ExpireDate]))
GO
ALTER TABLE [dbo].[Temporary_Absence] CHECK CONSTRAINT [CreateDate_w_ExpireDate]
GO
ALTER TABLE [dbo].[Temporary_Residence]  WITH CHECK ADD  CONSTRAINT [CreateDate_w_ExpireDatex] CHECK  (([CreateDate]<[ExpireDate]))
GO
ALTER TABLE [dbo].[Temporary_Residence] CHECK CONSTRAINT [CreateDate_w_ExpireDatex]
GO

SET IDENTITY_INSERT [dbo].[UserRole] ON 
INSERT [dbo].[UserRole] ([NameRole]) VALUES ('Manager')
INSERT [dbo].[UserRole] ([NameRole]) VALUES ('Employee')
SET IDENTITY_INSERT [dbo].[UserRole] OFF
GO

SET IDENTITY_INSERT [dbo].[Users] ON
INSERT [dbo].Users ([Username], [Password], [Tier], [Name], [DateOfBirth], [Sex], [IdentityNum]) VALUES ('DUONG1', 'ZHVvbmcxMjM=', '2', N'Nguyễn Hoàng Thái Dương', '2001-03-14', '1', '564502310213')
INSERT [dbo].Users ([Username], [Password], [Tier], [Name], [DateOfBirth], [Sex], [IdentityNum]) VALUES ('DUY1', 'ZHVvbmcxMjM=', '2', N'Nguyễn Âu Duy', '2001-04-11', '1', '785420057035')
INSERT [dbo].Users ([Username], [Password], [Tier], [Name], [DateOfBirth], [Sex], [IdentityNum]) VALUES ('ADMIN', 'YWRtaW4=', '1', 'Admin', '2021-09-05', '1', '000000000000')
INSERT [dbo].Users ([Username], [Password], [Tier], [Name], [DateOfBirth], [Sex], [IdentityNum]) VALUES ('MANAGER', 'bWFuYWdlcjEyMw==', '1', 'Diabolic Esper', '2099-01-15', '1', '101010101010')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO

SET IDENTITY_INSERT [dbo].[Population] ON
INSERT [dbo].Population (Id, Name, DateOfBirth, PlaceOfBirth, Sex, Relegion, Career) VALUES ('445577249830', N'Lê Trọng Nhân', '2001-01-25', N'TP Hồ Chí Minh', '1', 'Christianity', 'Teacher')
INSERT [dbo].Population (Id, Name, DateOfBirth, PlaceOfBirth, Sex, Relegion, Career) VALUES ('398807346472', N'Lương Thành Long', '1987-05-14', N'TP Hồ Chí Minh', '1', 'Budha', 'Student')
INSERT [dbo].Population (Id, Name, DateOfBirth, PlaceOfBirth, Sex, Relegion, Career) VALUES ('393650225257', N'Nguyễn Thành Nam', '1995-12-20', N'TP Đà Nẵng', '1', 'Budha', 'Graphic Designer')
INSERT [dbo].Population (Id, Name, DateOfBirth, PlaceOfBirth, Sex, Relegion, Career) VALUES ('288341482322', 'Abra Freezor', '1914-11-13', 'Senneterre', '1', 'Christianity', 'Software Engineer II')
INSERT [dbo].Population (Id, Name, DateOfBirth, PlaceOfBirth, Sex, Relegion, Career) VALUES ('969687522747', 'Berty Massey', '2001-01-25', 'Gandapura', '0', 'Christianity', 'Statistician II')
INSERT [dbo].Population (Id, Name, DateOfBirth, PlaceOfBirth, Sex, Relegion, Career) VALUES ('270987964659', 'Harold Pinke', '1978-04-17', 'La Palma', '1', 'Christianity', 'Structural Engineer')
INSERT [dbo].Population (Id, Name, DateOfBirth, PlaceOfBirth, Sex, Relegion, Career) VALUES ('645812284406', N'Lê Phương Linh', '2005-01-30', N'TP Bình Dương', '0', 'Christianity', 'Systems Administrator II')
INSERT [dbo].Population (Id, Name, DateOfBirth, PlaceOfBirth, Sex, Relegion, Career) VALUES ('327687535047', N'Vương Minh Nhi', '1999-05-15', N'Long An', '0', 'Budha', 'Pharmacist')
INSERT [dbo].Population (Id, Name, DateOfBirth, PlaceOfBirth, Sex, Relegion, Career) VALUES ('219575051297', 'Elyssa Snawdon', '1983-10-10', 'Lodon', '0', 'Christianity', 'Executive Secretary')
INSERT [dbo].Population (Id, Name, DateOfBirth, PlaceOfBirth, Sex, Relegion, Career) VALUES ('881681367233', 'Betti Tuvey', '2001-09-26', 'Hetou', '0', 'Budha', 'Occupational Therapist')
SET IDENTITY_INSERT [dbo].[Population] OFF
GO
insert into Population(Id, Name, PlaceOfBirth, Address, DateOfBirth, Sex, Relegion, Career) values('445577249830', 'Abra Freezor', 'Senneterre', '0937 Bayside Center', '11/13/2001' ,'1' ,'Christianity' ,'Graphic Designer')
insert into Population(Id, Name, PlaceOfBirth, Address, DateOfBirth, Sex, Relegion, Career) values('398807346472', 'Corby Ingraham', 'Mayakovski', '41 Kipling Crossing' ,'1/26/1958' ,'0' ,'Christianity', 'Software Engineer II')
insert into Population(Id, Name, PlaceOfBirth, Address, DateOfBirth, Sex, Relegion, Career) values('288341482322', 'Mommy Benyan', 'Kumane', '95674 Corscot Pass' ,'6/19/1988' ,'1' ,'Budha', 'Occupational Therapist')
insert into Population(Id, Name, PlaceOfBirth, Address, DateOfBirth, Sex, Relegion, Career) values('969687522747', 'Kristel Orrell', 'Shiojiri', '26 Hermina Road' ,'8/6/1978' ,'1' ,'Budha', 'Sales Representative')
insert into Population(Id, Name, PlaceOfBirth, Address, DateOfBirth, Sex, Relegion, Career) values('840094038854', 'Elyssa Snawdon', 'Gandapura', '2928 East Way' ,'2/21/1985' ,'0' ,'None', 'Occupational Therapist')
insert into Population(Id, Name, PlaceOfBirth, Address, DateOfBirth, Sex, Relegion, Career) values('270987964659', 'Drew Falconbridge', 'Brokopondo', '6122 Monument Avenue' ,'4/13/2002' ,'1' ,'Christianity', 'Executive Secretary')
insert into Population(Id, Name, PlaceOfBirth, Address, DateOfBirth, Sex, Relegion, Career) values('709532487783', 'Cyndie Costell', 'Jeminay', '4 Meadow Vale Way' ,'3/5/1999' ,'0' ,'Christianity', 'Compensation Analyst')
insert into Population(Id, Name, PlaceOfBirth, Address, DateOfBirth, Sex, Relegion, Career) values('684398172813', 'Betti Tuvey', 'Veracruz', '990 Browning Terrace' ,'9/30/1989' ,'1' ,'None', 'Administrative Assistant III')
insert into Population(Id, Name, PlaceOfBirth, Address, DateOfBirth, Sex, Relegion, Career) values('484322022659', 'Kevin Bollon', 'Bakung Utara', '86 Sachtjen Road' ,'12/25/2000' ,'1' ,'None', 'Financial Advisor')
insert into Population(Id, Name, PlaceOfBirth, Address, DateOfBirth, Sex, Relegion, Career) values('858767781011', 'Enrique O Moylan', 'Hetou', '0311 Reinke Pass' ,'6/10/1968' ,'0' ,'Christianity', 'Quality Engineer')

insert into Household_Registration (Id, IdOfOwner, NameOfOwner, Address) values ('K4785', '445577249830', 'Abra Freezor', '0937 Bayside Center')
insert into Household_Registration (Id, IdOfOwner, NameOfOwner, Address) values ('T6789', '398807346472', 'Corby Ingraham', '41 Kipling Crossing')
insert into Household_Registration (Id, IdOfOwner, NameOfOwner, Address) values ('A4231', '288341482322', 'Mommy Benyan', '95674 Corscot Pass')
insert into Household_Registration (Id, IdOfOwner, NameOfOwner, Address) values ('D1332', '709532487783', 'Cyndie Costell', '4 Meadow Vale Way')

insert into Transfer_Household (Id, Id_Owner, CreateDate, Id_Household, Old_Address, New_Address) values ('F7621', '445577249830', '2020-10-18', 'K4785' ,'1548 Fragen' ,'0937 Bayside Center')
insert into Transfer_Household (Id, Id_Owner, CreateDate, Id_Household, Old_Address, New_Address) values ('K5124', '398807346472', '2021-12-10', 'T6789' ,'10 Animal Crossing' ,'40 Kipling Crossing')


insert into Temporary_Residence (Id, Id_Owner, NameOfOwner, Id_Household, HouseOwnerName, PAddress, TAddress, CreateDate, ExpireDate) values ('V4555', '858767781011', 'Enrique O Moylan' ,'D1332', 'Cyndie Costell', '0311 Reinke Pass', '4 Meadow Vale Way', '2020-4-19', '2023-4-19')
insert into Temporary_Residence (Id, Id_Owner, NameOfOwner, Id_Household, HouseOwnerName, PAddress, TAddress, CreateDate, ExpireDate) values ('V4556', '684398172813', 'Betti Tuvey' ,'D1332', 'Cyndie Costell', '990 Browning Terrace', '4 Meadow Vale Way', '2020-4-19', '2023-4-19')
insert into Temporary_Residence (Id, Id_Owner, NameOfOwner, Id_Household, HouseOwnerName, PAddress, TAddress, CreateDate, ExpireDate) values ('V4557', '270987964659', 'Drew Falconbridge' ,'D1332', 'Cyndie Costell', '6122 Monument Avenue', '4 Meadow Vale Way', '2020-4-19', '2023-4-19')

insert into Temporary_Absence (Id, Id_Owner, NameOfOwner, Id_Household, HouseOwnerName, CreateDate, ExpireDate) values ('T4511', '398807346472', 'Corby Ingraham', 'T6789', 'Corby Ingraham', '2021-12-12', '2023-12-12')


USE [master]
GO
ALTER DATABASE [HoKhau] SET  READ_WRITE 
GO
