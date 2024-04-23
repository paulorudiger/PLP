using APIWebDB.BaseDados.Models;
using APIWebDB.Services;
using APIWebDB.Services.DTOs;
using APIWebDB.Services.Exceptions;
using APIWebDB.Services.Parser;
using Microsoft.AspNetCore.Mvc;
using System;

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

                ClienteParser.UpdateEntityFromDTO(cliente, existingEntity);

                var updatedEntity = _service.Update(existingEntity);
                return Ok(updatedEntity);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
