using Microsoft.EntityFrameworkCore;
using TestePraticoDev.Models;

namespace TestePraticoDev.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){ }

        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<ItemPedido> ItemPedido { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Pedido>()
              .HasKey(p => p.Id);

            builder.Entity<ItemPedido>()
                        .HasKey(ip => ip.Id);

            // Configuração da ForeignKey
            builder.Entity<ItemPedido>()
                        .HasOne(ip => ip.Pedido)        
                        .WithMany(p => p.ItensPedido)  
                        .HasForeignKey(ip => ip.PedidoId); 

            SetPropertyRules(builder);
        }

        private async void SetPropertyRules(ModelBuilder builder)
        {

            builder.Entity<Pedido>()
                .Property(u => u.Id)
                .IsRequired();

            builder.Entity<Pedido>()
                .Property(u => u.NomeCliente)
                .IsRequired();

            builder.Entity<Pedido>()
                .Property(u => u.Data)
                .IsRequired();

            builder.Entity<Pedido>()
                .Property(u => u.ValorTotal)
                .IsRequired();

            builder.Entity<ItemPedido>()
             .HasKey(p => p.Id);

            builder.Entity<ItemPedido>()
                .Property(u => u.Id)
                .IsRequired();

            builder.Entity<ItemPedido>()
               .Property(u => u.PedidoId)
               .IsRequired();

            builder.Entity<ItemPedido>()
              .Property(u => u.NomeProduto)
              .IsRequired();

            builder.Entity<ItemPedido>()
              .Property(u => u.Valor)
              .IsRequired();

            builder.Entity<ItemPedido>()
              .Property(u => u.Quantidade)
              .IsRequired();
        }
    }
}
