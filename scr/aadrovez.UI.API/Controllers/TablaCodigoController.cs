using aadrovez.BLL.Factory;
using aadrovez.BLL.Services;
using System.Threading.Tasks;
using System.Web.Http;

namespace aadrovez.UI.API.Controllers
{
    public class TablaCodigoController : ApiController
    {
        private readonly ITablaCodigoService _service;

        public TablaCodigoController()
        {
            _service = ServiceFactory.CreateTablaCodigoService();
        }
        // GET: api/TablaCodigo
        public async Task<IHttpActionResult> GetAll(string filtro)
        {
            var data = await _service.BuscarTablaCodigo(filtro);
            return Ok(data);
        }

        // GET: api/TablaCodigo/5
        public async Task<IHttpActionResult> Get(int id)
        {
            var data = await _service.BuacarPorId(id);
            return Ok(data);
        }

        // POST: api/TablaCodigo
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/TablaCodigo/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/TablaCodigo/5
        public void Delete(int id)
        {
        }
    }
}
