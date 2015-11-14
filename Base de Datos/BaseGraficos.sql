USE [master]
GO

/****** Object:  Database [Graficos]    Script Date: 14/11/2015 4:38:45 ******/
CREATE DATABASE [Graficos]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Graficos', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Graficos.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Graficos_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Graficos_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [Graficos] SET COMPATIBILITY_LEVEL = 120
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Graficos].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Graficos] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Graficos] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Graficos] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Graficos] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Graficos] SET ARITHABORT OFF 
GO

ALTER DATABASE [Graficos] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Graficos] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Graficos] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Graficos] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Graficos] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Graficos] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Graficos] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Graficos] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Graficos] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Graficos] SET  DISABLE_BROKER 
GO

ALTER DATABASE [Graficos] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Graficos] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Graficos] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Graficos] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Graficos] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Graficos] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [Graficos] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Graficos] SET RECOVERY FULL 
GO

ALTER DATABASE [Graficos] SET  MULTI_USER 
GO

ALTER DATABASE [Graficos] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Graficos] SET DB_CHAINING OFF 
GO

ALTER DATABASE [Graficos] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [Graficos] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [Graficos] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [Graficos] SET  READ_WRITE 
GO