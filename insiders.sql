USE [Finviz]
GO

/****** Object:  Table [dbo].[insiders]    Script Date: 10/05/2022 00:30:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[insiders](
	[iddownload] [varchar](50) NOT NULL,
	[ticker] [varchar](50) NOT NULL,
	[date] [datetime] NOT NULL,
	[tradedate] [datetime] NOT NULL,
	[insidername] [varchar](200) NOT NULL,
	[title] [varchar](100) NOT NULL,
	[tradetype] [varchar](50) NOT NULL,
	[price] [float] NOT NULL,
	[value] [float] NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


