using System;
using System.Collections.Generic;

namespace TestePraticoDev.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public string NomeCliente { get; set; }
        public DateTime Data { get; set; }
        public decimal ValorTotal { get; set; }
        public virtual ICollection<ItemPedido> ItensPedido { get; set; }
    }
}
