using aadrovez.BLL.Factory;
using aadrovez.BLL.Services;
using aadrovez.Contracts.DTO;
using System.Threading.Tasks;
using System.Web.Http;

namespace aadrovez.UI.API.Controllers
{
    [RoutePrefix("api/codigo")]
    public class TablaCodigoController : ApiController
    {
        private readonly ITablaCodigoService _service;

        public TablaCodigoController()
        {
            _service = ServiceFactory.CreateTablaCodigoService();
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IHttpActionResult> GetAll(string filtro)
        {
            var data = await _service.BuscarTablaCodigo(filtro);
            return Ok(data);
        }

        [HttpGet]
        [Route("Buscar")]
        public async Task<IHttpActionResult> Get(int id)
        {
            var data = await _service.BuacarPorId(id);
            return Ok(data);
        }

        [HttpPut]
        [Route("Insertar")]
        public async Task<IHttpActionResult> Post([FromBody] TablaCodigoDto tablaCodigo)
        {
            if (tablaCodigo == null)
            {
                return BadRequest("El cuerpo de la solicitud es requerido.");
            }

            var id = await _service.InsertarAsync(tablaCodigo);
            return Ok(id);
        }

        // PUT: api/TablaCodigo/5
        public async Task<IHttpActionResult> Put([FromBody] TablaCodigoDto tablaCodigo)
        {
            if (tablaCodigo == null)
            {
                return BadRequest("El cuerpo de la solicitud es requerido.");
            }            

            if (tablaCodigo.Id != 0)
            {
                return BadRequest("El id de la ruta no coincide con el id del cuerpo.");
            }
           
            var actualizado = await _service.ActualizarAsync(tablaCodigo);
            return Ok(actualizado);
        }

        // DELETE: api/TablaCodigo/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            var eliminado = await _service.Eliminar(id);
            return Ok(eliminado);
        }


    }
}
