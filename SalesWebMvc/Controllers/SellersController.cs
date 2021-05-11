using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService; //Declarando uma dependencia

        public SellersController(SellerService sellerService) 
        {
            _sellerService = sellerService;
        }

        public IActionResult Index() //Chamando o Controllers
        {
            var list = _sellerService.FindAll(); // Controlador Acessou o Models e pegou o dado da lista
            return View(list); // Encaminhar os dados para View
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}
