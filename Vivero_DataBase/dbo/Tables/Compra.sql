CREATE TABLE [dbo].[Compra] (
    [IdCompra]      INT          IDENTITY (1, 1) NOT NULL,
    [FechaCompra]   VARCHAR (1)  NULL,
    [IdPlanta]      INT          NULL,
    [NomCientifico] VARCHAR (20) NULL,
    [Total]         INT          NULL,
    CONSTRAINT [PK_IDCOMPRA] PRIMARY KEY CLUSTERED ([IdCompra] ASC),
    CONSTRAINT [FK_IDPLANTACOMPRA] FOREIGN KEY ([IdPlanta]) REFERENCES [dbo].[Planta] ([IdPlanta]),
    CONSTRAINT [FK_NOMBRECIENT] FOREIGN KEY ([NomCientifico]) REFERENCES [dbo].[Planta] ([NomCientifico])
);

