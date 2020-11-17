CREATE TABLE [dbo].[Staff] (
    [Id]      INT          IDENTITY (1, 1) NOT NULL,
    [EmpCode] INT          NOT NULL,
    [Name]    VARCHAR (50) NOT NULL,
    [Email]   VARCHAR (50) NOT NULL,
    [Type]    INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

