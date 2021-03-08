using AutoMapper;
using BlueModas.Domain;
using BlueModas.Domain.Repositories;
using BlueModas.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BlueModas.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrinhoController : ControllerBase
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CarrinhoController(IPedidoRepository pedidoRepository,
                                  IProdutoRepository produtoRepository,
                                  IUnitOfWork unitOfWork, 
                                  IMapper mapper)
        {
            _pedidoRepository = pedidoRepository;
            _produtoRepository = produtoRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ObterCarrinho()
        {
            var pedido = await _pedidoRepository.ObterPorIdAsync(Guid.Parse("d7dd4a60-98dc-48cc-9e37-e3edfab91f97"));
            var pedidoViewModel = _mapper.Map<Pedido, PedidoViewModel>(pedido);

            return Ok(pedidoViewModel);
        }

        [HttpPost("adicionar-item")]
        public async Task<IActionResult> AdicionarItem(AdicionarItemProdutoViewModel viewModel)
        {
            var pedido = await _pedidoRepository.ObterPorIdAsync(Guid.Parse("d7dd4a60-98dc-48cc-9e37-e3edfab91f97"));
            var produto = await _produtoRepository.ObterPorIdAsync(viewModel.ProdutoId);

            if (produto is null)
            {
                return BadRequest("O produto não existe");
            }

            var itemPedido = new ItemPedido(pedido.Id, produto.Id, produto.Nome, viewModel.Quantidade, produto.Preco);

            bool itemExistente = pedido.ItemPedidoExistente(itemPedido);

            pedido.AdicionarItem(itemPedido);

            if (itemExistente)
            {
                _pedidoRepository.AtualizarItem(pedido.ItensPedido.SingleOrDefault(p => p.ProdutoId == itemPedido.ProdutoId));
            }
            else
            {
                await _pedidoRepository.AdicionarItemAsync(itemPedido);
            }

            _pedidoRepository.Atualizar(pedido);

            try
            {
                await _unitOfWork.CommitAsync();
            }
            catch (Exception e)
            {
                return BadRequest("Ocorreu um erro ao adicionar o item ");
            }

            return Ok();
        }

        [HttpPost("remover-item")]
        public async Task<IActionResult> RemoverItem(RemoverItemProdutoViewModel viewModel)
        {
            var pedido = await _pedidoRepository.ObterPorIdAsync(Guid.Parse("d7dd4a60-98dc-48cc-9e37-e3edfab91f97"));

            var produto = await _produtoRepository.ObterPorIdAsync(viewModel.ProdutoId);

            if (produto is null)
            {
                return BadRequest("O produto não existe");
            }

            var itemPedido = pedido.ItensPedido.SingleOrDefault(i => i.ProdutoId == viewModel.ProdutoId);

            if (itemPedido is null)
            {
                return BadRequest("O item deste pedido não existe");
            }

            if (pedido.ItemPedidoExistente(itemPedido))
            {
                pedido.RemoverItem(itemPedido);

                _pedidoRepository.RemoverItem(itemPedido);
                _pedidoRepository.Atualizar(pedido);

                await _unitOfWork.CommitAsync();
            }

            return Ok();
        }
    }
}
