using aadrovez.Aplicacion.IRepositories;
using aadrovez.Dominio.Entities;
using aadrovez.Infraestructura.Data;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace aadrovez.Infraestructura.Repositories
{
    public class TablaCodigoRepository : ITablaCodigoRepository
    {
        private readonly AppDbContext _context;
        public TablaCodigoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TablaCodigo>> GetAllAsync(string filtro)
        {
            // Tu SP usa '' como "sin filtro"
            var filtroSeguro = filtro ?? string.Empty;

            var pFiltro = new SqlParameter("@Filtro", SqlDbType.VarChar, 50)
            {
                Value = filtroSeguro
            };

            return await _context.Database
                .SqlQuery<TablaCodigo>("EXEC dbo.SP_TablaCodigoLeer @Filtro", pFiltro)
                .ToListAsync();
        }

        public async Task<TablaCodigo> GetByIdAsync(int Id)
        {
            var pId = new SqlParameter("@Id", SqlDbType.Int)
            {
                Value = Id
            };

            return await _context.Database
                .SqlQuery<TablaCodigo>("EXEC dbo.SP_TablaCodigoBuscarById @Id", pId)
                .SingleOrDefaultAsync();
        }

        public async Task<int> AddAsync(TablaCodigo tablaCodigo)
        {
            var parametroId = new SqlParameter("@Id", System.Data.SqlDbType.Int);
            var parametroCodigo = new SqlParameter("@Codigo", tablaCodigo.Codigo);
            var parametroDescripcion = new SqlParameter("@Descripcion", tablaCodigo.Descripcion);

            parametroId.Direction = System.Data.ParameterDirection.Output;

            await _context.Database.ExecuteSqlCommandAsync(
                $@"EXEC dbo.SP_TablaCodigoInsertar 
                    @Codigo ={parametroCodigo},
                    @Descripcion = {parametroDescripcion}, 
                    @Id = {parametroId} OUTPUT");

            var id = (int)parametroId.Value;
            return id;
        }

        public async Task<bool> UpdateAsync(TablaCodigo tablaCodigo)
        {
            var parametroId = new SqlParameter("@Id", System.Data.SqlDbType.Int);
            var parametroCodigo = new SqlParameter("@Codigo", tablaCodigo.Codigo);
            var parametroDescripcion = new SqlParameter("@Descripcion", tablaCodigo.Descripcion);
            var parametroExisto = new SqlParameter("@Id", System.Data.SqlDbType.Bit);

            parametroExisto.Direction = System.Data.ParameterDirection.Output;

            await _context.Database.ExecuteSqlCommandAsync(
                $@"EXEC dbo.SP_TablaCodigoActualizar 
                    @Id = {parametroId},
                    @Codigo ={parametroCodigo},
                    @Descripcion = {parametroDescripcion}, 
                    @Exito = {parametroExisto} OUTPUT");

            return (bool)parametroId.Value;
        }

        public async Task<bool> Delete(int id)
        {
            var parametroId = new SqlParameter("@Id", System.Data.SqlDbType.Int);
            var parametroExisto = new SqlParameter("@Id", System.Data.SqlDbType.Bit);
            parametroExisto.Direction = System.Data.ParameterDirection.Output;

            await _context.Database.ExecuteSqlCommandAsync(
                $@"EXEC dbo.SP_TablaCodigoEliminar 
                    @Id = {parametroId},                   
                    @Exito = {parametroExisto} OUTPUT");

            return (bool)parametroId.Value;
        }


    }
}
