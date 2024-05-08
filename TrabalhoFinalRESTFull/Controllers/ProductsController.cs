using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using TrabalhoFinalRESTFull.BaseDados.Models;
using TrabalhoFinalRESTFull.Services;
using TrabalhoFinalRESTFull.Services.DTOs;
using TrabalhoFinalRESTFull.Services.Exceptions;

namespace TrabalhoFinalRESTFull.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _service;
        private readonly ILogger _logger;

        public ProductsController(ProductService service, ILogger<ProductsController> logger)
        {
            _service = service;
            _logger = logger;
        }


        /// <summary>
        /// Rota para insercao de novos clientes
        /// </summary>
        ///  <param name="productDTO">json dos dados que serão inseridos.  
        ///     Obrigatorios: Nome, Documento, Tipodoc
        /// </param>
        /// <returns>Retorna o cliente inserido</returns>
        /// <response code="200">Retorna o Json com o cliente cadastrado</response>
        /// <response code="400">Os dados enviados não são válidos</response>
        /// <response code="422">Campos obrigatórios não enviados para a inserir cliente</response>
        /// <response code="500">Erro interno de servidor</response>
        [HttpPost()]
        public ActionResult<TbProduct> Insert(ProductDTO productDTO)
        {
            try
            {
                var entity = _service.Insert(productDTO);
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


    }
}
