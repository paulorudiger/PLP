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

        /// <summary>
        /// Rota para insercao de novos enderecos
        /// </summary>
        ///  <param name="enderecoDTO">json dos dados que serão atualizados.  
        ///     Obrigatorios: CEP, Logradouro, Numero, Bairro, Cidade, Clienteid, Status (0 - inativo1 - ativo)
        /// </param>
        /// <returns>Retorna o endereco inserido</returns>
        /// <response code="200">Retorna o Json com o endereco cadastrado</response>
        /// <response code="400">Os dados enviados não são válidos</response>
        /// <response code="422">Campos obrigatórios não enviados para a inserir endereco</response>
        /// <response code="500">Erro interno de servidor</response>
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
                _logger.LogError(E.Message);
                return BadRequest(E.Message);
            }

        }

        /// <summary>
        /// Rota para atualizacao de enderecos. 
        /// </summary>
        /// <param name="id">id do endereco que será atualizado</param>
        ///  <param name="enderecoDTO">json dos dados que serão atualizados.  
        ///     Obrigatorios: CEP, Logradouro, Numero, Bairro, Cidade, Clienteid, Status (0 - inativo1 - ativo)
        /// </param>
        /// <returns>Retorna o endereco inserido</returns>
        /// <response code="200">Retorna o Json com o endereco atualizado</response>
        /// <response code="400">Os dados enviados não são válidos</response>
        /// <response code="422">Campos obrigatórios não enviados para a atualizacão</response>
        /// <response code="500">Erro interno de servidor</response>
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
        /// Rota para delecao de enderecos. 
        /// </summary>
        /// <param name="id">id do endereco que será deletado</param>
        /// <returns>Retorna o endereco deletado</returns>
        /// <response code="204">Retorna que o servidor executou com sucesso mas não tem nada a retornar</response>
        /// <response code="404">Endereço não encontrado</response>
        /// <response code="500">Erro interno de servidor</response>
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
        /// Rota para consulta de endereco já cadastrado. 
        /// </summary>
        /// <param name="id">id do endereco que será consultado </param>,
        /// <returns>Retorna o endereco solicitado</returns>
        /// <response code="200">Retorna o Json com os dados do endereço</response>
        /// <response code="404">Endereço não encontrado</response>
        /// <response code="500">Erro interno de servidor</response>
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
                _logger.LogError(E.Message);
                return NotFound(E.Message);
            }
            catch (System.Exception E)
            {
                _logger.LogError(E.Message);
                return new ObjectResult(new { error = E.Message })
                {
                    StatusCode = 500
                };
            }
        }


        /// <summary>
        /// Rota para consulta de enderecos de um cliente. 
        /// </summary>
        /// <param name="Clienteid">id do cliente que será consultado</param>,
        /// <returns>Retorna a lista de enderecos do clinete informado</returns>
        /// <response code="200">Retorna o Json com os dados do endereço</response>
        /// <response code="404">Endereço não encontrado</response>
        /// <response code="500">Erro interno de servidor</response>
        [HttpGet("/getAllByClienteid/{Clienteid}")]
        public ActionResult<TbEndereco> GetAll(int Clienteid)
        {
            try
            {
                var entity = _service.GetAll(Clienteid);
                return Ok(entity);
            }
            catch (NotFoundException E)
            {
                _logger.LogError(E.Message);
                return NotFound(E.Message);
            }
            catch (System.Exception E)
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
