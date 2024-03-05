using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Interfaces;
using PruebaTecnica.Models;
using System.Net.Http.Json;
using System.Security.Principal;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace PruebaTecnica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpresaController : Controller
    {
        private readonly iEmpresa _IEmpresa;
        public EmpresaController(iEmpresa iempresa)
        {
            _IEmpresa = iempresa;
        }

        [HttpGet("Index")]
        public async Task<IActionResult>  Index()
        {
            object respuesta = await _IEmpresa.GeteEmpresasAsync();
            return Ok(respuesta);
        }

        [HttpDelete]
        [Route("delete/{empresaId}")]
        public IActionResult Delete(int empresaId)
        {
            object respuesta = _IEmpresa.DeleteEmpresa(empresaId);
            return Ok(respuesta);
        }

        [HttpPost]
        public async Task<IActionResult> NuevaEmpresa([FromBody]EmpresaModel empresa)
        {
            if (empresa != null) {
                object respuesta = _IEmpresa.NewEmpresa(empresa);
                return Ok(respuesta);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
