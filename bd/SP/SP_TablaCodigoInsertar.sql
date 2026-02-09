USE dbHonda
GO

CREATE PROCEDURE dbo.SP_TablaCodigoInsertar
(
     @Codigo        VARCHAR(50)
    ,@Descripcion   VARCHAR(50)
    ,@Id            INT     OUTPUT
)
AS
BEGIN

        INSERT INTO dbo.TablaCodigo
           (Codigo
           ,Descripcion)
        VALUES
           (@Codigo
           ,@Descripcion)

        SET @Id = SCOPE_IDENTITY()    
  

END
GO


