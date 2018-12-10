IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180910153619_Initial')
BEGIN
    CREATE TABLE [Aktualnosci] (
        [ID] bigint NOT NULL IDENTITY,
        [Zdjecie] nvarchar(max) NOT NULL,
        [Tytul] nvarchar(40) NOT NULL,
        [Tresc] nvarchar(max) NOT NULL,
        [Dzien] datetime2 NOT NULL,
        CONSTRAINT [PK_Aktualnosci] PRIMARY KEY ([ID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180910153619_Initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180910153619_Initial', N'2.1.2-rtm-30932');
END;

GO

