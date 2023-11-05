﻿using BookZone.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookZone.DataAccess.Repository
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly ApplicationDbContext _dbContext;
		internal DbSet<T> dbSet { get; set; }
		public Repository(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
			this.dbSet= _dbContext.Set<T>();
		}
		public void Add(T entity)
		{
			dbSet.Add(entity);
		}

		public void Remove(T entity)
		{
			dbSet.Remove(entity);
		}

		public void RemoveRange(IEnumerable<T> entities)
		{
			dbSet.RemoveRange(entities);
		}

		public T Get(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] properties)
		{
			IQueryable<T> query=dbSet;
			query= query = properties.Aggregate(query, (current, property) => current.Include(property));
			return query.First(filter);
		}
		public Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] properties)
		{
			if (properties is not null)
			{
				IQueryable<T> query = dbSet;
				query = properties.Aggregate(query, (current, property) => current.Include(property));
				return query.FirstOrDefaultAsync(filter);
			}
			return dbSet.FirstOrDefaultAsync(filter);
		}


		public IEnumerable<T> GetAll()
		{
			IQueryable<T> query = dbSet;
			return query.ToList();
		}
	}
}
