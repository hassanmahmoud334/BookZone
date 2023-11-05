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
		public Product Product { get; set; } =new Product();
		public List<int> SelectedCategories { get; set; } = default!;
		public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();
	}
}
