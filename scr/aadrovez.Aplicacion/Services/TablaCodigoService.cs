using aadrovez.Aplicacion.DTOs;
using aadrovez.Aplicacion.IRepositories;
using aadrovez.Aplicacion.IServices;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace aadrovez.Aplicacion.Services
{
    public class TablaCodigoService : ITablaCodigoService
    {
        private readonly ITablaCodigoRepository _tablaCodigoRepository;
        private readonly IMapper _mapper;



        public TablaCodigoService(ITablaCodigoRepository tablaCodigoRepository
                                , IMapper mapper)
        {
            _tablaCodigoRepository = tablaCodigoRepository;
            _mapper = mapper;
        }

        public Task<int> AddAsync(TablaCodigoDto tablaCodigo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TablaCodigoDto>> GetAllAsync(string filtro)
        {
            var resp = await _tablaCodigoRepository.GetAllAsync(filtro);
            return _mapper.Map<List<TablaCodigoDto>>(resp);
        }

        public Task<TablaCodigoDto> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(TablaCodigoDto tablaCodigo)
        {
            throw new NotImplementedException();
        }
    }
}
