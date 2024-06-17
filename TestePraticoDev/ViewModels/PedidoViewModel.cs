using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestePraticoDev.ViewModels
{
    public class PedidoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do cliente é obrigatório.")]
        [StringLength(100)]
        [MinLength(2, ErrorMessage = "O nome do cliente deve ter no mínimo 2 caracteres.")]
        public string? NomeCliente { get; set; }

        [Required(ErrorMessage = "A data do pedido é obrigatória.")]
        [DataType(DataType.Date, ErrorMessage = "Formato de data inválido.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O valor é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero.")]
        public decimal ValorTotal { get; set; }

        public int QuantidadeItens { get; set; }

        public List<ItemPedidoViewModel>? ItensPedido { get; set; }
    }

    public class ItemPedidoViewModel 
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public string? NomeProduto { get; set; }
        public int QuantidadeProduto { get; set; }
        public decimal Valor { get; set; }
    }
}
