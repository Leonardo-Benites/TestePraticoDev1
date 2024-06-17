using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestePraticoDev.Context;
using TestePraticoDev.Models;
using TestePraticoDev.Repositories;
using TestePraticoDev.Services.Interfaces;
using TestePraticoDev.ViewModels;

namespace TestePraticoDev.Services
{
    public class PedidoService : IPedidoService
    {
        readonly PedidoRepository _pedidoRepository;
        readonly IMapper _mapper;
        private static Random random = new Random();

        public PedidoService(AppDbContext context, IMapper mapper)
        {
            _pedidoRepository = new PedidoRepository(context);
            _mapper = mapper;
        }

        public async Task<PedidoViewModel> GetPedidoById(int id)
        {
            var pedido = await _pedidoRepository.GetPedidoById(id);
            return _mapper.Map<Pedido, PedidoViewModel>(pedido);
        }
        public async Task<List<ItemPedidoViewModel>> GetItensPedidoById(int id)
        {
            var itensPedido = await _pedidoRepository.GetItensPedidoById(id);
            return _mapper.Map<List<ItemPedido>, List<ItemPedidoViewModel>>(itensPedido);
        }

        public async Task<List<PedidoViewModel>> GetAll()
        {
            var pedidos = await _pedidoRepository.GetAll();
            return _mapper.Map<List<Pedido>, List<PedidoViewModel>>(pedidos);
        }

        public async Task Insert(PedidoViewModel viewModel)
        {
            if (viewModel.QuantidadeItens > 0)
                viewModel.ItensPedido = GerarItemPedidoAleatorio(viewModel.QuantidadeItens);
             
            var pedido = _mapper.Map<PedidoViewModel, Pedido>(viewModel);
            await _pedidoRepository.Insert(pedido);
        }

        public async Task Update(PedidoViewModel viewModel)
        {
            var pedido = _mapper.Map<PedidoViewModel, Pedido>(viewModel);
            await _pedidoRepository.Update(pedido);
        }

        public async Task Delete(PedidoViewModel viewModel)
        {
            var pedido = _mapper.Map<PedidoViewModel, Pedido>(viewModel);
            await _pedidoRepository.Delete(pedido);
        }

        private static List<ItemPedidoViewModel> GerarItemPedidoAleatorio(int quantidade)
        {
            string[] produtos = { "Produto A", "Produto B", "Produto C", "Produto D", "Produto E" };
            
            var itensPedido = new List<ItemPedidoViewModel>();
            decimal valorDefault = 500;

            for (int i = 0; i < quantidade; i++)
            {

                var itemPedido = new ItemPedidoViewModel
                {
                    Id = random.Next(1, 1000), 
                    NomeProduto = produtos[random.Next(produtos.Length)], 
                    Quantidade = 1, 
                    Valor = valorDefault, 
                };

                itensPedido.Add(itemPedido);
            }

            return itensPedido;
        }
    }
}
