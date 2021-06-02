
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/02/2021 22:03:02
-- Generated from EDMX file: C:\Users\nikol\source\repos\DataBase\DataBase\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_WriterWrites]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WrittenPublications] DROP CONSTRAINT [FK_WriterWrites];
GO
IF OBJECT_ID(N'[dbo].[FK_Belongs]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WrittenPublications] DROP CONSTRAINT [FK_Belongs];
GO
IF OBJECT_ID(N'[dbo].[FK_FieldField]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Fields] DROP CONSTRAINT [FK_FieldField];
GO
IF OBJECT_ID(N'[dbo].[FK_BookPublisher]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Publications_Book] DROP CONSTRAINT [FK_BookPublisher];
GO
IF OBJECT_ID(N'[dbo].[FK_ArticleMagazine]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Publications_Article] DROP CONSTRAINT [FK_ArticleMagazine];
GO
IF OBJECT_ID(N'[dbo].[FK_WriterUnderContractMagazine]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Writers_WriterUnderContract] DROP CONSTRAINT [FK_WriterUnderContractMagazine];
GO
IF OBJECT_ID(N'[dbo].[FK_PublicationWrittenPublication]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WrittenPublications] DROP CONSTRAINT [FK_PublicationWrittenPublication];
GO
IF OBJECT_ID(N'[dbo].[FK_Book_inherits_Publication]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Publications_Book] DROP CONSTRAINT [FK_Book_inherits_Publication];
GO
IF OBJECT_ID(N'[dbo].[FK_Article_inherits_Publication]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Publications_Article] DROP CONSTRAINT [FK_Article_inherits_Publication];
GO
IF OBJECT_ID(N'[dbo].[FK_WriterUnderContract_inherits_Writer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Writers_WriterUnderContract] DROP CONSTRAINT [FK_WriterUnderContract_inherits_Writer];
GO
IF OBJECT_ID(N'[dbo].[FK_WriterFreelancer_inherits_Writer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Writers_WriterFreelancer] DROP CONSTRAINT [FK_WriterFreelancer_inherits_Writer];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Writers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Writers];
GO
IF OBJECT_ID(N'[dbo].[Publications]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Publications];
GO
IF OBJECT_ID(N'[dbo].[Fields]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Fields];
GO
IF OBJECT_ID(N'[dbo].[WrittenPublications]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WrittenPublications];
GO
IF OBJECT_ID(N'[dbo].[Publishers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Publishers];
GO
IF OBJECT_ID(N'[dbo].[Magazines]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Magazines];
GO
IF OBJECT_ID(N'[dbo].[Publications_Book]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Publications_Book];
GO
IF OBJECT_ID(N'[dbo].[Publications_Article]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Publications_Article];
GO
IF OBJECT_ID(N'[dbo].[Writers_WriterUnderContract]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Writers_WriterUnderContract];
GO
IF OBJECT_ID(N'[dbo].[Writers_WriterFreelancer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Writers_WriterFreelancer];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Writers'
CREATE TABLE [dbo].[Writers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [WriterType] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Publications'
CREATE TABLE [dbo].[Publications] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PubName] nvarchar(max)  NOT NULL,
    [PubType] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Fields'
CREATE TABLE [dbo].[Fields] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FieldName] nvarchar(max)  NOT NULL,
    [SuperFieldId] int  NULL
);
GO

-- Creating table 'WrittenPublications'
CREATE TABLE [dbo].[WrittenPublications] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [WriterId] int  NOT NULL,
    [PublicationId] int  NOT NULL,
    [Field_Id] int  NOT NULL
);
GO

-- Creating table 'Publishers'
CREATE TABLE [dbo].[Publishers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PublisherName] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Magazines'
CREATE TABLE [dbo].[Magazines] (
    [MagazineName] nvarchar(max)  NOT NULL,
    [NumMag] int  NOT NULL,
    [YearPublish] int  NOT NULL
);
GO

-- Creating table 'Publications_Book'
CREATE TABLE [dbo].[Publications_Book] (
    [NumOfCopies] int  NOT NULL,
    [Id] int  NOT NULL,
    [Publisher_Id] int  NOT NULL
);
GO

-- Creating table 'Publications_Article'
CREATE TABLE [dbo].[Publications_Article] (
    [NumLetters] int  NOT NULL,
    [Id] int  NOT NULL,
    [Magazine_YearPublish] int  NOT NULL,
    [Magazine_NumMag] int  NOT NULL
);
GO

-- Creating table 'Writers_WriterUnderContract'
CREATE TABLE [dbo].[Writers_WriterUnderContract] (
    [Salary] int  NOT NULL,
    [NumWorkHours] int  NOT NULL,
    [Id] int  NOT NULL,
    [Magazine_YearPublish] int  NOT NULL,
    [Magazine_NumMag] int  NOT NULL
);
GO

-- Creating table 'Writers_WriterFreelancer'
CREATE TABLE [dbo].[Writers_WriterFreelancer] (
    [Description] nvarchar(max)  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Writers'
ALTER TABLE [dbo].[Writers]
ADD CONSTRAINT [PK_Writers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Publications'
ALTER TABLE [dbo].[Publications]
ADD CONSTRAINT [PK_Publications]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Fields'
ALTER TABLE [dbo].[Fields]
ADD CONSTRAINT [PK_Fields]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'WrittenPublications'
ALTER TABLE [dbo].[WrittenPublications]
ADD CONSTRAINT [PK_WrittenPublications]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Publishers'
ALTER TABLE [dbo].[Publishers]
ADD CONSTRAINT [PK_Publishers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [YearPublish], [NumMag] in table 'Magazines'
ALTER TABLE [dbo].[Magazines]
ADD CONSTRAINT [PK_Magazines]
    PRIMARY KEY CLUSTERED ([YearPublish], [NumMag] ASC);
GO

-- Creating primary key on [Id] in table 'Publications_Book'
ALTER TABLE [dbo].[Publications_Book]
ADD CONSTRAINT [PK_Publications_Book]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Publications_Article'
ALTER TABLE [dbo].[Publications_Article]
ADD CONSTRAINT [PK_Publications_Article]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Writers_WriterUnderContract'
ALTER TABLE [dbo].[Writers_WriterUnderContract]
ADD CONSTRAINT [PK_Writers_WriterUnderContract]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Writers_WriterFreelancer'
ALTER TABLE [dbo].[Writers_WriterFreelancer]
ADD CONSTRAINT [PK_Writers_WriterFreelancer]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [WriterId] in table 'WrittenPublications'
ALTER TABLE [dbo].[WrittenPublications]
ADD CONSTRAINT [FK_WriterWrites]
    FOREIGN KEY ([WriterId])
    REFERENCES [dbo].[Writers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WriterWrites'
CREATE INDEX [IX_FK_WriterWrites]
ON [dbo].[WrittenPublications]
    ([WriterId]);
GO

-- Creating foreign key on [Field_Id] in table 'WrittenPublications'
ALTER TABLE [dbo].[WrittenPublications]
ADD CONSTRAINT [FK_Belongs]
    FOREIGN KEY ([Field_Id])
    REFERENCES [dbo].[Fields]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Belongs'
CREATE INDEX [IX_FK_Belongs]
ON [dbo].[WrittenPublications]
    ([Field_Id]);
GO

-- Creating foreign key on [SuperFieldId] in table 'Fields'
ALTER TABLE [dbo].[Fields]
ADD CONSTRAINT [FK_FieldField]
    FOREIGN KEY ([SuperFieldId])
    REFERENCES [dbo].[Fields]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FieldField'
CREATE INDEX [IX_FK_FieldField]
ON [dbo].[Fields]
    ([SuperFieldId]);
GO

-- Creating foreign key on [Publisher_Id] in table 'Publications_Book'
ALTER TABLE [dbo].[Publications_Book]
ADD CONSTRAINT [FK_BookPublisher]
    FOREIGN KEY ([Publisher_Id])
    REFERENCES [dbo].[Publishers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BookPublisher'
CREATE INDEX [IX_FK_BookPublisher]
ON [dbo].[Publications_Book]
    ([Publisher_Id]);
GO

-- Creating foreign key on [Magazine_YearPublish], [Magazine_NumMag] in table 'Publications_Article'
ALTER TABLE [dbo].[Publications_Article]
ADD CONSTRAINT [FK_ArticleMagazine]
    FOREIGN KEY ([Magazine_YearPublish], [Magazine_NumMag])
    REFERENCES [dbo].[Magazines]
        ([YearPublish], [NumMag])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ArticleMagazine'
CREATE INDEX [IX_FK_ArticleMagazine]
ON [dbo].[Publications_Article]
    ([Magazine_YearPublish], [Magazine_NumMag]);
GO

-- Creating foreign key on [Magazine_YearPublish], [Magazine_NumMag] in table 'Writers_WriterUnderContract'
ALTER TABLE [dbo].[Writers_WriterUnderContract]
ADD CONSTRAINT [FK_WriterUnderContractMagazine]
    FOREIGN KEY ([Magazine_YearPublish], [Magazine_NumMag])
    REFERENCES [dbo].[Magazines]
        ([YearPublish], [NumMag])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WriterUnderContractMagazine'
CREATE INDEX [IX_FK_WriterUnderContractMagazine]
ON [dbo].[Writers_WriterUnderContract]
    ([Magazine_YearPublish], [Magazine_NumMag]);
GO

-- Creating foreign key on [PublicationId] in table 'WrittenPublications'
ALTER TABLE [dbo].[WrittenPublications]
ADD CONSTRAINT [FK_PublicationWrittenPublication]
    FOREIGN KEY ([PublicationId])
    REFERENCES [dbo].[Publications]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PublicationWrittenPublication'
CREATE INDEX [IX_FK_PublicationWrittenPublication]
ON [dbo].[WrittenPublications]
    ([PublicationId]);
GO

-- Creating foreign key on [Id] in table 'Publications_Book'
ALTER TABLE [dbo].[Publications_Book]
ADD CONSTRAINT [FK_Book_inherits_Publication]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Publications]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Publications_Article'
ALTER TABLE [dbo].[Publications_Article]
ADD CONSTRAINT [FK_Article_inherits_Publication]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Publications]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Writers_WriterUnderContract'
ALTER TABLE [dbo].[Writers_WriterUnderContract]
ADD CONSTRAINT [FK_WriterUnderContract_inherits_Writer]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Writers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Writers_WriterFreelancer'
ALTER TABLE [dbo].[Writers_WriterFreelancer]
ADD CONSTRAINT [FK_WriterFreelancer_inherits_Writer]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Writers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------