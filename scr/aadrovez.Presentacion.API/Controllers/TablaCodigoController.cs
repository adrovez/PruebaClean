using aadrovez.Aplicacion.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace aadrovez.Presentacion.API.Controllers
{
    [RoutePrefix("api/Codigo")]
    public class TablaCodigoController : ApiController
    {
        private readonly ITablaCodigoService _tablaCodigoService;

        public TablaCodigoController(ITablaCodigoService tablaCodigoService)
        {
            _tablaCodigoService = tablaCodigoService;
        }

        [Route("listar")]
        public IHttpActionResult Get()
        {
            try
            {
                var result = _tablaCodigoService.GetAllAsync("");
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return InternalServerError(ex);
            }
        }
    }
}
