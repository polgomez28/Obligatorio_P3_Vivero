CREATE TABLE [dbo].[TipoPlanta] (
    [IdTipoPlanta] INT           IDENTITY (1, 1) NOT NULL,
    [TipoNombre]   VARCHAR (30)  NOT NULL,
    [TipoDesc]     VARCHAR (200) NULL,
    CONSTRAINT [PK_IDTIPOPLANTA] PRIMARY KEY CLUSTERED ([IdTipoPlanta] ASC),
    UNIQUE NONCLUSTERED ([TipoNombre] ASC)
);

