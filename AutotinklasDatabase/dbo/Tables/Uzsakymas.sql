CREATE TABLE [dbo].[Uzsakymas] (
    [uzsakymo_nr]               INT           IDENTITY (1, 1) NOT NULL,
    [data]                      DATE          NULL,
    [kliento_vardas]            NVARCHAR (50) NULL,
    [kliento_pavarde]           NVARCHAR (50) NULL,
    [kliento_telefonas]         NVARCHAR (50) NULL,
    [fk_meistras]               INT           NULL,
    [fk_automobilis]            NVARCHAR (6)  NULL,
    [fk_pakaitinis_automobilis] NVARCHAR (6)  NULL,
    CONSTRAINT [PK_Uzsakymas] PRIMARY KEY CLUSTERED ([uzsakymo_nr] ASC),
    CONSTRAINT [FK_Uzsakymas_Automobilis] FOREIGN KEY ([fk_automobilis]) REFERENCES [dbo].[Automobilis] ([valstybinis_numeris]),
    CONSTRAINT [FK_Uzsakymas_Darbuotojas] FOREIGN KEY ([fk_meistras]) REFERENCES [dbo].[Darbuotojas] ([id]),
    CONSTRAINT [FK_Uzsakymas_Pakaitinis_automobilis] FOREIGN KEY ([fk_pakaitinis_automobilis]) REFERENCES [dbo].[Pakaitinis_automobilis] ([valstybinis_numeris])
);

