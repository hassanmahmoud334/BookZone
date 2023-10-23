using BookZone.DataAccess.Data;
using BookZone.DataAccess.Repository;
using BookZone.Models;

namespace BookZone.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ICategoryRepository _categoryRepository;
		public CategoryController(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}
        public IActionResult Index()
		{
			var objCategoryList=_categoryRepository.GetAll();
			return View(objCategoryList);
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Category obj)
		{
			if (ModelState.IsValid)
			{
				_categoryRepository.Add(obj);
				_categoryRepository.Save();
				TempData["Success"] = "The category has been created successfully";
				return RedirectToAction("Index");
			}
			return View(obj);
		}
		public IActionResult Edit(int? Id)
		{
			if (Id == null || Id == 0)
			{
				return NotFound();
			}
			var obj = _categoryRepository.Get(c=>c.Id==Id);
			if (obj == null)
			{
				return NotFound();
			}
			return View(obj);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Category obj)
		{
			if (ModelState.IsValid)
			{
				_categoryRepository.Update(obj);
				_categoryRepository.Save();
				TempData["Success"] = "Category has been updated successfully";
				return RedirectToAction("Index");
			}
			return View(obj);
		}
		

		public IActionResult Delete(int? Id)
		{
			if (Id == null || Id == 0)
			{
				return NotFound();
			}
			var obj = _categoryRepository.Get(c => c.Id == Id);
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
			var obj = _categoryRepository.Get(c => c.Id == Id);
			if (obj == null)
			{
				return NotFound();
			}
			_categoryRepository.Delete(obj);
			_categoryRepository.Save();
			TempData["Success"] = "Category has been deleted successfully";
			return RedirectToAction("Index");
		}

		
	}
}
