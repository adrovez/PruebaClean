USE dbHonda
GO

ALTER PROCEDURE dbo.SP_TablaCodigoActualizar
(
     @Id            INT 
    ,@Codigo        VARCHAR(50)
    ,@Descripcion   VARCHAR(50)
    ,@Exito      BIT OUTPUT
)
AS
BEGIN

    IF EXISTS(SELECT 1 FROM TablaCodigo WHERE Id = @Id)
    BEGIN
        UPDATE dbo.TablaCodigo
        SET   Codigo = @Codigo
              ,Descripcion = @Descripcion
        WHERE Id = @Id

        SET @Exito = 0 --TRUE
    END
    ELSE
    BEGIN
        SET @Exito = 1 --FALSE
    END

END
GO


