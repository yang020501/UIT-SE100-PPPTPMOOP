USE [master]
GO
/****** Object:  Database [HoKhau]    Script Date: 11/22/2021 1:05:36 PM ******/
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
/****** Object:  Table [dbo].[Family_Household]    Script Date: 11/22/2021 1:05:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Family_Household](
	[Id_Household] [varchar](5) NOT NULL,
	[Id_Owner] [varchar](12) NOT NULL,
	[Id_Person] [varchar](12) NOT NULL,
	[Name_Person] [varchar](100) NULL,
 CONSTRAINT [Pk_Family_Household] PRIMARY KEY CLUSTERED 
(
	[Id_Household] ASC,
	[Id_Owner] ASC,
	[Id_Person] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Household_Registration]    Script Date: 11/22/2021 1:05:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Household_Registration](
	[Stt] [int] IDENTITY(1,1) NOT NULL,
	[Id] [varchar](5) NOT NULL,
	[IdOfOwner] [varchar](12) NULL,
	[NameOfOwner] [varchar](100) NULL,
	[Address] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Population]    Script Date: 11/22/2021 1:05:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Population](
	[Stt] [int] IDENTITY(1,1) NOT NULL,
	[Id] [varchar](12) NOT NULL,
	[Name] [varchar](100) NULL,
	[Id_Household] [varchar](5) NULL,
	[PlaceOfBirth] [varchar](500) NULL,
	[Address] [varchar](500) NULL,
	[DateOfBirth] [date] NULL,
	[Sex] [bit] NULL,
	[Relegion] [varchar](100) NULL,
	[Career] [varchar](200) NULL,
	[isAbsence] [bit] NULL,
	[isTResidence] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Temporary_Absence]    Script Date: 11/22/2021 1:05:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Temporary_Absence](
	[Stt] [int] IDENTITY(1,1) NOT NULL,
	[Id] [varchar](5) NOT NULL,
	[Id_Owner] [varchar](12) NULL,
	[NameOfOwner] [varchar](100) NULL,
	[Id_Household] [varchar](5) NULL,
	[HouseOwnerName] [varchar](100) NULL,
	[CreateDate] [date] NULL,
	[ExpireDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Temporary_Residence]    Script Date: 11/22/2021 1:05:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Temporary_Residence](
	[Stt] [int] IDENTITY(1,1) NOT NULL,
	[Id] [varchar](5) NOT NULL,
	[Id_Owner] [varchar](12) NULL,
	[NameOfOwner] [varchar](100) NULL,
	[Id_Household] [varchar](5) NULL,
	[HouseOwnerName] [varchar](100) NULL,
	[PAddress] [varchar](max) NULL,
	[TAddress] [varchar](max) NULL,
	[CreateDate] [date] NULL,
	[ExpireDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transfer_Household]    Script Date: 11/22/2021 1:05:36 PM ******/
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
	[Old_Address] [varchar](max) NULL,
	[New_Address] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 11/22/2021 1:05:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NameRole] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/22/2021 1:05:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1000,1) NOT NULL,
	[Username] [varchar](100) NULL,
	[Password] [varchar](max) NULL,
	[Tier] [int] NULL,
	[Name] [varchar](100) NULL,
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
USE [master]
GO
ALTER DATABASE [HoKhau] SET  READ_WRITE 
GO
insert into UserRole(NameRole) values ('Manager')
insert into UserRole(NameRole) values ('Employee')

insert into Users(Username, Password, Tier, Name, DateOfBirth, Sex, IdentityNum) values('DUONG1', 'ZHVvbmcxMjM=', '2', 'Nguyen Hoang Thai Duong', '2001-03-14', '1', '564502310213')
insert into Users(Username, Password, Tier, Name, DateOfBirth, Sex, IdentityNum) values('DUY1', 'ZHVvbmcxMjM=', '2', 'Nguyen Au Duy', '2001-04-11', '1', '785420057035')
insert into Users(Username, Password, Tier, Name, DateOfBirth, Sex, IdentityNum) values('ADMIN', 'YWRtaW4=', '1', 'Admin', '2021-09-05', '1', '000000000000')
insert into Users(Username, Password, Tier, Name, DateOfBirth, Sex, IdentityNum) values('MANAGER', 'bWFuYWdlcjEyMw==', '1', 'Diabolic Esper', '2099-01-15', '1', '101010101010')

