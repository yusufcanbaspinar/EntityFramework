
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/12/2019 15:58:28
-- Generated from EDMX file: C:\Users\Section2\source\repos\NT_EntityFramework\EF_ModelFirst\AccountingSystemModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [AcountingSystem2];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'InvoiceHeaders'
CREATE TABLE [dbo].[InvoiceHeaders] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Total] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'InvoiceDetails'
CREATE TABLE [dbo].[InvoiceDetails] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ItemDescription] nvarchar(max)  NOT NULL,
    [Quantity] int  NOT NULL,
    [Price] decimal(18,0)  NOT NULL,
    [InvoiceHeaderId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'InvoiceHeaders'
ALTER TABLE [dbo].[InvoiceHeaders]
ADD CONSTRAINT [PK_InvoiceHeaders]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'InvoiceDetails'
ALTER TABLE [dbo].[InvoiceDetails]
ADD CONSTRAINT [PK_InvoiceDetails]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [InvoiceHeaderId] in table 'InvoiceDetails'
ALTER TABLE [dbo].[InvoiceDetails]
ADD CONSTRAINT [FK_InvoiceHeaderInvoiceDetail]
    FOREIGN KEY ([InvoiceHeaderId])
    REFERENCES [dbo].[InvoiceHeaders]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_InvoiceHeaderInvoiceDetail'
CREATE INDEX [IX_FK_InvoiceHeaderInvoiceDetail]
ON [dbo].[InvoiceDetails]
    ([InvoiceHeaderId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------