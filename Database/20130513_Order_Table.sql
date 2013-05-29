USE [stockbeheer]
GO
/****** Object:  Table [dbo].[AcquirementNumber]    Script Date: 05/29/2013 19:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AcquirementNumber](
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_AcquirementNumber] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReasonOrdered]    Script Date: 05/29/2013 19:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReasonOrdered](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Reason] [nvarchar](max) NOT NULL,
	[PedalModelId] [int] NULL,
 CONSTRAINT [PK_ReasonOrdered] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 05/29/2013 19:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] NOT NULL,
	[SupplierId] [int] NOT NULL,
	[DateCreation] [datetime2](7) NOT NULL,
	[DateOrdered] [datetime2](7) NULL,
	[DeliveryCosts] [numeric](18, 6) NOT NULL,
	[FinancialDiscount] [numeric](18, 6) NOT NULL,
	[CommercialDiscount] [numeric](18, 6) NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderLine]    Script Date: 05/29/2013 19:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderLine](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ComponentId] [int] NOT NULL,
	[Amount] [int] NOT NULL,
	[Comment] [nvarchar](max) NULL,
	[OrderedBecauseOf] [int] NOT NULL,
 CONSTRAINT [PK_OrderLine] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF_Order_DateCreation]    Script Date: 05/29/2013 19:41:14 ******/
ALTER TABLE [dbo].[Order] ADD  CONSTRAINT [DF_Order_DateCreation]  DEFAULT (getdate()) FOR [DateCreation]
GO
/****** Object:  Default [DF_Order_DeliveryCosts]    Script Date: 05/29/2013 19:41:14 ******/
ALTER TABLE [dbo].[Order] ADD  CONSTRAINT [DF_Order_DeliveryCosts]  DEFAULT ((0)) FOR [DeliveryCosts]
GO
/****** Object:  Default [DF_Order_FinancialDiscount]    Script Date: 05/29/2013 19:41:14 ******/
ALTER TABLE [dbo].[Order] ADD  CONSTRAINT [DF_Order_FinancialDiscount]  DEFAULT ((0)) FOR [FinancialDiscount]
GO
/****** Object:  Default [DF_Order_CommercialDiscount]    Script Date: 05/29/2013 19:41:14 ******/
ALTER TABLE [dbo].[Order] ADD  CONSTRAINT [DF_Order_CommercialDiscount]  DEFAULT ((0)) FOR [CommercialDiscount]
GO
/****** Object:  ForeignKey [FK_Order_Leverancier]    Script Date: 05/29/2013 19:41:14 ******/
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Leverancier] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Leverancier] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Leverancier]
GO
/****** Object:  ForeignKey [FK_OrderLine_Component]    Script Date: 05/29/2013 19:41:14 ******/
ALTER TABLE [dbo].[OrderLine]  WITH CHECK ADD  CONSTRAINT [FK_OrderLine_Component] FOREIGN KEY([ComponentId])
REFERENCES [dbo].[Component] ([Id])
GO
ALTER TABLE [dbo].[OrderLine] CHECK CONSTRAINT [FK_OrderLine_Component]
GO
/****** Object:  ForeignKey [FK_OrderLine_Order]    Script Date: 05/29/2013 19:41:14 ******/
ALTER TABLE [dbo].[OrderLine]  WITH CHECK ADD  CONSTRAINT [FK_OrderLine_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([Id])
GO
ALTER TABLE [dbo].[OrderLine] CHECK CONSTRAINT [FK_OrderLine_Order]
GO
