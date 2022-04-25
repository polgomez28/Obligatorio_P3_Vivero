CREATE TABLE [dbo].[Planta] (
    [IdPlanta]        INT           IDENTITY (1, 1) NOT NULL,
    [NomCientifico]   VARCHAR (20)  NOT NULL,
    [Descripcion]     VARCHAR (500) NULL,
    [IdTipoPlanta]    INT           NULL,
    [IdFichaCuidados] INT           NULL,
    [Ambiente]        VARCHAR (30)  NULL,
    [Altura]          INT           NULL,
    [NombresVulgares] VARCHAR (500) NULL,
    CONSTRAINT [PK_PLANTA] PRIMARY KEY CLUSTERED ([IdPlanta] ASC),
    CONSTRAINT [FK_IDFICHACUIDADOS] FOREIGN KEY ([IdFichaCuidados]) REFERENCES [dbo].[FichaCuidados] ([IdFichaCuidados]),
    CONSTRAINT [FK_IDTIPO] FOREIGN KEY ([IdTipoPlanta]) REFERENCES [dbo].[TipoPlanta] ([IdTipoPlanta]),
    UNIQUE NONCLUSTERED ([NomCientifico] ASC)
);



