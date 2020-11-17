CREATE TYPE [dbo].[UT_Staff] AS TABLE (
    [EmpCode] INT          NOT NULL,
    [Name]    VARCHAR (50) NOT NULL,
    [Email]   VARCHAR (50) NOT NULL,
    [Type]    INT          NOT NULL,
    [Extra]   VARCHAR (50) NOT NULL);

