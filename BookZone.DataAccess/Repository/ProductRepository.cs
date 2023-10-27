using BookZone.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookZone.DataAccess.Repository
{
	public class ProductRepository : Repository<Product>, IProductRepository
	{
		private readonly ApplicationDbContext _dbContext;
		public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}
		public void Update(Product product)
		{
			product.ProductCategories = product.SelectedCategories.Select(d => new ProductCategory { CategoryId = d }).ToList();
			_dbContext.Products.Update(product);
		}
		public new IEnumerable<Product> GetAll()
		{
			return _dbContext.Products
				.Include(c => c.ProductCategories)
				.ThenInclude(cp=>cp.Category)
				.ToList();
		}
		public new void Add(Product product)
		{
			product.ProductCategories = product.SelectedCategories.Select(d => new ProductCategory { CategoryId = d }).ToList();
			_dbContext.Products.Add(product);
		}
	}
	
}
