﻿using BookZone.Models;
using BookZone.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookZone.DataAccess.Repository
{
	public interface IProductRepository : IRepository<Product>
	{
		void Update(CreateProductViewModel productvm);
		void AddProduct(CreateProductViewModel productvm);
		Product? GetFirstOrDefault(int id);

	}
}
