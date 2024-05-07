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
    public class ClientesController : ControllerBase
    {
        private readonly ClienteService _service;
        private readonly ILogger _logger;

        public ClientesController(ClienteService service, ILogger<ClientesController> logger)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Rota para insercao de novos clientes
        /// </summary>
        ///  <param name="clienteDTO">json dos dados que serão inseridos.  
        ///     Obrigatorios: Nome, Documento, Tipodoc
        /// </param>
        /// <returns>Retorna o cliente inserido</returns>
        /// <response code="200">Retorna o Json com o cliente cadastrado</response>
        /// <response code="400">Os dados enviados não são válidos</response>
        /// <response code="422">Campos obrigatórios não enviados para a inserir cliente</response>
        /// <response code="500">Erro interno de servidor</response>
        [HttpPost()]
        public ActionResult<TbCliente> Insert(ClienteDTO clienteDTO)
        {
            try
            {
                var entity = _service.Insert(clienteDTO);
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
                _logger.LogError(E.Message);
                return BadRequest(E.Message);
            }

        }

        /// <summary>
        /// Rota para atualizacao de clientes. 
        /// </summary>
        /// <param name="id">id do cliente que será atualizado</param>
        ///  <param name="clienteDTO">json dos dados que serão inseridos.  
        ///     Obrigatorios: Nome, Documento, Tipodoc
        /// </param>
        /// <returns>Retorna o cliente que foi atualizado</returns>
        /// <response code="200">Retorna o Json com o cliente atualizado</response>
        /// <response code="400">Os dados enviados não são válidos</response>
        /// <response code="422">Campos obrigatórios não enviados para a atualizacão</response>
        /// <response code="500">Erro interno de servidor</response>
        [HttpPut("{id}")]
        public ActionResult<TbCliente> Put(int id, ClienteDTO clienteDTO)
        {
            try
            {
                var entity = _service.Put(clienteDTO, id);
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
                _logger.LogError(E.Message);
                return BadRequest(E.Message);
            }

        }

        /// <summary>
        /// Rota para delecao de clientes. 
        /// </summary>
        /// <param name="id">id do cliente que será deletado</param>
        /// <returns>Retorna o cliente deletado</returns>
        /// <response code="204">Retorna que o servidor executou com sucesso mas não tem nada a retornar</response>
        /// <response code="404">Endereço não encontrado</response>
        /// <response code="500">Erro interno de servidor</response>
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
                _logger.LogError(E.Message);
                return NotFound(E.Message);
            }
            catch (Exception E)
            {
                _logger.LogError(E.Message);
                return new ObjectResult(new { error = E.Message })
                {
                    StatusCode = 500
                };

            }
        }

        /// <summary>
        /// Rota para consulta de cliente já cadastrado. 
        /// </summary>
        /// <param name="id">id do cliente que será consultado </param>,
        /// <returns>Retorna o cliente solicitado</returns>
        /// <response code="200">Retorna o Json com os dados do cliente</response>
        /// <response code="404">Endereço não encontrado</response>
        /// <response code="500">Erro interno de servidor</response>
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
                _logger.LogError(E.Message);
                return NotFound(E.Message);
            }
            catch (System.Exception e)
            {
                _logger.LogError(e.Message);
                return new ObjectResult(new { error = e.Message })
                {
                    StatusCode = 500
                };
            }
        }
        /// <summary>
        /// Rota para consulta de todos os clientes cadastrados. 
        /// </summary>
        /// <returns>Retorna a lista de clientes cadastrados</returns>
        /// <response code="200">Retorna o Json com os dados de todos os clientes cadastrados</response>
        /// <response code="404">Endereço não encontrado</response>
        /// <response code="500">Erro interno de servidor</response>
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
                _logger.LogError(E.Message);
                return NotFound(E.Message);
            }
            catch (System.Exception e)
            {
                _logger.LogError(e.Message);
                return new ObjectResult(new { error = e.Message })
                {
                    StatusCode = 500
                };
            }
        }
    }
}
