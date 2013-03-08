USE [StockBeheer]
GO
/****** Object:  Table [dbo].[Leverancier]    Script Date: 03/08/2013 14:48:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Leverancier](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Naam] [nvarchar](max) NOT NULL,
	[Adres] [nvarchar](max) NULL,
	[Site] [nvarchar](max) NULL,
 CONSTRAINT [PK_Leverancier] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Component]    Script Date: 03/08/2013 14:48:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Component](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Naam] [nvarchar](max) NOT NULL,
	[MinimumStock] [int] NOT NULL,
	[Hoeveelheid] [int] NOT NULL,
	[Stocknr] [nvarchar](20) NOT NULL,
	[Prijs] [numeric](10, 4) NOT NULL,
	[LeverancierId] [int] NOT NULL,
	[Opmerkingen] [nvarchar](max) NULL,
 CONSTRAINT [PK_Component] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF_Component_MinimumStock]    Script Date: 03/08/2013 14:48:52 ******/
ALTER TABLE [dbo].[Component] ADD  CONSTRAINT [DF_Component_MinimumStock]  DEFAULT ((0)) FOR [MinimumStock]
GO
/****** Object:  ForeignKey [FK_Component_Leverancier]    Script Date: 03/08/2013 14:48:52 ******/
ALTER TABLE [dbo].[Component]  WITH CHECK ADD  CONSTRAINT [FK_Component_Leverancier] FOREIGN KEY([LeverancierId])
REFERENCES [dbo].[Leverancier] ([Id])
GO
ALTER TABLE [dbo].[Component] CHECK CONSTRAINT [FK_Component_Leverancier]
GO
