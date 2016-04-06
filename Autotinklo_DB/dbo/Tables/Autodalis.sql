CREATE TABLE [dbo].[Autodalis] (
    [id]            INT           IDENTITY (1, 1) NOT NULL,
    [pavadinimas]   NVARCHAR (50) NULL,
    [kaina]         FLOAT (53)    NULL,
    [gamintojas]    NVARCHAR (50) NULL,
    [fk_parduotuve] INT           NULL,
    CONSTRAINT [PK_Autodalis] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_Autodalis_Parduotuve] FOREIGN KEY ([fk_parduotuve]) REFERENCES [dbo].[Parduotuve] ([id])
);

