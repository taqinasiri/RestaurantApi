USE [master]
GO
/****** Object:  Database [RestaurantDb]    Script Date: 3/1/2024 5:08:09 PM ******/
CREATE DATABASE [RestaurantDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RestaurantDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\RestaurantDb.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'RestaurantDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\RestaurantDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [RestaurantDb] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RestaurantDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RestaurantDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RestaurantDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RestaurantDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RestaurantDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RestaurantDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [RestaurantDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RestaurantDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RestaurantDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RestaurantDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RestaurantDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RestaurantDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RestaurantDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RestaurantDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RestaurantDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RestaurantDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [RestaurantDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RestaurantDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RestaurantDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RestaurantDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RestaurantDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RestaurantDb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [RestaurantDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RestaurantDb] SET RECOVERY FULL 
GO
ALTER DATABASE [RestaurantDb] SET  MULTI_USER 
GO
ALTER DATABASE [RestaurantDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RestaurantDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RestaurantDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RestaurantDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [RestaurantDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [RestaurantDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'RestaurantDb', N'ON'
GO
ALTER DATABASE [RestaurantDb] SET QUERY_STORE = ON
GO
ALTER DATABASE [RestaurantDb] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [RestaurantDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 3/1/2024 5:08:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Branches]    Script Date: 3/1/2024 5:08:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Branches](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Slug] [nvarchar](100) NOT NULL,
	[Description] [ntext] NULL,
	[Address] [nvarchar](200) NOT NULL,
	[CreatedByBrowserName] [nvarchar](1000) NULL,
	[CreatedByIp] [nvarchar](255) NULL,
	[CreatedByUserId] [bigint] NULL,
	[CreatedDateTime] [datetime2](7) NOT NULL,
	[ModifiedByBrowserName] [nvarchar](1000) NULL,
	[ModifiedByIp] [nvarchar](255) NULL,
	[ModifiedByUserId] [bigint] NULL,
	[ModifiedDateTime] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[AdminId] [bigint] NOT NULL,
 CONSTRAINT [PK_Branches] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BranchWorkingHours]    Script Date: 3/1/2024 5:08:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BranchWorkingHours](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[BranchId] [bigint] NOT NULL,
	[From] [time](7) NOT NULL,
	[To] [time](7) NOT NULL,
	[DayOfWeek] [int] NOT NULL,
	[CreatedByBrowserName] [nvarchar](1000) NULL,
	[CreatedByIp] [nvarchar](255) NULL,
	[CreatedByUserId] [bigint] NULL,
	[CreatedDateTime] [datetime2](7) NOT NULL,
	[ModifiedByBrowserName] [nvarchar](1000) NULL,
	[ModifiedByIp] [nvarchar](255) NULL,
	[ModifiedByUserId] [bigint] NULL,
	[ModifiedDateTime] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_BranchWorkingHours] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 3/1/2024 5:08:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](4000) NULL,
	[Slug] [nvarchar](100) NOT NULL,
	[ParentId] [bigint] NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedByBrowserName] [nvarchar](1000) NULL,
	[CreatedByIp] [nvarchar](255) NULL,
	[CreatedByUserId] [bigint] NULL,
	[CreatedDateTime] [datetime2](7) NOT NULL,
	[ModifiedByBrowserName] [nvarchar](1000) NULL,
	[ModifiedByIp] [nvarchar](255) NULL,
	[ModifiedByUserId] [bigint] NULL,
	[ModifiedDateTime] [datetime2](7) NULL,
	[ImageId] [bigint] NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CategoryToProduct]    Script Date: 3/1/2024 5:08:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryToProduct](
	[CategoryId] [bigint] NOT NULL,
	[ProductId] [bigint] NOT NULL,
	[CreatedByBrowserName] [nvarchar](1000) NULL,
	[CreatedByIp] [nvarchar](255) NULL,
	[CreatedByUserId] [bigint] NULL,
	[CreatedDateTime] [datetime2](7) NOT NULL,
	[ModifiedByBrowserName] [nvarchar](1000) NULL,
	[ModifiedByIp] [nvarchar](255) NULL,
	[ModifiedByUserId] [bigint] NULL,
	[ModifiedDateTime] [datetime2](7) NULL,
 CONSTRAINT [PK_CategoryToProduct] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC,
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Images]    Script Date: 3/1/2024 5:08:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Images](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Extension] [nvarchar](10) NULL,
	[Size] [int] NULL,
	[UploadDate] [datetime2](7) NOT NULL,
	[CreatedByBrowserName] [nvarchar](1000) NULL,
	[CreatedByIp] [nvarchar](255) NULL,
	[CreatedByUserId] [bigint] NULL,
	[CreatedDateTime] [datetime2](7) NOT NULL,
	[ModifiedByBrowserName] [nvarchar](1000) NULL,
	[ModifiedByIp] [nvarchar](255) NULL,
	[ModifiedByUserId] [bigint] NULL,
	[ModifiedDateTime] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Images] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ImageToBranch]    Script Date: 3/1/2024 5:08:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImageToBranch](
	[ImageId] [bigint] NOT NULL,
	[BranchId] [bigint] NOT NULL,
	[CreatedByBrowserName] [nvarchar](1000) NULL,
	[CreatedByIp] [nvarchar](255) NULL,
	[CreatedByUserId] [bigint] NULL,
	[CreatedDateTime] [datetime2](7) NOT NULL,
	[ModifiedByBrowserName] [nvarchar](1000) NULL,
	[ModifiedByIp] [nvarchar](255) NULL,
	[ModifiedByUserId] [bigint] NULL,
	[ModifiedDateTime] [datetime2](7) NULL,
 CONSTRAINT [PK_ImageToBranch] PRIMARY KEY CLUSTERED 
(
	[BranchId] ASC,
	[ImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ImageToProduct]    Script Date: 3/1/2024 5:08:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImageToProduct](
	[ImageId] [bigint] NOT NULL,
	[ProductId] [bigint] NOT NULL,
	[CreatedByBrowserName] [nvarchar](1000) NULL,
	[CreatedByIp] [nvarchar](255) NULL,
	[CreatedByUserId] [bigint] NULL,
	[CreatedDateTime] [datetime2](7) NOT NULL,
	[ModifiedByBrowserName] [nvarchar](1000) NULL,
	[ModifiedByIp] [nvarchar](255) NULL,
	[ModifiedByUserId] [bigint] NULL,
	[ModifiedDateTime] [datetime2](7) NULL,
 CONSTRAINT [PK_ImageToProduct] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC,
	[ImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ImageToTable]    Script Date: 3/1/2024 5:08:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImageToTable](
	[ImageId] [bigint] NOT NULL,
	[TableId] [bigint] NOT NULL,
	[CreatedByBrowserName] [nvarchar](1000) NULL,
	[CreatedByIp] [nvarchar](255) NULL,
	[CreatedByUserId] [bigint] NULL,
	[CreatedDateTime] [datetime2](7) NOT NULL,
	[ModifiedByBrowserName] [nvarchar](1000) NULL,
	[ModifiedByIp] [nvarchar](255) NULL,
	[ModifiedByUserId] [bigint] NULL,
	[ModifiedDateTime] [datetime2](7) NULL,
 CONSTRAINT [PK_ImageToTable] PRIMARY KEY CLUSTERED 
(
	[TableId] ASC,
	[ImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 3/1/2024 5:08:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[TableId] [bigint] NOT NULL,
	[TableRentalMinutePrice] [int] NOT NULL,
	[FromTime] [datetime2](7) NOT NULL,
	[ToTime] [datetime2](7) NOT NULL,
	[TotalPrice] [int] NOT NULL,
	[Description] [nvarchar](500) NULL,
	[RefId] [int] NOT NULL,
	[CreatedByBrowserName] [nvarchar](1000) NULL,
	[CreatedByIp] [nvarchar](255) NULL,
	[CreatedByUserId] [bigint] NULL,
	[CreatedDateTime] [datetime2](7) NOT NULL,
	[ModifiedByBrowserName] [nvarchar](1000) NULL,
	[ModifiedByIp] [nvarchar](255) NULL,
	[ModifiedByUserId] [bigint] NULL,
	[ModifiedDateTime] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[Status] [int] NOT NULL,
	[PayDateTime] [datetime2](7) NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderItems]    Script Date: 3/1/2024 5:08:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItems](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductId] [bigint] NOT NULL,
	[OrderId] [bigint] NOT NULL,
	[UnitPrice] [int] NOT NULL,
	[Amount] [int] NOT NULL,
	[CreatedByBrowserName] [nvarchar](1000) NULL,
	[CreatedByIp] [nvarchar](255) NULL,
	[CreatedByUserId] [bigint] NULL,
	[CreatedDateTime] [datetime2](7) NOT NULL,
	[ModifiedByBrowserName] [nvarchar](1000) NULL,
	[ModifiedByIp] [nvarchar](255) NULL,
	[ModifiedByUserId] [bigint] NULL,
	[ModifiedDateTime] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_OrderItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 3/1/2024 5:08:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](150) NOT NULL,
	[Slug] [nvarchar](100) NOT NULL,
	[Description] [ntext] NULL,
	[CreatedByBrowserName] [nvarchar](1000) NULL,
	[CreatedByIp] [nvarchar](255) NULL,
	[CreatedByUserId] [bigint] NULL,
	[CreatedDateTime] [datetime2](7) NOT NULL,
	[ModifiedByBrowserName] [nvarchar](1000) NULL,
	[ModifiedByIp] [nvarchar](255) NULL,
	[ModifiedByUserId] [bigint] NULL,
	[ModifiedDateTime] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[Price] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductToBranch]    Script Date: 3/1/2024 5:08:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductToBranch](
	[ProductId] [bigint] NOT NULL,
	[BranchId] [bigint] NOT NULL,
	[IsAvailable] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedByBrowserName] [nvarchar](1000) NULL,
	[CreatedByIp] [nvarchar](255) NULL,
	[CreatedByUserId] [bigint] NULL,
	[CreatedDateTime] [datetime2](7) NOT NULL,
	[ModifiedByBrowserName] [nvarchar](1000) NULL,
	[ModifiedByIp] [nvarchar](255) NULL,
	[ModifiedByUserId] [bigint] NULL,
	[ModifiedDateTime] [datetime2](7) NULL,
 CONSTRAINT [PK_ProductToBranch] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC,
	[BranchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleClaims]    Script Date: 3/1/2024 5:08:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [bigint] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_RoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 3/1/2024 5:08:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CreatedByBrowserName] [nvarchar](1000) NULL,
	[CreatedByIp] [nvarchar](255) NULL,
	[CreatedByUserId] [bigint] NULL,
	[CreatedDateTime] [datetime2](7) NOT NULL,
	[ModifiedByBrowserName] [nvarchar](1000) NULL,
	[ModifiedByIp] [nvarchar](255) NULL,
	[ModifiedByUserId] [bigint] NULL,
	[ModifiedDateTime] [datetime2](7) NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tables]    Script Date: 3/1/2024 5:08:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tables](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](150) NOT NULL,
	[Slug] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](2000) NULL,
	[Space] [tinyint] NOT NULL,
	[RentalMinutePrice] [int] NOT NULL,
	[IsAvailable] [bit] NOT NULL,
	[BranchId] [bigint] NOT NULL,
	[CreatedByBrowserName] [nvarchar](1000) NULL,
	[CreatedByIp] [nvarchar](255) NULL,
	[CreatedByUserId] [bigint] NULL,
	[CreatedDateTime] [datetime2](7) NOT NULL,
	[ModifiedByBrowserName] [nvarchar](1000) NULL,
	[ModifiedByIp] [nvarchar](255) NULL,
	[ModifiedByUserId] [bigint] NULL,
	[ModifiedDateTime] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Tables] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserClaims]    Script Date: 3/1/2024 5:08:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLogins]    Script Date: 3/1/2024 5:08:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [bigint] NOT NULL,
 CONSTRAINT [PK_UserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 3/1/2024 5:08:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[UserId] [bigint] NOT NULL,
	[RoleId] [bigint] NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 3/1/2024 5:08:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CreatedByBrowserName] [nvarchar](1000) NULL,
	[CreatedByIp] [nvarchar](255) NULL,
	[CreatedByUserId] [bigint] NULL,
	[CreatedDateTime] [datetime2](7) NOT NULL,
	[ModifiedByBrowserName] [nvarchar](1000) NULL,
	[ModifiedByIp] [nvarchar](255) NULL,
	[ModifiedByUserId] [bigint] NULL,
	[ModifiedDateTime] [datetime2](7) NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[SendCodeLastTime] [datetime2](7) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[AvatarId] [bigint] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserTokens]    Script Date: 3/1/2024 5:08:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTokens](
	[UserId] [bigint] NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240119115315_initDb', N'8.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240119131232_AddAvaratToUser', N'8.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240119162632_AddSendLastTimeCodeToUser', N'8.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240122141157_AddIsActiveToUser', N'8.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240122155403_AddCategory', N'8.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240122160114_CategoryNtestDescToNvarchar', N'8.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240122160216_AddMaxLenghToCaregoryDesc', N'8.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240123184757_addAuditableShaowProps', N'8.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240123191748_FixCategoryParentBug', N'8.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240204172344_addProductAndImagesTables', N'8.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240204172716_addProductAndImagesUniques', N'8.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240204193854_imageToProductRelationFixBug', N'8.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240206165250_addBranchTable', N'8.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240206172434_setBrachSlugAndTitileUnique', N'8.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240209132307_addTablesTable', N'8.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240210114457_movePriceToProduct', N'8.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240211120323_AddUserBranchRoleTable', N'8.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240211131233_RemoveUserBranchRoleTable', N'8.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240214141409_AddOtherIdentityCustomTables', N'8.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240214141737_EditUserRoleTableName', N'8.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240216113807_AddCategoryImageRelation', N'8.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240216120547_ChangeUserAvatarRelatoin', N'8.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240216190319_AddBranchWorkingHours', N'8.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240216200847_EditBranchWorkingHourFromName', N'8.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240217165252_AddOrderTables', N'8.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240217170715_AddStatusToOrderTable', N'8.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240223142944_AddPayDateTimeToOrder', N'8.0.1')
GO
SET IDENTITY_INSERT [dbo].[Branches] ON 

INSERT [dbo].[Branches] ([Id], [Title], [Slug], [Description], [Address], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted], [AdminId]) VALUES (1, N'شعبه یزد', N'yazd-branch', N'اولین و بهترین شعبه ما', N'یزد، خیابان اول کوچه دوم', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:34:49.7949781' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[Branches] ([Id], [Title], [Slug], [Description], [Address], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted], [AdminId]) VALUES (2, N'شعبه شیراز', N'shiraz-branch', N'دومین و شیرازی ترین شعبه ما', N'شیراز، خیابان اول کوچه دوم', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:41:41.7410972' AS DateTime2), NULL, NULL, NULL, NULL, 0, 2)
SET IDENTITY_INSERT [dbo].[Branches] OFF
GO
SET IDENTITY_INSERT [dbo].[BranchWorkingHours] ON 

INSERT [dbo].[BranchWorkingHours] ([Id], [BranchId], [From], [To], [DayOfWeek], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (1, 1, CAST(N'09:00:00' AS Time), CAST(N'14:00:00' AS Time), 0, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:45:49.2340786' AS DateTime2), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BranchWorkingHours] ([Id], [BranchId], [From], [To], [DayOfWeek], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (2, 1, CAST(N'17:00:00' AS Time), CAST(N'22:00:00' AS Time), 0, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:45:49.2340786' AS DateTime2), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BranchWorkingHours] ([Id], [BranchId], [From], [To], [DayOfWeek], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (3, 1, CAST(N'09:00:00' AS Time), CAST(N'14:00:00' AS Time), 1, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:45:49.2340786' AS DateTime2), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BranchWorkingHours] ([Id], [BranchId], [From], [To], [DayOfWeek], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (4, 1, CAST(N'17:00:00' AS Time), CAST(N'22:00:00' AS Time), 1, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:45:49.2340786' AS DateTime2), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BranchWorkingHours] ([Id], [BranchId], [From], [To], [DayOfWeek], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (5, 1, CAST(N'09:00:00' AS Time), CAST(N'14:00:00' AS Time), 2, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:45:49.2340786' AS DateTime2), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BranchWorkingHours] ([Id], [BranchId], [From], [To], [DayOfWeek], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (6, 1, CAST(N'17:00:00' AS Time), CAST(N'22:00:00' AS Time), 2, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:45:49.2340786' AS DateTime2), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BranchWorkingHours] ([Id], [BranchId], [From], [To], [DayOfWeek], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (7, 1, CAST(N'09:00:00' AS Time), CAST(N'14:00:00' AS Time), 3, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:45:49.2340786' AS DateTime2), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BranchWorkingHours] ([Id], [BranchId], [From], [To], [DayOfWeek], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (8, 1, CAST(N'17:00:00' AS Time), CAST(N'22:00:00' AS Time), 3, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:45:49.2340786' AS DateTime2), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BranchWorkingHours] ([Id], [BranchId], [From], [To], [DayOfWeek], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (9, 1, CAST(N'09:00:00' AS Time), CAST(N'14:00:00' AS Time), 4, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:45:49.2340786' AS DateTime2), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BranchWorkingHours] ([Id], [BranchId], [From], [To], [DayOfWeek], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (10, 1, CAST(N'17:00:00' AS Time), CAST(N'22:00:00' AS Time), 4, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:45:49.2340786' AS DateTime2), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BranchWorkingHours] ([Id], [BranchId], [From], [To], [DayOfWeek], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (11, 1, CAST(N'09:00:00' AS Time), CAST(N'14:00:00' AS Time), 5, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:45:49.2340786' AS DateTime2), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BranchWorkingHours] ([Id], [BranchId], [From], [To], [DayOfWeek], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (12, 1, CAST(N'17:00:00' AS Time), CAST(N'21:00:00' AS Time), 5, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:45:49.2340786' AS DateTime2), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BranchWorkingHours] ([Id], [BranchId], [From], [To], [DayOfWeek], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (13, 1, CAST(N'18:00:00' AS Time), CAST(N'22:00:00' AS Time), 6, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:45:49.2340786' AS DateTime2), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BranchWorkingHours] ([Id], [BranchId], [From], [To], [DayOfWeek], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (14, 2, CAST(N'10:00:00' AS Time), CAST(N'15:00:00' AS Time), 0, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:47:35.1820746' AS DateTime2), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BranchWorkingHours] ([Id], [BranchId], [From], [To], [DayOfWeek], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (15, 2, CAST(N'18:00:00' AS Time), CAST(N'23:00:00' AS Time), 0, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:47:35.1820746' AS DateTime2), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BranchWorkingHours] ([Id], [BranchId], [From], [To], [DayOfWeek], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (16, 2, CAST(N'10:00:00' AS Time), CAST(N'15:00:00' AS Time), 1, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:47:35.1820746' AS DateTime2), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BranchWorkingHours] ([Id], [BranchId], [From], [To], [DayOfWeek], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (17, 2, CAST(N'18:00:00' AS Time), CAST(N'23:00:00' AS Time), 1, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:47:35.1820746' AS DateTime2), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BranchWorkingHours] ([Id], [BranchId], [From], [To], [DayOfWeek], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (18, 2, CAST(N'10:00:00' AS Time), CAST(N'15:00:00' AS Time), 2, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:47:35.1820746' AS DateTime2), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BranchWorkingHours] ([Id], [BranchId], [From], [To], [DayOfWeek], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (19, 2, CAST(N'18:00:00' AS Time), CAST(N'23:00:00' AS Time), 2, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:47:35.1820746' AS DateTime2), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BranchWorkingHours] ([Id], [BranchId], [From], [To], [DayOfWeek], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (20, 2, CAST(N'10:00:00' AS Time), CAST(N'15:00:00' AS Time), 3, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:47:35.1820746' AS DateTime2), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BranchWorkingHours] ([Id], [BranchId], [From], [To], [DayOfWeek], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (21, 2, CAST(N'18:00:00' AS Time), CAST(N'23:00:00' AS Time), 3, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:47:35.1820746' AS DateTime2), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BranchWorkingHours] ([Id], [BranchId], [From], [To], [DayOfWeek], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (22, 2, CAST(N'10:00:00' AS Time), CAST(N'15:00:00' AS Time), 4, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:47:35.1820746' AS DateTime2), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BranchWorkingHours] ([Id], [BranchId], [From], [To], [DayOfWeek], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (23, 2, CAST(N'18:00:00' AS Time), CAST(N'23:00:00' AS Time), 4, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:47:35.1820746' AS DateTime2), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BranchWorkingHours] ([Id], [BranchId], [From], [To], [DayOfWeek], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (24, 2, CAST(N'10:00:00' AS Time), CAST(N'15:00:00' AS Time), 5, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:47:35.1820746' AS DateTime2), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BranchWorkingHours] ([Id], [BranchId], [From], [To], [DayOfWeek], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (25, 2, CAST(N'18:00:00' AS Time), CAST(N'23:00:00' AS Time), 5, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:47:35.1820746' AS DateTime2), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BranchWorkingHours] ([Id], [BranchId], [From], [To], [DayOfWeek], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (26, 2, CAST(N'18:00:00' AS Time), CAST(N'22:00:00' AS Time), 6, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:47:35.1820746' AS DateTime2), NULL, NULL, NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[BranchWorkingHours] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Title], [Description], [Slug], [ParentId], [IsDeleted], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [ImageId]) VALUES (1, N'فست فود', N'فست فود های خوشمزه', N'fast-food', NULL, 0, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:55:12.8321165' AS DateTime2), NULL, NULL, NULL, NULL, 9)
INSERT [dbo].[Categories] ([Id], [Title], [Description], [Slug], [ParentId], [IsDeleted], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [ImageId]) VALUES (2, N'خورشت ها', N'خورشت های خوش بو و خوش طعم', N'khoresht', NULL, 0, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:56:04.1373982' AS DateTime2), NULL, NULL, NULL, NULL, 10)
INSERT [dbo].[Categories] ([Id], [Title], [Description], [Slug], [ParentId], [IsDeleted], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [ImageId]) VALUES (3, N'نوشیدنی ها', N'کنار غذا نوشیدنی میچسبه ها', N'noshidani-ha', NULL, 0, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:56:55.6243508' AS DateTime2), NULL, NULL, NULL, NULL, 11)
INSERT [dbo].[Categories] ([Id], [Title], [Description], [Slug], [ParentId], [IsDeleted], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [ImageId]) VALUES (4, N'پیتزا', N'پیتزای خوب رو خوب بخورید', N'pizza', 1, 0, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:58:06.3502257' AS DateTime2), NULL, NULL, NULL, NULL, 12)
INSERT [dbo].[Categories] ([Id], [Title], [Description], [Slug], [ParentId], [IsDeleted], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [ImageId]) VALUES (5, N'ساندویچ', N'ساندویچ با نون تازه', N'Sandwich', 1, 0, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:59:09.8544780' AS DateTime2), NULL, NULL, NULL, NULL, 13)
INSERT [dbo].[Categories] ([Id], [Title], [Description], [Slug], [ParentId], [IsDeleted], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [ImageId]) VALUES (6, N'قهوه', N'قهوه تازه میل دارین ؟', N'coffee', 3, 0, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:00:23.9005404' AS DateTime2), NULL, NULL, NULL, NULL, 14)
INSERT [dbo].[Categories] ([Id], [Title], [Description], [Slug], [ParentId], [IsDeleted], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [ImageId]) VALUES (7, N'نوشابه ها', N'خنک بنوشید !', N'noshabe', 3, 0, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:00:50.3629010' AS DateTime2), NULL, NULL, NULL, NULL, 15)
INSERT [dbo].[Categories] ([Id], [Title], [Description], [Slug], [ParentId], [IsDeleted], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [ImageId]) VALUES (8, N'اسپرسو', N'تلخ بنوشید !', N'Espresso', 6, 0, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:01:43.4727337' AS DateTime2), NULL, NULL, NULL, NULL, 16)
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
INSERT [dbo].[CategoryToProduct] ([CategoryId], [ProductId], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime]) VALUES (1, 1, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:04:25.3259060' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[CategoryToProduct] ([CategoryId], [ProductId], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime]) VALUES (4, 1, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:04:25.3259060' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[CategoryToProduct] ([CategoryId], [ProductId], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime]) VALUES (1, 2, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:05:25.2846397' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[CategoryToProduct] ([CategoryId], [ProductId], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime]) VALUES (5, 2, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:05:25.2846397' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[CategoryToProduct] ([CategoryId], [ProductId], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime]) VALUES (2, 3, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:06:26.8453954' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[CategoryToProduct] ([CategoryId], [ProductId], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime]) VALUES (2, 4, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:07:00.9739134' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[CategoryToProduct] ([CategoryId], [ProductId], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime]) VALUES (3, 5, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:07:56.4067470' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[CategoryToProduct] ([CategoryId], [ProductId], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime]) VALUES (6, 5, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:07:56.4067470' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[CategoryToProduct] ([CategoryId], [ProductId], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime]) VALUES (8, 5, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:07:56.4067470' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[CategoryToProduct] ([CategoryId], [ProductId], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime]) VALUES (3, 6, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:08:22.1386670' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[CategoryToProduct] ([CategoryId], [ProductId], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime]) VALUES (6, 6, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:08:22.1386670' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[CategoryToProduct] ([CategoryId], [ProductId], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime]) VALUES (8, 6, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:08:22.1386670' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[CategoryToProduct] ([CategoryId], [ProductId], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime]) VALUES (3, 7, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:09:08.7772709' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[CategoryToProduct] ([CategoryId], [ProductId], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime]) VALUES (6, 7, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:09:08.7772709' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[CategoryToProduct] ([CategoryId], [ProductId], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime]) VALUES (3, 8, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:10:45.1956205' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[CategoryToProduct] ([CategoryId], [ProductId], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime]) VALUES (7, 8, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:10:45.1956205' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[CategoryToProduct] ([CategoryId], [ProductId], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime]) VALUES (3, 9, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:11:26.2753018' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[CategoryToProduct] ([CategoryId], [ProductId], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime]) VALUES (7, 9, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:11:26.2753018' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[CategoryToProduct] ([CategoryId], [ProductId], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime]) VALUES (3, 10, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:13:22.3632896' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[CategoryToProduct] ([CategoryId], [ProductId], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime]) VALUES (6, 10, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:13:22.3632896' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[CategoryToProduct] ([CategoryId], [ProductId], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime]) VALUES (8, 10, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:13:22.3632896' AS DateTime2), NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Images] ON 

INSERT [dbo].[Images] ([Id], [Name], [Extension], [Size], [UploadDate], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (1, N'user-default-avatar.png', NULL, NULL, CAST(N'2024-03-01T15:57:46.2134374' AS DateTime2), NULL, NULL, NULL, CAST(N'2024-03-01T12:27:46.4834865' AS DateTime2), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Images] ([Id], [Name], [Extension], [Size], [UploadDate], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (2, N'69ece31a4cf549838f07ecc7452087df.jpg', N'jpg', 40948, CAST(N'2024-03-01T16:04:49.7375333' AS DateTime2), N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:34:49.7949781' AS DateTime2), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Images] ([Id], [Name], [Extension], [Size], [UploadDate], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (3, N'bc2198d162e34fd79667a0db644526a3.jpg', N'jpg', 40948, CAST(N'2024-03-01T16:11:41.7393198' AS DateTime2), N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:41:41.7410972' AS DateTime2), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Images] ([Id], [Name], [Extension], [Size], [UploadDate], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (4, N'73fb2bdca9a14625bbd2c798df38ebdb.jpg', N'jpg', 40948, CAST(N'2024-03-01T16:18:34.3088746' AS DateTime2), N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:48:34.3621200' AS DateTime2), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Images] ([Id], [Name], [Extension], [Size], [UploadDate], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (5, N'050bd0c63e6942e58c643fff9cdd4f03.jpg', N'jpg', 40948, CAST(N'2024-03-01T16:19:44.4667980' AS DateTime2), N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:49:44.4674271' AS DateTime2), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Images] ([Id], [Name], [Extension], [Size], [UploadDate], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (6, N'ff3ffdeed49a43938320a297f1e3c6fa.jpg', N'jpg', 40948, CAST(N'2024-03-01T16:20:24.7129425' AS DateTime2), N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:50:24.7136265' AS DateTime2), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Images] ([Id], [Name], [Extension], [Size], [UploadDate], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (7, N'1aee420c18bd43538e07baef13f9c246.jpg', N'jpg', 40948, CAST(N'2024-03-01T16:21:23.3867978' AS DateTime2), N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:51:23.3875941' AS DateTime2), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Images] ([Id], [Name], [Extension], [Size], [UploadDate], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (8, N'49b8176057e546808c5fdb9a4103acac.jpg', N'jpg', 40948, CAST(N'2024-03-01T16:22:04.2027183' AS DateTime2), N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:52:04.2214116' AS DateTime2), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Images] ([Id], [Name], [Extension], [Size], [UploadDate], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (9, N'4a0835155913448681ea4ebcca14a281.jpg', N'jpg', 40948, CAST(N'2024-03-01T16:25:12.7993117' AS DateTime2), N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:55:12.8321165' AS DateTime2), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Images] ([Id], [Name], [Extension], [Size], [UploadDate], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (10, N'2970c2b91ae24c5db87b1eec185af75e.jpg', N'jpg', 40948, CAST(N'2024-03-01T16:26:04.1362653' AS DateTime2), N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:56:04.1373982' AS DateTime2), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Images] ([Id], [Name], [Extension], [Size], [UploadDate], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (11, N'109f6e97f815450fb81af3638018ae58.jpg', N'jpg', 40948, CAST(N'2024-03-01T16:26:55.6236830' AS DateTime2), N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:56:55.6243508' AS DateTime2), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Images] ([Id], [Name], [Extension], [Size], [UploadDate], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (12, N'46631996f8de44e997b1f9d4d4edc313.jpg', N'jpg', 40948, CAST(N'2024-03-01T16:28:06.3499527' AS DateTime2), N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:58:06.3502257' AS DateTime2), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Images] ([Id], [Name], [Extension], [Size], [UploadDate], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (13, N'e08cc4445c414470bab878bb8c29083d.jpg', N'jpg', 40948, CAST(N'2024-03-01T16:29:09.8538336' AS DateTime2), N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:59:09.8544780' AS DateTime2), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Images] ([Id], [Name], [Extension], [Size], [UploadDate], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (14, N'bad7d7c92ee54960b77cf1cd429b2d97.jpg', N'jpg', 40948, CAST(N'2024-03-01T16:30:23.9001263' AS DateTime2), N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:00:23.9005404' AS DateTime2), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Images] ([Id], [Name], [Extension], [Size], [UploadDate], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (15, N'052d052e73164fe4bb4983d8491141df.jpg', N'jpg', 40948, CAST(N'2024-03-01T16:30:50.3624250' AS DateTime2), N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:00:50.3629010' AS DateTime2), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Images] ([Id], [Name], [Extension], [Size], [UploadDate], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (16, N'2a88ea09fe234d1c9a1402d3164446b3.jpg', N'jpg', 40948, CAST(N'2024-03-01T16:31:43.4721079' AS DateTime2), N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:01:43.4727337' AS DateTime2), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Images] ([Id], [Name], [Extension], [Size], [UploadDate], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (17, N'51366f588fac4c698d48052c53fb5f2b.jpg', N'jpg', 40948, CAST(N'2024-03-01T16:34:25.2757790' AS DateTime2), N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:04:25.3259060' AS DateTime2), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Images] ([Id], [Name], [Extension], [Size], [UploadDate], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (18, N'528b63da41f6467abb849fa3c744dcd2.jpg', N'jpg', 40948, CAST(N'2024-03-01T16:35:25.2838709' AS DateTime2), N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:05:25.2846397' AS DateTime2), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Images] ([Id], [Name], [Extension], [Size], [UploadDate], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (19, N'3a8fa6aa9adb4dfca9383206f57caf3f.jpg', N'jpg', 40948, CAST(N'2024-03-01T16:36:26.8443175' AS DateTime2), N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:06:26.8453954' AS DateTime2), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Images] ([Id], [Name], [Extension], [Size], [UploadDate], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (20, N'b3a44e2d5c8a42dcbe0c58e5377f0ea9.jpg', N'jpg', 40948, CAST(N'2024-03-01T16:37:00.9732597' AS DateTime2), N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:07:00.9739134' AS DateTime2), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Images] ([Id], [Name], [Extension], [Size], [UploadDate], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (21, N'8a83997be82c4bf6bc1cb06bb3aa6088.jpg', N'jpg', 40948, CAST(N'2024-03-01T16:37:56.4059112' AS DateTime2), N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:07:56.4067470' AS DateTime2), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Images] ([Id], [Name], [Extension], [Size], [UploadDate], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (22, N'2fc05a911d7b42bfa19025547552d27e.jpg', N'jpg', 40948, CAST(N'2024-03-01T16:38:22.1382311' AS DateTime2), N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:08:22.1386670' AS DateTime2), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Images] ([Id], [Name], [Extension], [Size], [UploadDate], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (23, N'70aa966766ea44c1811a542437ba5f59.jpg', N'jpg', 40948, CAST(N'2024-03-01T16:39:08.7767024' AS DateTime2), N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:09:08.7772709' AS DateTime2), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Images] ([Id], [Name], [Extension], [Size], [UploadDate], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (24, N'dad72691577b475ab9596aa7d84c4e38.jpg', N'jpg', 40948, CAST(N'2024-03-01T16:40:45.1942739' AS DateTime2), N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:10:45.1956205' AS DateTime2), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Images] ([Id], [Name], [Extension], [Size], [UploadDate], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (25, N'df5c4e1b97424dd69bb3fd44fc4a070f.jpg', N'jpg', 40948, CAST(N'2024-03-01T16:41:26.2746296' AS DateTime2), N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:11:26.2753018' AS DateTime2), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Images] ([Id], [Name], [Extension], [Size], [UploadDate], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (26, N'72b837af345a44e29de4b737dac043cc.jpg', N'jpg', 40948, CAST(N'2024-03-01T16:43:22.3626888' AS DateTime2), N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:13:22.3632896' AS DateTime2), NULL, NULL, NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[Images] OFF
GO
INSERT [dbo].[ImageToBranch] ([ImageId], [BranchId], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime]) VALUES (2, 1, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:34:49.7949781' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[ImageToBranch] ([ImageId], [BranchId], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime]) VALUES (3, 2, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:41:41.7410972' AS DateTime2), NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ImageToProduct] ([ImageId], [ProductId], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime]) VALUES (17, 1, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:04:25.3259060' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[ImageToProduct] ([ImageId], [ProductId], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime]) VALUES (18, 2, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:05:25.2846397' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[ImageToProduct] ([ImageId], [ProductId], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime]) VALUES (19, 3, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:06:26.8453954' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[ImageToProduct] ([ImageId], [ProductId], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime]) VALUES (20, 4, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:07:00.9739134' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[ImageToProduct] ([ImageId], [ProductId], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime]) VALUES (21, 5, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:07:56.4067470' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[ImageToProduct] ([ImageId], [ProductId], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime]) VALUES (22, 6, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:08:22.1386670' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[ImageToProduct] ([ImageId], [ProductId], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime]) VALUES (23, 7, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:09:08.7772709' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[ImageToProduct] ([ImageId], [ProductId], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime]) VALUES (24, 8, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:10:45.1956205' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[ImageToProduct] ([ImageId], [ProductId], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime]) VALUES (25, 9, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:11:26.2753018' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[ImageToProduct] ([ImageId], [ProductId], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime]) VALUES (26, 10, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:13:22.3632896' AS DateTime2), NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ImageToTable] ([ImageId], [TableId], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime]) VALUES (4, 1, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:48:34.3621200' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[ImageToTable] ([ImageId], [TableId], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime]) VALUES (5, 2, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:49:44.4674271' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[ImageToTable] ([ImageId], [TableId], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime]) VALUES (6, 3, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:50:24.7136265' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[ImageToTable] ([ImageId], [TableId], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime]) VALUES (7, 4, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:51:23.3875941' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[ImageToTable] ([ImageId], [TableId], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime]) VALUES (8, 5, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:52:04.2214116' AS DateTime2), NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([Id], [UserId], [TableId], [TableRentalMinutePrice], [FromTime], [ToTime], [TotalPrice], [Description], [RefId], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted], [Status], [PayDateTime]) VALUES (1, 7, 3, 50, CAST(N'2024-03-02T10:30:00.0000000' AS DateTime2), CAST(N'2024-03-02T11:15:00.0000000' AS DateTime2), 187250, N'فوم کاپوچینو زیاد نباشد', 12345678, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 7, CAST(N'2024-03-01T13:23:42.7456543' AS DateTime2), N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', NULL, CAST(N'2024-03-01T13:26:03.0019137' AS DateTime2), 0, 1, CAST(N'2024-03-01T16:56:03.0017630' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderItems] ON 

INSERT [dbo].[OrderItems] ([Id], [ProductId], [OrderId], [UnitPrice], [Amount], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (1, 7, 1, 35000, 1, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 7, CAST(N'2024-03-01T13:23:42.7456543' AS DateTime2), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[OrderItems] ([Id], [ProductId], [OrderId], [UnitPrice], [Amount], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (2, 1, 1, 150000, 1, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 7, CAST(N'2024-03-01T13:23:42.7456543' AS DateTime2), NULL, NULL, NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[OrderItems] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [Title], [Slug], [Description], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted], [Price]) VALUES (1, N'پیتزا مخصوص', N'pizza-makhsos', N'پیتزا', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:04:25.3259060' AS DateTime2), NULL, NULL, NULL, NULL, 0, 150000)
INSERT [dbo].[Products] ([Id], [Title], [Slug], [Description], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted], [Price]) VALUES (2, N'ساندویچ ماکارونی', N'makaroni-sandwich', N'ساندویچ ماکارونی', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:05:25.2846397' AS DateTime2), NULL, NULL, NULL, NULL, 0, 60000)
INSERT [dbo].[Products] ([Id], [Title], [Slug], [Description], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted], [Price]) VALUES (3, N'خورشت سبری', N'khoresht-sabzi', N'خورشت سبری همراه با ترشی و آبلمو', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:06:26.8453954' AS DateTime2), NULL, NULL, NULL, NULL, 0, 120000)
INSERT [dbo].[Products] ([Id], [Title], [Slug], [Description], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted], [Price]) VALUES (4, N'خورشت قیمه', N'khoresht-gheyme', N'خورشت قیمه همراه با مخلفات', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:07:00.9739134' AS DateTime2), NULL, NULL, NULL, NULL, 0, 140000)
INSERT [dbo].[Products] ([Id], [Title], [Slug], [Description], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted], [Price]) VALUES (5, N'اسپرسو تک', N'expresso-one', N'اسپرو تک همراه با شکلات', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:07:56.4067470' AS DateTime2), NULL, NULL, NULL, NULL, 0, 20000)
INSERT [dbo].[Products] ([Id], [Title], [Slug], [Description], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted], [Price]) VALUES (6, N'اسپرسو دبل', N'expresso-duble', N'اسپرو دبل همراه با شکلات', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:08:22.1386670' AS DateTime2), NULL, NULL, NULL, NULL, 0, 25000)
INSERT [dbo].[Products] ([Id], [Title], [Slug], [Description], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted], [Price]) VALUES (7, N'کاپوچینو', N'Cappuccino', N'کاپوچینو', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:09:08.7772709' AS DateTime2), NULL, NULL, NULL, NULL, 0, 35000)
INSERT [dbo].[Products] ([Id], [Title], [Slug], [Description], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted], [Price]) VALUES (8, N'پپسی مشکی خانواده', N'pepsi-meshki-khanevade', N'نوشابه پپسی مشکلی بزرگ', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:10:45.1956205' AS DateTime2), NULL, NULL, NULL, NULL, 0, 50000)
INSERT [dbo].[Products] ([Id], [Title], [Slug], [Description], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted], [Price]) VALUES (9, N'پپسی مشکی کوچک', N'pepsi-meshki-small', N'نوشابه پپسی مشکلی کوچک', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:11:26.2753018' AS DateTime2), NULL, NULL, NULL, NULL, 0, 20000)
INSERT [dbo].[Products] ([Id], [Title], [Slug], [Description], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted], [Price]) VALUES (10, N'لاته', N'Latte', N'قهوه لاته (اسپرسو + فوم شیر)', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:13:22.3632896' AS DateTime2), NULL, NULL, NULL, NULL, 0, 35000)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
INSERT [dbo].[ProductToBranch] ([ProductId], [BranchId], [IsAvailable], [IsActive], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime]) VALUES (1, 1, 1, 1, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:14:23.2613857' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[ProductToBranch] ([ProductId], [BranchId], [IsAvailable], [IsActive], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime]) VALUES (1, 2, 1, 1, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:14:26.1495769' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[ProductToBranch] ([ProductId], [BranchId], [IsAvailable], [IsActive], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime]) VALUES (2, 1, 1, 1, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:14:31.7830307' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[ProductToBranch] ([ProductId], [BranchId], [IsAvailable], [IsActive], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime]) VALUES (2, 2, 1, 1, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:14:34.3550968' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[ProductToBranch] ([ProductId], [BranchId], [IsAvailable], [IsActive], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime]) VALUES (3, 1, 1, 1, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:14:40.9290377' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[ProductToBranch] ([ProductId], [BranchId], [IsAvailable], [IsActive], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime]) VALUES (4, 1, 1, 1, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:14:45.5793125' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[ProductToBranch] ([ProductId], [BranchId], [IsAvailable], [IsActive], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime]) VALUES (5, 1, 1, 1, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:14:49.5528386' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[ProductToBranch] ([ProductId], [BranchId], [IsAvailable], [IsActive], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime]) VALUES (5, 2, 1, 1, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:15:44.5799599' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[ProductToBranch] ([ProductId], [BranchId], [IsAvailable], [IsActive], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime]) VALUES (6, 1, 1, 1, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:14:55.2470602' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[ProductToBranch] ([ProductId], [BranchId], [IsAvailable], [IsActive], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime]) VALUES (6, 2, 1, 1, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:15:48.2487735' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[ProductToBranch] ([ProductId], [BranchId], [IsAvailable], [IsActive], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime]) VALUES (7, 1, 1, 1, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:15:02.7551446' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[ProductToBranch] ([ProductId], [BranchId], [IsAvailable], [IsActive], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime]) VALUES (7, 2, 1, 1, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:15:53.5075904' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[ProductToBranch] ([ProductId], [BranchId], [IsAvailable], [IsActive], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime]) VALUES (8, 2, 1, 1, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:15:57.1443418' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[ProductToBranch] ([ProductId], [BranchId], [IsAvailable], [IsActive], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime]) VALUES (9, 2, 1, 1, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:16:02.2747761' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[ProductToBranch] ([ProductId], [BranchId], [IsAvailable], [IsActive], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime]) VALUES (10, 1, 1, 1, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:15:10.2937378' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[ProductToBranch] ([ProductId], [BranchId], [IsAvailable], [IsActive], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime]) VALUES (10, 2, 1, 1, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T13:16:06.4264517' AS DateTime2), NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (1, NULL, NULL, NULL, CAST(N'2024-03-01T12:27:46.0198593' AS DateTime2), NULL, NULL, NULL, NULL, N'Admin', N'ADMIN', NULL)
INSERT [dbo].[Roles] ([Id], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (2, NULL, NULL, NULL, CAST(N'2024-03-01T12:27:46.1728337' AS DateTime2), NULL, NULL, NULL, NULL, N'BranchManager', N'BRANCHMANAGER', NULL)
INSERT [dbo].[Roles] ([Id], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (3, NULL, NULL, NULL, CAST(N'2024-03-01T12:27:46.1789886' AS DateTime2), NULL, NULL, NULL, NULL, N'ProductManager', N'PRODUCTMANAGER', NULL)
INSERT [dbo].[Roles] ([Id], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (4, NULL, NULL, NULL, CAST(N'2024-03-01T12:27:46.1821894' AS DateTime2), NULL, NULL, NULL, NULL, N'TableManager', N'TABLEMANAGER', NULL)
INSERT [dbo].[Roles] ([Id], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (5, NULL, NULL, NULL, CAST(N'2024-03-01T12:27:46.1877169' AS DateTime2), NULL, NULL, NULL, NULL, N'CategoryManager', N'CATEGORYMANAGER', NULL)
INSERT [dbo].[Roles] ([Id], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (6, NULL, NULL, NULL, CAST(N'2024-03-01T12:27:46.1911948' AS DateTime2), NULL, NULL, NULL, NULL, N'OrderManage', N'ORDERMANAGE', NULL)
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Tables] ON 

INSERT [dbo].[Tables] ([Id], [Title], [Slug], [Description], [Space], [RentalMinutePrice], [IsAvailable], [BranchId], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (1, N'میز دو نفره کد 0', N'do-nafare-code-0', N'برای شما و دوستتان', 2, 100, 1, 1, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:48:34.3621200' AS DateTime2), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Tables] ([Id], [Title], [Slug], [Description], [Space], [RentalMinutePrice], [IsAvailable], [BranchId], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (2, N'میز چهار نفره کد 1', N'chahar-nafare-code-1', N'برای شما و دوستانتان', 4, 200, 1, 1, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:49:44.4674271' AS DateTime2), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Tables] ([Id], [Title], [Slug], [Description], [Space], [RentalMinutePrice], [IsAvailable], [BranchId], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (3, N'میز یک نفره کد 2', N'yek-nafare-code-2', N'فقط برای شما', 1, 50, 1, 1, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:50:24.7136265' AS DateTime2), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Tables] ([Id], [Title], [Slug], [Description], [Space], [RentalMinutePrice], [IsAvailable], [BranchId], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (4, N'میز هفت نفره کد 3', N'haft-nafare-code-2', N'برای خانواده شما', 7, 420, 1, 2, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:51:23.3875941' AS DateTime2), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Tables] ([Id], [Title], [Slug], [Description], [Space], [RentalMinutePrice], [IsAvailable], [BranchId], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [IsDeleted]) VALUES (5, N'میز سه نفره کد 4', N'se-nafare-code-4', N'برای اکیپ شما', 3, 180, 1, 2, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:52:04.2214116' AS DateTime2), NULL, NULL, NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[Tables] OFF
GO
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (1, 1)
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (2, 2)
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (3, 2)
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [SendCodeLastTime], [IsActive], [AvatarId]) VALUES (1, NULL, NULL, NULL, CAST(N'2024-03-01T12:27:46.4834865' AS DateTime2), N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', NULL, CAST(N'2024-03-01T12:31:51.1054607' AS DateTime2), N'Admin', N'ADMIN', N'admin@test.com', N'ADMIN@TEST.COM', 1, N'AQAAAAIAAYagAAAAEHc27nI07aVi54Ja0XkMGAjRr2RUs6jtjmpu3nb1EraVkEdsPni6Izt0TjOjd6BLKA==', N'7Y3K6RUDM6SEW5276F43WWX27RGLAEOS', N'c33cec2e-7953-48c3-9c41-170ad0db7bee', NULL, 0, 0, NULL, 1, 0, CAST(N'2024-03-01T16:01:51.0946007' AS DateTime2), 1, 1)
INSERT [dbo].[Users] ([Id], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [SendCodeLastTime], [IsActive], [AvatarId]) VALUES (2, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', NULL, CAST(N'2024-03-01T12:29:15.1237626' AS DateTime2), N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:53:24.8213534' AS DateTime2), N'taqinasiri', N'TAQINASIRI', N'taqinasiri@outlook.com', N'TAQINASIRI@OUTLOOK.COM', 0, NULL, N'Q44EXYDAAQ5ZXBJAZQMH2U4TMSNFQNI4', N'c4246706-0947-4909-a23f-7df497aad5cb', NULL, 0, 0, NULL, 1, 0, CAST(N'2024-03-01T15:59:15.1144028' AS DateTime2), 1, NULL)
INSERT [dbo].[Users] ([Id], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [SendCodeLastTime], [IsActive], [AvatarId]) VALUES (3, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', NULL, CAST(N'2024-03-01T12:29:45.2813858' AS DateTime2), N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', 1, CAST(N'2024-03-01T12:53:31.3799754' AS DateTime2), N'sara', N'SARA', N'sara@gmail.com', N'SARA@GMAIL.COM', 0, NULL, N'PFO6UXGBHAPYQSMPE5XPG34RYGDC4EU2', N'aa4c1b15-63fc-4a3d-a89c-7be4eda9c4b8', NULL, 0, 0, NULL, 1, 0, CAST(N'2024-03-01T15:59:45.2737762' AS DateTime2), 1, NULL)
INSERT [dbo].[Users] ([Id], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [SendCodeLastTime], [IsActive], [AvatarId]) VALUES (4, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', NULL, CAST(N'2024-03-01T12:29:51.8165828' AS DateTime2), NULL, NULL, NULL, NULL, N'iman', N'IMAN', N'iman@gmail.com', N'IMAN@GMAIL.COM', 0, NULL, N'6LRXH6SD42YABBS4MEOG6Y6GJU52KBIC', N'b3dd770a-9acf-4713-a4d3-8aac847b928c', NULL, 0, 0, NULL, 1, 0, CAST(N'2024-03-01T15:59:51.8105327' AS DateTime2), 1, NULL)
INSERT [dbo].[Users] ([Id], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [SendCodeLastTime], [IsActive], [AvatarId]) VALUES (5, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', NULL, CAST(N'2024-03-01T12:29:57.2112159' AS DateTime2), NULL, NULL, NULL, NULL, N'javad', N'JAVAD', N'javad@gmail.com', N'JAVAD@GMAIL.COM', 0, NULL, N'JXY7AEISQYKTWDO4MR45UK4EKWOVDOY4', N'c13e621f-b114-4f55-a7b1-601ae0582cce', NULL, 0, 0, NULL, 1, 0, CAST(N'2024-03-01T15:59:57.1998247' AS DateTime2), 1, NULL)
INSERT [dbo].[Users] ([Id], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [SendCodeLastTime], [IsActive], [AvatarId]) VALUES (6, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', NULL, CAST(N'2024-03-01T12:30:02.0832225' AS DateTime2), NULL, NULL, NULL, NULL, N'reyhane', N'REYHANE', N'reyhane@gmail.com', N'REYHANE@GMAIL.COM', 0, NULL, N'VRQU5YFRRQYLXQHIMXIU7AAVDAWETXOD', N'4f79cf58-2c38-4879-b008-c012bc6f8177', NULL, 0, 0, NULL, 1, 0, CAST(N'2024-03-01T16:00:02.0738064' AS DateTime2), 1, NULL)
INSERT [dbo].[Users] ([Id], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [SendCodeLastTime], [IsActive], [AvatarId]) VALUES (7, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', NULL, CAST(N'2024-03-01T12:30:05.3463380' AS DateTime2), N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', NULL, CAST(N'2024-03-01T13:20:23.6417233' AS DateTime2), N'sahar', N'SAHAR', N'sahar@gmail.com', N'SAHAR@GMAIL.COM', 0, NULL, N'DB3LZINRDULJ5Y6C22IEXTEMEZMJGWQ5', N'41e0d791-ebbf-41dd-8fb9-7c2ac8695edc', NULL, 0, 0, NULL, 1, 0, CAST(N'2024-03-01T16:50:23.6197278' AS DateTime2), 1, NULL)
INSERT [dbo].[Users] ([Id], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [SendCodeLastTime], [IsActive], [AvatarId]) VALUES (8, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', NULL, CAST(N'2024-03-01T12:30:08.8922633' AS DateTime2), NULL, NULL, NULL, NULL, N'hadi', N'HADI', N'hadi@gmail.com', N'HADI@GMAIL.COM', 0, NULL, N'LGXH2KCCGZ5VMKFAIFVXBM4HSFIM3GUB', N'31d17b38-3b26-4b73-9b62-199f2ca44555', NULL, 0, 0, NULL, 1, 0, CAST(N'2024-03-01T16:00:08.8884782' AS DateTime2), 1, NULL)
INSERT [dbo].[Users] ([Id], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [SendCodeLastTime], [IsActive], [AvatarId]) VALUES (9, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', NULL, CAST(N'2024-03-01T12:30:13.5048659' AS DateTime2), NULL, NULL, NULL, NULL, N'ehsan', N'EHSAN', N'ehsan@gmail.com', N'EHSAN@GMAIL.COM', 0, NULL, N'D5FEZ22A67W2KCDX224ZCXUCRJ6WVZLY', N'ef35581b-dfe9-48d3-8437-e40b5735274d', NULL, 0, 0, NULL, 1, 0, CAST(N'2024-03-01T16:00:13.5001624' AS DateTime2), 1, NULL)
INSERT [dbo].[Users] ([Id], [CreatedByBrowserName], [CreatedByIp], [CreatedByUserId], [CreatedDateTime], [ModifiedByBrowserName], [ModifiedByIp], [ModifiedByUserId], [ModifiedDateTime], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [SendCodeLastTime], [IsActive], [AvatarId]) VALUES (10, N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0', N'::1', NULL, CAST(N'2024-03-01T12:30:17.8491095' AS DateTime2), NULL, NULL, NULL, NULL, N'hossein', N'HOSSEIN', N'hossein@gmail.com', N'HOSSEIN@GMAIL.COM', 0, NULL, N'CI6V4MXMASYC5NRGKJGND2UBW5AHHPUS', N'dc906a87-9007-45ef-bbd9-4f72e27f8cd2', NULL, 0, 0, NULL, 1, 0, CAST(N'2024-03-01T16:00:17.8458608' AS DateTime2), 1, NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
/****** Object:  Index [IX_Branches_AdminId]    Script Date: 3/1/2024 5:08:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_Branches_AdminId] ON [dbo].[Branches]
(
	[AdminId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Branches_Slug]    Script Date: 3/1/2024 5:08:09 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Branches_Slug] ON [dbo].[Branches]
(
	[Slug] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Branches_Title]    Script Date: 3/1/2024 5:08:09 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Branches_Title] ON [dbo].[Branches]
(
	[Title] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_BranchWorkingHours_BranchId]    Script Date: 3/1/2024 5:08:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_BranchWorkingHours_BranchId] ON [dbo].[BranchWorkingHours]
(
	[BranchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Categories_ImageId]    Script Date: 3/1/2024 5:08:09 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Categories_ImageId] ON [dbo].[Categories]
(
	[ImageId] ASC
)
WHERE ([ImageId] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Categories_ParentId]    Script Date: 3/1/2024 5:08:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_Categories_ParentId] ON [dbo].[Categories]
(
	[ParentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Categories_Slug]    Script Date: 3/1/2024 5:08:09 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Categories_Slug] ON [dbo].[Categories]
(
	[Slug] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Categories_Title]    Script Date: 3/1/2024 5:08:09 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Categories_Title] ON [dbo].[Categories]
(
	[Title] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_CategoryToProduct_CategoryId]    Script Date: 3/1/2024 5:08:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_CategoryToProduct_CategoryId] ON [dbo].[CategoryToProduct]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Images_Name]    Script Date: 3/1/2024 5:08:09 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Images_Name] ON [dbo].[Images]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ImageToBranch_ImageId]    Script Date: 3/1/2024 5:08:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_ImageToBranch_ImageId] ON [dbo].[ImageToBranch]
(
	[ImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ImageToProduct_ImageId]    Script Date: 3/1/2024 5:08:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_ImageToProduct_ImageId] ON [dbo].[ImageToProduct]
(
	[ImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ImageToTable_ImageId]    Script Date: 3/1/2024 5:08:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_ImageToTable_ImageId] ON [dbo].[ImageToTable]
(
	[ImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Order_TableId]    Script Date: 3/1/2024 5:08:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_Order_TableId] ON [dbo].[Order]
(
	[TableId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Order_UserId]    Script Date: 3/1/2024 5:08:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_Order_UserId] ON [dbo].[Order]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderItems_OrderId]    Script Date: 3/1/2024 5:08:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderItems_OrderId] ON [dbo].[OrderItems]
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderItems_ProductId]    Script Date: 3/1/2024 5:08:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderItems_ProductId] ON [dbo].[OrderItems]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Products_Slug]    Script Date: 3/1/2024 5:08:09 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Products_Slug] ON [dbo].[Products]
(
	[Slug] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Products_Title]    Script Date: 3/1/2024 5:08:09 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Products_Title] ON [dbo].[Products]
(
	[Title] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductToBranch_BranchId]    Script Date: 3/1/2024 5:08:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductToBranch_BranchId] ON [dbo].[ProductToBranch]
(
	[BranchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_RoleClaims_RoleId]    Script Date: 3/1/2024 5:08:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_RoleClaims_RoleId] ON [dbo].[RoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 3/1/2024 5:08:09 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[Roles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Tables_BranchId]    Script Date: 3/1/2024 5:08:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_Tables_BranchId] ON [dbo].[Tables]
(
	[BranchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Tables_Slug]    Script Date: 3/1/2024 5:08:09 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Tables_Slug] ON [dbo].[Tables]
(
	[Slug] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Tables_Title]    Script Date: 3/1/2024 5:08:09 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Tables_Title] ON [dbo].[Tables]
(
	[Title] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserClaims_UserId]    Script Date: 3/1/2024 5:08:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserClaims_UserId] ON [dbo].[UserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserLogins_UserId]    Script Date: 3/1/2024 5:08:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserLogins_UserId] ON [dbo].[UserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserRoles_RoleId]    Script Date: 3/1/2024 5:08:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserRoles_RoleId] ON [dbo].[UserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 3/1/2024 5:08:09 PM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[Users]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Users_AvatarId]    Script Date: 3/1/2024 5:08:09 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users_AvatarId] ON [dbo].[Users]
(
	[AvatarId] ASC
)
WHERE ([AvatarId] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 3/1/2024 5:08:09 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[Users]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Branches] ADD  DEFAULT (CONVERT([bigint],(0))) FOR [AdminId]
GO
ALTER TABLE [dbo].[Categories] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[Order] ADD  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ((0)) FOR [Price]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [SendCodeLastTime]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsActive]
GO
ALTER TABLE [dbo].[Branches]  WITH CHECK ADD  CONSTRAINT [FK_Branches_Users_AdminId] FOREIGN KEY([AdminId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Branches] CHECK CONSTRAINT [FK_Branches_Users_AdminId]
GO
ALTER TABLE [dbo].[BranchWorkingHours]  WITH CHECK ADD  CONSTRAINT [FK_BranchWorkingHours_Branches_BranchId] FOREIGN KEY([BranchId])
REFERENCES [dbo].[Branches] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BranchWorkingHours] CHECK CONSTRAINT [FK_BranchWorkingHours_Branches_BranchId]
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_Categories_Categories_ParentId] FOREIGN KEY([ParentId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_Categories_Categories_ParentId]
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_Categories_Images_ImageId] FOREIGN KEY([ImageId])
REFERENCES [dbo].[Images] ([Id])
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_Categories_Images_ImageId]
GO
ALTER TABLE [dbo].[CategoryToProduct]  WITH CHECK ADD  CONSTRAINT [FK_CategoryToProduct_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CategoryToProduct] CHECK CONSTRAINT [FK_CategoryToProduct_Categories_CategoryId]
GO
ALTER TABLE [dbo].[CategoryToProduct]  WITH CHECK ADD  CONSTRAINT [FK_CategoryToProduct_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CategoryToProduct] CHECK CONSTRAINT [FK_CategoryToProduct_Products_ProductId]
GO
ALTER TABLE [dbo].[ImageToBranch]  WITH CHECK ADD  CONSTRAINT [FK_ImageToBranch_Branches_BranchId] FOREIGN KEY([BranchId])
REFERENCES [dbo].[Branches] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ImageToBranch] CHECK CONSTRAINT [FK_ImageToBranch_Branches_BranchId]
GO
ALTER TABLE [dbo].[ImageToBranch]  WITH CHECK ADD  CONSTRAINT [FK_ImageToBranch_Images_ImageId] FOREIGN KEY([ImageId])
REFERENCES [dbo].[Images] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ImageToBranch] CHECK CONSTRAINT [FK_ImageToBranch_Images_ImageId]
GO
ALTER TABLE [dbo].[ImageToProduct]  WITH CHECK ADD  CONSTRAINT [FK_ImageToProduct_Images_ImageId] FOREIGN KEY([ImageId])
REFERENCES [dbo].[Images] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ImageToProduct] CHECK CONSTRAINT [FK_ImageToProduct_Images_ImageId]
GO
ALTER TABLE [dbo].[ImageToProduct]  WITH CHECK ADD  CONSTRAINT [FK_ImageToProduct_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ImageToProduct] CHECK CONSTRAINT [FK_ImageToProduct_Products_ProductId]
GO
ALTER TABLE [dbo].[ImageToTable]  WITH CHECK ADD  CONSTRAINT [FK_ImageToTable_Images_ImageId] FOREIGN KEY([ImageId])
REFERENCES [dbo].[Images] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ImageToTable] CHECK CONSTRAINT [FK_ImageToTable_Images_ImageId]
GO
ALTER TABLE [dbo].[ImageToTable]  WITH CHECK ADD  CONSTRAINT [FK_ImageToTable_Tables_TableId] FOREIGN KEY([TableId])
REFERENCES [dbo].[Tables] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ImageToTable] CHECK CONSTRAINT [FK_ImageToTable_Tables_TableId]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Tables_TableId] FOREIGN KEY([TableId])
REFERENCES [dbo].[Tables] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Tables_TableId]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Users_UserId]
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_OrderItems_Order_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderItems] CHECK CONSTRAINT [FK_OrderItems_Order_OrderId]
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_OrderItems_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderItems] CHECK CONSTRAINT [FK_OrderItems_Products_ProductId]
GO
ALTER TABLE [dbo].[ProductToBranch]  WITH CHECK ADD  CONSTRAINT [FK_ProductToBranch_Branches_BranchId] FOREIGN KEY([BranchId])
REFERENCES [dbo].[Branches] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductToBranch] CHECK CONSTRAINT [FK_ProductToBranch_Branches_BranchId]
GO
ALTER TABLE [dbo].[ProductToBranch]  WITH CHECK ADD  CONSTRAINT [FK_ProductToBranch_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductToBranch] CHECK CONSTRAINT [FK_ProductToBranch_Products_ProductId]
GO
ALTER TABLE [dbo].[RoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_RoleClaims_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RoleClaims] CHECK CONSTRAINT [FK_RoleClaims_Roles_RoleId]
GO
ALTER TABLE [dbo].[Tables]  WITH CHECK ADD  CONSTRAINT [FK_Tables_Branches_BranchId] FOREIGN KEY([BranchId])
REFERENCES [dbo].[Branches] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tables] CHECK CONSTRAINT [FK_Tables_Branches_BranchId]
GO
ALTER TABLE [dbo].[UserClaims]  WITH CHECK ADD  CONSTRAINT [FK_UserClaims_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserClaims] CHECK CONSTRAINT [FK_UserClaims_Users_UserId]
GO
ALTER TABLE [dbo].[UserLogins]  WITH CHECK ADD  CONSTRAINT [FK_UserLogins_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserLogins] CHECK CONSTRAINT [FK_UserLogins_Users_UserId]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Roles_RoleId]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Users_UserId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Images_AvatarId] FOREIGN KEY([AvatarId])
REFERENCES [dbo].[Images] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Images_AvatarId]
GO
ALTER TABLE [dbo].[UserTokens]  WITH CHECK ADD  CONSTRAINT [FK_UserTokens_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserTokens] CHECK CONSTRAINT [FK_UserTokens_Users_UserId]
GO
USE [master]
GO
ALTER DATABASE [RestaurantDb] SET  READ_WRITE 
GO
