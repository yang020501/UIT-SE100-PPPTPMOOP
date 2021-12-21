USE [master]
GO
/****** Object:  Database [HoKhau]    Script Date: 12/21/2021 1:24:35 PM ******/
CREATE DATABASE [HoKhau]
 
USE [HoKhau]
GO
/****** Object:  Table [dbo].[Family_Household]    Script Date: 12/21/2021 1:24:36 PM ******/
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
/****** Object:  Table [dbo].[Household_Registration]    Script Date: 12/21/2021 1:24:36 PM ******/
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
/****** Object:  Table [dbo].[Population]    Script Date: 12/21/2021 1:24:36 PM ******/
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
	[OriginalAddress] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
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
/****** Object:  Table [dbo].[Temporary_Absence]    Script Date: 12/21/2021 1:24:36 PM ******/
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
/****** Object:  Table [dbo].[Temporary_Residence]    Script Date: 12/21/2021 1:24:36 PM ******/
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
/****** Object:  Table [dbo].[Transfer_Household]    Script Date: 12/21/2021 1:24:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transfer_Household](
	[Stt] [int] IDENTITY(1,1) NOT NULL,
	[Id] [varchar](5) NOT NULL,
	[Id_Owner] [varchar](12) NULL,
	[CreateDate] [date] NULL,
	[Old_Id_Household] [varchar](5) NULL,
	[Old_Address] [nvarchar](max) NULL,
	[New_Id_Household] [varchar](5) NULL,
	[New_Address] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 12/21/2021 1:24:36 PM ******/
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
/****** Object:  Table [dbo].[Users]    Script Date: 12/21/2021 1:24:36 PM ******/
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
ALTER TABLE [dbo].[Transfer_Household]  WITH CHECK ADD FOREIGN KEY([Id_Owner])
REFERENCES [dbo].[Population] ([Id])
GO
ALTER TABLE [dbo].[Transfer_Household]  WITH CHECK ADD FOREIGN KEY([New_Id_Household])
REFERENCES [dbo].[Household_Registration] ([Id])
GO
ALTER TABLE [dbo].[Transfer_Household]  WITH CHECK ADD FOREIGN KEY([Old_Id_Household])
REFERENCES [dbo].[Household_Registration] ([Id])
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
