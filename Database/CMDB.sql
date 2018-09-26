USE [master]
GO
/****** Object:  Database [CMDB]    Script Date: 26/09/2018 9:36:37 AM ******/
CREATE DATABASE [CMDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CMDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\CMDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CMDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\CMDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [CMDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CMDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CMDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CMDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CMDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CMDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CMDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [CMDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CMDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CMDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CMDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CMDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CMDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CMDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CMDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CMDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CMDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CMDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CMDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CMDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CMDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CMDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CMDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CMDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CMDB] SET RECOVERY FULL 
GO
ALTER DATABASE [CMDB] SET  MULTI_USER 
GO
ALTER DATABASE [CMDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CMDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CMDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CMDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CMDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'CMDB', N'ON'
GO
ALTER DATABASE [CMDB] SET QUERY_STORE = OFF
GO
USE [CMDB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [CMDB]
GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 26/09/2018 9:36:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacts](
	[ContactID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Company] [nvarchar](1000) NULL,
	[Email] [varchar](100) NULL,
	[Address] [nvarchar](1000) NULL,
 CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED 
(
	[ContactID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Contacts] ON 
GO
INSERT [dbo].[Contacts] ([ContactID], [Name], [Company], [Email], [Address]) VALUES (1, N'Ingrid Townsend', N'JASPER', N'ingridtownsend@jasper.com', N'690 Charles Place, Santel, Northern Mariana Islands, 3791')
GO
INSERT [dbo].[Contacts] ([ContactID], [Name], [Company], [Email], [Address]) VALUES (2, N'Estrada Nolan', N'FIBRODYNE', N'estradanolan@fibrodyne.com', N'317 Seeley Street, Cade, Maryland, 3976')
GO
INSERT [dbo].[Contacts] ([ContactID], [Name], [Company], [Email], [Address]) VALUES (3, N'Laverne Andrews', N'INTRAWEAR', N'laverneandrews@intrawear.com', N'760 Provost Street, Valle, Alaska, 4628')
GO
INSERT [dbo].[Contacts] ([ContactID], [Name], [Company], [Email], [Address]) VALUES (4, N'Hull Woodward', N'SENMAO', N'hullwoodward@senmao.com', N'452 Union Avenue, Hachita, Palau, 9166')
GO
INSERT [dbo].[Contacts] ([ContactID], [Name], [Company], [Email], [Address]) VALUES (5, N'Maria Stanley', N'EYERIS', N'mariastanley@eyeris.com', N'350 Remsen Avenue, Abrams, Ohio, 6355')
GO
INSERT [dbo].[Contacts] ([ContactID], [Name], [Company], [Email], [Address]) VALUES (6, N'Bảo', N'Unit', N'baolhq@unit.com.vn', N'Địa chỉ nè')
GO
INSERT [dbo].[Contacts] ([ContactID], [Name], [Company], [Email], [Address]) VALUES (7, N'Su Tobi', N'Xinh đẹp', N'tuyenntn@byt.com.vn', N'Chung nhà với Bảo')
GO
INSERT [dbo].[Contacts] ([ContactID], [Name], [Company], [Email], [Address]) VALUES (8, N'Hello World', N'AngularJS', N'angularjs@mail.com', N'ahihi12')
GO
SET IDENTITY_INSERT [dbo].[Contacts] OFF
GO
USE [master]
GO
ALTER DATABASE [CMDB] SET  READ_WRITE 
GO
