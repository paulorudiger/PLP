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
    public class SalesController : ControllerBase
    {
        private readonly SalesService _service;
        private readonly ILogger _logger;

        public SalesController(SalesService service, ILogger<SalesController> logger)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Rota para inserção de novas vendas
        /// </summary>
        /// <param name="saleDTO">JSON dos dados que serão inseridos.
        ///     Obrigatórios: Code, Createat, Productid, Price, Qty, Discount
        /// </param>
        /// <returns>Retorna a venda inserida</returns>
        /// <response code="200">Retorna o JSON com a venda cadastrada</response>
        /// <response code="400">Os dados enviados não são válidos</response>
        /// <response code="422">Campos obrigatórios não enviados para a inserção da venda</response>
        /// <response code="500">Erro interno de servidor</response>
        [HttpPost]
        public ActionResult<TbSale> Insert(SaleDTO saleDTO)
        {
            try
            {
                var entity = _service.Insert(saleDTO);
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
        /// Rota para consulta de venda já cadastrada pelo código da venda
        /// </summary>
        /// <param name="code">Código da venda</param>
        /// <returns>Retorna a venda solicitada</returns>
        /// <response code="200">Retorna o JSON com os dados da venda</response>
        /// <response code="404">Venda não encontrada</response>
        /// <response code="500">Erro interno de servidor</response>
        [HttpGet("code/{code}")]
        public ActionResult<TbSale> GetByCode(string code)
        {
            try
            {
                var entity = _service.GetByCode(code);
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
        /// Rota para listar todas as vendas
        /// </summary>
        /// <returns>Retorna a lista de vendas</returns>
        /// <response code="200">Retorna o JSON com os dados das vendas</response>
        /// <response code="404">Nenhuma venda encontrada</response>
        /// <response code="500">Erro interno de servidor</response>
        [HttpGet]
        public ActionResult<IEnumerable<TbSale>> GetAll()
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

        /// <summary>
        /// Relatório de vendas por período
        /// </summary>
        /// <param name="startDate">Data de início do período</param>
        /// <param name="endDate">Data de fim do período</param>
        /// <returns>Retorna o relatório de vendas</returns>
        /// <response code="200">Retorna o JSON com os dados do relatório</response>
        /// <response code="404">Nenhuma venda encontrada</response>
        /// <response code="500">Erro interno de servidor</response>
        [HttpGet("report")]
        public ActionResult<IEnumerable<SaleReportDTO>> GetSalesReportByPeriod(DateTime startDate, DateTime endDate)
        {
            try
            {
                var entities = _service.GetSalesReportByPeriod(startDate, endDate);
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
