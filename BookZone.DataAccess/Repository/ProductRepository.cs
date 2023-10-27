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
			// Retrieve the existing product from the database to include its current product categories
			Product? existingProduct = _dbContext.Products
				.Include(p => p.ProductCategories)
				.SingleOrDefault(p => p.Id == product.Id);

			if (existingProduct == null)
			{
				// Handle the case where the product is not found
				throw new InvalidOperationException("Product not found.");
			}

			// Remove the old product categories that are not present in the SelectedCategories list
			var categoriesToRemove = existingProduct.ProductCategories
				.Where(pc => !product.SelectedCategories.Contains(pc.CategoryId))
				.ToList();

			foreach (var categoryToRemove in categoriesToRemove)
			{
				existingProduct.ProductCategories.Remove(categoryToRemove);
			}

			// Add new product categories from the SelectedCategories list
			var newCategoryIds = product.SelectedCategories
				.Except(existingProduct.ProductCategories.Select(pc => pc.CategoryId))
				.ToList();

			foreach (var categoryId in newCategoryIds)
			{
				existingProduct.ProductCategories.Add(new ProductCategory { CategoryId = categoryId });
			}

			_dbContext.SaveChanges();
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
