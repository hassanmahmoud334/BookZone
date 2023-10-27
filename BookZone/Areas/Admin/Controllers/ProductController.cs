using BookZone.DataAccess.Repository;
using BookZone.Models;
using BookZone.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookZone.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ProductController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		public ProductController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public IActionResult Index()
		{
			var objProductList = _unitOfWork.Product.GetAll();
			return View(objProductList);
		}
		public IActionResult Create()
		{
			Product product = new()
			{
				Categories = _unitOfWork.Category.GetSelectList(),
			};
			return View(product);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Product obj)
		{
			if (!ModelState.IsValid)
			{
				obj.Categories = _unitOfWork.Category.GetSelectList();
				return View(obj);
			}
				_unitOfWork.Product.Add(obj);
				_unitOfWork.Save();
				TempData["Success"] = "The category has been created successfully";
				return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Edit(int? Id)
		{
			if (Id == null || Id == 0)
			{
				return NotFound();
			}
			//var obj = _unitOfWork.Product.Get(c => c.Id == Id);
			var obj = await _unitOfWork.Product.GetFirstOrDefaultAsync(c=>c.Id == Id,properties: c=>c.ProductCategories);
			if (obj == null)
			{
				return NotFound();
			}
			Product product = new()
			{
				Id = obj.Id,
				Title = obj.Title,
				Author = obj.Author,
				Description = obj.Description,
				ImageUrl = obj.ImageUrl,
				Price = obj.Price,
				Discount = obj.Discount,
				PriceWithDiscount = obj.PriceWithDiscount,
				Quantity = obj.Quantity,
				Categories = _unitOfWork.Category.GetSelectList(),
				SelectedCategories = obj.ProductCategories.Select(c => c.CategoryId).ToList()
			};
			return View(product);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Product obj)
		{
			if (!ModelState.IsValid)
			{
				obj.Categories = _unitOfWork.Category.GetSelectList();
				return View(obj);
			}
				 _unitOfWork.Product.Update(obj);
				//_unitOfWork.Save();
				TempData["Success"] = "Product has been updated successfully";
				return RedirectToAction(nameof(Index));
		}
		public IActionResult Delete(int? Id)
		{
			if (Id == null || Id == 0)
			{
				return NotFound();
			}
			var obj = _unitOfWork.Product.Get(c => c.Id == Id);
			if (obj == null)
			{
				return NotFound();
			}
			return View(obj);
		}
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeletePost(int? Id)
		{
			var obj = _unitOfWork.Product.Get(c => c.Id == Id);
			if (obj == null)
			{
				return NotFound();
			}
			_unitOfWork.Product.Remove(obj);
			_unitOfWork.Save();
			TempData["Success"] = "Product has been deleted successfully";
			return RedirectToAction(nameof(Index));
		}
	}
}
