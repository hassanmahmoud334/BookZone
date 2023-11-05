using BookZone.DataAccess.Repository;
using BookZone.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookZone.Areas.Customer.Controllers
{
	[Area("Customer")]
	public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger,IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var Products = _unitOfWork.Product.GetAll();
            return View(Products);
        }
        public IActionResult Details(int id)
        {
            //Product Product = _unitOfWork.Product.Get(p => p.Id == id, properties: c=>c.ProductCategories);
            Product Product = _unitOfWork.Product.GetFirstOrDefault(id);
			return View(Product);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}