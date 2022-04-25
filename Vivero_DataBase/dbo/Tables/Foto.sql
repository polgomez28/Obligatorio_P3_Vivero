CREATE TABLE [dbo].[Foto] (
    [IdFoto]     INT          IDENTITY (1, 1) NOT NULL,
    [NombreFoto] VARCHAR (30) NULL,
    CONSTRAINT [PK_IDFOTO] PRIMARY KEY CLUSTERED ([IdFoto] ASC)
);

