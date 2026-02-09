using aadrovez.Contracts.DTO;
using aadrovez.DALC.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace aadrovez.BLL.Services
{
    public class TablaCodigoService : ITablaCodigoService
    {
        private readonly ITablaCodigoRepository _tablaCodigoRepository;

        public TablaCodigoService()
        {
            _tablaCodigoRepository = new TablaCodigoRepository();
        }
        public Task<bool> ActualizarAsync(TablaCodigoDto TablaCodigoDto)
        {
            Validate(TablaCodigoDto);

            return _tablaCodigoRepository.UpdateAsync(TablaCodigoDto);
        }

        public Task<TablaCodigoDto> BuacarPorId(int Id)
        {
            if (Id <= 0)
            {
                throw new ArgumentException("El Id debe ser mayor que cero.", nameof(Id));
            }
            return _tablaCodigoRepository.GetByIdAsync(Id);
        }

        public async Task<List<TablaCodigoDto>> BuscarTablaCodigo(string filtro)
        {
            return await _tablaCodigoRepository.GetAllAsync(filtro);
        }

        public async Task<bool> Eliminar(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El Id debe ser mayor que cero.", nameof(id));
            }

            return await _tablaCodigoRepository.Delete(id);
        }

        public async Task<int> InsertarAsync(TablaCodigoDto TablaCodigoDto)
        {
            Validate(TablaCodigoDto);

            return await _tablaCodigoRepository.AddAsync(TablaCodigoDto);
        }

        private void Validate(TablaCodigoDto dto)
        {
            if (dto == null) throw new System.ArgumentNullException(nameof(dto));
            if (string.IsNullOrWhiteSpace(dto.Codigo)) throw new System.ArgumentException("Codigo requerido");
            if (string.IsNullOrWhiteSpace(dto.Descripcion)) throw new System.ArgumentException("Descripcion requerida");
        }

    }
}
