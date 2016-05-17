CREATE TABLE [dbo].[Saskaita] (
    [saskaitos_numeris] NVARCHAR (50) NOT NULL,
    [data]              DATE          NULL,
    [suma]              FLOAT (53)    NULL,
    [fk_uzsakymas]      INT           NULL,
    CONSTRAINT [PK_Saskaita] PRIMARY KEY CLUSTERED ([saskaitos_numeris] ASC),
    CONSTRAINT [FK_Saskaita_Uzsakymas] FOREIGN KEY ([fk_uzsakymas]) REFERENCES [dbo].[Uzsakymas] ([uzsakymo_nr])
);

