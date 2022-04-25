CREATE TABLE [dbo].[TipoIluminacion] (
    [IdTipoIluminacion] INT          IDENTITY (1, 1) NOT NULL,
    [Tipo]              VARCHAR (30) NULL,
    CONSTRAINT [PK_TIPOILUID] PRIMARY KEY CLUSTERED ([IdTipoIluminacion] ASC)
);

