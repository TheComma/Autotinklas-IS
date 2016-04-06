CREATE TABLE [dbo].[Darbuotojas] (
    [id]           INT            IDENTITY (1, 1) NOT NULL,
    [pavarde]      NVARCHAR (MAX) NULL,
    [vardas]       NVARCHAR (MAX) NULL,
    [adresas]      NVARCHAR (MAX) NULL,
    [telefonas]    NVARCHAR (50)  NULL,
    [fk_Padalinys] INT            NULL,
    CONSTRAINT [PK_Darbuotojas] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_Darbuotojas_Padalinys] FOREIGN KEY ([fk_Padalinys]) REFERENCES [dbo].[Padalinys] ([id])
);



