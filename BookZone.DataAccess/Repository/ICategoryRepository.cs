﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookZone.DataAccess.Repository
{
	public interface ICategoryRepository : IRepository<Category>
	{
		void Update(Category category);
		public IEnumerable<SelectListItem> GetSelectList();

	}
}
