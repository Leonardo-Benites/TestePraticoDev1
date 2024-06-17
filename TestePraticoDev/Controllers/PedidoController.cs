using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TestePraticoDev.Context;
using TestePraticoDev.Services.Interfaces;
using TestePraticoDev.ViewModels;

namespace TestePraticoDev.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(AppDbContext context, IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _pedidoService.GetAll());
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View(new PedidoViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PedidoViewModel pedido)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(pedido);
                }

                await _pedidoService.Insert(pedido);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                //tratar excessão
                return View();
            }
        }

        public async Task <IActionResult> Edit(int id)
        {
            var pedido = await _pedidoService.GetPedidoById(id);
            pedido.ItensPedido = await _pedidoService.GetItensPedidoById(id);
            pedido.QuantidadeItens = pedido.ItensPedido.Count;
            return View(pedido);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PedidoViewModel pedido)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(pedido);
                }

                await _pedidoService.Update(pedido);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _pedidoService.GetPedidoById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(PedidoViewModel pedido)
        {
            try
            {
                await _pedidoService.Delete(pedido);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
