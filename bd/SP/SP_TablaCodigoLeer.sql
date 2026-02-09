USE dbHonda
GO

CREATE PROCEDURE dbo.SP_TablaCodigoLeer
(
    @Filtro VARCHAR(50)
)
AS
BEGIN
    SELECT   Id
            ,Codigo
            ,Descripcion
    FROM dbo.TablaCodigo
    WHERE (Codigo = @Filtro  OR  @Filtro = '')

END
GO


