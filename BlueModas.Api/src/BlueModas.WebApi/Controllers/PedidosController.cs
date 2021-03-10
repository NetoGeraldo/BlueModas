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
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public PedidosController(IPedidoRepository pedidoRepository, IClienteRepository clienteRepository, IMapper mapper)
        {
            _pedidoRepository = pedidoRepository;
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> ObterPedido(Guid id)
        {
            var pedido = await _pedidoRepository.ObterPorIdAsync(id);

            if (pedido is null)
                return BadRequest("Pedido não encontrado");

            var cliente = await _clienteRepository.ObterPorIdAsync(pedido.ClienteId.Value);

            if (cliente is null)
                return BadRequest("Cliente não encontrado");

            var pedidoFinalizadoViewModel = new PedidoFinalizadoViewModel
            {
                NumeroPedido = pedido.Id.ToString(),
                Email = cliente.Email,
                Nome = cliente.Nome,
                Telefone = cliente.Telefone,
                ItensPedidos = _mapper.Map<List<ItemPedido>, List<ItemPedidoViewModel>>(pedido.ItensPedido.ToList()),
                ValorTotal = pedido.ValorTotal,
            };

            return Ok(pedidoFinalizadoViewModel);
        }
    }
}
