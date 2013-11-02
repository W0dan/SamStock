USE [Stockbeheer]
GO
/****** Object:  User [YORICK-PC\NorrlandDbLogin]    Script Date: 07/01/2013 18:49:05 ******/
CREATE USER [YORICK-PC\NorrlandDbLogin] FOR LOGIN [YORICK-PC\NorrlandDbLogin] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[AdminData]    Script Date: 07/01/2013 18:49:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Value] [numeric](10, 4) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 07/01/2013 18:49:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NULL,
	[Website] [nvarchar](max) NULL,
 CONSTRAINT [PK_Leverancier] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedal]    Script Date: 07/01/2013 18:49:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedal](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Price] [numeric](10, 4) NOT NULL,
	[Margin] [numeric](10, 4) NOT NULL,
 CONSTRAINT [PK_Pedaal] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Component]    Script Date: 07/01/2013 18:49:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Component](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[MinimumStock] [int] NOT NULL,
	[Stock] [int] NOT NULL,
	[Stocknr] [nvarchar](20) NOT NULL,
	[Price] [numeric](10, 4) NOT NULL,
	[SupplierId] [int] NOT NULL,
	[Remarks] [nvarchar](max) NULL,
	[ItemCode] [nchar](7) NOT NULL,
 CONSTRAINT [PK_Component] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PedalComponent]    Script Date: 07/01/2013 18:49:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PedalComponent](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ComponentId] [int] NOT NULL,
	[Number] [int] NOT NULL,
	[PedalId] [int] NOT NULL,
 CONSTRAINT [PK_PedaalComponent] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF_Pedal_Margin]    Script Date: 07/01/2013 18:49:07 ******/
ALTER TABLE [dbo].[Pedal] ADD  CONSTRAINT [DF_Pedal_Margin]  DEFAULT ((0)) FOR [Margin]
GO
/****** Object:  Default [DF_Component_MinimumStock]    Script Date: 07/01/2013 18:49:07 ******/
ALTER TABLE [dbo].[Component] ADD  CONSTRAINT [DF_Component_MinimumStock]  DEFAULT ((0)) FOR [MinimumStock]
GO
/****** Object:  ForeignKey [FK_Component_Leverancier]    Script Date: 07/01/2013 18:49:07 ******/
ALTER TABLE [dbo].[Component]  WITH CHECK ADD  CONSTRAINT [FK_Component_Leverancier] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Supplier] ([Id])
GO
ALTER TABLE [dbo].[Component] CHECK CONSTRAINT [FK_Component_Leverancier]
GO
/****** Object:  ForeignKey [FK_PedalComponent_Component]    Script Date: 07/01/2013 18:49:07 ******/
ALTER TABLE [dbo].[PedalComponent]  WITH CHECK ADD  CONSTRAINT [FK_PedalComponent_Component] FOREIGN KEY([ComponentId])
REFERENCES [dbo].[Component] ([Id])
GO
ALTER TABLE [dbo].[PedalComponent] CHECK CONSTRAINT [FK_PedalComponent_Component]
GO
/****** Object:  ForeignKey [FK_PedalComponent_Pedaal]    Script Date: 07/01/2013 18:49:07 ******/
ALTER TABLE [dbo].[PedalComponent]  WITH CHECK ADD  CONSTRAINT [FK_PedalComponent_Pedaal] FOREIGN KEY([PedalId])
REFERENCES [dbo].[Pedal] ([Id])
GO
ALTER TABLE [dbo].[PedalComponent] CHECK CONSTRAINT [FK_PedalComponent_Pedaal]
GO
