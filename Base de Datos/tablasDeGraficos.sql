USE [Graficos]
GO
------------jobA-------------------------------------------------------------------
/****** Object:  Table [dbo].[jobA]    Script Date: 14/11/2015 4:39:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[jobA](
	[producto] [nchar](50) NULL,
	[version] [nchar](10) NULL,
	[codigoError] [nvarchar](50) NULL,
	[cantidadErrores] [numeric](18, 0) NULL
) ON [PRIMARY]

GO
-----------jobB---------------------------------------------------------------------
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[jobB](
	[producto] [nchar](50) NULL,
	[version] [nchar](10) NULL,
	[mes] [nchar](10) NULL,
	[codigoError] [nvarchar](50) NULL,
	[cantidadErrores] [numeric](18, 0) NULL
) ON [PRIMARY]

GO
---------jobC----------------------------------------------------------------------------
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[jobC](
	[producto] [nchar](50) NULL,
	[mes] [nchar](10) NULL,
	[codigoError] [nvarchar](50) NULL,
	[cantidadErrores] [numeric](18, 0) NULL
) ON [PRIMARY]

GO
---------jobD------------------------------------------------------------------------------
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[jobD](
	[mes] [nchar](10) NULL,
	[codigoError] [nvarchar](50) NULL,
	[cantidadErrores] [numeric](18, 0) NULL
) ON [PRIMARY]

GO
-------jobE----------------------------------------------------------------------------
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[jobE](
	[producto] [nchar](50) NULL,
	[version] [nchar](10) NULL,
	[cantidadErrores] [numeric](18, 0) NULL
) ON [PRIMARY]

GO
----------jobF----------------------------------------------------------------------------
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[jobF](
	[producto] [nchar](50) NULL,
	[codigoError] [nvarchar](50) NULL,
	[cantidadErrores] [numeric](18, 0) NULL
) ON [PRIMARY]

GO
--------jobG------------------------------------------------------------------------------
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[jobG](
	[codigoError] [nvarchar](50) NULL,
	[errorStack] [nvarchar](50) NULL
) ON [PRIMARY]

GO