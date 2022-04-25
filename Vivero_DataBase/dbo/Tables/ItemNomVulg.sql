CREATE TABLE [dbo].[ItemNomVulg] (
    [IdItemNomVulg] INT IDENTITY (1, 1) NOT NULL,
    [IdNomVulg]     INT NULL,
    [IdPlanta]      INT NULL,
    CONSTRAINT [PK_ITEMNOMVULGID] PRIMARY KEY CLUSTERED ([IdItemNomVulg] ASC),
    CONSTRAINT [FK_ITEMNOMVULG_NOMVULGID] FOREIGN KEY ([IdNomVulg]) REFERENCES [dbo].[NombresVulgares] ([IdNomVulg]),
    CONSTRAINT [FK_ITEMNOMVULGIDPLANTA] FOREIGN KEY ([IdPlanta]) REFERENCES [dbo].[Planta] ([IdPlanta])
);

