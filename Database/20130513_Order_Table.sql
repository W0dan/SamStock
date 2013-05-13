USE [StockBeheer]
GO

/****** Object:  Table [dbo].[Component]    Script Date: 05/13/2013 14:41:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SupplierId] int NOT NULL,
	[DateCreation] datetime2 NOT NULL,
	[DateOrdered] datetime2 NULL
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Leverancier] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Leverancier] ([Id])
GO

CREATE TABLE [dbo].[OrderLine](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] int NOT NULL,
	[ComponentId] int NOT NULL,
	[Amount] int NOT NULL
 CONSTRAINT [PK_OrderLine] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[OrderLine]  WITH CHECK ADD  CONSTRAINT [FK_OrderLine_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([Id])
GO

ALTER TABLE [dbo].[OrderLine]  WITH CHECK ADD  CONSTRAINT [FK_OrderLine_Component] FOREIGN KEY([ComponentId])
REFERENCES [dbo].[Component] ([Id])
GO
