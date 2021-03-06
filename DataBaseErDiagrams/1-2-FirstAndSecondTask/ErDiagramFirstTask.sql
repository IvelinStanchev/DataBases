USE [master]
GO
/****** Object:  Database [ExerciseFirstTask]    Script Date: 8/21/2014 3:19:22 PM ******/
CREATE DATABASE [ExerciseFirstTask]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ExerciseFirstTask', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\ExerciseFirstTask.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ExerciseFirstTask_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\ExerciseFirstTask_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ExerciseFirstTask] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ExerciseFirstTask].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ExerciseFirstTask] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ExerciseFirstTask] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ExerciseFirstTask] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ExerciseFirstTask] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ExerciseFirstTask] SET ARITHABORT OFF 
GO
ALTER DATABASE [ExerciseFirstTask] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ExerciseFirstTask] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ExerciseFirstTask] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ExerciseFirstTask] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ExerciseFirstTask] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ExerciseFirstTask] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ExerciseFirstTask] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ExerciseFirstTask] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ExerciseFirstTask] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ExerciseFirstTask] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ExerciseFirstTask] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ExerciseFirstTask] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ExerciseFirstTask] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ExerciseFirstTask] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ExerciseFirstTask] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ExerciseFirstTask] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ExerciseFirstTask] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ExerciseFirstTask] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ExerciseFirstTask] SET  MULTI_USER 
GO
ALTER DATABASE [ExerciseFirstTask] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ExerciseFirstTask] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ExerciseFirstTask] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ExerciseFirstTask] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ExerciseFirstTask] SET DELAYED_DURABILITY = DISABLED 
GO
USE [ExerciseFirstTask]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 8/21/2014 3:19:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresses](
	[AddressID] [int] IDENTITY(1,1) NOT NULL,
	[Address_Text] [nvarchar](100) NOT NULL,
	[Town_ID] [int] NOT NULL,
 CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED 
(
	[AddressID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Continents]    Script Date: 8/21/2014 3:19:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Continents](
	[ContinentID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Continents] PRIMARY KEY CLUSTERED 
(
	[ContinentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Countries]    Script Date: 8/21/2014 3:19:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[CountryID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ContinentID] [int] NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[CountryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Person]    Script Date: 8/21/2014 3:19:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[PersonID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Address_ID] [int] NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Towns]    Script Date: 8/21/2014 3:19:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Towns](
	[TownID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Country_ID] [int] NOT NULL,
 CONSTRAINT [PK_Towns] PRIMARY KEY CLUSTERED 
(
	[TownID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Addresses] ON 

INSERT [dbo].[Addresses] ([AddressID], [Address_Text], [Town_ID]) VALUES (6, N'Aleksandur Malinov', 1)
INSERT [dbo].[Addresses] ([AddressID], [Address_Text], [Town_ID]) VALUES (7, N'Oxford Rd', 2)
INSERT [dbo].[Addresses] ([AddressID], [Address_Text], [Town_ID]) VALUES (8, N'Allen Street', 3)
SET IDENTITY_INSERT [dbo].[Addresses] OFF
SET IDENTITY_INSERT [dbo].[Continents] ON 

INSERT [dbo].[Continents] ([ContinentID], [Name]) VALUES (1, N'Europe')
INSERT [dbo].[Continents] ([ContinentID], [Name]) VALUES (2, N'Australia')
INSERT [dbo].[Continents] ([ContinentID], [Name]) VALUES (3, N'Asia')
INSERT [dbo].[Continents] ([ContinentID], [Name]) VALUES (4, N'America')
INSERT [dbo].[Continents] ([ContinentID], [Name]) VALUES (6, N'Africa')
INSERT [dbo].[Continents] ([ContinentID], [Name]) VALUES (7, N'Antarctica')
SET IDENTITY_INSERT [dbo].[Continents] OFF
SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (1, N'Bulgaria', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (2, N'England', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (3, N'United States', 4)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (4, N'Brazil', 4)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (5, N'Germany', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (6, N'Papua New Guinea', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (7, N'Russia', 3)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (8, N'Nigeria', 6)
SET IDENTITY_INSERT [dbo].[Countries] OFF
SET IDENTITY_INSERT [dbo].[Person] ON 

INSERT [dbo].[Person] ([PersonID], [FirstName], [LastName], [Address_ID]) VALUES (3, N'Pesho', N'Peshov', 6)
INSERT [dbo].[Person] ([PersonID], [FirstName], [LastName], [Address_ID]) VALUES (4, N'Gosho', N'Goshov', 7)
INSERT [dbo].[Person] ([PersonID], [FirstName], [LastName], [Address_ID]) VALUES (5, N'Kiro', N'Kirov', 8)
SET IDENTITY_INSERT [dbo].[Person] OFF
SET IDENTITY_INSERT [dbo].[Towns] ON 

INSERT [dbo].[Towns] ([TownID], [Name], [Country_ID]) VALUES (1, N'Sofia', 1)
INSERT [dbo].[Towns] ([TownID], [Name], [Country_ID]) VALUES (2, N'Abingdon', 2)
INSERT [dbo].[Towns] ([TownID], [Name], [Country_ID]) VALUES (3, N'New York', 3)
INSERT [dbo].[Towns] ([TownID], [Name], [Country_ID]) VALUES (4, N'Sao Paulo', 4)
INSERT [dbo].[Towns] ([TownID], [Name], [Country_ID]) VALUES (5, N'Berlin', 5)
INSERT [dbo].[Towns] ([TownID], [Name], [Country_ID]) VALUES (6, N'Abau', 6)
INSERT [dbo].[Towns] ([TownID], [Name], [Country_ID]) VALUES (7, N'Moscow', 7)
INSERT [dbo].[Towns] ([TownID], [Name], [Country_ID]) VALUES (8, N'Abuja', 8)
SET IDENTITY_INSERT [dbo].[Towns] OFF
ALTER TABLE [dbo].[Addresses]  WITH CHECK ADD  CONSTRAINT [FK_Addresses_Towns] FOREIGN KEY([Town_ID])
REFERENCES [dbo].[Towns] ([TownID])
GO
ALTER TABLE [dbo].[Addresses] CHECK CONSTRAINT [FK_Addresses_Towns]
GO
ALTER TABLE [dbo].[Countries]  WITH CHECK ADD  CONSTRAINT [FK_Countries_Continents] FOREIGN KEY([ContinentID])
REFERENCES [dbo].[Continents] ([ContinentID])
GO
ALTER TABLE [dbo].[Countries] CHECK CONSTRAINT [FK_Countries_Continents]
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Addresses] FOREIGN KEY([Address_ID])
REFERENCES [dbo].[Addresses] ([AddressID])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_Addresses]
GO
ALTER TABLE [dbo].[Towns]  WITH CHECK ADD  CONSTRAINT [FK_Towns_Countries1] FOREIGN KEY([Country_ID])
REFERENCES [dbo].[Countries] ([CountryID])
GO
ALTER TABLE [dbo].[Towns] CHECK CONSTRAINT [FK_Towns_Countries1]
GO
USE [master]
GO
ALTER DATABASE [ExerciseFirstTask] SET  READ_WRITE 
GO
