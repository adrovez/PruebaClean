using Honda.Entidades.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Honda.BLL.Services
{
    public interface ITablaCodigoService
    {
        Task<List<TablaCodigoDto>> Listar(string filtro);
        Task<TablaCodigoDto> BuscarPorId(int Id);
        Task<int> Agregar(TablaCodigoDto item);
        Task<bool> Actualizar(TablaCodigoDto item);
        Task<bool> Eliminar(int Id);
    }
}
