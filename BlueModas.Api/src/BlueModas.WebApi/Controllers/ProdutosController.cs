using AutoMapper;
using BlueModas.Domain;
using BlueModas.Domain.Repositories;
using BlueModas.WebApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueModas.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : MainController
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutosController(IProdutoRepository produtoRepository, 
                                  IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ObterProdutosAsync()
        {
            var produtos = await _produtoRepository.ObterTodosAsync();

            var produtosViewModel = _mapper.Map<List<Produto>, List<ProdutoViewModel>>(produtos);

            return Ok(produtosViewModel);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> ObterProdutoAsync(Guid id)
        {
            var produto = await _produtoRepository.ObterPorIdAsync(id);

            var produtoViewModel = _mapper.Map<Produto, ProdutoViewModel>(produto);

            return Ok(produtoViewModel);
        }

    }
}
