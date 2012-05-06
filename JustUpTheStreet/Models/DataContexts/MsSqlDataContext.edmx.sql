
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 05/02/2012 23:43:07
-- Generated from EDMX file: C:\repository\JustUpTheStreet\JustUpTheStreet\Models\DataContexts\MsSqlDataContext.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [JustUpTheStreet];
GO
IF SCHEMA_ID(N'juts') IS NULL EXECUTE(N'CREATE SCHEMA [juts]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[juts].[FK_AccountClaim]', 'F') IS NOT NULL
    ALTER TABLE [juts].[Claims] DROP CONSTRAINT [FK_AccountClaim];
GO
IF OBJECT_ID(N'[juts].[FK_ClaimFulfillment]', 'F') IS NOT NULL
    ALTER TABLE [juts].[Fulfillments] DROP CONSTRAINT [FK_ClaimFulfillment];
GO
IF OBJECT_ID(N'[juts].[FK_ContributionAccount]', 'F') IS NOT NULL
    ALTER TABLE [juts].[Contributions] DROP CONSTRAINT [FK_ContributionAccount];
GO
IF OBJECT_ID(N'[juts].[FK_PrizeAccount]', 'F') IS NOT NULL
    ALTER TABLE [juts].[Prizes] DROP CONSTRAINT [FK_PrizeAccount];
GO
IF OBJECT_ID(N'[juts].[FK_PrizeRequirement]', 'F') IS NOT NULL
    ALTER TABLE [juts].[Requirements] DROP CONSTRAINT [FK_PrizeRequirement];
GO
IF OBJECT_ID(N'[juts].[FK_PrizeStatePrize]', 'F') IS NOT NULL
    ALTER TABLE [juts].[PrizeStates] DROP CONSTRAINT [FK_PrizeStatePrize];
GO
IF OBJECT_ID(N'[juts].[FK_RequirementFulfillment]', 'F') IS NOT NULL
    ALTER TABLE [juts].[Fulfillments] DROP CONSTRAINT [FK_RequirementFulfillment];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[aspnet_Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[aspnet_Users];
GO
IF OBJECT_ID(N'[juts].[Accounts]', 'U') IS NOT NULL
    DROP TABLE [juts].[Accounts];
GO
IF OBJECT_ID(N'[juts].[Claims]', 'U') IS NOT NULL
    DROP TABLE [juts].[Claims];
GO
IF OBJECT_ID(N'[juts].[Contributions]', 'U') IS NOT NULL
    DROP TABLE [juts].[Contributions];
GO
IF OBJECT_ID(N'[juts].[Fulfillments]', 'U') IS NOT NULL
    DROP TABLE [juts].[Fulfillments];
GO
IF OBJECT_ID(N'[juts].[Prizes]', 'U') IS NOT NULL
    DROP TABLE [juts].[Prizes];
GO
IF OBJECT_ID(N'[juts].[PrizeStates]', 'U') IS NOT NULL
    DROP TABLE [juts].[PrizeStates];
GO
IF OBJECT_ID(N'[juts].[Requirements]', 'U') IS NOT NULL
    DROP TABLE [juts].[Requirements];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Fulfillments'
CREATE TABLE [juts].[Fulfillments] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [RequirementId] bigint  NOT NULL,
    [ClaimId] bigint  NOT NULL
);
GO

-- Creating table 'Requirements'
CREATE TABLE [juts].[Requirements] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [PrizeId] int  NOT NULL,
    [Prize_Id] int  NOT NULL
);
GO

-- Creating table 'Contributions'
CREATE TABLE [juts].[Contributions] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Amount] float  NOT NULL,
    [ExpirationDate] datetime  NOT NULL,
    [Contributor_Id] bigint  NOT NULL
);
GO

-- Creating table 'Accounts'
CREATE TABLE [juts].[Accounts] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [AccountName] nvarchar(max)  NOT NULL,
    [DisplayName] nvarchar(max)  NOT NULL,
    [State] smallint  NOT NULL
);
GO

-- Creating table 'PrizeStates'
CREATE TABLE [juts].[PrizeStates] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [State] smallint  NOT NULL,
    [ExpirationDate] datetime  NOT NULL,
    [Prize_Id] int  NOT NULL
);
GO

-- Creating table 'Prizes'
CREATE TABLE [juts].[Prizes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Owner_Id] bigint  NOT NULL
);
GO

-- Creating table 'Claims'
CREATE TABLE [juts].[Claims] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [AccountId] bigint  NOT NULL
);
GO

-- Creating table 'aspnet_Users'
CREATE TABLE [juts].[aspnet_Users] (
    [ApplicationId] uniqueidentifier  NOT NULL,
    [UserId] uniqueidentifier  NOT NULL,
    [UserName] nvarchar(256)  NOT NULL,
    [LoweredUserName] nvarchar(256)  NOT NULL,
    [MobileAlias] nvarchar(16)  NULL,
    [IsAnonymous] bit  NOT NULL,
    [LastActivityDate] datetime  NOT NULL,
    [aspnet_UsersAccount_aspnet_Users_Id] bigint  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Fulfillments'
ALTER TABLE [juts].[Fulfillments]
ADD CONSTRAINT [PK_Fulfillments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Requirements'
ALTER TABLE [juts].[Requirements]
ADD CONSTRAINT [PK_Requirements]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Contributions'
ALTER TABLE [juts].[Contributions]
ADD CONSTRAINT [PK_Contributions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Accounts'
ALTER TABLE [juts].[Accounts]
ADD CONSTRAINT [PK_Accounts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PrizeStates'
ALTER TABLE [juts].[PrizeStates]
ADD CONSTRAINT [PK_PrizeStates]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Prizes'
ALTER TABLE [juts].[Prizes]
ADD CONSTRAINT [PK_Prizes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Claims'
ALTER TABLE [juts].[Claims]
ADD CONSTRAINT [PK_Claims]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [UserId] in table 'aspnet_Users'
ALTER TABLE [juts].[aspnet_Users]
ADD CONSTRAINT [PK_aspnet_Users]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Contributor_Id] in table 'Contributions'
ALTER TABLE [juts].[Contributions]
ADD CONSTRAINT [FK_ContributionAccount]
    FOREIGN KEY ([Contributor_Id])
    REFERENCES [juts].[Accounts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ContributionAccount'
CREATE INDEX [IX_FK_ContributionAccount]
ON [juts].[Contributions]
    ([Contributor_Id]);
GO

-- Creating foreign key on [Owner_Id] in table 'Prizes'
ALTER TABLE [juts].[Prizes]
ADD CONSTRAINT [FK_PrizeAccount]
    FOREIGN KEY ([Owner_Id])
    REFERENCES [juts].[Accounts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PrizeAccount'
CREATE INDEX [IX_FK_PrizeAccount]
ON [juts].[Prizes]
    ([Owner_Id]);
GO

-- Creating foreign key on [Prize_Id] in table 'PrizeStates'
ALTER TABLE [juts].[PrizeStates]
ADD CONSTRAINT [FK_PrizeStatePrize]
    FOREIGN KEY ([Prize_Id])
    REFERENCES [juts].[Prizes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PrizeStatePrize'
CREATE INDEX [IX_FK_PrizeStatePrize]
ON [juts].[PrizeStates]
    ([Prize_Id]);
GO

-- Creating foreign key on [Prize_Id] in table 'Requirements'
ALTER TABLE [juts].[Requirements]
ADD CONSTRAINT [FK_PrizeRequirement]
    FOREIGN KEY ([Prize_Id])
    REFERENCES [juts].[Prizes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PrizeRequirement'
CREATE INDEX [IX_FK_PrizeRequirement]
ON [juts].[Requirements]
    ([Prize_Id]);
GO

-- Creating foreign key on [AccountId] in table 'Claims'
ALTER TABLE [juts].[Claims]
ADD CONSTRAINT [FK_AccountClaim]
    FOREIGN KEY ([AccountId])
    REFERENCES [juts].[Accounts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AccountClaim'
CREATE INDEX [IX_FK_AccountClaim]
ON [juts].[Claims]
    ([AccountId]);
GO

-- Creating foreign key on [ClaimId] in table 'Fulfillments'
ALTER TABLE [juts].[Fulfillments]
ADD CONSTRAINT [FK_ClaimFulfillment]
    FOREIGN KEY ([ClaimId])
    REFERENCES [juts].[Claims]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ClaimFulfillment'
CREATE INDEX [IX_FK_ClaimFulfillment]
ON [juts].[Fulfillments]
    ([ClaimId]);
GO

-- Creating foreign key on [RequirementId] in table 'Fulfillments'
ALTER TABLE [juts].[Fulfillments]
ADD CONSTRAINT [FK_RequirementFulfillment]
    FOREIGN KEY ([RequirementId])
    REFERENCES [juts].[Requirements]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RequirementFulfillment'
CREATE INDEX [IX_FK_RequirementFulfillment]
ON [juts].[Fulfillments]
    ([RequirementId]);
GO

-- Creating foreign key on [aspnet_UsersAccount_aspnet_Users_Id] in table 'aspnet_Users'
ALTER TABLE [juts].[aspnet_Users]
ADD CONSTRAINT [FK_aspnet_UsersAccount]
    FOREIGN KEY ([aspnet_UsersAccount_aspnet_Users_Id])
    REFERENCES [juts].[Accounts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_aspnet_UsersAccount'
CREATE INDEX [IX_FK_aspnet_UsersAccount]
ON [juts].[aspnet_Users]
    ([aspnet_UsersAccount_aspnet_Users_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------