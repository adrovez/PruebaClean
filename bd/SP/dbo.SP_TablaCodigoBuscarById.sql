USE dbHonda
GO

CREATE PROCEDURE dbo.SP_TablaCodigoBuscarById
(
    @Id INT
)
AS
BEGIN
    SELECT   Id
            ,Codigo
            ,Descripcion
    FROM dbo.TablaCodigo
    WHERE id= @Id

END
GO