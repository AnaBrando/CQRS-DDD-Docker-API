CREATE DATABASE waproject;
GO
USE waproject;
GO
IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO
BEGIN TRANSACTION;
CREATE TABLE [dbo].[AspNetRoles] (
[Id]   NVARCHAR (128) NOT NULL,
[Name] NVARCHAR (256) NOT NULL,
CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex]
ON [dbo].[AspNetRoles]([Name] ASC);

CREATE TABLE [dbo].[AspNetUsers] (
[Id]                   NVARCHAR (128) NOT NULL,
[Discriminator]         NVARCHAR (MAX) NULL,
[NormalizedUserName] NVARCHAR (256) NULL,
[NormalizedEmail] NVARCHAR (256) NULL,
[Email]                NVARCHAR (256) NULL,
[EmailConfirmed]       BIT            NOT NULL,
[PasswordHash]         NVARCHAR (MAX) NULL,
[SecurityStamp]        NVARCHAR (MAX) NULL,
[ConcurrencyStamp]  NVARCHAR (MAX) NULL,
[PhoneNumber]          NVARCHAR (MAX) NULL,
[PhoneNumberConfirmed] BIT            NOT NULL,
[TwoFactorEnabled]     BIT            NOT NULL,
[LockoutEnd]    DATETIME       NULL,
[LockoutEnabled]       BIT            NOT NULL,
[AccessFailedCount]    INT            NOT NULL,
[UserName]             NVARCHAR (256) NOT NULL,
CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex]
ON [dbo].[AspNetUsers]([UserName] ASC);


CREATE TABLE [dbo].[AspNetUserRoles] (
[UserId] NVARCHAR (128) NOT NULL,
[RoleId] NVARCHAR (128) NOT NULL,
CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED ([UserId] ASC, [RoleId] ASC),
CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AspNetRoles] ([Id]) ON DELETE CASCADE,
CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
 );


GO
CREATE NONCLUSTERED INDEX [IX_UserId]
ON [dbo].[AspNetUserRoles]([UserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_RoleId]
ON [dbo].[AspNetUserRoles]([RoleId] ASC);



CREATE TABLE [dbo].[AspNetUserLogins] (
[LoginProvider] NVARCHAR (128) NOT NULL,
[ProviderKey]   NVARCHAR (128) NOT NULL,
[UserId]        NVARCHAR (128) NOT NULL,
CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED ([LoginProvider] ASC, [ProviderKey] ASC, [UserId] ASC),
CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_UserId]
ON [dbo].[AspNetUserLogins]([UserId] ASC);



CREATE TABLE [dbo].[AspNetUserClaims] (
[Id]         INT            IDENTITY (1, 1) NOT NULL,
[UserId]     NVARCHAR (128) NOT NULL,
[ClaimType]  NVARCHAR (MAX) NULL,
[ClaimValue] NVARCHAR (MAX) NULL,
CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED ([Id] ASC),
CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_UserId]
ON [dbo].[AspNetUserClaims]([UserId] ASC);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210418164206_user', N'5.0.5');
GO

COMMIT;
GO
IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Equipes] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] nvarchar(max) NULL,
    [Descricao] nvarchar(max) NULL,
    [Placa] nvarchar(max) NULL,
    [CascadeMode] int NOT NULL,
    [DataCadastro] datetime2 NOT NULL,
    [DataAtualizacao] datetime2 NULL,
    [Ativo] bit NOT NULL,
    CONSTRAINT [PK_Equipes] PRIMARY KEY ([Id])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nome', N'Descricao', N'Placa', N'Ativo', N'DataCadastro', N'CascadeMode') AND [object_id] = OBJECT_ID(N'[Equipes]'))
    SET IDENTITY_INSERT [Equipes] ON;
INSERT INTO [Equipes] ([Id], [Nome], [Descricao], [Placa], [Ativo], [DataCadastro], [CascadeMode])
VALUES ('efae10aa-426e-4fcc-9e4d-e9cffc68ae2b', N'Equipe1', N'Primeira Equipe', N'ABDC', CAST(1 AS bit), '2021-05-16T10:19:28.0975959-04:00', 1);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nome', N'Descricao', N'Placa', N'Ativo', N'DataCadastro', N'CascadeMode') AND [object_id] = OBJECT_ID(N'[Equipes]'))
    SET IDENTITY_INSERT [Equipes] OFF;
GO

CREATE TABLE [Pedidos] (
    [Id] uniqueidentifier NOT NULL,
    [Endereco] nvarchar(max) NULL,
    [DataEntrega] datetime2 NOT NULL,
    [CascadeMode] int NOT NULL,
    [DataCadastro] datetime2 NOT NULL,
    [DataAtualizacao] datetime2 NULL,
    [Ativo] bit NOT NULL,
    CONSTRAINT [PK_Pedidos] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Encomendas] (
    [Id] uniqueidentifier NOT NULL,
    [EquipeId] uniqueidentifier NOT NULL,
    [PedidoId] uniqueidentifier NULL,
    [CascadeMode] int NOT NULL,
    [DataCadastro] datetime2 NOT NULL,
    [DataAtualizacao] datetime2 NULL,
    [Ativo] bit NOT NULL,
    CONSTRAINT [PK_Encomendas] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Encomendas_Pedidos_PedidoId] FOREIGN KEY ([PedidoId]) REFERENCES [Pedidos] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Produtos] (
    [Id] uniqueidentifier NOT NULL,
    [Descricao] nvarchar(max) NULL,
    [Valor] real NOT NULL,
    [PedidoId] uniqueidentifier NULL,
    [CascadeMode] int NOT NULL,
    [DataCadastro] datetime2 NOT NULL,
    [DataAtualizacao] datetime2 NULL,
    [Ativo] bit NOT NULL,
    CONSTRAINT [PK_Produtos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Produtos_Pedidos_PedidoId] FOREIGN KEY ([PedidoId]) REFERENCES [Pedidos] ([Id]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_Encomendas_PedidoId] ON [Encomendas] ([PedidoId]);
GO

CREATE INDEX [IX_Produtos_PedidoId] ON [Produtos] ([PedidoId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210418164112_initial', N'5.0.5');
GO

COMMIT;
GO

