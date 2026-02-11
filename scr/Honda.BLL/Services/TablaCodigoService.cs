using Honda.DALC.Repositories;
using Honda.Entidades.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Honda.BLL.Services
{
    public class TablaCodigoService : ITablaCodigoService
    {
        private readonly ITablaCodigoRepository _repository;

        public TablaCodigoService()
        {
            _repository = new TablaCodigoRepository();
        }

        public Task<List<TablaCodigoDto>> Listar(string filtro)
        {
            try
            {
                return _repository.getListar(filtro);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los códigos: " + ex.Message);
            }
        }

        public Task<TablaCodigoDto> BuscarPorId(int Id)
        {
            try
            {
                if (Id <= 0)
                {
                    throw new ArgumentException("El campo Id debe ser mayor a cero.");
                }

                return _repository.getBuscarPorId(Id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al bucar: " + ex.Message);
            }
        }

        public Task<int> Agregar(TablaCodigoDto item)
        {
            try
            {
                Validar(item);
                return _repository.setAgregar(item);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar: " + ex.Message);
            }
        }

        public Task<bool> Actualizar(TablaCodigoDto item)
        {
            try
            {
                if (item.Id <= 0)
                {
                    throw new ArgumentException("El campo Id debe ser mayor a cero.");
                }

                Validar(item);
                return _repository.setActualizar(item);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar: " + ex.Message);
            }
        }

        public Task<bool> Eliminar(int Id)
        {
            if (Id <= 0)
            {
                throw new ArgumentException("El campo Id debe ser mayor a cero.");
            }

            return _repository.setEliminar(Id);
        }

        public void Validar(TablaCodigoDto Item)
        {
            if (string.IsNullOrEmpty(Item.Codigo))
            {
                throw new ArgumentException("El campo Codigo es obligatorio.");
            }
            if (string.IsNullOrEmpty(Item.Descripcion))
            {
                throw new ArgumentException("El campo Descripcion es obligatorio.");
            }
        }




    }
}
