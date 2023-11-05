using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BookZone.DataAccess.Data
{ 
	public class ApplicationDbContext :IdentityDbContext<IdentityUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}
		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<ProductCategory> ProductCategories { get; set; }
		public DbSet<ApplicationUser> ApplicationUsers { get; set; }
		override protected void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Product>()
				.Property(p => p.Price)
				.HasColumnType("decimal(18,2)");
			modelBuilder.Entity<Product>()
				.Property(p => p.PriceWithDiscount)
				.HasColumnType("decimal(18,2)");
			modelBuilder.Entity<ProductCategory>()
				.HasKey(pc => new { pc.ProductId, pc.CategoryId });
			modelBuilder.Entity<Category>()
				.HasData(

				new Category { Id = 1, Name = "Drama" },
				new Category { Id = 2, Name = "Action" },
				new Category { Id = 3, Name = "Romance" },
				new Category { Id = 4, Name = "Science Fiction" },
				new Category { Id = 5, Name = "Horror" },
				new Category { Id = 6, Name = "Thriller" },
				new Category { Id = 7, Name = "Mystery" },
				new Category { Id = 8, Name = "Crime" },
				new Category { Id = 9, Name = "Historical Fiction" },
				new Category { Id = 10, Name = "Cooking" },
				new Category { Id = 11, Name = "Art" },
				new Category { Id = 12, Name = "Self-help / Personal" },
				new Category { Id = 13, Name = "Development" },
				new Category { Id = 14, Name = "Motivational" },
				new Category { Id = 15, Name = "Health" },
				new Category { Id = 16, Name = "History" },
				new Category { Id = 17, Name = "Travel" },
				new Category { Id = 18, Name = "Guide / How-to" },
				new Category { Id = 19, Name = "Families & Relationships" },
				new Category { Id = 20, Name = "Humor" },
				new Category { Id = 21, Name = "Children's" },
				new Category { Id = 22, Name = "Other" });
			modelBuilder.Entity<Product>()
				.HasData(
				new Product
				{
					Id = 1,
					Title = "The Great Gatsby",
					Author = "F. Scott Fitzgerald",
					Description = "A novel about the American Dream",
					ImageUrl = "https://example.com/book1.jpg",
					Price = 12.99m,
					Discount = 0,
					PriceWithDiscount = 12.99m,
					Quantity = 20
					
				},
				new Product
				{
					Id = 2,
					Title = "To Kill a Mockingbird",
					Author = "Harper Lee",
					Description = "A story of racial injustice in the Deep South",
					ImageUrl = "https://example.com/book2.jpg",
					Price = 9.99m,
					Discount = 20,
					PriceWithDiscount = 7.99m,
					Quantity = 15
				},
				new Product
				{
					Id = 3,
					Title = "Harry Potter and the Philosopher's Stone",
					Author = "J.K. Rowling",
					Description = "The first book in the Harry Potter series",
					ImageUrl = "https://example.com/book3.jpg",
					Price = 14.99m,
					Discount = 10,
					PriceWithDiscount = 13.49m,
					Quantity = 8
				});



		}
	}
}
