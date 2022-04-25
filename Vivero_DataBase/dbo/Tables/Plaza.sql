CREATE TABLE [dbo].[Plaza] (
    [IdPlaza]    INT IDENTITY (1, 1) NOT NULL,
    [CostoFlete] INT NULL,
    [IdPlanta]   INT NULL,
    [TasaIVA]    INT NULL,
    CONSTRAINT [PK_IDPLAZA] PRIMARY KEY CLUSTERED ([IdPlaza] ASC),
    CONSTRAINT [FK_IDPLANTAPLAZA] FOREIGN KEY ([IdPlanta]) REFERENCES [dbo].[Planta] ([IdPlanta])
);

