
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/28/2019 16:36:40
-- Generated from EDMX file: C:\Users\Tiago\Desktop\cópia IMPACTA - ACESSO A DADOS\.net AD Projetos em Aula\Aula 4 ENTITY_modelfirts_databasefirts\Cap04Lab01\Cap04Lab01\Models\PubsContext.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [pubsmd];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__titles__pub_id__1A14E395]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Livros] DROP CONSTRAINT [FK__titles__pub_id__1A14E395];
GO
IF OBJECT_ID(N'[dbo].[FK__titleauth__au_id__1DE57479]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LivrosAutores] DROP CONSTRAINT [FK__titleauth__au_id__1DE57479];
GO
IF OBJECT_ID(N'[dbo].[FK__titleauth__title__1ED998B2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LivrosAutores] DROP CONSTRAINT [FK__titleauth__title__1ED998B2];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Autores]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Autores];
GO
IF OBJECT_ID(N'[dbo].[Editoras]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Editoras];
GO
IF OBJECT_ID(N'[dbo].[Livros]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Livros];
GO
IF OBJECT_ID(N'[dbo].[LivrosAutores]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LivrosAutores];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Autores'
CREATE TABLE [dbo].[Autores] (
    [AutorId] varchar(11)  NOT NULL,
    [Nome] varchar(40)  NOT NULL,
    [SobreNome] varchar(20)  NOT NULL,
    [phone] char(12)  NOT NULL,
    [Endereco] varchar(40)  NULL,
    [Cidade] varchar(20)  NULL,
    [Estado] char(2)  NULL,
    [CEP] char(5)  NULL,
    [contract] bit  NOT NULL
);
GO

-- Creating table 'Editoras'
CREATE TABLE [dbo].[Editoras] (
    [EditoraId] char(4)  NOT NULL,
    [EditoraNome] varchar(40)  NULL,
    [Cidade] varchar(20)  NULL,
    [Estado] char(2)  NULL,
    [Pais] varchar(30)  NULL
);
GO

-- Creating table 'Livros'
CREATE TABLE [dbo].[Livros] (
    [LivroId] varchar(6)  NOT NULL,
    [Titulo] varchar(80)  NOT NULL,
    [Tipo] char(12)  NOT NULL,
    [EditoraId] char(4)  NULL,
    [Preco] decimal(19,4)  NULL,
    [advance] decimal(19,4)  NULL,
    [royalty] int  NULL,
    [ytd_sales] int  NULL,
    [Observacoes] varchar(200)  NULL,
    [DataPublicacao] datetime  NOT NULL
);
GO

-- Creating table 'LivrosAutores'
CREATE TABLE [dbo].[LivrosAutores] (
    [AutorId] varchar(11)  NOT NULL,
    [LivroId] varchar(6)  NOT NULL,
    [au_ord] tinyint  NULL,
    [royaltyper] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [AutorId] in table 'Autores'
ALTER TABLE [dbo].[Autores]
ADD CONSTRAINT [PK_Autores]
    PRIMARY KEY CLUSTERED ([AutorId] ASC);
GO

-- Creating primary key on [EditoraId] in table 'Editoras'
ALTER TABLE [dbo].[Editoras]
ADD CONSTRAINT [PK_Editoras]
    PRIMARY KEY CLUSTERED ([EditoraId] ASC);
GO

-- Creating primary key on [LivroId] in table 'Livros'
ALTER TABLE [dbo].[Livros]
ADD CONSTRAINT [PK_Livros]
    PRIMARY KEY CLUSTERED ([LivroId] ASC);
GO

-- Creating primary key on [AutorId], [LivroId] in table 'LivrosAutores'
ALTER TABLE [dbo].[LivrosAutores]
ADD CONSTRAINT [PK_LivrosAutores]
    PRIMARY KEY CLUSTERED ([AutorId], [LivroId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [EditoraId] in table 'Livros'
ALTER TABLE [dbo].[Livros]
ADD CONSTRAINT [FK__titles__pub_id__1A14E395]
    FOREIGN KEY ([EditoraId])
    REFERENCES [dbo].[Editoras]
        ([EditoraId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__titles__pub_id__1A14E395'
CREATE INDEX [IX_FK__titles__pub_id__1A14E395]
ON [dbo].[Livros]
    ([EditoraId]);
GO

-- Creating foreign key on [AutorId] in table 'LivrosAutores'
ALTER TABLE [dbo].[LivrosAutores]
ADD CONSTRAINT [FK__titleauth__au_id__1DE57479]
    FOREIGN KEY ([AutorId])
    REFERENCES [dbo].[Autores]
        ([AutorId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [LivroId] in table 'LivrosAutores'
ALTER TABLE [dbo].[LivrosAutores]
ADD CONSTRAINT [FK__titleauth__title__1ED998B2]
    FOREIGN KEY ([LivroId])
    REFERENCES [dbo].[Livros]
        ([LivroId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__titleauth__title__1ED998B2'
CREATE INDEX [IX_FK__titleauth__title__1ED998B2]
ON [dbo].[LivrosAutores]
    ([LivroId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------