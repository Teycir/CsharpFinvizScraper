USE [Finviz]
GO

/****** Object:  Table [dbo].[findata]    Script Date: 10/05/2022 00:32:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[findata](
	[iddownload] [varchar](45) NULL DEFAULT ('0'),
	[ticker] [varchar](10) NOT NULL,
	[date] [datetime] NOT NULL,
	[price] [float] NULL DEFAULT (NULL),
	[targetprice] [float] NULL DEFAULT (NULL),
	[volume] [float] NULL DEFAULT (NULL),
	[relvolume] [float] NULL DEFAULT (NULL),
	[rsi14] [float] NULL DEFAULT (NULL),
	[whigh] [float] NULL DEFAULT (NULL),
	[wlow] [float] NULL DEFAULT (NULL),
	[shortratio] [float] NULL DEFAULT (NULL),
	[shortfloat] [float] NULL DEFAULT (NULL),
	[instown] [float] NULL DEFAULT (NULL),
	[insttrans] [float] NULL DEFAULT (NULL),
	[insidown] [float] NULL DEFAULT (NULL),
	[insidtrans] [float] NULL DEFAULT (NULL),
	[profitmargin] [float] NULL DEFAULT (NULL),
	[debteq] [float] NULL DEFAULT (NULL),
	[peg] [float] NULL DEFAULT (NULL),
	[pe] [float] NULL DEFAULT (NULL),
	[forwardpe] [float] NULL DEFAULT (NULL),
	[pricetobook] [float] NULL DEFAULT (NULL),
	[booksh] [float] NULL DEFAULT (NULL),
	[cashsh] [float] NULL DEFAULT (NULL),
	[reco] [float] NULL DEFAULT (NULL),
	[dividendpercent] [float] NULL DEFAULT (NULL),
	[perfyear] [float] NULL DEFAULT (NULL),
	[perfhalfyear] [float] NULL DEFAULT (NULL),
	[employees] [float] NULL DEFAULT (NULL),
	[optionable] [varchar](4) NULL DEFAULT (NULL),
	[shortable] [varchar](4) NULL DEFAULT (NULL),
	[sector] [varchar](100) NULL DEFAULT (NULL),
	[industry] [varchar](100) NULL DEFAULT (NULL),
	[country] [varchar](100) NULL DEFAULT (NULL)
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


