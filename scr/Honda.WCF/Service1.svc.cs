using Honda.BLL.Services;
using Honda.Entidades.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Honda.WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        private readonly ITablaCodigoService _service;
        public Service1()
        {
            _service = new TablaCodigoService();
        }

        public async Task<TablaCodigoWCF> getBuscarTablaCodigo(int id)
        {
            TablaCodigoWCF item = new TablaCodigoWCF();
            var resp = await _service.BuscarPorId(id);

            if (resp == null)
            {
                item.Id = resp.Id;
                item.Codigo = resp.Codigo;
                item.Descripcion = resp.Descripcion;
            }

            return item;
        }

        public async Task<List<TablaCodigoWCF>> getListarTablaCodigo(string pFiltro)
        {
            List<TablaCodigoWCF> wcfItem = new List<TablaCodigoWCF>();
            var resp = await _service.Listar(pFiltro);

            foreach (var item in resp)
            {
                wcfItem.Add(new TablaCodigoWCF
                {
                    Id = item.Id,
                    Codigo = item.Codigo,
                    Descripcion = item.Descripcion
                });
            }

            return wcfItem;
        }

        public async Task<bool> setActualizarTabalCodigo(TablaCodigoWCF item)
        {
            TablaCodigoDto ItemDto = new TablaCodigoDto
            {
                Id = item.Id,
                Codigo = item.Codigo,
                Descripcion = item.Descripcion
            };
            var resp = await _service.Actualizar(ItemDto);
            return resp;
        }

        public async Task<int> setAgregarTablaCodigo(TablaCodigoWCF item)
        {
            TablaCodigoDto ItemDto = new TablaCodigoDto
            {
                Id = item.Id,
                Codigo = item.Codigo,
                Descripcion = item.Descripcion
            };
            var resp = await _service.Agregar(ItemDto);
            return resp;
        }

        public async Task<bool> setEliminarTabalCodigo(int Id)
        {
            var resp = await _service.Eliminar(Id);
            return resp;
        }
    }
}
