CREATE TABLE [dbo].[Marke] (
    [id]          INT           IDENTITY (1, 1) NOT NULL,
    [pavadinimas] NVARCHAR (50) NULL,
    CONSTRAINT [PK_Marke] PRIMARY KEY CLUSTERED ([id] ASC)
);

