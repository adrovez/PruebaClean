using aadrovez.Contracts.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace aadrovez.BLL.Services
{
    public interface ITablaCodigoService
    {
        Task<List<TablaCodigoDto>> BuscarTablaCodigo(string filtro);
        Task<TablaCodigoDto> BuacarPorId(int Id);
        Task<int> InsertarAsync(TablaCodigoDto TablaCodigoDto);
        Task<bool> ActualizarAsync(TablaCodigoDto TablaCodigoDto);
        Task<bool> Eliminar(int id);
    }
}
