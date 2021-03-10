using AutoMapper;
using BlueModas.Domain;
using BlueModas.Domain.Repositories;
using BlueModas.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueModas.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrinhoController : MainController
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CarrinhoController(IPedidoRepository pedidoRepository,
                                  IProdutoRepository produtoRepository,
                                  IUnitOfWork unitOfWork,
                                  IMapper mapper, 
                                  IClienteRepository clienteRepository)
        {
            _pedidoRepository = pedidoRepository;
            _produtoRepository = produtoRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ObterCarrinho()
        {
            var pedido = await _pedidoRepository.ObterPedidoEmRascunhoAsync();
            var pedidoViewModel = _mapper.Map<Pedido, PedidoViewModel>(pedido);

            return Ok(pedidoViewModel);
        }

        [HttpPost]
        [Route("finalizar-pedido")]
        public async Task<IActionResult> FinalizarPedido(ClienteViewModel viewModel)
        {
            var pedido = await _pedidoRepository.ObterPedidoEmRascunhoAsync();
            var cliente = await _clienteRepository.ObterPorEmailAsync(viewModel.Email);

            if (cliente is null)
            {
                cliente = new Cliente(viewModel.Nome, viewModel.Email, viewModel.Telefone);

                await _clienteRepository.AdicionarAsync(cliente);
            }

            if (pedido is null)
            {
                return BadRequest("Pedido não encontrado");
            }

            pedido.FinalizarPedido(cliente);

            _pedidoRepository.Atualizar(pedido);

            try
            {
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                return BadRequest("Ocorreu um erro ao finalizar o produto");
            }

            return Ok(new
                {
                    PedidoId = pedido.Id.ToString()
                });
        }

        [HttpPost("adicionar-item")]
        public async Task<IActionResult> AdicionarItem(AdicionarItemProdutoViewModel viewModel)
        {
            var pedido = await _pedidoRepository.ObterPedidoEmRascunhoAsync();
            var produto = await _produtoRepository.ObterPorIdAsync(viewModel.ProdutoId);

            if (produto is null)
            {
                return BadRequest("O produto não existe");
            }

            var itemPedido = new ItemPedido(produto.Id, produto.Nome, viewModel.Quantidade, produto.Preco);

            if (pedido is null)
            {
                pedido = new Pedido();

                pedido.AdicionarItem(itemPedido);

                await _pedidoRepository.AdicionarAsync(pedido);
            }
            else
            {
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
            }

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
            var pedido = await _pedidoRepository.ObterPedidoEmRascunhoAsync();

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
