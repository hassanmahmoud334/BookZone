using BookZone.DataAccess.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookZone.DataAccess.Repository
{
	public class CategoryRepository : Repository<Category>,ICategoryRepository
	{
		private readonly ApplicationDbContext _dbContext;
		public CategoryRepository(ApplicationDbContext dbContext):base(dbContext)
		{
			_dbContext = dbContext;
		}
		public void Update(Category category)
		{
			_dbContext.Categories.Update(category);
		}
		public IEnumerable<SelectListItem> GetSelectList()
		{
			return _dbContext.Categories
				.Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() })
				.OrderBy(c => c.Text)
				.AsNoTracking()
				.ToList();
		}
	}
}
