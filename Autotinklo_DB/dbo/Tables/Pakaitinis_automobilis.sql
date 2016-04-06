CREATE TABLE [dbo].[Pakaitinis_automobilis] (
    [valstybinis_numeris] NVARCHAR (6) NOT NULL,
    [metai]               NVARCHAR (4) NULL,
    [degalu_kiekis]       INT          NULL,
    [fk_modelis]          INT          NULL,
    CONSTRAINT [PK_Pakaitinis_automobilis] PRIMARY KEY CLUSTERED ([valstybinis_numeris] ASC),
    CONSTRAINT [FK_Pakaitinis_automobilis_Modelis] FOREIGN KEY ([fk_modelis]) REFERENCES [dbo].[Modelis] ([id])
);

