CREATE TABLE [dbo].[ItemCompra] (
    [IdItemCompra]   INT          IDENTITY (1, 1) NOT NULL,
    [Cantidad]       INT          NULL,
    [IdCompra]       INT          NULL,
    [NomCientifico]  VARCHAR (20) NULL,
    [PrecioUnitario] INT          NULL,
    CONSTRAINT [PK_IDITEMCOMPRA] PRIMARY KEY CLUSTERED ([IdItemCompra] ASC),
    CONSTRAINT [FK_IDCOMPRA] FOREIGN KEY ([IdCompra]) REFERENCES [dbo].[Compra] ([IdCompra]),
    CONSTRAINT [FK_NOMCIENTCOMPRA] FOREIGN KEY ([NomCientifico]) REFERENCES [dbo].[Planta] ([NomCientifico])
);

