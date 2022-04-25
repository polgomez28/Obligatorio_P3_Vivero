CREATE TABLE [dbo].[Foto] (
    [IdFoto]        INT             IDENTITY (1, 1) NOT NULL,
    [Nombre]        VARCHAR (30)    NULL,
    [FotoByteArray] VARBINARY (MAX) NULL,
    [EsPrincipal]   BIT             NULL,
    CONSTRAINT [PK_IDFOTO] PRIMARY KEY CLUSTERED ([IdFoto] ASC)
);



