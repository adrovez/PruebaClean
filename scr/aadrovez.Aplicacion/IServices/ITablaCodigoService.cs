using aadrovez.Aplicacion.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace aadrovez.Aplicacion.IServices
{
    public interface ITablaCodigoService
    {
        Task<List<TablaCodigoDto>> GetAllAsync(string filtro);
        Task<TablaCodigoDto> GetByIdAsync(int Id);
        Task<int> AddAsync(TablaCodigoDto tablaCodigo);
        Task<bool> UpdateAsync(TablaCodigoDto tablaCodigo);
        Task<bool> DeleteAsync(int id);

    }
}
