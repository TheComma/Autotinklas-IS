CREATE TABLE [dbo].[Parduotuve] (
    [id]          INT           IDENTITY (1, 1) NOT NULL,
    [pavadinimas] NVARCHAR (50) NULL,
    [miestas]     NVARCHAR (50) NULL,
    [adresas]     NVARCHAR (50) NULL,
    CONSTRAINT [PK_Parduotuve] PRIMARY KEY CLUSTERED ([id] ASC)
);

