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
        /// Rota para inserção de novos produtos
        /// </summary>
        /// <param name="productDTO">JSON dos dados que serão inseridos.  
        ///     Obrigatórios: Nome, Documento, Tipodoc
        /// </param>
        /// <returns>Retorna o produto inserido</returns>
        /// <response code="200">Retorna o JSON com o produto cadastrado</response>
        /// <response code="400">Os dados enviados não são válidos</response>
        /// <response code="422">Campos obrigatórios não enviados para a inserção do produto</response>
        /// <response code="500">Erro interno de servidor</response>
        [HttpPost]
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

        /// <summary>
        /// Rota para atualização de produtos
        /// </summary>
        /// <param name="id">ID do produto que será atualizado</param>
        /// <param name="productDTO">JSON dos dados que serão atualizados.  
        ///     Obrigatórios: Nome, Documento, Tipodoc
        /// </param>
        /// <returns>Retorna o produto atualizado</returns>
        /// <response code="200">Retorna o JSON com o produto atualizado</response>
        /// <response code="400">Os dados enviados não são válidos</response>
        /// <response code="422">Campos obrigatórios não enviados para a atualização do produto</response>
        /// <response code="500">Erro interno de servidor</response>
        [HttpPut("{id}")]
        public ActionResult<TbProduct> Put(int id, ProductDTO productDTO)
        {
            try
            {
                var entity = _service.Put(productDTO, id);
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
        /// Rota para deleção de produtos
        /// </summary>
        /// <param name="id">ID do produto que será deletado</param>
        /// <returns>Retorna o produto deletado</returns>
        /// <response code="204">Retorna que o servidor executou com sucesso mas não tem nada a retornar</response>
        /// <response code="404">Produto não encontrado</response>
        /// <response code="500">Erro interno de servidor</response>
        [HttpDelete("{id}")]
        public ActionResult<TbProduct> Delete(int id)
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
        /// Rota para consulta de produto já cadastrado
        /// </summary>
        /// <param name="id">ID do produto que será consultado</param>
        /// <returns>Retorna o produto solicitado</returns>
        /// <response code="200">Retorna o JSON com os dados do produto</response>
        /// <response code="404">Produto não encontrado</response>
        /// <response code="500">Erro interno de servidor</response>
        [HttpGet("{id}")]
        public ActionResult<TbProduct> GetById(int id)
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

    }
}
