CREATE TABLE [dbo].[Padalinys] (
    [id]      INT            IDENTITY (1, 1) NOT NULL,
    [adresas] NVARCHAR (MAX) NULL,
    [miestas] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Padalinys1] PRIMARY KEY CLUSTERED ([id] ASC)
);

