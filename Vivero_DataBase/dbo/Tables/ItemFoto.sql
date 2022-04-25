CREATE TABLE [dbo].[ItemFoto] (
    [IdItemFoto] INT          IDENTITY (1, 1) NOT NULL,
    [IdFoto]     INT          NULL,
    [IdPlanta]   INT          NULL,
    [ItemNom]    VARCHAR (30) NULL,
    CONSTRAINT [PK_IDITEMFOTO] PRIMARY KEY CLUSTERED ([IdItemFoto] ASC),
    CONSTRAINT [FK_ITEMFOTOIDFOTO] FOREIGN KEY ([IdFoto]) REFERENCES [dbo].[Foto] ([IdFoto]),
    CONSTRAINT [FK_ITEMFOTOIDPLANTA] FOREIGN KEY ([IdPlanta]) REFERENCES [dbo].[Planta] ([IdPlanta])
);

