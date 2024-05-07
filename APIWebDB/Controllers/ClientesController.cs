using APIWebDB.BaseDados.Models;
using APIWebDB.Services;
using APIWebDB.Services.DTOs;
using APIWebDB.Services.Exceptions;
using APIWebDB.Services.Parser;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel;

namespace APIWebDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ClienteService _service;
        private readonly ILogger _logger;

        public ClientesController(ClienteService service, ILogger<ClientesController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost()]
        public ActionResult<TbCliente> Insert(ClienteDTO cliente)
        {
            try
            {
                var entity = _service.Insert(cliente);
                return Ok(entity);
            }
            catch (InvalidEntityException E)
            {
                _logger.LogError(E.Message);
                return new ObjectResult(new { error = E.Message })
                {
                    StatusCode = 422
                };

            }
            catch (Exception E)
            {
                return BadRequest(E.Message);
            }

        }

        [HttpPut("{id}")]
        public ActionResult<TbCliente> Put(int id, ClienteDTO cliente)
        {
            try
            {
                var entity = _service.Put(cliente, id);
                return Ok(entity);
            }
            catch (InvalidEntityException E)
            {
                return new ObjectResult(new { error = E.Message })
                {
                    StatusCode = 422
                };

            }
            catch (Exception E)
            {
                return BadRequest(E.Message);
            }

        }

        [HttpPatch("{id}")]
        public ActionResult<TbCliente> Update(int id, ClienteDTO cliente)
        {
            try
            {
                var existingEntity = _service.GetById(id);
                if (existingEntity == null)
                {
                    return NotFound();
                }
                 // todo: tirar regra do controller
                ClienteParser.UpdateEntityFromDTO(cliente, existingEntity);

                var updatedEntity = _service.Update(existingEntity);
                return Ok(updatedEntity);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<TbCliente> Delete(int id)
        {
            try
            {
                _service.Delete(id);
                return NoContent();
            }
            catch (NotFoundException E)
            {
                return NotFound(E.Message);
            }
            catch (Exception E)
            {
                return new ObjectResult(new { error = E.Message })
                {
                    StatusCode = 500
                };

            }
        }

        [HttpGet("{id}")]
        public ActionResult<TbCliente> GetById(int id)
        {
            try
            {
                var entity = _service.GetById(id);
                return Ok(entity);
            }
            catch (NotFoundException E)
            {
                return NotFound(E.Message);
            }
            catch (System.Exception e)
            {
                return new ObjectResult(new { error = e.Message })
                {
                    StatusCode = 500
                };
            }
        }
        [HttpGet()]
        public ActionResult<TbCliente> GetAll()
        {
            try
            {
                var entity = _service.GetAll();
                return Ok(entity);
            }
            catch (NotFoundException E)
            {
                return NotFound(E.Message);
            }
            catch (System.Exception e)
            {
                return new ObjectResult(new { error = e.Message })
                {
                    StatusCode = 500
                };
            }
        }
    

}
}
