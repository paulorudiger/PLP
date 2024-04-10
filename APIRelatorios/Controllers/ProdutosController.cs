using APIRelatorios.Database.Models;
using APIRelatorios.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Mime;

namespace APIRelatorios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(
        MediaTypeNames.Application.Json, 
        MediaTypeNames.Application.Xml)]
    [Consumes(MediaTypeNames.Application.Json)]

    public class ProdutosController : ControllerBase
    {

        private readonly ProdutoService _produtoService;

        public ProdutosController(ProdutoService produtoService)
        {

            _produtoService = produtoService;
        }

        [HttpGet()]
        public ActionResult<List<Produto>> GetAll()
        {
            return Ok(_produtoService.GetAll());
        }

        [HttpGet(":codigo")]
        public ActionResult<Produto> GetByCodigo(int codigo)
        {

            try
            {
                var produto = _produtoService.GetByCodigo(codigo);
                return Ok(produto);
            }
            catch (NotFoundException)
            {
                return NotFound("Produto não encotrado!");

            }
            catch (Exception e)
            {
                return BadRequest("Ocorreu um erro inesperado! " +
                    e.Message);
            }
        }


    }
}
