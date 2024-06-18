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
    public class PromotionsController : ControllerBase
    {
        private readonly PromotionService _service;
        private readonly ILogger _logger;

        public PromotionsController(PromotionService service, ILogger<PromotionsController> logger)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Rota para inserção de novas promoções
        /// </summary>
        /// <param name="promotionDTO">JSON dos dados que serão inseridos.
        ///     Obrigatórios: Startdate, Enddate, Promotiontype, Productid, Value
        /// </param>
        /// <returns>Retorna a promoção inserida</returns>
        /// <response code="200">Retorna o JSON com a promoção cadastrada</response>
        /// <response code="400">Os dados enviados não são válidos</response>
        /// <response code="422">Campos obrigatórios não enviados para a inserção da promoção</response>
        /// <response code="500">Erro interno de servidor</response>
        [HttpPost]
        public ActionResult<TbPromotion> Insert(PromotionDTO promotionDTO)
        {
            try
            {
                var entity = _service.Insert(promotionDTO);
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
        /// Rota para atualização de promoções
        /// </summary>
        /// <param name="id">ID da promoção que será atualizada</param>
        /// <param name="promotionDTO">JSON dos dados que serão atualizados.
        ///     Obrigatórios: Startdate, Enddate, Promotiontype, Productid, Value
        /// </param>
        /// <returns>Retorna a promoção atualizada</returns>
        /// <response code="200">Retorna o JSON com a promoção atualizada</response>
        /// <response code="400">Os dados enviados não são válidos</response>
        /// <response code="422">Campos obrigatórios não enviados para a atualização da promoção</response>
        /// <response code="500">Erro interno de servidor</response>
        [HttpPut("{id}")]
        public ActionResult<TbPromotion> Put(int id, PromotionDTO promotionDTO)
        {
            try
            {
                var entity = _service.Put(promotionDTO, id);
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
        /// Rota para deleção de promoções
        /// </summary>
        /// <param name="id">ID da promoção que será deletada</param>
        /// <returns>Retorna a promoção deletada</returns>
        /// <response code="204">Retorna que o servidor executou com sucesso mas não tem nada a retornar</response>
        /// <response code="404">Promoção não encontrada</response>
        /// <response code="500">Erro interno de servidor</response>
        [HttpDelete("{id}")]
        public ActionResult<TbPromotion> Delete(int id)
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
        /// Rota para consulta de promoção já cadastrada
        /// </summary>
        /// <param name="id">ID da promoção que será consultada</param>
        /// <returns>Retorna a promoção solicitada</returns>
        /// <response code="200">Retorna o JSON com os dados da promoção</response>
        /// <response code="404">Promoção não encontrada</response>
        /// <response code="500">Erro interno de servidor</response>
        [HttpGet("{id}")]
        public ActionResult<TbPromotion> GetById(int id)
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

        /// <summary>
        /// Rota para buscar promoções de um produto em um determinado período
        /// </summary>
        /// <param name="productId">ID do produto</param>
        /// <param name="startDate">Data de início do período</param>
        /// <param name="endDate">Data de fim do período</param>
        /// <returns>Retorna a lista de promoções</returns>
        /// <response code="200">Retorna o JSON com os dados das promoções</response>
        /// <response code="404">Nenhuma promoção encontrada</response>
        /// <response code="500">Erro interno de servidor</response>
        [HttpGet("product/{productId}/period")]
        public ActionResult<IEnumerable<TbPromotion>> GetPromotionsByProductAndPeriod(int productId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var entities = _service.GetPromotionsByProductAndPeriod(productId, startDate, endDate);
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
        /// Rota para listar todas as promoções
        /// </summary>
        /// <returns>Retorna a lista de promoções</returns>
        /// <response code="200">Retorna o JSON com os dados das promoções</response>
        /// <response code="404">Nenhuma promoção encontrada</response>
        /// <response code="500">Erro interno de servidor</response>
        [HttpGet]
        public ActionResult<IEnumerable<TbPromotion>> GetAll()
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
