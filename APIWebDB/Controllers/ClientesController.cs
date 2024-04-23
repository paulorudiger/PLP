using APIWebDB.BaseDados.Models;
using APIWebDB.Services;
using APIWebDB.Services.DTOs;
using APIWebDB.Services.Parser;
using Microsoft.AspNetCore.Mvc;

namespace APIWebDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {

        private readonly ClienteService _service;
        public ClientesController(ClienteService service)
        {
            _service = service;
        }

        [HttpPost()]
        public ActionResult<TbCliente> Insert(ClienteDTO cliente)
        {
            try
            {
                var entity = _service.Insert(cliente);
                return Ok(entity);
            }
            catch (System.Exception E)
            {
                return BadRequest(E.Message);
            }

        }
    }
}
