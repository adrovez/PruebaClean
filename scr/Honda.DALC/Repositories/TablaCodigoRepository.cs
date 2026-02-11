using Honda.DALC.Data;
using Honda.Entidades.DTOs;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Honda.DALC.Repositories
{
    public class TablaCodigoRepository : ITablaCodigoRepository
    {
        public async Task<TablaCodigoDto> getBuscarPorId(int Id)
        {
            var pId = new SqlParameter("@Id", System.Data.SqlDbType.Int) { Value = Id };

            using (var _contect = new AplicacionDataContext())
            {
                return await _contect.Database
                            .SqlQuery<TablaCodigoDto>($"EXEC SP_TablaCodigoBuscarById @Id", pId)
                            .FirstOrDefaultAsync();
            }
        }

        public async Task<List<TablaCodigoDto>> getListar(string filtro)
        {
            var pFiltro = new SqlParameter("@Filtro", System.Data.SqlDbType.VarChar, 50) { Value = filtro };

            using (var _contect = new AplicacionDataContext())
            {
                return await _contect.Database
                            .SqlQuery<TablaCodigoDto>($"EXEC SP_TablaCodigoLeer @Filtro", pFiltro)
                            .ToListAsync();
            }
        }

        public async Task<bool> setActualizar(TablaCodigoDto item)
        {
            var pId = new SqlParameter("@Id", System.Data.SqlDbType.Int)
            { Value = item.Id };
            var pCodigo = new SqlParameter("@Codigo", System.Data.SqlDbType.VarChar, 50)
            { Value = item.Codigo };
            var pDescripcion = new SqlParameter("@Descripcion", System.Data.SqlDbType.VarChar, 50)
            { Value = item.Descripcion };

            var pRespuesta = new SqlParameter("@Respuesta", System.Data.SqlDbType.Bit);
            pRespuesta.Direction = System.Data.ParameterDirection.Output;

            using (var _contect = new AplicacionDataContext())
            {
                await _contect.Database
                           .ExecuteSqlCommandAsync(
                             $"EXEC SP_TablaCodigoActualizar @Id, @Codigo, @Descripcion, @Respuesta OUTPUT"
                           , pId
                           , pCodigo
                           , pDescripcion
                           , pRespuesta);

                return (bool)pRespuesta.Value;
            }
        }

        public async Task<int> setAgregar(TablaCodigoDto item)
        {
            var pCodigo = new SqlParameter("@Codigo", System.Data.SqlDbType.VarChar, 50)
            { Value = item.Codigo };
            var pDescripcion = new SqlParameter("@Descripcion", System.Data.SqlDbType.VarChar, 50)
            { Value = item.Descripcion };

            var pRespuesta = new SqlParameter("@Respuesta", System.Data.SqlDbType.Int);
            pRespuesta.Direction = System.Data.ParameterDirection.Output;

            using (var _contect = new AplicacionDataContext())
            {
                await _contect.Database
                           .ExecuteSqlCommandAsync(
                             $"EXEC SP_TablaCodigoInsertar @Codigo, @Descripcion, @Respuesta OUTPUT"
                           , pCodigo
                           , pDescripcion
                           , pRespuesta);

                return (int)pRespuesta.Value;
            }
        }

        public async Task<bool> setEliminar(int Id)
        {
            var pId = new SqlParameter("@Codigo", System.Data.SqlDbType.Int)
            { Value = Id };

            var pRespuesta = new SqlParameter("@Respuesta", System.Data.SqlDbType.Int);
            pRespuesta.Direction = System.Data.ParameterDirection.Output;

            using (var _contect = new AplicacionDataContext())
            {
                await _contect.Database
                           .ExecuteSqlCommandAsync(
                             $"EXEC SP_TablaCodigoEliminar @Id, @Respuesta OUTPUT"
                           , pId
                           , pRespuesta);

                return (bool)pRespuesta.Value;
            }
        }
    }
}
