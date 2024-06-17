using System.ComponentModel.DataAnnotations.Schema;

namespace TestePraticoDev.Models
{
    public class ItemPedido
    {
        public int Id { get; set; }
        [ForeignKey("Parent")]
        public int PedidoId { get; set; }
        public string NomeProduto { get; set; }
        public int Quantidade { get; set; } //produto
        public decimal Valor { get; set; }
        public virtual Pedido Pedido { get; set; }
    }
}
