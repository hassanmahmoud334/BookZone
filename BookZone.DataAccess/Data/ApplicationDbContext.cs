namespace BookZone.DataAccess.Data
{ 
	public class ApplicationDbContext :DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}
		public DbSet<Category> Categories { get; set; }
		override protected void OnModelCreating(ModelBuilder modelBuilder)
		{
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
		}
	}
}
