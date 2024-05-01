using APIWebDB.BaseDados.Models;
using APIWebDB.Services;
using APIWebDB.Services.DTOs;
using APIWebDB.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace APIWebDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly EnderecoService _service;
        private readonly ILogger _logger;

        public EnderecoController(EnderecoService service, ILogger<EnderecoController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost()]
        public ActionResult<TbEndereco> Insert(EnderecoDTO enderecoDTO)
        {
            try
            {
                var entity = _service.Insert(enderecoDTO);
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
        public ActionResult<TbEndereco> Put(int id, EnderecoDTO enderecoDTO)
        {
            try
            {
                var entity = _service.Put(enderecoDTO, id);
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
        public ActionResult<TbEndereco> Update(int id, EnderecoDTO enderecoDTO)
        {
            try
            {
                var updatedEntity = _service.Update(id, enderecoDTO);
                return Ok(updatedEntity);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<TbEndereco> Delete(int id)
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

        [HttpGet("/getById/{id}")]
        public ActionResult<TbEndereco> GetById(int id)
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
        [HttpGet("/getAll/{id}")]
        public ActionResult<TbEndereco> GetAll(int id)
        {
            try
            {
                var entity = _service.GetAll(id);
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
