using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestePraticoDev.Context;
using TestePraticoDev.Models;

namespace TestePraticoDev.Repositories
{
    public class PedidoRepository
    {
        private readonly AppDbContext _context;

        public PedidoRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Pedido> GetPedidoById(int id)
        {
            return await _context.Pedido.FindAsync(id); 
        }
        public async Task<List<ItemPedido>> GetItensPedidoById(int id)
        {
            return await _context.ItemPedido.Where(x => x.PedidoId == id).ToListAsync();
        }

        public async Task<List<Pedido>> GetAll()
        {
            var date = DateTime.Now;
            return await _context.Pedido.ToListAsync();
        }
        public async Task Insert(Pedido obj)
        {
            _context.Pedido.Add(obj);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Pedido obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task Delete(Pedido obj)
        {
            _context.Pedido.Remove(obj);
            await _context.SaveChangesAsync();
        }
    }
}
