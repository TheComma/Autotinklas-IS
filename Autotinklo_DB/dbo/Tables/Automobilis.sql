CREATE TABLE [dbo].[Automobilis] (
    [valstybinis_numeris] NVARCHAR (6)  NOT NULL,
    [kebulo_tipas]        NVARCHAR (50) NULL,
    [kebulo_numeris]      NVARCHAR (50) NULL,
    [metai]               NVARCHAR (4)  NULL,
    [fk_modelis]          INT           NULL,
    CONSTRAINT [PK_Automobilis] PRIMARY KEY CLUSTERED ([valstybinis_numeris] ASC)
);

