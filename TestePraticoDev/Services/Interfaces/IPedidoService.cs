using System.Collections.Generic;
using System.Threading.Tasks;
using TestePraticoDev.ViewModels;

namespace TestePraticoDev.Services.Interfaces
{
    public interface IPedidoService
    {
        public Task<PedidoViewModel> GetPedidoById(int id);
        public Task<List<ItemPedidoViewModel>> GetItensPedidoById(int id);
        public Task<List<PedidoViewModel>> GetAll();
        public Task Insert(PedidoViewModel viewModel);
        public Task Update(PedidoViewModel viewModel);
        public Task Delete(PedidoViewModel viewModel);
    }
}
