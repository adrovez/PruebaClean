using Honda.API.Models;
using Honda.BLL.Services;
using Honda.Entidades.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Honda.API.Controllers
{
    [RoutePrefix("api/codigo")]
    public class CodigoController : ApiController
    {
        private readonly ITablaCodigoService _service;

        public CodigoController()
        {
            _service = new TablaCodigoService();
        }


        [HttpGet]
        [Route("listar")]
        public async Task<IHttpActionResult> getListar()
        {
            List<TablaCodigoModel> model = new List<TablaCodigoModel>();
            var response = await _service.Listar("");
            foreach (var item in response)
            {
                model.Add(new TablaCodigoModel
                {
                    Id = item.Id,
                    Codigo = item.Codigo,
                    Descripcion = item.Descripcion
                });
            }

            return Ok(model);
        }

        [HttpGet]
        [Route("buscar/{id}")]
        public async Task<IHttpActionResult> getBuscar(int id)
        {
            try
            {
                var response = await _service.BuscarPorId(id);
                TablaCodigoModel model = new TablaCodigoModel
                {
                    Id = response.Id,
                    Codigo = response.Codigo,
                    Descripcion = response.Descripcion
                };
                return Ok(model);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpPost]
        [Route("agregar")]
        public async Task<IHttpActionResult> setAgregar([FromBody] TablaCodigoModel item)
        {            
            TablaCodigoDto dto = new TablaCodigoDto
            {
                Id = item.Id,
                Codigo = item.Codigo,
                Descripcion = item.Descripcion
            };

            int resp = await _service.Agregar(dto);

            return Ok(resp);
        }

        [HttpPut]
        [Route("actualizar")]
        public async Task<IHttpActionResult> setActualizar([FromBody] TablaCodigoModel item)
        {
            TablaCodigoDto dto = new TablaCodigoDto
            {
                Id = item.Id,
                Codigo = item.Codigo,
                Descripcion = item.Descripcion
            };

            var resp = await _service.Actualizar(dto);

            return Ok(resp);
        }

        [HttpDelete]
        [Route("eliminar")]
        public async Task<IHttpActionResult> setEliminar(int Id)
        {
            var resp = await _service.Eliminar(Id);

            return Ok(resp);
        }

    }
}
