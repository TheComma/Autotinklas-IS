CREATE TABLE [dbo].[Autodalies_uzsakymas] (
    [id]           INT IDENTITY (1, 1) NOT NULL,
    [kiekis]       INT NULL,
    [fk_autodalis] INT NULL,
    [fk_uzsakymas] INT NULL,
    CONSTRAINT [PK_Autodalies_uzsakymas] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_Autodalies_uzsakymas_Autodalis] FOREIGN KEY ([fk_autodalis]) REFERENCES [dbo].[Autodalis] ([id]),
    CONSTRAINT [FK_Autodalies_uzsakymas_Uzsakymas] FOREIGN KEY ([fk_uzsakymas]) REFERENCES [dbo].[Uzsakymas] ([uzsakymo_nr])
);

