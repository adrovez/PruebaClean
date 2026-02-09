USE dbHonda
GO

CREATE TABLE dbo.TablaCodigo
(
	Id				int IDENTITY(1,1) NOT NULL,
	Codigo			varchar(50) NOT NULL,
	Descripcion		varchar(50) NOT NULL,
	CONSTRAINT PK_TablaCodigo PRIMARY KEY CLUSTERED (Id)
)

GO


