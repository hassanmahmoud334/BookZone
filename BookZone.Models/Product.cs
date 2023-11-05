using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookZone.Models
{
	public class Product
	{
		public int Id { get; set; }
		[MaxLength(150)]
		public string Title { get; set; } = string.Empty;
		[MaxLength(100)]
		public string Author { get; set; } = string.Empty;
		[MaxLength(2500)]
		public string Description { get; set; } = string.Empty;
		public string ImageUrl { get; set; } = string.Empty;
		public decimal Price { get; set; }
		[Range(0, 100)]
		public int Discount { get; set;}
		public decimal PriceWithDiscount { get; set; }
		[Range(0, 10000)]
		public int Quantity { get; set; }
		[JsonIgnore]
		public ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();

	}
}
