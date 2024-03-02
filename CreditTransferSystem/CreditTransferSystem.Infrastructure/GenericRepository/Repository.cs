﻿using CreditTransferSystem.Domain.IGenericRepository;
using CreditTransferSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CreditTransferSystem.Infrastructure.GenericRepository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity == null)
            {
                throw new InvalidOperationException("Entity not found");
            }

            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity, int id)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
