using BookZone.DataAccess.Data;
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
			//var obj = _dbContext.Categories.FirstOrDefault(s => s.Id == category.Id);
			//if (obj != null)
			//{
			//	obj.Name = category.Name;
			//	_dbContext.SaveChanges();
			//}
			_dbContext.Update(category);
		}
		public void Save()
		{
			_dbContext.SaveChanges();
		}
	}
}
