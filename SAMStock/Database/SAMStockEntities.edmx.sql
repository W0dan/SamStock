
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/04/2014 18:30:04
-- Generated from EDMX file: E:\Documents\Visual Studio 2013\Projects\SAMStock\SAMStock\Database\SAMStockEntities.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SAMStock];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Component_Leverancier]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Components] DROP CONSTRAINT [FK_Component_Leverancier];
GO
IF OBJECT_ID(N'[dbo].[FK_PedalComponent_Component]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ComponentsOfPedals] DROP CONSTRAINT [FK_PedalComponent_Component];
GO
IF OBJECT_ID(N'[dbo].[FK_PedalComponent_Pedaal]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ComponentsOfPedals] DROP CONSTRAINT [FK_PedalComponent_Pedaal];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Components]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Components];
GO
IF OBJECT_ID(N'[dbo].[ComponentsOfPedals]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ComponentsOfPedals];
GO
IF OBJECT_ID(N'[dbo].[Config]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Config];
GO
IF OBJECT_ID(N'[dbo].[Pedals]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pedals];
GO
IF OBJECT_ID(N'[dbo].[Suppliers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Suppliers];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Components'
CREATE TABLE [dbo].[Components] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [MinimumStock] int  NOT NULL,
    [Stock] int  NOT NULL,
    [StockNumber] nvarchar(20)  NOT NULL,
    [Price] decimal(10,4)  NOT NULL,
    [SupplierId] int  NOT NULL,
    [Remarks] nvarchar(max)  NULL,
    [ItemCode] nchar(7)  NOT NULL
);
GO

-- Creating table 'ComponentsOfPedals'
CREATE TABLE [dbo].[ComponentsOfPedals] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ComponentId] int  NOT NULL,
    [Amount] int  NOT NULL,
    [PedalId] int  NOT NULL
);
GO

-- Creating table 'Config'
CREATE TABLE [dbo].[Config] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [VAT] decimal(10,4)  NOT NULL,
    [DefaultPedalProfitMargin] decimal(10,4)  NOT NULL
);
GO

-- Creating table 'Pedals'
CREATE TABLE [dbo].[Pedals] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Price] decimal(10,4)  NOT NULL,
    [ProfitMargin] decimal(10,4)  NULL
);
GO

-- Creating table 'Suppliers'
CREATE TABLE [dbo].[Suppliers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NULL,
    [Website] nvarchar(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Components'
ALTER TABLE [dbo].[Components]
ADD CONSTRAINT [PK_Components]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ComponentsOfPedals'
ALTER TABLE [dbo].[ComponentsOfPedals]
ADD CONSTRAINT [PK_ComponentsOfPedals]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Config'
ALTER TABLE [dbo].[Config]
ADD CONSTRAINT [PK_Config]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Pedals'
ALTER TABLE [dbo].[Pedals]
ADD CONSTRAINT [PK_Pedals]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Suppliers'
ALTER TABLE [dbo].[Suppliers]
ADD CONSTRAINT [PK_Suppliers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [SupplierId] in table 'Components'
ALTER TABLE [dbo].[Components]
ADD CONSTRAINT [FK_Component_Leverancier]
    FOREIGN KEY ([SupplierId])
    REFERENCES [dbo].[Suppliers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Component_Leverancier'
CREATE INDEX [IX_FK_Component_Leverancier]
ON [dbo].[Components]
    ([SupplierId]);
GO

-- Creating foreign key on [ComponentId] in table 'ComponentsOfPedals'
ALTER TABLE [dbo].[ComponentsOfPedals]
ADD CONSTRAINT [FK_PedalComponent_Component]
    FOREIGN KEY ([ComponentId])
    REFERENCES [dbo].[Components]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PedalComponent_Component'
CREATE INDEX [IX_FK_PedalComponent_Component]
ON [dbo].[ComponentsOfPedals]
    ([ComponentId]);
GO

-- Creating foreign key on [PedalId] in table 'ComponentsOfPedals'
ALTER TABLE [dbo].[ComponentsOfPedals]
ADD CONSTRAINT [FK_PedalComponent_Pedaal]
    FOREIGN KEY ([PedalId])
    REFERENCES [dbo].[Pedals]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PedalComponent_Pedaal'
CREATE INDEX [IX_FK_PedalComponent_Pedaal]
ON [dbo].[ComponentsOfPedals]
    ([PedalId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------