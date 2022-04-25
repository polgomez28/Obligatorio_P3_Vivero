CREATE TABLE [dbo].[Importacion] (
    [IdImportacion] INT IDENTITY (1, 1) NOT NULL,
    [IdPlanta]      INT NULL,
    [TasaImpuesto]  INT NULL,
    CONSTRAINT [PK_IDIMPORTACION] PRIMARY KEY CLUSTERED ([IdImportacion] ASC),
    CONSTRAINT [FK_IDPLANTAIMPORTACION] FOREIGN KEY ([IdPlanta]) REFERENCES [dbo].[Planta] ([IdPlanta])
);

