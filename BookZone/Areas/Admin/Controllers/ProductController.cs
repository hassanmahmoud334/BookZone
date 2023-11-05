using BookZone.DataAccess.Repository;
using BookZone.Models;
using BookZone.Models.ViewModels;
using BookZone.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BookZone.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class ProductController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		public readonly IWebHostEnvironment _webHostEnvironment;
		public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
		{
			_unitOfWork = unitOfWork;
			_webHostEnvironment = webHostEnvironment;
		}
		public IActionResult Index()
		{
			var objProductList = _unitOfWork.Product.GetAll();
			return View(objProductList);
		}
		public IActionResult Create()
		{
			CreateProductViewModel productvm = new()
			{
				Categories = _unitOfWork.Category.GetSelectList(),
				Product = new Product()
			};
			return View(productvm);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(CreateProductViewModel productvm,IFormFile? file)
		{
			if (!ModelState.IsValid)
			{
				productvm.Categories = _unitOfWork.Category.GetSelectList();
				return View(productvm);
			}
			    string webRootPath = _webHostEnvironment.WebRootPath;
			if(file != null)
			{
				string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
				var productPath = Path.Combine(webRootPath, @"assets\images\product"); 
				using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
				{
					file.CopyTo(fileStream);
				}
				productvm.Product.ImageUrl = @"\assets\images\product\" + fileName;
			}
			else
			{
				productvm.Categories = _unitOfWork.Category.GetSelectList();
				return View(productvm);
			}
				_unitOfWork.Product.AddProduct(productvm);
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
			var obj = await _unitOfWork.Product.GetFirstOrDefaultAsync(c => c.Id == Id, properties: c => c.ProductCategories);
			if (obj == null)
			{
				return NotFound();
			}
			CreateProductViewModel productvm = new()
			{
				Product = obj,
				Categories = _unitOfWork.Category.GetSelectList(),
				SelectedCategories = obj.ProductCategories.Select(c => c.CategoryId).ToList()
			};
			return View(productvm);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(int id,CreateProductViewModel productvm, IFormFile? file)
		{
			if (!ModelState.IsValid)
			{
				productvm.Categories = _unitOfWork.Category.GetSelectList();
				return View(productvm);
			}
			string webRootPath = _webHostEnvironment.WebRootPath;
			if (file != null)
			{
				string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
				var productPath = Path.Combine(webRootPath, @"assets\images\product");
				if (!string.IsNullOrEmpty(productvm.Product.ImageUrl))
				{
					//this is an edit and we need to remove old image
					var oldimagePath = Path.Combine(webRootPath, productvm.Product.ImageUrl.TrimStart('\\'));
					if (System.IO.File.Exists(oldimagePath))
					{
						System.IO.File.Delete(oldimagePath);
					}
				}
				using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
				{
					file.CopyTo(fileStream);
				}
				productvm.Product.ImageUrl = @"\assets\images\product\" + fileName;
			}
			productvm.Product.Id = id;
			_unitOfWork.Product.Update(productvm);
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
			string webRootPath = _webHostEnvironment.WebRootPath;

			if (obj.ImageUrl!=null)
			{
				var oldimagePath = Path.Combine(webRootPath, obj.ImageUrl.TrimStart('\\'));
				if (System.IO.File.Exists(oldimagePath))
				{
					System.IO.File.Delete(oldimagePath);
				}
			}
			_unitOfWork.Product.Remove(obj);
			_unitOfWork.Save();
			TempData["Success"] = "Product has been deleted successfully";
			return RedirectToAction(nameof(Index));
		}
		#region API CALLS
		[HttpGet]
		public IActionResult GetAll()
		{
			var allObj = _unitOfWork.Product.GetAll();
			return Json(new { data = allObj });
		}
		//[HttpDelete]
		//public IActionResult Delete(int id)
		//{
		//	var productToBeDeleted = _unitOfWork.Product.Get(c => c.Id == id);
		//	if (productToBeDeleted == null)
		//	{
		//		return Json(new { success = false, message = "Error while deleting" });
		//	}
		//	string webRootPath = _webHostEnvironment.WebRootPath;

		//	if (productToBeDeleted.ImageUrl != null)
		//	{
		//		var oldimagePath = Path.Combine(webRootPath, productToBeDeleted.ImageUrl.TrimStart('\\'));
		//		if (System.IO.File.Exists(oldimagePath))
		//		{
		//			System.IO.File.Delete(oldimagePath);
		//		}
		//		_unitOfWork.Product.Remove(productToBeDeleted);
		//	_unitOfWork.Save();
		//	return Json(new { success = true, message = "Delete Successful" });
		//}
		#endregion
	}
}
