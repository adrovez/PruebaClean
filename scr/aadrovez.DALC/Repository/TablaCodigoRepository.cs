using aadrovez.Contracts.DTO;
using aadrovez.DALC.Data;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace aadrovez.DALC.Repository
{
    public class TablaCodigoRepository : ITablaCodigoRepository
    {
        public async Task<List<TablaCodigoDto>> GetAllAsync(string filtro)
        {

            // Tu SP usa '' como "sin filtro"
            var filtroSeguro = filtro ?? string.Empty;

            var pFiltro = new SqlParameter("@Filtro", SqlDbType.VarChar, 50)
            {
                Value = filtroSeguro
            };

            using (var _context = new AplicacionDbContext())
            {
                return await _context.Database
               .SqlQuery<TablaCodigoDto>("EXEC dbo.SP_TablaCodigoDtoLeer @Filtro", pFiltro)
               .ToListAsync();
            }

        }

        public async Task<TablaCodigoDto> GetByIdAsync(int Id)
        {
            var pId = new SqlParameter("@Id", SqlDbType.Int)
            {
                Value = Id
            };
            using (var _context = new AplicacionDbContext())
            {
                return await _context.Database
                .SqlQuery<TablaCodigoDto>("EXEC dbo.SP_TablaCodigoDtoBuscarById @Id", pId)
                .SingleOrDefaultAsync();
            }
        }

        public async Task<int> AddAsync(TablaCodigoDto TablaCodigoDto)
        {
            var parametroId = new SqlParameter("@Id", System.Data.SqlDbType.Int);
            var parametroCodigo = new SqlParameter("@Codigo", TablaCodigoDto.Codigo);
            var parametroDescripcion = new SqlParameter("@Descripcion", TablaCodigoDto.Descripcion);

            parametroId.Direction = System.Data.ParameterDirection.Output;

            using (var _context = new AplicacionDbContext())
            {
                await _context.Database.ExecuteSqlCommandAsync(
                $@"EXEC dbo.SP_TablaCodigoDtoInsertar 
                    @Codigo ={parametroCodigo},
                    @Descripcion = {parametroDescripcion}, 
                    @Id = {parametroId} OUTPUT");

                var id = (int)parametroId.Value;
                return id;
            }
        }

        public async Task<bool> UpdateAsync(TablaCodigoDto TablaCodigoDto)
        {
            var parametroId = new SqlParameter("@Id", System.Data.SqlDbType.Int);
            var parametroCodigo = new SqlParameter("@Codigo", TablaCodigoDto.Codigo);
            var parametroDescripcion = new SqlParameter("@Descripcion", TablaCodigoDto.Descripcion);
            var parametroExisto = new SqlParameter("@Id", System.Data.SqlDbType.Bit);

            parametroExisto.Direction = System.Data.ParameterDirection.Output;

            using (var _context = new AplicacionDbContext())
            {
                await _context.Database.ExecuteSqlCommandAsync(
                $@"EXEC dbo.SP_TablaCodigoDtoActualizar 
                    @Id = {parametroId},
                    @Codigo ={parametroCodigo},
                    @Descripcion = {parametroDescripcion}, 
                    @Exito = {parametroExisto} OUTPUT");

                return (bool)parametroId.Value;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var parametroId = new SqlParameter("@Id", System.Data.SqlDbType.Int);
            var parametroExisto = new SqlParameter("@Id", System.Data.SqlDbType.Bit);
            parametroExisto.Direction = System.Data.ParameterDirection.Output;

            using (var _context = new AplicacionDbContext())
            {
                await _context.Database.ExecuteSqlCommandAsync(
                $@"EXEC dbo.SP_TablaCodigoDtoEliminar 
                    @Id = {parametroId},                   
                    @Exito = {parametroExisto} OUTPUT");

                return (bool)parametroId.Value;
            }
        }
    }
}
