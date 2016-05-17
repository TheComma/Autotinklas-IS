CREATE TABLE [dbo].[Gedimas] (
    [id]           INT            IDENTITY (1, 1) NOT NULL,
    [pavadinimas]  NVARCHAR (MAX) NULL,
    [fk_uzsakymas] INT            NULL,
    CONSTRAINT [PK_Gedimas] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_Gedimas_Uzsakymas] FOREIGN KEY ([fk_uzsakymas]) REFERENCES [dbo].[Uzsakymas] ([uzsakymo_nr])
);

