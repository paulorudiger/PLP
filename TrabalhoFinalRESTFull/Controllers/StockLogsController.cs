using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using TrabalhoFinalRESTFull.BaseDados.Models;
using TrabalhoFinalRESTFull.Services;
using TrabalhoFinalRESTFull.Services.DTOs;
using TrabalhoFinalRESTFull.Services.Exceptions;

namespace TrabalhoFinalRESTFull.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockLogsController : ControllerBase
    {
        private readonly StockLogService _service;
        private readonly ILogger _logger;

        public StockLogsController(StockLogService service, ILogger<StockLogsController> logger)
        {
            _service = service;
            _logger = logger;
        }
              
        /*

        /// <summary>
        /// Rota para deleção de logs de estoque
        /// </summary>
        /// <param name="id">ID do log de estoque que será deletado</param>
        /// <returns>Retorna o log de estoque deletado</returns>
        /// <response code="204">Retorna que o servidor executou com sucesso mas não tem nada a retornar</response>
        /// <response code="404">Log de estoque não encontrado</response>
        /// <response code="500">Erro interno de servidor</response>
        [HttpDelete("{id}")]
        public ActionResult<TbStockLog> Delete(long id)
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
        /// Rota para consulta de log de estoque já cadastrado
        /// </summary>
        /// <param name="id">ID do log de estoque que será consultado</param>
        /// <returns>Retorna o log de estoque solicitado</returns>
        /// <response code="200">Retorna o JSON com os dados do log de estoque</response>
        /// <response code="404">Log de estoque não encontrado</response>
        /// <response code="500">Erro interno de servidor</response>
        [HttpGet("{id}")]
        public ActionResult<TbStockLog> GetById(long id)
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
            catch (Exception E)
            {
                _logger.LogError(E.Message);
                return new ObjectResult(new { error = E.Message })
                {
                    StatusCode = 500
                };
            }
        }
        */


        /// <summary>
        /// Consultar logs por produto
        /// </summary>
        /// <param name="productId">ID do produto</param>
        /// <returns>Retorna a lista de logs</returns>
        /// <response code="200">Retorna o JSON com os dados dos logs</response>
        /// <response code="404">Nenhum log encontrado</response>
        /// <response code="500">Erro interno de servidor</response>
        [HttpGet("product/{productId}")]
        public ActionResult<IEnumerable<StockLogDTO>> GetLogsByProduct(int productId)
        {
            try
            {
                var entities = _service.GetLogsByProduct(productId);
                return Ok(entities);
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
        /// Rota para listar todos os logs de estoque
        /// </summary>
        /// <returns>Retorna a lista de logs de estoque</returns>
        /// <response code="200">Retorna o JSON com os dados dos logs de estoque</response>
        /// <response code="404">Nenhum log de estoque encontrado</response>
        /// <response code="500">Erro interno de servidor</response>
        [HttpGet]
        public ActionResult<IEnumerable<TbStockLog>> GetAll()
        {
            try
            {
                var entities = _service.GetAll();
                return Ok(entities);
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
    }
}
