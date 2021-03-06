USE [master]
GO
/****** Object:  Database [AccountSystem]    Script Date: 8/24/2014 5:27:03 PM ******/
CREATE DATABASE [AccountSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AccountSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\AccountSystem.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'AccountSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\AccountSystem_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [AccountSystem] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AccountSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AccountSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AccountSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AccountSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AccountSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AccountSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [AccountSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AccountSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AccountSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AccountSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AccountSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AccountSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AccountSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AccountSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AccountSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AccountSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AccountSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AccountSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AccountSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AccountSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AccountSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AccountSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AccountSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AccountSystem] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AccountSystem] SET  MULTI_USER 
GO
ALTER DATABASE [AccountSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AccountSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AccountSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AccountSystem] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [AccountSystem] SET DELAYED_DURABILITY = DISABLED 
GO
USE [AccountSystem]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 8/24/2014 5:27:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[AccountID] [int] IDENTITY(1,1) NOT NULL,
	[PersonID] [int] NOT NULL,
	[Balance] [int] NOT NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Persons]    Script Date: 8/24/2014 5:27:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[PersonID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[SSN] [int] NOT NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Accounts] ON 

INSERT [dbo].[Accounts] ([AccountID], [PersonID], [Balance]) VALUES (1, 5, 150)
INSERT [dbo].[Accounts] ([AccountID], [PersonID], [Balance]) VALUES (3, 1, 100)
INSERT [dbo].[Accounts] ([AccountID], [PersonID], [Balance]) VALUES (4, 2, 120)
INSERT [dbo].[Accounts] ([AccountID], [PersonID], [Balance]) VALUES (5, 4, 250)
INSERT [dbo].[Accounts] ([AccountID], [PersonID], [Balance]) VALUES (6, 3, 230)
SET IDENTITY_INSERT [dbo].[Accounts] OFF
SET IDENTITY_INSERT [dbo].[Persons] ON 

INSERT [dbo].[Persons] ([PersonID], [FirstName], [LastName], [SSN]) VALUES (1, N'Pesho', N'Peshov', 125124)
INSERT [dbo].[Persons] ([PersonID], [FirstName], [LastName], [SSN]) VALUES (2, N'Gosho', N'Goshov', 122151)
INSERT [dbo].[Persons] ([PersonID], [FirstName], [LastName], [SSN]) VALUES (3, N'Kiro', N'Kirov', 125125)
INSERT [dbo].[Persons] ([PersonID], [FirstName], [LastName], [SSN]) VALUES (4, N'Pesho2', N'Peshov', 656211)
INSERT [dbo].[Persons] ([PersonID], [FirstName], [LastName], [SSN]) VALUES (5, N'Kiro2', N'Kirov', 897214)
SET IDENTITY_INSERT [dbo].[Persons] OFF
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Persons] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Persons] ([PersonID])
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_Persons]
GO
/****** Object:  StoredProcedure [dbo].[usp_MoreMoneyThanSupplied]    Script Date: 8/24/2014 5:27:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_MoreMoneyThanSupplied](@money int)
AS
	SELECT p.FirstName + ' ' + p.LastName AS [Full Name]
	FROM Persons p
		JOIN Accounts a
		ON a.PersonID = p.PersonID
	WHERE a.Balance > @money

GO
/****** Object:  StoredProcedure [dbo].[usp_SelectFullNames]    Script Date: 8/24/2014 5:27:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_SelectFullNames]
AS
	SELECT FirstName + ' ' + LastName AS [Full Name] FROM Persons

GO
USE [master]
GO
ALTER DATABASE [AccountSystem] SET  READ_WRITE 
GO
