using BookZone.DataAccess.Data;
using BookZone.Models.ViewModels;
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
		//public void Update(Product product)
		//{
		//	// Retrieve the existing product from the database to include its current product categories
		//	Product? existingProduct = _dbContext.Products
		//		.Include(p => p.ProductCategories)
		//		.SingleOrDefault(p => p.Id == product.Id);

		//	if (existingProduct == null)
		//	{
		//		// Handle the case where the product is not found
		//		throw new InvalidOperationException("Product not found.");
		//	}

		//	// Remove the old product categories that are not present in the SelectedCategories list
		//	var categoriesToRemove = existingProduct.ProductCategories
		//		.Where(pc => !product.SelectedCategories.Contains(pc.CategoryId))
		//		.ToList();

		//	foreach (var categoryToRemove in categoriesToRemove)
		//	{
		//		existingProduct.ProductCategories.Remove(categoryToRemove);
		//	}

		//	// Add new product categories from the SelectedCategories list
		//	var newCategoryIds = product.SelectedCategories
		//		.Except(existingProduct.ProductCategories.Select(pc => pc.CategoryId))
		//		.ToList();

		//	foreach (var categoryId in newCategoryIds)
		//	{
		//		existingProduct.ProductCategories.Add(new ProductCategory { CategoryId = categoryId });
		//	}

		//	_dbContext.SaveChanges();
		//}
		public new IEnumerable<Product> GetAll()
		{
			return _dbContext.Products
				.Include(c => c.ProductCategories)
				.ThenInclude(cp=>cp.Category)
				.ToList();
		}
		public Product? GetFirstOrDefault(int id)
		{
			return _dbContext.Products.Include(c => c.ProductCategories).ThenInclude(c=>c.Category).FirstOrDefault(p => p.Id == id);
		}
		public void Update(CreateProductViewModel productvm)
		{
			Product? product = _dbContext.Products
				.Include(p => p.ProductCategories)
				.SingleOrDefault(p => p.Id == productvm.Product.Id);
			if (product == null)
			{
				throw new InvalidOperationException("Product not found.");
			}
			product.Author= productvm.Product.Author;
			product.Description = productvm.Product.Description;
			product.Price = productvm.Product.Price;
			product.Title = productvm.Product.Title;
			product.Discount = productvm.Product.Discount;
			product.PriceWithDiscount = productvm.Product.PriceWithDiscount;
			product.Quantity = productvm.Product.Quantity;
			product.ImageUrl = productvm.Product.ImageUrl;
			product.ProductCategories = productvm.SelectedCategories
				.Select(d => new ProductCategory { CategoryId = d }).ToList();
			_dbContext.Products.Update(product);
			_dbContext.SaveChanges();
		}
		public void AddProduct(CreateProductViewModel productvm)
		{
			productvm.Product.ProductCategories = productvm.SelectedCategories
				.Select(d => new ProductCategory { CategoryId = d }).ToList();
			_dbContext.Products.Add(productvm.Product);
		}
	}
	
}
