using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookZone.Models.ViewModels
{
	public class CreateProductViewModel
	{
		[MaxLength(150)]
		public string Title { get; set; } = string.Empty;
		[MaxLength(100)]
		public string Author { get; set; } = string.Empty;
		[MaxLength(2500)]
		public string Description { get; set; } = string.Empty;
		public IFormFile ImageUrl { get; set; } = default!;
		public decimal Price { get; set; }
		[Range(0, 100)]
		public int Discount { get; set; }
		public decimal PriceWithDiscount { get; set; }
		[Range(0, 10000)]
		public int Quantity { get; set; }
		public List<int> SelectedCategories { get; set; } = default!;
		public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();
	}
}
