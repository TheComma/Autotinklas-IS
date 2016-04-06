CREATE TABLE [dbo].[Login] (
    [id]       INT           NOT NULL,
    [username] NVARCHAR (50) NULL,
    [password] VARCHAR (50)  NULL,
    [role]     INT           NULL,
    CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED ([id] ASC)
);

