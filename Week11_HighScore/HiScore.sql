USE [HiScore]
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPaneCount' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ScoreView'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ScoreView'
GO
/****** Object:  View [dbo].[ScoreView]    Script Date: 22/10/2018 8:50:18 AM ******/
DROP VIEW [dbo].[ScoreView]
GO
/****** Object:  Table [dbo].[HiScore]    Script Date: 22/10/2018 8:50:18 AM ******/
DROP TABLE [dbo].[HiScore]
GO
USE [master]
GO
/****** Object:  Database [HiScore]    Script Date: 22/10/2018 8:50:18 AM ******/
DROP DATABASE [HiScore]
GO
/****** Object:  Database [HiScore]    Script Date: 22/10/2018 8:50:18 AM ******/
CREATE DATABASE [HiScore]
GO
ALTER DATABASE [HiScore] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HiScore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HiScore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HiScore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HiScore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HiScore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HiScore] SET ARITHABORT OFF 
GO
ALTER DATABASE [HiScore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HiScore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HiScore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HiScore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HiScore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HiScore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HiScore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HiScore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HiScore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HiScore] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HiScore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HiScore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HiScore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HiScore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HiScore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HiScore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HiScore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HiScore] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HiScore] SET  MULTI_USER 
GO
ALTER DATABASE [HiScore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HiScore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HiScore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HiScore] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HiScore] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HiScore] SET QUERY_STORE = OFF
GO
USE [HiScore]
GO
/****** Object:  Table [dbo].[HiScore]    Script Date: 22/10/2018 8:50:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HiScore](
	[ScoreId] [int] IDENTITY(1,1) NOT NULL,
	[Score] [int] NOT NULL,
	[Name] [nchar](20) NOT NULL,
 CONSTRAINT [PK_HiScore] PRIMARY KEY CLUSTERED 
(
	[ScoreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ScoreView]    Script Date: 22/10/2018 8:50:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ScoreView]
AS
SELECT        TOP (100) PERCENT Score, Name
FROM            dbo.HiScore
ORDER BY Score DESC
GO
SET IDENTITY_INSERT [dbo].[HiScore] ON 
GO
INSERT [dbo].[HiScore] ([ScoreId], [Score], [Name]) VALUES (1, 10000, N'AAA                 ')
GO
INSERT [dbo].[HiScore] ([ScoreId], [Score], [Name]) VALUES (2, 9000, N'BBB                 ')
GO
INSERT [dbo].[HiScore] ([ScoreId], [Score], [Name]) VALUES (3, 8000, N'CCC                 ')
GO
INSERT [dbo].[HiScore] ([ScoreId], [Score], [Name]) VALUES (4, 7000, N'DDD                 ')
GO
INSERT [dbo].[HiScore] ([ScoreId], [Score], [Name]) VALUES (5, 6000, N'EEE                 ')
GO
INSERT [dbo].[HiScore] ([ScoreId], [Score], [Name]) VALUES (6, 5000, N'FFF                 ')
GO
INSERT [dbo].[HiScore] ([ScoreId], [Score], [Name]) VALUES (7, 4000, N'GGG                 ')
GO
INSERT [dbo].[HiScore] ([ScoreId], [Score], [Name]) VALUES (8, 3000, N'HHH                 ')
GO
INSERT [dbo].[HiScore] ([ScoreId], [Score], [Name]) VALUES (9, 2000, N'III                 ')
GO
INSERT [dbo].[HiScore] ([ScoreId], [Score], [Name]) VALUES (10, 1000, N'JJJ                 ')
GO
INSERT [dbo].[HiScore] ([ScoreId], [Score], [Name]) VALUES (11, 200, N'Pete                ')
GO
SET IDENTITY_INSERT [dbo].[HiScore] OFF
GO

USE [master]
GO
ALTER DATABASE [HiScore] SET  READ_WRITE 
GO
