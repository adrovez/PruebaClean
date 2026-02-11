using Honda.Entidades.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Honda.DALC.Repositories
{
    public interface ITablaCodigoRepository
    {
        Task<List<TablaCodigoDto>> getListar(string filtro);
        Task<TablaCodigoDto> getBuscarPorId(int Id);
        Task<int> setAgregar(TablaCodigoDto item);
        Task<bool> setActualizar(TablaCodigoDto item);
        Task<bool> setEliminar(int Id);

    }
}
