USE dbHonda
GO

CREATE PROCEDURE dbo.SP_TablaCodigoEliminar
(
    @Id     INT
   ,@Exito  BIT
)
AS
BEGIN

    IF EXISTS(SELECT 1 FROM dbo.TablaCodigo WHERE Id= @Id)
    BEGIN
        DELETE FROM dbo.TablaCodigo
        WHERE Id = @Id;

        SET @Exito = 1 --TRUE;
    END
    ELSE
    BEGIN
        SET @Exito = 0 --TRUE;
    END
       
END
GO


