CREATE TABLE [dbo].[NombresVulgares] (
    [IdNomVulg] INT          IDENTITY (1, 1) NOT NULL,
    [Nombre]    VARCHAR (30) NULL,
    CONSTRAINT [PK_NOMVULGID] PRIMARY KEY CLUSTERED ([IdNomVulg] ASC)
);

