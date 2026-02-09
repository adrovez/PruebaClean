using aadrovez.Dominio.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace aadrovez.Aplicacion.IRepositories
{
    public interface ITablaCodigoRepository
    {
        Task<List<TablaCodigo>> GetAllAsync(string filtro);
        Task<TablaCodigo> GetByIdAsync(int Id);
        Task<int> AddAsync(TablaCodigo tablaCodigo);
        Task<bool> UpdateAsync(TablaCodigo tablaCodigo);
        Task<bool> Delete(int id);
    }
}
