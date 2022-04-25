CREATE TABLE [dbo].[ParamSistema] (
    [IdParam]     INT           IDENTITY (1, 1) NOT NULL,
    [Nombre]      VARCHAR (30)  NULL,
    [Descripcion] VARCHAR (100) NULL,
    [ValorMin]    INT           NULL,
    [ValorMax]    INT           NULL
);

