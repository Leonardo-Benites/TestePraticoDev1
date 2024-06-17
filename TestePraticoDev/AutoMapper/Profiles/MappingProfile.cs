using AutoMapper;
using TestePraticoDev.Models;
using TestePraticoDev.ViewModels;

namespace TestePraticoDev.AutoMapper.Profiles
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Pedido, PedidoViewModel>()
				.ReverseMap();

			CreateMap<ItemPedido, ItemPedidoViewModel>()
				.ReverseMap();
		}
	}
}
