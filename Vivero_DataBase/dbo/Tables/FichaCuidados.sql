CREATE TABLE [dbo].[FichaCuidados] (
    [IdFichaCuidados]   INT          IDENTITY (1, 1) NOT NULL,
    [Riego]             VARCHAR (30) NULL,
    [IdTipoIluminacion] INT          NULL,
    [Temperatura]       INT          NULL,
    CONSTRAINT [PK_IDFICHACUIDADOS] PRIMARY KEY CLUSTERED ([IdFichaCuidados] ASC),
    CONSTRAINT [FK_FICHACUIDADOSIDILUMINACION] FOREIGN KEY ([IdTipoIluminacion]) REFERENCES [dbo].[TipoIluminacion] ([IdTipoIluminacion])
);

