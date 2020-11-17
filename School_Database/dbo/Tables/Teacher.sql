CREATE TABLE [dbo].[Teacher] (
    [Id]      INT          IDENTITY (1, 1) NOT NULL,
    [StaffId] INT          NOT NULL,
    [Subject] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([StaffId]) REFERENCES [dbo].[Staff] ([Id])
);

