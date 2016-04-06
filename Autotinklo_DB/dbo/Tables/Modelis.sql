CREATE TABLE [dbo].[Modelis] (
    [id]          INT           IDENTITY (1, 1) NOT NULL,
    [pavadinimas] NVARCHAR (50) NULL,
    [fk_marke]    INT           NULL,
    CONSTRAINT [PK_Modelis] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_Modelis_Marke] FOREIGN KEY ([fk_marke]) REFERENCES [dbo].[Marke] ([id])
);

