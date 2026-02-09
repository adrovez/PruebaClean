using aadrovez.Contracts.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace aadrovez.DALC.Repository
{
    public interface ITablaCodigoRepository
    {
        Task<List<TablaCodigoDto>> GetAllAsync(string filtro);
        Task<TablaCodigoDto> GetByIdAsync(int Id);
        Task<int> AddAsync(TablaCodigoDto TablaCodigoDto);
        Task<bool> UpdateAsync(TablaCodigoDto TablaCodigoDto);
        Task<bool> Delete(int id);
    }
}
